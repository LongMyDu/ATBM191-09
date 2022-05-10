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
    public partial class ThongTinCaNhan_NV : Form
    {
        public string MaNV;
        public string HoTenNV;
        public string CMND_NV;
        public string NgaySinhNV;
        public string PhaiNV;
        public string QueQuanNV;
        public string CSYT_NV;
        public string VaiTro_NV;
        public string ChuyenKhoaNV;
        public string SDT_NV;

        public ThongTinCaNhan_NV(DataSet TTCN)
        {
            InitializeComponent();
            MaNV_TextBox.Text = TTCN.Tables[0].Columns["MANV"].ToString();
            TenNV_TextBox.Text = TTCN.Tables[0].Columns["HOTEN"].ToString();
            CMND_NV_TextBox.Text = TTCN.Tables[0].Columns["CMND"].ToString();
            GiơiTinhNV_TextBox.Text = TTCN.Tables[0].Columns["PHAI"].ToString();
            MaCSYT_NV_TextBox.Text = TTCN.Tables[0].Columns["CSYT"].ToString();
            QueQuanNV_TextBox.Text = TTCN.Tables[0].Columns["QUEQUAN"].ToString();
            SĐT_NV_TextBox.Text = TTCN.Tables[0].Columns["SODT"].ToString();
            ChuyenKhoaNV_TextBox.Text = TTCN.Tables[0].Columns["CHUYENKHOA"].ToString();
            VaiTroNV_TextBox.Text = TTCN.Tables[0].Columns["VAITRO"].ToString();
            NgaySinhNV_TextBox.Text = TTCN.Tables[0].Columns["NGAYSINH"].ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ThongTinCaNhan_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MaNV_TextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
