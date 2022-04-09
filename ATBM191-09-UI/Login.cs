﻿using System;
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


        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textUsername.Text;
            string password = textPassword.Text;

            if (username != "QLCSYTE_ADMIN")
            {
                MessageBox.Show("Username is invalid");
            }
            else
            {
                DataProvider.ConString = "Data Source=XEPDB1;User Id=QLCSYTE_ADMIN;Password=" + password + ";";
                try
                {
                    OracleConnection con = new OracleConnection(DataProvider.ConString);
                    { 
                        con.Open();

                        MessageBox.Show("Login is successfully");
                        MainForm mainFr = new MainForm();
                        mainFr.Show();
                        this.Hide();

                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Login is failed");
                }

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
