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
    public partial class ThanhTraMenu : Form
    {
        public ThanhTraMenu()
        {
            InitializeComponent();
        }

        private void PersonalInfo_Button_Click(object sender, EventArgs e)
        {
            // Reset data grid view
            //main_datagridview.Columns.Clear();
            DataSet dataSet = DataProvider.Instance.ExecuteQuery("Select * from QLCSYTE_ADMIN.VW_THONGTINCANHAN_NHANVIEN");
            //main_datagridview.DataSource = dataSet.Tables[0].DefaultView;
            ThongTinCaNhan_NV TTCN = new ThongTinCaNhan_NV(dataSet);
            TTCN.Show();
        }

       
        private void BN_button_Click(object sender, EventArgs e)
        {
            // Reset data grid view
            main_datagridview.Columns.Clear();
            DataSet dataSet = DataProvider.Instance.ExecuteQuery("Select * from QLCSYTE_ADMIN.BENHNHAN");
            main_datagridview.DataSource = dataSet.Tables[0].DefaultView;
        }

        private void NV_button_Click(object sender, EventArgs e)
        {
            // Reset data grid view
            main_datagridview.Columns.Clear();
            DataSet dataSet = DataProvider.Instance.ExecuteQuery("Select * from QLCSYTE_ADMIN.NHANVIEN");
            main_datagridview.DataSource = dataSet.Tables[0].DefaultView;
        }

        private void CSYT_button_Click(object sender, EventArgs e)
        {
            // Reset data grid view
            main_datagridview.Columns.Clear();
            DataSet dataSet = DataProvider.Instance.ExecuteQuery("Select * from QLCSYTE_ADMIN.CSYT");
            main_datagridview.DataSource = dataSet.Tables[0].DefaultView;
        }

        private void HSBA_Button_Click_1(object sender, EventArgs e)
        {
            // Reset data grid view
            main_datagridview.Columns.Clear();
            DataSet dataSet = DataProvider.Instance.ExecuteQuery("Select * from QLCSYTE_ADMIN.HSBA");
            main_datagridview.DataSource = dataSet.Tables[0].DefaultView;
        }

        private void HSBA_DV_Button_Click(object sender, EventArgs e)
        {
            // Reset data grid view
            main_datagridview.Columns.Clear();
            DataSet dataSet = DataProvider.Instance.ExecuteQuery("Select * from QLCSYTE_ADMIN.HSBA_DV");
            main_datagridview.DataSource = dataSet.Tables[0].DefaultView;
        }
    }
}
