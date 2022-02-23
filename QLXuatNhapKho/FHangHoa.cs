using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;



namespace QLXuatNhapKho
{

    public partial class FHangHoa : Form
    {
        string tnv = "", tdn = "", mk = "", CV = "", mnv;
        public FHangHoa()
        {
            InitializeComponent();
        }

        public FHangHoa(string mnv, string tnv, string tdn, string cV)
        {
            InitializeComponent();
            this.mnv = mnv;
            this.tnv = tnv;
            this.tdn = tdn;
            this.CV = cV;
        }

        string sqll = "select * from hangHoa";

        private void load()
        {


            //string sql = "select Hanghoa.MaHH,HangHoa.TenHH,GiaNhap,TSLuong,Hanghoa.Donvitinh,Tenloai,TenNCC,HangHoa.NgaySX,HangHoa.HanSD, HangHoa.ThanhTien,  HangHoa.Giamgia from HangHoa,LoaiHang, NhaCC, where  HangHoa.MaLoai = LoaiHang.MaLoai and HangHoa.MaNCC = NhaCC.MaNCC";
            dhh.DataSource = HelpForm.Gettable(sqll) ;
            string lhh = "Select * from LoaiHang";
            cbloai.DisplayMember = "TenLoai";
            cbloai.ValueMember = "MaLoai";
            cbloai.DataSource = HelpForm.Gettable(lhh);
            // string nv = "select * from TaiKhoanNV";
            string ncc = "select * from NhaCC";
            cbncc.DisplayMember = "TenNCC";
            cbncc.ValueMember = "MaNCC";
            cbncc.DataSource = HelpForm.Gettable(ncc);
        }
        private void tbfalse()
        {
            txtMH.ReadOnly = true;
            txttenhh.ReadOnly = true;
            txtgianhap.ReadOnly = true;
            //txtgiahang.ReadOnly = true;
            txttsl.ReadOnly = true;
            txtdvt.ReadOnly = true;
            txtthanhtien.ReadOnly = true;


            this.cbloai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
        private void tbtrue()
        {
            txtMH.ReadOnly = false;
            txttenhh.ReadOnly = false;
            txtgianhap.ReadOnly = false;
            //txtgiahang.ReadOnly = false;
            txttsl.ReadOnly = false;
            txtdvt.ReadOnly = false;
            txtthanhtien.ReadOnly = false;

        }
        private void FHangHoa_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dhh.Columns.Count; i++)
            {
                dhh.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            try
            {
                string d = "drop table HSD";
                SqlCommand d1 = new SqlCommand(d, HelpForm.Open());
                d1.ExecuteNonQuery();
            }
            catch(Exception el) { }
            tnvv.Text = tnv;
            load();
            tbfalse();
            dngaysx.Format = DateTimePickerFormat.Short;
            dhsd.Format = DateTimePickerFormat.Short;
            dngaysx.Value = DateTime.Now;
            dhsd.Value = DateTime.Now;
            dngaysx.Enabled = false;
            dhsd.Enabled = false;
           



        }
       
        private void tbclear()
        {
            txtMH.Clear();
            txttenhh.Clear();
            txtgianhap.Clear();
            txttsl.Clear();
            txtdvt.Clear();
            txtthanhtien.Clear();

        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            SqlDataAdapter ada = new SqlDataAdapter(sqll, HelpForm.Open());
            System.Data.DataTable daa = new System.Data.DataTable();
            ada.Fill(daa);
            DataView dv = new DataView(daa);
            if (txttimkiem.Text == "")
            { MessageBox.Show("Bạn muốn tìm gì hãy ghi ra nào!!!"); txttimkiem.Focus(); }
            else
            {
                dv.RowFilter = " TenHH like \'%" + txttimkiem.Text + "%\'";
                dhh.DataSource = dv;
            }
            tbclear();
        }

        private void btntrove_Click(object sender, EventArgs e)
        {
            Menuchucnang fmncn = new Menuchucnang(mnv, tnv, tdn, CV);
            fmncn.Show();
            this.Hide();

        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            try
            {
                string d = "drop table HSD";
                SqlCommand d1 = new SqlCommand(d, HelpForm.Open());
                d1.ExecuteNonQuery();
            }
            catch (Exception el) { }
            btnxoa.Enabled = true;
            btntrove.Enabled = true;
            btntimkiem.Enabled = true;
            
            dngaysx.Value = DateTime.Now;
            dhsd.Value = DateTime.Now;
            dngaysx.Enabled = false;
            dhsd.Enabled = false;
            
            txttimkiem.Text = "Tên hàng hóa";
            txttimkiem.ForeColor = Color.Gray;
            tbclear();
            tbfalse();
            load();

        }

        private void btnall_Click(object sender, EventArgs e)
        {
            SqlDataAdapter aad = new SqlDataAdapter(sqll, HelpForm.Open());
            System.Data.DataTable daa = new System.Data.DataTable();
            aad.Fill(daa);
            DataView dva = new DataView(daa);

            dhh.DataSource = dva;
        }

        private void cbloai_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlDataAdapter ad = new SqlDataAdapter(sqll, HelpForm.Open());
            System.Data.DataTable da = new System.Data.DataTable();
            ad.Fill(da);
            DataView dv = new DataView(da);
            dv.RowFilter = " MaLoai like '" + cbloai.SelectedValue + "'";
            dhh.DataSource = dv;
            tbclear();
        }

        private void dhh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int i = 0; i < dhh.Rows.Count; i++)
                    if (e.RowIndex == i)
                    {

                        DataGridViewRow row = this.dhh.Rows[e.RowIndex];
                        txtMH.Text = row.Cells[0].Value.ToString();
                        txttenhh.Text = row.Cells[1].Value.ToString();
                        txttsl.Text = row.Cells[2].Value.ToString();
                        txtdvt.Text = row.Cells[3].Value.ToString();
                        txtgianhap.Text = row.Cells[10].Value.ToString();
                        cbncc.Text = row.Cells[4].Value.ToString();
                        cbloai.Text = row.Cells[5].Value.ToString();
                       
                       
                        dngaysx.Text = row.Cells[8].Value.ToString();
                        dhsd.Text = row.Cells[9].Value.ToString();
                        txtthanhtien.Text = row.Cells[7].Value.ToString();
                        txtgiamgia.Text = row.Cells[6].Value.ToString();
                        txttimkiem.Clear();
                    }
            }
            catch (Exception ex) { }
        }
          
                
        
        string nhan = "";
        private void button2_Click(object sender, EventArgs e)
        {   if (CV == "1")
            {

                tbtrue();
                txtMH.ReadOnly = true;
                nhan = "Sửa";
                dngaysx.Enabled = true;
                dhsd.Enabled = true;
                
            }
            else
            {
                MessageBox.Show("Bạn không đủ quyền truy cập!!");
            }
            
        }

        private void txtgianhap_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select Hanghoa.MaHH,HangHoa.TenHH,GiaNhap,TSLuong,Hanghoa.Donvitinh,Tenloai,TenNCC,NgayNhap,NgaySX,HanSD, GiaNhap*TSLuong as ThanhTien from HangHoa, ChitietNH, LoaiHang, NhaCC, PhieuNH where HangHoa.MaHH = ChitietNH.MaHH and HangHoa.MaLoai = LoaiHang.MaLoai and HangHoa.MaNCC = NhaCC.MaNCC and ChitietNH.MaPN = PhieuNH.MaPN";
            dhh.DataSource = HelpForm.Gettable(sql);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 24;
            
            for(int i =1;i < dhh.Columns.Count + 1; i++)
            {
                obj.Cells[1, i] = dhh.Columns[i - 1].HeaderText;
               
            }
            for (int t = 0; t < dhh.Rows.Count; t++)
            {
                for (int j = 0; j < dhh.Columns.Count; j++)
                {
                    if (dhh.Rows[t].Cells[j].Value != null)
                    {
                        obj.Cells[t + 2, j + 1] = dhh.Rows[t].Cells[j].Value.ToString();
                    }
                }
            }
            obj.Visible = true;
            
            // obj.ActiveWorkbook.SaveCopyAs(@"D:\CT239\QLXuatNhapKho\HangHoa" + ".xlsx");
            // obj.ActiveWorkbook.Saved = true;
            MessageBox.Show("Đã in báo cáo thành công!!");
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

        private void txtgianhap_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float t1 = (float.Parse(txtgianhap.Text.ToString()) * float.Parse(txttsl.Text.ToString()));
                //float t2 = ((float.Parse(txtgianhap.Text.ToString()) * float.Parse(txttsl.Text.ToString())) * ((float.Parse(txtgiamgia.Text.ToString())) / 100));
                //float t3 = t1 - t2;
                string ttt = Convert.ToString(t1);
                txtthanhtien.Text = ttt;
            }
            catch (Exception ex) { }
        }

        private void txttsl_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float t1 = (float.Parse(txtgianhap.Text.ToString()) * float.Parse(txttsl.Text.ToString()));
                string ttt = Convert.ToString(t1);
                txtthanhtien.Text = ttt;
            }
            catch (Exception ex) { }

        }

        private void btall_Click(object sender, EventArgs e)
        {
                BaoCao fbc = new BaoCao(mnv, tnv, tdn, CV);
            fbc.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void dhh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbncc_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter ad = new SqlDataAdapter(sqll, HelpForm.Open());
            System.Data.DataTable da = new System.Data.DataTable();
            ad.Fill(da);
            DataView dv = new DataView(da);
            dv.RowFilter = " MaNCC like '" + cbncc.SelectedValue + "'";
            dhh.DataSource = dv;
            tbclear();
        }

        private void txtgiahang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        
        private void txttsl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
           
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            try
            {
                if (nhan == "")
                {
                    MessageBox.Show("Không có thay đổi gì để lưu");
                }
                else
                {
                    if (txtMH.Text == "" && txttenhh.Text == "" && txttsl.Text == "" && txttsl.Text == "")
                    {

                        MessageBox.Show("Bạn chưa chọn gì cả");
                    }

                    else
                    {
                        if (nhan == "Sửa")
                        {
                            string sua = "update HangHoa set TenHH=N'"+txttenhh.Text+"',TSLuong='"+txttsl.Text+"',Donvitinh=N'"+txtdvt.Text+ "',NgaySX='" + dngaysx.Text + "', HanSD ='" + dhsd.Text + "' where MaHH ='" + txtMH.Text+ "' ";
                            SqlCommand suaa = new SqlCommand(sua, HelpForm.Open());
                            suaa.ExecuteNonQuery();
                            string sua1= "update [ChitietNH] set TenHH=N'" + txttenhh.Text + "', GiaNhap='" + txtgianhap.Text+"',NgaySX='"+dngaysx.Text+"', HanSD ='"+dhsd.Text+"' where MaHH='"+txtMH.Text+"'";
                            SqlCommand suaa1 = new SqlCommand(sua1, HelpForm.Open());
                            suaa1.ExecuteNonQuery();
                            MessageBox.Show("Đã chỉnh sửa thành công!!");
                            load();
                            tbfalse();
                            dngaysx.Enabled = false;
                            dhsd.Enabled = false;
                            dngaysx.Format = DateTimePickerFormat.Short;
                            dhsd.Format = DateTimePickerFormat.Short;
                            dngaysx.Value = DateTime.Now;
                            dhsd.Value = DateTime.Now;

                            nhan = "";
                        }
                        


                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhẹ đâu đó!!!");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (CV == "1")
            {
                if (txtMH.Text == "" && txttenhh.Text == "" && txttsl.Text == "" && txttsl.Text == "")
                { MessageBox.Show("Bạn chưa chọn hàng hóa cần xóa"); }
                else
                {
                    DialogResult DR = MessageBox.Show("Bạn có chắc muốn xóa mặt hàng này", "Xác nhận", MessageBoxButtons.OKCancel);
                    if (DialogResult.OK == DR)
                    {
                        string xoa = "delete from HangHoa where MaHH='" + txtMH.Text + @"'";
                        SqlCommand delete = new SqlCommand(xoa, HelpForm.Open());
                        delete.ExecuteNonQuery();
                        string xoa1 = "delete from ChitietNH where MaHH='" + txtMH.Text + "'";
                        SqlCommand delete1 = new SqlCommand(xoa1, HelpForm.Open());
                        delete1.ExecuteNonQuery();
                        MessageBox.Show("Đã xóa thành công");
                        load();
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không đủ quyền truy cập!!");
            }
        }
    }
}