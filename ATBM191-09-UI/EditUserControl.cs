using System;
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

            public List<List<bool>> sys_privs_granted_before = new List<List<bool>>(); // each tuple first ele is granted, second is admin
            public List<List<bool>> sys_privs_granted_after = new List<List<bool>>(); // each tuple first ele is granted, second is admin
            
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

            privs_datagridview.CellContentClick += Sys_Privs_Granted_Click;
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
                $"select \"ROLE\" from dba_roles");

            role_datagridview.Columns.Clear();
            if (dataSet != null)
            {
                role_datagridview.DataSource = dataSet.Tables[0].DefaultView;
                // Thêm granted checkbox
                addCheckboxColumn(role_datagridview, "Granted");
                addCheckboxColumn(role_datagridview, "Admin");
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

            MessageBox.Show("Grant quyền thành công");
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            SaveSysPrivs();
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