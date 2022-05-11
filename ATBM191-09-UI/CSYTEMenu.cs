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
    public partial class CSYTEMenu : Form
    {
        public bool HSBA = true;
        public string MaCSYT;
        public CSYTEMenu()
        {
            InitializeComponent();
            Them_Button.Visible = false;

            DataSet TTCN = DataProvider.Instance.ExecuteQuery("Select * from QLCSYTE_ADMIN.VW_THONGTINCANHAN_NHANVIEN");
            MaCSYT = TTCN.Tables[0].Rows[0]["CSYT"].ToString();

            main_datagridview.CellClick += Xoa_Sua_HSBA;
        }

        public void Xoa_Sua_HSBA(Object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (HSBA == true)
                {
                    DataSet dataSet = DataProvider.Instance.ExecuteQuery("Select * from QLCSYTE_ADMIN.VW_HSBA_QLCSYT");
                    Control_HSBA hsba = new Control_HSBA(dataSet);
                    hsba.Show();
                }
                else
                {
                    DataSet dataSet = DataProvider.Instance.ExecuteQuery("Select * from QLCSYTE_ADMIN.VW_HSBA_DV_QLCSYT");
                    Control_HSBA_DV dv = new Control_HSBA_DV(dataSet);
                    dv.Show();
                }
                HSBA = true;
            }
        }
            private void HSBA_Button_Click(object sender, EventArgs e)
        {
            Them_Button.Visible = true;
            HSBA = true;
            main_datagridview.Columns.Clear();
            DataSet dataSet = DataProvider.Instance.ExecuteQuery("select * from QLCSYTE_ADMIN.VW_HSBA_QLCSYT");
            main_datagridview.DataSource = dataSet.Tables[0].DefaultView;
        }

        private void PersonalInfo_Button_Click(object sender, EventArgs e)
        {
            Them_Button.Visible = false;
            DataSet dataSet = DataProvider.Instance.ExecuteQuery("Select * from QLCSYTE_ADMIN.VW_THONGTINCANHAN_NHANVIEN");
            ThongTinCaNhan_NV TTCN = new ThongTinCaNhan_NV(dataSet);
            TTCN.Show();
        }

        private void Them_Button_Click(object sender, EventArgs e)
        {
            if(HSBA == true)
            {
                Control_HSBA hsba = new Control_HSBA(MaCSYT);
                hsba.Show();
            }    
            else
            {
                Control_HSBA_DV dv = new Control_HSBA_DV(MaCSYT);
                dv.Show();
            }

            HSBA = false;
        }

        private void HSBADV_Button_Click(object sender, EventArgs e)
        {
            HSBA = false;

            Them_Button.Visible = true;

            main_datagridview.Columns.Clear();
            DataSet dataSet = DataProvider.Instance.ExecuteQuery("select * from QLCSYTE_ADMIN.VW_HSBA_DV_QLCSYT");
            main_datagridview.DataSource = dataSet.Tables[0].DefaultView;
        }
    }
}
