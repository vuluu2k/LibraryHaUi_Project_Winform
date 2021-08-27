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
    public partial class DialogInforHD : Form
    {
        Models.QLThuVienContext dbcontext = new Models.QLThuVienContext();
        public DialogInforHD()
        {
            InitializeComponent();
        }

        private void DialogInforHD_Load(object sender, EventArgs e)
        {
            List<String> hd = (List<string>)this.Tag;
            String namesv = (from code in dbcontext.Docgia where code.Iddocgia == hd[1] select code.Hoten).FirstOrDefault();
            String namegv = (from code in dbcontext.Docgia where code.Iddocgia == hd[2] select code.Hoten).FirstOrDefault();
            var result = (from hdct in dbcontext.HoaDonChiTiets
                          join book in dbcontext.Saches on hdct.Idsach equals book.Idsach
                          where hdct.MaHd == hd[0]
                          select new
                          {
                              idBook = book.Idsach,
                              nameBook = book.Tensach,
                              slBook = hdct.SoLuongMua,
                              dgBook = book.Giasach,
                              sumBook = hdct.SoLuongMua * book.Giasach
                          }).ToList();
            if (hd[1] == "")
            {
                masv.Visible = false;
                magv.Visible = false;
                tensv.Visible = false;
                tengv.Visible = false;
            }
            dgvInforHD.Rows.Clear();
            dgvInforHD.ColumnCount = 6;
            int index = 0;
            foreach(var item in result)
            {
                dgvInforHD.Rows.Add();
                dgvInforHD.Rows[index].Cells[0].Value=item.idBook;
                dgvInforHD.Rows[index].Cells[1].Value=item.nameBook;
                dgvInforHD.Rows[index].Cells[2].Value=item.slBook;
                dgvInforHD.Rows[index].Cells[3].Value=item.dgBook;
                dgvInforHD.Rows[index].Cells[4].Value=item.sumBook;
                index++;
            }
            lbMaHD.Text = hd[0];
            lbNguoiLap.Text = hd[4];
            lbNgayLap.Text = hd[5];
            lbMaSV.Text = hd[1];
            lbTenSV.Text = namesv!="" ? namesv : "";
            lbMaGV.Text = hd[2];
            lbTenGV.Text = namegv!="" ? namegv : "";
            lbTongTT.Text = hd[3];
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (lbMaSV.Text == "")
            {

                var result = (from hdct in dbcontext.HoaDonChiTiets
                              join book in dbcontext.Saches on hdct.Idsach equals book.Idsach
                              where hdct.MaHd == lbMaHD.Text
                              select new
                              {
                                  idBook = book.Idsach,
                                  nameBook = book.Tensach,
                                  slBook = hdct.SoLuongMua,
                                  dgBook = book.Giasach,
                                  sumBook = hdct.SoLuongMua * book.Giasach
                              }).ToList();
                var w = printDocument1.DefaultPageSettings.PaperSize.Width;
                e.Graphics.DrawString("Thư viện Trường Đại Học Công Nghiệp Hà Nội".ToUpper(), new Font("Courier New", 16, FontStyle.Bold), Brushes.Black, new Point(w / 2 - 280, 40));
                e.Graphics.DrawString("Hoá đơn thanh toán".ToUpper(), new Font("Courier New", 14, FontStyle.Bold), Brushes.Black, new Point(w / 2 - 100, 80));
                e.Graphics.DrawString("Mã hoá đơn: " + lbMaHD.Text, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(50, 120));
                e.Graphics.DrawString("Người lập: " + lbNguoiLap.Text, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(50, 140));
                e.Graphics.DrawString("Ngày lập: " + lbNgayLap.Text, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(50, 160));
                Pen penBlack = new Pen(Color.Black, 1);
                var y = 180;
                Point p1 = new Point(10, y);
                Point p2 = new Point(w - 10, y);
                e.Graphics.DrawLine(penBlack, p1, p2);
                y += 20;
                e.Graphics.DrawString("STT", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(20, y));
                e.Graphics.DrawString("Mã sách", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(80, y));
                e.Graphics.DrawString("Tên sách", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(180, y));
                e.Graphics.DrawString("Số lượng", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
                e.Graphics.DrawString("Đơn giá", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 150, y));
                e.Graphics.DrawString("Thành tiền", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(w - 150, y));

                int i = 1;
                y += 25;

                foreach (var item in result)
                {
                    e.Graphics.DrawString(i++.ToString(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(20, y));
                    e.Graphics.DrawString(item.idBook, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(80, y));
                    e.Graphics.DrawString(item.nameBook, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(180, y));
                    e.Graphics.DrawString(item.slBook.ToString(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
                    e.Graphics.DrawString(item.dgBook.ToString(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 150, y));
                    e.Graphics.DrawString(item.sumBook.ToString(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(w - 150, y));
                    y += 20;
                }
                y += 20;
                p1 = new Point(10, y);
                p2 = new Point(w - 10, y);
                e.Graphics.DrawLine(penBlack, p1, p2);
                y += 20;
                e.Graphics.DrawString("Tổng tiền t.toán".ToUpper(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(20, y));
                e.Graphics.DrawString(lbTongTT.Text, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(w - 150, y));
                //y += 20;
                //e.Graphics.DrawString("Tiền độc giả trả".ToUpper(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(20, y));
                //e.Graphics.DrawString(moneyCustomer, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(w - 150, y));
                //y += 20;
                //e.Graphics.DrawString("Tiền trả lại".ToUpper(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(20, y));
                //e.Graphics.DrawString((Convert.ToDouble(moneyCustomer) - Convert.ToDouble(sumMoneyHD)).ToString(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(w - 150, y));
            }
            else
            {
                var result = (from hdct in dbcontext.HoaDonChiTiets
                              join book in dbcontext.Saches on hdct.Idsach equals book.Idsach
                              where hdct.MaHd == lbMaHD.Text
                              select new
                              {
                                  idBook = book.Idsach,
                                  nameBook = book.Tensach,
                                  slBook = hdct.SoLuongMua,
                                  dgBook = book.Giasach,
                                  sumBook = hdct.SoLuongMua * book.Giasach
                              }).ToList();
                var w = printDocument1.DefaultPageSettings.PaperSize.Width;
                e.Graphics.DrawString("Thư viện Trường Đại Học Công Nghiệp Hà Nội".ToUpper(), new Font("Courier New", 14, FontStyle.Bold), Brushes.Black, new Point(w / 2 - 280, 40));
                e.Graphics.DrawString("Hoá đơn thanh toán".ToUpper(), new Font("Courier New", 14, FontStyle.Bold), Brushes.Black, new Point(w / 2 - 100, 80));
                e.Graphics.DrawString("Mã hoá đơn: " + lbMaHD.Text, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(50, 120));
                e.Graphics.DrawString("Người lập: " + lbNguoiLap.Text, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(50, 140));
                e.Graphics.DrawString("Ngày lập: " + lbNgayLap.Text, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(50, 160));
                e.Graphics.DrawString("Mã sinh viên: " + lbMaSV.Text, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(50, 180));
                e.Graphics.DrawString("Tên sinh viên: " + lbTenSV.Text, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(w / 2, 180));
                e.Graphics.DrawString("Mã giảng viên: " + lbMaGV.Text, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(50, 200));
                e.Graphics.DrawString("Tên giảng viên: " + lbTenGV.Text, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(w / 2, 200));
                Pen penBlack = new Pen(Color.Black, 1);
                var y = 220;
                Point p1 = new Point(10, y);
                Point p2 = new Point(w - 10, y);
                e.Graphics.DrawLine(penBlack, p1, p2);
                y += 20;
                e.Graphics.DrawString("STT", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(20, y));
                e.Graphics.DrawString("Mã sách", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(80, y));
                e.Graphics.DrawString("Tên sách", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(180, y));
                e.Graphics.DrawString("Số lượng", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
                e.Graphics.DrawString("Đơn giá", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 150, y));
                e.Graphics.DrawString("Thành tiền", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(w - 150, y));

                int i = 1;
                y += 25;

                foreach (var item in result)
                {
                    e.Graphics.DrawString(i++.ToString(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(20, y));
                    e.Graphics.DrawString(item.idBook, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(80, y));
                    e.Graphics.DrawString(item.nameBook, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(180, y));
                    e.Graphics.DrawString(item.slBook.ToString(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
                    e.Graphics.DrawString(item.dgBook.ToString(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 150, y));
                    e.Graphics.DrawString(item.sumBook.ToString(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(w - 150, y));
                    y += 20;
                }
                y += 20;
                p1 = new Point(10, y);
                p2 = new Point(w - 10, y);
                e.Graphics.DrawLine(penBlack, p1, p2);
                y += 20;
                e.Graphics.DrawString("Tổng tiền t.toán".ToUpper(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(20, y));
                e.Graphics.DrawString(lbTongTT.Text, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(w - 150, y));
                //y += 20;
                //e.Graphics.DrawString("Tiền độc giả trả".ToUpper(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(20, y));
                //e.Graphics.DrawString(moneyCustomer, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(w - 150, y));
                //y += 20;
                //e.Graphics.DrawString("Tiền trả lại".ToUpper(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(20, y));
                //e.Graphics.DrawString((Convert.ToDouble(moneyCustomer) - Convert.ToDouble(sumMoneyHD)).ToString(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(w - 150, y));
            }
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
