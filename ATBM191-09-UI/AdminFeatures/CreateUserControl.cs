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
    public partial class CreateUserControl : Form
    {
        public class UserProperties
        {
            public String username;            
            public String password;            
        }

        UserProperties userProperties = new UserProperties();
        public CreateUserControl()
        {
            InitializeComponent();
        }

        private bool getInput()
        {            
            userProperties.username = username_textbox.Text.ToUpper();
            userProperties.password = password_textbox.Text;

            if (userProperties.username == "" || userProperties.password == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lưu ý");
                return false;
            }
            return true;
        }

        
        private bool CreateUser()
        {
            String oracleCmd = $"create user \"{userProperties.username}\" identified by {userProperties.password}";
            object count = DataProvider.Instance.ExecuteScalar(oracleCmd);
            if (count == null)
            {
                MessageBox.Show("Tạo user không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            EditUserControl userPrivsForm = new EditUserControl(userProperties.username);
            userPrivsForm.Show();
            return true;
        }

        private void create_button_Click(object sender, EventArgs e)
        {
            if (getInput())
            {
                CreateUser();
                this.Close();
            }
        }
    }
}
