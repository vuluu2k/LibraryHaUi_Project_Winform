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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnThuVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLiThuVien menu = new QuanLiThuVien();
            menu.Text = this.Text;
            menu.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Bạn có muốn thoát không ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Bạn muốn đăng xuất ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
        }

        private void btnQLTaiKhoan_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Accout accout = new Manage_Accout();
            accout.Show();
        }
    }
}
