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
    public partial class DialogUpdateLHD : Form
    {
        Models.QLThuVienContext dbcontext = new Models.QLThuVienContext();
        public DialogUpdateLHD()
        {
            InitializeComponent();
        }
        public int TheValue
        {
            get { return int.Parse(txtSLmua.Text); }
        }

        private void DialogUpdateLHD_Load(object sender, EventArgs e)
        {
            Models.Sach book = (from b in dbcontext.Saches where b.Idsach == (string) this.Tag select b).FirstOrDefault();
            lbMaSach.Text = book.Idsach;
            lbTenSach.Text = book.Tensach;
            btnXacNhan.DialogResult = DialogResult.OK;
        }
        private void txtSLmua_Validated(object sender, EventArgs e)
        {
            GetError.SetError(txtSLmua, "");
        }
        private void txtSLmua_Validating(object sender, CancelEventArgs e)
        {
            if (txtSLmua.Text == "")
            {
                GetError.SetError(txtSLmua, "Bạn phải nhập số lượng mua để sửa!");
                e.Cancel = true;
            }
            else
            {
                try
                {
                    Models.Sach book = (from b in dbcontext.Saches where b.Idsach == (string) this.Tag select b).FirstOrDefault();
                    if (int.Parse(txtSLmua.Text) > book.Soluong)
                    {
                        GetError.SetError(txtSLmua, "Số lượng mua bạn sửa vượt quá số lượng có, hiện tại còn " + book.Soluong + " quyển");
                        e.Cancel = true;
                        txtSLmua.SelectAll();
                    }

                }
                catch (Exception)
                {
                    GetError.SetError(txtSLmua, "Bạn phải nhập số lượng mua là số nguyên!");
                    e.Cancel = true;
                    txtSLmua.SelectAll();
                }
            }
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {

        }

    }
}
