using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace QLXuatNhapKho
{
    public partial class TaiKhoanNV : Form
    {
        string tnv = "", tdn = "", mk = "", CV = "", mnv;
        public TaiKhoanNV()
        {
            InitializeComponent();
        }
        public TaiKhoanNV(string mnv, string tnv, string tdn, string cV)
        {
            InitializeComponent();
            this.mnv = mnv;
            this.tnv = tnv;
            this.tdn = tdn;
            this.CV = cV;
        }

        private void load()
        {
            if (CV != "1")
            {
                string s0 = "select MaNV,TenNV,Dchi,Sdt from TaiKhoanNV";
                dtknv.DataSource = HelpForm.Gettable(s0);
                txtchucvu.ReadOnly = true;
            }
            else
            {
                string sss = "select * from TaiKHoanNV";
                dtknv.DataSource = HelpForm.Gettable(sss);
                txttdn.UseSystemPasswordChar = true;
                txtmk.UseSystemPasswordChar = true;
            }
        }

        string nhan = "";
        private void button1_Click_1(object sender, EventArgs e)
        {
           
            if (CV == "1")
            {
                string hh = "select * from TaiKhoanNV";
                SqlCommand ghh = new SqlCommand(hh, HelpForm.Open());
                SqlDataAdapter shh = new SqlDataAdapter(ghh);
                System.Data.DataTable dhh = new System.Data.DataTable();
                shh.Fill(dhh);
                if (dhh.Rows.Count < 0)
                {
                    txtmnv.Text ="NV" + "1";
                    nhan = "Them";
                    txtdchi.Clear();
                    txttdn.Clear();
                    txttnv.Clear();
                    txttim.Clear();
                    txtsdt.Clear();
                    txtmk.Clear();
                    txtchucvu.Clear();
                    txtchucvu.ReadOnly = false;
                    txtmk.ReadOnly = false;
                    txttdn.ReadOnly = false;
                    txttnv.ReadOnly = false;
                    txtdchi.ReadOnly = false;
                    txtsdt.ReadOnly = false;
                    txtmnv.ReadOnly = true;
                }
                else
                {
                    int k;
                    k = Convert.ToInt32((dhh.Rows.Count).ToString());
                    k++;
                    
                    txtmnv.Text ="NV"+ k ;
                    nhan = "Them";
                    txtdchi.Clear();
                    txttdn.Clear();
                    txttnv.Clear();
                    txttim.Clear();
                    txtsdt.Clear();
                    txtmk.Clear();
                    txtchucvu.Clear();
                    txtchucvu.ReadOnly = false;
                    txtmk.ReadOnly = false;
                    txttdn.ReadOnly = false;
                    txttnv.ReadOnly = false;
                    txtdchi.ReadOnly = false;
                    txtsdt.ReadOnly = false;
                    txtmnv.ReadOnly = true;
                }


            }
            else { MessageBox.Show("Bạn không đủ quyền truy cập!!!"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CV == "1")
            {
                if (txtmnv.Text == "" && txttnv.Text == "" && txtdchi.Text == "") { MessageBox.Show("Hãy chọn dữ liệu cần xóa!!!"); }
                else
                {
                    string i = "delete from TaiKhoanNV where MaNV ='" + txtmnv.Text + "' ";
                    SqlCommand si = new SqlCommand(i, HelpForm.Open());
                    si.ExecuteNonQuery();
                    MessageBox.Show("Đã xóa thành công dữ liệu!!!");
                    txtchucvu.Clear();
                    txtmk.Clear();
                    txttdn.Clear();
                    txttnv.Clear();
                    txtdchi.Clear();
                    txtsdt.Clear();
                    txtmnv.Clear();
                    load();
                }
            }
            else
            {
                MessageBox.Show("Bạn không đủ quyền truy cập!!!");
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CV == "1")
            {
                nhan = "Sua";
                txtchucvu.ReadOnly = false;
                txtmk.ReadOnly = false;
                txttdn.ReadOnly = false;
                txttnv.ReadOnly = false;
                txtdchi.ReadOnly = false;
                txtsdt.ReadOnly = false;
                txtmnv.ReadOnly = true;
            }
            else
            { DialogResult dr = MessageBox.Show("Bạn chỉ có thể sửa thông tin cơ bản !!", "Xác nhận", MessageBoxButtons.OKCancel);
                if (DialogResult.OK == dr)
                { 
                    nhan = "Sua";
                    txtchucvu.ReadOnly = false;
                    txtmk.ReadOnly = false;
                    txttdn.ReadOnly = false;
                    txttnv.ReadOnly = false;
                    txtdchi.ReadOnly = false;
                    txtsdt.ReadOnly = false;
                    txtmnv.ReadOnly = true;

                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (nhan == "") { MessageBox.Show("không có gì để lưu!!"); }
            else
            {
                if (nhan == "dmk" && CV == "1")
                {
                    string s = "update TaiKhoanNV set tendangnhap='" + txttdn.Text + "' , Matkhau='" + txtmk.Text + "'";
                    SqlCommand ss = new SqlCommand(s, HelpForm.Open());
                    ss.ExecuteNonQuery();
                    MessageBox.Show("Đã thay đổi thông tin thành công !");
                    nhan = "";
                    load();
                }
                else
                {
                    if (nhan == "Them" && CV == "1")
                    {
                        if (txtmnv.Text != "" && txttnv.Text != "" && txtdchi.Text != "")
                        {
                            string se = "select * from TaiKhoanNV where tendangnhap='" + txttdn.Text + "'";
                            System.Data.DataTable da = new System.Data.DataTable();
                            SqlDataAdapter a = new SqlDataAdapter(se, HelpForm.Open());
                            a.Fill(da);
                            if (da.Rows.Count > 0)
                            {
                                MessageBox.Show("Tên đăng nhập đã có người sử dụng!!");
                                txttdn.Focus();
                            }
                            else
                            {
                                string i = "insert into TaiKhoanNV values ('" + txtmnv.Text + "',N'" + txttnv.Text + "',N'" + txtdchi.Text + "','" + txtsdt.Text + "',N'" + txttdn.Text + "','" + txtchucvu.Text + "',N'" + txtmk.Text + "')";
                                SqlCommand si = new SqlCommand(i, HelpForm.Open());
                                si.ExecuteNonQuery();
                                MessageBox.Show("Đã thêm thành công tài khoản mới!!!");
                                txtchucvu.Clear();
                                txtdchi.Clear();
                                txttnv.Clear();
                                txtsdt.Clear();
                                txttdn.Clear();
                                txtmk.Clear();
                                txtmnv.Clear();
                                txttim.Clear();
                                load();
                                nhan = "";
                            }
                        }
                    }
                    else
                    {
                        if (nhan == "Sua" && CV == "1")
                        {
                            if (txtmnv.Text == "" && txttnv.Text == "" && txtdchi.Text == "") { MessageBox.Show("Hãy chọn dữ liệu cần sửa!!!"); }
                            else
                            {
                                string s = "update TaiKhoanNV set TenNV =N'" + txttnv.Text + "', Dchi=N'" + txtdchi.Text + "',Sdt='" + txtsdt.Text + "',Tendangnhap='" + txttdn.Text + "',Chucvu='" + txtchucvu.Text + "',MatKhau='" + txtmk.Text + "' where MaNV='" + txtmnv.Text + "'";
                                SqlCommand ss = new SqlCommand(s, HelpForm.Open());
                                ss.ExecuteNonQuery();
                                MessageBox.Show("Thay đổi dữ liệu thành công");
                                txtchucvu.Clear();
                                txtdchi.Clear();
                                txttnv.Clear();
                                txtsdt.Clear();
                                txttdn.Clear();
                                txtmk.Clear();
                                txtmnv.Clear();
                                txttim.Clear();
                                load();
                                nhan = "";
                            }
                        }
                        else
                        {
                            if (nhan == "Sua" && CV != "1")
                            {
                                if (txtmnv.Text == "" && txttnv.Text == "" && txtdchi.Text == "") { MessageBox.Show("Hãy chọn dữ liệu cần sửa!!!"); }
                                else
                                {
                                    txtchucvu.Enabled = false;
                                    string s = "update TaiKhoanNV set TenNV =N'" + txttnv.Text + "', Dchi=N'" + txtdchi.Text + "',Sdt='" + txtsdt.Text + "',Tendangnhap='" + txttdn.Text + "',Chucvu='" + txtchucvu.Text + "',MatKhau='" + txtmk.Text + "' where MaNV='" + txtmnv.Text + "'";
                                    SqlCommand ss = new SqlCommand(s, HelpForm.Open());
                                    ss.ExecuteNonQuery();
                                    MessageBox.Show("Thay đổi dữ liệu thành công");
                                    txtchucvu.Clear();
                                    txtdchi.Clear();
                                    txttnv.Clear();
                                    txtsdt.Clear();
                                    txttdn.Clear();
                                    txtmk.Clear();
                                    txtmnv.Clear();
                                    txttim.Clear();
                                    load();
                                    nhan = "";
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Menuchucnang fmncn = new Menuchucnang(mnv, tnv, tdn, CV);
            fmncn.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string ds = "select MaNV,TenNV,Dchi,Sdt from TaiKhoanNV";
            dtknv.DataSource = HelpForm.Gettable(ds);
            if (dtknv.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "ThôngtinNV"+ ".pdf";
                bool fileError = false;
                PdfPTable pdfPt = new PdfPTable(dtknv.Columns.Count);
                pdfPt.DefaultCell.Padding = 3;
                pdfPt.DefaultCell.MinimumHeight = 20;
                pdfPt.WidthPercentage = 100;
                pdfPt.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPt.DefaultCell.BorderWidth = 1;
                BaseFont cetb = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\Fonts\arial.ttf", BaseFont.IDENTITY_H, true);
                iTextSharp.text.Font cet = new iTextSharp.text.Font(cetb, 10, iTextSharp.text.Font.NORMAL);
                BaseFont pr = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\Fonts\arial.ttf", BaseFont.IDENTITY_H, true);
                iTextSharp.text.Font pc = new iTextSharp.text.Font(pr, 12, iTextSharp.text.Font.BOLD);
                BaseFont tb = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\Fonts\arial.ttf", BaseFont.IDENTITY_H, true);
                iTextSharp.text.Font tbc = new iTextSharp.text.Font(tb, 16, iTextSharp.text.Font.BOLD);
                BaseFont ld = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\Fonts\arial.ttf", BaseFont.IDENTITY_H, true);
                iTextSharp.text.Font nldd = new iTextSharp.text.Font(ld, 12, iTextSharp.text.Font.BOLD);
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
                            Paragraph ncc = new Paragraph();
                            ncc.Alignment = Element.ALIGN_LEFT;
                            tbcc.Alignment = Element.ALIGN_CENTER;
                            prgHeading.Alignment = Element.ALIGN_LEFT;
                            prgHeading.Add(new Chunk("Cửa Hàng Vật Liệu Xây Dựng MQ\n", pc));
                            prgHeading.Add(new Chunk("48C Nguyễn Văn Linh, Phường An Khánh, Q.Ninh Kiều, TP.Cần Thơ \n", cet));
                            prgHeading.Add(new Chunk("SĐT: 0398889888\n", cet));
                            prgHeading.Add(new Chunk("\n", pc));
                            prgHeading.Add(new Chunk("\n", pc));
                            tbcc.Add(new Chunk("THÔNG TIN NHÂN VIÊN\n", tbc));
                            prgHeading.Add(new Chunk("\n", tbc));
                            tbcc.Add(new Chunk("Ngày lập phiếu:  " + DateTime.Now.ToShortDateString(), cet));
                            tbcc.Add(new Chunk("\n", tbc));
                            tbcc.Add(new Chunk("\n", tbc));
                            //ncc.Add(new Chunk("     Người Giao Hàng                                                                                                " + "Người Lập Phiếu\n", nldd));
                           // ncc.Add(new Chunk("         (Ký,ghi rõ họ tên)                                                                                                                        " + "(Ký, ghi rõ họ tên)\n", cet));
                            PdfPTable pdfTable = new PdfPTable(dtknv.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 95;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            foreach (DataGridViewColumn column in dtknv.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, nldd));
                                pdfTable.AddCell(cell);
                            }
                            for (int i = 0; i < dtknv.Rows.Count; i++)
                            {
                                for (int j = 0; j < dtknv.Columns.Count; j++)
                                {
                                    System.Data.DataTable d = (System.Data.DataTable)dtknv.DataSource;
                                    pdfTable.AddCell(new Phrase(d.Rows[i][j].ToString(), cet));
                                }
                            }
                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 5f, 10f, 0f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(prgHeading);
                                pdfDoc.Add(tbcc);
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Add(ncc);

                                pdfDoc.Close();
                                stream.Close();
                            }
                            MessageBox.Show("Dữ liệu Export thành công!!!", "Info");
                            load();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (htc.Checked == true)
            {
                txttdn.UseSystemPasswordChar = false;
                txtmk.UseSystemPasswordChar = false;
            }
            else
            {
                txttdn.UseSystemPasswordChar = true;
                txtmk.UseSystemPasswordChar = true;
            }
           
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (CV != "1")
            { MessageBox.Show("Bạn chỉ có thể đổi mật khẩu của mình !!");
                doimatkhau fdmk = new doimatkhau(mnv, tnv, tdn, CV);
                fdmk.Show();
                this.Hide();
            }
            else
            {   if (txtmnv.Text == "" && txtdchi.Text == "" && txttnv.Text == "" && txttdn.Text == "" && txtmk.Text == "")
                    {
                       MessageBox.Show("Hãy Chọn Một Tài Khoản để đổi mật khẩu !!");
                    }
                else
                {
                    MessageBox.Show("Hãy điền mật khẩu hoặc tên đăng nhập mới");
                    txttdn.Focus();
                    nhan = "dmk";
                    
                    
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {   if(txttim.Text=="Tên nhân viên")
            {
                MessageBox.Show("Hãy điền tên nhân viên muốn tìm !");
            }
            else 
            {
                if (CV != "1")
                {
                    string s0 = "select MaNV,TenNV,Dchi,Sdt from TaiKhoanNV";
                    dtknv.DataSource = HelpForm.Gettable(s0);
                    SqlDataAdapter ada = new SqlDataAdapter(s0, HelpForm.Open());
                    System.Data.DataTable daa = new System.Data.DataTable();
                    ada.Fill(daa);
                    DataView dv = new DataView(daa);
                    dv.RowFilter = " TenNV like \'%" + txttim.Text + "%\'";
                    dtknv.DataSource = dv;
                    
                }
                else
                {
                    string s0 = "select * from TaiKhoanNV";
                    dtknv.DataSource = HelpForm.Gettable(s0);
                    SqlDataAdapter ada = new SqlDataAdapter(s0, HelpForm.Open());
                    System.Data.DataTable daa = new System.Data.DataTable();
                    ada.Fill(daa);
                    DataView dv = new DataView(daa);
                    dv.RowFilter = " TenNV like \'%" + txttim.Text + "%\'";
                    dtknv.DataSource = dv;
                }
                
            }
           
            
        }

        private void txttim_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void txttim_Enter(object sender, EventArgs e)
        {   if(txttim.Text=="Tên nhân viên") { txttim.Text = "";txttim.ForeColor = Color.Black; }
            
        }

        private void txttim_Leave(object sender, EventArgs e)
        {
            if (txttim.Text == "")
            {
                txttim.Text = "Tên nhân viên";
                txttim.ForeColor = Color.Gray;

            }
        }

        private void dtknv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CV == "1")
            {
                for (int i = 0; i < dtknv.Rows.Count; i++)
                    if (e.RowIndex == i)
                    {
                        DataGridViewRow row = this.dtknv.Rows[e.RowIndex];
                        txtmnv.Text = row.Cells[0].Value.ToString();
                        txttnv.Text = row.Cells[1].Value.ToString();
                        txtdchi.Text = row.Cells[2].Value.ToString();
                        txtsdt.Text = row.Cells[3].Value.ToString();
                        txttdn.Text = row.Cells[4].Value.ToString();
                        txtmk.Text = row.Cells[6].Value.ToString();
                        txtchucvu.Text = row.Cells[5].Value.ToString();
                    }
            }
            else
            {
                for (int i = 0; i < dtknv.Rows.Count; i++)
                    if (e.RowIndex == i)
                    {
                        DataGridViewRow row = this.dtknv.Rows[e.RowIndex];
                        txtmnv.Text = row.Cells[0].Value.ToString();
                        txttnv.Text = row.Cells[1].Value.ToString();
                        txtdchi.Text = row.Cells[2].Value.ToString();
                        txtsdt.Text = row.Cells[3].Value.ToString();
                    }
            }
        } 

        private void button8_Click(object sender, EventArgs e)
        {
            txtchucvu.Clear();
            txtdchi.Clear();
            txttnv.Clear();
            txtsdt.Clear();
            txttdn.Clear();
            txtmk.Clear();
            txtmnv.Clear();
            txttim.Text = "Tên nhân viên";
            txtchucvu.ReadOnly = true;
            txtmk.ReadOnly = true;
            txttdn.ReadOnly = true;
            txttnv.ReadOnly = true;
            txtdchi.ReadOnly = true;
            txtsdt.ReadOnly = true;
            txtmnv.ReadOnly = true;
            load();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void TaiKhoanNV_Load(object sender, EventArgs e)
        {   
            load();
            txtchucvu.ReadOnly = true;
            txtmk.ReadOnly = true;
            txttdn.ReadOnly = true;
            txttnv.ReadOnly = true;
            txtdchi.ReadOnly = true;
            txtsdt.ReadOnly = true;
            txtmnv.ReadOnly = true;


            
        }
    }
}
