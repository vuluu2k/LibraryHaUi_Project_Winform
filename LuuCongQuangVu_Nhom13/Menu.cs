using System;
using System.Collections;
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
        String laster_hd="";
        private void RefeshInforHD()
        {
            cbTimKiemMaHD.DataSource = dbcontext.HoaDons.ToList();
            cbTimKiemMaHD.DisplayMember = "MaHD";
            cbTimKiemMaHD.ValueMember = "MaHD";
        }
        private void RefeshMaDG()
        {
            cbMaDG.DataSource = dbcontext.Docgia.ToList();
            cbMaDG.DisplayMember = "Iddocgia";
            cbMaDG.ValueMember = "Iddocgia";
        }
        private void InCbTenSach()
        {
            cbMaSach_lhd.DataSource = dbcontext.Saches.ToList();
            cbMaSach_lhd.DisplayMember = "Tensach";
            cbMaSach_lhd.ValueMember = "Idsach";
        }
        private void InCbMaSach()
        {
            cbMaSach_lhd.DataSource = dbcontext.Saches.ToList();
            cbMaSach_lhd.DisplayMember = "Idsach";
            cbMaSach_lhd.ValueMember = "Idsach";
        }
        #endregion
        public QuanLiThuVien()
        {

            InitializeComponent();
            dategiomocuaphongdoc.ShowUpDown = true;
            dategiodongcuaphongdoc.ShowUpDown = true;
        }
        private void QuanLiThuVien_Load(object sender, EventArgs e)
        {
            if (this.Text == "Admin") btnAdmin.Visible = true;
            rdInCbTenSach.Checked = true;
            InCbTenSach();
            RefeshMaDG();
            RefeshInforHD();
            //Models.Account acc = (Models.Account)this.Tag;
            //MessageBox.Show(acc.Usename);
            //MessageBox.Show(dgvLHD.RowCount.ToString());
        }
        #region Xử lí radion button
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
        private void rdMaDG_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchDG.Visible = true;
            dtimeSearchDG.Visible = false;
        }
        private void rdNgaySinhDG_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchDG.Visible = false;
            dtimeSearchDG.Visible = true;
        }
        private void QuanLiThuVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            InCbTenSach();
            lbChangeLHD_MaSach.Text = "Tên sách";
        }

        private void rdInCbMaSach_CheckedChanged(object sender, EventArgs e)
        {
            InCbMaSach();
            lbChangeLHD_MaSach.Text = "Mã sách";
        }
        #endregion
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
            else
            {
                Models.Sach book = (from b in dbcontext.Saches where b.Idsach == txtmasach.Text select b).FirstOrDefault();
                if (txtmasach.Text.Length>4)
                {
                    GetError.SetError(txtmasach, "Mã sách chỉ tối đa 4 kí tự!");
                    txtmasach.Focus();
                    txtmasach.SelectAll();
                    return false;
                }
                else if (book != null )
                {
                    GetError.SetError(txtmasach, "Trùng mã sách, vui lòng nhập mã sách khác!");
                    txtmasach.Focus();
                    txtmasach.SelectAll();
                    return false;
                }
                
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
        private bool Validate_ManageBook1()
        {
            if (txtmasach.Text == "")
            {
                GetError.SetError(txtmasach, "Bạn phải nhập mã sách!");
                txtmasach.Focus();
                return false;
            }
            else
            {
                Models.Sach book = (from b in dbcontext.Saches where b.Idsach == txtmasach.Text select b).FirstOrDefault();
                if (txtmasach.Text.Length > 4)
                {
                    GetError.SetError(txtmasach, "Mã sách chỉ tối đa 4 kí tự!");
                    txtmasach.Focus();
                    txtmasach.SelectAll();
                    return false;
                }
                else if (book == null)
                {
                    GetError.SetError(txtmasach, "Mã sách không tồn tại!");
                    txtmasach.Focus();
                    txtmasach.SelectAll();
                    return false;
                }

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
        private bool Validate_ManageReader()
        {
            if (txtMaDocGia.Text == "")
            {
                GetError.SetError(txtMaDocGia, "Bạn phải nhập mã độc giả!");
                txtMaDocGia.Focus();
                return false;
            }
            else
            {
                Models.Docgium dg = (from d in dbcontext.Docgia where d.Iddocgia == txtMaDocGia.Text select d).FirstOrDefault();
                if (txtMaDocGia.Text.Length > 4)
                {
                    GetError.SetError(txtMaDocGia, "Mã độc giả chỉ tối đa 4 kí tự!");
                    txtMaDocGia.Focus();
                    txtMaDocGia.SelectAll();
                    return false;
                }
                else if (dg != null)
                {
                    GetError.SetError(txtMaDocGia, "Trùng mã độc giả, vui lòng nhập mã độc giả khác!");
                    txtMaDocGia.Focus();
                    txtMaDocGia.SelectAll();
                    return false;
                }
            }
            if (txtTenDocGia.Text == "")
            {
                GetError.SetError(txtTenDocGia, "Bạn phải nhập tên độc giả!");
                txtTenDocGia.Focus();
                return false;
            }
            if ((DateTime.Now.Year - dateDocGia.Value.Year)<18)
            {
                GetError.SetError(dateDocGia, "Độc giả phải trên 18 tuổi!");
                dateDocGia.Focus();
                return false;
            }
            if (txtDiaChiDocGia.Text == "")
            {
                GetError.SetError(txtDiaChiDocGia, "Bạn phải nhập địa chỉ độc giả!");
                txtDiaChiDocGia.Focus();
                return false;
            }
            if (txtNgheNhiep.Text == "")
            {
                GetError.SetError(txtNgheNhiep, "Bạn phải nhập nghề nghiệp độc giả!");
                txtNgheNhiep.Focus();
                return false;
            }
            if (txtSDT_DocGia.Text == "")
            {
                GetError.SetError(txtSDT_DocGia, "Bạn phải nhập số điện thoại độc giả!");
                txtSDT_DocGia.Focus();
                return false;
            }else
            {
                try
                {
                    int.Parse(txtSDT_DocGia.Text);
                    if (txtSDT_DocGia.Text.Length != 10)
                    {
                        GetError.SetError(txtSDT_DocGia, "Số điện thoại có độ dài là 10 kí tự!");
                        txtSDT_DocGia.Focus();
                        txtSDT_DocGia.SelectAll();
                        return false;
                    }
                }
                catch (Exception)
                {
                    GetError.SetError(txtSDT_DocGia, "Số điện thoại phải là kí tự số!");
                    txtSDT_DocGia.Focus();
                    txtSDT_DocGia.SelectAll();
                    return false;
                }
            }
            
            return true;
        }
        private bool Validate_ManageReader1()
        {
            if (txtMaDocGia.Text == "")
            {
                GetError.SetError(txtMaDocGia, "Bạn phải nhập mã độc giả!");
                txtMaDocGia.Focus();
                return false;
            }
            else
            {
                Models.Docgium dg = (from d in dbcontext.Docgia where d.Iddocgia == txtMaDocGia.Text select d).FirstOrDefault();
                if (txtMaDocGia.Text.Length > 4)
                {
                    GetError.SetError(txtMaDocGia, "Mã độc giả chỉ tối đa 4 kí tự!");
                    txtMaDocGia.Focus();
                    txtMaDocGia.SelectAll();
                    return false;
                }
                else if (dg == null)
                {
                    GetError.SetError(txtMaDocGia, "Mã độc giả đã tồn tại");
                    txtMaDocGia.Focus();
                    txtMaDocGia.SelectAll();
                    return false;
                }
            }
            if (txtTenDocGia.Text == "")
            {
                GetError.SetError(txtTenDocGia, "Bạn phải nhập tên độc giả!");
                txtTenDocGia.Focus();
                return false;
            }
            if ((DateTime.Now.Year - dateDocGia.Value.Year) < 18)
            {
                GetError.SetError(dateDocGia, "Độc giả phải trên 18 tuổi!");
                dateDocGia.Focus();
                return false;
            }
            if (txtDiaChiDocGia.Text == "")
            {
                GetError.SetError(txtDiaChiDocGia, "Bạn phải nhập địa chỉ độc giả!");
                txtDiaChiDocGia.Focus();
                return false;
            }
            if (txtNgheNhiep.Text == "")
            {
                GetError.SetError(txtNgheNhiep, "Bạn phải nhập nghề nghiệp độc giả!");
                txtNgheNhiep.Focus();
                return false;
            }
            if (txtSDT_DocGia.Text == "")
            {
                GetError.SetError(txtSDT_DocGia, "Bạn phải nhập số điện thoại độc giả!");
                txtSDT_DocGia.Focus();
                return false;
            }
            else
            {
                try
                {
                    int.Parse(txtSDT_DocGia.Text);
                    if (txtSDT_DocGia.Text.Length != 10)
                    {
                        GetError.SetError(txtSDT_DocGia, "Số điện thoại có độ dài là 10 kí tự!");
                        txtSDT_DocGia.Focus();
                        txtSDT_DocGia.SelectAll();
                        return false;
                    }
                }
                catch (Exception)
                {
                    GetError.SetError(txtSDT_DocGia, "Số điện thoại phải là kí tự số!");
                    txtSDT_DocGia.Focus();
                    txtSDT_DocGia.SelectAll();
                    return false;
                }

            }

            return true;
        }
        private bool CheckRadionReader()
        {
            if (rdMaDG.Checked == false && rdTenDG.Checked == false && rdNgaySinhDG.Checked == false && rdDiaChiDG.Checked == false && rdNgheNghiepDG.Checked == false && rdSDT_DG.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn nút tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        #endregion
        #region Xử lý lỗi lập hoá đơn
        private void txtMaHD_Validated(object sender, EventArgs e)
        {
            GetError.SetError(txtMaHD, "");
        }

        private void cbMaDG_Validated(object sender, EventArgs e)
        {
            GetError.SetError(cbMaDG, "");
        }

        private void dtimeNgayLap_Validated(object sender, EventArgs e)
        {
            GetError.SetError(dtimeNgayLap, "");
        }

        private void cbMaSach_lhd_Validated(object sender, EventArgs e)
        {
            GetError.SetError(cbMaSach_lhd, "");
        }

        private void txtsoluongmua_lhd_Validated(object sender, EventArgs e)
        {
            GetError.SetError(txtsoluongmua_lhd, "");
        }
        private bool Validate_LHD_InforHD()
        {
            if (txtMaHD.Text == "")
            {
                GetError.SetError(txtMaHD, "Bạn phải nhập mã hoá đơn!");
                txtMaHD.Focus();
                return false;
            }
            else
            {
                Models.HoaDon hd = (from h in dbcontext.HoaDons where h.MaHd == txtMaHD.Text select h).FirstOrDefault();
                if (txtMaHD.Text.Length > 4)
                {
                    GetError.SetError(txtMaHD, "Mã hoá đơn chỉ cho phép tối đa 4 kí tự!");
                    txtMaHD.Focus();
                    txtMaHD.Select();
                    return false;
                }
                if (hd != null)
                {
                    GetError.SetError(txtMaHD, "Trùng mã hoá đơn, vui lòng nhập mã hoá đơn khác!");
                    txtMaHD.Focus();
                    txtMaHD.Select();
                    return false;
                }
            }
            if (cbMaDG.Text == "")
            {
                GetError.SetError(cbMaDG, "Bạn phải nhập hoặc chọn mã độc giả!");
                cbMaDG.Focus();
                return false;
            }
            else
            {
                Models.Docgium dg = (from d in dbcontext.Docgia where d.Iddocgia == cbMaDG.Text select d).FirstOrDefault();
                if (cbMaDG.Text.Length > 4)
                {
                    GetError.SetError(cbMaDG, "Mã độc giả chỉ tối đa 4 kí tự!");
                    cbMaDG.Focus();
                    cbMaDG.SelectAll();
                    return false;
                }
                else if (dg == null)
                {
                    GetError.SetError(cbMaDG, "Mã độc giả không tồn tại");
                    txtMaDocGia.Focus();
                    txtMaDocGia.SelectAll();
                    return false;
                }
            }
            if (dtimeNgayLap.Value > DateTime.Now)
            {
                GetError.SetError(dtimeNgayLap, "Thời gian bạn chọn là thời trong tương lai!");
                dtimeNgayLap.Focus();
                return false;
            }
            if (dgvLHD.RowCount-1 <= 0)
            {
                MessageBox.Show("Bạn chưa mua một sách nào!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbMaSach_lhd.Focus();
                return false;
            }
            return true;
        }
        private bool Validate_LHD_InforBuyBook()
        {
            if (cbMaSach_lhd.Text == "")
            {
                if (rdInCbMaSach.Checked)
                {
                    GetError.SetError(cbMaSach_lhd,"Bạn phải nhập hoặc chọn mã sách!");
                    cbMaSach_lhd.Focus();
                    return false;
                }
                else
                {
                    GetError.SetError(cbMaSach_lhd, "Bạn phải nhập hoặc chọn tên sách!");
                    cbMaSach_lhd.Focus();
                    return false;
                }
            }
            else
            {
                if (rdInCbMaSach.Checked)
                {
                    Models.Sach book = (from b in dbcontext.Saches where b.Idsach == cbMaSach_lhd.Text select b).FirstOrDefault();
                    if (cbMaSach_lhd.Text.Length > 4)
                    {
                        GetError.SetError(cbMaSach_lhd, "Mã sách không được quá 4 kí tự!");
                        cbMaSach_lhd.Focus();
                        cbMaSach_lhd.SelectAll();
                        return false;
                    }
                    else if (book == null)
                    {
                        GetError.SetError(cbMaSach_lhd, "Mã sách không tồn tại!");
                        cbMaSach_lhd.Focus();
                        cbMaSach_lhd.SelectAll();
                        return false;
                    }
                }
                else
                {
                    Models.Sach book = (from b in dbcontext.Saches where b.Tensach == cbMaSach_lhd.Text select b).FirstOrDefault();
                    if (book == null)
                    {
                        GetError.SetError(cbMaSach_lhd, "Tên sách không tồn tại!");
                        cbMaSach_lhd.Focus();
                        cbMaSach_lhd.SelectAll();
                        return false;
                    }
                }
            }
            if (txtsoluongmua_lhd.Text == "")
            {
                GetError.SetError(txtsoluongmua_lhd, "Bạn phải nhập số lượng mua!");
                txtsoluongmua_lhd.Focus();
                return false;
            }
            else
            {
                try
                {
                    Models.Sach book = new Models.Sach();
                    if (rdInCbTenSach.Checked)
                    {
                        book = (from b in dbcontext.Saches where b.Tensach == cbMaSach_lhd.Text select b).FirstOrDefault();
                    }
                    else
                    {
                        book = (from b in dbcontext.Saches where b.Idsach == cbMaSach_lhd.Text select b).FirstOrDefault();
                    }
                    int.Parse(txtsoluongmua_lhd.Text);
                    if (int.Parse(txtsoluongmua_lhd.Text) < 0)
                    {
                        GetError.SetError(txtsoluongmua_lhd, "Bạn phải nhập số lượng mua >0!");
                        txtsoluongmua_lhd.Focus();
                        txtsoluongmua_lhd.SelectAll();
                        return false;
                    }
                    else if (book.Soluong == 0)
                    {
                        GetError.SetError(txtsoluongmua_lhd, "Sách này hiện tại đang hết");
                        txtsoluongmua_lhd.Focus();
                        txtsoluongmua_lhd.SelectAll();
                        return false;
                    }
                    else if (int.Parse(txtsoluongmua_lhd.Text) > book.Soluong)
                    {
                        GetError.SetError(txtsoluongmua_lhd, "Số lượng mua vượt quá số lượng có, hiện tại còn "+book.Soluong+" quyển");
                        txtsoluongmua_lhd.Focus();
                        txtsoluongmua_lhd.SelectAll();
                        return false;
                    }
                    
                }
                catch (Exception)
                {
                    GetError.SetError(txtsoluongmua_lhd, "Bạn phải nhập số lượng mua là số nguyên!");
                    txtsoluongmua_lhd.Focus();
                    txtsoluongmua_lhd.SelectAll();
                    return false;
                }
            }
            return true;
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
        }
        private void DelBook()
        {
            //using var dbcontext = new Models.QLThuVienContext();
            //Models.Sach id = dbcontext.Saches.Where(sach => sach.Idsach == txtmasach.Text).FirstOrDefault();
            //var idm = dbcontext.Muontrasaches.Where(m => m.Idsach == txtmasach.Text).ToList();
            Models.Sach id = (from book in dbcontext.Saches where book.Idsach==txtmasach.Text select book).FirstOrDefault();
            var idm = (from m in dbcontext.Muontrasaches where m.Idsach==txtmasach.Text select m).ToList();
            var hdcts = (from hdct in dbcontext.HoaDonChiTiets where hdct.Idsach == txtmasach.Text select hdct).ToList();
            var mttcs = (from mttc in dbcontext.Muontrataichos where mttc.Idsach == txtmasach.Text select mttc).ToList();
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn xoá không", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                if (id != null)
                {
                    if (idm != null)
                    {
                        dbcontext.Muontrasaches.RemoveRange(idm);
                    }
                    if (hdcts!=null)
                    {
                        dbcontext.HoaDonChiTiets.RemoveRange(hdcts);
                    }
                    if (mttcs != null)
                    {
                        dbcontext.Muontrataichos.RemoveRange(mttcs);
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
            if (Validate_ManageBook1())
            {
                Models.Sach sach = (from book in dbcontext.Saches where book.Idsach==txtmasach.Text select book).FirstOrDefault();
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
        private void ClearBook()
        {
            txtmasach.Clear();
            txttensach.Clear();
            txttacgia.Clear();
            txtsoluong.Clear();
            txttheloai.Clear();
            txtgiasach.Clear();
            txtnhasx.Clear();
            cbvitri.SelectedIndex=-1;
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
            ClearBook();
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
        private void ReadFileReader()
        {
            //using var dbcontext = new Models.QLThuVienContext();
            var list_docgia = dbcontext.Docgia.ToList();
            if (list_docgia != null)
            {
                    dgvDocGia.Rows.Clear();
                    dgvDocGia.ColumnCount = 6;
                    lbSluongDG.Text = list_docgia.Count().ToString();
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
        private void AddReader()
        {
            if (Validate_ManageReader())
            {
                Models.Docgium docgia = new Models.Docgium();
                docgia.Iddocgia = txtMaDocGia.Text;
                docgia.Hoten = txtTenDocGia.Text;
                docgia.NgaySinh = dateDocGia.Value;
                docgia.Diachi = txtDiaChiDocGia.Text;
                docgia.Nghenghiep = txtNgheNhiep.Text;
                docgia.Sodienthoai = txtSDT_DocGia.Text;
                dbcontext.Docgia.Add(docgia);
                dbcontext.SaveChanges();
                ReadFileReader();
            }
        }
        private void DelReader()
        {
            //using var dbcontext = new Models.QLThuVienContext();
            //Models.Docgium id = dbcontext.Docgia.Where(d => d.Iddocgia == txtMaDocGia.Text).FirstOrDefault();
            //var idt = dbcontext.Thethuviens.Where(t => t.Iddocgia == txtMaDocGia.Text).ToList();
            //var idm = dbcontext.Muontrasaches.Where(m => m.Iddocgia == txtMaDocGia.Text).ToList();
            //var idt = (from t in dbcontext.Thethuviens where t.Iddocgia==txtMaDocGia.Text select t).ToList();cc
            Models.Docgium id = (from d in dbcontext.Docgia where d.Iddocgia==txtMaDocGia.Text select d).FirstOrDefault();
            var idm = (from m in dbcontext.Muontrasaches where m.Iddocgia == txtMaDocGia.Text select m).ToList();
            var mttcs = (from mttc in dbcontext.Muontrataichos where mttc.Iddocgia == txtMaDocGia.Text select mttc).ToList();
            var hds = (from hd in dbcontext.HoaDons where hd.Iddocgia == txtMaDocGia.Text select hd).ToList();
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn xoá không", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                if (id != null)
                {
                    if (idm != null)
                    {
                        dbcontext.Muontrasaches.RemoveRange(idm);
                    }
                    if (mttcs != null)
                    {
                        dbcontext.Muontrataichos.RemoveRange(mttcs);
                    }
                    if (hds != null)
                    {
                        foreach(var item in hds)
                        {
                            var hdcts = (from hdct in dbcontext.HoaDonChiTiets where hdct.MaHd == item.MaHd select hdct).ToList();
                            if (hdcts != null)
                            {
                                dbcontext.RemoveRange(hdcts);
                            }
                        }
                        dbcontext.RemoveRange(hds);
                    }
                    dbcontext.Docgia.Remove(id);
                    dbcontext.SaveChanges();
                    ReadFileReader();
                }
                else
                {
                    MessageBox.Show("Mã độc giả không tồn tại", "Thông báo");
                }
            }
        }
        private void UpdateReader()
        {
            if (Validate_ManageReader1())
            {
                //using var dbcontext = new Models.QLThuVienContext();
                //Models.Docgium id = dbcontext.Docgia.Where(d => d.Iddocgia == txtMaDocGia.Text).FirstOrDefault();
                Models.Docgium id = (from d in dbcontext.Docgia where d.Iddocgia == txtMaDocGia.Text select d ).FirstOrDefault();
                id.Hoten = txtTenDocGia.Text;
                id.NgaySinh = dateDocGia.Value;
                id.Diachi = txtDiaChiDocGia.Text;
                id.Nghenghiep = txtNgheNhiep.Text;
                id.Sodienthoai = txtSDT_DocGia.Text;
                dbcontext.SaveChanges();
                ReadFileReader();
            }
        }
        private void ClearReader()
        {
            txtMaDocGia.Clear();
            txtTenDocGia.Clear();
            txtDiaChiDocGia.Clear();
            txtNgheNhiep.Clear();
            txtSDT_DocGia.Clear();
        }
        private void SearchReader()
        {
            if (CheckRadionReader())
            {
                if (rdMaDG.Checked)
                {
                    //using var dbcontext = new Models.QLThuVienContext();
                    //var list_docgia = dbcontext.Docgia.Where(d=>d.Iddocgia==txtMaDocGia.Text).ToList();
                    var list_docgia = (from d in dbcontext.Docgia where d.Iddocgia==txtSearchDG.Text select d).ToList();
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
                        MessageBox.Show("Không tồn tại dữ liệu tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (rdTenDG.Checked)
                {
                    //using var dbcontext = new Models.QLThuVienContext();
                    //var list_docgia = dbcontext.Docgia.Where(d => d.Hoten == txtTenDocGia.Text).ToList();
                    var list_docgia = (from d in dbcontext.Docgia where d.Hoten == txtSearchDG.Text select d).ToList();
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
                        MessageBox.Show("Không tồn tại dữ liệu tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (rdNgaySinhDG.Checked)
                {
                    //using var dbcontext = new Models.QLThuVienContext();
                    //var list_docgia = dbcontext.Docgia.Where(d =>d.Ngaysinh.Value.Date == dateDocGia.Value.Date).ToList();
                    var list_docgia = (from d in dbcontext.Docgia where d.NgaySinh.Value.Date == dtimeSearchDG.Value.Date select d).ToList();
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
                        MessageBox.Show("Không tồn tại dữ liệu tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (rdDiaChiDG.Checked)
                {
                    //using var dbcontext = new Models.QLThuVienContext();
                    //var list_docgia = dbcontext.Docgia.Where(d => d.Diachi == txtDiaChiDocGia.Text).ToList();
                    var list_docgia = (from d in dbcontext.Docgia where d.Diachi == txtSearchDG.Text select d).ToList();
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
                        MessageBox.Show("Không tồn tại dữ liệu tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (rdNgheNghiepDG.Checked)
                {
                    //using var dbcontext = new Models.QLThuVienContext();
                    //var list_docgia = dbcontext.Docgia.Where(d => d.Nghenghiep == txtNgheNhiep.Text).ToList();
                    var list_docgia = (from d in dbcontext.Docgia where d.Nghenghiep == txtSearchDG.Text select d).ToList();
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
                        MessageBox.Show("Không tồn tại dữ liệu tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (rdSDT_DG.Checked)
                {
                    //using var dbcontext = new Models.QLThuVienContext();
                    //var list_docgia = dbcontext.Docgia.Where(d => d.Sodienthoai == txtSDT_DocGia.Text).ToList();
                    var list_docgia = (from d in dbcontext.Docgia where d.Sodienthoai == txtSearchDG.Text select d).ToList();
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
                        MessageBox.Show("Không tồn tại dữ liệu tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void btnReadDocGia_Click(object sender, EventArgs e)
        {
            ReadFileReader();
        }

        private void btnThemDocGia_Click(object sender, EventArgs e)
        {
            AddReader();
        }

        private void btnXoaDocGia_Click(object sender, EventArgs e)
        {
            DelReader();
        }

        private void btnSuaDocGia_Click(object sender, EventArgs e)
        {
            UpdateReader();
        }

        private void btnHuyDocGia_Click(object sender, EventArgs e)
        {
            ClearReader();
        }

        private void btnTimKiemDocGia_Click(object sender, EventArgs e)
        {
            SearchReader();
        }

        private void cell_click_reader(object sender, DataGridViewCellEventArgs e)
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

        private void AddBookBuy()
        {
            if (Validate_LHD_InforBuyBook())
            {
                if (dgvLHD.RowCount == 1)
                {
                    dgvLHD.Rows.Clear();
                    index = 0;
                }
                Models.Sach book = new Models.Sach();
                if (rdInCbTenSach.Checked)
                {
                    book = (from b in dbcontext.Saches where b.Tensach == cbMaSach_lhd.Text select b).FirstOrDefault();
                }
                else
                {
                    book = (from b in dbcontext.Saches where b.Idsach == cbMaSach_lhd.Text select b).FirstOrDefault();
                }
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
                    GetError.SetError(cbMaSach_lhd, "Mã sách/Tên sách này không tồn tại!");
                    cbMaSach_lhd.Focus();
                    cbMaSach_lhd.SelectAll();
                }
            }
        }
        private void UpdateBookBuy()
        {
            if (Validate_LHD_InforBuyBook())
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
                    GetError.SetError(cbMaSach_lhd, "Mã sách này không tồn tại!");
                    cbMaSach_lhd.Focus();
                    cbMaSach_lhd.SelectAll();
                }
            }
        }
        private void DelBookBuy()
        {
            dgvLHD.Rows.RemoveAt(dgvLHD.SelectedCells[0].RowIndex);
        }
        private void CreateBill()
        {
            if (Validate_LHD_InforHD())
            {
                Models.Account acc = (Models.Account)this.Tag;
                //MessageBox.Show(acc.Usename);
                //string username = (string) this.Tag;
                Models.HoaDon hd = new Models.HoaDon();
                hd.MaHd = txtMaHD.Text;
                hd.Iddocgia = cbMaDG.Text;
                hd.Usename = acc.Usename;
                hd.NgayLap = dtimeNgayLap.Value;
                dbcontext.HoaDons.Add(hd);
                for (int i = 0; i < dgvLHD.RowCount-1; i++)
                {
                    if (dgvLHD.Rows[i].Cells[0].Value == "")
                    {
                        dgvLHD.Rows.RemoveAt(i);
                    }
                    //MessageBox.Show(Convert.ToString(dgvLHD.Rows[i].Cells[0].Value));
                    Models.HoaDonChiTiet hdct = new Models.HoaDonChiTiet();
                    hdct.MaHd = hd.MaHd;
                    hdct.Idsach = Convert.ToString(dgvLHD.Rows[i].Cells[0].Value);
                    hdct.SoLuongMua = Convert.ToInt32(dgvLHD.Rows[i].Cells[2].Value);
                    Models.Sach book = (from b in dbcontext.Saches where b.Idsach==hdct.Idsach select b).FirstOrDefault();
                    book.Soluong = book.Soluong - hdct.SoLuongMua;
                    dbcontext.HoaDonChiTiets.Add(hdct);
                }
                dbcontext.SaveChanges();
                MessageBox.Show("Lập hoá đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                laster_hd = txtMaHD.Text;
                ClearALl();
            }
        }

        private void ClearALl()
        {
            txtMaHD.Clear();
            cbMaDG.SelectedIndex = -1;
            dtimeNgayLap.Value = DateTime.Now;
            cbMaSach_lhd.SelectedIndex = -1;
            txtsoluongmua_lhd.Clear();
            dgvLHD.Rows.Clear();
        }

        private void dgvLHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index_lhd = dgvLHD.SelectedCells[0].RowIndex;
            DataGridViewRow row = dgvLHD.Rows[index_lhd];
            cbMaSach_lhd.Text = Convert.ToString(row.Cells[1].Value);
            txtsoluongmua_lhd.Text = Convert.ToString(row.Cells[2].Value);
            //Cell_Click_LHD = index_lhd;
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
        private void btnHuySachMua_Click(object sender, EventArgs e)
        {
            cbMaSach_lhd.Text = "";
            txtsoluongmua_lhd.Clear();
        }

        #endregion
        #region Quản lí bán sách>Thông tin hoá đơn độc giả
        private void btnFirstHD_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(laster_hd);
            if (laster_hd != "")
            {
                Models.HoaDon hd = (from h in dbcontext.HoaDons where h.MaHd == laster_hd select h).FirstOrDefault();
                var hdct = (from hct in dbcontext.HoaDonChiTiets where hct.MaHd == laster_hd select hct).ToList();
                Models.Docgium dg = (from d in dbcontext.Docgia where d.Iddocgia == hd.Iddocgia select d).FirstOrDefault();
                Models.Account acc = (from a in dbcontext.Accounts where a.Usename == hd.Usename select a).FirstOrDefault();
                lbInforMaHD.Text = hd.MaHd;
                lbInforMaDG.Text = hd.Iddocgia;
                lbInforNLap.Text = acc.Tenchutaikhoan;
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
            else
            {
                MessageBox.Show("Bạn chưa lập bất kì một hoá đơn nào từ kề lần đăng nhập gần nhất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                MessageBox.Show("Không có mã hoá đơn này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);//not working because it always get id
            }
        }
        
        private void btnTimKiem_InforHD_Click(object sender, EventArgs e)
        {
            Models.HoaDon hd = (from h in dbcontext.HoaDons where h.MaHd == cbTimKiemMaHD.Text select h).FirstOrDefault();
            if (hd != null)
            {
                var hdct = (from hct in dbcontext.HoaDonChiTiets where hct.MaHd == cbTimKiemMaHD.Text select hct).ToList();
                Models.Docgium dg = (from d in dbcontext.Docgia where d.Iddocgia == hd.Iddocgia select d).FirstOrDefault();
                Models.Account acc = (from a in dbcontext.Accounts where a.Usename == hd.Usename select a).FirstOrDefault();
                lbInforMaHD.Text = hd.MaHd;
                lbInforMaDG.Text = hd.Iddocgia;
                lbInforNLap.Text = acc.Tenchutaikhoan;
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
            else
            {
                MessageBox.Show("Không có mã hoá đơn này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Quản lí bán sách>Lịch sử bán sách
        private void btnDDLhistory_Click(object sender, EventArgs e)
        {
            var hds = (from h in dbcontext.HoaDons
                       join dg in dbcontext.Docgia on h.Iddocgia equals dg.Iddocgia
                       join acc in dbcontext.Accounts on h.Usename equals acc.Usename
                       select new
                       {
                           mahd = h.MaHd,
                           madg = h.Iddocgia,
                           tendg = dg.Hoten,
                           nguoilap = acc.Tenchutaikhoan,
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
                       join acc in dbcontext.Accounts on h.Usename equals acc.Usename
                       select new
                       {
                           mahd = h.MaHd,
                           madg = h.Iddocgia,
                           tendg = dg.Hoten,
                           nguoilap = acc.Usename,
                           ngaylap = h.NgayLap
                       }).ToList();
            dgvHistoryBS.Rows.Clear();
            dgvHistoryBS.ColumnCount = 7;
            int index_historybs = 0;
            if (dtimeStart.Value.Date > dtimeEnd.Value.Date)
            {
                MessageBox.Show("Điểm khởi thời gian đầu lớn hơn điểm kết thúc", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (dgvHistoryBS.RowCount == 1) ;
            {
                MessageBox.Show($"Không có dữ liệu từ {dtimeStart.Value.Date} đến {dtimeEnd.Value.Date}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #endregion
        #region Refesh Buttons
        private void btnRefeshMaDG_Click(object sender, EventArgs e)
        {
            RefeshMaDG();
        }
        private void btnRefeshMaSach_Click(object sender, EventArgs e)
        {
            if (rdInCbTenSach.Checked)
            {
                InCbTenSach();
            }
            else
            {
                InCbMaSach();
            }
        }
        private void btnRefeshSearchInforHD_Click(object sender, EventArgs e)
        {
            RefeshInforHD();
        }
        #endregion




        //-------------------------------------------------------QUẢN LÝ PHÒNG ĐỌC------------------------------------------------
        private bool Validate_ManagePhongDoc()
        {
            if (txtidphongdoc.Text == "")
            {
                GetError.SetError(txtidphongdoc, "Bạn phải nhập id phòng đọc!");
                txtidphongdoc.Focus();
                return false;
            }
            else
            {
                Models.PhongDoc phongdoc = (from pd in dbcontext.PhongDocs where pd.Idphongdoc == txtidphongdoc.Text select pd).FirstOrDefault();
                if (txtidphongdoc.Text.Length > 4)
                {
                    GetError.SetError(txtmasach, "Mã phòng đọc chỉ tối đa 4 kí tự!");
                    txtidphongdoc.Focus();
                    txtidphongdoc.SelectAll();
                    return false;
                }
                else if (phongdoc != null)
                {
                    GetError.SetError(txtidphongdoc, "Trùng id phòng đọc, vui lòng nhập id phòng đọc khác khác!");
                    txtidphongdoc.Focus();
                    txtidphongdoc.SelectAll();
                    return false;
                }
            }
            if (txttennhanvien.Text == "")
            {
                GetError.SetError(txttennhanvien, "Bạn phải nhập tên nhân viên!");
                txttennhanvien.Focus();
                return false;
            }
            if (txtsobanphongdoc.Text == "")
            {
                GetError.SetError(txtsobanphongdoc, "Bạn phải nhập số bàn trong phòng đọc!");
                txtsobanphongdoc.Focus();
                return false;
            }
            else
            {
                try
                {
                    int.Parse(txtsobanphongdoc.Text);
                    if (int.Parse(txtsobanphongdoc.Text) < 0)
                    {
                        GetError.SetError(txtsobanphongdoc, "Bạn phải nhập số bàn đọc  >0!");
                        txtsobanphongdoc.Focus();
                        txtsobanphongdoc.SelectAll();
                        return false;
                    }
                }
                catch (Exception)
                {
                    GetError.SetError(txtsobanphongdoc, "Bạn phải nhập số lượng là số nguyên!");
                    txtsobanphongdoc.Focus();
                    txtsobanphongdoc.SelectAll();
                    return false;
                }
            }
            if (dategiomocuaphongdoc.Text.Equals(""))
            {
                GetError.SetError(dategiomocuaphongdoc, "Bạn phải nhập giờ mở cửa!");
                dategiomocuaphongdoc.Focus();
                return false;
            }
            if (dategiomocuaphongdoc.Text.Equals(""))
            {
                GetError.SetError(dategiodongcua, "Bạn phải nhập giờ đóng cửa!");
                dategiodongcua.Focus();
                return false;
            }
            if (dategiomocuaphongdoc.Value.Date != dategiomocuaphongdoc.Value.Date)
            {
                MessageBox.Show("giờ mở cửa và giờ đóng cửa phải cùng ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private bool Validate_ManagePhongDoc1()
        {
            if (txtidphongdoc.Text == "")
            {
                GetError.SetError(txtmasach, "Bạn phải nhập id phòng đọc!");
                txtidphongdoc.Focus();
                return false;
            }
            else
            {
                Models.PhongDoc phongdoc = (from pd in dbcontext.PhongDocs where pd.Idphongdoc == txtidphongdoc.Text select pd).FirstOrDefault();
                if (txtidphongdoc.Text.Length > 4)
                {
                    GetError.SetError(txtmasach, "Mã phòng đọc chỉ tối đa 4 kí tự!");
                    txtidphongdoc.Focus();
                    txtidphongdoc.SelectAll();
                    return false;
                }
                else if (phongdoc == null)
                {
                    GetError.SetError(txtidphongdoc, "ID phòng đọc không tồn tại");
                    txtidphongdoc.Focus();
                    txtidphongdoc.SelectAll();
                    return false;
                }

            }
            if (txttennhanvien.Text == "")
            {
                GetError.SetError(txttennhanvien, "Bạn phải nhập tên nhân viên!");
                txttennhanvien.Focus();
                return false;
            }
            if (txtsobanphongdoc.Text == "")
            {
                GetError.SetError(txtsobanphongdoc, "Bạn phải nhập số bàn trong phòng đọc!");
                txtsobanphongdoc.Focus();
                return false;
            }
            else
            {
                try
                {
                    int.Parse(txtsobanphongdoc.Text);
                    if (int.Parse(txtsobanphongdoc.Text) < 0)
                    {
                        GetError.SetError(txtsobanphongdoc, "Bạn phải nhập số bàn đọc  >0!");
                        txtsobanphongdoc.Focus();
                        txtsobanphongdoc.SelectAll();
                        return false;
                    }
                }
                catch (Exception)
                {
                    GetError.SetError(txtsobanphongdoc, "Bạn phải nhập số lượng là số nguyên!");
                    txtsobanphongdoc.Focus();
                    txtsobanphongdoc.SelectAll();
                    return false;
                }
            }
            if (dategiomocuaphongdoc.Text.Equals(""))
            {
                GetError.SetError(dategiomocuaphongdoc, "Bạn phải nhập giờ mở cửa!");
                dategiomocuaphongdoc.Focus();
                return false;
            }
            if (dategiodongcuaphongdoc.Text.Equals(""))
            {
                GetError.SetError(dategiodongcua, "Bạn phải nhập giờ đóng cửa!");
                dategiodongcua.Focus();
                return false;
            }
            if (dategiomocuaphongdoc.Value.Date != dategiomocuaphongdoc.Value.Date)
            {
                MessageBox.Show("giờ mở cửa và giờ đóng cửa phải cùng ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void ReadFileQuanLiPhongDoc()
        {
            //using var dbcontext = new Models.QLThuVienContext();
            var list_phongdoc = dbcontext.PhongDocs.ToList();
            if (list_phongdoc != null)
            {
                if (list_phongdoc.Count() > 0)
                {
                    txtSL_Sach.Text = Convert.ToString(list_phongdoc.Count());
                    dgvphongdoc.Rows.Clear();
                    dgvphongdoc.ColumnCount = 5;
                    for (int i = 0; i < list_phongdoc.Count(); i++)
                    {
                        dgvphongdoc.Rows.Add();
                        dgvphongdoc.Rows[i].Cells[0].Value = list_phongdoc[i].Idphongdoc;
                        dgvphongdoc.Rows[i].Cells[1].Value = list_phongdoc[i].Tennhanvien;
                        dgvphongdoc.Rows[i].Cells[2].Value = list_phongdoc[i].Soban;
                        dgvphongdoc.Rows[i].Cells[3].Value = list_phongdoc[i].Giomocua;
                        dgvphongdoc.Rows[i].Cells[4].Value = list_phongdoc[i].Giodong;
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void ClearPhongDoc()
        {
            txtidphongdoc.Clear();
            txttennhanvien.Clear();
            txtsobanphongdoc.Clear();
            dategiomocuaphongdoc.Enabled = true;
            dategiodongcuaphongdoc.Enabled = true;

        }
        private void AddPhongDoc()
        {           
            if (Validate_ManagePhongDoc())
            {
                Models.PhongDoc phongdoc = new Models.PhongDoc();
                phongdoc.Idphongdoc = txtidphongdoc.Text;
                phongdoc.Tennhanvien = txttennhanvien.Text;
                phongdoc.Soban = int.Parse(txtsobanphongdoc.Text);
                phongdoc.Giomocua = dategiomocuaphongdoc.Value;
                phongdoc.Giodong = dategiodongcuaphongdoc.Value;
                dbcontext.PhongDocs.Add(phongdoc);
                dbcontext.SaveChanges();
                ReadFileQuanLiPhongDoc();
            }
        }
        private void UpdatePhongDoc()
        {
            //using var dbcontext = new Models.QLThuVienContext();
            //Models.Sach sach = dbcontext.Saches.Where(sach => sach.Idsach == txtmasach.Text).FirstOrDefault();
            if (Validate_ManagePhongDoc1())
            {
                Models.PhongDoc phongdoc = (from pd in dbcontext.PhongDocs where pd.Idphongdoc == txtidphongdoc.Text select pd).FirstOrDefault();
                phongdoc.Tennhanvien = txttennhanvien.Text;
                phongdoc.Soban = int.Parse(txtsobanphongdoc.Text);
                phongdoc.Giomocua = dategiomocuaphongdoc.Value;
                phongdoc.Giodong = dategiodongcuaphongdoc.Value;
                dbcontext.SaveChanges();
                ReadFileQuanLiPhongDoc();
            }
        }
        private void DelPhongDoc()
        {
            //using var dbcontext = new Models.QLThuVienContext();
            //Models.Sach id = dbcontext.Saches.Where(sach => sach.Idsach == txtmasach.Text).FirstOrDefault();
            //var idm = dbcontext.Muontrasaches.Where(m => m.Idsach == txtmasach.Text).ToList();
            Models.PhongDoc phongdoc = (from pd in dbcontext.PhongDocs where pd.Idphongdoc == txtidphongdoc.Text select pd).FirstOrDefault();
            var mttcs = (from mttc in dbcontext.Muontrataichos where mttc.Idphongdoc == txtidphongdoc.Text select mttc).ToList();
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn xoá không", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                if (phongdoc != null)
                {
                    if (mttcs != null)
                    {
                        dbcontext.Muontrataichos.RemoveRange(mttcs);
                    }
                    dbcontext.PhongDocs.Remove(phongdoc);
                    dbcontext.SaveChanges();
                    ReadFileQuanLiPhongDoc();
                }
                else
                {
                    MessageBox.Show("ID phòng đọc không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void SearchPhongDoc()
        {
            //using var dbcontext = new Models.QLThuVienContext();
            //var list_sach = dbcontext.Saches.Where(book=>book.Idsach==txtmasach.Text).ToList();
            var list_phongdoc = (from pd in dbcontext.PhongDocs where pd.Idphongdoc == txtidphongdoc.Text select pd).ToList();
            if (list_phongdoc != null)
            {
                if (list_phongdoc.Count() > 0)
                {
                    dgvphongdoc.Rows.Clear();
                    dgvphongdoc.ColumnCount = 5;
                    for (int i = 0; i < list_phongdoc.Count(); i++)
                    {
                        dgvphongdoc.Rows.Add();
                        dgvphongdoc.Rows[i].Cells[0].Value = list_phongdoc[i].Idphongdoc;
                        dgvphongdoc.Rows[i].Cells[1].Value = list_phongdoc[i].Tennhanvien;
                        dgvphongdoc.Rows[i].Cells[2].Value = list_phongdoc[i].Soban;
                        dgvphongdoc.Rows[i].Cells[3].Value = list_phongdoc[i].Giomocua;
                        dgvphongdoc.Rows[i].Cells[4].Value = list_phongdoc[i].Giodong;
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại dữ liệu tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btnhienthiphongdoc_Click(object sender, EventArgs e)
        {
            ReadFileQuanLiPhongDoc();
        }
        private void btnthemphongdoc_Click(object sender, EventArgs e)
        {
            AddPhongDoc();
            ClearPhongDoc();
        }
        private void btnsuaphongdoc_Click(object sender, EventArgs e)
        {
            UpdatePhongDoc();
        }
        private void cellclick_phongdoc(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvphongdoc.SelectedCells[0].RowIndex;
            DataGridViewRow row = dgvphongdoc.Rows[index];
            txtidphongdoc.Text = Convert.ToString(row.Cells[0].Value);
            txttennhanvien.Text = Convert.ToString(row.Cells[1].Value);
            txtsobanphongdoc.Text = Convert.ToString(row.Cells[2].Value);
        }
        private void btnxoaphongdoc_Click(object sender, EventArgs e)
        {
            DelPhongDoc();
            ClearPhongDoc();
        }
        private void btnhuyphongdoc_Click(object sender, EventArgs e)
        {
            ClearPhongDoc();
        }
        private void btntimkiemphongdoc_Click(object sender, EventArgs e)
        {
            SearchPhongDoc();
        }
        //------------------------------------------------------------MƯỢN TRẢ TẠI CHỖ -------------------------------------------------
        private void ClearMuonTraTaiPhong()
        {
            cbbiddocgiamuontra.Text = "";
            cbbidphongmuontra.Text = "";
            cbbidsachmuontra.Text = "";
            txtvitringoimuontra.Clear();
            dategiovaomuontra.Enabled = true;
            dategioramuontra.Enabled = true;
            txttinhtrangsachmuontra.Clear();
            cbbidphongmuontra.Focus();
        }
        void loadIDPhong(ComboBox pmt)
        {
            using var dbcontext = new Models.QLThuVienContext();
            pmt.DataSource = dbcontext.PhongDocs.ToList();
            pmt.DisplayMember = "Idphongdoc";
        }
        void loadIDSach(ComboBox s)
        {
            using var dbcontext = new Models.QLThuVienContext();
            s.DataSource = dbcontext.Saches.ToList();
            s.DisplayMember = "Idsach";
        }
        void loadIDdocgia(ComboBox cb)
        {
            using var dbcontext = new Models.QLThuVienContext();
            cb.DataSource = dbcontext.Docgia.ToList();
            cb.DisplayMember = "Iddocgia";
        }
        private bool Validate_ManageMuonTraTaiPhong()
        {
            if (cbbidphongmuontra.Text.Equals(""))
            {
                GetError.SetError(cbbidphongmuontra, "Bạn chưa chọn ID phòng đọc!");
                cbbidphongmuontra.Focus();
                return false;
            }
            if (cbbidsachmuontra.Text.Equals(""))
            {
                GetError.SetError(cbbidsachmuontra, "Bạn chưa chọn ID sách!");
                cbbidsachmuontra.Focus();
                return false;
            }
            if (cbbiddocgiamuontra.Text.Equals(""))
            {
                GetError.SetError(cbbiddocgiamuontra, "Bạn chưa chọn ID đọc giả!");
                cbbiddocgiamuontra.Focus();
                return false;
            }         
            if (txtvitringoimuontra.Text == "")
            {
                GetError.SetError(txtvitringoimuontra, "Bạn phải nhập vị trí ngồi!");
                txtvitringoimuontra.Focus();
                return false;
            }
            if (dategiovaomuontra.Text.Equals(""))
            {
                GetError.SetError(dategiovaomuontra, "Bạn phải nhập giờ vào!");
                dategiovaomuontra.Focus();
                return false;
            }
            if (dategioramuontra.Text.Equals(""))
            {
                GetError.SetError(dategioramuontra, "Bạn phải nhập giờ ra!");
                dategioramuontra.Focus();
                return false;
            }
            if (dategiovaomuontra.Value.Date != dategioramuontra.Value.Date)
            {
                MessageBox.Show("giờ ra và giờ vào phải cùng một ngày ! Vui lòng chọn lại ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void ReadFileQuanLyMuonTraTaiCho()
        {
            ClearMuonTraTaiPhong();
            loadIDPhong(cbbidphongmuontra);
            loadIDSach(cbbidsachmuontra);
            loadIDdocgia(cbbiddocgiamuontra);
            using var dbcontext = new Models.QLThuVienContext();
            var list_muontrataicho = from mttcs in dbcontext.Muontrataichos
                           join p in dbcontext.PhongDocs on mttcs.Idphongdoc equals p.Idphongdoc
                           join s in dbcontext.Saches on mttcs.Idsach equals s.Idsach
                           join dg in dbcontext.Docgia on mttcs.Iddocgia equals dg.Iddocgia                        
                           select new
                           {
                               idphongdoc = mttcs.Idphongdoc,
                               idsachmuontaiphong = mttcs.Idsach,
                               iddocgiamuontaiphong = mttcs.Iddocgia,
                               vitri = mttcs.Vitriban,
                               giovaomuontaiphong = mttcs.Giovao,
                               gioramuontaiphong = mttcs.Giora,
                               tinhtrangsachmuon = mttcs.Tinhtrangsach
                           };
            if (list_muontrataicho != null)
            {
                dgvmuontrataiphong.Rows.Clear();
                dgvmuontrataiphong.ColumnCount = 7;
                int i = 0;
                foreach (var muontaicho in list_muontrataicho)
                {
                    dgvmuontrataiphong.Rows.Add();
                    dgvmuontrataiphong.Rows[i].Cells[0].Value = muontaicho.idphongdoc;
                    dgvmuontrataiphong.Rows[i].Cells[1].Value = muontaicho.idsachmuontaiphong;
                    dgvmuontrataiphong.Rows[i].Cells[2].Value = muontaicho.iddocgiamuontaiphong;
                    dgvmuontrataiphong.Rows[i].Cells[3].Value = muontaicho.vitri;
                    dgvmuontrataiphong.Rows[i].Cells[4].Value = muontaicho.giovaomuontaiphong;
                    dgvmuontrataiphong.Rows[i].Cells[5].Value = muontaicho.gioramuontaiphong;
                    dgvmuontrataiphong.Rows[i].Cells[6].Value = muontaicho.tinhtrangsachmuon;
                    i++;
                }
            }
            else
            {
                MessageBox.Show("Không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void AddMuonTraTaiPhong()
        {
            if (Validate_ManageMuonTraTaiPhong())
            {
                using (var dbcontext = new Models.QLThuVienContext())
                {
                    try
                    {
                        Models.Muontrataicho mttcs = new Models.Muontrataicho();
                        mttcs.Idphongdoc = cbbidphongmuontra.Text;
                        mttcs.Idsach = cbbidsachmuontra.Text;
                        mttcs.Iddocgia = cbbiddocgiamuontra.Text;
                        mttcs.Vitriban = int.Parse(txtvitringoimuontra.Text);
                        mttcs.Giovao = dategiovaomuontra.Value;
                        mttcs.Giora = dategioramuontra.Value;
                        mttcs.Tinhtrangsach = txttinhtrangsachmuontra.Text;
                        dbcontext.Muontrataichos.Add(mttcs);
                        dbcontext.SaveChanges();
                        ReadFileQuanLyMuonTraTaiCho();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Dữ liệu đầu vào bảng sai");
                    }

                }
            }
        }
        private void UpdateMuonTraTaiPhong()
        {
            if (Validate_ManageMuonTraTaiPhong())
            {
                using var dbcontext = new Models.QLThuVienContext();
                //Models.Muontrasach mt = dbcontext.Muontrasaches.Where(mt => mt.Iddocgia == comboBoxMaDG.Text && mt.Idsach == comboBoxMasach.Text).FirstOrDefault();
                Models.Muontrataicho mt = (from mttcs in dbcontext.Muontrataichos
                                         where mttcs.Idphongdoc == cbbidphongmuontra.Text
                                            && mttcs.Idsach == cbbidsachmuontra.Text
                                            && mttcs.Iddocgia == cbbiddocgiamuontra.Text
                                            select mttcs).FirstOrDefault();
                if (mt != null)
                {
                    mt.Idphongdoc = cbbidphongmuontra.Text;
                    mt.Idsach = cbbidsachmuontra.Text;
                    mt.Iddocgia = cbbiddocgiamuontra.Text;
                    mt.Vitriban = int.Parse(txtvitringoimuontra.Text);
                    mt.Giovao = dategiovaomuontra.Value;
                    mt.Giora = dategioramuontra.Value;
                    mt.Tinhtrangsach = txttinhtrangsachmuontra.Text;
                    dbcontext.SaveChanges();
                    ReadFileQuanLyMuonTraTaiCho();
                }
                else
                {
                    MessageBox.Show("Không tồn tại", "Thông báo");
                }
            }           
        }
        private void DelMuonTraTaiPhong()
        {
            using var dbcontext = new Models.QLThuVienContext();
            //Models.Muontrasach id = dbcontext.Muontrasaches.Where(mt => mt.Iddocgia == comboBoxMaDG.Text && mt.Idsach == comboBoxMasach.Text).FirstOrDefault();
            Models.Muontrataicho id = (from mttcs in dbcontext.Muontrataichos 
                                       where mttcs.Idphongdoc == cbbidphongmuontra.Text 
                                          && mttcs.Idsach == cbbidsachmuontra.Text 
                                          && mttcs.Iddocgia == cbbiddocgiamuontra.Text select mttcs).FirstOrDefault();
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn xoá không", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                if (id != null)
                {
                    dbcontext.Muontrataichos.Remove(id);
                    dbcontext.SaveChanges();
                    ReadFileQuanLyMuonTraTaiCho();
                }
                else
                {
                    MessageBox.Show("Không tồn tại thông tin mượn trả này ! Bạn vui lòng kiểm tra lại thông tin", "Thông báo");
                }
            }
        }
        private bool isRadioIsEmptyMuonTraTaiPhong()
        {
            if (radidphongmuontra.Checked == false && radidsachmuontra.Checked == false && radiddocgiamuontra.Checked == false)
            {
                return true;
            }
            return false;
        }
        private void SearchMuonTraTaiPhong()
        {
            if (isRadioIsEmptyMuonTraTaiPhong())
            {
                MessageBox.Show("Bạn chưa chọn loại tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (radidphongmuontra.Checked)
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
                var list_mttcs = (from mttcs in dbcontext.Muontrataichos
                               where mttcs.Idphongdoc == cbbidphongmuontra.Text
                               join pd in dbcontext.PhongDocs on mttcs.Idphongdoc equals pd.Idphongdoc
                               join s in dbcontext.Saches on mttcs.Idsach equals s.Idsach
                               join dg in dbcontext.Docgia on mttcs.Iddocgia equals dg.Iddocgia
                               select new                       
                               {
                                   idphongmuontaiphong = mttcs.Idphongdoc,
                                   idsachmuontaiphong = mttcs.Idsach,
                                   iddocgiamuontaiphong = mttcs.Iddocgia,
                                   vitringoi = mttcs.Vitriban,
                                   giovaomuontaiphong = mttcs.Giovao,
                                   gioramuontaiphong = mttcs.Giora,
                                   tinhtrangsachmuon = mttcs.Tinhtrangsach
                               }).ToList();

                if (list_mttcs != null)
                {
                    if (list_mttcs.Count() > 0)
                    {
                        dgvmuontrataiphong.Rows.Clear();
                        dgvmuontrataiphong.ColumnCount = 7;
                        int i = 0;
                        foreach (var muontra in list_mttcs)
                        {
                            dgvmuontrataiphong.Rows.Add();
                            dgvmuontrataiphong.Rows[i].Cells[0].Value = muontra.idphongmuontaiphong;
                            dgvmuontrataiphong.Rows[i].Cells[1].Value = muontra.idsachmuontaiphong;
                            dgvmuontrataiphong.Rows[i].Cells[2].Value = muontra.iddocgiamuontaiphong;
                            dgvmuontrataiphong.Rows[i].Cells[3].Value = muontra.vitringoi;
                            dgvmuontrataiphong.Rows[i].Cells[4].Value = muontra.giovaomuontaiphong;
                            dgvmuontrataiphong.Rows[i].Cells[5].Value = muontra.gioramuontaiphong;
                            dgvmuontrataiphong.Rows[i].Cells[6].Value = muontra.tinhtrangsachmuon;
                            i++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại dữ liệu tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (radidsachmuontra.Checked)
            {
                using var dbcontext = new Models.QLThuVienContext();
                var list_mttcs = (from mttcs in dbcontext.Muontrataichos
                               where mttcs.Idsach == cbbidsachmuontra.Text
                                  join pd in dbcontext.PhongDocs on mttcs.Idphongdoc equals pd.Idphongdoc
                                  join s in dbcontext.Saches on mttcs.Idsach equals s.Idsach
                                  join dg in dbcontext.Docgia on mttcs.Iddocgia equals dg.Iddocgia
                                  select new
                               {
                                      idphongmuontaiphong = mttcs.Idphongdoc,
                                      idsachmuontaiphong = mttcs.Idsach,
                                      iddocgiamuontaiphong = mttcs.Iddocgia,
                                      vitringoi = mttcs.Vitriban,
                                      giovaomuontaiphong = mttcs.Giovao,
                                      gioramuontaiphong = mttcs.Giora,
                                      tinhtrangsachmuon = mttcs.Tinhtrangsach
                               }).ToList();

                if (list_mttcs != null)
                {
                    if (list_mttcs.Count() > 0)
                    {
                        dgvmuontrataiphong.Rows.Clear();
                        dgvmuontrataiphong.ColumnCount = 7;
                        int i = 0;
                        foreach (var muontra in list_mttcs)
                        {
                            dgvmuontrataiphong.Rows.Add();
                            dgvmuontrataiphong.Rows[i].Cells[0].Value = muontra.idphongmuontaiphong;
                            dgvmuontrataiphong.Rows[i].Cells[1].Value = muontra.idsachmuontaiphong;
                            dgvmuontrataiphong.Rows[i].Cells[2].Value = muontra.iddocgiamuontaiphong;
                            dgvmuontrataiphong.Rows[i].Cells[3].Value = muontra.vitringoi;
                            dgvmuontrataiphong.Rows[i].Cells[4].Value = muontra.giovaomuontaiphong;
                            dgvmuontrataiphong.Rows[i].Cells[5].Value = muontra.gioramuontaiphong;
                            dgvmuontrataiphong.Rows[i].Cells[6].Value = muontra.tinhtrangsachmuon;
                            i++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại dữ liệu tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (radiddocgiamuontra.Checked)
            {
                using var dbcontext = new Models.QLThuVienContext();
                var list_mttcs = (from mttcs in dbcontext.Muontrataichos
                               where mttcs.Iddocgia == cbbiddocgiamuontra.Text
                                  join pd in dbcontext.PhongDocs on mttcs.Idphongdoc equals pd.Idphongdoc
                                  join s in dbcontext.Saches on mttcs.Idsach equals s.Idsach
                                  join dg in dbcontext.Docgia on mttcs.Iddocgia equals dg.Iddocgia
                                  select new
                               {
                                      idphongmuontaiphong = mttcs.Idphongdoc,
                                      idsachmuontaiphong = mttcs.Idsach,
                                      iddocgiamuontaiphong = mttcs.Iddocgia,
                                      vitringoi = mttcs.Vitriban,
                                      giovaomuontaiphong = mttcs.Giovao,
                                      gioramuontaiphong = mttcs.Giora,
                                      tinhtrangsachmuon = mttcs.Tinhtrangsach
                                  }).ToList();

                if (list_mttcs != null)
                {
                    if (list_mttcs.Count() > 0)
                    {
                        dgvmuontrataiphong.Rows.Clear();
                        dgvmuontrataiphong.ColumnCount = 7;
                        int i = 0;
                        foreach (var muontra in list_mttcs)
                        {
                            dgvmuontrataiphong.Rows.Add();
                            dgvmuontrataiphong.Rows[i].Cells[0].Value = muontra.idphongmuontaiphong;
                            dgvmuontrataiphong.Rows[i].Cells[1].Value = muontra.idsachmuontaiphong;
                            dgvmuontrataiphong.Rows[i].Cells[2].Value = muontra.iddocgiamuontaiphong;
                            dgvmuontrataiphong.Rows[i].Cells[3].Value = muontra.vitringoi;
                            dgvmuontrataiphong.Rows[i].Cells[4].Value = muontra.giovaomuontaiphong;
                            dgvmuontrataiphong.Rows[i].Cells[5].Value = muontra.gioramuontaiphong;
                            dgvmuontrataiphong.Rows[i].Cells[6].Value = muontra.tinhtrangsachmuon;
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
        private void ThongKeMuonTaiPhong()
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
            var list_thongke = (from mtc in dbcontext.Muontrataichos
                             where mtc.Giovao.Value.Day == dategiovaomuontra.Value.Day
                                && mtc.Giora.Value.Day == dategioramuontra.Value.Day
                                join pd in dbcontext.PhongDocs on mtc.Idphongdoc equals pd.Idphongdoc
                                join s in dbcontext.Saches on mtc.Idsach equals s.Idsach
                                join dg in dbcontext.Docgia on mtc.Iddocgia equals dg.Iddocgia
                                select new
                             {
                                    idphongmuontaiphong = mtc.Idphongdoc,
                                    idsachmuontaiphong = mtc.Idsach,
                                    iddocgiamuontaiphong = mtc.Iddocgia,
                                    vitringoi = mtc.Vitriban,
                                    giovaomuontaiphong = mtc.Giovao,
                                    gioramuontaiphong = mtc.Giora,
                                    tinhtrangsachmuon = mtc.Tinhtrangsach
                                }).ToList();

            if (list_thongke != null)
            {
                dgvmuontrataiphong.Rows.Clear();
                dgvmuontrataiphong.ColumnCount = 7;
                int i = 0;
                foreach (var thongke in list_thongke)
                {
                    dgvmuontrataiphong.Rows.Add();
                    dgvmuontrataiphong.Rows[i].Cells[0].Value = thongke.idphongmuontaiphong;
                    dgvmuontrataiphong.Rows[i].Cells[1].Value = thongke.idsachmuontaiphong;
                    dgvmuontrataiphong.Rows[i].Cells[2].Value = thongke.iddocgiamuontaiphong;
                    dgvmuontrataiphong.Rows[i].Cells[3].Value = thongke.vitringoi;
                    dgvmuontrataiphong.Rows[i].Cells[4].Value = thongke.giovaomuontaiphong;
                    dgvmuontrataiphong.Rows[i].Cells[5].Value = thongke.gioramuontaiphong;
                    dgvmuontrataiphong.Rows[i].Cells[6].Value = thongke.tinhtrangsachmuon;
                    i++;
                }
            }
            else
            {
                MessageBox.Show("Không tồn tại dữ liệu có ngày này ! Vui lòng kiểm tra lại ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnhienthimuontra_Click(object sender, EventArgs e)
        {
            ReadFileQuanLyMuonTraTaiCho();
        }
        private void btnthemmuontra_Click(object sender, EventArgs e)
        {
            AddMuonTraTaiPhong();
            ClearMuonTraTaiPhong();
        }
        private void btnsuamuontra_Click(object sender, EventArgs e)
        {
            UpdateMuonTraTaiPhong();
            ClearMuonTraTaiPhong();
        }
        private void cellclick_muontrataiphong(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvmuontrataiphong.SelectedCells[0].RowIndex;
            DataGridViewRow row = dgvmuontrataiphong.Rows[index];
            cbbidphongmuontra.Text = Convert.ToString(row.Cells[0].Value);
            cbbidsachmuontra.Text = Convert.ToString(row.Cells[1].Value);
            cbbiddocgiamuontra.Text = Convert.ToString(row.Cells[2].Value);
            txtvitringoimuontra.Text = Convert.ToString(row.Cells[3].Value);
            txttinhtrangsachmuontra.Text = Convert.ToString(row.Cells[6].Value);
        }
        private void btnxoamuontra_Click(object sender, EventArgs e)
        {
            DelMuonTraTaiPhong();
            ClearMuonTraTaiPhong();
        }
        private void btnhuymuontra_Click(object sender, EventArgs e)
        {
            ClearMuonTraTaiPhong();
        }
        private void btntimkiemmuontra_Click(object sender, EventArgs e)
        {
            ClearMuonTraTaiPhong();
            SearchMuonTraTaiPhong();
        }
        private void btnthongkemuontra_Click(object sender, EventArgs e)
        {
            ThongKeMuonTaiPhong();
        }      
    }
}
