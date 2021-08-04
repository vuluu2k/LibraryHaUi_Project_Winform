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
        #region Common
        Models.QLThuVienContext dbcontext = new Models.QLThuVienContext();
        int index=0;
        String laster_hd;
        private void RefeshInforHD()
        {
            cbTimKiemMaHD.DataSource = dbcontext.HoaDons.ToList();
            cbTimKiemMaHD.DisplayMember = "MaHD";
            cbTimKiemMaHD.ValueMember = "MaHD";
        }
        #endregion
        public QuanLiThuVien()
        {

            InitializeComponent();
        }
        private void QuanLiThuVien_Load(object sender, EventArgs e)
        {
            if (this.Text == "Admin") btnAdmin.Visible = true;

            cbMaDG.DataSource = dbcontext.Docgia.ToList();
            cbMaDG.DisplayMember = "Iddocgia";
            cbMaDG.ValueMember = "Iddocgia";
            cbMaSach_lhd.DataSource = dbcontext.Saches.ToList();
            cbMaSach_lhd.DisplayMember = "Tensach";
            cbMaSach_lhd.ValueMember = "Idsach";
            RefeshInforHD();
        }
        private void rdvitri_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchBook.Visible = false;
            cbSeachBook.Visible = true;
        }

        private void rdmasach_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchBook.Visible = true;
            cbSeachBook.Visible = false;
        }
        private void QuanLiThuVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
        #region Admin, Logout, Exists
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

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin().Show();
        }
        #endregion
        #region Xư lý lỗi quản lí sách
        private void txtmasach_Validated(object sender, EventArgs e)
        {
            GetError.SetError(txtmasach, "");
        }

        private void txttensach_Validated(object sender, EventArgs e)
        {
            GetError.SetError(txttensach, "");
        }

        private void txttacgia_Validated(object sender, EventArgs e)
        {
            GetError.SetError(txttacgia, "");
        }

        private void txtsoluong_Validated(object sender, EventArgs e)
        {
            GetError.SetError(txtsoluong, "");
        }

        private void txttheloai_Validated(object sender, EventArgs e)
        {
            GetError.SetError(txttheloai, "");
        }

        private void txtgiasach_Validated(object sender, EventArgs e)
        {
            GetError.SetError(txtgiasach, "");
        }

        private void txtnhasx_Validated(object sender, EventArgs e)
        {
            GetError.SetError(txtnhasx, "");
        }

        private void cbvitri_Validated(object sender, EventArgs e)
        {
            GetError.SetError(cbvitri, "");
        }
        private bool Validate_ManageBook()
        {
            if (txtmasach.Text == "")
            {
                GetError.SetError(txtmasach, "Bạn phải nhập mã sách!");
                txtmasach.Focus();
                return false;
            }
            if (txttensach.Text == "")
            {
                GetError.SetError(txttensach, "Bạn phải nhập tên sách!");
                txttensach.Focus();
                return false;
            }
            if (txttacgia.Text == "")
            {
                GetError.SetError(txttacgia, "Bạn phải nhập tác giả!");
                txttacgia.Focus();
                return false;
            }
            if (txtsoluong.Text == "")
            {
                GetError.SetError(txtsoluong, "Bạn phải nhập số lượng!");
                txtsoluong.Focus();
                return false;
            }
            else
            {
                try
                {
                    int.Parse(txtsoluong.Text);
                    if (int.Parse(txtsoluong.Text) < 0)
                    {
                        GetError.SetError(txtsoluong, "Bạn phải nhập số lượng >0!");
                        txtsoluong.Focus();
                        txtsoluong.SelectAll();
                        return false;
                    }
                }
                catch (Exception)
                {
                    GetError.SetError(txtsoluong, "Bạn phải nhập số lượng là số nguyên!");
                    txtsoluong.Focus();
                    txtsoluong.SelectAll();
                    return false;
                }
            }
            if (txttheloai.Text == "")
            {
                GetError.SetError(txttheloai, "Bạn phải nhập thể loại!");
                txttheloai.Focus();
                return false;
            }
            if (txtgiasach.Text == "")
            {
                GetError.SetError(txtgiasach, "Bạn phải nhập giá sách!");
                txtgiasach.Focus();
                return false;
            }
            else
            {
                try
                {
                    double.Parse(txtgiasach.Text);
                    if (double.Parse(txtgiasach.Text) < 0)
                    {
                        GetError.SetError(txtgiasach, "Bạn phải nhập giá sách >0!");
                        txtgiasach.Focus();
                        txtgiasach.SelectAll();
                        return false;
                    }
                }
                catch (Exception)
                {
                    GetError.SetError(txtgiasach, "Bạn phải nhập giá sách là số thực!");
                    txtgiasach.Focus();
                    txtgiasach.SelectAll();
                    return false;
                }
            }
            if (txtnhasx.Text == "")
            {
                GetError.SetError(txtnhasx, "Bạn phải nhập nhà sản xuất!");
                txtnhasx.Focus();
                return false;
            }
            if (cbvitri.Text == "")
            {
                GetError.SetError(cbvitri, "Bạn phải chọn vị trí!");
                cbvitri.Focus();
                return false;
            }
            return true;
        }
        private bool isRadioIsEmpty()
        {
            if (rdmasach.Checked == false && rdtensach.Checked == false && rdtacgia.Checked == false && rdtheloai.Checked == false && rdnxb.Checked == false && rdvitri.Checked == false)
            {
                return true;
            }
            return false;
        }
        #endregion
        #region Xử lý lỗi quản lí độc giả
        private void txtMaDocGia_Validated(object sender, EventArgs e)
        {
            GetError.SetError(txtMaDocGia, "");
        }

        private void txtTenDocGia_Validated(object sender, EventArgs e)
        {
            GetError.SetError(txtTenDocGia, "");
        }

        private void dateDocGia_Validated(object sender, EventArgs e)
        {
            GetError.SetError(dateDocGia, "");
        }

        private void txtDiaChiDocGia_Validated(object sender, EventArgs e)
        {
            GetError.SetError(txtDiaChiDocGia, "");
        }

        private void txtNgheNhiep_Validated(object sender, EventArgs e)
        {
            GetError.SetError(txtNgheNhiep, "");
        }

        private void txtSDT_DocGia_Validated(object sender, EventArgs e)
        {
            GetError.SetError(txtSDT_DocGia, "");
        }
        #endregion
        #region Quản lí sách
        //----------------------------Quản lý sách-------------------------------------------------------------------------------------------------------------
        private void ReadFile()
        {
            //using var dbcontext = new Models.QLThuVienContext();
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
        private void AddBook()
        {
            if (Validate_ManageBook())
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
        private void DelBook()
        {
            //using var dbcontext = new Models.QLThuVienContext();
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
                    MessageBox.Show("Mã sách không tồn tại", "Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }
        private void UpdateBook()
        {
            //using var dbcontext = new Models.QLThuVienContext();
            //Models.Sach sach = dbcontext.Saches.Where(sach => sach.Idsach == txtmasach.Text).FirstOrDefault();
            if (Validate_ManageBook())
            {
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
                    MessageBox.Show("Mã sách không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                //using var dbcontext = new Models.QLThuVienContext();
                //var list_sach = dbcontext.Saches.Where(book=>book.Idsach==txtmasach.Text).ToList();
                var list_sach = (from book in dbcontext.Saches where book.Idsach == txtSearchBook.Text select book).ToList();
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
                //using var dbcontext = new Models.QLThuVienContext();
                //var list_sach = dbcontext.Saches.Where(book => book.Tensach == txttensach.Text).ToList();
                var list_sach = (from book in dbcontext.Saches where book.Tensach == txtSearchBook.Text select book).ToList();
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
                //using var dbcontext = new Models.QLThuVienContext();
                //var list_sach = dbcontext.Saches.Where(book => book.Tacgia == txttacgia.Text).ToList();
                var list_sach = (from book in dbcontext.Saches where book.Tacgia == txtSearchBook.Text select book).ToList();
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
                //using var dbcontext = new Models.QLThuVienContext();
                //var list_sach = dbcontext.Saches.Where(book => book.Theloai == txttheloai.Text).ToList();
                var list_sach = (from book in dbcontext.Saches where book.Theloai == txtSearchBook.Text select book).ToList();
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
                //using var dbcontext = new Models.QLThuVienContext();
                //var list_sach = dbcontext.Saches.Where(book => book.Nhaxuatban == txtnhasx.Text).ToList();
                var list_sach = (from book in dbcontext.Saches where book.Nhaxuatban == txtSearchBook.Text select book).ToList();
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
                //using var dbcontext = new Models.QLThuVienContext();
                //var list_sach = dbcontext.Saches.Where(book => book.Vitri == cbvitri.Text).ToList();
                var list_sach = (from book in dbcontext.Saches where book.Vitri == cbSeachBook.Text select book).ToList();
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
        #endregion
        #region Quản lí độc giả
        //------------------Quản lí độc giả--------------------------------------------------------------------------------------------------------------------
        private void ReadFileAuthor()
        {
            //using var dbcontext = new Models.QLThuVienContext();
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
                        dgvDocGia.Rows[i].Cells[2].Value = docgia.NgaySinh.Value;
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
                //using (var dbcontext = new Models.QLThuVienContext())
                //{
                    try
                    {
                        Models.Docgium docgia = new Models.Docgium();
                        docgia.Iddocgia = txtMaDocGia.Text;
                        docgia.Hoten = txtTenDocGia.Text;
                        docgia.NgaySinh =dateDocGia.Value;
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

                //}
            }
        }
        private void DelAuthor()
        {
            //using var dbcontext = new Models.QLThuVienContext();
            //Models.Docgium id = dbcontext.Docgia.Where(d => d.Iddocgia == txtMaDocGia.Text).FirstOrDefault();
            //var idt = dbcontext.Thethuviens.Where(t => t.Iddocgia == txtMaDocGia.Text).ToList();
            //var idm = dbcontext.Muontrasaches.Where(m => m.Iddocgia == txtMaDocGia.Text).ToList();
            Models.Docgium id = (from d in dbcontext.Docgia where d.Iddocgia==txtMaDocGia.Text select d).FirstOrDefault();
            //var idt = (from t in dbcontext.Thethuviens where t.Iddocgia==txtMaDocGia.Text select t).ToList();
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
                    //if (idt != null)
                    //{
                    //    dbcontext.Thethuviens.RemoveRange(idt);
                    //}
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
            //using var dbcontext = new Models.QLThuVienContext();
            //Models.Docgium id = dbcontext.Docgia.Where(d => d.Iddocgia == txtMaDocGia.Text).FirstOrDefault();
            Models.Docgium id = (from d in dbcontext.Docgia where d.Iddocgia == txtMaDocGia.Text select d ).FirstOrDefault();
            if (id != null)
            {
                id.Hoten = txtTenDocGia.Text;
                id.NgaySinh = dateDocGia.Value;
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
                //using var dbcontext = new Models.QLThuVienContext();
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
                        dgvDocGia.Rows[i].Cells[2].Value = docgia.NgaySinh.Value;
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
                //using var dbcontext = new Models.QLThuVienContext();
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
                        dgvDocGia.Rows[i].Cells[2].Value = docgia.NgaySinh.Value;
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
                //using var dbcontext = new Models.QLThuVienContext();
                //var list_docgia = dbcontext.Docgia.Where(d =>d.Ngaysinh.Value.Date == dateDocGia.Value.Date).ToList();
                var list_docgia = (from d in dbcontext.Docgia where d.NgaySinh.Value.Date == dateDocGia.Value.Date select d).ToList();
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
                        dgvDocGia.Rows[i].Cells[2].Value = docgia.NgaySinh.Value;
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
                //using var dbcontext = new Models.QLThuVienContext();
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
                        dgvDocGia.Rows[i].Cells[2].Value = docgia.NgaySinh.Value;
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
                //using var dbcontext = new Models.QLThuVienContext();
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
                        dgvDocGia.Rows[i].Cells[2].Value = docgia.NgaySinh.Value;
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
                //using var dbcontext = new Models.QLThuVienContext();
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
                        dgvDocGia.Rows[i].Cells[2].Value = docgia.NgaySinh.Value;
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
        #endregion
        #region Quản lí bán sách
        #region Quản lí bán sách>Lập hoá đơn
        // Lập hoá đơn
        private void AddBookBuy()
        {
            Models.Sach book = (from b in dbcontext.Saches where b.Idsach == cbMaSach_lhd.SelectedValue.ToString() select b).FirstOrDefault();
            if (book != null)
            {
                dgvLHD.ColumnCount = 5;
                dgvLHD.Rows.Add();
                dgvLHD.Rows[index].Cells[0].Value = book.Idsach;
                dgvLHD.Rows[index].Cells[1].Value = book.Tensach;
                dgvLHD.Rows[index].Cells[2].Value = txtsoluongmua_lhd.Text;
                dgvLHD.Rows[index].Cells[3].Value = book.Giasach;
                dgvLHD.Rows[index].Cells[4].Value = int.Parse(txtsoluongmua_lhd.Text) * book.Giasach;
                //MessageBox.Show(Convert.ToString(dgvLHD.Rows[index].Cells[0].Value));
                index++;
                cbMaSach_lhd.Text = "";
                txtsoluongmua_lhd.Clear();
                cbMaSach_lhd.Focus();
                //MessageBox.Show(dgvLHD.RowCount.ToString());
            }
            else
            {
                MessageBox.Show("Không có mã sản sách này", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbMaSach_lhd.Text = "";
                cbMaSach_lhd.Focus();
            }
        }
        private void dgvLHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index_lhd = dgvLHD.SelectedCells[0].RowIndex;
            DataGridViewRow row = dgvLHD.Rows[index_lhd];
            cbMaSach_lhd.Text = Convert.ToString(row.Cells[1].Value);
            txtsoluongmua_lhd.Text = Convert.ToString(row.Cells[2].Value);
            //Cell_Click_LHD = index_lhd;
        }
        private void UpdateBookBuy()
        {
            Models.Sach book = (from b in dbcontext.Saches where b.Idsach == cbMaSach_lhd.SelectedValue.ToString() select b).FirstOrDefault();
            if (book != null)
            {
                dgvLHD.ColumnCount = 5;
                dgvLHD.Rows[dgvLHD.SelectedCells[0].RowIndex].Cells[0].Value = book.Idsach;
                dgvLHD.Rows[dgvLHD.SelectedCells[0].RowIndex].Cells[1].Value = book.Tensach;
                dgvLHD.Rows[dgvLHD.SelectedCells[0].RowIndex].Cells[2].Value = txtsoluongmua_lhd.Text;
                dgvLHD.Rows[dgvLHD.SelectedCells[0].RowIndex].Cells[3].Value = book.Giasach;
                dgvLHD.Rows[dgvLHD.SelectedCells[0].RowIndex].Cells[4].Value = int.Parse(txtsoluongmua_lhd.Text) * book.Giasach;
                //MessageBox.Show(Convert.ToString(dgvLHD.Rows[index].Cells[0].Value));
                //cbMaSach_lhd.Text = "";
                //txtsoluongmua_lhd.Clear();
                //cbMaSach_lhd.Focus();
                //MessageBox.Show(dgvLHD.RowCount.ToString());
            }
            else
            {
                MessageBox.Show("Không có mã sản sách này", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbMaSach_lhd.Text = "";
                cbMaSach_lhd.Focus();
            }
        }
        private void DelBookBuy()
        {
            dgvLHD.Rows.RemoveAt(dgvLHD.SelectedCells[0].RowIndex);
        }
       
        private void CreateBill()
        {
            Models.HoaDon hd = new Models.HoaDon();
            hd.MaHd = txtMaHD.Text;
            hd.Iddocgia = cbMaDG.SelectedValue.ToString();
            hd.NguoiLap = "Lưu Công Quang Vũ";
            hd.NgayLap = dtimeNgayLap.Value;
            dbcontext.HoaDons.Add(hd);
            for (int i = 0; i < dgvLHD.RowCount-1; i++)
            {
                //MessageBox.Show(Convert.ToString(dgvLHD.Rows[i].Cells[0].Value));
                Models.HoaDonChiTiet hdct = new Models.HoaDonChiTiet();
                hdct.MaHd = hd.MaHd;
                hdct.Idsach = Convert.ToString(dgvLHD.Rows[i].Cells[0].Value);
                hdct.SoLuongMua = Convert.ToInt32(dgvLHD.Rows[i].Cells[2].Value);
                dbcontext.HoaDonChiTiets.Add(hdct);
            }
            dbcontext.SaveChanges();
            MessageBox.Show("Lập hoá đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            laster_hd = txtMaHD.Text;
        }
        
        private void btnThemSachMua_Click(object sender, EventArgs e)
        {
            AddBookBuy();
        }
        private void btnSuaSachMua_Click(object sender, EventArgs e)
        {
            UpdateBookBuy();
        }
        private void btnXoaSachMua_Click(object sender, EventArgs e)
        {
            DelBookBuy();
        }
        private void btnLapHD_Click(object sender, EventArgs e)
        {
            CreateBill();
        }


        #endregion
        #region Quản lí bán sách>Thông tin hoá đơn độc giả
        private void btnFirstHD_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(laster_hd);
            Models.HoaDon hd = (from h in dbcontext.HoaDons where h.MaHd == laster_hd select h).FirstOrDefault();
            var hdct = (from hct in dbcontext.HoaDonChiTiets where hct.MaHd == laster_hd select hct).ToList();
            Models.Docgium dg = (from d in dbcontext.Docgia where d.Iddocgia == hd.Iddocgia select d).FirstOrDefault();
            lbInforMaHD.Text = hd.MaHd;
            lbInforMaDG.Text = hd.Iddocgia;
            lbInforNLap.Text = hd.NguoiLap;
            lbNgayLap.Text = hd.NgayLap.ToString();
            lbInforTenDG.Text = dg.Hoten;
            dgvInforHD.Rows.Clear();
            dgvInforHD.ColumnCount = 5;
            int index_inforHD = 0;
            double SumMoney = 0;
            foreach(var item in hdct)
            {
                Models.Sach book = (from b in dbcontext.Saches where b.Idsach == item.Idsach select b).FirstOrDefault();
                dgvInforHD.Rows.Add();
                dgvInforHD.Rows[index_inforHD].Cells[0].Value = item.Idsach;
                dgvInforHD.Rows[index_inforHD].Cells[1].Value = book.Tensach;
                dgvInforHD.Rows[index_inforHD].Cells[2].Value = item.SoLuongMua;
                dgvInforHD.Rows[index_inforHD].Cells[3].Value = book.Giasach;
                dgvInforHD.Rows[index_inforHD].Cells[4].Value = item.SoLuongMua * book.Giasach;
                SumMoney += item.SoLuongMua.Value*book.Giasach.Value;
                index_inforHD++;
            }
            lbTongTien.Text = SumMoney.ToString();
        }
        private void btnInforXoa_Click(object sender, EventArgs e)
        {
            Models.HoaDon hd = (from h in dbcontext.HoaDons where h.MaHd == lbInforMaHD.Text select h).FirstOrDefault();
            var hdct = (from hct in dbcontext.HoaDonChiTiets where hct.MaHd == lbInforMaHD.Text select hct).ToList();
            if (hd != null)
            {
                if (hdct != null)
                {
                    dbcontext.RemoveRange(hdct);
                }
                dbcontext.Remove(hd);
                dbcontext.SaveChanges();
                lbInforMaHD.Text = "";
                lbInforMaDG.Text = "";
                lbInforNLap.Text = "";
                lbInforTenDG.Text = "";
                lbNgayLap.Text = "";
                lbTongTien.Text = "0";
                dgvInforHD.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Không có mã hoá đơn này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);//not working because it always get id
            }
        }
        private void btnRefeshInforHD_Click(object sender, EventArgs e)
        {
            RefeshInforHD();
        }
        private void btnTimKiem_InforHD_Click(object sender, EventArgs e)
        {
            Models.HoaDon hd = (from h in dbcontext.HoaDons where h.MaHd == cbTimKiemMaHD.Text select h).FirstOrDefault();
            var hdct = (from hct in dbcontext.HoaDonChiTiets where hct.MaHd == cbTimKiemMaHD.Text select hct).ToList();
            Models.Docgium dg = (from d in dbcontext.Docgia where d.Iddocgia == hd.Iddocgia select d).FirstOrDefault();
            lbInforMaHD.Text = hd.MaHd;
            lbInforMaDG.Text = hd.Iddocgia;
            lbInforNLap.Text = hd.NguoiLap;
            lbNgayLap.Text = hd.NgayLap.ToString();
            lbInforTenDG.Text = dg.Hoten;
            dgvInforHD.Rows.Clear();
            dgvInforHD.ColumnCount = 5;
            int index_inforHD = 0;
            double SumMoney = 0;
            foreach (var item in hdct)
            {
                Models.Sach book = (from b in dbcontext.Saches where b.Idsach == item.Idsach select b).FirstOrDefault();
                dgvInforHD.Rows.Add();
                dgvInforHD.Rows[index_inforHD].Cells[0].Value = item.Idsach;
                dgvInforHD.Rows[index_inforHD].Cells[1].Value = book.Tensach;
                dgvInforHD.Rows[index_inforHD].Cells[2].Value = item.SoLuongMua;
                dgvInforHD.Rows[index_inforHD].Cells[3].Value = book.Giasach;
                dgvInforHD.Rows[index_inforHD].Cells[4].Value = item.SoLuongMua * book.Giasach;
                SumMoney += item.SoLuongMua.Value*book.Giasach.Value;
                index_inforHD++;
            }
            lbTongTien.Text = SumMoney.ToString();
        }
        #endregion
        #region Quản lí bán sách>Lịch sử bán sách
        private void btnDDLhistory_Click(object sender, EventArgs e)
        {
            var hds = (from h in dbcontext.HoaDons
                       join dg in dbcontext.Docgia on h.Iddocgia equals dg.Iddocgia
                       select new
                       {
                           mahd = h.MaHd,
                           madg = h.Iddocgia,
                           tendg = dg.Hoten,
                           nguoilap = h.NguoiLap,
                           ngaylap = h.NgayLap
                       }).ToList();
            dgvHistoryBS.Rows.Clear();
            dgvHistoryBS.ColumnCount = 7;
            int index_historybs = 0;
            foreach (var item in hds)
            {
                var hdcts = (from hct in dbcontext.HoaDonChiTiets where hct.MaHd == item.mahd select hct).ToList();
                double SumMoney = 0;
                foreach (var child_item in hdcts)
                {
                    Models.Sach book = (from b in dbcontext.Saches where b.Idsach == child_item.Idsach select b).FirstOrDefault();
                    SumMoney += child_item.SoLuongMua.Value * book.Giasach.Value;
                }
                dgvHistoryBS.Rows.Add();
                dgvHistoryBS.Rows[index_historybs].Cells[0].Value = item.mahd;
                dgvHistoryBS.Rows[index_historybs].Cells[1].Value = item.madg;
                dgvHistoryBS.Rows[index_historybs].Cells[2].Value = item.tendg;
                dgvHistoryBS.Rows[index_historybs].Cells[3].Value = SumMoney;
                dgvHistoryBS.Rows[index_historybs].Cells[4].Value = item.nguoilap;
                dgvHistoryBS.Rows[index_historybs].Cells[5].Value = item.ngaylap;
                int days = DateTime.Now.Day - item.ngaylap.Value.Day;
                if (days == 0)
                {
                    dgvHistoryBS.Rows[index_historybs].Cells[6].Value = "Hôm nay";
                }
                else if (0 < days && days < 30)
                {
                    dgvHistoryBS.Rows[index_historybs].Cells[6].Value = days + " ngày trước";
                }
                else
                {
                    dgvHistoryBS.Rows[index_historybs].Cells[6].Value = ">=30 ngày trước";
                }
                index_historybs++;
            }
        }
        private void btnLayDL_Click(object sender, EventArgs e)
        {
            var hds = (from h in dbcontext.HoaDons
                       join dg in dbcontext.Docgia on h.Iddocgia equals dg.Iddocgia
                       select new
                       {
                           mahd = h.MaHd,
                           madg = h.Iddocgia,
                           tendg = dg.Hoten,
                           nguoilap = h.NguoiLap,
                           ngaylap = h.NgayLap
                       }).ToList();
            dgvHistoryBS.Rows.Clear();
            dgvHistoryBS.ColumnCount = 7;
            int index_historybs = 0;
            if (dtimeStart.Value.Date > dtimeEnd.Value.Date)
            {
                MessageBox.Show("Điểm khởi đầu lớn hơn điểm kết thúc", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (var item in hds)
                {   
                    if (dtimeStart.Value.Date<=item.ngaylap.Value.Date&&item.ngaylap.Value.Date<=dtimeEnd.Value.Date)
                    {
                        var hdcts = (from hct in dbcontext.HoaDonChiTiets where hct.MaHd == item.mahd select hct).ToList();
                        double SumMoney = 0;
                        foreach (var child_item in hdcts)
                        {
                            Models.Sach book = (from b in dbcontext.Saches where b.Idsach == child_item.Idsach select b).FirstOrDefault();
                            SumMoney += child_item.SoLuongMua.Value * book.Giasach.Value;
                        }
                        dgvHistoryBS.Rows.Add();
                        dgvHistoryBS.Rows[index_historybs].Cells[0].Value = item.mahd;
                        dgvHistoryBS.Rows[index_historybs].Cells[1].Value = item.madg;
                        dgvHistoryBS.Rows[index_historybs].Cells[2].Value = item.tendg;
                        dgvHistoryBS.Rows[index_historybs].Cells[3].Value = SumMoney;
                        dgvHistoryBS.Rows[index_historybs].Cells[4].Value = item.nguoilap;
                        dgvHistoryBS.Rows[index_historybs].Cells[5].Value = item.ngaylap;
                        int days = DateTime.Now.Day - item.ngaylap.Value.Day;
                        if (days == 0)
                        {
                            dgvHistoryBS.Rows[index_historybs].Cells[6].Value = "Hôm nay";
                        }
                        else if (0 < days && days < 30)
                        {
                            dgvHistoryBS.Rows[index_historybs].Cells[6].Value = days + " ngày trước";
                        }
                        else
                        {
                            dgvHistoryBS.Rows[index_historybs].Cells[6].Value = ">=30 ngày trước";
                        }
                        index_historybs++;
                    }
                }
            }
        }


        #endregion

        #endregion
    }
}
