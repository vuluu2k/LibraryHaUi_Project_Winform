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
            ClearBook();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DelBook();
            ClearBook();
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
            ClearReader();
        }

        private void btnXoaDocGia_Click(object sender, EventArgs e)
        {
            DelReader();
            ClearReader();
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
                    cbMaSach_lhd.Text = "";
                    txtsoluongmua_lhd.Clear();
                    cbMaSach_lhd.Focus();
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
            ClearBookBuy();
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

        private void tabPage11_Click(object sender, EventArgs e)
        {

        }
    }
}
