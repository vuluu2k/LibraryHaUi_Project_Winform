
namespace LuuCongQuangVu_Nhom13
{
    partial class Login
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
            this.txtTaikhoan = new System.Windows.Forms.TextBox();
            this.txtMatkhau = new System.Windows.Forms.TextBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(173, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng nhập";
            // 
            // txtTaikhoan
            // 
            this.txtTaikhoan.BackColor = System.Drawing.Color.OldLace;
            this.txtTaikhoan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTaikhoan.Location = new System.Drawing.Point(137, 137);
            this.txtTaikhoan.Name = "txtTaikhoan";
            this.txtTaikhoan.PlaceholderText = "Tài khoản";
            this.txtTaikhoan.Size = new System.Drawing.Size(198, 29);
            this.txtTaikhoan.TabIndex = 3;
            // 
            // txtMatkhau
            // 
            this.txtMatkhau.BackColor = System.Drawing.Color.OldLace;
            this.txtMatkhau.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMatkhau.Location = new System.Drawing.Point(137, 197);
            this.txtMatkhau.Name = "txtMatkhau";
            this.txtMatkhau.PasswordChar = '*';
            this.txtMatkhau.PlaceholderText = "Mật khẩu";
            this.txtMatkhau.Size = new System.Drawing.Size(198, 29);
            this.txtMatkhau.TabIndex = 4;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.Wheat;
            this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDangNhap.Image = global::LuuCongQuangVu_Nhom13.Properties.Resources.Unlock;
            this.btnDangNhap.Location = new System.Drawing.Point(137, 262);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(99, 38);
            this.btnDangNhap.TabIndex = 5;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Wheat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThoat.Image = global::LuuCongQuangVu_Nhom13.Properties.Resources.Exit;
            this.btnThoat.Location = new System.Drawing.Point(242, 262);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnThoat.Size = new System.Drawing.Size(93, 38);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::LuuCongQuangVu_Nhom13.Properties.Resources.Users;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(102, 137);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 29);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::LuuCongQuangVu_Nhom13.Properties.Resources.key_login;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(102, 197);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 29);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(163)))), ((int)(((byte)(103)))));
            this.BackgroundImage = global::LuuCongQuangVu_Nhom13.Properties.Resources.bg_Login;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(497, 512);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.txtMatkhau);
            this.Controls.Add(this.txtTaikhoan);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.SaddleBrown;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(163)))), ((int)(((byte)(103)))));
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTaikhoan;
        private System.Windows.Forms.TextBox txtMatkhau;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}