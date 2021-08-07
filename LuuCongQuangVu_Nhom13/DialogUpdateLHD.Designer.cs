
namespace LuuCongQuangVu_Nhom13
{
    partial class DialogUpdateLHD
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogUpdateLHD));
            this.txtSLmua = new System.Windows.Forms.TextBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.GetError = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbTenSach = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbMaSach = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GetError)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSLmua
            // 
            this.txtSLmua.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtSLmua.Location = new System.Drawing.Point(23, 81);
            this.txtSLmua.Name = "txtSLmua";
            this.txtSLmua.PlaceholderText = "Số lượng sửa";
            this.txtSLmua.Size = new System.Drawing.Size(242, 22);
            this.txtSLmua.TabIndex = 0;
            this.txtSLmua.Validating += new System.ComponentModel.CancelEventHandler(this.txtSLmua_Validating);
            this.txtSLmua.Validated += new System.EventHandler(this.txtSLmua_Validated);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.Orange;
            this.btnXacNhan.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnXacNhan.Image = global::LuuCongQuangVu_Nhom13.Properties.Resources.Tick;
            this.btnXacNhan.Location = new System.Drawing.Point(70, 121);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnXacNhan.Size = new System.Drawing.Size(132, 32);
            this.btnXacNhan.TabIndex = 1;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // GetError
            // 
            this.GetError.ContainerControl = this;
            this.GetError.Icon = ((System.Drawing.Icon)(resources.GetObject("GetError.Icon")));
            // 
            // lbTenSach
            // 
            this.lbTenSach.AutoSize = true;
            this.lbTenSach.BackColor = System.Drawing.Color.Transparent;
            this.lbTenSach.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTenSach.Location = new System.Drawing.Point(83, 50);
            this.lbTenSach.Name = "lbTenSach";
            this.lbTenSach.Size = new System.Drawing.Size(40, 15);
            this.lbTenSach.TabIndex = 3;
            this.lbTenSach.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã sách:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(22, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên sách:";
            // 
            // lbMaSach
            // 
            this.lbMaSach.AutoSize = true;
            this.lbMaSach.BackColor = System.Drawing.Color.Transparent;
            this.lbMaSach.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbMaSach.Location = new System.Drawing.Point(83, 20);
            this.lbMaSach.Name = "lbMaSach";
            this.lbMaSach.Size = new System.Drawing.Size(40, 15);
            this.lbMaSach.TabIndex = 6;
            this.lbMaSach.Text = "label3";
            // 
            // DialogUpdateLHD
            // 
            this.AcceptButton = this.btnXacNhan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LuuCongQuangVu_Nhom13.Properties.Resources.bg_admin;
            this.ClientSize = new System.Drawing.Size(287, 165);
            this.Controls.Add(this.lbMaSach);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbTenSach);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txtSLmua);
            this.Name = "DialogUpdateLHD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UpdateLoop";
            this.Load += new System.EventHandler(this.DialogUpdateLHD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GetError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSLmua;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.ErrorProvider GetError;
        private System.Windows.Forms.Label lbTenSach;
        private System.Windows.Forms.Label lbMaSach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}