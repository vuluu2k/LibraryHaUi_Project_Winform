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
    public partial class Manage_Accout : Form
    {
        Models.QLThuVienContext dbcontext = new Models.QLThuVienContext();
        public Manage_Accout()
        {
            InitializeComponent();
        }
        #region ReadData
        private void clear()
        {
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtHoTen.Clear();
            cbCapDo.SelectedIndex = -1;
        }

        private void ReadFile()
        {
            var list_accout = dbcontext.Accounts.ToList();
            if (list_accout != null)
            {
                if (list_accout.Count() > 0)
                {
                    dgvAccout.Rows.Clear();
                    dgvAccout.ColumnCount = 4;
                    for (int i = 0; i < list_accout.Count(); i++)
                    {
                        dgvAccout.Rows.Add();
                        dgvAccout.Rows[i].Cells[0].Value = list_accout[i].Usename;
                        dgvAccout.Rows[i].Cells[1].Value = list_accout[i].Password;
                        dgvAccout.Rows[i].Cells[2].Value = list_accout[i].Tenchutaikhoan;
                        dgvAccout.Rows[i].Cells[3].Value = list_accout[i].Capdo;
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void ReadfilePhanLoai()
        {
            //var list_accout = dbcontext.Accounts.Where(a => a.Capdo == cbCapDo.Text).ToList();
            var list_accout = (from a in dbcontext.Accounts where a.Capdo == cbCapDo.Text select a).ToList();
            if (list_accout != null)
            {
                if (list_accout.Count() > 0)
                {
                    dgvAccout.Rows.Clear();
                    dgvAccout.ColumnCount = 4;
                    for (int i = 0; i < list_accout.Count(); i++)
                    {
                        dgvAccout.Rows.Add();
                        dgvAccout.Rows[i].Cells[0].Value = list_accout[i].Usename;
                        dgvAccout.Rows[i].Cells[1].Value = list_accout[i].Password;
                        dgvAccout.Rows[i].Cells[2].Value = list_accout[i].Tenchutaikhoan;
                        dgvAccout.Rows[i].Cells[3].Value = list_accout[i].Capdo;
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void Manage_Accout_Load(object sender, EventArgs e)
        {
            ReadFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadFile();
        }

        private void cell_click_account(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvAccout.SelectedCells[0].RowIndex;
            DataGridViewRow row = dgvAccout.Rows[index];
            txtTaiKhoan.Text = Convert.ToString(row.Cells[0].Value);
            txtMatKhau.Text = Convert.ToString(row.Cells[1].Value);
            txtHoTen.Text = Convert.ToString(row.Cells[2].Value);
            cbCapDo.Text = Convert.ToString(row.Cells[3].Value);
        }
        #endregion
        #region Xử lí lỗi
        private void txtTaiKhoan_Validated(object sender, EventArgs e)
        {
            GetError.SetError(txtTaiKhoan, "");
        }

        private void txtMatKhau_Validated(object sender, EventArgs e)
        {
            GetError.SetError(txtMatKhau, "");
        }

        private void txtHoTen_Validated(object sender, EventArgs e)
        {
            GetError.SetError(txtHoTen, "");
        }

        private void cbCapDo_Validated(object sender, EventArgs e)
        {
            GetError.SetError(cbCapDo, "");
        }
        private bool Validate_Account_Add()
        {
            if (txtTaiKhoan.Text == "")
            {
                GetError.SetError(txtTaiKhoan, "Bạn phải nhập tên tài khoản!");
                txtTaiKhoan.Focus();
                return false;
            }
            else
            {
                Models.Account acc = (from a in dbcontext.Accounts where a.Usename == txtTaiKhoan.Text select a).FirstOrDefault();
                if (acc != null)
                {
                    GetError.SetError(txtTaiKhoan, "Tài khoản này đã tồn tại!");
                    txtTaiKhoan.Focus();
                    txtTaiKhoan.SelectAll();
                    return false;
                }
            }
            if (txtMatKhau.Text == "")
            {
                GetError.SetError(txtMatKhau, "Bạn phải nhập mật khẩu!");
                txtMatKhau.Focus();
                return false;
            } 
            if (txtHoTen.Text == "")
            {
                GetError.SetError(txtHoTen, "Bạn phải nhập họ tên!");
                txtHoTen.Focus();
                return false;
            }
            if (cbCapDo.Text == "")
            {
                GetError.SetError(cbCapDo, "Bạn phải chọn cấp độ!");
                cbCapDo.Focus();
                return false;
            }
            return true;
        }
        private bool Validate_Account_Update()
        {
            if (txtTaiKhoan.Text == "")
            {
                GetError.SetError(txtTaiKhoan, "Bạn phải nhập tên tài khoản!");
                txtTaiKhoan.Focus();
                return false;
            }
            else
            {
                Models.Account acc = (from a in dbcontext.Accounts where a.Usename == txtTaiKhoan.Text select a).FirstOrDefault();
                if (acc == null)
                {
                    GetError.SetError(txtTaiKhoan, "Không có tên tài khoản này!");
                    txtTaiKhoan.Focus();
                    txtTaiKhoan.SelectAll();
                    return false;
                }
            }
            if (txtMatKhau.Text == "")
            {
                GetError.SetError(txtMatKhau, "Bạn phải nhập mật khẩu!");
                txtMatKhau.Focus();
                return false;
            }
            if (txtHoTen.Text == "")
            {
                GetError.SetError(txtHoTen, "Bạn phải nhập họ tên!");
                txtHoTen.Focus();
                return false;
            }
            if (cbCapDo.Text == "")
            {
                GetError.SetError(cbCapDo, "Bạn phải chọn cấp độ!");
                cbCapDo.Focus();
                return false;
            }
            return true;
        }

        #endregion
        #region Admin, Logout, Exits
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin().Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Bạn muốn đăng xuất", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                this.Hide();
                new Login().Show();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Bạn muốn thoát", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }
        #endregion
        #region Xử lí main buttons
        private void btnThem_Click(object sender, EventArgs e)
        {
            lbThongBao.Text = btnThem.Text;
            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            btnPhanLoai.Visible = false;
            btnTimKiem.Visible = false;
            lbTaiKhoan.Visible = true;
            lbMatKhau.Visible = true;
            lbHoTen.Visible = true;
            lbCapDo.Visible = true;
            txtTaiKhoan.Visible = true;
            txtMatKhau.Visible = true;
            txtHoTen.Visible = true;
            cbCapDo.Visible = true;
            btnOK.Text = "Cấp";
            btnOK.Visible = true;
            btnCancel.Visible = true;
            clear();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            lbThongBao.Text = btnSua.Text;
            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            btnPhanLoai.Visible = false;
            btnTimKiem.Visible = false;
            lbTaiKhoan.Visible = true;
            lbMatKhau.Visible = true;
            lbHoTen.Visible = true;
            lbCapDo.Visible = true;
            txtTaiKhoan.Visible = true;
            txtMatKhau.Visible = true;
            txtHoTen.Visible = true;
            cbCapDo.Visible = true;
            btnOK.Text = "Đổi";
            btnOK.Visible = true;
            btnCancel.Visible = true;
            clear();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            lbThongBao.Text = btnXoa.Text;
            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            btnPhanLoai.Visible = false;
            btnTimKiem.Visible = false;
            lbTaiKhoan.Visible = true;
            txtTaiKhoan.Visible = true;
            btnOK.Text = "Xoá";
            btnOK.Visible = true;
            btnCancel.Visible = true;
            clear();
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lbThongBao.Text = btnTimKiem.Text;
            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            btnPhanLoai.Visible = false;
            btnTimKiem.Visible = false;
            lbTaiKhoan.Visible = true;
            lbMatKhau.Visible = true;
            lbHoTen.Visible = true;
            lbCapDo.Visible = true;
            txtTaiKhoan.Visible = true;
            txtMatKhau.Visible = true;
            txtHoTen.Visible = true;
            cbCapDo.Visible = true;
            btnOK.Text = "Tìm";
            btnOK.Visible = true;
            btnCancel.Visible = true;
            btnXoa1.Visible = true;
            btnSua1.Visible = true;
            rdTaiKhoan.Visible = true;
            rdMatKhau.Visible = true;
            rdHoTen.Visible = true;
            clear();
        }
        private void btnPhanLoai_Click(object sender, EventArgs e)
        {
            lbThongBao.Text = btnPhanLoai.Text;
            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            btnPhanLoai.Visible = false;
            btnTimKiem.Visible = false;
            lbTaiKhoan.Visible = true;
            lbMatKhau.Visible = true;
            lbHoTen.Visible = true;
            lbCapDo.Visible = true;
            txtTaiKhoan.Visible = true;
            txtMatKhau.Visible = true;
            txtHoTen.Visible = true;
            cbCapDo.Visible = true;
            btnOK.Text = "Thực thi";
            btnOK.Visible = true;
            btnCancel.Visible = true;
            btnXoa1.Visible = true;
            btnSua1.Visible = true;
            clear();
        }
        #endregion
        #region Xử lí child buttons
        private void btnCancel_Click(object sender, EventArgs e)
        {
            lbThongBao.Text = "";
            btnThem.Visible = true;
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnPhanLoai.Visible = true;
            btnTimKiem.Visible = true;
            lbTaiKhoan.Visible = false;
            lbMatKhau.Visible = false;
            lbHoTen.Visible = false;
            lbCapDo.Visible = false;
            txtTaiKhoan.Visible = false;
            txtMatKhau.Visible = false;
            txtHoTen.Visible = false;
            cbCapDo.Visible = false;
            btnOK.Visible = false;
            btnCancel.Visible = false;
            rdTaiKhoan.Visible = false;
            rdMatKhau.Visible = false;
            rdHoTen.Visible = false;
            btnXoa1.Visible = false;
            btnSua1.Visible = false;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lbThongBao.Text == btnThem.Text)
            {
                if(Validate_Account_Add())
                {
                    Models.Account acc = new Models.Account();
                    acc.Usename = txtTaiKhoan.Text;
                    acc.Password = txtMatKhau.Text;
                    acc.Tenchutaikhoan = txtHoTen.Text;
                    acc.Capdo = cbCapDo.Text;
                    dbcontext.Accounts.Add(acc);
                    dbcontext.SaveChanges();
                    ReadFile();
                    clear();
                }
            }
            else if (lbThongBao.Text == btnSua.Text)
            {
                if (Validate_Account_Update())
                {
                    //Models.Account acc = dbcontext.Accounts.Where(a => a.Usename == txtTaiKhoan.Text).FirstOrDefault();
                    Models.Account acc = (from a in dbcontext.Accounts where a.Usename == txtTaiKhoan.Text select a).FirstOrDefault();
                    acc.Usename = txtTaiKhoan.Text;
                    acc.Password = txtMatKhau.Text;
                    acc.Tenchutaikhoan = txtHoTen.Text;
                    acc.Capdo = cbCapDo.Text;
                    dbcontext.SaveChanges();
                    ReadFile();
                }   
            }
            else if (lbThongBao.Text==btnXoa.Text)
            {
                //Models.Account acc = dbcontext.Accounts.Where(a => a.Usename == txtTaiKhoan.Text).FirstOrDefault();
                Models.Account acc = (from a in dbcontext.Accounts where a.Usename == txtTaiKhoan.Text select a).FirstOrDefault();
                DialogResult confirm = MessageBox.Show("Bạn muốn xoá không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm==DialogResult.Yes)
                {
                    if (acc != null)
                    {
                        dbcontext.Accounts.Remove(acc);
                        dbcontext.SaveChanges();
                        ReadFile();
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Tên tài khoản không tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }  
            }
            else if (lbThongBao.Text==btnPhanLoai.Text)
            {
                //var list_accout = dbcontext.Accounts.Where(a=>a.Capdo==cbCapDo.Text).ToList();
                var list_accout = (from a in dbcontext.Accounts where a.Capdo==cbCapDo.Text select a).ToList();
                if (list_accout != null)
                {
                    if (list_accout.Count() > 0)
                    {
                        dgvAccout.Rows.Clear();
                        dgvAccout.ColumnCount = 8;
                        for (int i = 0; i < list_accout.Count(); i++)
                        {
                            dgvAccout.Rows.Add();
                            dgvAccout.Rows[i].Cells[0].Value = list_accout[i].Usename;
                            dgvAccout.Rows[i].Cells[1].Value = list_accout[i].Password;
                            dgvAccout.Rows[i].Cells[2].Value = list_accout[i].Tenchutaikhoan;
                            dgvAccout.Rows[i].Cells[3].Value = list_accout[i].Capdo;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (lbThongBao.Text==btnTimKiem.Text)
            {
                if (rdTaiKhoan.Checked == false && rdMatKhau.Checked == false && rdHoTen.Checked==false)
                {
                    MessageBox.Show("Bạn vui chọn mục tìm kiếm theo Tài khoản / Mật khẩu/ Họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (rdTaiKhoan.Checked)
                {
                    if (txtTaiKhoan.Text == "")
                    {
                        GetError.SetError(txtTaiKhoan, "Bạn chưa nhập tên tài khoản cho việc tìm kiếm!");
                        txtTaiKhoan.Focus();
                    }
                    else
                    {
                        //var list_accout = dbcontext.Accounts.Where(a => a.Usename == txtTaiKhoan.Text).ToList();
                        var list_accout = (from a in dbcontext.Accounts where a.Usename == txtTaiKhoan.Text select a ).ToList();
                        if (list_accout != null)
                        {
                            if (list_accout.Count() > 0)
                            {
                                dgvAccout.Rows.Clear();
                                dgvAccout.ColumnCount = 4;
                                for (int i = 0; i < list_accout.Count(); i++)
                                {
                                    dgvAccout.Rows.Add();
                                    dgvAccout.Rows[i].Cells[0].Value = list_accout[i].Usename;
                                    dgvAccout.Rows[i].Cells[1].Value = list_accout[i].Password;
                                    dgvAccout.Rows[i].Cells[2].Value = list_accout[i].Tenchutaikhoan;
                                    dgvAccout.Rows[i].Cells[3].Value = list_accout[i].Capdo;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else if (rdMatKhau.Checked)
                {
                    if (txtMatKhau.Text == "")
                    {
                        GetError.SetError(txtMatKhau, "Bạn chưa nhập mật khẩu cho việc tìm kiếm!");
                        txtMatKhau.Focus();
                    }
                    else
                    {
                        //var list_accout = dbcontext.Accounts.Where(a => a.Password == txtMatKhau.Text).ToList();
                        var list_accout = (from a in dbcontext.Accounts where a.Password == txtMatKhau.Text select a).ToList();
                        if (list_accout != null)
                        {
                            if (list_accout.Count() > 0)
                            {
                                dgvAccout.Rows.Clear();
                                dgvAccout.ColumnCount = 4;
                                for (int i = 0; i < list_accout.Count(); i++)
                                {
                                    dgvAccout.Rows.Add();
                                    dgvAccout.Rows[i].Cells[0].Value = list_accout[i].Usename;
                                    dgvAccout.Rows[i].Cells[1].Value = list_accout[i].Password;
                                    dgvAccout.Rows[i].Cells[2].Value = list_accout[i].Tenchutaikhoan;
                                    dgvAccout.Rows[i].Cells[3].Value = list_accout[i].Capdo;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else if (rdHoTen.Checked)
                {
                    if (txtHoTen.Text == "")
                    {
                        GetError.SetError(txtHoTen, "Bạn chưa nhập họ tên tài khoản cho việc tìm kiếm!");
                        txtHoTen.Focus();
                    }
                    else
                    {
                        //var list_accout = dbcontext.Accounts.Where(a => a.Password == txtMatKhau.Text).ToList();
                        var list_accout = (from a in dbcontext.Accounts where a.Password == txtMatKhau.Text select a).ToList();
                        if (list_accout != null)
                        {
                            if (list_accout.Count() > 0)
                            {
                                dgvAccout.Rows.Clear();
                                dgvAccout.ColumnCount = 4;
                                for (int i = 0; i < list_accout.Count(); i++)
                                {
                                    dgvAccout.Rows.Add();
                                    dgvAccout.Rows[i].Cells[0].Value = list_accout[i].Usename;
                                    dgvAccout.Rows[i].Cells[1].Value = list_accout[i].Password;
                                    dgvAccout.Rows[i].Cells[2].Value = list_accout[i].Tenchutaikhoan;
                                    dgvAccout.Rows[i].Cells[3].Value = list_accout[i].Capdo;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }

        }
        private void btnXoa1_Click(object sender, EventArgs e)
        {
            //Models.Account acc = dbcontext.Accounts.Where(a => a.Usename == txtTaiKhoan.Text).FirstOrDefault();
            Models.Account acc = (from a in dbcontext.Accounts where a.Usename == txtTaiKhoan.Text select a).FirstOrDefault();
            DialogResult confirm = MessageBox.Show("Bạn muốn xoá không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                if (acc != null)
                {
                    dbcontext.Accounts.Remove(acc);
                    dbcontext.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản không tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (lbThongBao.Text == btnPhanLoai.Text)
            {
                ReadfilePhanLoai();
            }
            else
            {
                ReadFile();
            }
            
        }
        private void btnSua1_Click(object sender, EventArgs e)
        {
            if (Validate_Account_Update())
            {
                //Models.Account acc = dbcontext.Accounts.Where(a => a.Usename == txtTaiKhoan.Text).FirstOrDefault();
                Models.Account acc = (from a in dbcontext.Accounts where a.Usename == txtTaiKhoan.Text select a).FirstOrDefault();
                acc.Usename = txtTaiKhoan.Text;
                acc.Password = txtMatKhau.Text;
                acc.Tenchutaikhoan = txtHoTen.Text;
                acc.Capdo = cbCapDo.Text;
                dbcontext.SaveChanges();
            }
            if (lbThongBao.Text==btnPhanLoai.Text)
            {
                ReadfilePhanLoai();
            }
            else
            {
                ReadFile();
            }
         
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            clear();
        }
        #endregion

    }
}
