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
            public List<String> grantedRoles = new List<string>();
            public List<String> adminRoles = new List<string>();

        }

        UserProperties userProperties;
        public UserControl()
        {
            InitializeComponent();
            LoadRoles();
        }

        private bool getInput()
        {
            userProperties = new UserProperties();

            userProperties.username = username_textbox.Text.ToUpper();
            userProperties.password = password_textbox.Text;

            if (userProperties.username == "" || userProperties.password == "")
            {
                return false;
            }

            foreach (DataGridViewRow row in role_datagridview.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Granted"].Value) == true)
                {
                    MessageBox.Show(row.Cells["ROLE"].Value.ToString());
                    userProperties.grantedRoles.Add(row.Cells["ROLE"].Value.ToString());
                }
                if (Convert.ToBoolean(row.Cells["Admin"].Value) == true)
                {
                    userProperties.adminRoles.Add(row.Cells["ROLE"].Value.ToString());
                }
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
        

        private bool CreateUser()
        {
            String oracleCmd = $"create user {userProperties.username} identified by {userProperties.password}";
            object count = DataProvider.Instance.ExecuteScalar(oracleCmd);
            if (count == null)
            {
                MessageBox.Show("Tạo user không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
