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
    public partial class MainForm : Form
    {        
        TableControl tableControlForm = null;
        UserControl userControlForm = null;
        int currentOption = -1; //0: đang trong chức năng User, 1: chức năng Roles, 2: Views, 3: Tables

        public MainForm()
        {
            InitializeComponent();
            //if (!ConnectOracle())
            //{
            //    MessageBox.Show("Không thể kết nối tới Oracle DB.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Close();
            //}
        }

        private void Display_MainDataGridView(DataSet dataSet)
        {
            if (dataSet != null)
            {
                // Reset data grid view
                main_datagridview.Columns.Clear();
                main_datagridview.DataSource = dataSet.Tables[0].DefaultView;

                // disable sorting in datagridview
                foreach (DataGridViewColumn column in main_datagridview.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void User_Button_Click(object sender, EventArgs e)
        {
            currentOption = 0;  // Set chức năng hiện tại là Users
            header_label.Text = "Danh sách user của hệ thống";
            LoadUsers();
        }

        private void Table_Button_Click(object sender, EventArgs e)
        {            
            currentOption = 3;  // Set chức năng hiện tại là Tables
            header_label.Text = "Danh sách table của hệ thống";
            LoadTables();
        }
        
        private void New_button_Click(object sender, EventArgs e)
        {
            switch (currentOption)
            { 
                case 0:
                    CreateUser();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    CreateTable();
                    break;
                default:
                    break;
            }
        }
  
        private void User_Details_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (main_datagridview.Columns["viewDetailButton"] != null && 
                e.ColumnIndex == main_datagridview.Columns["viewDetailButton"].Index)
            {
                String username = main_datagridview.Rows[e.RowIndex].Cells["USERNAME"].Value.ToString();
                LoadUserDetails(username);
            }
        }

        private void LoadUsers()
        {         
            DataSet userDataSource = DataProvider.Instance.ExecuteQuery("select USER_ID, USERNAME, CREATED from all_users");
            if (userDataSource != null)
            {
                Display_MainDataGridView(userDataSource);

                // Thêm nút xem chi tiết vào cột cuối cùng
                DataGridViewButtonColumn viewDetailButtonColumn = new DataGridViewButtonColumn();
                viewDetailButtonColumn.Name = "viewDetailButton";
                viewDetailButtonColumn.Text = "Chi tiết";
                viewDetailButtonColumn.UseColumnTextForButtonValue = true;
                main_datagridview.CellClick += User_Details_Click;  //Thêm event handler cho các nút

                int columnIndex = main_datagridview.ColumnCount;
                if (main_datagridview.Columns["viewDetailButton"] == null)
                {
                    main_datagridview.Columns.Insert(columnIndex, viewDetailButtonColumn);
                }
            }
        }

        private void LoadUserDetails(String username)
        {
            DataSet userDetailsDataSet = DataProvider.Instance.ExecuteQuery(
                $"select GRANTEE AS \"USER\", TABLE_NAME, \"PRIVILEGE\", GRANTABLE, GRANTOR from dba_tab_privs where GRANTEE ='{username}'");                
            Display_MainDataGridView(userDetailsDataSet);                                
        }

        private void LoadTables()
        {
            DataSet tablesDataSet = DataProvider.Instance.ExecuteQuery(
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
                            uc.constraint_name = cc.constraint_name)");
            Display_MainDataGridView(tablesDataSet);                
        }

        private void CreateTable()
        {
            // Mở form TableControl, nếu chưa tồn tại hoặc đã bị tắt thì tạo form mới
            if (tableControlForm == null || tableControlForm.IsDisposed == true)
            {
                tableControlForm = new TableControl();
            }
            tableControlForm.Show();
        }

        private void CreateUser()
        {
            // Mở form UserControl, nếu chưa tồn tại hoặc đã bị tắt thì tạo form mới
            if (userControlForm == null || userControlForm.IsDisposed == true)
            {
                userControlForm = new UserControl();
            }
            userControlForm.Show();
        }
    }
}
