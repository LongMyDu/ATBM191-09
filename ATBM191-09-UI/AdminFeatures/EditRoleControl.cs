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
    public partial class EditRoleControl : Form
    {
        public class RoleProperties
        {
            public String rolename;
            public String password;
            
            public List<List<bool>> role_granted_before = new List<List<bool>>();
            public List<List<bool>> role_granted_after = new List<List<bool>>();
            public List<List<bool>> sys_privs_granted_before = new List<List<bool>>(); // each tuple first ele is granted, second is admin
            public List<List<bool>> sys_privs_granted_after = new List<List<bool>>(); // each tuple first ele is granted, second is admin            

            public DataSet object_privs_before;
        }

        RoleProperties roleProperties = new RoleProperties();

        public EditRoleControl(String rolename)
        {
            InitializeComponent();
            roleProperties.rolename = rolename;
            rolename_textbox.Text = rolename;
            rolename_textbox.ReadOnly = true;

            LoadRoles();
            LoadTables();
            LoadSysPrivs();
            role_datagridview.CellContentClick += Role_Grant_Click;
            privs_datagridview.CellContentClick += Sys_Privs_Granted_Click;
            table_datagridview.CellContentClick += Details_Button_Click;
        }

        private bool getInput()
        {
            roleProperties.password = password_textbox.Text;

            if (roleProperties.rolename == "" || roleProperties.password == "")
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
                if (e.ColumnIndex == role_datagridview.Columns["Granted"].Index)
                {
                    if (roleProperties.role_granted_after[e.RowIndex][0])
                        role_datagridview.Rows[e.RowIndex].Cells["Admin"].Value = roleProperties.role_granted_after[e.RowIndex][1] = false;
                    roleProperties.role_granted_after[e.RowIndex][0] = !roleProperties.role_granted_after[e.RowIndex][0];
                }
                if (e.ColumnIndex == role_datagridview.Columns["Admin"].Index)
                {
                    if (!roleProperties.role_granted_after[e.RowIndex][1])
                        role_datagridview.Rows[e.RowIndex].Cells["Granted"].Value = roleProperties.role_granted_after[e.RowIndex][0] = true;
                    roleProperties.role_granted_after[e.RowIndex][1] = !roleProperties.role_granted_after[e.RowIndex][1];
                }
                //MessageBox.Show(roleProperties.role_granted_after[e.RowIndex][0].ToString() + " " + roleProperties.role_granted_after[e.RowIndex][1].ToString());
            }
        }

        private void Sys_Privs_Granted_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == privs_datagridview.Columns["Granted"].Index)
                {
                    //Nếu tick bỏ grant thì bỏ luôn admin
                    if (roleProperties.sys_privs_granted_after[e.RowIndex][0] == true)
                    {
                        privs_datagridview.Rows[e.RowIndex].Cells["Admin"].Value =
                            roleProperties.sys_privs_granted_after[e.RowIndex][1] = false;
                    }
                    roleProperties.sys_privs_granted_after[e.RowIndex][0] =
                    !roleProperties.sys_privs_granted_after[e.RowIndex][0];
                }

                if (e.ColumnIndex == privs_datagridview.Columns["Admin"].Index)
                {
                    //Nếu tick admin thì tick luôn grant
                    if (roleProperties.sys_privs_granted_after[e.RowIndex][1] == false)
                    {
                        privs_datagridview.Rows[e.RowIndex].Cells["Granted"].Value =
                            roleProperties.sys_privs_granted_after[e.RowIndex][0] = true;
                    }

                    roleProperties.sys_privs_granted_after[e.RowIndex][1] =
                    !roleProperties.sys_privs_granted_after[e.RowIndex][1];
                }

                //MessageBox.Show(roleProperties.sys_privs_granted_after[e.RowIndex][0].ToString() + roleProperties.sys_privs_granted_after[e.RowIndex][1].ToString());
            }
        }

        private void LoadRoles()
        {

            DataSet dataSet = DataProvider.Instance.ExecuteQuery(
                @"select ar.role, gr.admin_option, gr.grantee
                   from dba_roles ar LEFT JOIN dba_role_privs gr on(ar.role = gr.granted_role and gr.grantee = '" + roleProperties.rolename + "')" +
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
                    roleProperties.role_granted_before.Add(new List<bool>() { granted, admin });
                    roleProperties.role_granted_after.Add(new List<bool>() { granted, admin });
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
            for (int i = 0; i < roleProperties.role_granted_before.Count; ++i)
            {
                grant_before = roleProperties.role_granted_before[i][0];
                admin_before = roleProperties.role_granted_before[i][1];
                grant_after = roleProperties.role_granted_after[i][0];
                admin_after = roleProperties.role_granted_after[i][1];
                role = role_datagridview.Rows[i].Cells["Role"].Value.ToString();
                if (!grant_before && !admin_before && grant_after && !admin_after)
                {
                    // grant
                    if (DataProvider.Instance.ExecuteScalar($"GRANT {role} TO {roleProperties.rolename}") == null)
                    {
                        failedGrant += role + ", ";
                    }
                }
                if (!admin_before && admin_after)
                {
                    // grant admin
                    if (DataProvider.Instance.ExecuteScalar($"GRANT {role} TO {roleProperties.rolename} WITH ADMIN OPTION") == null)
                    {
                        failedGrant += role + ", ";
                    }
                }
                if (grant_before & !grant_after)
                {
                    // revoke
                    if (DataProvider.Instance.ExecuteScalar($"REVOKE {role} FROM {roleProperties.rolename}") == null)
                    {
                        failedRevoke += role + ", ";
                    }
                }
                if (grant_before && admin_before && grant_after && !admin_after)
                {
                    // revoke
                    if (DataProvider.Instance.ExecuteScalar($"REVOKE {role} FROM {roleProperties.rolename}") == null)
                    {
                        failedRevoke += role + ", ";
                    }
                    // grant
                    else if (DataProvider.Instance.ExecuteScalar($"GRANT {role} TO {roleProperties.rolename}") == null)
                    {
                        failedGrant += role + ", ";
                    }
                    // grant
                }
            }
            String failStr = "";
            if (failedGrant != "")
            {
                failStr += "Không thể GRANT các role:\n" + failedGrant;
            }
            if (failedRevoke != "")
            {
                failStr += "Không thể REVOKE các role:\n" + failedRevoke;
            }
            if (failStr != "")
            {
                MessageBox.Show(failStr);
            }
        }

        private void Details_Button_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (table_datagridview.Columns["ViewDetailButton"] != null &&
                e.ColumnIndex == table_datagridview.Columns["ViewDetailButton"].Index && e.RowIndex >= 0
                && !table_datagridview.Rows[e.RowIndex].IsNewRow)
            {
                String table_name = table_datagridview.Rows[e.RowIndex].Cells["Tables"].Value.ToString();
                (new ObjectPrivs(roleProperties.rolename, table_name, true)).Show();
            }
        }

        private void LoadTables()
        {
            //Lấy danh sách tables và views
            DataSet dataSet = DataProvider.Instance.ExecuteQuery(
                "select distinct table_name from user_tab_columns");
            //Chuyển dataset thành list<string>
            List<String> tables = new List<string>();
            if (dataSet != null)
            {
                // Thêm cột combox là các tables và views
                DataGridViewComboBoxColumn tablesCombobox = new DataGridViewComboBoxColumn();
                tablesCombobox.HeaderText = "Tables/Views";
                tablesCombobox.Name = "Tables";
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    tables.Add(row[0].ToString());
        }
                tablesCombobox.DataSource = tables;
                table_datagridview.Columns.Insert(0, tablesCombobox);
            }

            // Lấy danh sách các bảng mà user có quyền
            DataSet userDetailsDataSet = DataProvider.Instance.ExecuteQuery(
                $"select distinct TABLE_NAME from dba_tab_privs where GRANTEE ='{roleProperties.rolename}'"
            + $"UNION select distinct TABLE_NAME from User_col_privs where GRANTEE = '{roleProperties.rolename}'");

            //// Lưu lại trạng thái before của các object privilege
            //roleProperties.object_privs_before = userDetailsDataSet.Copy();

            String tableName;
            int cnt = 0;
            if (userDetailsDataSet != null)
        {
                // Gán những thông tin này vô datagridview 
                for (int i = 0; i < userDetailsDataSet.Tables[0].Rows.Count; i++)
            {
                    tableName = userDetailsDataSet.Tables[0].Rows[i]["TABLE_NAME"].ToString();
                    if (tables.IndexOf(tableName) != -1)
                    {
                        table_datagridview.Rows.Add();          //Tạo một dòng mới trong bảng
                        table_datagridview.Rows[cnt++].Cells["Tables"].Value = tableName;
                    }
                }
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
                        on (sp.name = upr.privilege and upr.grantee = '" + roleProperties.rolename + "')" +
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
                    roleProperties.sys_privs_granted_before.Add(new List<bool>() { privGranted, privAdmin });
                    roleProperties.sys_privs_granted_after.Add(new List<bool>() { privGranted, privAdmin });

                    //Set readonly tên các privilege
                    gridViewRow.Cells["SysPrivs"].ReadOnly = true;
                }
            }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            SaveRoles();
            SaveSysPrivs();
            //SaveTables();
            SavePassword();
            this.Close();
        }

        private void SaveSysPrivs()
        {
            bool grant_before, admin_before, grant_after, admin_after;
            String priv;

            String failedGrant = "";
            String failedRevoke = "";
            for (int i = 0; i < roleProperties.sys_privs_granted_before.Count; i++)
            {
                priv = privs_datagridview.Rows[i].Cells["SysPrivs"].Value.ToString();

                grant_before = roleProperties.sys_privs_granted_before[i][0];
                admin_before = roleProperties.sys_privs_granted_before[i][1];
                grant_after = roleProperties.sys_privs_granted_after[i][0];
                admin_after = roleProperties.sys_privs_granted_after[i][1];

                if (!grant_before && !admin_before && grant_after && !admin_after)
                {
                    // Grant
                    object result = DataProvider.Instance.ExecuteScalar($"GRANT {priv} TO {roleProperties.rolename}");
                    if (result == null)
                        failedGrant += priv + ", ";
                }
                if (!admin_before && admin_after)
                {
                    //Grant admin
                    object result = DataProvider.Instance.ExecuteScalar($"GRANT {priv} TO {roleProperties.rolename} WITH ADMIN OPTION");
                    if (result == null)
                        failedGrant += priv + ", ";
                }
                if (grant_before && !grant_after)
                {
                    //Revoke
                    object result = DataProvider.Instance.ExecuteScalar($"REVOKE {priv} FROM {roleProperties.rolename}");
                    if (result == null)
                        failedRevoke += priv + ", ";
                }
                if (grant_before && admin_before && grant_after && !admin_after)
                {
                    //Revoke
                    object result = DataProvider.Instance.ExecuteScalar($"REVOKE {priv} FROM {roleProperties.rolename}");
                    if (result == null)
                        failedRevoke += priv + ", ";
                    else
                    {
                        //Grant
                        result = DataProvider.Instance.ExecuteScalar($"GRANT {priv} TO {roleProperties.rolename}");
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
                roleProperties.password = password_textbox.Text;

                object result = DataProvider.Instance.ExecuteScalar($"ALTER ROLE {roleProperties.rolename} IDENTIFIED BY {roleProperties.password}");
                if (result == null)
                {
                    MessageBox.Show("Không thể thay đổi mật khẩu của role!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
