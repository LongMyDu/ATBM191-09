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
    public partial class ThongTinCaNhan_NV : Form
    {
        public ThongTinCaNhan_NV(DataSet TTCN)
        {
            InitializeComponent();

            NgaySinh_Picker.Format = DateTimePickerFormat.Custom;
            NgaySinh_Picker.CustomFormat = "dd/MM/yyyy";

            MaNV_TextBox.Text = TTCN.Tables[0].Rows[0]["MANV"].ToString();
            TenNV_TextBox.Text = TTCN.Tables[0].Rows[0]["HOTEN"].ToString();
            CMND_NV_TextBox.Text = TTCN.Tables[0].Rows[0]["CMND"].ToString();
            Phai_ComboBox.Text = TTCN.Tables[0].Rows[0]["PHAI"].ToString();
            MaCSYT_NV_TextBox.Text = TTCN.Tables[0].Rows[0]["CSYT"].ToString();
            QueQuanNV_TextBox.Text = TTCN.Tables[0].Rows[0]["QUEQUAN"].ToString();
            SĐT_NV_TextBox.Text = TTCN.Tables[0].Rows[0]["SODT"].ToString();
            ChuyenKhoaNV_TextBox.Text = TTCN.Tables[0].Rows[0]["CHUYENKHOA"].ToString();
            VaiTroNV_TextBox.Text = TTCN.Tables[0].Rows[0]["VAITRO"].ToString();
            NgaySinh_Picker.Value = DateTime.Parse(TTCN.Tables[0].Rows[0]["NGAYSINH"].ToString());

            
        }

        private void NgaySinh_Picker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string MaNV, HoTenNV, CMND_NV, NgaySinhNV, PhaiNV, QueQuanNV, CSYT_NV, VaiTro_NV, ChuyenKhoaNV, SDT_NV;

            MaNV = MaNV_TextBox.Text;
            HoTenNV = TenNV_TextBox.Text;
            CMND_NV = CMND_NV_TextBox.Text;
            NgaySinhNV = NgaySinh_Picker.Text;
            PhaiNV = Phai_ComboBox.Text;
            QueQuanNV = QueQuanNV_TextBox.Text;
            CSYT_NV = MaCSYT_NV_TextBox.Text;
            VaiTro_NV = VaiTroNV_TextBox.Text;
            ChuyenKhoaNV = ChuyenKhoaNV_TextBox.Text;
            SDT_NV = SĐT_NV_TextBox.Text;

            OracleCommand cmd = new OracleCommand("UPDATE QLCSYTE_ADMIN.VW_THONGTINCANHAN_NHANVIEN SET HOTEN = :HoTen ,PHAI = :Phai,  NGAYSINH = TO_DATE(:NgaySinh,'dd/MM/yyyy') ,CMND = :cmnd ,QUEQUAN = :QueQuan ,SODT = :sdt ,CSYT = :csyt ,VAITRO = :VaiTro, CHUYENKHOA = :ChuyenKhoa WHERE MANV = :MaNV");
            cmd.Parameters.Add(new OracleParameter("HoTen", HoTenNV));
            cmd.Parameters.Add(new OracleParameter("Phai", PhaiNV));
            cmd.Parameters.Add(new OracleParameter("NgaySinh", NgaySinhNV));
            cmd.Parameters.Add(new OracleParameter("cmnd", CMND_NV));
            cmd.Parameters.Add(new OracleParameter("QueQuan", QueQuanNV));
            cmd.Parameters.Add(new OracleParameter("sdt", SDT_NV));
            cmd.Parameters.Add(new OracleParameter("csyt", CSYT_NV));
            cmd.Parameters.Add(new OracleParameter("VaiTro", VaiTro_NV));
            cmd.Parameters.Add(new OracleParameter("ChuyenKhoa", ChuyenKhoaNV));
            cmd.Parameters.Add(new OracleParameter("MANV", MaNV));

            int update = DataProvider.instance.ExecuteNonQuery(cmd);
            if(update > 0)
            {
                MessageBox.Show("Chỉnh sửa thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Chỉnh sửa thất bại.");
            }
        }

        private void MaNV_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void VaiTroNV_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void MaCSYT_NV_TextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
