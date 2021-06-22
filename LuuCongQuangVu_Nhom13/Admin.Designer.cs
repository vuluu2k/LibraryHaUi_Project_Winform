
namespace LuuCongQuangVu_Nhom13
{
    partial class Admin
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnThuVien = new System.Windows.Forms.Button();
            this.btnQLTaiKhoan = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(119, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quyền truy cập Admin";
            // 
            // btnThuVien
            // 
            this.btnThuVien.BackColor = System.Drawing.Color.Orange;
            this.btnThuVien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThuVien.Location = new System.Drawing.Point(31, 83);
            this.btnThuVien.Name = "btnThuVien";
            this.btnThuVien.Size = new System.Drawing.Size(439, 59);
            this.btnThuVien.TabIndex = 1;
            this.btnThuVien.Text = "Truy cập vào quản lí thư viện";
            this.btnThuVien.UseVisualStyleBackColor = false;
            this.btnThuVien.Click += new System.EventHandler(this.btnThuVien_Click);
            // 
            // btnQLTaiKhoan
            // 
            this.btnQLTaiKhoan.BackColor = System.Drawing.Color.Orange;
            this.btnQLTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnQLTaiKhoan.Location = new System.Drawing.Point(31, 148);
            this.btnQLTaiKhoan.Name = "btnQLTaiKhoan";
            this.btnQLTaiKhoan.Size = new System.Drawing.Size(439, 57);
            this.btnQLTaiKhoan.TabIndex = 2;
            this.btnQLTaiKhoan.Text = "Truy cập vào quản lí tài khoản";
            this.btnQLTaiKhoan.UseVisualStyleBackColor = false;
            this.btnQLTaiKhoan.Click += new System.EventHandler(this.btnQLTaiKhoan_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Orange;
            this.btnThoat.Image = global::LuuCongQuangVu_Nhom13.Properties.Resources.Exit;
            this.btnThoat.Location = new System.Drawing.Point(273, 237);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnThoat.Size = new System.Drawing.Size(96, 42);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.Orange;
            this.btnDangXuat.Image = global::LuuCongQuangVu_Nhom13.Properties.Resources.Lock;
            this.btnDangXuat.Location = new System.Drawing.Point(159, 237);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(96, 42);
            this.btnDangXuat.TabIndex = 4;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.BackgroundImage = global::LuuCongQuangVu_Nhom13.Properties.Resources.bg_admin;
            this.ClientSize = new System.Drawing.Size(509, 325);
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnQLTaiKhoan);
            this.Controls.Add(this.btnThuVien);
            this.Controls.Add(this.label1);
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThuVien;
        private System.Windows.Forms.Button btnQLTaiKhoan;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnDangXuat;
    }
}