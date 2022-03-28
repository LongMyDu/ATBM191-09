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
        ViewControl viewControlForm = null;
        CreateUserControl createUserControlForm = null;
        int currentOption = -1; //0: đang trong chức năng User, 1: chức năng Roles, 2: Tables, 3: Views

        public MainForm()
        {
            InitializeComponent();           
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
            currentOption = 2;  // Set chức năng hiện tại là Tables
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
                    CreateTable();
                    break;
                case 3:
                    CreateView();
                    break;
                default:
                    break;
            }
        }
  
        private void User_Details_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (main_datagridview.Columns["viewDetailButton"] != null && 
                e.ColumnIndex == main_datagridview.Columns["viewDetailButton"].Index && e.RowIndex >= 0)
            {
                String username = main_datagridview.Rows[e.RowIndex].Cells["USERNAME"].Value.ToString();
                (new EditUserControl(username)).Show();
                //LoadUserDetails(username);
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
                viewDetailButtonColumn.HeaderText = "";
                viewDetailButtonColumn.Text = "Chi tiết";
                viewDetailButtonColumn.UseColumnTextForButtonValue = true;
                main_datagridview.CellClick += User_Details_Click;  //Thêm event handler cho các nút
              
                if (main_datagridview.Columns["viewDetailButton"] == null)
                {
                    main_datagridview.Columns.Add(viewDetailButtonColumn);
                }

                // Thêm nút xóa user cột cuối cùng
                DataGridViewButtonColumn deleteUserButtonCol = new DataGridViewButtonColumn();
                deleteUserButtonCol.Name = "Delete";
                deleteUserButtonCol.HeaderText = "";
                deleteUserButtonCol.Text = "Xóa";
                deleteUserButtonCol.UseColumnTextForButtonValue = true;
                main_datagridview.CellClick += Delete_User_Click;  //Thêm event handler cho các nút

                if (main_datagridview.Columns["Delete"] == null)
                {
                    main_datagridview.Columns.Add(deleteUserButtonCol);
                }
            }
        }

        private void Delete_User_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (main_datagridview.Columns["Delete"] != null &&
                e.ColumnIndex == main_datagridview.Columns["Delete"].Index)
            {
                String username = main_datagridview.Rows[e.RowIndex].Cells["USERNAME"].Value.ToString();
                if (MessageBox.Show("Xác nhận xóa user?", "Xác nhận",
                                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,
                                        MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.OK)
                {
                    String query = $"DROP USER {username} CASCADE";
                    Object result = DataProvider.Instance.ExecuteScalar(query);
                    if (result != null)
                    {
                        MessageBox.Show("Xóa user thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                @"select decode( col.table_name
                , lag(col.table_name, 1) over(order by col.table_name)
                , null
                , col.table_name ) view_name,
                col.column_name, 
                col.data_type, 
                col.data_length, 
                col.data_precision, 
                col.data_scale, 
                col.nullable
                from sys.all_tab_columns col
                inner join sys.all_tables sat on col.owner = (select user from dual)
                and col.table_name = sat.table_name
                order by col.table_name");
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
            if (createUserControlForm == null || createUserControlForm.IsDisposed == true)
            {
                createUserControlForm = new CreateUserControl();
            }
            createUserControlForm.Show();
        }

        private void view_button_Click(object sender, EventArgs e)
        {
            currentOption = 3;  // Set chức năng hiện tại là Views
            header_label.Text = "Danh sách view của hệ thống";
            LoadViews();
        }
        private void LoadViews()
        {
            DataSet viewsDataSet = DataProvider.Instance.ExecuteQuery(
                @"select decode( col.table_name
                , lag(col.table_name, 1) over(order by col.table_name)
                , null
                , col.table_name ) view_name,
                col.column_name, 
                col.data_type, 
                col.data_length, 
                col.data_precision, 
                col.data_scale, 
                col.nullable
                from sys.all_tab_columns col
                inner join sys.all_views v on col.owner = (select user from dual)
                and col.table_name = v.view_name
                order by col.table_name");
            Display_MainDataGridView(viewsDataSet);
        }

        private void CreateView()
        {
            // Mở form TableControl, nếu chưa tồn tại hoặc đã bị tắt thì tạo form mới
            if (viewControlForm == null || viewControlForm.IsDisposed == true)
            {
                viewControlForm = new ViewControl();
            }
            viewControlForm.Show();
        }

        private void role_button_Click(object sender, EventArgs e)
        {
            currentOption = 1;  // Set chức năng hiện tại là Roles
            header_label.Text = "Danh sách role của hệ thống";
            LoadRoles();
        }

        private void LoadRoles()
        {
            DataSet rolesDataSet = DataProvider.Instance.ExecuteQuery(
            @"select 
            role,
            privilege,
            admin_option,
            common,
            inherited
            from role_sys_privs order by role");
            Display_MainDataGridView(rolesDataSet);
        }
    }
}
