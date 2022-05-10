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
    public partial class NghienCuuMenu : Form
    {
        public NghienCuuMenu()
        {
            InitializeComponent();
        }

        private void HSBA_Button_Click(object sender, EventArgs e)
        {
            // Reset data grid view
            main_datagridview.Columns.Clear();
            DataSet dataSet = DataProvider.Instance.ExecuteQuery("Select * from QLCSYTE_ADMIN.HSBA");
            main_datagridview.DataSource = dataSet.Tables[0].DefaultView;
        }

        private void HSBADV_Button_Click(object sender, EventArgs e)
        {
            // Reset data grid view
            main_datagridview.Columns.Clear();
            DataSet dataSet = DataProvider.Instance.ExecuteQuery("Select * from QLCSYTE_ADMIN.HSBA_DV");
            main_datagridview.DataSource = dataSet.Tables[0].DefaultView;
        }
    }
}
