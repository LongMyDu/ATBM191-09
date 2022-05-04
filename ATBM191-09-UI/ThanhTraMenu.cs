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
            main_datagridview.Columns.Clear();
            DataSet dataSet = DataProvider.Instance.ExecuteQuery("Select * from QLCSYTE_ADMIN.VW_THONGTINCANHAN_NHANVIEN");
            main_datagridview.DataSource = dataSet.Tables[0].DefaultView;
        }
    }
}
