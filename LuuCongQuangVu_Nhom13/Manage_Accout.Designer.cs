
namespace LuuCongQuangVu_Nhom13
{
    partial class Manage_Accout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvAccout = new System.Windows.Forms.DataGridView();
            this.taikhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matkhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capdo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbCapDo = new System.Windows.Forms.ComboBox();
            this.lbCapDo = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbMatKhau = new System.Windows.Forms.Label();
            this.lbTaiKhoan = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnPhanLoai = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbThongBao = new System.Windows.Forms.Label();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa1 = new System.Windows.Forms.Button();
            this.btnSua1 = new System.Windows.Forms.Button();
            this.isTaiKhoan = new System.Windows.Forms.CheckBox();
            this.isMatKhau = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccout)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAccout
            // 
            this.dgvAccout.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(142)))), ((int)(((byte)(72)))));
            this.dgvAccout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAccout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccout.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.taikhoan,
            this.matkhau,
            this.capdo});
            this.dgvAccout.Location = new System.Drawing.Point(431, 51);
            this.dgvAccout.Name = "dgvAccout";
            this.dgvAccout.RowTemplate.Height = 25;
            this.dgvAccout.Size = new System.Drawing.Size(492, 329);
            this.dgvAccout.TabIndex = 10;
            this.dgvAccout.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cell_click_account);
            // 
            // taikhoan
            // 
            this.taikhoan.HeaderText = "Tài khoản";
            this.taikhoan.Name = "taikhoan";
            this.taikhoan.Width = 150;
            // 
            // matkhau
            // 
            this.matkhau.HeaderText = "Mật khẩu";
            this.matkhau.Name = "matkhau";
            this.matkhau.Width = 150;
            // 
            // capdo
            // 
            this.capdo.HeaderText = "Cấp độ";
            this.capdo.Name = "capdo";
            this.capdo.Width = 150;
            // 
            // cbCapDo
            // 
            this.cbCapDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCapDo.FormattingEnabled = true;
            this.cbCapDo.IntegralHeight = false;
            this.cbCapDo.Items.AddRange(new object[] {
            "Nhân viên",
            "Admin"});
            this.cbCapDo.Location = new System.Drawing.Point(128, 204);
            this.cbCapDo.Name = "cbCapDo";
            this.cbCapDo.Size = new System.Drawing.Size(197, 25);
            this.cbCapDo.TabIndex = 19;
            this.cbCapDo.Visible = false;
            // 
            // lbCapDo
            // 
            this.lbCapDo.AutoSize = true;
            this.lbCapDo.BackColor = System.Drawing.Color.Transparent;
            this.lbCapDo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbCapDo.Location = new System.Drawing.Point(56, 212);
            this.lbCapDo.Name = "lbCapDo";
            this.lbCapDo.Size = new System.Drawing.Size(51, 17);
            this.lbCapDo.TabIndex = 18;
            this.lbCapDo.Text = "Cấp độ";
            this.lbCapDo.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Orange;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOK.Image = global::LuuCongQuangVu_Nhom13.Properties.Resources.Tick;
            this.btnOK.Location = new System.Drawing.Point(128, 256);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(99, 39);
            this.btnOK.TabIndex = 17;
            this.btnOK.Text = "Thực thi";
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lbMatKhau
            // 
            this.lbMatKhau.AutoSize = true;
            this.lbMatKhau.BackColor = System.Drawing.Color.Transparent;
            this.lbMatKhau.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbMatKhau.Location = new System.Drawing.Point(56, 160);
            this.lbMatKhau.Name = "lbMatKhau";
            this.lbMatKhau.Size = new System.Drawing.Size(66, 17);
            this.lbMatKhau.TabIndex = 16;
            this.lbMatKhau.Text = "Mật khẩu";
            this.lbMatKhau.Visible = false;
            // 
            // lbTaiKhoan
            // 
            this.lbTaiKhoan.AutoSize = true;
            this.lbTaiKhoan.BackColor = System.Drawing.Color.Transparent;
            this.lbTaiKhoan.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTaiKhoan.Location = new System.Drawing.Point(56, 108);
            this.lbTaiKhoan.Name = "lbTaiKhoan";
            this.lbTaiKhoan.Size = new System.Drawing.Size(66, 17);
            this.lbTaiKhoan.TabIndex = 15;
            this.lbTaiKhoan.Text = "Tài khoản";
            this.lbTaiKhoan.Visible = false;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(128, 152);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(196, 25);
            this.txtMatKhau.TabIndex = 14;
            this.txtMatKhau.Visible = false;
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(128, 100);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(197, 25);
            this.txtTaiKhoan.TabIndex = 13;
            this.txtTaiKhoan.Visible = false;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Orange;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThem.Image = global::LuuCongQuangVu_Nhom13.Properties.Resources.Add;
            this.btnThem.Location = new System.Drawing.Point(43, 51);
            this.btnThem.Name = "btnThem";
            this.btnThem.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnThem.Size = new System.Drawing.Size(282, 51);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Cấp tài khoản mới";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(55, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Quản lí tài khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(68, 539);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(811, 21);
            this.label2.TabIndex = 20;
            this.label2.Text = "Khuyến cáo: không nên tạo tài khoản có quyền admin nếu không cần thiết có thể gây" +
    " mất quyền quản trị";
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.Orange;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSua.Image = global::LuuCongQuangVu_Nhom13.Properties.Resources.Edit;
            this.btnSua.Location = new System.Drawing.Point(43, 120);
            this.btnSua.Name = "btnSua";
            this.btnSua.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnSua.Size = new System.Drawing.Size(282, 52);
            this.btnSua.TabIndex = 21;
            this.btnSua.Text = "Đổi mật khẩu, Cấp độ";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Orange;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnXoa.Image = global::LuuCongQuangVu_Nhom13.Properties.Resources.Trash;
            this.btnXoa.Location = new System.Drawing.Point(42, 194);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnXoa.Size = new System.Drawing.Size(282, 52);
            this.btnXoa.TabIndex = 22;
            this.btnXoa.Text = "Xoá tài khoản";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnPhanLoai
            // 
            this.btnPhanLoai.BackColor = System.Drawing.Color.Orange;
            this.btnPhanLoai.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPhanLoai.Image = global::LuuCongQuangVu_Nhom13.Properties.Resources.Numbered_list;
            this.btnPhanLoai.Location = new System.Drawing.Point(42, 260);
            this.btnPhanLoai.Name = "btnPhanLoai";
            this.btnPhanLoai.Size = new System.Drawing.Size(282, 51);
            this.btnPhanLoai.TabIndex = 23;
            this.btnPhanLoai.Text = "Phân loại, Xoá, Đổi mật khẩu, Cấp độ";
            this.btnPhanLoai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPhanLoai.UseVisualStyleBackColor = false;
            this.btnPhanLoai.Click += new System.EventHandler(this.btnPhanLoai_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Orange;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTimKiem.Image = global::LuuCongQuangVu_Nhom13.Properties.Resources.Search;
            this.btnTimKiem.Location = new System.Drawing.Point(42, 329);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(282, 51);
            this.btnTimKiem.TabIndex = 24;
            this.btnTimKiem.Text = "Tìm kiếm, Xoá ,Đổi mật khẩu, Cấp độ";
            this.btnTimKiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Orange;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Image = global::LuuCongQuangVu_Nhom13.Properties.Resources.Delete;
            this.btnCancel.Location = new System.Drawing.Point(233, 256);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 39);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Quay lại";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbThongBao
            // 
            this.lbThongBao.AutoSize = true;
            this.lbThongBao.BackColor = System.Drawing.Color.Transparent;
            this.lbThongBao.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbThongBao.Location = new System.Drawing.Point(56, 51);
            this.lbThongBao.Name = "lbThongBao";
            this.lbThongBao.Size = new System.Drawing.Size(0, 21);
            this.lbThongBao.TabIndex = 26;
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.Orange;
            this.btnAdmin.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAdmin.Image = global::LuuCongQuangVu_Nhom13.Properties.Resources.admin1;
            this.btnAdmin.Location = new System.Drawing.Point(42, 470);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnAdmin.Size = new System.Drawing.Size(282, 47);
            this.btnAdmin.TabIndex = 27;
            this.btnAdmin.Text = "Trở về quyền quản trị admin";
            this.btnAdmin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.Orange;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDangXuat.Image = global::LuuCongQuangVu_Nhom13.Properties.Resources.Lock;
            this.btnDangXuat.Location = new System.Drawing.Point(685, 470);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(113, 47);
            this.btnDangXuat.TabIndex = 28;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Orange;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThoat.Image = global::LuuCongQuangVu_Nhom13.Properties.Resources.Exit;
            this.btnThoat.Location = new System.Drawing.Point(810, 470);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnThoat.Size = new System.Drawing.Size(113, 47);
            this.btnThoat.TabIndex = 29;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa1
            // 
            this.btnXoa1.BackColor = System.Drawing.Color.Orange;
            this.btnXoa1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnXoa1.Image = global::LuuCongQuangVu_Nhom13.Properties.Resources.Trash;
            this.btnXoa1.Location = new System.Drawing.Point(128, 301);
            this.btnXoa1.Name = "btnXoa1";
            this.btnXoa1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnXoa1.Size = new System.Drawing.Size(99, 39);
            this.btnXoa1.TabIndex = 30;
            this.btnXoa1.Text = "Xoá";
            this.btnXoa1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa1.UseVisualStyleBackColor = false;
            this.btnXoa1.Visible = false;
            this.btnXoa1.Click += new System.EventHandler(this.btnXoa1_Click);
            // 
            // btnSua1
            // 
            this.btnSua1.BackColor = System.Drawing.Color.Orange;
            this.btnSua1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSua1.Image = global::LuuCongQuangVu_Nhom13.Properties.Resources.Edit;
            this.btnSua1.Location = new System.Drawing.Point(233, 301);
            this.btnSua1.Name = "btnSua1";
            this.btnSua1.Size = new System.Drawing.Size(91, 39);
            this.btnSua1.TabIndex = 31;
            this.btnSua1.Text = "Đổi MK";
            this.btnSua1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua1.UseVisualStyleBackColor = false;
            this.btnSua1.Visible = false;
            this.btnSua1.Click += new System.EventHandler(this.btnSua1_Click);
            // 
            // isTaiKhoan
            // 
            this.isTaiKhoan.AutoSize = true;
            this.isTaiKhoan.Location = new System.Drawing.Point(331, 105);
            this.isTaiKhoan.Name = "isTaiKhoan";
            this.isTaiKhoan.Size = new System.Drawing.Size(15, 14);
            this.isTaiKhoan.TabIndex = 32;
            this.isTaiKhoan.UseVisualStyleBackColor = true;
            this.isTaiKhoan.Visible = false;
            this.isTaiKhoan.CheckedChanged += new System.EventHandler(this.isTaiKhoan_CheckedChanged);
            // 
            // isMatKhau
            // 
            this.isMatKhau.AutoSize = true;
            this.isMatKhau.Location = new System.Drawing.Point(331, 158);
            this.isMatKhau.Name = "isMatKhau";
            this.isMatKhau.Size = new System.Drawing.Size(15, 14);
            this.isMatKhau.TabIndex = 33;
            this.isMatKhau.UseVisualStyleBackColor = true;
            this.isMatKhau.Visible = false;
            this.isMatKhau.CheckedChanged += new System.EventHandler(this.isMatKhau_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Orange;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Image = global::LuuCongQuangVu_Nhom13.Properties.Resources.List;
            this.button1.Location = new System.Drawing.Point(431, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 46);
            this.button1.TabIndex = 34;
            this.button1.Text = "Đọc dữ liệu";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Manage_Accout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.BackgroundImage = global::LuuCongQuangVu_Nhom13.Properties.Resources.bg_admin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(952, 584);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.isMatKhau);
            this.Controls.Add(this.isTaiKhoan);
            this.Controls.Add(this.btnSua1);
            this.Controls.Add(this.btnXoa1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.lbThongBao);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnPhanLoai);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvAccout);
            this.Controls.Add(this.cbCapDo);
            this.Controls.Add(this.lbCapDo);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbMatKhau);
            this.Controls.Add(this.lbTaiKhoan);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTaiKhoan);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "Manage_Accout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage_Accout";
            this.Load += new System.EventHandler(this.Manage_Accout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAccout;
        private System.Windows.Forms.ComboBox cbCapDo;
        private System.Windows.Forms.Label lbCapDo;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lbMatKhau;
        private System.Windows.Forms.Label lbTaiKhoan;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnPhanLoai;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbThongBao;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa1;
        private System.Windows.Forms.Button btnSua1;
        private System.Windows.Forms.CheckBox isTaiKhoan;
        private System.Windows.Forms.CheckBox isMatKhau;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn taikhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn matkhau;
        private System.Windows.Forms.DataGridViewTextBoxColumn capdo;
    }
}