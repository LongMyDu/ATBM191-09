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
        }

        UserProperties userProperties = new UserProperties();

        private void Display_DataGridView(DataSet dataSet, DataGridView gridView)
        {
            if (dataSet != null)
            {
                // Reset data grid view
                gridView.Columns.Clear();
                gridView.DataSource = dataSet.Tables[0].DefaultView;                
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public EditUserControl(String username)
        {
            InitializeComponent();
            userProperties.username = username;
            username_textbox.Text = username;        
            username_textbox.ReadOnly = true;

            LoadRoles();
            LoadTables();
            LoadSysPrivs();
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

                // Đổ data từ  userDetailsDataSet vào trong table grid view
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

            //Display_DataGridView(userDetailsDataSet, table_datagridview);
        }

        private void LoadSysPrivs()
        {
            privs_datagridview.Columns.Clear();

            //Lấy danh sách system privileges
            DataSet dataSet = DataProvider.Instance.ExecuteQuery(
                "select name from system_privilege_map order by name");
            if (dataSet != null)
            {
                privs_datagridview.DataSource = dataSet.Tables[0].DefaultView;
                // Thêm granted checkbox
                addCheckboxColumn(privs_datagridview, "Granted");
                addCheckboxColumn(privs_datagridview, "Admin");
            }
        }

       
    }
}
