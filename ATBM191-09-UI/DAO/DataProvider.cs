using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using System.Windows.Forms; //for debug purpose

namespace ATBM191_09_UI.DAO
{
    class DataProvider
    {
       public static string ConString = "Data Source=XEPDB1;User Id=username;Password=******;";


        public static DataProvider instance = null;

        public static DataProvider Instance
        {
            get {
                if (instance == null) instance = new DataProvider();
                return instance;
            }
            private set { DataProvider.instance = value;  }
        }

        private DataProvider() { }

        public DataSet ExecuteQuery(string query)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(ConString))
                {
                    con.Open();
                    OracleCommand getTableMetadataCmd;
                    getTableMetadataCmd = new OracleCommand(query, con);
                    con.Close();

                    OracleDataAdapter oda = new OracleDataAdapter(getTableMetadataCmd);
                    DataSet ds = new DataSet();
                    oda.Fill(ds);

                    if (ds.Tables.Count > 0)
                    {
                        return ds;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public DataSet ExecuteQuery(OracleCommand command)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(ConString))
                {
                    con.Open();
                    command.Connection = con;
                    OracleDataAdapter oda = new OracleDataAdapter(command);
                    DataSet ds = new DataSet();
                    oda.Fill(ds);
                    con.Close();

                    if (ds.Tables.Count > 0)
                    {
                        return ds;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public Object ExecuteScalar(string query)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(ConString))
                {
                    con.Open();
                    OracleCommand getTableMetadataCmd;
                    getTableMetadataCmd = new OracleCommand(query, con);                    
                    Object data = getTableMetadataCmd.ExecuteScalar();
                    con.Close();

                    if (data == null) data = new Object();
                    return data;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public int ExecuteNonQuery(OracleCommand command)
        {
            int result = 0;
            OracleConnection conn = new OracleConnection(ConString);
            try
            {
                conn.Open();
                command.Connection = conn;
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return result;
        }


    }
}
