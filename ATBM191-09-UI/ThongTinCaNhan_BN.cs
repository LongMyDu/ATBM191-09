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
    public partial class ThongTinCaNhan_BN : Form
    {
        public ThongTinCaNhan_BN(DataSet TTCN)
        {
            InitializeComponent();

            NgaySinh_dateTimePicker.Format = DateTimePickerFormat.Custom;
            NgaySinh_dateTimePicker.CustomFormat = "dd/MM/yyyy";

            MaBN_TextBox.Text = TTCN.Tables[0].Rows[0]["MABN"].ToString();
            TenBN_TextBox.Text = TTCN.Tables[0].Rows[0]["TENBN"].ToString();
            SoNha_TextBox.Text = TTCN.Tables[0].Rows[0]["SONHA"].ToString();
            TenDuong_TextBox.Text = TTCN.Tables[0].Rows[0]["TENDUONG"].ToString();
            QuanHuyen_TextBox.Text = TTCN.Tables[0].Rows[0]["QUANHUYEN"].ToString();
            MaCSYT_TextBox.Text = TTCN.Tables[0].Rows[0]["MACSYT"].ToString();
            CMND_TextBox.Text = TTCN.Tables[0].Rows[0]["CMND"].ToString();
            TinhTP_TextBox.Text = TTCN.Tables[0].Rows[0]["TINHTP"].ToString();
            ThuocDiUng_textBox.Text = TTCN.Tables[0].Rows[0]["DIUNGTHUOC"].ToString();
            TieuSuBenh_TextBox.Text = TTCN.Tables[0].Rows[0]["TIENSUBENH"].ToString();
            TieuSuGD_TextBox.Text = TTCN.Tables[0].Rows[0]["TIENSUBENHGD"].ToString();
            NgaySinh_dateTimePicker.Value = DateTime.Parse(TTCN.Tables[0].Rows[0]["NGAYSINH"].ToString());
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string MaBN, MaCSYT, TenBN, CMND, NgaySinh, SoNha, TenDuong, QuanHuyen, TinhTP, TienSuBenh, TienSuGD, DiUngThuoc;

            MaBN = MaBN_TextBox.Text;
            MaCSYT = MaCSYT_TextBox.Text;
            TenBN = TenBN_TextBox.Text;
            CMND = CMND_TextBox.Text;
            NgaySinh = NgaySinh_dateTimePicker.Text;
            SoNha = SoNha_TextBox.Text;
            TenDuong = TenDuong_TextBox.Text;
            QuanHuyen = QuanHuyen_TextBox.Text;
            TinhTP = TinhTP_TextBox.Text;
            TienSuBenh = TieuSuBenh_TextBox.Text;
            TienSuGD = TieuSuGD_TextBox.Text;
            DiUngThuoc = ThuocDiUng_textBox.Text;

            OracleCommand cmd = new OracleCommand("UPDATE QLCSYTE_ADMIN.VW_THONGTINCANHAN_BENHNHAN SET MACSYT = :MaCSYT, TENBN = :TenBN, CMND = :cmnd, NGAYSINH = TO_DATE(:NgaySinh,'dd/MM/yyyy'), SONHA = :SoNha, TENDUONG = :TenDuong, QUANHUYEN = :QuanHuyen, TINHTP = :TinhTP, TIENSUBENH = :TSBenh, TIENSUBENHGD = :TSBenhGD, DIUNGTHUOC = :ThuocDiUng WHERE MABN = :MaBN");
            cmd.Parameters.Add(new OracleParameter("MaCSYT", MaCSYT));
            cmd.Parameters.Add(new OracleParameter("TenBN", TenBN));
            cmd.Parameters.Add(new OracleParameter("cmnd", CMND));
            cmd.Parameters.Add(new OracleParameter("NgaySinh", NgaySinh));
            cmd.Parameters.Add(new OracleParameter("SoNha", SoNha));
            cmd.Parameters.Add(new OracleParameter("TenDuong", TenDuong));
            cmd.Parameters.Add(new OracleParameter("QuanHuyen", QuanHuyen));
            cmd.Parameters.Add(new OracleParameter("TinhTP", TinhTP));
            cmd.Parameters.Add(new OracleParameter("TSBenh", TienSuBenh));
            cmd.Parameters.Add(new OracleParameter("TSBenhGD", TienSuGD));
            cmd.Parameters.Add(new OracleParameter("ThuocDiUng", DiUngThuoc));
            cmd.Parameters.Add(new OracleParameter("MaBN", MaBN));

            int update = DataProvider.instance.ExecuteNonQuery(cmd);
            if (update > 0)
            {
                MessageBox.Show("Chỉnh sửa thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Chỉnh sửa thất bại.");
            }
        }
    }
}
