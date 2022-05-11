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
        public bool Them = false;
        public Control_HSBA(string MaCSYT)
        {
            InitializeComponent();
            MaCSYT_comboBox.Text = MaCSYT;
            Xoa_button.Visible = false;

            HSBA_Button.Text = "Thêm";
            Them = true;
        }

        public Control_HSBA(DataSet HSBA)
        {
            InitializeComponent();

            Ngay_dateTimePicker.Format = DateTimePickerFormat.Custom;
            Ngay_dateTimePicker.CustomFormat = "dd/MM/yyyy";

            MaHSBA_textBox.Text = HSBA.Tables[0].Rows[0]["MAHSBA"].ToString();
            MaBN_comboBox.Text = HSBA.Tables[0].Rows[0]["MABN"].ToString();
            Ngay_dateTimePicker.Text = HSBA.Tables[0].Rows[0]["NGAY"].ToString();
            ChuanDoan_textBox.Text = HSBA.Tables[0].Rows[0]["CHANDOAN"].ToString();
            MaBS_comboBox.Text = HSBA.Tables[0].Rows[0]["MABS"].ToString();
            MaKhoa_comboBox.Text = HSBA.Tables[0].Rows[0]["MAKHOA"].ToString();
            MaCSYT_comboBox.Text = HSBA.Tables[0].Rows[0]["MACSYT"].ToString();
            KetLuan_textBox.Text = HSBA.Tables[0].Rows[0]["KETLUAN"].ToString();

            Them = false;
            Xoa_button.Visible = true;
            HSBA_Button.Text = "Cập nhật";

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void HSBA_Button_Click(object sender, EventArgs e)
        {
            string MaHSBA, MaBN, Ngay, ChuanDoan, MaBS, MaKhoa, MaCSYT, KetLuan;

            OracleCommand cmd;

            if (Them == true)
            {
                MaHSBA_textBox.Enabled = true;
                cmd = new OracleCommand("INSERT INTO QLCSYTE_ADMIN.VW_HSBA_QLCSYT (MAHSBA,MABN,NGAY,CHANDOAN,MABS,MAKHOA,MACSYT,KETLUAN) " +
                    "                   VALUES (:MaHSBA ,:MaBN ,TO_DATE(:Ngay,'dd/MM/yyyy') ,:ChuanDoan, :MaBS , :MaKhoa, :MaCSYT, :KetLuan)");
            }
            else
            {
                MaHSBA_textBox.Enabled = false;
                cmd = new OracleCommand("UPDATE QLCSYTE_ADMIN.VW_HSBA_QLCSYT SET MABN = :MaBN ,NGAY = TO_DATE(:Ngay,'dd/MM/yyyy'), CHANDOAN = :ChuanDoan ,MABS = :MaBS ,MAKHOA = :MaKhoa ,MACSYT = :MaCSYT, KETLUAN = :KetLuan WHERE MAHSBA = :MaHSBA");

            }
            MaHSBA = MaHSBA_textBox.Text;
            MaBN = MaBN_comboBox.Text;
            Ngay = Ngay_dateTimePicker.Text;
            ChuanDoan = ChuanDoan_textBox.Text;
            MaBS = MaBS_comboBox.Text;
            MaKhoa = MaKhoa_comboBox.Text;
            MaCSYT = MaCSYT_comboBox.Text;
            KetLuan = KetLuan_textBox.Text;

            cmd.Parameters.Add(new OracleParameter("MaHSBA", MaHSBA));
            cmd.Parameters.Add(new OracleParameter("MaBN", MaBN));
            cmd.Parameters.Add(new OracleParameter("Ngay", Ngay));
            cmd.Parameters.Add(new OracleParameter("MaBS", MaBS));
            cmd.Parameters.Add(new OracleParameter("MaKhoa", MaKhoa));
            cmd.Parameters.Add(new OracleParameter("MaCSYT", MaCSYT));
            cmd.Parameters.Add(new OracleParameter("KetLuan", KetLuan));
            cmd.Parameters.Add(new OracleParameter("ChuanDoan", ChuanDoan));

            MessageBox.Show(cmd.ToString());

            int hsba = DataProvider.instance.ExecuteNonQuery(cmd);
            if (hsba > 0)
            {
                if (Them == true)
                {
                    MessageBox.Show("Thêm HSBA thành công!");
                }
                else
                {
                    MessageBox.Show("Cập nhật HSBA thành công!");
                    Xoa_button.Visible = false;
                }    
                this.Close();
            }
            else
            {
                if (Them == true)
                {
                    MessageBox.Show("Thêm HSBA thất bại.");
                }
                else
                {
                    MessageBox.Show("Cập nhật HSBA thất bại.");
                }
            }
        }

        private void MaBN_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Xoa_button_Click(object sender, EventArgs e)
        {
            string MaHSBA;

            MaHSBA = MaHSBA_textBox.Text;

            OracleCommand cmd = new OracleCommand("DELETE FROM QLCSYTE_ADMIN.VW_HSBA_QLCSYT WHERE MAHSBA = :MaHSBA");
            cmd.Parameters.Add(new OracleParameter("MaHSBA", MaHSBA));

            int hsba = DataProvider.instance.ExecuteNonQuery(cmd);
            if (hsba > 0)
            {
               MessageBox.Show("Xóa HSBA thành công!");
               Xoa_button.Visible = false;
               this.Close();
            }
            else
            {
                
                MessageBox.Show("Xóa HSBA thất bại.");
                
            }
        }

        private void ChuanDoan_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void header_panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
