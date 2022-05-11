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
    public partial class Control_HSBA : Form
    {
        public Control_HSBA(string MaCSYT)
        {
            InitializeComponent();
            MaCSYT_comboBox.Text = MaCSYT;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string MaHSBA, MaBN, Ngay, ChuanDoan, MaBS, MaKhoa, MaCSYT, KetLuan;

            MaHSBA = MaHSBA_textBox.Text;
            MaBN = MaBN_comboBox.Text;
            Ngay = Ngay_dateTimePicker.Text;
            ChuanDoan = ChuanDoan_textBox.Text;
            MaBS = MaBS_comboBox.Text;
            MaKhoa = MaKhoa_comboBox.Text;
            MaCSYT = MaCSYT_comboBox.Text;
            KetLuan = KetLuan_textBox.Text;

            OracleCommand cmd = new OracleCommand("INSERT INTO QLCSYTE_ADMIN.VW_HSBA_QLCSYT(MAHSBA,MABN,NGAY,CHANDOAN,MABS,MAKHOA,MACSYT,KETLUAN) VALUES (:MaHSBA ,:MaBN ,TO_DATE(:Ngay,'dd/MM/yyyy') ,:ChuanDoan ,:MaBS , :MaKhoa, :MaCSYT, :KetLuan)");
            cmd.Parameters.Add(new OracleParameter("MaHSBA", MaHSBA));
            cmd.Parameters.Add(new OracleParameter("MaBN", MaBN));
            cmd.Parameters.Add(new OracleParameter("Ngay", Ngay));
            cmd.Parameters.Add(new OracleParameter("MaBS", MaBS));
            cmd.Parameters.Add(new OracleParameter("MaKhoa", MaKhoa));
            cmd.Parameters.Add(new OracleParameter("MaCSYT", MaCSYT));
            cmd.Parameters.Add(new OracleParameter("KetLuan", KetLuan));
            cmd.Parameters.Add(new OracleParameter("ChuanDoan", ChuanDoan));
            
            int insert = DataProvider.instance.ExecuteNonQuery(cmd);
            if (insert > 0)
            {
                MessageBox.Show("Thêm HSBA thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm HSBA thất bại.");
            }
        }

        private void MaBN_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
