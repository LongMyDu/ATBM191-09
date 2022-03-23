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
    public partial class MainForm : Form
    {
        string ConString = "Data Source=XEPDB1;User Id=QLCSYTE_ADMIN;Password=qlcsyteadmin;";
        OracleConnection con;
        TableControl tableControlForm = null;

        public MainForm()
        {
            InitializeComponent();
            if (!ConnectOracle())
            {
                return;
            }
        }

        private bool ConnectOracle()
        {
            try
            {
                con = new OracleConnection(ConString);
                con.Open();
                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        private void LoadTables()
        {
            try {
                OracleCommand getTableMetadataCmd;
                getTableMetadataCmd = new OracleCommand(
                    @"select 
                    decode( t.table_name
                          , lag(t.table_name, 1) over(order by t.table_name)
                          , null
                          , t.table_name ) as table_name 
                    , t.column_name
                    , t.data_type
                    , cc.constraint_name
                    , uc.constraint_type
                    from user_tab_columns t
                        left join user_cons_columns cc
                            on(cc.table_name = t.table_name and
                                cc.column_name = t.column_name)
                        left join user_constraints uc
                            on(t.table_name = uc.table_name and
                                uc.constraint_name = cc.constraint_name)", con);
                
                OracleDataAdapter oda = new OracleDataAdapter(getTableMetadataCmd);
                DataSet ds = new DataSet();
                oda.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    main_datagridview.DataSource = ds.Tables[0].DefaultView;
                    // disable sorting in datagridview
                    foreach (DataGridViewColumn column in main_datagridview.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void table_button_Click(object sender, EventArgs e)
        {
            header_label.Text = "Danh sách table của hệ thống";
            LoadTables();
        }

        private void new_button_Click(object sender, EventArgs e)
        {
            // Mở form TableControl, nếu chưa tồn tại hoặc đã bị tắt thì tạo form mới
            if (tableControlForm == null || tableControlForm.IsDisposed == true)
            {
                tableControlForm = new TableControl(con);
            }
            tableControlForm.Show();
        }

        private void header_panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
