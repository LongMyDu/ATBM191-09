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
    

    public partial class TableControl : Form
    {
        public class TableProperties
        {
            public String name;
            public Boolean PK;
            public Boolean notNull;
            public String dataType;
            public String colSize;
        }

        public TableControl()
        {
            InitializeComponent();
        }

        private void getData()
        {
            List<TableProperties> items = new List<TableProperties>();
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.Cells["ColName"].Value != null)
                { 

                TableProperties item = new TableProperties();
                
                item.name = dr.Cells["ColName"].Value.ToString();
                item.dataType = dr.Cells["DataType"].Value.ToString();
                item.colSize = dr.Cells["ColSize"].Value.ToString();
                item.PK = Convert.ToBoolean(dr.Cells["PK"].Value);
                item.notNull = Convert.ToBoolean(dr.Cells["NotNull"].Value);
                items.Add(item);

                Console.WriteLine(item.name, item.dataType);
                   MessageBox.Show(item.name + item.dataType + item.colSize + item.notNull + item.PK, "debug");
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getData();
        }
    }
}
