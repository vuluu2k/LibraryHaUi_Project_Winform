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
            var acc = dbcontext.Accounts.Where(a => (a.Usename == txtTaikhoan.Text && a.Password == txtMatkhau.Text)).FirstOrDefault();
            if (acc != null)
            {
                if (acc.Capdo.Equals("Nhân viên"))
                {
                    this.Hide();
                    QuanLiThuVien menu = new QuanLiThuVien();
                    menu.Text = "Quản lí thư viện";
                    menu.Show();
                }
                else if (acc.Capdo.Equals("Admin"))
                {
                    this.Hide();
                    Admin admin = new Admin();
                    admin.Show();
                }
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
