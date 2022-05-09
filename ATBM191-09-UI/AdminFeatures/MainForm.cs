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
        CreateRoleControl createRoleControlForm = null;
        int currentOption = -1; //0: đang trong chức năng User, 1: chức năng Roles, 2: Tables, 3: Views

        public MainForm()
        {
            InitializeComponent();

            main_datagridview.CellClick += User_Details_Click;  //Thêm event handler cho các nút
            main_datagridview.CellClick += Delete_User_Click;  //Thêm event handler cho các nút
            main_datagridview.CellClick += Role_Details_Click;
            main_datagridview.CellClick += Delete_Role_Click;

            User_Button_Click(user_button, new EventArgs());
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

        private void Highlight_Nav_Button(Button button)
        {
            table_button.BackColor = Color.FromArgb(51, 51, 75);
            view_button.BackColor = Color.FromArgb(51, 51, 75);
            user_button.BackColor = Color.FromArgb(51, 51, 75);
            role_button.BackColor = Color.FromArgb(51, 51, 75);

            button.BackColor = Color.FromArgb(61, 61, 90);
        }


        private void User_Button_Click(object sender, EventArgs e)
        {
            Highlight_Nav_Button((Button)sender);
            currentOption = 0;  // Set chức năng hiện tại là Users
            header_label.Text = "Danh sách user của hệ thống";
            LoadUsers();
        }

        private void Table_Button_Click(object sender, EventArgs e)
        {
            Highlight_Nav_Button((Button)sender);
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
                    CreateRole();
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
                        LoadUsers();
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
                from user_tab_columns col
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
            LoadTables(); //Reload lại danh sách tables
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

        private void View_Button_Click(object sender, EventArgs e)
        {
            Highlight_Nav_Button((Button)sender);
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
            Highlight_Nav_Button((Button)sender);
            currentOption = 1;  // Set chức năng hiện tại là Roles
            header_label.Text = "Danh sách role của hệ thống";
            LoadRoles();
        }

        private void LoadRoles()
        {
            DataSet rolesDataSet = DataProvider.Instance.ExecuteQuery(
            @"select role, role_id, password_required from dba_roles");
            if (rolesDataSet != null)
            {
                Display_MainDataGridView(rolesDataSet);

                // Thêm nút xem chi tiết vào cột cuối cùng
                DataGridViewButtonColumn roleDetailButtonColumn = new DataGridViewButtonColumn();
                roleDetailButtonColumn.Name = "roleDetailButton";
                roleDetailButtonColumn.HeaderText = "";
                roleDetailButtonColumn.Text = "Chi tiết";
                roleDetailButtonColumn.UseColumnTextForButtonValue = true;

                if (main_datagridview.Columns["roleDetailButton"] == null)
                {
                    main_datagridview.Columns.Add(roleDetailButtonColumn);
                }

                // Thêm nút xóa role cột cuối cùng
                DataGridViewButtonColumn deleteRoleButtonCol = new DataGridViewButtonColumn();
                deleteRoleButtonCol.Name = "DeleteRole";
                deleteRoleButtonCol.HeaderText = "";
                deleteRoleButtonCol.Text = "Xóa";
                deleteRoleButtonCol.UseColumnTextForButtonValue = true;

                if (main_datagridview.Columns["DeleteRole"] == null)
                {
                    main_datagridview.Columns.Add(deleteRoleButtonCol);
                }
            }
            main_datagridview.Columns["role"].FillWeight = 200;
        }

        private void Delete_Role_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (main_datagridview.Columns["DeleteRole"] != null &&
                e.ColumnIndex == main_datagridview.Columns["DeleteRole"].Index)
            {
                String rolename = main_datagridview.Rows[e.RowIndex].Cells["ROLE"].Value.ToString();
                if (MessageBox.Show("Xác nhận xóa role?", "Xác nhận",
                                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,
                                        MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.OK)
                {
                    String query = $"DROP ROLE {rolename}";
                    Object result = DataProvider.Instance.ExecuteScalar(query);
                    if (result != null)
                    {
                        MessageBox.Show("Xóa role thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRoles();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CreateRole()
        {
            // Mở form TableControl, nếu chưa tồn tại hoặc đã bị tắt thì tạo form mới
            if (createRoleControlForm == null || createRoleControlForm.IsDisposed == true)
            {
                createRoleControlForm = new CreateRoleControl();
            }
            createRoleControlForm.Show();
        }

        

        private void Role_Details_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (main_datagridview.Columns["roleDetailButton"] != null &&
                e.ColumnIndex == main_datagridview.Columns["roleDetailButton"].Index && e.RowIndex >= 0)
            {
                String rolename = main_datagridview.Rows[e.RowIndex].Cells["ROLE"].Value.ToString();
                (new EditRoleControl(rolename)).Show();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
