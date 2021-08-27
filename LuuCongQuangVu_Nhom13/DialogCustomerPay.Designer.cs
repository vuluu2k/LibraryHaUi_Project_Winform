
namespace LuuCongQuangVu_Nhom13
{
    partial class DialogCustomerPay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogCustomerPay));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSumMoney = new System.Windows.Forms.TextBox();
            this.txtCustomerPay = new System.Windows.Forms.TextBox();
            this.txtEmployPay = new System.Windows.Forms.TextBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.checkPrint = new System.Windows.Forms.CheckBox();
            this.GetError = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GetError)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(81, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổng tiền";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(41, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số tiền khách trả";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(37, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số tiền cần trả lại";
            // 
            // txtSumMoney
            // 
            this.txtSumMoney.Enabled = false;
            this.txtSumMoney.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtSumMoney.Location = new System.Drawing.Point(148, 31);
            this.txtSumMoney.Name = "txtSumMoney";
            this.txtSumMoney.Size = new System.Drawing.Size(137, 22);
            this.txtSumMoney.TabIndex = 3;
            // 
            // txtCustomerPay
            // 
            this.txtCustomerPay.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtCustomerPay.Location = new System.Drawing.Point(148, 68);
            this.txtCustomerPay.Name = "txtCustomerPay";
            this.txtCustomerPay.Size = new System.Drawing.Size(137, 22);
            this.txtCustomerPay.TabIndex = 4;
            this.txtCustomerPay.TextChanged += new System.EventHandler(this.txtCustomerPay_TextChanged);
            this.txtCustomerPay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerPay_KeyPress);
            this.txtCustomerPay.Validating += new System.ComponentModel.CancelEventHandler(this.txtCustomerPay_Validating);
            this.txtCustomerPay.Validated += new System.EventHandler(this.txtCustomerPay_Validated);
            // 
            // txtEmployPay
            // 
            this.txtEmployPay.Enabled = false;
            this.txtEmployPay.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtEmployPay.Location = new System.Drawing.Point(148, 105);
            this.txtEmployPay.Name = "txtEmployPay";
            this.txtEmployPay.Size = new System.Drawing.Size(137, 22);
            this.txtEmployPay.TabIndex = 5;
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.Orange;
            this.btnPay.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPay.Image = global::LuuCongQuangVu_Nhom13.Properties.Resources.Tick;
            this.btnPay.Location = new System.Drawing.Point(108, 190);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(112, 36);
            this.btnPay.TabIndex = 6;
            this.btnPay.Text = "Thanh Toán";
            this.btnPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPay.UseVisualStyleBackColor = false;
            // 
            // checkPrint
            // 
            this.checkPrint.AutoSize = true;
            this.checkPrint.BackColor = System.Drawing.Color.Transparent;
            this.checkPrint.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.checkPrint.Location = new System.Drawing.Point(148, 142);
            this.checkPrint.Name = "checkPrint";
            this.checkPrint.Size = new System.Drawing.Size(82, 19);
            this.checkPrint.TabIndex = 8;
            this.checkPrint.Text = "In hoá đơn";
            this.checkPrint.UseVisualStyleBackColor = false;
            // 
            // GetError
            // 
            this.GetError.ContainerControl = this;
            this.GetError.Icon = ((System.Drawing.Icon)(resources.GetObject("GetError.Icon")));
            // 
            // DialogCustomerPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LuuCongQuangVu_Nhom13.Properties.Resources.bg_admin;
            this.ClientSize = new System.Drawing.Size(327, 248);
            this.Controls.Add(this.checkPrint);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.txtEmployPay);
            this.Controls.Add(this.txtCustomerPay);
            this.Controls.Add(this.txtSumMoney);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DialogCustomerPay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DialogCustomerPay";
            this.Load += new System.EventHandler(this.DialogCustomerPay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GetError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSumMoney;
        private System.Windows.Forms.TextBox txtCustomerPay;
        private System.Windows.Forms.TextBox txtEmployPay;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.CheckBox checkPrint;
        private System.Windows.Forms.ErrorProvider GetError;
    }
}