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
    public partial class YBacSiMenu : Form
    {
        public YBacSiMenu()
        {
            InitializeComponent();
        }

        private void PersonalInfo_Button_Click(object sender, EventArgs e)
        {
            // Reset data grid view
            main_datagridview.Columns.Clear();
            DataSet dataSet = DataProvider.Instance.ExecuteQuery("Select * from QLCSYTE_ADMIN.VW_THONGTINCANHAN_NHANVIEN");
            main_datagridview.DataSource = dataSet.Tables[0].DefaultView;
        }

        private void HSBA_Button_Click(object sender, EventArgs e)
        {
            MaBN_Textbox.Enabled = false;
            CMNDBN_TextBox.Enabled = false;

            main_datagridview.Columns.Clear();
            DataSet dataSet = DataProvider.Instance.ExecuteQuery("select * from QLCSYTE_ADMIN.HSBA");
            main_datagridview.DataSource = dataSet.Tables[0].DefaultView;
        }

        private void HSBADV_Button_Click(object sender, EventArgs e)
        {
            MaBN_Textbox.Enabled = false;
            CMNDBN_TextBox.Enabled = false;

            main_datagridview.Columns.Clear();
            DataSet dataSet = DataProvider.Instance.ExecuteQuery("select * from QLCSYTE_ADMIN.HSBA_DV");
            main_datagridview.DataSource = dataSet.Tables[0].DefaultView;
        }

        private void BenhNhan_Button_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MaBN_Textbox.Enabled = true;
            CMNDBN_TextBox.Enabled = true;

            String query = "select * from QLCSYTE_ADMIN.BENHNHAN ";
            OracleCommand command;
            if (!String.IsNullOrEmpty(MaBN_Textbox.Text))
            {
                query += "where MABN = :mabn";
                command = new OracleCommand(query);
                command.Parameters.Add(new OracleParameter("mabn", MaBN_Textbox.Text));
            }
            else if (!String.IsNullOrEmpty(CMNDBN_TextBox.Text))
            {
                query += "where CMND = :cmnd";
                command = new OracleCommand(query);
                command.Parameters.Add(new OracleParameter("cmnd", CMNDBN_TextBox.Text));
            }
            else
            {
                command = new OracleCommand(query);
            }

            main_datagridview.Columns.Clear();
            DataSet dataSet = DataProvider.Instance.ExecuteQuery(command);
            main_datagridview.DataSource = dataSet.Tables[0].DefaultView;
        }

        private void MaBN_Textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
