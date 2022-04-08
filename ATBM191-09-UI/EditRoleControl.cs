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
            
            //----------
        }

        RoleProperties roleProperties = new RoleProperties();

        public EditRoleControl()
        {
            InitializeComponent();
        }

        public EditRoleControl(String username)
        {
            InitializeComponent();
            roleProperties.rolename = username;
            textRoleName.Text = username;
            textRoleName.ReadOnly = true;
        }

        private bool getInput()
        {
            roleProperties.password = textPassword.Text;

            if (roleProperties.rolename == "" || roleProperties.password == "")
            {
                return false;
            }
            return true;
        }

        private void EditRoleControl_Load(object sender, EventArgs e)
        {

        }

        private void SavePassword()
        {
            if (textPassword.Text != "")
            {
                roleProperties.password = textPassword.Text;

                object result = DataProvider.Instance.ExecuteScalar($"ALTER USER {roleProperties.rolename} IDENTIFIED BY {roleProperties.password}");
                if (result == null)
                {
                    MessageBox.Show("Không thể thay đổi mật khẩu của user!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SavePassword();
            this.Close();
        }
    }
}
