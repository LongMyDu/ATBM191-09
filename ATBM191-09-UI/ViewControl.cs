using ATBM191_09_UI.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATBM191_09_UI
{
    public partial class ViewControl : Form
    {
        DataSet resDataSet = null;
        public ViewControl()
        {
            InitializeComponent();
            queryRTxt.Text = @"SELECT

FROM
    ";
        }

        private void Display_MainDataGridView(DataSet dataSet, DataGridView gridView)
        {
            if (dataSet != null)
            {
                // Reset data grid view
                gridView.Columns.Clear();
                gridView.DataSource = dataSet.Tables[0].DefaultView;

                // disable sorting in datagridview
                foreach (DataGridViewColumn column in gridView.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private String getVwCreateQuery()
        {
            String vwCreateQuery = queryRTxt.Text.TrimEnd();
            if (vwCreateQuery[vwCreateQuery.Length - 1] == ';') vwCreateQuery = vwCreateQuery.Substring(0, vwCreateQuery.Length - 1);
            return vwCreateQuery;
        }
        private void getDataSet()
        {
            resDataSet = DataProvider.Instance.ExecuteQuery(getVwCreateQuery());
        }
        private void showResBtn_Click(object sender, EventArgs e)
        {
            getDataSet();
            if (resDataSet != null)
                resDataGVw.DataSource = resDataSet.Tables[0].DefaultView;
            else
                MessageBox.Show("Truy vấn không hợp lệ!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void vwCreateBtn_Click(object sender, EventArgs e)
        {
            getDataSet();
            if (resDataSet != null) {
                object count = DataProvider.Instance.ExecuteScalar($"create view {vwNameTxt.Text} as ({getVwCreateQuery()})");
                if (count == null)
                {
                    MessageBox.Show("Tạo view không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                    MessageBox.Show("Tạo view thành công", "Thành công", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Truy vấn không hợp lệ!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cancelVwCreateBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
