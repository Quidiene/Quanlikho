using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace QLXuatNhapKho
{
    public partial class BaoCao : Form
    {
        string tnv = "", tdn = "", mk = "", CV = "", mnv;
       
      
        private void button2_Click(object sender, EventArgs e)
        {
            FHangHoa fhh = new FHangHoa(mnv, tnv, tdn, CV);
            fhh.Show();
            this.Hide();
        }
   
        private string mphieunhap;

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (dkq.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                if (checkBox1.Checked == true) { sfd.FileName = "BC_"+checkBox1.Text.Trim() +".pdf"; }
                else
                { if(checkBox2.Checked == true) { sfd.FileName = "BC_" + checkBox2.Text.Trim()+".pdf"; }
                  else { sfd.FileName = "BC_" + checkBox3.Text.Trim() +".pdf"; }
                }
                bool fileError = false;
                PdfPTable pdfPt = new PdfPTable(dkq.Columns.Count);
                pdfPt.DefaultCell.Padding = 3;
                pdfPt.DefaultCell.MinimumHeight = 20;
                pdfPt.WidthPercentage = 100;
                pdfPt.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPt.DefaultCell.BorderWidth = 1;
                BaseFont cetb = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\Fonts\arial.ttf", BaseFont.IDENTITY_H,true);
                iTextSharp.text.Font cet = new iTextSharp.text.Font(cetb, 12, iTextSharp.text.Font.NORMAL);
                BaseFont pr = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\Fonts\arial.ttf", BaseFont.IDENTITY_H, true);
                iTextSharp.text.Font pc = new iTextSharp.text.Font(pr, 12, iTextSharp.text.Font.BOLD);
                BaseFont tb = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\Fonts\arial.ttf", BaseFont.IDENTITY_H, true);
                iTextSharp.text.Font tbc = new iTextSharp.text.Font(tb, 16, iTextSharp.text.Font.BOLD);
                BaseFont ld= BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\Fonts\arial.ttf", BaseFont.IDENTITY_H, true);
                iTextSharp.text.Font nldd = new iTextSharp.text.Font(ld, 14, iTextSharp.text.Font.BOLD);
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Không thể ghi dữ liệu tới ổ đĩa. Mô tả lỗi:" + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            Paragraph prgHeading = new Paragraph(); 
                            Paragraph tbcc = new Paragraph(); 
                            Paragraph nld = new Paragraph();
                            nld.Alignment = Element.ALIGN_RIGHT;
                            tbcc.Alignment = Element.ALIGN_CENTER;
                            prgHeading.Alignment = Element.ALIGN_LEFT;
                            prgHeading.Add(new Chunk("Cửa Hàng Vật Liệu Xây Dựng MQ\n", pc));
                            prgHeading.Add(new Chunk("48C Nguyễn Văn Linh, Phường An Khánh, Q.Ninh Kiều, TP.Cần Thơ \n", cet));
                            prgHeading.Add(new Chunk("SĐT: 0398889888\n", cet));
                            prgHeading.Add(new Chunk("\n", pc));
                            prgHeading.Add(new Chunk("\n", pc));
                            if (checkBox1.Checked == true) 
                            { tbcc.Add(new Chunk("Báo Cáo Thống Kê Hàng Tồn Kho\n", tbc)); }
                            else
                            {
                                if (checkBox2.Checked == true) 
                                {   tbcc.Add(new Chunk("Báo Cáo Thống Kê Doanh Thu\n", tbc));
                                    nld.Add(new Chunk("\nTổng Cộng :           " + txttt.Text + "   VNĐ\n", pc));
                                }
                                else { tbcc.Add(new Chunk("Báo Cáo Thống Kê Hạn Sử Dụng \n", tbc)); }
                            }
                            prgHeading.Add(new Chunk("\n", tbc));
                            tbcc.Add(new Chunk("Ngày lập phiếu\t"+DateTime.Now.ToShortDateString(), cet));
                            tbcc.Add(new Chunk("\n", tbc));
                            tbcc.Add(new Chunk("\n", tbc));
                            
                            nld.Add(new Chunk("\nNgười Lập Báo Cáo\n", nldd));
                            nld.Add(new Chunk("(Ký,ghi rõ họ tên)\n", cet));
                            PdfPTable pdfTable = new PdfPTable(dkq.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dkq.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, nldd));
                                pdfTable.AddCell(cell);
                            }

                            for (int i= 0;i<dkq.Rows.Count;i++)
                            {
                                for (int j =0;j<dkq.Columns.Count;j++)
                                {
                                    DataTable d = (DataTable)dkq.DataSource;
                                    pdfTable.AddCell(new Phrase(d.Rows[i][j].ToString(),cet));
                                }
                            }
                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(prgHeading);
                                pdfDoc.Add(tbcc);
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Add(nld);
                                pdfDoc.Close();
                                stream.Close();
                            }
                            MessageBox.Show("Dữ liệu Export thành công!!!", "Info");    
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Mô tả lỗi :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn dữ liệu để export!!!", "Info");
            }
        }

        

        public BaoCao()
        {
            InitializeComponent();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            try {
                string d = "drop table HSD";
                SqlCommand sd = new SqlCommand(d, HelpForm.Open());
                sd.ExecuteNonQuery();
            }
            catch (Exception) { }
            if (checkBox3.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = true;
                string sqll = "select * from HangHoa";
                try
                {
                    SqlCommand c1 = new SqlCommand(sqll, HelpForm.Open());
                    SqlDataAdapter c2 = new SqlDataAdapter(c1);
                    System.Data.DataTable c3 = new System.Data.DataTable();
                    c2.Fill(c3);
                    string cr = "create table HSD (MaHH nvarchar(10), TenHH nvarchar(64), HanSD date, SoNgay int)";
                    SqlCommand cr1 = new SqlCommand(cr, HelpForm.Open());
                    cr1.ExecuteNonQuery();
                    for (int i = 0; i <= c3.Rows.Count ; i++)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        DataGridViewCell _cell;
                        DateTime hansd = Convert.ToDateTime(c3.Rows[i]["HanSD"].ToString());
                        DateTime nht = Convert.ToDateTime(DateTime.Now);
                        TimeSpan ch = hansd - nht;
                        int Tsn = ch.Days + 1;
                        String ih = " insert into HSD values ('" + c3.Rows[i]["MaHH"].ToString() + "',N'" + c3.Rows[i]["TenHH"].ToString() + "', '" + c3.Rows[i]["HanSD"].ToString() + "','"+Tsn+"')";
                        SqlCommand ih1 = new SqlCommand(ih, HelpForm.Open());
                        ih1.ExecuteNonQuery();
                        string sl1 = "select * from HSD";
                        dkq.DataSource = HelpForm.Gettable(sl1);
                    }
                    MessageBox.Show("Đã kiểm tra xong");
                }
                catch (Exception eh) { }
            }
            else
            {
                dkq.DataSource = null; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
           
            
            if (checkBox2.Checked)
            {
                checkBox3.Checked = false;
                checkBox1.Checked = false;
                checkBox2.Checked = true;
                string st1 = "Select BaoCao.MaHH, BaoCao.TenHH,ChitietXH.SoLuong,ChitietXH.Thanhtien as ThanhTien from ChitietXH,Baocao where ChitietXH.Mahh = BaoCao.mahh";
                dkq.DataSource = HelpForm.Gettable(st1);
                int sum = 0;
                for (int i = 0; i < dkq.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dkq.Rows[i].Cells["ThanhTien"].Value);
                }
                txttt.Text = sum.ToString();

            }
            else
            {
                dkq.DataSource = null;

            }
            try
            {
                string d = "drop table HSD";
                SqlCommand sd = new SqlCommand(d, HelpForm.Open());
                sd.ExecuteNonQuery();
            }
            catch (Exception) { }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox3.Checked = false;
            checkBox2.Checked = false;
            if (checkBox1.Checked)
            {
                string st = "Select BaoCao.MaHH, BaoCao.TenHH, BaoCao.SoLuongNhap,BaoCao.SoLuongXuat, HangHoa.TSLuong as TonKho from HangHoa,Baocao where hanghoa.Mahh = BaoCao.mahh";
                dkq.DataSource = HelpForm.Gettable(st);
                
            }
            else { dkq.DataSource = null;
                
            }
            try {
                string d = "drop table HSD";
                SqlCommand sd = new SqlCommand(d, HelpForm.Open());
                sd.ExecuteNonQuery();
            }
            catch (Exception) { }
        }

        public BaoCao(string mnv, string tnv, string tdn, string cV)
        {
            InitializeComponent();
            this.mnv = mnv;
            this.tnv = tnv;
            this.tdn = tdn;
            this.CV = cV;
        }
        private void BaoCao_Load(object sender, EventArgs e)
        {
           
        }
     
        private void ExpPDF(DataTable dtblTable, String strPdfPath)
        {
            System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter w = PdfWriter.GetInstance(document, fs);
            document.Open();
            Paragraph prgAuthor = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(btnAuthor, 13, 2, BaseColor.BLACK);
            prgAuthor.Alignment = Element.ALIGN_CENTER;
            prgAuthor.Add(new Chunk("CỬA HÀNG VẬT LIỆU XÂY DỰNG MQ", fntAuthor));
            prgAuthor.Add(new Chunk("\n48C Nguyễn Văn Linh,Phường An Khánh, Q.Ninh Kiều, TP.Cần Thơ" + DateTime.Now.ToShortDateString(), fntAuthor));
            prgAuthor.Add(new Chunk("\nSố Điện Thoại: 0939553399", fntAuthor));
            document.Add(prgAuthor);
            BaseFont bh = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fh = new iTextSharp.text.Font(bh,16,1, BaseColor.BLACK);
            Paragraph ph = new Paragraph();
            ph.Alignment = Element.ALIGN_CENTER;
          
            ph.Add(new Chunk("\n"+ DateTime.Now.ToShortDateString(), fntAuthor));
            document.Add(ph);
            document.Add(new Chunk("\n", fh));

            PdfPTable table = new PdfPTable(dtblTable.Columns.Count);
            BaseFont bch = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fch = new iTextSharp.text.Font(bch, 10, 1, BaseColor.WHITE);
            for (int i = 0; i < dtblTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = BaseColor.GRAY;
                cell.AddElement(new Chunk(dtblTable.Columns[i].ColumnName.ToUpper(), fch));
                table.AddCell(cell);
            }
            for (int i = 0; i < dtblTable.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable.Columns.Count; j++)
                {
                    table.AddCell(dtblTable.Rows[i][j].ToString());
                }
            }
            document.Add(table);
            document.Add(new Chunk("\n", fh));
            BaseFont nv = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fnv = new iTextSharp.text.Font(bh, 13, 1, BaseColor.BLACK);
            Paragraph pnv = new Paragraph();
            ph.Alignment = Element.ALIGN_CENTER;
            ph.Add(new Chunk("\nNgười lập phiếu" , fnv));
            ph.Add(new Chunk("\n (Ký,Họ tên", fnv));
            document.Add(ph);
            document.Close();
            w.Close();
            fs.Close();

        }
    }
}
   


