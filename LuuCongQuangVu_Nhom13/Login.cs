using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuuCongQuangVu_Nhom13
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            using var dbcontext = new Models.QLThuVienContext();
            //var acc = dbcontext.Accounts.Where(a => (a.Usename == txtTaikhoan.Text && a.Password == txtMatkhau.Text)).FirstOrDefault();
            Models.Account acc = (from a in dbcontext.Accounts where (a.Usename == txtTaikhoan.Text && a.Password == txtMatkhau.Text) select a).FirstOrDefault();
            if (acc != null)
            {
                    this.Hide();
                    QuanLiThuVien menu = new QuanLiThuVien();
                    menu.Tag = acc;// get account nv
                    menu.Text = "Quản lí thư viện";
                    menu.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
