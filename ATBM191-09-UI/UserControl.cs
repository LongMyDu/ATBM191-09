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

        UserProperties userProperties;
        public UserControl()
        {
            InitializeComponent();
            userProperties = new UserProperties();
            LoadRoles();
        }

        private void getInput()
        {
            userProperties.username = username_textbox.Text.ToUpper();
            userProperties.password = password_textbox.Text;
        }

        private void LoadRoles()
        {
            DataSet dataSet = DataProvider.Instance.ExecuteQuery(
                $"select \"ROLE\" from dba_roles");

            role_datagridview.Columns.Clear();
            if (dataSet != null)
            {
                role_datagridview.DataSource = dataSet.Tables[0].DefaultView;

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
            getInput();
            CreateUser();
        }
    }
}
