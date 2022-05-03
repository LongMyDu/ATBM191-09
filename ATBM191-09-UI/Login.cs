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
                    MessageBox.Show(getUserRole(con), "ROLE");
                    MainForm mainFr = new MainForm();
                    mainFr.Show();
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
    }
}
