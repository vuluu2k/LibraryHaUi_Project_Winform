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
    public partial class DialogCustomerPay : Form
    {
        public DialogCustomerPay()
        {
            InitializeComponent();
        }
        public double moneyCustomer
        {
            get { return Convert.ToDouble(txtCustomerPay.Text);}
        }
        public bool checkPrinter
        {
            get { return checkPrint.Checked ? true : false; }
        }
        private void DialogCustomerPay_Load(object sender, EventArgs e)
        {
            txtSumMoney.Text = (string)this.Tag;
            btnPay.DialogResult = DialogResult.OK;
        }
        private void txtCustomerPay_TextChanged(object sender, EventArgs e)
        {
            double EmployPay = Convert.ToDouble(txtCustomerPay.Text) - Convert.ToDouble(txtSumMoney.Text);
            txtEmployPay.Text = EmployPay.ToString();
        }

        private void txtCustomerPay_Validated(object sender, EventArgs e)
        {
            GetError.SetError(txtCustomerPay, "");
        }
        private void txtCustomerPay_Validating(object sender, CancelEventArgs e)
        {
            if (txtCustomerPay.Text == "")
            {
                GetError.SetError(txtCustomerPay, "Bạn cần nhập số tiền khách trả");
                e.Cancel = true;
            }
            else
            {
                try
                {
                    double CustomerPay = Convert.ToDouble(txtCustomerPay.Text);
                    if (CustomerPay < Convert.ToDouble(txtSumMoney.Text))
                    {
                        GetError.SetError(txtCustomerPay, "Số tiền nhập phải lớn hơn tổng tiền phải trả!");
                        e.Cancel = true;
                    }
                }
                catch (Exception)
                {
                    GetError.SetError(txtCustomerPay, "Bạn phải nhập là số thực!");
                    e.Cancel = true;
                }
            }
        }

        private void txtCustomerPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
