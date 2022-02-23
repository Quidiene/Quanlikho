using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace QLXuatNhapKho
{
    public partial class ChitietXH : Form
    {
        string mphieuxuat, tnv = "", tdn = "", mk = "", CV = "", mnv;

        private void dhh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dhh.Rows.Count; i++)
            {

                if (e.RowIndex == i)
                {
                    DataGridViewRow row = this.dhh.Rows[e.RowIndex];
                    txtmhh.Text = row.Cells[0].Value.ToString();
                    txtthh.Text = row.Cells[1].Value.ToString();
                    txtsl.Text = row.Cells[2].Value.ToString();
                    txtdvt.Text = row.Cells[3].Value.ToString();


                }




            }
        }

        private void txtsl_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float t1 = (float.Parse(txtgiaxuat.Text.ToString()) * float.Parse(txtsl.Text.ToString()));
                float t2 = ((float.Parse(txtgiaxuat.Text.ToString()) * float.Parse(txtsl.Text.ToString())) * ((float.Parse(txtgiamgia.Text.ToString())) / 100));
                float t3 = t1 - t2;
                string ttt = Convert.ToString(t3);
                txtthanhtien.Text = ttt;
                
            }
            catch (Exception ex) { }
            
            
        }
            

        

        private void txtgiamgia_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float t1 = (float.Parse(txtgiaxuat.Text.ToString()) * float.Parse(txtsl.Text.ToString()));
                float t2 = ((float.Parse(txtgiaxuat.Text.ToString()) * float.Parse(txtsl.Text.ToString())) * ((float.Parse(txtgiamgia.Text.ToString())) / 100));
                float t3 = t1 - t2;
                string ttt = Convert.ToString(t3);
                txtthanhtien.Text = ttt;
            }
            catch (Exception ex) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PhieuXuatHang fxh = new PhieuXuatHang(mnv, tnv, tdn, CV);
            fxh.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtclear();
        }
        private void txtclear()
        {
            txtsl.Clear();
            txtmhh.Clear();
            txtthh.Clear();
            txtgiaxuat.Clear();
            txtthanhtien.Clear();
            txtgiamgia.Clear();
            txtdvt.Clear();
        }
        private void txtR()
        {
            txtsl.ReadOnly= true;
            txtmhh.ReadOnly= true;
            txtthh.ReadOnly= true;
            txtgiaxuat.ReadOnly= true;
            txtthanhtien.ReadOnly= true;
            txtgiamgia.ReadOnly= true;
            txtdvt.ReadOnly= true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string se111 = "select * from HangHoa where MaHH ='" + txtmhh.Text + "'";
            SqlCommand s1111 = new SqlCommand(se111, HelpForm.Open());
            SqlDataAdapter da111 = new SqlDataAdapter(s1111);
            System.Data.DataTable s3111 = new System.Data.DataTable();
            da111.Fill(s3111);
            float s4111 = float.Parse(s3111.Rows[0]["GiaNhap"].ToString());
            float gx112 = s4111;
            string gx111 = Convert.ToString(gx112);
            string sbc = "select * from BaoCao Where MaHH='" + txtmhh.Text + "'";
            SqlCommand sbc1 = new SqlCommand(sbc, HelpForm.Open());
            SqlDataAdapter ssbc = new SqlDataAdapter(sbc1);
            System.Data.DataTable sbcc = new System.Data.DataTable();
            ssbc.Fill(sbcc);
            float sxk = float.Parse(sbcc.Rows[0]["SoLuongXuat"].ToString());
            if ( nhan == "")
            { MessageBox.Show("Không biết bạn muốn làm gì ạ ??"); }
            else 
            {
                if (nhan == "them")
                {
                    string s = "Select * from HangHoa where MaHH='" + txtmhh.Text + "'";
                    SqlCommand s11 = new SqlCommand(s, HelpForm.Open());
                    SqlDataAdapter da1 = new SqlDataAdapter(s11);
                    System.Data.DataTable s31 = new System.Data.DataTable();
                    da1.Fill(s31);
                    float s41 = float.Parse(s31.Rows[0]["TSLuong"].ToString());
                   
                    ///


                    try
                    {
                        if (s4111 > float.Parse(txtgiaxuat.Text.ToString()))
                        {
                            DialogResult dr = MessageBox.Show("Giá xuất hàng thấp hơn giá nhập hàng !!", "Cảnh báo !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (DialogResult.OK == dr)
                            {
                                txtgiaxuat.Text = gx111;
                            }
                        }
                        else
                        {

                            if (nhan == "them" && s41 < float.Parse(txtsl.Text.ToString()))
                            {
                                DialogResult dr = MessageBox.Show("Số lượng bạn nhập vượt quá số lượng trong kho", "Cảnh báo !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                if (DialogResult.OK == dr)
                                {
                                    txtsl.Text = Convert.ToString(s41);
                                }
                            }
                            else
                            {
                                if (nhan == "them" && s41 >= float.Parse(txtsl.Text.ToString()))
                                {
                                    string i = "insert into ChitietXH values('" + txtmp.Text + "',N'" + txtmhh.Text + "',N'" + txtthh.Text + "','" + txtgiaxuat.Text + "','" + txtsl.Text + "','" + txtgiamgia.Text + "','" + txtthanhtien.Text + "')";
                                    SqlCommand i1 = new SqlCommand(i, HelpForm.Open());
                                    i1.ExecuteNonQuery();
                                    if (sxk == 0)
                                    {
                                        string themcc1 = " UPDATE BaoCao SET SoLuongXuat='" + txtsl.Text + "' where MaHH='" + txtmhh.Text + "'";
                                        SqlCommand thssl1 = new SqlCommand(themcc1, HelpForm.Open());
                                        thssl1.ExecuteNonQuery();
                                    }
                                    else {
                                        float stl = float.Parse(txtsl.Text);
                                       string sl= Convert.ToString(sxk + stl);
                                        string themcc1 = " UPDATE BaoCao SET SoLuongXuat='" + sl + "' where MaHH='" + txtmhh.Text + "'";
                                        SqlCommand thssl1 = new SqlCommand(themcc1, HelpForm.Open());
                                        thssl1.ExecuteNonQuery();
                                    }
                                    string s1 = "Select * from HangHoa where MaHH='" + txtmhh.Text + "'";
                                    SqlCommand s111 = new SqlCommand(s, HelpForm.Open());
                                    SqlDataAdapter da11 = new SqlDataAdapter(s111);
                                    System.Data.DataTable s311 = new System.Data.DataTable();
                                    da11.Fill(s311);
                                    float s411 = float.Parse(s311.Rows[0]["TSLuong"].ToString());
                                    float hc = s411 - (float.Parse(txtsl.Text));
                                    string hck = Convert.ToString(hc);
                                    string uhh = "update HangHoa set TSLuong ='" + hck + "' where MaHH ='" + txtmhh.Text + "'";
                                    SqlCommand uhh1 = new SqlCommand(uhh, HelpForm.Open());
                                    uhh1.ExecuteNonQuery();

                                    MessageBox.Show("Đã thêm hàng hóa vào !");
                                    txtclear();
                                    load();
                                    nhan = "";
                                }
                            }
                        }

                    }
                    catch (Exception e1) { }
                }
                else
                {
                    if (nhan == "Sua")
                    {
                        string s = "Select * from HangHoa where MaHH='" + txtmhh.Text + "'";
                        SqlCommand s11 = new SqlCommand(s, HelpForm.Open());
                        SqlDataAdapter da1 = new SqlDataAdapter(s11);
                        System.Data.DataTable s31 = new System.Data.DataTable();
                        da1.Fill(s31);
                        float s41 = float.Parse(s31.Rows[0]["TSLuong"].ToString());
                        string sx = "select * from ChitietXH where MaHH='" + txtmhh.Text + "'";
                        SqlCommand sx11 = new SqlCommand(sx, HelpForm.Open());
                        SqlDataAdapter dax1 = new SqlDataAdapter(sx11);
                        System.Data.DataTable sx31 = new System.Data.DataTable();
                        dax1.Fill(sx31);
                        float sx41 = float.Parse(sx31.Rows[0]["SoLuong"].ToString());
                        try
                        {
                            if (s4111 > float.Parse(txtgiaxuat.Text.ToString()))
                            {
                                DialogResult dr = MessageBox.Show("Giá xuất hàng thấp hơn giá nhập hàng !!", "Cảnh báo !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                if (DialogResult.OK == dr)
                                {
                                    txtgiaxuat.Text = gx111;
                                }
                            }
                            else
                            {
                                if (nhan == "Sua" && sx41 >= float.Parse(txtsl.Text.ToString()) && s41 < float.Parse(txtsl.Text.ToString()))
                                {
                                    string aasi = "update ChitietXH set Giamgia ='" + txtgiamgia.Text + "', ThanhTien='" + txtthanhtien.Text + "' ";
                                    SqlCommand aasi1 = new SqlCommand(aasi, HelpForm.Open());
                                    aasi1.ExecuteNonQuery();
                                    string ss= Convert.ToString( s41 - float.Parse(txtsl.Text.ToString()));
                                    string themcc1 = " UPDATE BaoCao SET SoLuongNhap= '" + ss + "', SoLuongXuat='"+txtsl.Text+"' where MaHH='" + txtmhh.Text + "'";
                                    SqlCommand thssl1 = new SqlCommand(themcc1, HelpForm.Open());
                                    thssl1.ExecuteNonQuery();
                                    MessageBox.Show("Đã sửa thành công !");
                                    load();
                                    txtclear();
                                }

                                else
                                {
                                    if (nhan == "Sua" && s41 >= float.Parse(txtsl.Text.ToString()))
                                    {
                                        if (sx41 < float.Parse(txtsl.Text.ToString()))
                                        {
                                            string si = "update ChitietXH set SoLuong ='" + txtsl.Text + "', Giamgia ='" + txtgiamgia.Text + "', ThanhTien='" + txtthanhtien.Text + "' ";
                                            SqlCommand si1 = new SqlCommand(si, HelpForm.Open());
                                            si1.ExecuteNonQuery();
                                            
                                            string ss1 = "Select * from HangHoa where MaHH='" + txtmhh.Text + "'";
                                            SqlCommand ss111 = new SqlCommand(ss1, HelpForm.Open());
                                            SqlDataAdapter das11 = new SqlDataAdapter(ss111);
                                            System.Data.DataTable ss311 = new System.Data.DataTable();
                                            das11.Fill(ss311);
                                            float s411 = float.Parse(ss311.Rows[0]["TSLuong"].ToString());
                                            float shc = s411 - (float.Parse(txtsl.Text) - sx41);
                                            string shck = Convert.ToString(shc);
                                            string uhh = "update HangHoa set TSLuong ='" + shck + "' where MaHH ='" + txtmhh.Text + "'";
                                            SqlCommand uhh1 = new SqlCommand(uhh, HelpForm.Open());
                                            uhh1.ExecuteNonQuery();
                                            string themcc2 = " UPDATE BaoCao SET SoLuongNhap= '" + shck + "', SoLuongXuat='"+txtsl.Text+"' where MaHH='" + txtmhh.Text + "'";
                                            SqlCommand thssl2 = new SqlCommand(themcc2, HelpForm.Open());
                                            thssl2.ExecuteNonQuery();
                                            MessageBox.Show("Đã sửa !");
                                            txtclear();
                                            load();
                                            nhan = "";
                                        }
                                        else
                                        {
                                            if (sx41 > float.Parse(txtsl.Text.ToString()))
                                            {
                                                string asi = "update ChitietXH set SoLuong ='" + txtsl.Text + "', Giamgia ='" + txtgiamgia.Text + "', ThanhTien='" + txtthanhtien.Text + "' ";
                                                SqlCommand asi1 = new SqlCommand(asi, HelpForm.Open());
                                                asi1.ExecuteNonQuery();
                                   
                                                float m = s41 + (sx41 - float.Parse(txtsl.Text));
                                                string ashck = Convert.ToString(m);
                                                string auhh = "update HangHoa set TSLuong ='" + ashck + "' where MaHH ='" + txtmhh.Text + "'";
                                                SqlCommand auhh1 = new SqlCommand(auhh, HelpForm.Open());
                                                auhh1.ExecuteNonQuery();
                                                string themcc2 = " UPDATE BaoCao SET SoLuongNhap= '" + ashck + "', SoLuongXuat='"+txtsl.Text+"' where MaHH='" + txtmhh.Text + "'";
                                                SqlCommand thssl2 = new SqlCommand(themcc2, HelpForm.Open());
                                                thssl2.ExecuteNonQuery();
                                                MessageBox.Show("Đã sửa!");
                                                txtclear();
                                                load();
                                                nhan = "";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (s41 < float.Parse(txtsl.Text.ToString()))
                                        { MessageBox.Show("Số lượng hàng hóa trong kho không đáp ứng đủ !!"); }


                                    }

                                }
                            }
                        }

                        catch (Exception ex) { }
                        
                    }
                }

             }
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < dxh.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dxh.Rows[i].Cells["ThanhTien"].Value);
            }

            if (dxh.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = mphieuxuat + ".pdf";
                bool fileError = false;
                PdfPTable pdfPt = new PdfPTable(dxh.Columns.Count);
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
                            tbcc.Add(new Chunk("PHIẾU XUẤT KHO", tbc));
                            prgHeading.Add(new Chunk("\n", tbc));
                            ncc.Add(new Chunk("Tổng tiền:  " + sum.ToString() + " VNĐ\n", nldd));
                            tbcc.Add(new Chunk("\n", tbc));
                            tbcc.Add(new Chunk("Ngày lập phiếu:  " + DateTime.Now.ToShortDateString(), cet));
                            tbcc.Add(new Chunk("\nMã Số Phiếu:  " + txtmp.Text + "             ", cet));
                            tbcc.Add(new Chunk("\n", tbc));
                            tbcc.Add(new Chunk("\n", tbc));
                            ncc.Add(new Chunk("     Người Mua Hàng                                                                                                " + "Người Lập Phiếu\n", nldd));
                            ncc.Add(new Chunk("         (Ký,ghi rõ họ tên)                                                                                                                        " + "(Ký, ghi rõ họ tên)\n", cet));
                            PdfPTable pdfTable = new PdfPTable(dxh.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 95;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            foreach (DataGridViewColumn column in dxh.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, nldd));
                                pdfTable.AddCell(cell);
                            }
                            for (int i = 0; i < dxh.Rows.Count; i++)
                            {
                                for (int j = 0; j < dxh.Columns.Count; j++)
                                {
                                    System.Data.DataTable d = (System.Data.DataTable)dxh.DataSource;
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtmhh.Text == "" && txtthh.Text == "" && txtsl.Text == "" && txtmp.Text == "" && txtthanhtien.Text =="")
            { MessageBox.Show("Bạn chưa chọn mặt hàng cần xóa"); }
            else
            {
                DialogResult DR = MessageBox.Show("Bạn có chắc muốn xóa mặt hàng này", "Xác nhận", MessageBoxButtons.OKCancel);
                if (DialogResult.OK == DR)
                {


                    string xoa = "delete from ChiTietXH where MaPX='"+txtmp.Text+"'and MaHH='" + txtmhh.Text + "'";
                    SqlCommand delete = new SqlCommand(xoa, HelpForm.Open());
                    delete.ExecuteNonQuery();
                    MessageBox.Show("Đã xóa thành công");
                    load();
                    txtclear();

                }

               
            }
        }
        string nhan = "";
        private void btnthem_Click(object sender, EventArgs e)
        {
            nhan = "them";
            MessageBox.Show("Bạn đã chọn chức năng thêm");
        }

        private void txtmhh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string se = "select * from Hanghoa where MaHH ='" + txtmhh.Text + "'";
                SqlCommand s1 = new SqlCommand(se, HelpForm.Open());
                SqlDataAdapter da = new SqlDataAdapter(s1);
                System.Data.DataTable s3 = new System.Data.DataTable();
                da.Fill(s3);
                float s4 = float.Parse(s3.Rows[0]["GiaNhap"].ToString());
                float gx = s4 ;
                string gx1 = Convert.ToString(gx);
                txtgiaxuat.Text = gx1;
            }
            catch(Exception e2) { }
        }

        private void txtmhh_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtgiaxuat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float t1 = (float.Parse(txtgiaxuat.Text.ToString()) * float.Parse(txtsl.Text.ToString()));
                float t2 = ((float.Parse(txtgiaxuat.Text.ToString()) * float.Parse(txtsl.Text.ToString())) * ((float.Parse(txtgiamgia.Text.ToString())) / 100));
                float t3 = t1 - t2;
                string ttt = Convert.ToString(t3);
                txtthanhtien.Text = ttt;
            }
            catch (Exception ex) { }
           
            
           
        }

        private void dxh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dxh.Rows.Count; i++)
            {

                if (e.RowIndex == i)
                {
                    DataGridViewRow row = this.dxh.Rows[e.RowIndex];
                    
                    txtmhh.Text = row.Cells[0].Value.ToString();
                    txtthh.Text = row.Cells[1].Value.ToString();
                    txtgiaxuat.Text = row.Cells[2].Value.ToString();
                    txtsl.Text = row.Cells[3].Value.ToString();
                    txtgiamgia.Text = row.Cells[5].Value.ToString();
                    txtthanhtien.Text = row.Cells[6].Value.ToString();
                    txtdvt.Text = row.Cells[4].Value.ToString();


                }




            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtmhh.Text == "" && txtthh.Text == "" && txtsl.Text == "" && txtmp.Text == "" && txtthanhtien.Text == "")
            { MessageBox.Show("Bạn chưa chọn mặt hàng để sửa"); }
            else
            {
                nhan = "Sua";
                txtR();
                txtthh.ReadOnly = false;
                txtsl.ReadOnly = false;
                txtgiamgia.ReadOnly = false;
                MessageBox.Show("Bạn chưa chọn chức năng sửa");

            }
        }

        private void txttimkiem_Enter(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "Tên hàng hóa")
            { txttimkiem.Text = ""; txttimkiem.ForeColor = Color.Black; }
        }

        private void txttimkiem_Leave(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                txttimkiem.Text = "Tên hàng hóa";
                txttimkiem.ForeColor = Color.Gray;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sqll = "select * from  ChitietXH";
            SqlDataAdapter ada = new SqlDataAdapter(sqll, HelpForm.Open());
            System.Data.DataTable daa = new System.Data.DataTable();
            ada.Fill(daa);
            DataView dv = new DataView(daa);
            if (txttimkiem.Text == "")
            { MessageBox.Show("Bạn muốn tìm gì hãy ghi ra nào!!!"); txttimkiem.Focus(); }
            else
            {
                dv.RowFilter = " TenHH like \'%" + txttimkiem.Text + "%\'";
                dxh.DataSource = dv;
            }
            txtclear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string slhh = "select * from HangHoa where MaLoai='"+cbl.SelectedValue.ToString()+"'";
            dhh.DataSource = HelpForm.Gettable(slhh);
            
        }

        public ChitietXH()
        {
            InitializeComponent();
        }
        public ChitietXH(string mnv, string mp, string tnv, string tdn, string CV)
        {
            InitializeComponent();
            this.mphieuxuat = mp;
            this.tnv = tnv;
            this.tdn = tdn;
            this.CV = CV;
        }
        private void load()
        {
            string slhh = "select * from HangHoa ";
            dhh.DataSource = HelpForm.Gettable(slhh);
            txtmp.Text = mphieuxuat;
            txtmp.ReadOnly = true;
            string sl = "select * from LoaiHang";
            cbl.DisplayMember = "TenLoai";
            cbl.ValueMember = "MaLoai";
            cbl.DataSource = HelpForm.Gettable(sl);
            string dx = "select ChitietXH.MaHH,ChitietXH.TenHH,ChitietXH.GiaXuat,ChitietXH.SoLuong,HangHoa.Donvitinh,ChitietXH.GiamGia,ChitietXH.ThanhTien from ChitietXH,HangHoa where hangHoa.MaHH=ChitietXH.MaHH and MaPX='" + mphieuxuat + "'";
            dxh.DataSource = HelpForm.Gettable(dx);
        }
        private void ChitietXH_Load(object sender, EventArgs e)
        {
            load();
          
            
        }
    }
}
