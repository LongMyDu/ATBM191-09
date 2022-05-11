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
using Oracle.DataAccess.Client;

namespace ATBM191_09_UI
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textUsername.Text;
            string password = textPassword.Text;
            
            DataProvider.ConString = $"Data Source=XEPDB1;User Id={username};Password={password};";
            try
            {
                OracleConnection con = new OracleConnection(DataProvider.ConString);
                {
                    con.Open();
                    String user_role = getUserRole(con);
                    if (user_role == "DBA")
                    {
                        MainForm mainFr = new MainForm();
                        mainFr.Show();
                    } else if (user_role == "Thanh tra")
                    {
                        ThanhTraMenu menu = new ThanhTraMenu();
                        menu.Show();
                    }
                    else if (user_role == "Y sĩ/ bác sĩ")
                    {
                        YBacSiMenu menu = new YBacSiMenu();
                        menu.Show();
                    }
                    else if (user_role == "Bệnh nhân")
                    {
                        BenhNhanMenu menu = new BenhNhanMenu();
                        menu.Show();
                    }
                    else if (user_role == "Nghiên cứu")
                    {
                        NghienCuuMenu menu = new NghienCuuMenu();
                        menu.Show();
                    }
                    else if (user_role == "Cơ sở y tế")
                    {
                        CSYTEMenu menu = new CSYTEMenu();
                        menu.Show();
                    }

                    else
                    {
                        MessageBox.Show("Người dùng không hợp lệ");
                        con.Close();
                        return;
                    }
                    
                    con.Close();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Login is failed");
            }
        }

        private String getUserRole(OracleConnection con)
        {
            OracleCommand command;
            command = new OracleCommand("select sys_context('USER_ROLE_CONTEXT', 'USER_ROLE') from dual", con);
            Object data = command.ExecuteScalar();            
            return data.ToString();
        }

        private void textUsername_KeyDown(object sender, KeyEventArgs e)
        {
            textLogin_KeyDown(sender, e);
        }

        private void textPassword_KeyDown(object sender, KeyEventArgs e)
        {
            textLogin_KeyDown(sender, e);
        }
        
        private void textLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
