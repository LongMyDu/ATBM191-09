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
    public partial class Control_HSBA_DV : Form
    {
        public bool Them = false;
        public Control_HSBA_DV(string MaCSYT)
        {
            InitializeComponent(); 
            Xoa_button.Visible = false;

            HSBA_DV_Button.Text = "Thêm";
            Them = true;
        }

        public Control_HSBA_DV(DataSet HSBA)
        {
            InitializeComponent();

            Ngay_dateTimePicker.Format = DateTimePickerFormat.Custom;
            Ngay_dateTimePicker.CustomFormat = "dd/MM/yyyy";

            MaHSBA_textBox.Text = HSBA.Tables[0].Rows[0]["MAHSBA"].ToString();
            Ngay_dateTimePicker.Text = HSBA.Tables[0].Rows[0]["NGAY"].ToString();
            MaDV_comboBox.Text = HSBA.Tables[0].Rows[0]["MADV"].ToString();
            MaKTV_comboBox.Text = HSBA.Tables[0].Rows[0]["MAKTV"].ToString();
            Ketqua_textBox.Text = HSBA.Tables[0].Rows[0]["KETQUA"].ToString();

            Them = false;
            Xoa_button.Visible = true;
            HSBA_DV_Button.Text = "Cập nhật";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Control_HSBA_DV_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void MaHSBA_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void HSBA_DV_Button_Click(object sender, EventArgs e)
        {
            string MaHSBA, MaDV, Ngay, MaKTV, KetQua;

            OracleCommand cmd;

            if (Them == true)
            {
                MaHSBA_textBox.Enabled = true;
                MaDV_comboBox.Enabled = true;
                Ngay_dateTimePicker.Enabled = true;

                cmd = new OracleCommand("INSERT INTO QLCSYTE_ADMIN.VW_HSBA_DV_QLCSYT (MAHSBA,MADV,NGAY,MAKTV,KETQUA) VALUES (:MaHSBA ,:MaDV ,TO_DATE(:Ngay,'dd/MM/yyyy') ,:MaKTV, :KetQua)");
            }
            else
            {
                MaHSBA_textBox.Enabled = false;
                MaDV_comboBox.Enabled = false;
                Ngay_dateTimePicker.Enabled = false;

                cmd = new OracleCommand("UPDATE QLCSYTE_ADMIN.VW_HSBA_DV_QLCSYT SET MAKTV = :MaBN, KETQUA = :ChuanDoan WHERE MAHSBA = :MaHSBA AND MADV = :MaDV AND NGAY = :Ngay");

            }

            MaHSBA = MaHSBA_textBox.Text;
            MaDV = MaDV_comboBox.Text;
            Ngay = Ngay_dateTimePicker.Text;
            MaKTV = MaKTV_comboBox.Text;
            KetQua = Ketqua_textBox.Text;


            cmd.Parameters.Add(new OracleParameter("MaHSBA", MaHSBA));
            cmd.Parameters.Add(new OracleParameter("MaDV", MaDV));
            cmd.Parameters.Add(new OracleParameter("Ngay", Ngay));
            cmd.Parameters.Add(new OracleParameter("MaKTV", MaKTV));
            cmd.Parameters.Add(new OracleParameter("KetQua", KetQua));

            MessageBox.Show(cmd.ToString());

            int dv = DataProvider.instance.ExecuteNonQuery(cmd);
            if (dv > 0)
            {
                if (Them == true)
                {
                    MessageBox.Show("Thêm Dịch vụ HSBA thành công!");
                }
                else
                {
                    MessageBox.Show("Cập nhật Dịch vụ HSBA thành công!");
                    Xoa_button.Visible = false;
                }
                this.Close();
            }
            else
            {
                if (Them == true)
                {
                    MessageBox.Show("Thêm Dịch vụ HSBA thất bại.");
                }
                else
                {
                    MessageBox.Show("Cập nhật Dịch vụ HSBA thất bại.");
                }
            }
        }

        private void Xoa_button_Click(object sender, EventArgs e)
        {
            string MaHSBA;

            MaHSBA = MaHSBA_textBox.Text;

            OracleCommand cmd = new OracleCommand("DELETE FROM QLCSYTE_ADMIN.VW_HSBA_DV_QLCSYT WHERE MAHSBA = :MaHSBA AND MADV = :MaDV AND NGAY = :Ngay");
            cmd.Parameters.Add(new OracleParameter("MaHSBA", MaHSBA));

            int dv = DataProvider.instance.ExecuteNonQuery(cmd);
            if (dv > 0)
            {
                MessageBox.Show("Xóa Dịch vụ HSBA thành công!");
                Xoa_button.Visible = false;
                this.Close();
            }
            else
            {

                MessageBox.Show("Xóa Dịch vụ HSBA thất bại.");

            }
        }
    }
}
