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
    public partial class BenhNhanMenu : Form
    {
        public BenhNhanMenu()
        {
            InitializeComponent();
        }


        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void PersonalInfo_Button_Click(object sender, EventArgs e)
        {
            DataSet dataSet = DataProvider.Instance.ExecuteQuery("Select * from QLCSYTE_ADMIN.VW_THONGTINCANHAN_BENHNHAN");
            ThongTinCaNhan_BN TTCN = new ThongTinCaNhan_BN(dataSet);
            TTCN.Show();
        }

        private void header_label_Click(object sender, EventArgs e)
        {

        }
    }
}
