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
    public partial class CreateRoleControl : Form
    {
        public class RoleProperties
        {
            public String role_name;
            public String password;
        }

        RoleProperties roleProperties = new RoleProperties();
        public CreateRoleControl()
        {
            InitializeComponent();
        }

        private bool getInput()
        {
            roleProperties.role_name = textRoleName.Text.ToUpper();
            roleProperties.password = textPassword.Text;

            if (roleProperties.role_name == "" || roleProperties.password == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lưu ý");
                return false;
            }
            return true;
        }


        private bool CreateRole()
        {
            String oracleCmd = $"create role \"{roleProperties.role_name}\" identified by {roleProperties.password}";
            object count = DataProvider.Instance.ExecuteScalar(oracleCmd);
            if (count == null)
            {
                MessageBox.Show("Tạo role không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            EditRoleControl editRoleForm = new EditRoleControl(roleProperties.role_name);
            editRoleForm.Show();
            return true;
        }

        
        private void CreateRoleControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (getInput())
            {
                CreateRole();
                this.Close();
            }
        }
    }
}
