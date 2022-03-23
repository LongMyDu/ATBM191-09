﻿using System;
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
        List<TableProperties> colsProperties;
        String tableName;
        OracleConnection con;

        public TableControl(OracleConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        private void getData()
        {
            tableName = table_name_textbox.Text;

            colsProperties = new List<TableProperties>();
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.Cells["ColName"].Value != null)
                { 

                TableProperties item = new TableProperties();
                
                item.name = dr.Cells["ColName"].Value.ToString();
                item.dataType = dr.Cells["DataType"].Value.ToString().ToUpper();

                if (dr.Cells["ColSize"].Value != null)
                    item.colSize = dr.Cells["ColSize"].Value.ToString();
                else
                    item.colSize = null;

                item.PK = Convert.ToBoolean(dr.Cells["PK"].Value);
                item.notNull = Convert.ToBoolean(dr.Cells["NotNull"].Value);
                colsProperties.Add(item);
                
                //MessageBox.Show(item.name + item.dataType + item.colSize + item.notNull + item.PK, "debug");
                }
            }

        }

        private bool CreateTable()
        {
           
            String oracleCmd = $"CREATE TABLE {tableName.ToUpper()} (";
            for (int i = 0; i<colsProperties.Count; i++)
            {
                oracleCmd += ":col" + i.ToString() + "name ";
                oracleCmd += ":col" + i.ToString() + "type ";
                if (colsProperties[i].colSize != null)
                    oracleCmd += "(:col" + i.ToString() + "size) ";

                if (colsProperties[i].notNull)
                    oracleCmd += ":col" + i.ToString() + "notnull";
               
                oracleCmd += " ,";
            }            

            for (int i = 0; i < colsProperties.Count; i++)
            {
                oracleCmd = oracleCmd.Replace(":col" + i.ToString() + "name", colsProperties[i].name);
                oracleCmd = oracleCmd.Replace(":col" + i.ToString() + "type", colsProperties[i].dataType);
                
                if (colsProperties[i].colSize != null)
                {
                    oracleCmd = oracleCmd.Replace(":col" + i.ToString() + "size", colsProperties[i].colSize);
                }
                if (colsProperties[i].notNull)
                {
                    oracleCmd = oracleCmd.Replace(":col" + i.ToString() + "notnull", "NOT NULL");
                }
            }
            oracleCmd += $"CONSTRAINT {tableName}_PK PRIMARY KEY(";
            bool needComma = false;
            for (int i = 0; i < colsProperties.Count; i++)
            {                
                if (colsProperties[i].PK)
                {
                    if (needComma)
                    {
                        oracleCmd += ",";
                    }
                    oracleCmd += colsProperties[i].name;
                    needComma = true;
                }               
            }
            oracleCmd += "))";
            MessageBox.Show(oracleCmd, "debug");
            Clipboard.SetText(oracleCmd);

            OracleCommand getTableMetadataCmd = new OracleCommand(oracleCmd, con);
            try
            {
                object count = getTableMetadataCmd.ExecuteScalar();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

            MessageBox.Show("Tạo bảng thành công", "Thành công", MessageBoxButtons.OK);
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getData();
            CreateTable();
        }
    }
}
