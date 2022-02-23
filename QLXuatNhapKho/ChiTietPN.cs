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
    public partial class ChiTietPN : Form
    {
        string tnv = "", tdn = "", mk = "", CV = "", mnv;
        private string mphieunhap;
        public ChiTietPN()
        {
            InitializeComponent();
        }
        public ChiTietPN(string mnv,string mp, string tnv,string  tdn,string CV)
        {
            InitializeComponent();
            this.mphieunhap = mp;
            this.tnv = tnv;
            this.tdn = tdn;
            this.CV = CV;
        }
        private void cbloai_SelectedIndexChanged(object sender, EventArgs e)
        {
          /*  string aapn = "select phieuNH.MaPN,ChitietNH.MaHH,TenLoai,ChitietNH.TenHH,NhaCC.TenNCC,PhieuNH.NgayNhap,ChitietNH.NgaySX,ChitietNH.HanSD,ChitietNH.Donvitinh,ChitietNH.GiaNhap,ChitietNH.SoLuong,ChitietNH.GiamGia,ChitietNH.ThanhTien,MaNV from ChitietNH join PhieuNH on PhieuNH.MaPN = ChitietNH.MaPN join HangHoa on HangHoa.MaHH = ChitietNH.MaHH join NhaCC on HangHoa.MaNCC = NhaCC.MaNCC join LoaiHang on HangHoa.MaLoai = LoaiHang.MaLoai where LoaiHang.Maloai = '" + cbloai.SelectedValue.ToString() + "'and PhieuNH.MaPN='" + txtmp.Text+"'";
            dnh.DataSource = HelpForm.Gettable(aapn);
            SqlDataAdapter ad = new SqlDataAdapter(aapn, HelpForm.Open());
            System.Data.DataTable da = new System.Data.DataTable();
            ad.Fill(da);
            DataView dv = new DataView(da);
            dv.RowFilter = " Tenloai like '" + cbloai.Text + "'";
            dnh.DataSource = dv;
            tbclear();*/
        }
        private void load()
        {
            string aapn = "select MaHH,TenHH,GiaNhap,Donvitinh,NgaySX,HanSD,SoLuong,GiamGia, Thanhtien from ChitietNH where MaPN='"+txtmp.Text+"'";
            dnh.DataSource = HelpForm.Gettable(aapn);
            string lhh = "Select * from LoaiHang";
            cbloai.DisplayMember = "TenLoai";
            cbloai.ValueMember = "MaLoai";
            cbloai.DataSource = HelpForm.Gettable(lhh);
            string ncc = "select * from NhaCC";
            cbncc.DisplayMember = "TenNCC";
            cbncc.ValueMember = "MaNCC";
            cbncc.DataSource = HelpForm.Gettable(ncc);
            string nvv = "select * from TaiKhoanNV";
            cbnv.DisplayMember = "TenNV";
            cbnv.ValueMember = "MaNV";
            cbnv.DataSource = HelpForm.Gettable(nvv);
            txtgianhap.Text = null;
            txtsln.Text = null;
            txtgiamgia.Text = null;


        }
        private void tbclear()
        {
            txtMH.Clear();
            txttenhh.Clear();
            txtgianhap.Clear();
            txtgiamgia.Clear();
            txtsln.Clear();
            txtdvt.Clear();
            txtthanhtien.Clear();

        }
        private void PhieuNH_Load(object sender, EventArgs e)
        {
            txtmp.Text = mphieunhap;
            
            cbnv.SelectedValue = mnv;
            load();
            tbfalse();
            dngaysx.Format = DateTimePickerFormat.Short;
            dhsd.Format = DateTimePickerFormat.Short;
            dnnh.Format = DateTimePickerFormat.Short;
            dnnh.Value = DateTime.Now;
            dngaysx.Value = DateTime.Now;
            dhsd.Value = DateTime.Now;
            dngaysx.Enabled = false;
            dhsd.Enabled = false;
            dnnh.Enabled = false;

        }
        private void tbfalse()
        {
            txtMH.ReadOnly = true;
            txttenhh.ReadOnly = true;
            txtgianhap.ReadOnly = true;
            //txtgiamgia.ReadOnly = true;
            txtsln.ReadOnly = true;
            txtdvt.ReadOnly = true;
            txtthanhtien.ReadOnly = true;
            this.cbloai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
        private void tbtrue()
        {
            txtMH.ReadOnly = false;
            txttenhh.ReadOnly = false;
            txtgianhap.ReadOnly = false;
            txtsln.ReadOnly = false;
            txtdvt.ReadOnly = false;
            txtthanhtien.ReadOnly = false;

        }

        private void dnh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dnh.Rows.Count; i++)
            {

                if (e.RowIndex == i)
                {
                    DataGridViewRow row = this.dnh.Rows[e.RowIndex];
                   // txtmp.Text = row.Cells[0].Value.ToString();
                    txtMH.Text = row.Cells[0].Value.ToString();
                    //cbloai.Text = row.Cells[2].Value.ToString();
                    txttenhh.Text = row.Cells[1].Value.ToString();
                    //cbncc.Text = row.Cells[4].Value.ToString();
                    //dnnh.Text = row.Cells[5].Value.ToString();
                    dngaysx.Text = row.Cells[4].Value.ToString();
                    dhsd.Text = row.Cells[5].Value.ToString();
                    txtdvt.Text = row.Cells[3].Value.ToString();
                    txtgianhap.Text = row.Cells[2].Value.ToString();
                    txtsln.Text = row.Cells[6].Value.ToString();
                    txtgiamgia.Text = row.Cells[7].Value.ToString();
                    txtthanhtien.Text = row.Cells[8].Value.ToString();
                   // cbnv.SelectedValue = row.Cells[13].Value.ToString();
                    txttimkiem.Clear();

                }

            }
        }       
        string nhan = "";
        private void btnsua_Click(object sender, EventArgs e)
        {
            tbtrue();
            txtMH.ReadOnly = true;
            nhan = "Sửa";
            dngaysx.Enabled = true;
            dhsd.Enabled = true;
            dnnh.Enabled = true;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (nhan == "")
            {
                MessageBox.Show("Không có thay đổi gì để lưu");
            }
            else
            {
                if (txtMH.Text == "" && txttenhh.Text == "" && txtsln.Text == "" && txtmp.Text == "")
                {

                    MessageBox.Show("Bạn chưa chọn gì cả");
                }
                else
                {
                    if (nhan == "Sửa")
                    {                       
                        string timss = "select * from HangHoa where MaHH='" + txtMH.Text + "'";
                        SqlCommand gpnss = new SqlCommand(timss, HelpForm.Open());
                        SqlDataAdapter ssspn = new SqlDataAdapter(gpnss);
                        System.Data.DataTable dssss = new System.Data.DataTable();
                        ssspn.Fill(dssss);
                        float tsl = float.Parse(dssss.Rows[0]["TSLuong"].ToString());
                        string timsss = "select Soluong from ChitietNH where MaPN='" + txtmp.Text + "'";
                        SqlCommand gpnsss = new SqlCommand(timsss, HelpForm.Open());
                        SqlDataAdapter sssspn = new SqlDataAdapter(gpnsss);
                        System.Data.DataTable dsssss = new System.Data.DataTable();
                        sssspn.Fill(dsssss);
                        float tt = tsl + (float.Parse(txtsln.Text.ToString()) - float.Parse(dsssss.Rows[0]["Soluong"].ToString()));
                        if (float.Parse(txtsln.Text.ToString()) > tsl)
                        {
                                         
                            string themcc = " UPDATE HangHoa SET TSLuong= '" + tt + "' where MaHH='" + txtMH.Text + "'";
                            SqlCommand thssl = new SqlCommand(themcc, HelpForm.Open());
                            thssl.ExecuteNonQuery();
                            string Se = "Select * from BaoCao where MaHH ='"+txtMH.Text+"'";
                            SqlCommand se1 = new SqlCommand(Se, HelpForm.Open());
                            SqlDataAdapter ssw = new SqlDataAdapter(se1);
                            System.Data.DataTable sss = new System.Data.DataTable();
                            ssw.Fill(sss);
                            if(sss.Rows.Count == 0) {
                                string th1e = "insert into BaoCao values('" + txtMH.Text + "',N'" + txttenhh.Text + "','" + txtsln.Text + "','" + 0 + "')";
                                SqlCommand thm11 = new SqlCommand(th1e, HelpForm.Open());
                                thm11.ExecuteNonQuery();
                            }
                            else {
                                string themcc1 = " UPDATE BaoCao SET SoLuongNhap= '" + tt + "' where MaHH='" + txtMH.Text + "'";
                                SqlCommand thssl1 = new SqlCommand(themcc1, HelpForm.Open());
                                thssl.ExecuteNonQuery();
                            }                           
                            string suapn = "update PhieuNH set NgayNhap='" + dnnh.Text + "', MaNV='" + cbnv.SelectedValue.ToString() + "' where MaPN='"+txtmp.Text+"'";
                            SqlCommand suaa = new SqlCommand(suapn, HelpForm.Open());
                            suaa.ExecuteNonQuery();
                            string sctnh = "update ChiTietNH set TenHH=N'" + txttenhh.Text + "',GiaNhap='" + txtgianhap.Text + "',Donvitinh=N'" + txtdvt.Text + "',NgaySX='" + dngaysx.Text + "',HanSD='" + dhsd.Text + "',Soluong  ='" + txtsln.Text + "',GiamGia='" + txtgiamgia.Text + "',ThanhTien='" + txtthanhtien.Text + "' where MaPN ='"+txtmp.Text+ "' and MaHH='" + txtMH.Text + "'";
                            SqlCommand sctnhh = new SqlCommand(sctnh, HelpForm.Open());
                            sctnhh.ExecuteNonQuery();
                            MessageBox.Show("Đã chỉnh sửa dữ liệu");
                            tbfalse();
                            load();
                            dngaysx.Enabled = false;
                            dhsd.Enabled = false;
                            dnnh.Enabled = false;
                            nhan = "";
                            txtcl();

                        }
                        else
                        {
                            if (float.Parse(txtsln.Text.ToString()) < tsl)
                            {
                                string timssss = "select * from ChiTietNH where MaPN='" + txtmp.Text + "'";
                                SqlCommand gpnssss = new SqlCommand(timssss, HelpForm.Open());
                                SqlDataAdapter ssssspn = new SqlDataAdapter(gpnssss);
                                System.Data.DataTable dssssss = new System.Data.DataTable();
                                ssssspn.Fill(dssssss);
                                float ttt = tsl - (float.Parse(dssssss.Rows[0]["SoLuong"].ToString()) - float.Parse(txtsln.Text.ToString()));                             
                                string themccc = " UPDATE HangHoa SET TSLuong= '" + ttt + "' where MaHH='" + txtMH.Text + "'";
                                SqlCommand thsssl = new SqlCommand(themccc, HelpForm.Open());
                                thsssl.ExecuteNonQuery();
                                string Se = "Select * from BaoCao where MaHH ='" + txtMH.Text + "'";
                                SqlCommand se1 = new SqlCommand(Se, HelpForm.Open());
                                SqlDataAdapter ssw = new SqlDataAdapter(se1);
                                System.Data.DataTable sss = new System.Data.DataTable();
                                ssw.Fill(sss);
                                if (sss.Rows.Count == 0)
                                {
                                    string th1e = "insert into BaoCao values('" + txtMH.Text + "',N'" + txttenhh.Text + "','" + txtsln.Text + "','" + 0 + "')";
                                    SqlCommand thm11 = new SqlCommand(th1e, HelpForm.Open());
                                    thm11.ExecuteNonQuery();
                                }
                                else
                                {
                                    string themcc1 = " UPDATE BaoCao SET SoLuongNhap= '" + tt + "' where MaHH='" + txtMH.Text + "'";
                                    SqlCommand thssl1 = new SqlCommand(themcc1, HelpForm.Open());
                                    thssl1.ExecuteNonQuery();
                                }
                                string ssctnh = "update ChiTietNH set TenHH=N'" + txttenhh.Text + "',GiaNhap='" + txtgianhap.Text + "',Donvitinh=N'" + txtdvt.Text + "',NgaySX='" + dngaysx.Text + "',HanSD='" + dhsd.Text + "',Soluong  ='" + txtsln.Text + "',GiamGia='" + txtgiamgia.Text + "',ThanhTien='" + txtthanhtien.Text + "' where MaPN='" + txtmp.Text + "' and  MaHH='" + txtMH.Text + "'";
                                SqlCommand ssctnhh = new SqlCommand(ssctnh, HelpForm.Open());
                                ssctnhh.ExecuteNonQuery();
                                MessageBox.Show("Đã chỉnh sửa dữ liệu");
                                tbfalse();
                                load();
                                txtcl();
                                dngaysx.Enabled = false;
                                dhsd.Enabled = false;
                                dnnh.Enabled = false;
                                nhan = "";
                            }
                            else
                            {
                                if (float.Parse(txtsln.Text.ToString()) == tsl)
                                {
                                    string Se = "Select * from BaoCao where MaHH ='" + txtMH.Text + "'";
                                    SqlCommand se1 = new SqlCommand(Se, HelpForm.Open());
                                    SqlDataAdapter ssw = new SqlDataAdapter(se1);
                                    System.Data.DataTable sss = new System.Data.DataTable();
                                    ssw.Fill(sss);
                                    if (sss.Rows.Count == 0)
                                    {
                                        string th1e = "insert into BaoCao values('" + txtMH.Text + "',N'" + txttenhh.Text + "','" + txtsln.Text + "','" + 0 + "')";
                                        SqlCommand thm11 = new SqlCommand(th1e, HelpForm.Open());
                                        thm11.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        string themcc1 = " UPDATE BaoCao SET SoLuongNhap= '" + tt + "' where MaHH='" + txtMH.Text + "'";
                                        SqlCommand thssl1 = new SqlCommand(themcc1, HelpForm.Open());
                                        thssl1.ExecuteNonQuery();
                                    }
                                    string sctnh = "update ChiTietNH set MaPN='" + txtmp.Text + "',MaHH='" + txtMH.Text + "',TenHH=N'" + txttenhh.Text + "',GiaNhap='" + txtgianhap.Text + "',Donvitinh=N'" + txtdvt.Text + "',NgaySX='" + dngaysx.Text + "',HanSD='" + dhsd.Text + "',Soluong  ='" + txtsln.Text + "',GiamGia='" + txtgiamgia.Text + "',ThanhTien='" + txtthanhtien.Text + "'";
                                    SqlCommand sctnhh = new SqlCommand(sctnh, HelpForm.Open());
                                    sctnhh.ExecuteNonQuery();
                                    MessageBox.Show("Đã chỉnh sửa dữ liệu");
                                    tbfalse();
                                    load();
                                    txtcl();
                                    dngaysx.Enabled = false;
                                    dhsd.Enabled = false;
                                    dnnh.Enabled = false;
                                    nhan = "";
                                }
                            }
                        }
                    }
                    else
                    {
                        if (nhan == "Thêm" && txtMH.Text != "" && txttenhh.Text != "" && txtgianhap.Text != "" && txtsln.Text != "" && txtdvt.Text != "" && cbncc.Text != "" && dnnh.Text != "" && dngaysx.Text != "" && dhsd.Text != "")
                        {
                            float tt = (float.Parse(txtsln.Text.ToString()) * float.Parse(txtgianhap.Text.ToString())) - ((float.Parse(txtsln.Text.ToString()) * float.Parse(txtgianhap.Text.ToString())) * (float.Parse(txtgiamgia.Text.ToString())) / 100);
                            string tctpn = "insert into ChitietNH values('" + txtmp.Text + "','" + txtMH.Text + "',N'" + txttenhh.Text + "','" + txtgianhap.Text + "',N'" + txtdvt.Text + "','" + dngaysx.Text + "','" + dhsd.Text + "','" + txtsln.Text + "','" + txtgiamgia.Text + "','" + tt + "')";
                            SqlCommand ttctpn = new SqlCommand(tctpn, HelpForm.Open());
                                ttctpn.ExecuteNonQuery();
                            
                            string shh="Select * from HangHoa where MaHH='"+txtMH.Text+"'";
                            SqlCommand gpnss111 = new SqlCommand(shh, HelpForm.Open());
                            SqlDataAdapter ssspn111 = new SqlDataAdapter(gpnss111);
                            System.Data.DataTable dssss111 = new System.Data.DataTable();
                            ssspn111.Fill(dssss111);
                            if (dssss111.Rows.Count <= 0)
                            {
                                string them = "insert into HangHoa values ('" + txtMH.Text + "',N'" + txttenhh.Text + "','" + txtsln.Text + "',N'" + txtdvt.Text + "','" + cbncc.SelectedValue.ToString() + "','" + cbloai.SelectedValue.ToString() + "','"+txtgiamgia.Text+"','"+txtthanhtien.Text+"','"+dngaysx.Value.ToString()+"','"+dhsd.Value.ToString()+"','"+txtgianhap.Text+"')";
                                SqlCommand thm = new SqlCommand(them, HelpForm.Open());
                                thm.ExecuteNonQuery();
                                string the = "insert into BaoCao values('" + txtMH.Text + "',N'" + txttenhh.Text + "','" + txtsln.Text + "','" + 0 + "')";
                                SqlCommand thm1 = new SqlCommand(the, HelpForm.Open());
                                thm1.ExecuteNonQuery();

                            }
                            else {
                               
                                float slk1 = float.Parse(dssss111.Rows[0]["TSLuong"].ToString());
                                float tk1 = slk1 + float.Parse(txtsln.Text.ToString());
                                string t1 = Convert.ToString(tk1);
                                string themc1 = " UPDATE HangHoa SET TSLuong= '" + t1 + "' where MaHH='" + txtMH.Text + "'";
                                SqlCommand thsl1 = new SqlCommand(themc1, HelpForm.Open());
                                thsl1.ExecuteNonQuery();
                                string themc2 = " UPDATE BaoCao SET SoLuongNhap= '" + t1 + "' where MaHH='" + txtMH.Text + "'";
                                SqlCommand thsl2 = new SqlCommand(themc2, HelpForm.Open());
                                thsl2.ExecuteNonQuery();
                            }
                            load();
                            MessageBox.Show("Đã xong");
                            txtcl();
                            nhan = ".";
                        }
                        else //nếu có mã hàng hóa thì cộng số lượng nhập vào số lượng trong kho
                        {
                            if (nhan == "Thêm" && txtMH.Text != "" && txttenhh.Text != "" && txtgianhap.Text != "" && txtsln.Text != "" && txtdvt.Text != "" && cbncc.Text != "" && dnnh.Text != "" && dngaysx.Text != "" && dhsd.Text != "")
                            {
                                string timss1 = "select * from HangHoa where MaHH='" + txtMH.Text + "'";
                                SqlCommand gpnss1 = new SqlCommand(timss1, HelpForm.Open());
                                SqlDataAdapter ssspn1 = new SqlDataAdapter(gpnss1);
                                System.Data.DataTable dssss1 = new System.Data.DataTable();
                                ssspn1.Fill(dssss1);
                                float slk1 = float.Parse(dssss1.Rows[0]["TSLuong"].ToString());
                                float tk1 = slk1 + float.Parse(txtsln.Text.ToString());
                                string t1 = Convert.ToString(tk1);
                                string themc1 = " UPDATE HangHoa SET TSLuong= '" + t1 + "' where MaHH='" + txtMH.Text + "'";
                                SqlCommand thsl1 = new SqlCommand(themc1, HelpForm.Open());
                                thsl1.ExecuteNonQuery();
                                string timss11 = "select * from ChiTietNH where MaHH='" + txtMH.Text + "'";
                                SqlCommand gpnss11 = new SqlCommand(timss1, HelpForm.Open());
                                SqlDataAdapter ssspn11 = new SqlDataAdapter(gpnss11);
                                System.Data.DataTable dssss11 = new System.Data.DataTable();
                                ssspn11.Fill(dssss11);
                                if (dssss11.Rows.Count <= 0)
                                {
                                   // float ttt = (float.Parse(txtsln.Text.ToString()) * float.Parse(txtgianhap.Text.ToString())) - ((float.Parse(txtsln.Text.ToString()) * float.Parse(txtgianhap.Text.ToString())) * (float.Parse(txtgiamgia.Text.ToString())) / 100);
                                    string tctpn = "insert into ChitietNH values('" + txtmp.Text + "','" + txtMH.Text + "',N'" + txttenhh.Text + "','" + txtgianhap.Text + "',N'" + txtdvt.Text + "','" + dngaysx.Text + "','" + dhsd.Text + "','" + txtsln.Text + "','" + txtgiamgia.Text + "','" + txtthanhtien.Text + "')";
                                    SqlCommand ttctpn = new SqlCommand(tctpn, HelpForm.Open());
                                    ttctpn.ExecuteNonQuery();
                                }
                                else
                                {
                                    //float ttt = (float.Parse(txtsln.Text.ToString()) * float.Parse(txtgianhap.Text.ToString())) - ((float.Parse(txtsln.Text.ToString()) * float.Parse(txtgianhap.Text.ToString())) * (float.Parse(txtgiamgia.Text.ToString())) / 100);
                                    float slk11 = float.Parse(dssss11.Rows[0]["SoLuong"].ToString());
                                    float tk11 = slk11 + float.Parse(txtsln.Text.ToString());
                                    string t11 = Convert.ToString(tk1);
                                    string tctpn = " update ChitietNH set SoLuong='" + t11 + "' where MaHH ='" + txtMH.Text + "'"; 
                                    SqlCommand ttctpn = new SqlCommand(tctpn, HelpForm.Open());
                                    ttctpn.ExecuteNonQuery();
                                }
                                load();
                                MessageBox.Show("Đã xong");
                                txtcl();
                                nhan = "";
                            }
                            else { MessageBox.Show("Còn thiếu thông tin!!"); }
                        }
                    }
                }
            }
        }
        private void txtcl() {
            txtMH.Clear();
            txtsln.Clear();
            txtthanhtien.Clear();
            txttenhh.Clear();
            txtgianhap.Clear();
            txtgiamgia.Clear();
            txtdvt.Clear();
        }
        private void label10_Click(object sender, EventArgs e)
        {
            ThemLoaiHang ftl = new ThemLoaiHang(mphieunhap,tnv,tdn,CV);
            ftl.Show();
            this.Hide();
        }
        private void label13_Click(object sender, EventArgs e)
        {
            ThemNCC fncc = new ThemNCC(mphieunhap,tdn,tdn,CV);
            fncc.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {   int sum = 0;
            for (int i = 0; i < dnh.Rows.Count; ++i)
            {
              sum += Convert.ToInt32(dnh.Rows[i].Cells["ThanhTien"].Value);
            }

            if (dnh.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = mphieunhap + ".pdf";
                bool fileError = false;
                PdfPTable pdfPt = new PdfPTable(dnh.Columns.Count);
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
                            tbcc.Add(new Chunk("PHIẾU NHẬP KHO\n", tbc));
                            prgHeading.Add(new Chunk("\n", tbc));
                            ncc.Add(new Chunk("Tổng tiền:  " + sum.ToString()+" VNĐ\n", nldd));
                            tbcc.Add(new Chunk("\n", tbc));
                            tbcc.Add(new Chunk("Ngày lập phiếu:  "+DateTime.Now.ToShortDateString(), cet));
                            tbcc.Add(new Chunk("\nMã Số Phiếu:  " +txtmp.Text+"             ", cet));
                            tbcc.Add(new Chunk("\n", tbc));
                            tbcc.Add(new Chunk("\n", tbc));
                            ncc.Add(new Chunk("     Người Giao Hàng                                                                                                "+"Người Lập Phiếu\n", nldd));
                            ncc.Add(new Chunk("         (Ký,ghi rõ họ tên)                                                                                                                        "+"(Ký, ghi rõ họ tên)\n", cet)); 
                            PdfPTable pdfTable = new PdfPTable(dnh.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 95;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            foreach (DataGridViewColumn column in dnh.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, nldd));
                                pdfTable.AddCell(cell);
                            }
                            for (int i = 0; i < dnh.Rows.Count; i++)
                            {      
                                for (int j =0; j < dnh.Columns.Count; j++)
                                {
                                    System.Data.DataTable d = (System.Data.DataTable)dnh.DataSource;
                                    pdfTable.AddCell(new Phrase(d.Rows[i][j].ToString(), cet));
                                }
                            }
                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4,10f,5f,10f,0f);
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

        private void cbloai_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string slec = "select * from ChitietNH";
            dnh.DataSource = HelpForm.Gettable(slec);
            // string aapn = "select phieuNH.MaPN,ChitietNH.MaHH,TenLoai,ChitietNH.TenHH,NhaCC.TenNCC,NgayNhap,NgaySX,HanSD,ChitietNH.Donvitinh,GiaNhap,SoLuong,GiamGia,ThanhTien,MaNV from ChitietNH join PhieuNH on PhieuNH.MaPN = ChitietNH.MaPN join HangHoa on HangHoa.MaHH = ChitietNH.MaHH join NhaCC on HangHoa.MaNCC = NhaCC.MaNCC join LoaiHang on HangHoa.MaLoai = LoaiHang.MaLoai where PhieuNH.MaPN ='" + mphieunhap + "'";
            //dnh.DataSource = HelpForm.Gettable(aapn);
            tbclear();
        }

        private void txtgianhap_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float t1 = (float.Parse(txtgianhap.Text.ToString()) * float.Parse(txtsln.Text.ToString()));
                float t2 = ((float.Parse(txtgianhap.Text.ToString()) * float.Parse(txtsln.Text.ToString())) * ((float.Parse(txtgiamgia.Text.ToString())) / 100));
                float t3 = t1 - t2;
                string ttt = Convert.ToString(t3);
                txtthanhtien.Text = ttt;
            }
            catch (Exception ex) { }
        }

        private void txtsln_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float t1 = (float.Parse(txtgianhap.Text.ToString()) * float.Parse(txtsln.Text.ToString()));
                float t2 = ((float.Parse(txtgianhap.Text.ToString()) * float.Parse(txtsln.Text.ToString())) * ((float.Parse(txtgiamgia.Text.ToString())) / 100));
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
                float t1 = (float.Parse(txtgianhap.Text.ToString()) * float.Parse(txtsln.Text.ToString()));
                float t2 =((float.Parse(txtgianhap.Text.ToString()) * float.Parse(txtsln.Text.ToString())) * ((float.Parse(txtgiamgia.Text.ToString()))/100));
                float t3 = t1 - t2;
                string ttt = Convert.ToString(t3);
                txtthanhtien.Text = ttt;
            }
            catch (Exception ex) { }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sqll = "select * from  ChitietNH";
            SqlDataAdapter ada = new SqlDataAdapter(sqll, HelpForm.Open());
            System.Data.DataTable daa = new System.Data.DataTable();
            ada.Fill(daa);
            DataView dv = new DataView(daa);
            if (txttimkiem.Text == "")
            { MessageBox.Show("Bạn muốn tìm gì hãy ghi ra nào!!!"); txttimkiem.Focus(); }
            else
            {
                dv.RowFilter = " TenHH like \'%" + txttimkiem.Text + "%\'";
                dnh.DataSource = dv;
            }
        }

        private void txttimkiem_Leave(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                txttimkiem.Text = "Tên hàng hóa";
                txttimkiem.ForeColor = Color.Gray;

            }
        }

        private void txttimkiem_Enter(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "Tên hàng hóa")
            { txttimkiem.Text = ""; txttimkiem.ForeColor = Color.Black; }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            tbtrue();
            if (txtMH.Text == "" && txttenhh.Text == "" && txtsln.Text == "" && txtmp.Text == "")
            { MessageBox.Show("Bạn chưa chọn mặt hàng cần xóa"); }
            else
            {
                DialogResult DR = MessageBox.Show("Bạn có chắc muốn xóa mặt hàng này", "Xác nhận", MessageBoxButtons.OKCancel);
                if (DialogResult.OK == DR)
                {

                    string xoa = "delete from ChiTietNH where MaHH='" + txtMH.Text + "'";
                    SqlCommand delete = new SqlCommand(xoa, HelpForm.Open());
                    delete.ExecuteNonQuery();
                    MessageBox.Show("Đã xóa thành công");
                    load();
                }
            }
        }

        private void dnh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbc() {
            txttenhh.Clear();
            txtgiamgia.Clear();
            txtgianhap.Clear();
            txtthanhtien.Clear();
            txtdvt.Clear();
            txtsln.Clear();
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            tbc();
            txtmp.ReadOnly = true;
            dnnh.Value = DateTime.Now;
            tbtrue();
            string hh = "select * from HangHoa where MaLoai='" + cbloai.SelectedValue.ToString() + "'";
            SqlCommand ghh = new SqlCommand(hh, HelpForm.Open());
            SqlDataAdapter shh = new SqlDataAdapter(ghh);
            System.Data.DataTable dhh = new System.Data.DataTable();
            shh.Fill(dhh);
            if (dhh.Rows.Count < 0)
            {
                txtMH.Text = cbloai.SelectedValue.ToString() + "1";
            }
            else
            {
                float k;
                k = Convert.ToInt32((dhh.Rows.Count).ToString());
                k++;
                txtMH.Text = cbloai.SelectedValue.ToString() + k;
            }
            nhan = "Thêm"; 
            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            dngaysx.Enabled = true;
            dhsd.Enabled = true;
            dnnh.Enabled = true;
            txtgiamgia.Enabled = true;
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            load();
            tbclear();
            tbfalse();
            txtmp.Enabled = false;
           // btnsua.Enabled = true;
           // btnxoa.Enabled = true;
           // btntrove.Enabled = true;
            btntimkiem.Enabled = true;
            dngaysx.Enabled = false;
            dhsd.Enabled = false;
            dnnh.Enabled = false;
        }

        private void btntrove_Click(object sender, EventArgs e)
        {
            
            PhieuNhapHang fpnh = new PhieuNhapHang(mnv, tnv, tdn, CV);
            fpnh.Show();
            this.Hide();
        }
    }
    
}
