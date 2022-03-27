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
    public partial class UserControl : Form
    {
        public class UserProperties
        {
            public String username;            
            public String password;            
        }

        UserProperties userProperties = new UserProperties();
        public UserControl(String username = "")
        {
            InitializeComponent();
            userProperties.username = username;
            LoadRoles();
            LoadTables();
        }

        private bool getInput()
        {            
            userProperties.username = username_textbox.Text.ToUpper();
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

            int columnIndex = gridView.ColumnCount;
            if (gridView.Columns[columnName] == null)
            {
                gridView.Columns.Insert(columnIndex, checkboxColumn);
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
            table_datagridview.Columns.Clear();
            
            //Lấy danh sách tables và views
            DataSet dataSet = DataProvider.Instance.ExecuteQuery(
                "select distinct table_name from user_tab_columns");            
            if (dataSet != null)
            {
                // Thêm cột combox là các tables và views
                DataGridViewComboBoxColumn tablesCombobox = new DataGridViewComboBoxColumn();
                tablesCombobox.HeaderText = "Tables/Views";
                tablesCombobox.Name = "tables";

                //Chuyển dataset thành list<string>
                List<String> tables = new List<string>();
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    tables.Add(row[0].ToString());
                }
                tablesCombobox.DataSource = tables;
                table_datagridview.Columns.Add(tablesCombobox);
            }

            DataGridViewComboBoxColumn privilegesCombobox = new DataGridViewComboBoxColumn();
            List<String> privileges = new List<String>() { "Select", "Insert", "Update", "Delete" };
            privilegesCombobox.DataSource = privileges;
            privilegesCombobox.Name = "privileges";
            privilegesCombobox.HeaderText = "Privileges";
            table_datagridview.Columns.Add(privilegesCombobox);

            addCheckboxColumn(table_datagridview, "Grantable");
        }

        private bool CreateUser()
        {
            String oracleCmd = $"create user {userProperties.username} identified by {userProperties.password}";
            object count = DataProvider.Instance.ExecuteScalar(oracleCmd);
            if (count == null)
            {
                MessageBox.Show("Tạo user không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Grant roles cho user
            foreach (DataGridViewRow row in role_datagridview.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Granted"].Value) == false 
                    && Convert.ToBoolean(row.Cells["Admin"].Value) == false)
                {
                    continue;
                }
                String role = row.Cells["ROLE"].Value.ToString();
                oracleCmd = $"Grant {role} to {userProperties.username}";
                if (Convert.ToBoolean(row.Cells["Admin"].Value) == true)
                {
                    oracleCmd += " WITH ADMIN OPTION";
                }
                MessageBox.Show(oracleCmd);
                count = DataProvider.Instance.ExecuteScalar(oracleCmd);
                if (count == null)
                {
                    MessageBox.Show($"Không thể grant {role} cho user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //Grant quyền trên tables, views cho user
            foreach (DataGridViewRow row in table_datagridview.Rows)
            {
                if (row.IsNewRow)
                    continue;
                String privilege = row.Cells["privileges"].Value.ToString();
                String table_name = row.Cells["tables"].Value.ToString();
                oracleCmd = $"Grant {privilege} on {table_name} to {userProperties.username}";
                if (Convert.ToBoolean(row.Cells["Grantable"].Value) == true)
                {
                    oracleCmd += " WITH GRANT OPTION";
                }
                MessageBox.Show(oracleCmd);
                count = DataProvider.Instance.ExecuteScalar(oracleCmd);
                if (count == null)
                {
                    MessageBox.Show($"Không thể grant {privilege} trên {table_name} cho user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show("Tạo user thành công", "Thành công", MessageBoxButtons.OK);
            return true;
        }

        private void create_button_Click(object sender, EventArgs e)
        {
            if (getInput())
                CreateUser();
        }
    }
}
