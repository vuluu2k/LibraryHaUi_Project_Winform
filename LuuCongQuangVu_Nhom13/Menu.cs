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
    public partial class QuanLiThuVien : Form
    {
        public QuanLiThuVien()
        {

            InitializeComponent();
        }
        //----------------------------Quản lý sách-------------------------------------------------------------------------------------------------------------
        private void ReadFile()
        {
            using var dbcontext = new Models.QLThuVienContext();
            var list_sach = dbcontext.Saches.ToList();
            if (list_sach != null)
            {
                if (list_sach.Count() > 0)
                {
                    txtSL_Sach.Text = Convert.ToString(list_sach.Count());
                    dgvSach.Rows.Clear();
                    dgvSach.ColumnCount = 8;
                    for (int i = 0; i < list_sach.Count(); i++)
                    {
                        dgvSach.Rows.Add();
                        dgvSach.Rows[i].Cells[0].Value = list_sach[i].Idsach;
                        dgvSach.Rows[i].Cells[1].Value = list_sach[i].Tensach;
                        dgvSach.Rows[i].Cells[2].Value = list_sach[i].Tacgia;
                        dgvSach.Rows[i].Cells[3].Value = list_sach[i].Soluong;
                        dgvSach.Rows[i].Cells[4].Value = list_sach[i].Theloai;
                        dgvSach.Rows[i].Cells[5].Value = list_sach[i].Giasach;
                        dgvSach.Rows[i].Cells[6].Value = list_sach[i].Nhaxuatban;
                        dgvSach.Rows[i].Cells[7].Value = list_sach[i].Vitri;
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private bool isBoxIsEmpty()
        {
            if(txtmasach.Text.Equals("")|| txttensach.Text.Equals("") || txttacgia.Text.Equals("") || txtsoluong.Text.Equals("") || txttheloai.Text.Equals("") || txtgiasach.Text.Equals("") || txtnhasx.Text.Equals("")||cbvitri.Text.Equals(""))
            {
                return true;
            }
            return false;
        }
        private bool isRadioIsEmpty()
        {
            if(rdmasach.Checked==false&& rdtensach.Checked == false && rdtacgia.Checked == false && rdtheloai.Checked == false && rdnxb.Checked == false && rdvitri.Checked == false)
            {
                return true;
            }
            return false;
        }
        private void AddBook()
        {
            if (isBoxIsEmpty())
            {
                MessageBox.Show("Bạn đang để trống trường nhập dữ liệu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmasach.Focus();
            }
            else
            {
                using (var dbcontext = new Models.QLThuVienContext())
                {
                    try
                    {
                        Models.Sach sach = new Models.Sach();
                        sach.Idsach = txtmasach.Text;
                        sach.Tensach = txttensach.Text;
                        sach.Tacgia = txttacgia.Text;
                        sach.Soluong = int.Parse(txtsoluong.Text);
                        sach.Theloai = txttheloai.Text;
                        sach.Giasach = double.Parse(txtgiasach.Text);
                        sach.Nhaxuatban = txtnhasx.Text;
                        sach.Vitri = cbvitri.Text;
                        dbcontext.Saches.Add(sach);
                        dbcontext.SaveChanges();
                        ReadFile();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Dữ liệu đầu vào bảng sai");
                    }

                }
            }
        }
        private void DelBook()
        {
            using var dbcontext = new Models.QLThuVienContext();
            //Models.Sach id = dbcontext.Saches.Where(sach => sach.Idsach == txtmasach.Text).FirstOrDefault();
            //var idm = dbcontext.Muontrasaches.Where(m => m.Idsach == txtmasach.Text).ToList();
            Models.Sach id = (from book in dbcontext.Saches where book.Idsach==txtmasach.Text select book).FirstOrDefault();
            var idm = (from m in dbcontext.Muontrasaches where m.Idsach==txtmasach.Text select m).ToList();
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn xoá không", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                if (id != null)
                {
                    if (idm != null)
                    {
                        dbcontext.Muontrasaches.RemoveRange(idm);
                    }
                    dbcontext.Saches.Remove(id);
                    dbcontext.SaveChanges();
                    ReadFile();
                }
                else
                {
                    MessageBox.Show("Mã sách không tồn tại", "Thông báo");
                }
            }
        }
        private void UpdateBook()
        {
            using var dbcontext = new Models.QLThuVienContext();
            //Models.Sach sach = dbcontext.Saches.Where(sach => sach.Idsach == txtmasach.Text).FirstOrDefault();
            Models.Sach sach = (from book in dbcontext.Saches where book.Idsach==txtmasach.Text select book).FirstOrDefault();
            if (sach != null)
            {
                sach.Tensach = txttensach.Text;
                sach.Tacgia = txttacgia.Text;
                sach.Soluong = int.Parse(txtsoluong.Text);
                sach.Theloai = label.Text;
                sach.Giasach = double.Parse(txtgiasach.Text);
                sach.Nhaxuatban = txtnhasx.Text;
                sach.Vitri = cbvitri.Text;
                dbcontext.SaveChanges();
                ReadFile();
            }
            else
            {
                MessageBox.Show("Mã sách không tồn tại", "Thông báo");
            }
        }
        private void SearchBook()
        {
            if (isRadioIsEmpty())
            {
                MessageBox.Show("Bạn chưa chọn nút tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (rdmasach.Checked)
            {
                using var dbcontext = new Models.QLThuVienContext();
                //var list_sach = dbcontext.Saches.Where(book=>book.Idsach==txtmasach.Text).ToList();
                var list_sach = (from book in dbcontext.Saches where book.Idsach == txtmasach.Text select book).ToList();
                if (list_sach != null)
                {
                    if (list_sach.Count() > 0)
                    {
                        dgvSach.Rows.Clear();
                        dgvSach.ColumnCount = 8;
                        for (int i = 0; i < list_sach.Count(); i++)
                        {
                            dgvSach.Rows.Add();
                            dgvSach.Rows[i].Cells[0].Value = list_sach[i].Idsach;
                            dgvSach.Rows[i].Cells[1].Value = list_sach[i].Tensach;
                            dgvSach.Rows[i].Cells[2].Value = list_sach[i].Tacgia;
                            dgvSach.Rows[i].Cells[3].Value = list_sach[i].Soluong;
                            dgvSach.Rows[i].Cells[4].Value = list_sach[i].Theloai;
                            dgvSach.Rows[i].Cells[5].Value = list_sach[i].Giasach;
                            dgvSach.Rows[i].Cells[6].Value = list_sach[i].Nhaxuatban;
                            dgvSach.Rows[i].Cells[7].Value = list_sach[i].Vitri;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại dữ liệu tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (rdtensach.Checked)
            {
                using var dbcontext = new Models.QLThuVienContext();
                //var list_sach = dbcontext.Saches.Where(book => book.Tensach == txttensach.Text).ToList();
                var list_sach = (from book in dbcontext.Saches where book.Tensach == txttensach.Text select book).ToList();
                if (list_sach != null)
                {
                    if (list_sach.Count() > 0)
                    {
                        dgvSach.Rows.Clear();
                        dgvSach.ColumnCount = 8;
                        for (int i = 0; i < list_sach.Count(); i++)
                        {
                            dgvSach.Rows.Add();
                            dgvSach.Rows[i].Cells[0].Value = list_sach[i].Idsach;
                            dgvSach.Rows[i].Cells[1].Value = list_sach[i].Tensach;
                            dgvSach.Rows[i].Cells[2].Value = list_sach[i].Tacgia;
                            dgvSach.Rows[i].Cells[3].Value = list_sach[i].Soluong;
                            dgvSach.Rows[i].Cells[4].Value = list_sach[i].Theloai;
                            dgvSach.Rows[i].Cells[5].Value = list_sach[i].Giasach;
                            dgvSach.Rows[i].Cells[6].Value = list_sach[i].Nhaxuatban;
                            dgvSach.Rows[i].Cells[7].Value = list_sach[i].Vitri;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại dữ liệu tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (rdtacgia.Checked)
            {
                using var dbcontext = new Models.QLThuVienContext();
                //var list_sach = dbcontext.Saches.Where(book => book.Tacgia == txttacgia.Text).ToList();
                var list_sach = (from book in dbcontext.Saches where book.Tacgia == txttacgia.Text select book).ToList();
                if (list_sach != null)
                {
                    if (list_sach.Count() > 0)
                    {
                        dgvSach.Rows.Clear();
                        dgvSach.ColumnCount = 8;
                        for (int i = 0; i < list_sach.Count(); i++)
                        {
                            dgvSach.Rows.Add();
                            dgvSach.Rows[i].Cells[0].Value = list_sach[i].Idsach;
                            dgvSach.Rows[i].Cells[1].Value = list_sach[i].Tensach;
                            dgvSach.Rows[i].Cells[2].Value = list_sach[i].Tacgia;
                            dgvSach.Rows[i].Cells[3].Value = list_sach[i].Soluong;
                            dgvSach.Rows[i].Cells[4].Value = list_sach[i].Theloai;
                            dgvSach.Rows[i].Cells[5].Value = list_sach[i].Giasach;
                            dgvSach.Rows[i].Cells[6].Value = list_sach[i].Nhaxuatban;
                            dgvSach.Rows[i].Cells[7].Value = list_sach[i].Vitri;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại dữ liệu tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (rdtheloai.Checked)
            {
                using var dbcontext = new Models.QLThuVienContext();
                //var list_sach = dbcontext.Saches.Where(book => book.Theloai == txttheloai.Text).ToList();
                var list_sach = (from book in dbcontext.Saches where book.Theloai == txttheloai.Text select book).ToList();
                if (list_sach != null)
                {
                    if (list_sach.Count() > 0)
                    {
                        dgvSach.Rows.Clear();
                        dgvSach.ColumnCount = 8;
                        for (int i = 0; i < list_sach.Count(); i++)
                        {
                            dgvSach.Rows.Add();
                            dgvSach.Rows[i].Cells[0].Value = list_sach[i].Idsach;
                            dgvSach.Rows[i].Cells[1].Value = list_sach[i].Tensach;
                            dgvSach.Rows[i].Cells[2].Value = list_sach[i].Tacgia;
                            dgvSach.Rows[i].Cells[3].Value = list_sach[i].Soluong;
                            dgvSach.Rows[i].Cells[4].Value = list_sach[i].Theloai;
                            dgvSach.Rows[i].Cells[5].Value = list_sach[i].Giasach;
                            dgvSach.Rows[i].Cells[6].Value = list_sach[i].Nhaxuatban;
                            dgvSach.Rows[i].Cells[7].Value = list_sach[i].Vitri;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại dữ liệu tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (rdnxb.Checked)
            {
                using var dbcontext = new Models.QLThuVienContext();
                //var list_sach = dbcontext.Saches.Where(book => book.Nhaxuatban == txtnhasx.Text).ToList();
                var list_sach = (from book in dbcontext.Saches where book.Nhaxuatban == txtnhasx.Text select book).ToList();
                if (list_sach != null)
                {
                    if (list_sach.Count() > 0)
                    {
                        dgvSach.Rows.Clear();
                        dgvSach.ColumnCount = 8;
                        for (int i = 0; i < list_sach.Count(); i++)
                        {
                            dgvSach.Rows.Add();
                            dgvSach.Rows[i].Cells[0].Value = list_sach[i].Idsach;
                            dgvSach.Rows[i].Cells[1].Value = list_sach[i].Tensach;
                            dgvSach.Rows[i].Cells[2].Value = list_sach[i].Tacgia;
                            dgvSach.Rows[i].Cells[3].Value = list_sach[i].Soluong;
                            dgvSach.Rows[i].Cells[4].Value = list_sach[i].Theloai;
                            dgvSach.Rows[i].Cells[5].Value = list_sach[i].Giasach;
                            dgvSach.Rows[i].Cells[6].Value = list_sach[i].Nhaxuatban;
                            dgvSach.Rows[i].Cells[7].Value = list_sach[i].Vitri;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại dữ liệu tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (rdvitri.Checked)
            {
                using var dbcontext = new Models.QLThuVienContext();
                //var list_sach = dbcontext.Saches.Where(book => book.Vitri == cbvitri.Text).ToList();
                var list_sach = (from book in dbcontext.Saches where book.Vitri == cbvitri.Text select book).ToList();
                if (list_sach != null)
                {
                    if (list_sach.Count() > 0)
                    {
                        dgvSach.Rows.Clear();
                        dgvSach.ColumnCount = 8;
                        for (int i = 0; i < list_sach.Count(); i++)
                        {
                            dgvSach.Rows.Add();
                            dgvSach.Rows[i].Cells[0].Value = list_sach[i].Idsach;
                            dgvSach.Rows[i].Cells[1].Value = list_sach[i].Tensach;
                            dgvSach.Rows[i].Cells[2].Value = list_sach[i].Tacgia;
                            dgvSach.Rows[i].Cells[3].Value = list_sach[i].Soluong;
                            dgvSach.Rows[i].Cells[4].Value = list_sach[i].Theloai;
                            dgvSach.Rows[i].Cells[5].Value = list_sach[i].Giasach;
                            dgvSach.Rows[i].Cells[6].Value = list_sach[i].Nhaxuatban;
                            dgvSach.Rows[i].Cells[7].Value = list_sach[i].Vitri;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại dữ liệu tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void Clear()
        {
            txtmasach.Clear();
            txttensach.Clear();
            txttacgia.Clear();
            txtsoluong.Clear();
            txttheloai.Clear();
            txtgiasach.Clear();
            txtnhasx.Clear();
            cbvitri.Text="";
            txtmasach.Focus();
        }
        private void btnDocSach_Click(object sender, EventArgs e)
        {
            ReadFile();
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            AddBook();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DelBook();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            UpdateBook();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            SearchBook();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Bạn muốn đăng xuất ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Bạn có muốn thoát không ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void Cell_Click_QLbook(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvSach.SelectedCells[0].RowIndex;
            DataGridViewRow row = dgvSach.Rows[index];
            txtmasach.Text = Convert.ToString(row.Cells[0].Value);
            txttensach.Text = Convert.ToString(row.Cells[1].Value);
            txttacgia.Text = Convert.ToString(row.Cells[2].Value);
            txtsoluong.Text = Convert.ToString(row.Cells[3].Value);
            txttheloai.Text = Convert.ToString(row.Cells[4].Value);
            txtgiasach.Text = Convert.ToString(row.Cells[5].Value);
            txtnhasx.Text = Convert.ToString(row.Cells[6].Value);
            cbvitri.Text = Convert.ToString(row.Cells[7].Value);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin().Show();
        }

        private void tabQuanLiSach_Click(object sender, EventArgs e)
        {
             
        }

        private void QuanLiThuVien_Load(object sender, EventArgs e)
        {
            if (this.Text == "Admin") btnAdmin.Visible = true;
        }
        //------------------Quản lí độc giả--------------------------------------------------------------------------------------------------------------------
        private void ReadFileAuthor()
        {
            using var dbcontext = new Models.QLThuVienContext();
            var list_docgia = dbcontext.Docgia.ToList();
            if (list_docgia != null)
            {
                    dgvDocGia.Rows.Clear();
                    dgvDocGia.ColumnCount = 6;
                    int i = 0;
                    foreach(var docgia in list_docgia)
                    {
                        dgvDocGia.Rows.Add();
                        dgvDocGia.Rows[i].Cells[0].Value = docgia.Iddocgia;
                        dgvDocGia.Rows[i].Cells[1].Value = docgia.Hoten;
                        dgvDocGia.Rows[i].Cells[2].Value = docgia.Ngaysinh.Value;
                        dgvDocGia.Rows[i].Cells[3].Value = docgia.Diachi;
                        dgvDocGia.Rows[i].Cells[4].Value = docgia.Nghenghiep;
                        dgvDocGia.Rows[i].Cells[5].Value = docgia.Sodienthoai;
                        i++;
                    }
            }
            else
            {
                MessageBox.Show("Không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool isBoxDocGiaIsEmpty()
        {
            if (txtMaDocGia.Text.Equals("") || txtTenDocGia.Text.Equals("") || dateDocGia.Text.Equals("") || txtDiaChiDocGia.Text.Equals("") || txtNgheNhiep.Text.Equals("")||txtSDT_DocGia.Text.Equals(""))
            {
                return true;
            }
            return false;
        }
        private void AddAuthor()
        {
            if (isBoxDocGiaIsEmpty())
            {
                MessageBox.Show("Bạn đang để trống trường nhập dữ liệu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmasach.Focus();
            }
            else
            {
                using (var dbcontext = new Models.QLThuVienContext())
                {
                    try
                    {
                        Models.Docgium docgia = new Models.Docgium();
                        docgia.Iddocgia = txtMaDocGia.Text;
                        docgia.Hoten = txtTenDocGia.Text;
                        docgia.Ngaysinh =dateDocGia.Value;
                        docgia.Diachi = txtDiaChiDocGia.Text;
                        docgia.Nghenghiep = txtNgheNhiep.Text;
                        docgia.Sodienthoai = txtSDT_DocGia.Text;
                        dbcontext.Docgia.Add(docgia);
                        dbcontext.SaveChanges();
                        ReadFileAuthor();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Dữ liệu đầu vào bảng sai");
                    }

                }
            }
        }
        private void DelAuthor()
        {
            using var dbcontext = new Models.QLThuVienContext();
            //Models.Docgium id = dbcontext.Docgia.Where(d => d.Iddocgia == txtMaDocGia.Text).FirstOrDefault();
            //var idt = dbcontext.Thethuviens.Where(t => t.Iddocgia == txtMaDocGia.Text).ToList();
            //var idm = dbcontext.Muontrasaches.Where(m => m.Iddocgia == txtMaDocGia.Text).ToList();
            Models.Docgium id = (from d in dbcontext.Docgia where d.Iddocgia==txtMaDocGia.Text select d).FirstOrDefault();
            var idt = (from t in dbcontext.Thethuviens where t.Iddocgia==txtMaDocGia.Text select t).ToList();
            var idm = (from m in dbcontext.Muontrasaches where m.Iddocgia == txtMaDocGia.Text select m).ToList();
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn xoá không", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                if (id != null)
                {
                    if (idm != null)
                    {
                        dbcontext.Muontrasaches.RemoveRange(idm);
                    }
                    if (idt != null)
                    {
                        dbcontext.Thethuviens.RemoveRange(idt);
                    }
                    dbcontext.Docgia.Remove(id);
                    dbcontext.SaveChanges();
                    ReadFileAuthor();
                }
                else
                {
                    MessageBox.Show("Mã độc giả không tồn tại", "Thông báo");
                }
            }
        }
        private void UpdateAuthor()
        {
            using var dbcontext = new Models.QLThuVienContext();
            //Models.Docgium id = dbcontext.Docgia.Where(d => d.Iddocgia == txtMaDocGia.Text).FirstOrDefault();
            Models.Docgium id = (from d in dbcontext.Docgia where d.Iddocgia == txtMaDocGia.Text select d ).FirstOrDefault();
            if (id != null)
            {
                id.Hoten = txtTenDocGia.Text;
                id.Ngaysinh = dateDocGia.Value;
                id.Diachi = txtDiaChiDocGia.Text;
                id.Nghenghiep = txtNgheNhiep.Text;
                id.Sodienthoai = txtSDT_DocGia.Text;
                dbcontext.SaveChanges();
                ReadFileAuthor();
            }
            else
            {
                MessageBox.Show("Mã sách không tồn tại", "Thông báo");
            }
        }
        private void ClearAuthor()
        {
            txtMaDocGia.Clear();
            txtTenDocGia.Clear();
            txtDiaChiDocGia.Clear();
            txtNgheNhiep.Clear();
            txtSDT_DocGia.Clear();
        }
        private void SearchAuthor()
        {
            if (cbTimKiem.Text.Equals(""))
            {
                MessageBox.Show("Chưa chọn trường tìm kiếm (@_@)", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else if (cbTimKiem.SelectedIndex==0)
            {
                using var dbcontext = new Models.QLThuVienContext();
                //var list_docgia = dbcontext.Docgia.Where(d=>d.Iddocgia==txtMaDocGia.Text).ToList();
                var list_docgia = (from d in dbcontext.Docgia where d.Iddocgia==txtMaDocGia.Text select d).ToList();
                if (list_docgia != null)
                {
                    dgvDocGia.Rows.Clear();
                    dgvDocGia.ColumnCount = 6;
                    int i = 0;
                    foreach (var docgia in list_docgia)
                    {
                        dgvDocGia.Rows.Add();
                        dgvDocGia.Rows[i].Cells[0].Value = docgia.Iddocgia;
                        dgvDocGia.Rows[i].Cells[1].Value = docgia.Hoten;
                        dgvDocGia.Rows[i].Cells[2].Value = docgia.Ngaysinh.Value;
                        dgvDocGia.Rows[i].Cells[3].Value = docgia.Diachi;
                        dgvDocGia.Rows[i].Cells[4].Value = docgia.Nghenghiep;
                        dgvDocGia.Rows[i].Cells[5].Value = docgia.Sodienthoai;
                        i++;
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (cbTimKiem.SelectedIndex == 1)
            {
                using var dbcontext = new Models.QLThuVienContext();
                //var list_docgia = dbcontext.Docgia.Where(d => d.Hoten == txtTenDocGia.Text).ToList();
                var list_docgia = (from d in dbcontext.Docgia where d.Hoten == txtTenDocGia.Text select d).ToList();
                if (list_docgia != null)
                {
                    dgvDocGia.Rows.Clear();
                    dgvDocGia.ColumnCount = 6;
                    int i = 0;
                    foreach (var docgia in list_docgia)
                    {
                        dgvDocGia.Rows.Add();
                        dgvDocGia.Rows[i].Cells[0].Value = docgia.Iddocgia;
                        dgvDocGia.Rows[i].Cells[1].Value = docgia.Hoten;
                        dgvDocGia.Rows[i].Cells[2].Value = docgia.Ngaysinh.Value;
                        dgvDocGia.Rows[i].Cells[3].Value = docgia.Diachi;
                        dgvDocGia.Rows[i].Cells[4].Value = docgia.Nghenghiep;
                        dgvDocGia.Rows[i].Cells[5].Value = docgia.Sodienthoai;
                        i++;
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (cbTimKiem.SelectedIndex == 2)
            {
                using var dbcontext = new Models.QLThuVienContext();
                //var list_docgia = dbcontext.Docgia.Where(d =>d.Ngaysinh.Value.Date == dateDocGia.Value.Date).ToList();
                var list_docgia = (from d in dbcontext.Docgia where d.Ngaysinh.Value.Date == dateDocGia.Value.Date select d).ToList();
                if (list_docgia != null)
                {
                    dgvDocGia.Rows.Clear();
                    dgvDocGia.ColumnCount = 6;
                    int i = 0;
                    foreach (var docgia in list_docgia)
                    {
                        dgvDocGia.Rows.Add();
                        dgvDocGia.Rows[i].Cells[0].Value = docgia.Iddocgia;
                        dgvDocGia.Rows[i].Cells[1].Value = docgia.Hoten;
                        dgvDocGia.Rows[i].Cells[2].Value = docgia.Ngaysinh.Value;
                        dgvDocGia.Rows[i].Cells[3].Value = docgia.Diachi;
                        dgvDocGia.Rows[i].Cells[4].Value = docgia.Nghenghiep;
                        dgvDocGia.Rows[i].Cells[5].Value = docgia.Sodienthoai;
                        i++;
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (cbTimKiem.SelectedIndex == 3)
            {
                using var dbcontext = new Models.QLThuVienContext();
                //var list_docgia = dbcontext.Docgia.Where(d => d.Diachi == txtDiaChiDocGia.Text).ToList();
                var list_docgia = (from d in dbcontext.Docgia where d.Diachi == txtDiaChiDocGia.Text select d).ToList();
                if (list_docgia != null)
                {
                    dgvDocGia.Rows.Clear();
                    dgvDocGia.ColumnCount = 6;
                    int i = 0;
                    foreach (var docgia in list_docgia)
                    {
                        dgvDocGia.Rows.Add();
                        dgvDocGia.Rows[i].Cells[0].Value = docgia.Iddocgia;
                        dgvDocGia.Rows[i].Cells[1].Value = docgia.Hoten;
                        dgvDocGia.Rows[i].Cells[2].Value = docgia.Ngaysinh.Value;
                        dgvDocGia.Rows[i].Cells[3].Value = docgia.Diachi;
                        dgvDocGia.Rows[i].Cells[4].Value = docgia.Nghenghiep;
                        dgvDocGia.Rows[i].Cells[5].Value = docgia.Sodienthoai;
                        i++;
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (cbTimKiem.SelectedIndex == 4)
            {
                using var dbcontext = new Models.QLThuVienContext();
                //var list_docgia = dbcontext.Docgia.Where(d => d.Nghenghiep == txtNgheNhiep.Text).ToList();
                var list_docgia = (from d in dbcontext.Docgia where d.Nghenghiep == txtNgheNhiep.Text select d).ToList();
                if (list_docgia != null)
                {
                    dgvDocGia.Rows.Clear();
                    dgvDocGia.ColumnCount = 6;
                    int i = 0;
                    foreach (var docgia in list_docgia)
                    {
                        dgvDocGia.Rows.Add();
                        dgvDocGia.Rows[i].Cells[0].Value = docgia.Iddocgia;
                        dgvDocGia.Rows[i].Cells[1].Value = docgia.Hoten;
                        dgvDocGia.Rows[i].Cells[2].Value = docgia.Ngaysinh.Value;
                        dgvDocGia.Rows[i].Cells[3].Value = docgia.Diachi;
                        dgvDocGia.Rows[i].Cells[4].Value = docgia.Nghenghiep;
                        dgvDocGia.Rows[i].Cells[5].Value = docgia.Sodienthoai;
                        i++;
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (cbTimKiem.SelectedIndex == 5)
            {
                using var dbcontext = new Models.QLThuVienContext();
                //var list_docgia = dbcontext.Docgia.Where(d => d.Sodienthoai == txtSDT_DocGia.Text).ToList();
                var list_docgia = (from d in dbcontext.Docgia where d.Sodienthoai == txtSDT_DocGia.Text select d).ToList();
                if (list_docgia != null)
                {
                    dgvDocGia.Rows.Clear();
                    dgvDocGia.ColumnCount = 6;
                    int i = 0;
                    foreach (var docgia in list_docgia)
                    {
                        dgvDocGia.Rows.Add();
                        dgvDocGia.Rows[i].Cells[0].Value = docgia.Iddocgia;
                        dgvDocGia.Rows[i].Cells[1].Value = docgia.Hoten;
                        dgvDocGia.Rows[i].Cells[2].Value = docgia.Ngaysinh.Value;
                        dgvDocGia.Rows[i].Cells[3].Value = docgia.Diachi;
                        dgvDocGia.Rows[i].Cells[4].Value = docgia.Nghenghiep;
                        dgvDocGia.Rows[i].Cells[5].Value = docgia.Sodienthoai;
                        i++;
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btnReadDocGia_Click(object sender, EventArgs e)
        {
            ReadFileAuthor();
        }

        private void btnThemDocGia_Click(object sender, EventArgs e)
        {
            AddAuthor();
        }

        private void btnXoaDocGia_Click(object sender, EventArgs e)
        {
            DelAuthor();
        }

        private void btnSuaDocGia_Click(object sender, EventArgs e)
        {
            UpdateAuthor();
        }

        private void btnHuyDocGia_Click(object sender, EventArgs e)
        {
            ClearAuthor();
        }

        private void btnTimKiemDocGia_Click(object sender, EventArgs e)
        {
            SearchAuthor();
        }

        private void cell_click_author(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvDocGia.SelectedCells[0].RowIndex;
            DataGridViewRow row = dgvDocGia.Rows[index];
            txtMaDocGia.Text = Convert.ToString(row.Cells[0].Value);
            txtTenDocGia.Text = Convert.ToString(row.Cells[1].Value);
            dateDocGia.Value = Convert.ToDateTime(row.Cells[2].Value);
            txtDiaChiDocGia.Text = Convert.ToString(row.Cells[3].Value);
            txtNgheNhiep.Text = Convert.ToString(row.Cells[4].Value);
            txtSDT_DocGia.Text = Convert.ToString(row.Cells[5].Value);
        }



        //------------------Quản lý Mượn trả sách
        private void ReadFileQLMTSach()
        {
            ClearQLMTsach();
            loadIDdocgia(comboBoxMaDG);
            loadmasach(comboBoxMasach);
            dateNgaymuon.Value = DateTime.Now;
            dateNgayhentra.Value = DateTime.Now;
            dateNgaythuctra.Value = DateTime.Now;

            using var dbcontext = new Models.QLThuVienContext();
            var list_mt = from m in dbcontext.Muontrasaches
                          join s in dbcontext.Saches on m.Idsach equals s.Idsach
                          join dg in dbcontext.Docgia on m.Iddocgia equals dg.Iddocgia
                          select new
                          {
                              iddocgia = m.Iddocgia,
                              hoten = dg.Hoten,
                              masach = m.Idsach,
                              tensach = s.Tensach,
                              soluongmuon = m.Soluongmuon,
                              dongia = s.Giasach,
                              ngaymuon = m.Ngaymuon,
                              ngayhentra = m.Ngayhentra,
                              ngaythuctra = m.Ngaythuctra
                          };
            txtHotenMT.DataBindings.Clear();
            txtHotenMT.DataBindings.Add("Text", comboBoxMaDG.DataSource, "Hoten");
            txtTensachMT.DataBindings.Clear();
            txtTensachMT.DataBindings.Add("Text", comboBoxMasach.DataSource, "Tensach");


            if (list_mt != null)
            {

                dgvMTsach.Rows.Clear();
                dgvMTsach.ColumnCount = 9;
                int i = 0;
                foreach (var muontra in list_mt)
                {
                    dgvMTsach.Rows.Add();
                    dgvMTsach.Rows[i].Cells[0].Value = muontra.iddocgia;
                    dgvMTsach.Rows[i].Cells[1].Value = muontra.hoten;
                    dgvMTsach.Rows[i].Cells[2].Value = muontra.masach;
                    dgvMTsach.Rows[i].Cells[3].Value = muontra.tensach;
                    dgvMTsach.Rows[i].Cells[4].Value = muontra.soluongmuon;
                    dgvMTsach.Rows[i].Cells[5].Value = muontra.soluongmuon * muontra.dongia;
                    
                    dgvMTsach.Rows[i].Cells[6].Value = muontra.ngaymuon;
                    dgvMTsach.Rows[i].Cells[7].Value = muontra.ngayhentra;
                    dgvMTsach.Rows[i].Cells[8].Value = muontra.ngaythuctra;
                    i++;
                }
            }
            else
            {
                MessageBox.Show("Không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void loadIDdocgia(ComboBox cb)
        {
            using var dbcontext = new Models.QLThuVienContext();
            cb.DataSource = dbcontext.Docgia.ToList();
            cb.DisplayMember = "Iddocgia";

        }
        void loadmasach(ComboBox cb)
        {
            using var dbcontext = new Models.QLThuVienContext();
            cb.DataSource = dbcontext.Saches.ToList();
            cb.DisplayMember = "Idsach";

        }
        private void ClearQLMTsach()
        {

            if (rbMuonsach.Checked)
            {
                dateNgaythuctra.Visible = false;
                dateNgayhentra.Visible = true;
                dateNgaymuon.Visible = true;
                txtSLmuon.Enabled = true;
                lblNgaythuctra.Visible = false;
                lblNgaymuon.Visible = true;
                lblNgayhentra.Visible = true;
                dgvMTsach.Columns["dataGridViewTextBoxColumn11"].Visible = false;
            }else if (rbTrasach.Checked)
            {
                dateNgaythuctra.Visible = true;
                dateNgayhentra.Visible = false;
                dateNgaymuon.Visible = false;
                txtSLmuon.Enabled = false;
                lblNgaythuctra.Visible = true;
                lblNgaymuon.Visible = false;
                lblNgayhentra.Visible = false;
                dgvMTsach.Columns["dataGridViewTextBoxColumn11"].Visible = true;
            }
            
            comboBoxMaDG.Text = "d001";
            comboBoxMasach.Text= "s001";
            //txtTensachMT.Clear();
            //txtHotenMT.Clear();
            rbMTIDDG.Checked = false;
            rbMTMasach.Checked = false;
            rbMTNgaymuon.Checked = false;
            comboBoxMaDG.Enabled = true;
            comboBoxMasach.Enabled = true;
            dateMTtungay.Enabled = true;
            dateMTdenngay.Enabled = true;
            dateMTtungay.Value = DateTime.Now;
            dateMTdenngay.Value = DateTime.Now;
            //rbMuonsach.Checked = false;
            //rbTrasach.Checked = false;
            txtSLmuon.Text = "";
            dateNgaythuctra.Value = DateTime.Now;
            dateNgayhentra.Value = DateTime.Now;
            dateNgaymuon.Value = DateTime.Now;
           // dateNgaythuctra.Visible = true;
           // dateNgayhentra.Visible = true;
           // dateNgaymuon.Visible = true;
            //txtSLmuon.Enabled = true;
           // lblNgaythuctra.Visible = true;
           // lblNgaymuon.Visible = true;
           // lblNgayhentra.Visible = true;
           // dgvMTsach.Columns["dataGridViewTextBoxColumn11"].Visible = true;


        }

        private bool isBoxMTEmpty()
        {
            if (comboBoxMaDG.Text.Equals("") || comboBoxMasach.Text.Equals("") || txtSLmuon.Text.Equals(""))
            {
                return true;
            }
            return false;
        }
        private bool isRadioIsEmptyMT()
        {
            if (rbMuonsach.Checked == false && rbTrasach.Checked == false )
            {
                return true;
            }
            return false;
        }
        private void AddMT()
        {
            using var dbcontext = new Models.QLThuVienContext();
            var list_mt = from m in dbcontext.Muontrasaches
                          join s in dbcontext.Saches on m.Idsach equals s.Idsach
                          join dg in dbcontext.Docgia on m.Iddocgia equals dg.Iddocgia
                          where m.Iddocgia == comboBoxMaDG.Text && (m.Ngaythuctra >= DateTime.Now || m.Ngaythuctra == null)
                          select new
                          {
                              ngaymuon= m.Ngaymuon,
                              soluongmuon = m.Soluongmuon
                          };
            var sumsl = list_mt.Sum(s => s.soluongmuon);
           

            var ngaymuon = (from m in dbcontext.Muontrasaches
                          where m.Iddocgia == comboBoxMaDG.Text && m.Idsach==comboBoxMasach.Text
                          select m.Ngaymuon).FirstOrDefault();





            //MessageBox.Show(sumsl);
            if (isRadioIsEmptyMT())
            {
                MessageBox.Show("Bạn chưa chọn loại Mượn hoặc trả sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else if (rbMuonsach.Checked)
            {
                    if (isBoxMTEmpty())
                    {
                        MessageBox.Show("Bạn đang để trống trường nhập dữ liệu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxMaDG.Focus();
                    }
                    else if (dateNgayhentra.Value.Date <= dateNgaymuon.Value.Date )
                    {
                        MessageBox.Show("Ngày hẹn trả không được sớm hơn ngày mượn!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxMaDG.Focus();
                    }
                    else if ((int.Parse(sumsl.Value.ToString()) + int.Parse(txtSLmuon.Text)) >= 10)
                    {
                        MessageBox.Show("Khách hàng không thể mượn quá 10 quyển sách !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        using (dbcontext)
                        {
                            try
                            {
                            Models.Muontrasach mt = new Models.Muontrasach();
                            mt.Iddocgia = comboBoxMaDG.Text;
                            mt.Idsach = comboBoxMasach.Text;
                            mt.Soluongmuon = int.Parse(txtSLmuon.Text);
                            mt.Ngaymuon = dateNgaymuon.Value;
                            mt.Ngayhentra = dateNgayhentra.Value;
                            Models.Sach sach = (from s in dbcontext.Saches where s.Idsach == mt.Idsach select s).FirstOrDefault();
                            sach.Soluong = sach.Soluong - int.Parse(txtSLmuon.Text);
                            dbcontext.Muontrasaches.Add(mt);
                            dbcontext.SaveChanges();
                            ReadFileQLMTSach();

                        }
                            catch (Exception)
                            {
                                MessageBox.Show("Đã tồn tại dữ liệu trong bảng ");
                            }

                        }
                    }

            }
            else if (rbTrasach.Checked)
            {
                var slmuon = (from m in dbcontext.Muontrasaches
                                where m.Iddocgia == comboBoxMaDG.Text && m.Idsach == comboBoxMasach.Text
                                select m.Soluongmuon).FirstOrDefault();

                var ngaytra = (from m in dbcontext.Muontrasaches
                                where m.Iddocgia == comboBoxMaDG.Text && m.Idsach == comboBoxMasach.Text
                                select m.Ngaythuctra).FirstOrDefault();

                using (dbcontext)
                {
                    Models.Muontrasach mt = (from m in dbcontext.Muontrasaches where m.Iddocgia == comboBoxMaDG.Text && m.Idsach == comboBoxMasach.Text select m).FirstOrDefault();

                    if (mt == null)
                    {
                        MessageBox.Show("Không tồn tại dữ liệu này!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxMaDG.Focus();
                    }
                    else if (isBoxMTEmpty())
                    {
                        MessageBox.Show("Bạn đang để trống trường nhập dữ liệu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxMaDG.Focus();
                    }
                    else if ( Convert.ToString(ngaytra) != "")
                    {
                        MessageBox.Show("Dã thêm ngày trả sách không thể thêm nữa!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxMaDG.Focus();
                    }
                    else if (ngaymuon.Value.Date >= dateNgaythuctra.Value.Date)
                    {
                        MessageBox.Show("Ngày trả không được sớm hơn ngày mượn!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxMaDG.Focus();
                    }

                    else
                    {
                        
                             mt = (from m in dbcontext.Muontrasaches where m.Iddocgia == comboBoxMaDG.Text && m.Idsach == comboBoxMasach.Text select m).FirstOrDefault();
                            if (mt != null)
                            {
                                mt.Iddocgia = comboBoxMaDG.Text;
                                mt.Idsach = comboBoxMasach.Text;
                                Models.Sach sach = (from s in dbcontext.Saches where s.Idsach == mt.Idsach select s).FirstOrDefault();
                                sach.Soluong = sach.Soluong + int.Parse(txtSLmuon.Text);
                                mt.Ngaythuctra = dateNgaythuctra.Value;

                                dbcontext.SaveChanges();
                                ReadFileQLMTSach();
                            }
                        
                    }
                }

            }

        }
        private void DelMT()
        {
            using var dbcontext = new Models.QLThuVienContext();
            //Models.Muontrasach id = dbcontext.Muontrasaches.Where(mt => mt.Iddocgia == comboBoxMaDG.Text && mt.Idsach == comboBoxMasach.Text).FirstOrDefault();
            Models.Muontrasach id = (from mt in dbcontext.Muontrasaches where mt.Iddocgia == comboBoxMaDG.Text && mt.Idsach == comboBoxMasach.Text select mt).FirstOrDefault();
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn xoá không", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                if (id != null)
                {
                    dbcontext.Muontrasaches.Remove(id);
                    dbcontext.SaveChanges();
                    ReadFileQLMTSach();
                }
                else
                {
                    MessageBox.Show("Mã sách không tồn tại", "Thông báo");
                }
            }
        }
        private void UpdateMT()
        {
            using var dbcontext = new Models.QLThuVienContext();
            var list_mt = from m in dbcontext.Muontrasaches
                          join s in dbcontext.Saches on m.Idsach equals s.Idsach
                          join dg in dbcontext.Docgia on m.Iddocgia equals dg.Iddocgia
                          where m.Iddocgia == comboBoxMaDG.Text && (m.Ngaythuctra >= DateTime.Now || m.Ngaythuctra ==null)
                          select new
                          {
                              ngaymuon = m.Ngaymuon,
                              soluongmuon = m.Soluongmuon
                          };
            var sumsl = list_mt.Sum(s => s.soluongmuon);


            var ngaymuon = (from m in dbcontext.Muontrasaches
                            where m.Iddocgia == comboBoxMaDG.Text && m.Idsach == comboBoxMasach.Text
                            select m.Ngaymuon).FirstOrDefault();
          
            var slmuon = (from m in dbcontext.Muontrasaches
                          where m.Iddocgia == comboBoxMaDG.Text && m.Idsach == comboBoxMasach.Text
                          select m.Soluongmuon).FirstOrDefault();



            if (isRadioIsEmptyMT())
            {
                MessageBox.Show("Bạn chưa chọn loại Mượn hoặc trả sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (rbMuonsach.Checked)
            {

                if (isBoxMTEmpty())
                {
                    MessageBox.Show("Bạn đang để trống trường nhập dữ liệu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBoxMaDG.Focus();
                }
                else if (dateNgayhentra.Value.Date <= dateNgaymuon.Value.Date)
                {
                    MessageBox.Show("Ngày hẹn trả không được sớm hơn ngày mượn!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBoxMaDG.Focus();
                }
                else if ((sumsl + (int.Parse(txtSLmuon.Text)-slmuon)) >= 10)
                {
                    MessageBox.Show("Khách hàng không thể mượn quá 10 quyển sách !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    //Models.Muontrasach mt = dbcontext.Muontrasaches.Where(mt => mt.Iddocgia == comboBoxMaDG.Text && mt.Idsach == comboBoxMasach.Text).FirstOrDefault();
                    Models.Muontrasach mt = (from m in dbcontext.Muontrasaches where m.Iddocgia == comboBoxMaDG.Text && m.Idsach == comboBoxMasach.Text select m).FirstOrDefault();
                    if (mt != null)
                    {
                        mt.Iddocgia = comboBoxMaDG.Text;
                        mt.Idsach = comboBoxMasach.Text;
                        mt.Soluongmuon = int.Parse(txtSLmuon.Text);
                        mt.Ngaymuon = dateNgaymuon.Value;
                        mt.Ngayhentra = dateNgayhentra.Value;
          

                        dbcontext.SaveChanges();
                        ReadFileQLMTSach();
                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại", "Thông báo");
                    }
                }
            }
            else if (rbTrasach.Checked)
            {
                
                using (dbcontext)
                {
                    Models.Muontrasach mt = (from m in dbcontext.Muontrasaches where m.Iddocgia == comboBoxMaDG.Text && m.Idsach == comboBoxMasach.Text select m).FirstOrDefault();

                    if (mt == null)
                    {
                        MessageBox.Show("Không tồn tại dữ liệu này!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxMaDG.Focus();
                    }
                    else if(isBoxMTEmpty())
                    {
                        MessageBox.Show("Bạn đang để trống trường nhập dữ liệu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxMaDG.Focus();
                    }
                    else if (ngaymuon.Value.Date >= dateNgaythuctra.Value.Date)
                    {
                        MessageBox.Show("Ngày trả không được sớm hơn ngày mượn!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxMaDG.Focus();
                    }

                    else
                    {
                        
                            mt = (from m in dbcontext.Muontrasaches where m.Iddocgia == comboBoxMaDG.Text && m.Idsach == comboBoxMasach.Text select m).FirstOrDefault();
                            if (mt != null)
                            {
                                mt.Iddocgia = comboBoxMaDG.Text;
                                mt.Idsach = comboBoxMasach.Text;

                                mt.Ngaythuctra = dateNgaythuctra.Value;

                                dbcontext.SaveChanges();
                                ReadFileQLMTSach();
                            }
                            

                        
                    }
                }
            }

            }
        private bool isRadioIsEmptyTimkiem()
        {
            if (rbMTIDDG.Checked == false && rbMTMasach.Checked == false && rbMTNgaymuon.Checked == false)
            {
                return true;
            }
            return false;
        }
        private void SearchMT()
        {
            if (isRadioIsEmptyTimkiem())
            {
                MessageBox.Show("Bạn chưa chọn loại tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (rbMTIDDG.Checked)
            {

                /*
                //var list_mt = from mt in dbcontext.Muontrasaches.Where(mt => mt.Iddocgia == comboBoxMaDG.Text).ToList()
                //              join s in dbcontext.Saches on mt.Idsach equals s.Idsach
                //              join dg in dbcontext.Docgia on mt.Iddocgia equals dg.Iddocgia
                //              select new
                //              {
                //                  iddocgia = mt.Iddocgia,
                //                  hoten = dg.Hoten,
                //                  masach = mt.Idsach,
                //                  tensach = s.Tensach,
                //                  ngaymuon = mt.Ngaymuon,
                //                  ngayhentra = mt.Ngayhentra,
                //                  ngaythuctra = mt.Ngaythuctra
                //              };
                */

                using var dbcontext = new Models.QLThuVienContext();
                var list_mt = (from mt in dbcontext.Muontrasaches
                               where mt.Iddocgia == comboBoxMaDG.Text
                               join s in dbcontext.Saches on mt.Idsach equals s.Idsach
                               join dg in dbcontext.Docgia on mt.Iddocgia equals dg.Iddocgia
                               select new
                               {
                                   iddocgia = mt.Iddocgia,
                                   hoten = dg.Hoten,
                                   masach = mt.Idsach,
                                   tensach = s.Tensach,
                                   soluongmuon = mt.Soluongmuon,
                                   dongia = s.Giasach,
                                   ngaymuon = mt.Ngaymuon,
                                   ngayhentra = mt.Ngayhentra,
                                   ngaythuctra = mt.Ngaythuctra
                               }).ToList();

                if (list_mt != null)
                {
                    if (list_mt.Count() > 0)
                    {
                        dgvMTsach.Rows.Clear();
                        dgvMTsach.ColumnCount = 9;
                        int i = 0;
                        foreach (var muontra in list_mt)
                        {
                            dgvMTsach.Rows.Add();
                            dgvMTsach.Rows[i].Cells[0].Value = muontra.iddocgia;
                            dgvMTsach.Rows[i].Cells[1].Value = muontra.hoten;
                            dgvMTsach.Rows[i].Cells[2].Value = muontra.masach;
                            dgvMTsach.Rows[i].Cells[3].Value = muontra.tensach;
                            dgvMTsach.Rows[i].Cells[4].Value = muontra.soluongmuon;
                            dgvMTsach.Rows[i].Cells[5].Value = muontra.soluongmuon * muontra.dongia;
                            dgvMTsach.Rows[i].Cells[6].Value = muontra.ngaymuon;
                            dgvMTsach.Rows[i].Cells[7].Value = muontra.ngayhentra;
                            dgvMTsach.Rows[i].Cells[8].Value = muontra.ngaythuctra;
                            i++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại dữ liệu tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (rbMTMasach.Checked)
            {


                using var dbcontext = new Models.QLThuVienContext();
                var list_mt = (from mt in dbcontext.Muontrasaches
                               where mt.Idsach == comboBoxMasach.Text
                               join s in dbcontext.Saches on mt.Idsach equals s.Idsach
                               join dg in dbcontext.Docgia on mt.Iddocgia equals dg.Iddocgia
                               select new
                               {
                                   iddocgia = mt.Iddocgia,
                                   hoten = dg.Hoten,
                                   masach = mt.Idsach,
                                   tensach = s.Tensach,
                                   ngaymuon = mt.Ngaymuon,
                                   ngayhentra = mt.Ngayhentra,
                                   ngaythuctra = mt.Ngaythuctra
                               }).ToList();

                if (list_mt != null)
                {
                    if (list_mt.Count() > 0)
                    {
                        dgvMTsach.Rows.Clear();
                        dgvMTsach.ColumnCount = 7;
                        int i = 0;
                        foreach (var muontra in list_mt)
                        {
                            dgvMTsach.Rows.Add();
                            dgvMTsach.Rows[i].Cells[0].Value = muontra.iddocgia;
                            dgvMTsach.Rows[i].Cells[1].Value = muontra.hoten;
                            dgvMTsach.Rows[i].Cells[2].Value = muontra.masach;
                            dgvMTsach.Rows[i].Cells[3].Value = muontra.tensach;
                            dgvMTsach.Rows[i].Cells[4].Value = muontra.ngaymuon;
                            dgvMTsach.Rows[i].Cells[5].Value = muontra.ngayhentra;
                            dgvMTsach.Rows[i].Cells[6].Value = muontra.ngaythuctra;
                            i++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại dữ liệu tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (rbMTNgaymuon.Checked)
            {


                using var dbcontext = new Models.QLThuVienContext();
                var list_mt = (from mt in dbcontext.Muontrasaches
                               where mt.Ngaymuon >= dateMTtungay.Value && mt.Ngaymuon <= dateMTdenngay.Value
                               join s in dbcontext.Saches on mt.Idsach equals s.Idsach
                               join dg in dbcontext.Docgia on mt.Iddocgia equals dg.Iddocgia
                               select new
                               {
                                   iddocgia = mt.Iddocgia,
                                   hoten = dg.Hoten,
                                   masach = mt.Idsach,
                                   tensach = s.Tensach,
                                   ngaymuon = mt.Ngaymuon,
                                   ngayhentra = mt.Ngayhentra,
                                   ngaythuctra = mt.Ngaythuctra
                               }).ToList();

                if (list_mt != null)
                {
                    if (list_mt.Count() > 0)
                    {
                        dgvMTsach.Rows.Clear();
                        dgvMTsach.ColumnCount = 7;
                        int i = 0;
                        foreach (var muontra in list_mt)
                        {
                            dgvMTsach.Rows.Add();
                            dgvMTsach.Rows[i].Cells[0].Value = muontra.iddocgia;
                            dgvMTsach.Rows[i].Cells[1].Value = muontra.hoten;
                            dgvMTsach.Rows[i].Cells[2].Value = muontra.masach;
                            dgvMTsach.Rows[i].Cells[3].Value = muontra.tensach;
                            dgvMTsach.Rows[i].Cells[4].Value = muontra.ngaymuon;
                            dgvMTsach.Rows[i].Cells[5].Value = muontra.ngayhentra;
                            dgvMTsach.Rows[i].Cells[6].Value = muontra.ngaythuctra;
                            i++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại dữ liệu tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void CellClick_MTSach(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvMTsach.SelectedCells[0].RowIndex;
            DataGridViewRow row = dgvMTsach.Rows[index];
            comboBoxMaDG.Text = Convert.ToString(row.Cells[0].Value);
            txtHotenMT.Text = Convert.ToString(row.Cells[1].Value);
            comboBoxMasach.Text = Convert.ToString(row.Cells[2].Value);
            txtTensachMT.Text = Convert.ToString(row.Cells[3].Value);
            txtSLmuon.Text = Convert.ToString(row.Cells[4].Value);
            dateNgaymuon.Value = Convert.ToDateTime(row.Cells[6].Value);
            dateNgayhentra.Value = Convert.ToDateTime(row.Cells[7].Value);
            if(Convert.ToString(row.Cells[8].Value) == "" )
            {
                dateNgaythuctra.Value = DateTime.Now;
            }
            else
            {
                dateNgaythuctra.Value = Convert.ToDateTime(row.Cells[8].Value);
            }
        }

        public void MDG_checkedChanged(object sender, EventArgs e)
        {
            comboBoxMasach.Enabled = !rbMTIDDG.Checked;
            dateMTtungay.Enabled = !rbMTIDDG.Checked;
            dateMTdenngay.Enabled = !rbMTIDDG.Checked;
        }

        private void MS_Changed(object sender, EventArgs e)
        {
            comboBoxMaDG.Enabled = !rbMTMasach.Checked;
            dateMTtungay.Enabled = !rbMTMasach.Checked;
            dateMTdenngay.Enabled = !rbMTMasach.Checked;
        }

        private void NgayMuon_changed(object sender, EventArgs e)
        {
            comboBoxMasach.Enabled = !rbMTNgaymuon.Checked;
            comboBoxMaDG.Enabled = !rbMTNgaymuon.Checked;
        }

        private void btnLoadMTsach_Click(object sender, EventArgs e)
        {
            ReadFileQLMTSach();
        }

        private void btnThemMTsach_Click(object sender, EventArgs e)
        {
            AddMT();
        }

        private void btnXoaMTsach_Click(object sender, EventArgs e)
        {
            DelMT();
        }

        private void btnSuaMTsach_Click(object sender, EventArgs e)
        {
            UpdateMT();
        }

        private void btnHuyMTsach_Click(object sender, EventArgs e)
        {
            ClearQLMTsach();
        }

        private void btnTimMTsach_Click(object sender, EventArgs e)
        {
            SearchMT();
        }


        //------------------Thống kê Quá Hạn 
        private void ReadFileTKQH()
        {
            // using var dbcontext = new Models.QLThuVienContext();
            //var list_tkqh = from m in dbcontext.Muontrasaches.Where(m => m.Ngayhentra.Value.Date < m.Ngaythuctra.Value.Date).ToList()
            //                join s in dbcontext.Saches on m.Idsach equals s.Idsach
            //                join dg in dbcontext.Docgia on m.Iddocgia equals dg.Iddocgia
            //                select new
            //                {
            //                    iddocgia = m.Iddocgia,
            //                    hoten = dg.Hoten,
            //                    masach = m.Idsach,
            //                    tensach = s.Tensach,
            //                    ngaymuon = m.Ngaymuon,
            //                    ngayhentra = m.Ngayhentra,
            //                    ngaythuctra = m.Ngaythuctra
            //                };
            using var dbcontext = new Models.QLThuVienContext();
            var list_tkqh = (from m in dbcontext.Muontrasaches
                             where m.Ngayhentra.Value.Date < m.Ngaythuctra.Value.Date
                             join s in dbcontext.Saches on m.Idsach equals s.Idsach
                             join dg in dbcontext.Docgia on m.Iddocgia equals dg.Iddocgia
                             select new
                             {
                                 iddocgia = m.Iddocgia,
                                 hoten = dg.Hoten,
                                 masach = m.Idsach,
                                 tensach = s.Tensach,
                                 ngaymuon = m.Ngaymuon,
                                 ngayhentra = m.Ngayhentra,
                                 ngaythuctra = m.Ngaythuctra
                             }).ToList();



            if (list_tkqh != null)
            {
                dgvTKQH.Rows.Clear();
                dgvTKQH.ColumnCount = 7;
                int i = 0;
                foreach (var quahan in list_tkqh)
                {
                    dgvTKQH.Rows.Add();
                    dgvTKQH.Rows[i].Cells[0].Value = quahan.iddocgia;
                    dgvTKQH.Rows[i].Cells[1].Value = quahan.hoten;
                    dgvTKQH.Rows[i].Cells[2].Value = quahan.masach;
                    dgvTKQH.Rows[i].Cells[3].Value = quahan.tensach;
                    dgvTKQH.Rows[i].Cells[4].Value = quahan.ngaymuon;
                    dgvTKQH.Rows[i].Cells[5].Value = quahan.ngayhentra;
                    dgvTKQH.Rows[i].Cells[6].Value = quahan.ngaythuctra;
                    i++;
                }
            }
            else
            {
                MessageBox.Show("Không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCapnhatQH_Click(object sender, EventArgs e)
        {
            ReadFileTKQH();
        }

        private void rbMuonsach_CheckedChanged(object sender, EventArgs e)
        {
            dateNgaythuctra.Visible = false;
            dateNgayhentra.Visible = true;
            dateNgaymuon.Visible = true;
            txtSLmuon.Enabled = true;
            lblNgaythuctra.Visible = false;
            lblNgaymuon.Visible = true;
            lblNgayhentra.Visible = true;
            dgvMTsach.Columns["dataGridViewTextBoxColumn11"].Visible = false;


        }

        private void rbTrasach_CheckedChanged(object sender, EventArgs e)
        {
            dateNgaythuctra.Visible = true;
            dateNgayhentra.Visible = false;
            dateNgaymuon.Visible = false;
            txtSLmuon.Enabled = false;
            lblNgaythuctra.Visible = true;
            lblNgaymuon.Visible = false;
            lblNgayhentra.Visible = false;
            dgvMTsach.Columns["dataGridViewTextBoxColumn11"].Visible = true;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxMaDG_SelectedValueChanged(object sender, EventArgs e)
        {
            Models.QLThuVienContext dbcontext = new Models.QLThuVienContext();
            if (rbTrasach.Checked)
            {
                var mts = dbcontext.Muontrasaches.Where(s => (s.Iddocgia == comboBoxMaDG.Text && s.Idsach == comboBoxMasach.Text)).FirstOrDefault();
                if (mts!= null) {
                    txtSLmuon.Text = mts.Soluongmuon.Value.ToString();
                }
                else
                {
                    txtSLmuon.Text = "";
                }
                    
               
            }
        }

        private void txtSLmuon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
