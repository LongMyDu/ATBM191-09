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

            public List<List<bool>> role_granted_before = new List<List<bool>>();
            public List<List<bool>> role_granted_after = new List<List<bool>>();
            public List<List<bool>> sys_privs_granted_before = new List<List<bool>>(); // each tuple first ele is granted, second is admin
            public List<List<bool>> sys_privs_granted_after = new List<List<bool>>(); // each tuple first ele is granted, second is admin            

            public DataSet object_privs_before;
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
            privs_datagridview.CellContentClick += Sys_Privs_Granted_Click;
            table_datagridview.CellContentClick += Details_Button_Click;
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
                if (e.ColumnIndex == role_datagridview.Columns["Granted"].Index) {
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

        private void Sys_Privs_Granted_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {                
                if (e.ColumnIndex == privs_datagridview.Columns["Granted"].Index)
                {
                    //Nếu tick bỏ grant thì bỏ luôn admin
                    if (userProperties.sys_privs_granted_after[e.RowIndex][0] == true)
                    {
                        privs_datagridview.Rows[e.RowIndex].Cells["Admin"].Value =
                            userProperties.sys_privs_granted_after[e.RowIndex][1] = false;
                    }
                    userProperties.sys_privs_granted_after[e.RowIndex][0] =
                    !userProperties.sys_privs_granted_after[e.RowIndex][0];
                }

                if (e.ColumnIndex == privs_datagridview.Columns["Admin"].Index)
                {
                    //Nếu tick admin thì tick luôn grant
                    if (userProperties.sys_privs_granted_after[e.RowIndex][1] == false)
                    {
                        privs_datagridview.Rows[e.RowIndex].Cells["Granted"].Value =
                            userProperties.sys_privs_granted_after[e.RowIndex][0] = true;
                    }

                    userProperties.sys_privs_granted_after[e.RowIndex][1] =
                    !userProperties.sys_privs_granted_after[e.RowIndex][1];
                }

                MessageBox.Show(userProperties.sys_privs_granted_after[e.RowIndex][0].ToString() + userProperties.sys_privs_granted_after[e.RowIndex][1].ToString());
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
                failStr += "Không thể GRANT các role:\n" + failedGrant;
            }
            if(failedRevoke != "")
            {
                failStr += "Không thể REVOKE các role:\n" + failedRevoke;
            }
            if(failStr != "")
            {
                MessageBox.Show(failStr);
            }
        }

        private void Details_Button_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (table_datagridview.Columns["ViewDetailButton"] != null &&
                e.ColumnIndex == table_datagridview.Columns["ViewDetailButton"].Index && e.RowIndex >= 0)
            {
                String table_name = table_datagridview.Rows[e.RowIndex].Cells["Tables"].Value.ToString();
                LoadNoColPrivs(table_name);
                LoadColPrivs(table_name);
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
                table_datagridview.Columns.Insert(0, tablesCombobox);
            }

            // Lấy danh sách các bảng mà user có quyền
            DataSet userDetailsDataSet = DataProvider.Instance.ExecuteQuery(
                $"select distinct TABLE_NAME from dba_tab_privs where GRANTEE ='{userProperties.username}'"
            + $"UNION select distinct TABLE_NAME from User_col_privs where GRANTEE = '{userProperties.username}'");

            //// Lưu lại trạng thái before của các object privilege
            //userProperties.object_privs_before = userDetailsDataSet.Copy();

            if (userDetailsDataSet != null)
            {
                // Gán những thông tin này vô datagridview 
                for (int i = 0; i < userDetailsDataSet.Tables[0].Rows.Count; i++)
                {
                    table_datagridview.Rows.Add();          //Tạo một dòng mới trong bảng
                    table_datagridview.Rows[i].Cells["Tables"].Value
                        = userDetailsDataSet.Tables[0].Rows[i]["TABLE_NAME"].ToString();
                }
            }
            
        }

        private void LoadNoColPrivs(String tablename)
        {
            nocol_datagridview.Rows.Clear();

            // Lấy thông tin về object privilege của user
            DataSet noColPrivs = DataProvider.Instance.ExecuteQuery(
                $"select \"PRIVILEGE\", GRANTABLE from dba_tab_privs where GRANTEE ='{userProperties.username}' AND TABLE_NAME='{tablename}'");
            for (int i = 0; i < noColPrivs.Tables[0].Rows.Count; i++)
            {
                nocol_datagridview.Rows.Add();
                DataRow noColPrivsRow = noColPrivs.Tables[0].Rows[i];
                DataGridViewRow gridViewRow = nocol_datagridview.Rows[i];

                gridViewRow.Cells["PrivilegeNoCol"].Value = noColPrivsRow["PRIVILEGE"].ToString();
                gridViewRow.Cells["Grantable"].Value = (noColPrivsRow["GRANTABLE"].ToString() == "YES");
                gridViewRow.Cells["PrivilegeNoCol"].ReadOnly = true;
                gridViewRow.Cells["Grantable"].ReadOnly = true;
            }
        }

        private void LoadColPrivs(String tablename)
        {
            cols_datagridview.Rows.Clear();

            // Lấy danh sách cột của bảng
            DataSet cols_DataSet = DataProvider.Instance.ExecuteQuery(
                $"select col.COLUMN_NAME from sys.all_tab_columns col where table_name = '{tablename}'");

            if (cols_DataSet != null)
            {
                if (cols_datagridview.Columns["ColName"] != null)
                    cols_datagridview.Columns.Remove("ColName");

                // Thêm cột combox là các cột
                DataGridViewComboBoxColumn colsCombobox = new DataGridViewComboBoxColumn();
                colsCombobox.HeaderText = "Column Name";
                colsCombobox.Name = "ColName";

                //Chuyển dataset thành list<string>
                List<String> columns = new List<string>();
                foreach (DataRow row in cols_DataSet.Tables[0].Rows)
                {
                    columns.Add(row[0].ToString());
                }
                colsCombobox.DataSource = columns;
                cols_datagridview.Columns.Insert(0, colsCombobox);

                // Lấy quyền trên cột của bảng
                DataSet colPrivs_DataSet = DataProvider.Instance.ExecuteQuery(
                    $"select COLUMN_NAME, PRIVILEGE from User_col_privs where table_name = '{tablename}' and grantee = '{userProperties.username}'");

                //Hiển thị các quyền trên cột trên datagrid view 
                if (colPrivs_DataSet != null)
                {
                    for (int j = 0; j < colPrivs_DataSet.Tables[0].Rows.Count; j++)
                    {
                        cols_datagridview.Rows.Add();     //Tạo một dòng mới trong bảng
                        DataGridViewRow gridViewRow = cols_datagridview.Rows[j];
                        DataRow priv_row = colPrivs_DataSet.Tables[0].Rows[j];

                        gridViewRow.Cells["ColName"].Value = priv_row["COLUMN_NAME"];
                        gridViewRow.Cells["PrivilegeCol"].Value = priv_row["PRIVILEGE"];

                    }
                }
            }
        }

        private void SaveTables()
        {
            String failRevokeStr = "";
            String failGrantStr = "";
            for (int i = 0; i < userProperties.object_privs_before.Tables[0].Rows.Count; i++)
            {
                DataRow objectPrivRow = userProperties.object_privs_before.Tables[0].Rows[i];
                string object_name = objectPrivRow["TABLE_NAME"].ToString();
                string object_priv = objectPrivRow["PRIVILEGE"].ToString();
                bool object_grantable = (objectPrivRow["GRANTABLE"].ToString() == "YES");

                int existIdx = -1;
                for (int j = 0; j < table_datagridview.RowCount; j++)
                {
                    
                    DataGridViewRow row = table_datagridview.Rows[j];
                    if (row.IsNewRow)
                        continue;

                    if (object_name == row.Cells["Tables"].Value.ToString()
                    && object_priv == row.Cells["Privileges"].Value.ToString()
                    && object_grantable == Convert.ToBoolean(row.Cells["Grantable"].Value))
                    {
                        existIdx = j;
                        break;
                    }
                }

                if (existIdx != -1)
                {
                    table_datagridview.Rows.RemoveAt(existIdx);
                } else
                {
                    MessageBox.Show($"REVOKE {object_priv} ON {object_name} FROM {userProperties.username}");
                    if (DataProvider.instance.ExecuteScalar($"REVOKE {object_priv} ON {object_name} FROM {userProperties.username}") == null)
                    {
                        failRevokeStr += object_priv + ", ";
                    }
                }
            }
            String grantOptionStr;
            for (int i = 0; i < table_datagridview.Rows.Count; ++i)
            {
                DataGridViewRow row = table_datagridview.Rows[i];
                if (row.IsNewRow)
                    continue;

                grantOptionStr = Convert.ToBoolean(row.Cells["Grantable"].Value) == true ? "WITH GRANT OPTION" : "";
                MessageBox.Show($"GRANT {row.Cells["Privileges"].Value.ToString()} ON {row.Cells["Tables"].Value.ToString()} TO {userProperties.username} {grantOptionStr}");
                if (DataProvider.instance.ExecuteScalar($"GRANT {table_datagridview.Rows[i].Cells["Privileges"].Value.ToString()} ON {table_datagridview.Rows[i].Cells["Tables"].Value.ToString()} TO {userProperties.username} {grantOptionStr}") == null)
                {
                    failGrantStr += table_datagridview.Rows[i].Cells["Privileges"].Value.ToString() + ", ";
                }
            }
            String failStr = "";
            if (failRevokeStr != "")
            {
                failStr += "Không thể revoke:\n" + failRevokeStr;
            }
            if (failGrantStr != "")
            {
                failStr += "Không thể grant:\n" + failGrantStr;
            }
            if (failStr != "")
            {
                MessageBox.Show(failStr);
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

                    // Lấy dòng trong gridview và dataset
                    DataRow sysPrivRow = dataSet.Tables[0].Rows[i];
                    DataGridViewRow gridViewRow = privs_datagridview.Rows[i];
                    bool privGranted = sysPrivRow["grantee"].ToString() != "";
                    bool privAdmin = sysPrivRow["admin_option"].ToString() == "YES";

                    // Đổ data từ vào trong grid view
                    gridViewRow.Cells["SysPrivs"].Value = sysPrivRow["name"].ToString();
                    gridViewRow.Cells["Granted"].Value = privGranted;
                    gridViewRow.Cells["Admin"].Value = privAdmin;

                    //Set up các quyền sys trong mảng before và after
                    userProperties.sys_privs_granted_before.Add(new List<bool>() { privGranted, privAdmin });
                    userProperties.sys_privs_granted_after.Add(new List<bool>() { privGranted, privAdmin });
                    
                    //Set readonly tên các privilege
                    gridViewRow.Cells["SysPrivs"].ReadOnly = true;
                }                                    
            }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            SaveRoles();
            SaveSysPrivs();
            SaveTables();
            SavePassword();
            this.Close();
        }

        private void SaveSysPrivs()
        {
            bool grant_before, admin_before, grant_after, admin_after;
            String priv;

            String failedGrant = "";
            String failedRevoke = "";
            for (int i = 0; i<userProperties.sys_privs_granted_before.Count; i++)
            {
                priv = privs_datagridview.Rows[i].Cells["SysPrivs"].Value.ToString();

                grant_before = userProperties.sys_privs_granted_before[i][0];
                admin_before = userProperties.sys_privs_granted_before[i][1];
                grant_after = userProperties.sys_privs_granted_after[i][0];
                admin_after = userProperties.sys_privs_granted_after[i][1];

                if (!grant_before && !admin_before && grant_after && !admin_after)
                {
                    // Grant
                    object result = DataProvider.Instance.ExecuteScalar($"GRANT {priv} TO {userProperties.username}");
                    if (result == null)
                        failedGrant += priv + ", ";
                }
                if (!admin_before && admin_after)
                {
                    //Grant admin
                    object result = DataProvider.Instance.ExecuteScalar($"GRANT {priv} TO {userProperties.username} WITH ADMIN OPTION");
                    if (result == null)
                        failedGrant += priv + ", ";
                }
                if (grant_before && !grant_after)
                {
                    //Revoke
                    object result = DataProvider.Instance.ExecuteScalar($"REVOKE {priv} FROM {userProperties.username}");
                    if (result == null)
                        failedRevoke += priv + ", ";
                }
                if (grant_before && admin_before && grant_after && !admin_after)
                {
                    //Revoke
                    object result = DataProvider.Instance.ExecuteScalar($"REVOKE {priv} FROM {userProperties.username}");
                    if (result == null)
                        failedRevoke += priv + ", ";
                    else
                    {
                        //Grant
                        result = DataProvider.Instance.ExecuteScalar($"GRANT {priv} TO {userProperties.username}");
                        if (result == null)
                            failedGrant += priv + ", ";
                    }                    
                }
            }

            if (failedGrant != "")
                MessageBox.Show("Không thể grant các quyền " + failedGrant.TrimEnd(' ', ',') + " cho user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (failedRevoke != "")
                MessageBox.Show("Không thể revoke các quyền " + failedGrant.TrimEnd(' ', ',') + " cho user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SavePassword()
        {
            if (password_textbox.Text != "")
            {
                userProperties.password = password_textbox.Text;

                object result = DataProvider.Instance.ExecuteScalar($"ALTER USER {userProperties.username} IDENTIFIED BY {userProperties.password}");
                if (result == null)
                {
                    MessageBox.Show("Không thể thay đổi mật khẩu của user!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

//GB: grant_before
//AB: admin_before
//GA: grant_after
//AA: admin_after
//GB    AB  GA  AA
//F     F   T   F   Grant
//F     F   T   T   Grant admin

//T     F   F   F   Revoke
//T     F   T   T   Grant admin

//T     T   F   F   Revoke
//T     T   T   F   Revoke, grant