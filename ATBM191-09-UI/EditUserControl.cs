﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATBM191_09_UI.DAO;

namespace ATBM191_09_UI
{
    public partial class EditUserControl : Form
    {
        public class UserProperties
        {
            public String username;
            public String password;

            //List<KeyValuePair <string, int>> sys_privs_granted_before = new List<bool>();

            public List<List<bool>> role_granted_before = new List<List<bool>>();
            public List<List<bool>> role_granted_after = new List<List<bool>>();
        }

        UserProperties userProperties = new UserProperties();

        public EditUserControl(String username)
        {
            InitializeComponent();
            userProperties.username = username;
            username_textbox.Text = username;        
            username_textbox.ReadOnly = true;

            LoadRoles();
            LoadTables();
            LoadSysPrivs();


            role_datagridview.CellContentClick += Role_Grant_Click;
        }

        private bool getInput()
        {           
            userProperties.password = password_textbox.Text;

            if (userProperties.username == "" || userProperties.password == "")
            {
                return false;
            }
            return true;
        }

        private void addCheckboxColumn(DataGridView gridView, String columnName)
        {
            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
            checkboxColumn.Name = columnName;
            
            if (gridView.Columns[columnName] == null)
            {
                gridView.Columns.Add(checkboxColumn);
            }
        }

        private void addTextboxColumn(DataGridView gridView, String columnName)
        {
            DataGridViewTextBoxColumn textboxColumn = new DataGridViewTextBoxColumn();
            textboxColumn.Name = columnName;

            if (gridView.Columns[columnName] == null)
            {
                gridView.Columns.Add(textboxColumn);
            }
        }

        private void Role_Grant_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if(e.ColumnIndex == role_datagridview.Columns["Granted"].Index) {
                    if (userProperties.role_granted_after[e.RowIndex][0])
                        role_datagridview.Rows[e.RowIndex].Cells["Admin"].Value = userProperties.role_granted_after[e.RowIndex][1] = false;
                    userProperties.role_granted_after[e.RowIndex][0] = !userProperties.role_granted_after[e.RowIndex][0];
                }
                if (e.ColumnIndex == role_datagridview.Columns["Admin"].Index) {
                    if (!userProperties.role_granted_after[e.RowIndex][1])
                        role_datagridview.Rows[e.RowIndex].Cells["Granted"].Value = userProperties.role_granted_after[e.RowIndex][0] = true;
                    userProperties.role_granted_after[e.RowIndex][1] = !userProperties.role_granted_after[e.RowIndex][1];
                }
                MessageBox.Show(userProperties.role_granted_after[e.RowIndex][0].ToString() + " " + userProperties.role_granted_after[e.RowIndex][1].ToString());
            }
        }

        private void LoadRoles()
        {

            DataSet dataSet = DataProvider.Instance.ExecuteQuery(
                @"select ar.role, gr.admin_option, gr.grantee
                   from dba_roles ar LEFT JOIN dba_role_privs gr on(ar.role = gr.granted_role and gr.grantee = '" + userProperties.username + "')" +
                   "order by ar.role");

            role_datagridview.Columns.Clear();
            if (dataSet != null)
            {
                addTextboxColumn(role_datagridview, "Role");
                addCheckboxColumn(role_datagridview, "Granted");
                addCheckboxColumn(role_datagridview, "Admin");

                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    role_datagridview.Rows.Add();
                    DataRow objectPrivRow = dataSet.Tables[0].Rows[i];
                    DataGridViewRow gridViewRow = role_datagridview.Rows[i];
                    gridViewRow.Cells["Role"].Value = objectPrivRow["role"].ToString();
                    gridViewRow.Cells["Granted"].Value = (objectPrivRow["grantee"].ToString() != "");
                    gridViewRow.Cells["Admin"].Value = (objectPrivRow["admin_option"].ToString() == "YES");

                    bool granted = (objectPrivRow["grantee"].ToString() != "");
                    bool admin = (objectPrivRow["admin_option"].ToString() == "YES");
                    userProperties.role_granted_before.Add(new List<bool>() { granted, admin });
                    userProperties.role_granted_after.Add(new List<bool>() { granted, admin });
                }
            }
        }

        private void SaveRoles()
        {
            bool grant_before;
            bool admin_before;
            bool grant_after;
            bool admin_after;
            String failedGrant = "";
            String failedRevoke = "";
            String role;
            for (int i = 0; i < userProperties.role_granted_before.Count; ++i)
            {
                grant_before = userProperties.role_granted_before[i][0];
                admin_before = userProperties.role_granted_before[i][1];
                grant_after = userProperties.role_granted_after[i][0];
                admin_after = userProperties.role_granted_after[i][1];
                role = role_datagridview.Rows[i].Cells["Role"].Value.ToString();
                if (!grant_before && !admin_before && grant_after && !admin_after)
                {
                    // grant
                    if(DataProvider.Instance.ExecuteScalar($"GRANT {role} TO {userProperties.username}") == null)
                    {
                        failedGrant += role + ", ";
                    }
                }
                if(!admin_before && admin_after)
                {
                    // grant admin
                    if (DataProvider.Instance.ExecuteScalar($"GRANT {role} TO {userProperties.username} WITH ADMIN OPTION") == null)
                    {
                        failedGrant += role + ", ";
                    }
                }
                if(grant_before & !grant_after)
                {
                    // revoke
                    if (DataProvider.Instance.ExecuteScalar($"REVOKE {role} FROM {userProperties.username}") == null)
                    {
                        failedRevoke += role + ", ";
                    }
                }
                if(grant_before && admin_before && grant_after && !admin_after)
                {
                    // revoke
                    if(DataProvider.Instance.ExecuteScalar($"REVOKE {role} FROM {userProperties.username}") == null)
                    {
                        failedRevoke += role + ", ";
                    }
                    // grant
                    else if (DataProvider.Instance.ExecuteScalar($"GRANT {role} TO {userProperties.username}") == null)
                    {
                        failedGrant += role + ", ";
                    }
                    // grant
                }
            }
            String failStr = "";
            if(failedGrant != "")
            {
                failStr += @"Không thể GRANT các role:
" + failedGrant;
            }
            if(failedRevoke != "")
            {
                failStr += @"Không thể REVOKE các role:
" + failedRevoke;
            }
            if(failStr != "")
            {
                MessageBox.Show(failStr);
            }
        }

        private void LoadTables()
        {            
            //Lấy danh sách tables và views
            DataSet dataSet = DataProvider.Instance.ExecuteQuery(
                "select distinct table_name from user_tab_columns");
            if (dataSet != null)
            {
                // Thêm cột combox là các tables và views
                DataGridViewComboBoxColumn tablesCombobox = new DataGridViewComboBoxColumn();
                tablesCombobox.HeaderText = "Tables/Views";
                tablesCombobox.Name = "Tables";

                //Chuyển dataset thành list<string>
                List<String> tables = new List<string>();
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    tables.Add(row[0].ToString());
                }
                tablesCombobox.DataSource = tables;
                table_datagridview.Columns.Add(tablesCombobox);
            }
            
            // Thêm combobox các privileges
            DataGridViewComboBoxColumn privilegesCombobox = new DataGridViewComboBoxColumn();
            List<String> privileges = new List<String>() { "SELECT", "INSERT", "UPDATE", "DELETE" };
            privilegesCombobox.DataSource = privileges;
            privilegesCombobox.Name = "Privileges";
            privilegesCombobox.HeaderText = "Privileges";
            table_datagridview.Columns.Add(privilegesCombobox);

            // Thêm check box Grantable
            addCheckboxColumn(table_datagridview, "Grantable");

            // Lấy thông tin về object privilege của user
            DataSet userDetailsDataSet = DataProvider.Instance.ExecuteQuery(
                $"select GRANTEE AS \"USER\", TABLE_NAME, \"PRIVILEGE\", GRANTABLE, GRANTOR from dba_tab_privs where GRANTEE ='{userProperties.username}'");
            
            // Gán những thông tin này vô datagridview 
            for (int i = 0; i < userDetailsDataSet.Tables[0].Rows.Count; i++)
            {
                table_datagridview.Rows.AddCopy(0);     //Tạo một dòng mới trong bảng

                // Đổ data từ userDetailsDataSet vào trong table grid view
                DataRow objectPrivRow = userDetailsDataSet.Tables[0].Rows[i];
                DataGridViewRow gridViewRow = table_datagridview.Rows[i];
                gridViewRow.Cells["Tables"].Value = objectPrivRow["TABLE_NAME"].ToString();
                gridViewRow.Cells["Privileges"].Value = objectPrivRow["PRIVILEGE"].ToString();
                gridViewRow.Cells["Grantable"].Value = (objectPrivRow["GRANTABLE"].ToString() == "YES");

                //Set readonly
                gridViewRow.Cells["Tables"].ReadOnly = true;
                gridViewRow.Cells["Privileges"].ReadOnly = true;
                gridViewRow.Cells["Grantable"].ReadOnly = true;
            }
        }

        private void LoadSysPrivs()
        {
            privs_datagridview.Columns.Clear();

            //Lấy danh sách system privileges 
            DataSet dataSet = DataProvider.Instance.ExecuteQuery(
                @"select sp.name, upr.admin_option, upr.grantee 
                    from system_privilege_map sp 
                        left join dba_sys_privs upr 
                        on (sp.name = upr.privilege and upr.grantee = '" + userProperties.username + "')" +
                    "order by sp.name");

            // Thêm các column
            DataGridViewTextBoxColumn privNameColumn = new DataGridViewTextBoxColumn();
            privNameColumn.HeaderText = "SYSTEM PRVILEGE";
            privNameColumn.Name = "SysPrivs";
            privs_datagridview.Columns.Add(privNameColumn);

            addCheckboxColumn(privs_datagridview, "Granted");
            addCheckboxColumn(privs_datagridview, "Admin");

            if (dataSet != null)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    privs_datagridview.Rows.Add();     //Tạo một dòng mới trong bảng

                    // Đổ data từ userDetailsDataSet vào trong table grid view
                    DataRow sysPrivRow = dataSet.Tables[0].Rows[i];
                    DataGridViewRow gridViewRow = privs_datagridview.Rows[i];

                    gridViewRow.Cells["SysPrivs"].Value = sysPrivRow["name"].ToString();
                    gridViewRow.Cells["Granted"].Value = (sysPrivRow["grantee"].ToString() != "");
                    gridViewRow.Cells["Admin"].Value = (sysPrivRow["admin_option"].ToString() == "YES");

                    //Set readonly
                    gridViewRow.Cells["SysPrivs"].ReadOnly = true;
                }                                    
            }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            SaveRoles();
            this.Close();
        }
    }
}
