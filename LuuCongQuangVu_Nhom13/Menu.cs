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
        public int slmua;
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

            //load combobox thể loại sách
            load_tkcbbthloai();
            //load combobox mã sách
            load_cbbmasach();
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
                    var book = (from b in dbcontext.Saches where b.Tensach == cbMaSach_lhd.Text select b).ToList();
                    if (book.Count() > 1)
                    {
                        GetError.SetError(cbMaSach_lhd, "Tên sách này đang có hơn một mã sách, vui lòng nhập bằng mã!");
                        cbMaSach_lhd.Focus();
                        cbMaSach_lhd.SelectAll();
                        return false;
                    }
                    else if (book.Count()==0)
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
                ClearBook();
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
            var tlbooks = (from tlbook in dbcontext.Thanhlisaches where tlbook.Idsach == txtmasach.Text select tlbook).ToList();
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
                    if (tlbooks != null)
                    {
                        dbcontext.Thanhlisaches.RemoveRange(tlbooks);
                    }
                    dbcontext.Saches.Remove(id);
                    dbcontext.SaveChanges();
                    ReadFile();
                    ClearBook();
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
                ClearReader();
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
                    ClearReader();
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
                bool check=true;
                int index_insert=0;
                for (int i = 0; i < dgvLHD.RowCount - 1; i++)
                {
                    index_insert = i;
                    if (dgvLHD.Rows[i].Cells[0].Value.ToString() == book.Idsach)
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
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
                    ClearBookBuy();
                    //MessageBox.Show(dgvLHD.RowCount.ToString());
                }
                else
                {
                    DialogResult confim= MessageBox.Show("Sách đã được thêm từ trước!\nYes.Để thay đổi số lượng\nNo.Để quay lại", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (confim == DialogResult.Yes)
                    {
                        using (DialogUpdateLHD DialogCustom = new DialogUpdateLHD())
                        {
                            DialogCustom.Text = dgvLHD.Rows[index_insert].Cells[0].Value.ToString();
                            if (DialogCustom.ShowDialog() == DialogResult.OK)
                            {
                                dgvLHD.Rows[index_insert].Cells[2].Value = DialogCustom.TheValue;
                                dgvLHD.Rows[index_insert].Cells[4].Value = DialogCustom.TheValue * double.Parse(dgvLHD.Rows[index_insert].Cells[3].Value.ToString());
                                //MessageBox.Show(DialogCustom.TheValue.ToString());
                            }
                        }
                    }
                }
            }
        }
        private void UpdateBookBuy()
        {
            if (Validate_LHD_InforBuyBook())
            {
                Models.Sach book = (from b in dbcontext.Saches where b.Idsach == cbMaSach_lhd.SelectedValue.ToString() select b).FirstOrDefault();
                dgvLHD.ColumnCount = 5;
                dgvLHD.Rows[dgvLHD.SelectedCells[0].RowIndex].Cells[0].Value = book.Idsach;
                dgvLHD.Rows[dgvLHD.SelectedCells[0].RowIndex].Cells[1].Value = book.Tensach;
                dgvLHD.Rows[dgvLHD.SelectedCells[0].RowIndex].Cells[2].Value = txtsoluongmua_lhd.Text;
                dgvLHD.Rows[dgvLHD.SelectedCells[0].RowIndex].Cells[3].Value = book.Giasach;
                dgvLHD.Rows[dgvLHD.SelectedCells[0].RowIndex].Cells[4].Value = int.Parse(txtsoluongmua_lhd.Text) * book.Giasach;
            }
        }
        private void DelBookBuy()
        {
            DialogResult confim = MessageBox.Show("Bạn muốn xoá tên sách: "+dgvLHD.Rows[dgvLHD.SelectedCells[0].RowIndex].Cells[1].Value.ToString()+" ra khỏi danh sách nhập bán", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confim == DialogResult.Yes)
            {
                dgvLHD.Rows.RemoveAt(dgvLHD.SelectedCells[0].RowIndex);
                ClearBookBuy();
            }
        }
        private void CreateBill()
        {
            if (Validate_LHD_InforHD())
            {
                Models.Account acc = (Models.Account)this.Tag;
                Models.HoaDon hd = new Models.HoaDon();
                hd.MaHd = txtMaHD.Text;
                hd.Iddocgia = cbMaDG.Text;
                hd.Usename = acc.Usename;
                hd.NgayLap = dtimeNgayLap.Value;
                dbcontext.HoaDons.Add(hd);
                for (int i = 0; i < dgvLHD.RowCount-1; i++)
                {
                    //if (dgvLHD.Rows[i].Cells[0].Value == "")
                    //{
                    //    dgvLHD.Rows.RemoveAt(i);
                    //}
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
        private void ClearBookBuy()
        {
            cbMaSach_lhd.Text = "" ;
            txtsoluongmua_lhd.Clear();
            cbMaSach_lhd.Focus();
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
            DialogResult confim = MessageBox.Show("Bạn muốn xoá hoá đơn trên", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confim == DialogResult.Yes)
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
            if (dgvHistoryBS.RowCount == 1)
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

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }
        #region thống kê sách
        #region thống kê sách theo thể loại
        //thống kê sách theo thể loại
        private void load_tkcbbthloai()
        {
            var list_cbbtheloai = dbcontext.Saches.Select(s => s.Theloai).Distinct();
            tkcbbtheloai.DataSource = list_cbbtheloai.ToList();
            tkcbbtheloai.DisplayMember = "Theloai";
        }
        //hiển thị danh sách thể loại
        private void tkbtnhienthi_Click(object sender, EventArgs e)
        {
            //hiển thị danh sách theo thể loại
            var ds = dbcontext.Saches.Where(s => s.Theloai == tkcbbtheloai.SelectedValue.ToString()).Select(s => new
            {
                Idsach = s.Idsach,
                Tensach = s.Tensach,
                tacgia = s.Tacgia,
                soluong = s.Soluong,
                theloai = s.Theloai,
                giasach = s.Giasach,
                nhaxb = s.Nhaxuatban,
                vitri = s.Vitri
            });
            if (ds == null)
            {
                MessageBox.Show("Danh sách trống!", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tkcbbtheloai.Focus();
                tkcbbtheloai.SelectAll();
            }
            else
            {
                if (checktkcbbempty())
                {
                    tkdgvthongketheotheloai.DataSource = ds.ToList();

                    //hiển thị số lượng sách theo thể loại lên label
                    var sl = dbcontext.Saches.Count(s => s.Theloai == tkcbbtheloai.SelectedValue.ToString());
                    tklbsltheotheloai.Text = Convert.ToString(sl);

                    //chỉnh sửa độ rộng các cột
                    tkdgvthongketheotheloai.Columns[0].Width = 60;
                    tkdgvthongketheotheloai.Columns[1].Width = 200;
                    tkdgvthongketheotheloai.Columns[2].Width = 150;
                    tkdgvthongketheotheloai.Columns[3].Width = 60;
                    tkdgvthongketheotheloai.Columns[4].Width = 150;
                    tkdgvthongketheotheloai.Columns[5].Width = 60;
                    tkdgvthongketheotheloai.Columns[6].Width = 150;
                    tkdgvthongketheotheloai.Columns[7].Width = 150;
                }
            }
        }

        //đưa tên thể loại lên combobox
        private void tkdgvthongketheotheloai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = tkdgvthongketheotheloai.Rows[index];
            tkcbbtheloai.Text = Convert.ToString(row.Cells["Theloai"].Value);
        }
        //check combobox thể loại
        private bool checktkcbbempty()
        {
            var check = dbcontext.Saches.Where(s => s.Theloai == tkcbbtheloai.Text).FirstOrDefault();
            if (check == null)
            {
                errorProvider1.SetError(tkcbbtheloai, "không tồn tại thể loại này!");
                tkcbbtheloai.Focus();
                tkcbbtheloai.SelectAll();
                return false;
            }
            if (tkcbbtheloai.SelectedValue == null)
            {
                errorProvider1.SetError(tkcbbtheloai, "bạn phải chọn thể loại trong combobox");
                tkcbbtheloai.Focus();
                tkcbbtheloai.SelectAll();
                return false;
            }
            return true;
        }

        private void tkcbbtheloai_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tkcbbtheloai, "");
        }
        #endregion
        #region thống kê sách mượn nhiều
        //thống kê sách mượn nhiều
        private void button16_Click(object sender, EventArgs e)
        {
            if (sachmuonnhieu_check())
            {
                if (rbsmnthang.Checked == true)
                {
                    var check = (from m in dbcontext.Muontrasaches
                                 where m.Ngaymuon.Value.Month == tkdtpsachmuonnhieu.Value.Month
                                 && m.Ngaymuon.Value.Year == tkdtpsachmuonnhieu.Value.Year
                                 select m).ToList();
                    if (check != null)
                    {
                        if (check.Count > 0)
                        {
                            var ds = from s in dbcontext.Saches
                                     join m in dbcontext.Muontrasaches on s.Idsach equals m.Idsach
                                     where m.Ngaymuon.Value.Month == tkdtpsachmuonnhieu.Value.Month
                                     && m.Ngaymuon.Value.Year == tkdtpsachmuonnhieu.Value.Year
                                     select new { idsach = m.Idsach, tensach = s.Tensach, tacgia = s.Tacgia, theloai = s.Theloai, nxb = s.Nhaxuatban, giasach = s.Giasach, soluongmuon = m.Soluongmuon };
                            var groupsachs = (from a in ds
                                              group a by new { a.idsach, a.tensach, a.tacgia, a.theloai, a.nxb, a.giasach }
                                            into b
                                              orderby b.Sum(s => s.soluongmuon) descending
                                              select new
                                              {
                                                  idsach = b.Key.idsach,
                                                  tensach = b.Key.tensach,
                                                  tacgia = b.Key.tacgia,
                                                  theloai = b.Key.theloai,
                                                  nxb = b.Key.nxb,
                                                  giasach = b.Key.giasach,
                                                  tongslmuon = b.Sum(s => s.soluongmuon)
                                              });

                            dgvsachmuonnhieu.DataSource = groupsachs.ToList();
                        }
                        else
                        {
                            MessageBox.Show("không có sách mượn trong tháng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tkdtpsachmuonnhieu.Focus();
                        }
                    }
                    tklbtongsachmuonthang.Text = "Tổng sách mượn theo tháng " + tkdtpsachmuonnhieu.Value.Month + " là:";
                    var sachmuontheothang = dbcontext.Muontrasaches.Where(m => m.Ngaymuon.Value.Month == tkdtpsachmuonnhieu.Value.Month
                              && m.Ngaymuon.Value.Year == tkdtpsachmuonnhieu.Value.Year).Sum(s => s.Soluongmuon);
                    tklbsachmuontheothang.Text = Convert.ToString(sachmuontheothang);
                }
                else
                    if (rbsmnngay.Checked == true)
                {
                    if (tkdtpdenngay.Value.Date < tkdtptungay.Value.Date)
                    {
                        DialogResult rs = MessageBox.Show("co phải ý bạn là từ ngày " + tkdtpdenngay.Value.Day + " đến ngày " + tkdtptungay.Value.Day + " không ?", "xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rs == DialogResult.Yes)
                        {
                            DateTime tg = new DateTime();
                            tg = tkdtpdenngay.Value;
                            tkdtpdenngay.Value = tkdtptungay.Value;
                            tkdtptungay.Value = tg;
                        }
                    }
                    var check = dbcontext.Muontrasaches.Where(m => m.Ngaymuon.Value.Date <= tkdtpdenngay.Value.Date && m.Ngaymuon.Value.Date >= tkdtptungay.Value.Date).ToList();
                    if (check != null)
                    {
                        if (check.Count > 0)
                        {
                            var ds = from s in dbcontext.Saches
                                     join m in dbcontext.Muontrasaches on s.Idsach equals m.Idsach
                                     where m.Ngaymuon.Value.Date <= tkdtpdenngay.Value.Date && m.Ngaymuon.Value.Date >= tkdtptungay.Value.Date
                                     select new { idsach = m.Idsach, tensach = s.Tensach, tacgia = s.Tacgia, theloai = s.Theloai, nxb = s.Nhaxuatban, giasach = s.Giasach, soluongmuon = m.Soluongmuon };
                            var groupsachs = from a in ds
                                             group a by new { a.idsach, a.tensach, a.tacgia, a.theloai, a.nxb, a.giasach }
                                    into b
                                             orderby b.Sum(s => s.soluongmuon) descending
                                             select new
                                             {
                                                 idsach = b.Key.idsach,
                                                 tensach = b.Key.tensach,
                                                 tacgia = b.Key.tacgia,
                                                 theloai = b.Key.theloai,
                                                 nxb = b.Key.nxb,
                                                 giasach = b.Key.giasach,
                                                 tongslmuon = b.Sum(s => s.soluongmuon)
                                             };
                            dgvsachmuonnhieu.DataSource = groupsachs.ToList();
                        }
                        else
                        {
                            MessageBox.Show("không có sách mượn trong ngày này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("bạn phải chọn hiển thị theo tháng hoặc ngày", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void rbsmnthang_CheckedChanged(object sender, EventArgs e)
        {
            tklbsachmuontheothang.Visible = rbsmnthang.Checked;
            tklbtongsachmuonthang.Visible = rbsmnthang.Checked;
            label45.Visible = rbsmnthang.Checked;
        }
        private void rbsmnngay_CheckedChanged(object sender, EventArgs e)
        {
            tklbsachmuontheothang.Visible = !rbsmnngay.Checked;
            tklbtongsachmuonthang.Visible = !rbsmnngay.Checked;
            label45.Visible = !rbsmnngay.Checked;
        }
        #region bắt lỗi sách mượn nhiều
        private bool sachmuonnhieu_check()
        {
            if (tkdtpsachmuonnhieu.Value > DateTime.Now)
            {
                errorProvider1.SetError(tkdtpsachmuonnhieu, "ngày không được lớn hơn ngày hiện tại");
                tkdtpsachmuonnhieu.Focus();
                return false;
            }
            if (tkdtptungay.Value > DateTime.Now)
            {
                errorProvider1.SetError(tkdtptungay, "ngày không được lớn hơn ngày hiện tại");
                tkdtptungay.Focus();
                return false;
            }
            if (tkdtpdenngay.Value > DateTime.Now)
            {
                errorProvider1.SetError(tkdtpdenngay, "ngày không được lớn hơn ngày hiện tại");
                tkdtpdenngay.Focus();
                return false;
            }
            return true;
        }
        private void tkdtpsachmuonnhieu_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tkdtpsachmuonnhieu, "");
        }

        private void tkdtptungay_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tkdtptungay, "");
        }

        private void tkdtpdenngay_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tkdtpdenngay, "");
        }
        #endregion
        #endregion
        #region thống kê sách bán
        //thống kê sách bán
        private void button15_Click(object sender, EventArgs e)
        {
            if (sachban_check())
            {
                if (rbsachbanthang.Checked == true)
                {
                    var check = (from m in dbcontext.HoaDons
                                 where m.NgayLap.Value.Month == tkdtpsachban.Value.Month
                                 && m.NgayLap.Value.Year == tkdtpsachban.Value.Year
                                 select m).ToList();
                    if (check != null)
                    {
                        if (check.Count > 0)
                        {
                            var ds = from h in dbcontext.HoaDons
                                     join ct in dbcontext.HoaDonChiTiets on h.MaHd equals ct.MaHd
                                     join s in dbcontext.Saches on ct.Idsach equals s.Idsach
                                     where h.NgayLap.Value.Month == tkdtpsachban.Value.Month
                                     && h.NgayLap.Value.Year == tkdtpsachban.Value.Year
                                     select new { idsach = s.Idsach, tensach = s.Tensach, tacgia = s.Tacgia, theloai = s.Theloai, nxb = s.Nhaxuatban, giasach = s.Giasach, ct.SoLuongMua };
                            var groupsachs = (from a in ds
                                              group a by new { a.idsach, a.tensach, a.tacgia, a.theloai, a.nxb, a.giasach }
                                            into b
                                              orderby b.Sum(ct => ct.SoLuongMua) descending
                                              select new
                                              {
                                                  idsach = b.Key.idsach,
                                                  tensach = b.Key.tensach,
                                                  tacgia = b.Key.tacgia,
                                                  theloai = b.Key.theloai,
                                                  nxb = b.Key.nxb,
                                                  giasach = b.Key.giasach,
                                                  tongslban = b.Sum(ct => ct.SoLuongMua)
                                              });

                            tkdgvsachban.DataSource = groupsachs.ToList();
                        }
                        else
                        {
                            MessageBox.Show("không có sách bán trong tháng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tkdtpsachban.Focus();
                        }
                    }
                    tklbtongsachban.Text = "Tổng sách bán theo tháng " + tkdtpsachban.Value.Month + " là:";
                    var sachbantheothang = (from h in dbcontext.HoaDons
                                            join ct in dbcontext.HoaDonChiTiets on h.MaHd equals ct.MaHd
                                            where h.NgayLap.Value.Month == tkdtpsachban.Value.Month
                                      && h.NgayLap.Value.Year == tkdtpsachban.Value.Year
                                            select ct).Sum(s => s.SoLuongMua);
                    tklbsoluongsachban.Text = Convert.ToString(sachbantheothang);
                }
                else
                    if (rbsachbanngay.Checked == true)
                {
                    if (tkdtpsachbandenngay.Value.Date < tkdtpsachbantungay.Value.Date)
                    {
                        DialogResult rs = MessageBox.Show("co phải ý bạn là từ ngày " + tkdtpsachbandenngay.Value.Day + " đến ngày " + tkdtpsachbantungay.Value.Day + " không ?", "xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rs == DialogResult.Yes)
                        {
                            DateTime tg = new DateTime();
                            tg = tkdtpsachbandenngay.Value;
                            tkdtpsachbandenngay.Value = tkdtpsachbantungay.Value;
                            tkdtpsachbantungay.Value = tg;
                        }
                    }
                    var check = (from m in dbcontext.HoaDons
                                 where m.NgayLap.Value.Date <= tkdtpsachbandenngay.Value.Date
                                 && m.NgayLap.Value.Date >= tkdtpsachbantungay.Value.Date
                                 select m).ToList();
                    if (check != null)
                    {
                        if (check.Count > 0)
                        {
                            var ds = from h in dbcontext.HoaDons
                                     join ct in dbcontext.HoaDonChiTiets on h.MaHd equals ct.MaHd
                                     join s in dbcontext.Saches on ct.Idsach equals s.Idsach
                                     where h.NgayLap.Value.Date <= tkdtpsachbandenngay.Value.Date
                                 && h.NgayLap.Value.Date >= tkdtpsachbantungay.Value.Date
                                     select new { idsach = s.Idsach, tensach = s.Tensach, tacgia = s.Tacgia, theloai = s.Theloai, nxb = s.Nhaxuatban, giasach = s.Giasach, ct.SoLuongMua };
                            var groupsachs = from a in ds
                                             group a by new { a.idsach, a.tensach, a.tacgia, a.theloai, a.nxb, a.giasach }
                                    into b
                                             orderby b.Sum(s => s.SoLuongMua) descending
                                             select new
                                             {
                                                 idsach = b.Key.idsach,
                                                 tensach = b.Key.tensach,
                                                 tacgia = b.Key.tacgia,
                                                 theloai = b.Key.theloai,
                                                 nxb = b.Key.nxb,
                                                 giasach = b.Key.giasach,
                                                 tongslban = b.Sum(s => s.SoLuongMua)
                                             };
                            tkdgvsachban.DataSource = groupsachs.ToList();
                        }
                        else
                        {
                            MessageBox.Show("không có sách bán trong ngày này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("bạn phải chọn hiển thị theo tháng hoặc ngày", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void rbsachbanthang_CheckedChanged(object sender, EventArgs e)
        {
            tklbtongsachban.Visible = rbsachbanthang.Checked;
            tklbsoluongsachban.Visible = rbsachbanthang.Checked;
            label44.Visible = rbsachbanthang.Checked;
        }

        private void rbsachbanngay_CheckedChanged(object sender, EventArgs e)
        {
            tklbtongsachban.Visible = !rbsachbanngay.Checked;
            tklbsoluongsachban.Visible = !rbsachbanngay.Checked;
            label44.Visible = !rbsachbanngay.Checked;
        }
        #region bắt lỗi sách bán
        private bool sachban_check()
        {
            if (tkdtpsachban.Value > DateTime.Now)
            {
                errorProvider1.SetError(tkdtpsachban, "ngày không được lớn hơn ngày hiện tại");
                tkdtpsachban.Focus();
                return false;
            }
            if (tkdtpsachbantungay.Value > DateTime.Now)
            {
                errorProvider1.SetError(tkdtpsachbantungay, "ngày không được lớn hơn ngày hiện tại");
                tkdtpsachbantungay.Focus();
                return false;
            }
            if (tkdtpsachbandenngay.Value > DateTime.Now)
            {
                errorProvider1.SetError(tkdtpsachbandenngay, "ngày không được lớn hơn ngày hiện tại");
                tkdtpsachbandenngay.Focus();
                return false;
            }
            return true;
        }
        private void tkdtpsachban_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tkdtpsachban, "");
        }
        private void tkdtpsachbantungay_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tkdtpsachbantungay, "");
        }
        private void tkdtpsachbandenngay_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tkdtpsachbandenngay, "");
        }
        #endregion
        #endregion
        #region thống kê tổng thể 
        private void button1_Click(object sender, EventArgs e)
        {
            var sachs = dbcontext.Saches.Select(s => s).Count();
            tklbtongsach.Text = Convert.ToString(sachs);

            var sachdangmuon = dbcontext.Muontrasaches.Where(m => m.Ngaythuctra == null).Count();
            tklbsachdangmuon.Text = Convert.ToString(sachdangmuon);

            tklbsosachconlai.Text = Convert.ToString(sachs - sachdangmuon);
        }
        //hiển thị danh sách sách có sắp xếp theo tiêu chí được chọn
        private void button6_Click(object sender, EventArgs e)
        {
            var list = dbcontext.Saches.Select(s => new { s.Idsach, s.Tensach, s.Tacgia, s.Soluong, s.Theloai, s.Giasach, s.Nhaxuatban, s.Vitri });
            if (tkrboption1.Checked == true)
            {
                tkdgvtongthe.DataSource = list.OrderByDescending(s => s.Tensach).ToList();
            }
            else if (tkrboption2.Checked == true)
            {
                tkdgvtongthe.DataSource = list.OrderByDescending(s => s.Soluong).ToList();
            }
            else if (tkrboption3.Checked == true)
            {
                tkdgvtongthe.DataSource = list.OrderByDescending(s => s.Giasach).ToList();
            }
            else if (tkrboption4.Checked == true)
            {
                tkdgvtongthe.DataSource = list.OrderByDescending(s => s.Nhaxuatban).ToList();
            }
            else
            {
                tkdgvtongthe.DataSource = list.ToList();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tkrboption1.Checked = false;
            tkrboption2.Checked = false;
            tkrboption3.Checked = false;
            tkrboption4.Checked = false;
        }
        #endregion
        #endregion
        #region thanh lí sách
        //load combobox mã sách
        private void load_cbbmasach()
        {
            var masach = dbcontext.Saches.Select(s => s.Idsach).ToList();
            tlcbbmasach.DataSource = masach;
        }

        #region bắt lỗi thanh lí sách
        private bool thanhli_check()
        {
            if (tlcbbmasach.SelectedValue == null)
            {
                errorProvider1.SetError(tlcbbmasach, "bạn phải chọn mã trong combobox");
                tlcbbmasach.Focus();
                return false;
            }
            var checkmasach = dbcontext.Saches.Where(s => s.Idsach == tlcbbmasach.Text).SingleOrDefault();
            if (checkmasach == null)
            {
                errorProvider1.SetError(tlcbbmasach, "không có sách này trong bảng sách");
                tlcbbmasach.Focus();
                return false;
            }
            if (tlslthanhli.Text == "")
            {
                errorProvider1.SetError(tlslthanhli, "bạn phải nhập số lượng cần thanh lí");
                tlslthanhli.Focus();
                return false;
            }
            try
            {
                int.Parse(tlslthanhli.Text);
                if (int.Parse(tlslthanhli.Text) <= 0)
                {
                    errorProvider1.SetError(tlslthanhli, "số lượng thanh lí phải >0");
                    tlslthanhli.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(tlslthanhli, "số lượng thanh lí phải là một số nguyên");
                tlslthanhli.Focus();
                return false;
            }
            if (tlptthanhli.Text == "")
            {
                errorProvider1.SetError(tlptthanhli, "bạn phải nhập phần trăm giá gốc");
                tlptthanhli.Focus();
                return false;
            }
            try
            {
                double a = double.Parse(tlptthanhli.Text);
                if (a < 0 || a > 100)
                {
                    errorProvider1.SetError(tlptthanhli, "phần trăm giá từ 0 đến 100");
                    tlptthanhli.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(tlptthanhli, "phần trăm giá gốc phải là một số");
                tlptthanhli.Focus();
                return false;
            }
            if (tlcbbtinhtrang.Text == "")
            {
                errorProvider1.SetError(tlcbbtinhtrang, "bạn phải nhập/chọn tình trạng sách");
                tlcbbtinhtrang.Focus();
                return false;
            }
            return true;
        }
        private bool thankli_laphoadon()
        {
            if (tltxtmahdthanhli.Text == "")
            {
                errorProvider1.SetError(tltxtmahdthanhli, "bạn phải điền mã hóa đơn thanh lí");
                tltxtmahdthanhli.Focus();
                return false;
            }
            if (tltxtmahdthanhli.Text.Length != 4)
            {
                errorProvider1.SetError(tltxtmahdthanhli, "mã phải chứa 4 kí tự");
                tltxtmahdthanhli.Focus();
                return false;
            }
            var check_mahdtl = dbcontext.HoaDonThanhLis.Where(h => h.MaHdtl == tltxtmahdthanhli.Text).SingleOrDefault();
            if (check_mahdtl != null)
            {
                errorProvider1.SetError(tltxtmahdthanhli, "mã này đã có trong bảng hóa đơn thanh lí");
                tltxtmahdthanhli.Focus();
                return false;
            }
            if (tldtpngaylap.Value > DateTime.Now)
            {
                errorProvider1.SetError(tldtpngaylap, "ngày lập không được lớn hơn ngày hiện tại");
                tldtpngaylap.Focus();
                return false;
            }
            return true;
        }

        private void tlcbbmasach_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tlcbbmasach, "");
        }

        private void tlslthanhli_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tlslthanhli, "");
        }

        private void tlptthanhli_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tlptthanhli, "");
        }

        private void tlcbbtinhtrang_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tlcbbtinhtrang, "");
        }
        private void textBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tltxtmahdthanhli, "");
        }

        #endregion
        //thêm sách thanh lí
        private void button2_Click(object sender, EventArgs e)
        {
            if (thanhli_check())
            {
                var sl = dbcontext.Saches.Where(s => s.Idsach == tlcbbmasach.Text).Select(s => s.Soluong).SingleOrDefault();
                bool check = true;
                //int index=0;
                for (int j = 0; j < tldgvthanhli.RowCount - 1; j++)
                {
                    //index = j;
                    if (tlcbbmasach.Text == tldgvthanhli.Rows[j].Cells[0].Value.ToString())
                    {
                        tlcbbmasach.Focus();
                        check = false;
                    }
                }

                if (check)
                {
                    var soluong = dbcontext.Saches.Where(s => s.Idsach == tlcbbmasach.SelectedValue.ToString()).Select(s => s.Soluong).SingleOrDefault();
                    if (soluong < Convert.ToInt32(tlslthanhli.Text))
                    {
                        MessageBox.Show("số lượng thanh lí không được vượt quá số sách đang có của sách", "Quá số lượng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tlslthanhli.Focus();
                    }
                    else
                    if (soluong == 0)
                    {
                        MessageBox.Show("sách này đã hết", "hết", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var ds = dbcontext.Saches.Where(s => s.Idsach == tlcbbmasach.SelectedValue.ToString()).SingleOrDefault();
                        tldgvthanhli.ColumnCount = 7;
                        int i = tldgvthanhli.RowCount - 1;
                        tldgvthanhli.Rows.Add();
                        tldgvthanhli.Rows[i].Cells[0].Value = ds.Idsach;
                        tldgvthanhli.Rows[i].Cells[1].Value = ds.Tensach;
                        tldgvthanhli.Rows[i].Cells[2].Value = tlcbbtinhtrang.Text;
                        tldgvthanhli.Rows[i].Cells[3].Value = tlptthanhli.Text;
                        tldgvthanhli.Rows[i].Cells[4].Value = tlslthanhli.Text;
                        tldgvthanhli.Rows[i].Cells[5].Value = ds.Giasach;
                        tldgvthanhli.Rows[i].Cells[6].Value = ds.Giasach * Convert.ToInt32(tlslthanhli.Text) * Convert.ToDouble(tlptthanhli.Text) / 100;
                        i++;
                        tongslthanhli();
                    }
                }
                else
                {
                    MessageBox.Show("Đã tồn tại mã sách này, thay đổi thông tin và nhấn nút Sửa nếu bạn muốn", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        //sửa thông tin sách thanh lí
        private void button3_Click(object sender, EventArgs e)
        {
            if (thanhli_check())
            {
                bool check = false;
                int index = 0;
                for (int j = 0; j < tldgvthanhli.RowCount - 1; j++)
                {
                    if (tlcbbmasach.Text == tldgvthanhli.Rows[j].Cells[0].Value.ToString())
                    {
                        index = j;
                        tlcbbmasach.Focus();
                        check = true;
                    }
                }

                if (check)
                {
                    var soluong = dbcontext.Saches.Where(s => s.Idsach == tlcbbmasach.SelectedValue.ToString()).Select(s => s.Soluong).SingleOrDefault();
                    if (soluong < Convert.ToInt32(tlslthanhli.Text))
                    {
                        MessageBox.Show("số lượng thanh lí không được vượt quá số sách đang có của sách", "Quá số lượng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tlslthanhli.Focus();
                    }
                    else
                    if (soluong == 0)
                    {
                        MessageBox.Show("sách này đã hết", "hết", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var ds = dbcontext.Saches.Where(s => s.Idsach == tlcbbmasach.SelectedValue.ToString()).SingleOrDefault();
                        tldgvthanhli.ColumnCount = 7;
                        tldgvthanhli.Rows[index].Cells[0].Value = tlcbbmasach.Text;
                        tldgvthanhli.Rows[index].Cells[1].Value = ds.Tensach;
                        tldgvthanhli.Rows[index].Cells[2].Value = tlcbbtinhtrang.Text;
                        tldgvthanhli.Rows[index].Cells[3].Value = tlptthanhli.Text;
                        tldgvthanhli.Rows[index].Cells[4].Value = tlslthanhli.Text;
                        tldgvthanhli.Rows[index].Cells[5].Value = ds.Giasach;
                        tldgvthanhli.Rows[index].Cells[6].Value = ds.Giasach * Convert.ToInt32(tlslthanhli.Text) * Convert.ToDouble(tlptthanhli.Text) / 100;
                        tongslthanhli();
                    }
                }
                else
                {
                    MessageBox.Show("không có sách có mã này trong bảng thanh lí", "Trống dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //cell click
        private void tldgvthanhli_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            DataGridViewRow row = tldgvthanhli.Rows[i];
            tlcbbmasach.Text = Convert.ToString(row.Cells[0].Value);
            tlslthanhli.Text = Convert.ToString(row.Cells[4].Value);
            tlptthanhli.Text = Convert.ToString(row.Cells[3].Value);
            tlcbbtinhtrang.Text = Convert.ToString(row.Cells[2].Value);
        }
        //xóa sách khỏi bảng thanh lí
        private void button4_Click(object sender, EventArgs e)
        {
            var check = dbcontext.Saches.Where(s => s.Idsach == tlcbbmasach.Text).SingleOrDefault();
            if (check != null)
            {
                int index = 0;
                bool exist = false;
                for (int j = 0; j < tldgvthanhli.RowCount - 1; j++)
                {
                    if (tlcbbmasach.Text == tldgvthanhli.Rows[j].Cells[0].Value.ToString())
                    {
                        index = j;
                        exist = true;
                    }
                }
                if (exist)
                {
                    DialogResult rs = MessageBox.Show("bạn muốn xóa không", "xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes)
                    {
                        tldgvthanhli.Rows.RemoveAt(index);
                        tongslthanhli();
                    }
                    else
                    {
                        MessageBox.Show("bạn đã hủy xóa", "hủy xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("không có sách có mã này trong bảng thanh lí", "dữ liệu trống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("không có sách có mã này trong bảng sách", "dữ liệu trống", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //clear
        private void button5_Click(object sender, EventArgs e)
        {
            tlcbbmasach.Text = "";
            tlslthanhli.Text = "";
            tlptthanhli.Text = "";
            tlcbbtinhtrang.Text = "";
            tlcbbmasach.Focus();
        }
        //lập hóa đơn thanh lí
        private void button8_Click(object sender, EventArgs e)
        {
            if (thankli_laphoadon())
            {
                Models.Account acc = (Models.Account)this.Tag;
                Models.HoaDonThanhLi hdtl = new Models.HoaDonThanhLi();
                hdtl.MaHdtl = tltxtmahdthanhli.Text;
                hdtl.NgayLap = tldtpngaylap.Value;
                hdtl.Usename = acc.Usename;
                dbcontext.HoaDonThanhLis.Add(hdtl);
                for (int i = 0; i < tldgvthanhli.RowCount - 1; i++)
                {
                    Models.Thanhlisach tls = new Models.Thanhlisach();
                    tls.MaHdtl = hdtl.MaHdtl;
                    tls.Idsach = Convert.ToString(tldgvthanhli.Rows[i].Cells[0].Value);
                    tls.Soluong = Convert.ToInt32(tldgvthanhli.Rows[i].Cells[4].Value);
                    tls.Tinhtrangsach = Convert.ToString(tldgvthanhli.Rows[i].Cells[2].Value);
                    tls.Phantramgiaban = Convert.ToInt32(tldgvthanhli.Rows[i].Cells[3].Value);
                    Models.Sach book = (from b in dbcontext.Saches where b.Idsach == tls.Idsach select b).FirstOrDefault();
                    book.Soluong = book.Soluong - tls.Soluong;
                    dbcontext.Thanhlisaches.Add(tls);
                    // thêm lệnh update lại số lượng sách có là được
                }
                dbcontext.SaveChanges();
                MessageBox.Show("Lập hoá đơn thanh lí thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearALl();
            }
        }
        //tính tổng tiền thanh lí sách
        private void tongslthanhli()
        {
            double tong = 0;
            for (int i = 0; i < tldgvthanhli.RowCount - 1; i++)
            {
                tong += Convert.ToDouble(tldgvthanhli.Rows[i].Cells[6].Value);
            }
            tllbtongtienthanhli.Text = tong.ToString();
        }

        #endregion
        #region Mượn trả sách
        // QUản lý Mượn trả sách

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
            }
            else if (rbTrasach.Checked)
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
            comboBoxMasach.Text = "s001";
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
            if (rbMuonsach.Checked == false && rbTrasach.Checked == false)
            {
                return true;
            }
            return false;
        }




       

        private void txtSLmuon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
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

        private void comboBoxMaDG_SelectedValueChanged(object sender, EventArgs e)
        {
            Models.QLThuVienContext dbcontext = new Models.QLThuVienContext();
            if (rbTrasach.Checked)
            {
                var mts = dbcontext.Muontrasaches.Where(s => (s.Iddocgia == comboBoxMaDG.Text && s.Idsach == comboBoxMasach.Text)).FirstOrDefault();
                if (mts != null)
                {
                    txtSLmuon.Text = mts.Soluongmuon.Value.ToString();
                }
                else
                {
                    txtSLmuon.Text = "";
                }


            }
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
                              ngaymuon = m.Ngaymuon,
                              soluongmuon = m.Soluongmuon
                          };
            var sumsl = list_mt.Sum(s => s.soluongmuon);


            var ngaymuon = (from m in dbcontext.Muontrasaches
                            where m.Iddocgia == comboBoxMaDG.Text && m.Idsach == comboBoxMasach.Text
                            select m.Ngaymuon).FirstOrDefault();



            
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
                    else if (Convert.ToString(ngaytra) != "")
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
                          where m.Iddocgia == comboBoxMaDG.Text && (m.Ngaythuctra >= DateTime.Now || m.Ngaythuctra == null)
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
                else if ((sumsl + (int.Parse(txtSLmuon.Text) - slmuon)) >= 10)
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
                    else if (isBoxMTEmpty())
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
        }

        private void dgvMTsach_CellClick(object sender, DataGridViewCellEventArgs e)
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
            if (Convert.ToString(row.Cells[8].Value) == "")
            {
                dateNgaythuctra.Value = DateTime.Now;
            }
            else
            {
                dateNgaythuctra.Value = Convert.ToDateTime(row.Cells[8].Value);
            }
        }


        private void rbMTIDDG_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxMasach.Enabled = !rbMTIDDG.Checked;
            dateMTtungay.Enabled = !rbMTIDDG.Checked;
            dateMTdenngay.Enabled = !rbMTIDDG.Checked;
        }

        private void rbMTMasach_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxMaDG.Enabled = !rbMTMasach.Checked;
            dateMTtungay.Enabled = !rbMTMasach.Checked;
            dateMTdenngay.Enabled = !rbMTMasach.Checked;
        }

        private void rbMTNgaymuon_CheckedChanged(object sender, EventArgs e)
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
        #endregion

        #region Thống kê Quá Hạn 
        //------------------Thống kê Quá Hạn 
        private void ReadFileTKQH()
        {

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
                                 slmuon = m.Soluongmuon,
                                 dongia = s.Giasach,
                                 ngaymuon = m.Ngaymuon,
                                 ngayhentra = m.Ngayhentra,
                                 ngaythuctra = m.Ngaythuctra
                             }).ToList();



            if (list_tkqh != null)
            {
                dgvTKQH.Rows.Clear();
                dgvTKQH.ColumnCount = 9;
                int i = 0;
                foreach (var quahan in list_tkqh)
                {
                    dgvTKQH.Rows.Add();
                    dgvTKQH.Rows[i].Cells[0].Value = quahan.iddocgia;
                    dgvTKQH.Rows[i].Cells[1].Value = quahan.hoten;
                    dgvTKQH.Rows[i].Cells[2].Value = quahan.masach;
                    dgvTKQH.Rows[i].Cells[3].Value = quahan.tensach;
                    dgvTKQH.Rows[i].Cells[4].Value = quahan.slmuon;
                    dgvTKQH.Rows[i].Cells[5].Value = quahan.slmuon * quahan.dongia;
                    dgvTKQH.Rows[i].Cells[6].Value = quahan.ngaymuon;
                    dgvTKQH.Rows[i].Cells[7].Value = quahan.ngayhentra;
                    dgvTKQH.Rows[i].Cells[8].Value = quahan.ngaythuctra;
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
        #endregion


    }
}
