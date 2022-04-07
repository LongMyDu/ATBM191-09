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
    public partial class ObjectPrivs : Form
    {
        public class TablePrivs
        {
            public String username;
            public String tablename;
            public List<String> columns = new List<String>();
            //public bool grant_before 


            public List<List<bool>> table_level_before = new List<List<bool>>(4);

            public List<String> privs = new List<String>() { "SELECT", "INSERT", "UPDATE", "DELETE" };
        }

        TablePrivs tablePrivs = new TablePrivs();

        public ObjectPrivs(String username, String tablename)
        {
            InitializeComponent();
            this.Name = tablename;

            tablePrivs.username = username;
            tablePrivs.tablename = tablename;
            LoadTableLevelPrivs();
            LoadColumnLevelPrivs();

            tablelevel_datagridview.CellContentClick += Table_Level_Privs_Granted_Click;
            update_datagridview.CellContentClick += Update_Column_Level_Privs_Granted_Click;
            insert_datagridview.CellContentClick += Insert_Column_Level_Privs_Granted_Click;
        }

        private void Handle_Click_Granted_Grantable(DataGridView gridView, DataGridViewCellEventArgs e)
        {
            // gridView.Col[1]: Granted
            // gridView.Col[2]: Grantable
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == gridView.Columns[1].Index)
                {
                    //Nếu tick bỏ grant thì bỏ luôn admin
                    if ((bool)gridView.Rows[e.RowIndex].Cells[1].Value == true)
                    {
                        gridView.Rows[e.RowIndex].Cells[2].Value = false;
                    }
                }

                if (e.ColumnIndex == gridView.Columns[2].Index)
                {
                    //Nếu tick admin thì tick luôn grant
                    if ((bool)gridView.Rows[e.RowIndex].Cells[2].Value == false)
                    {
                        gridView.Rows[e.RowIndex].Cells[1].Value = true;
                    }
                }
            }
        }


        private void LoadTableLevelPrivs()
        {
            tablelevel_datagridview.Rows.Clear();

            //Set up các quyền từ bảng privs
            for (int i = 0; i < tablePrivs.privs.Count; i++)
            {
                tablelevel_datagridview.Rows.Add();
                tablelevel_datagridview.Rows[i].Cells["PrivilegeName"].Value = tablePrivs.privs[i];

                // Set up tablelevel_datagridview với giá trị ban đầu granted = false, grantable = false cho tất cả quyền
                tablelevel_datagridview.Rows[i].Cells["Granted"].Value = false;
                tablelevel_datagridview.Rows[i].Cells["Grantable"].Value = false;

                // Set up mảng table_level_before với giá trị ban đầu là granted = false, grantable = false cho tất cả quyền
                tablePrivs.table_level_before.Add(new List<bool>() { false, false });
            }

            // Lấy thông tin về object privilege của user
            DataSet noColPrivs = DataProvider.Instance.ExecuteQuery(
            $"select \"PRIVILEGE\", GRANTABLE from dba_tab_privs where GRANTEE ='{tablePrivs.username}' AND TABLE_NAME='{tablePrivs.tablename}'");
            for (int i = 0; i < noColPrivs.Tables[0].Rows.Count; i++)
            {
                DataRow noColPrivsRow = noColPrivs.Tables[0].Rows[i];

                int index = tablePrivs.privs.IndexOf(noColPrivsRow["PRIVILEGE"].ToString());
                DataGridViewRow gridViewRow = tablelevel_datagridview.Rows[index];

                //Set up mảng table_level_before 
                tablePrivs.table_level_before[index][0] = true;
                tablePrivs.table_level_before[index][1] = (noColPrivsRow["GRANTABLE"].ToString() == "YES");

                //Hiển thị trên tablelevel datagridview
                gridViewRow.Cells["Granted"].Value = true ;
                gridViewRow.Cells["Grantable"].Value = (noColPrivsRow["GRANTABLE"].ToString() == "YES");
            }
        }

        private void SaveTableLevelPrivs()
        {
            bool grant_before, grantable_before, grant_after, grantable_after;
            String priv;

            String failedGrant = "";
            String failedRevoke = "";
            for (int i = 0; i < tablePrivs.table_level_before.Count; i++)
            {
                priv = tablePrivs.privs[i];
                grant_before = tablePrivs.table_level_before[i][0];
                grantable_before = tablePrivs.table_level_before[i][1];

                grant_after = (bool)tablelevel_datagridview.Rows[i].Cells["Granted"].Value;
                grantable_after = (bool)tablelevel_datagridview.Rows[i].Cells["Grantable"].Value;

                if (!grant_before && !grantable_before && grant_after && !grantable_after)
                {
                    // Grant
                    object result = DataProvider.Instance.ExecuteScalar
                        ($"GRANT {priv} ON {tablePrivs.tablename} TO {tablePrivs.username}");
                    if (result == null)
                        failedGrant += priv + ", ";
                }
                if (!grantable_before && grantable_after)
                {
                    //Grant admin
                    object result = DataProvider.Instance.ExecuteScalar
                        ($"GRANT {priv} ON {tablePrivs.tablename} TO {tablePrivs.username} WITH GRANT OPTION");
                    if (result == null)
                        failedGrant += priv + ", ";
                }
                if (grant_before && !grant_after)
                {
                    //Revoke
                    object result = DataProvider.Instance.ExecuteScalar
                        ($"REVOKE {priv} ON {tablePrivs.tablename} FROM {tablePrivs.username}");
                    if (result == null)
                        failedRevoke += priv + ", ";
                }
                if (grant_before && grantable_before && grant_after && !grantable_after)
                {
                    //Revoke
                    object result = DataProvider.Instance.ExecuteScalar
                        ($"REVOKE {priv} ON {tablePrivs.tablename} FROM {tablePrivs.username}");
                    if (result == null)
                        failedRevoke += priv + ", ";
                    else
                    {
                        //Grant
                        result = DataProvider.Instance.ExecuteScalar
                            ($"GRANT {priv} ON {tablePrivs.tablename} TO {tablePrivs.username}");
                        if (result == null)
                            failedGrant += priv + ", ";
                    }
                }
            }

            if (failedGrant != "")
                MessageBox.Show("Không thể grant các quyền " + failedGrant.TrimEnd(' ', ',') + " cho user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (failedRevoke != "")
                MessageBox.Show("Không thể revoke các quyền " + failedGrant.TrimEnd(' ', ',') + " cho user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Table_Level_Privs_Granted_Click(object sender, DataGridViewCellEventArgs e)
        {
            Handle_Click_Granted_Grantable(tablelevel_datagridview, e);
        }

        // Các hàm xử lý Column-level Privileges -------------------------------------------------
        private void LoadColumnLevelPrivs()
        {
            LoadColumns();
            LoadColumnLevel("UPDATE", update_datagridview);
            LoadColumnLevel("INSERT", insert_datagridview);
        }

        private void LoadColumns()
        {
            update_datagridview.Rows.Clear();
            insert_datagridview.Rows.Clear();

            // Lấy danh sách cột của bảng
            DataSet cols_DataSet = DataProvider.Instance.ExecuteQuery(
                $"select col.COLUMN_NAME from sys.all_tab_columns col where table_name = '{tablePrivs.tablename}'");

            if (cols_DataSet != null)
            {
                for (int i = 0; i < cols_DataSet.Tables[0].Rows.Count; i++)
                {
                    DataRow row = cols_DataSet.Tables[0].Rows[i];

                    //Chuyển dataset các cột thành list<string> trong tablePrivs
                    tablePrivs.columns.Add(row[0].ToString());
                    
                    //Hiển thị các cột này trong update_gridview và insert_gridview và init giá trị false cho granted và grantable
                    update_datagridview.Rows.Add();     
                    update_datagridview.Rows[i].Cells["Update_PrivilegeName"].Value = row[0].ToString();
                    update_datagridview.Rows[i].Cells["Update_Granted"].Value = false;
                    update_datagridview.Rows[i].Cells["Update_Grantable"].Value = false;

                    insert_datagridview.Rows.Add();
                    insert_datagridview.Rows[i].Cells["Insert_PrivilegeName"].Value = row[0].ToString();
                    insert_datagridview.Rows[i].Cells["Insert_Granted"].Value = false;
                    insert_datagridview.Rows[i].Cells["Insert_Grantable"].Value = false;
                }
            }
        }

        private void LoadColumnLevel(String priv, DataGridView priv_datagridview)
        {
            // Lấy quyền trên cột của bảng
            DataSet colPrivs_DataSet = DataProvider.Instance.ExecuteQuery(
                $"select COLUMN_NAME, PRIVILEGE, GRANTABLE from User_col_privs where table_name = '{tablePrivs.tablename}' and grantee = '{tablePrivs.username}' and PRIVILEGE='{priv}'");

            //Hiển thị các quyền trên cột trên datagrid view 
            if (colPrivs_DataSet != null)
            {
                for (int j = 0; j < colPrivs_DataSet.Tables[0].Rows.Count; j++)
                {
                    DataRow priv_row = colPrivs_DataSet.Tables[0].Rows[j];

                    int index = tablePrivs.columns.IndexOf(priv_row["COLUMN_NAME"].ToString());
                    DataGridViewRow gridViewRow = priv_datagridview.Rows[index];

                    gridViewRow.Cells[0].Value = priv_row["COLUMN_NAME"];
                    gridViewRow.Cells[1].Value = true;
                    gridViewRow.Cells[2].Value = (priv_row["GRANTABLE"].ToString() == "YES");
                }
            }
           
        }

        private void SaveColumnLevelPrivs(String priv, DataGridView priv_datagridview)
        {
            bool grant, grantable;
            String colName, exeString, failedGrant = "";

            // Revoke quyền trên toàn bảng
            object result = DataProvider.Instance.ExecuteScalar
            //($"REVOKE {priv} ON {tablePrivs.tablename} FROM {tablePrivs.username}");

            ($"BEGIN EXECUTE IMMEDIATE 'REVOKE {priv} ON {tablePrivs.tablename} FROM {tablePrivs.username}'; " +
            @" exception when others then if sqlcode != -1927 then raise; end if; end;");


            // Duyệt qua các cột để grant lại quyền
            for (int i = 0; i < tablePrivs.columns.Count; i++)
            {
                colName = tablePrivs.columns[i];

                // gridView.Col[1]: Granted
                // gridView.Col[2]: Grantable
                grant = (bool)priv_datagridview.Rows[i].Cells[1].Value;
                grantable = (bool)priv_datagridview.Rows[i].Cells[2].Value;

                if (!grant)
                    continue;

                exeString = $"GRANT {priv}({colName}) ON {tablePrivs.tablename} TO {tablePrivs.username}";
                if (grantable)
                {
                    //Grant admin
                    exeString += " WITH GRANT OPTION";
                }

                result = DataProvider.Instance.ExecuteScalar(exeString);
                if (result == null)
                    failedGrant += priv + $"({colName}), ";
            }

            if (failedGrant != "")
                MessageBox.Show("Không thể grant các quyền " + failedGrant.TrimEnd(' ', ',') + " cho user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Update_Column_Level_Privs_Granted_Click(object sender, DataGridViewCellEventArgs e)
        {
            Handle_Click_Granted_Grantable(update_datagridview, e);
        }

        private void Insert_Column_Level_Privs_Granted_Click(object sender, DataGridViewCellEventArgs e)
        {
            Handle_Click_Granted_Grantable(insert_datagridview, e);
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            SaveColumnLevelPrivs("UPDATE", update_datagridview);
            SaveColumnLevelPrivs("INSERT", insert_datagridview);
            SaveTableLevelPrivs();
            
            this.Close();
        }

    }
}
