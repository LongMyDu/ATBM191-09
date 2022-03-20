using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace ATBM191_09_UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                string ConString = "Data Source=XEPDB1;User Id=QLHOCPHAN_ADMIN;Password=qlhocphanadmin;";
                using (OracleConnection con = new OracleConnection(ConString))
                {
                    OracleCommand cmd = new OracleCommand("SELECT * FROM QLHOCPHAN_ADMIN.VW_GVU_SINHVIEN", con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    oda.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        dataGridView1.DataSource = ds.Tables[0].DefaultView;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
