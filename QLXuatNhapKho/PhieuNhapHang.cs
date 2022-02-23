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
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;


namespace QLXuatNhapKho
{
    public partial class PhieuNhapHang : Form
    {
        string tnv = "", tdn = "", mk = "", CV = "", mnv;
        public PhieuNhapHang()
        {
            InitializeComponent();
        }
        public PhieuNhapHang(string mnv, string tnv, string tdn, string cV)
        {
            InitializeComponent();
            this.mnv = mnv;
            this.tnv = tnv;
            this.tdn = tdn;
            this.CV = cV;
        }
        private void btntrove_Click(object sender, EventArgs e)
        {
            Menuchucnang fmncn = new Menuchucnang(mnv, cbnv.Text, tdn, CV);
            fmncn.Show();
            this.Hide();
        }
        string nhan = "";
        private void btnthem_Click(object sender, EventArgs e)
        {
            nhan = "thêm";
            txtmp.ReadOnly = true;
            dnnh.Value = DateTime.Now;
            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            dnnh.Enabled = true;
            string pn = "select * from PhieuNH";
            SqlCommand gpn = new SqlCommand(pn, HelpForm.Open());
            SqlDataAdapter spn = new SqlDataAdapter(gpn);
            System.Data.DataTable ds = new System.Data.DataTable();
            spn.Fill(ds);
            if (ds.Rows.Count <= 0)
            {
                txtmp.Text = "PN" + "1";
                string t = "insert into PhieuNH values('" + txtmp.Text + "','" + dnnh.Text + "','" + cbnv.SelectedValue.ToString() + "')";
                SqlCommand tt = new SqlCommand(t, HelpForm.Open());
                tt.ExecuteNonQuery();             
                ChiTietPN fpn = new ChiTietPN(mnv,txtmp.Text, cbnv.SelectedValue.ToString(),tdn, CV);
                fpn.Show();
                this.Hide();
            }
            else
            {
                int mpn;
                mpn = Convert.ToInt32(ds.Rows.Count.ToString());
                mpn++;
                txtmp.Text = "PN" + mpn;
                string t = "insert into PhieuNH values('" + txtmp.Text + "','" + dnnh.Text + "','" + cbnv.SelectedValue.ToString() + "')";
                SqlCommand tt = new SqlCommand(t, HelpForm.Open());
                tt.ExecuteNonQuery();
                ChiTietPN fpn = new ChiTietPN(mnv,txtmp.Text, cbnv.SelectedValue.ToString(),tdn, CV);
                fpn.Show();
                this.Hide();
            }
        }
        private void btnluu_Click(object sender, EventArgs e)
        {

        }
        private void btnhuy_Click(object sender, EventArgs e)
        {
            txttimkiem.Text = "Mã phiếu nhập hàng";
            txttimkiem.ForeColor = Color.Gray;
            txtmp.ReadOnly = true;
            txtmp.Clear();
            btntimkiem.Enabled = true;
            dnnh.Enabled = false;
        }
        private void PhieuNhapHang_Load(object sender, EventArgs e)
        {
            string nvv = "select * from TaiKhoanNV";
            cbnv.DisplayMember = "TenNV";
            cbnv.ValueMember = "MaNV";
            cbnv.DataSource = HelpForm.Gettable(nvv);
            txtmp.Enabled =false;
            dnnh.Format = DateTimePickerFormat.Short;
            dnnh.Value = DateTime.Now;
            string sls = "select * from  PhieuNH";
            dpn.DataSource = HelpForm.Gettable(sls);
          
        }
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (CV == "0") { MessageBox.Show("Bạn Không đủ quyền truy cập"); }
            //tbtrue();
            else
            {
                if (txtmp.Text == "" && cbnv.Text == "")
                { MessageBox.Show("Bạn chưa chọn phiếu cần xóa"); }
                else
                {
                    DialogResult DR = MessageBox.Show("Chắc chắn xóa", "Xác nhận", MessageBoxButtons.OKCancel);
                    if (DialogResult.OK == DR)
                    {
                        string scthh = "select * from ChitietNH where MaPN ='" + txtmp.Text + "'";
                        SqlDataAdapter ada = new SqlDataAdapter(scthh, HelpForm.Open());
                        System.Data.DataTable daa = new System.Data.DataTable();
                        ada.Fill(daa);
                        if (daa.Rows.Count > 0)
                        {
                            DialogResult DRr = MessageBox.Show("Dữ liệu cần xóa ở bảng khác !! Di chuyển đến", "Xác nhận", MessageBoxButtons.OKCancel);
                            if (DialogResult.OK == DRr)
                            {
                                ChiTietPN fpn = new ChiTietPN(mnv, txtmp.Text, cbnv.SelectedValue.ToString(), tdn, CV);
                                fpn.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            string del = " delete from PhieuNH where MaPN= '" + txtmp.Text + "'";
                            SqlCommand d = new SqlCommand(del, HelpForm.Open());
                            d.ExecuteNonQuery();
                            MessageBox.Show("Đã xóa thành công phiếu nhập hàng '" + txtmp.Text + "'");
                            string slss = "select * from  PhieuNH";
                            dpn.DataSource = HelpForm.Gettable(slss);
                            txtmp.Clear();
                        }
                    }
                }
            }
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txtmp.Text != "" && cbnv.Text != "")
                {
                    ChiTietPN fpn = new ChiTietPN(mnv,txtmp.Text,cbnv.SelectedValue.ToString(), tdn, CV);
                    fpn.Show();
                    this.Hide();
                }
             else { MessageBox.Show("Bạn chưa chọn phiếu"); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        private void txttimkiem_Enter_1(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "Mã phiếu nhập hàng") { txttimkiem.Text = ""; txttimkiem.ForeColor = Color.Black; }
        }
        private void txttimkiem_Leave(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                txttimkiem.Text = "Mã phiếu nhập hàng";
                txttimkiem.ForeColor = Color.Gray;
            }
        }
        private void btnall_Click(object sender, EventArgs e)
        {
            string sl = "select * from  PhieuNH";
            dpn.DataSource = HelpForm.Gettable(sl);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dpn.Rows.Count; i++)
                if (e.RowIndex == i)
                {
                    DataGridViewRow row = this.dpn.Rows[e.RowIndex];
                    txtmp.Text = row.Cells[0].Value.ToString();
                    dnnh.Text = row.Cells[1].Value.ToString();
                    cbnv.SelectedValue = row.Cells[2].Value.ToString();
                }
        }
        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sqll = "select * from  PhieuNH";
            SqlDataAdapter ada = new SqlDataAdapter(sqll, HelpForm.Open());
            System.Data.DataTable daa = new System.Data.DataTable();
            ada.Fill(daa);
            DataView dv = new DataView(daa);
            if (txttimkiem.Text == "")
            { MessageBox.Show("Bạn muốn tìm gì hãy ghi ra nào!!!"); txttimkiem.Focus(); }
            else
            {
                dv.RowFilter = " MaPN like \'%" + txttimkiem.Text + "%\'";
                dpn.DataSource = dv;
            }
            txtmp.Clear();           
        }
        private void cbnv_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ssqll = "select * from  PhieuNH where MaNV ='"+cbnv.SelectedValue.ToString()+"'";
            SqlDataAdapter ad = new SqlDataAdapter(ssqll, HelpForm.Open());
           
        }
    } 
}
