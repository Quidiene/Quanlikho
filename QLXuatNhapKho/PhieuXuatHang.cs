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
    public partial class PhieuXuatHang : Form
    {
        string mphieuxuat, tnv = "", tdn = "", mk = "", CV = "", mnv;

        private void button5_Click(object sender, EventArgs e)
        {
            Menuchucnang fmncn = new Menuchucnang(mnv, tnv, tdn, CV);
            fmncn.Show();
            this.Hide();
        }
        public PhieuXuatHang(string mnv, string tnv, string tdn, string CV)
        {
            InitializeComponent();
           // this.mphieuxuat = mp;
            this.tnv = tnv;
            this.tdn = tdn;
            this.CV = CV;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtmp.Text != "" && cbnv.Text != "" && cbkh.Text !="")
            {
                ChitietXH fpx = new ChitietXH(mnv, txtmp.Text, cbnv.Text, tdn, CV);
                fpx.Show();
                this.Hide();
            }
            else { MessageBox.Show("Bạn chưa chọn phiếu"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {   if (CV == "0") { MessageBox.Show("Bạn Không đủ quyền truy cập"); }
            else
            {
                if (txtmp.Text == "" && cbnv.Text == "")
                { MessageBox.Show("Bạn chưa chọn phiếu cần xóa"); }
                else
                {
                    DialogResult DR = MessageBox.Show("Chắc chắn xóa", "Xác nhận", MessageBoxButtons.OKCancel);
                    if (DialogResult.OK == DR)
                    {
                        string slctpn = "select * from ChitietXH where MaPX ='" + txtmp.Text + "'";
                        SqlDataAdapter ada = new SqlDataAdapter(slctpn, HelpForm.Open());
                        System.Data.DataTable daa = new System.Data.DataTable();
                        ada.Fill(daa);
                        if (daa.Rows.Count > 0)
                        {
                            DialogResult DRr = MessageBox.Show("Dữ liệu cần xóa ở bảng khác !! Di chuyển đến", "Xác nhận", MessageBoxButtons.OKCancel);
                            if (DialogResult.OK == DRr)
                            {
                                ChitietXH fpn = new ChitietXH(mnv, txtmp.Text, cbnv.Text.ToString(), tdn, CV);
                                fpn.Show();
                                this.Hide();
                            }

                        }
                        else
                        {
                            string del = " delete from PhieuXuat where MaPX= '" + txtmp.Text + "'";
                            SqlCommand d = new SqlCommand(del, HelpForm.Open());
                            d.ExecuteNonQuery();
                            MessageBox.Show("Đã xóa thành công phiếu xuất hàng '" + txtmp.Text + "'");
                            string slss = "select * from  PhieuXuat";
                            dxh.DataSource = HelpForm.Gettable(slss);
                            txtmp.Clear();
                        }

                    }
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ThemKH ftkh = new ThemKH(mnv, tnv, tdn, CV);
            ftkh.Show();
            this.Hide();

        }

        private void dxh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (float i = 0; i < dxh.Rows.Count; i++)
            {
                try
                {
                    if (e.RowIndex == i)
                    {
                        DataGridViewRow row = this.dxh.Rows[e.RowIndex];
                        txtmp.Text = row.Cells[0].Value.ToString();
                        dnxh.Text = row.Cells[1].Value.ToString();
                        cbnv.SelectedValue = row.Cells[2].Value.ToString();
                        cbkh.SelectedValue = row.Cells[3].Value.ToString();
                    }
                }
                catch(Exception ex) { }
             }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 24;

            for (int i = 1; i < dxh.Columns.Count + 1; i++)
            {
                obj.Cells[1, i] = dxh.Columns[i - 1].HeaderText;

            }
            for (int t = 0; t < dxh.Rows.Count; t++)
            {
                for (int j = 0; j < dxh.Columns.Count; j++)
                {
                    if (dxh.Rows[t].Cells[j].Value != null)
                    {
                        obj.Cells[t + 2, j + 1] = dxh.Rows[t].Cells[j].Value.ToString();
                    }
                }
            }
            obj.Visible = true;

            // obj.ActiveWorkbook.SaveCopyAs(@"D:\CT239\QLXuatNhapKho\HangHoa" + ".xlsx");
            // obj.ActiveWorkbook.Saved = true;
            MessageBox.Show("Đã in báo cáo thành công!!");
        }

        private void txttim_Enter(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "Mã phiếu") { txttimkiem.Text = ""; txttimkiem.ForeColor = Color.Black; }

        }

        private void txttimkiem_Leave(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                txttimkiem.Text = "Mã phiếu";
                txttimkiem.ForeColor = Color.Gray;

            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sqll = "select * from  PhieuXuat";
            SqlDataAdapter ada = new SqlDataAdapter(sqll, HelpForm.Open());
            System.Data.DataTable daa = new System.Data.DataTable();
            ada.Fill(daa);
            DataView dv = new DataView(daa);
            if (txttimkiem.Text == "")
            { MessageBox.Show("Bạn muốn tìm gì hãy ghi ra nào!!!"); txttimkiem.Focus(); }
            else
            {
                dv.RowFilter = " MaPX like \'%" + txttimkiem.Text + "%\'";
                dxh.DataSource = dv;
            }
            txtmp.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtmp.ReadOnly = true;
            dnxh.Value = DateTime.Now;
           // btnxoa.Enabled = false;
           // btnsua.Enabled = false;
            dnxh.Enabled = true;
            string pn = "select * from PhieuXuat";
            SqlCommand gpn = new SqlCommand(pn, HelpForm.Open());
            SqlDataAdapter spn = new SqlDataAdapter(gpn);
            System.Data.DataTable ds = new System.Data.DataTable();
            spn.Fill(ds);
            if (ds.Rows.Count <= 0)
            {
                txtmp.Text = "PX" + "1";
                string t = "insert into PhieuXuat values('" + txtmp.Text + "','" + dnxh.Text + "','" + cbnv.SelectedValue.ToString() + "','"+cbkh.SelectedValue.ToString()+"')";
                SqlCommand tt = new SqlCommand(t, HelpForm.Open());
                tt.ExecuteNonQuery();
                ChitietXH fctxh = new ChitietXH(mnv, txtmp.Text, tnv, tdn, CV);
                fctxh.Show();
                this.Hide();
            }
            else
            {
                int mpx;
                mpx = Convert.ToInt32(ds.Rows.Count.ToString());
                mpx++;
                txtmp.Text = "PX" + mpx;
                string ttt= "insert into PhieuXuat values('" + txtmp.Text + "','" + dnxh.Text + "','" + cbnv.SelectedValue.ToString() + "','" + cbkh.SelectedValue.ToString() + "')";
                SqlCommand tttt = new SqlCommand(ttt, HelpForm.Open());
                tttt.ExecuteNonQuery();
                ChitietXH fctxh = new ChitietXH(mnv, txtmp.Text, tnv, tdn, CV);
                fctxh.Show();
                this.Hide();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtmp.ReadOnly = true;
            txtmp.Clear();
            btntimkiem.Enabled = true;
           // dnxh.Enabled = false;
        }

        public PhieuXuatHang()
        {
            InitializeComponent();
        }
        

        private void PhieuXuatHang_Load(object sender, EventArgs e)
        {
            txtmp.ReadOnly = true;
            dnxh.Format = DateTimePickerFormat.Short;
            string kh = "select * from KhachHang";
            cbkh.DisplayMember = "TenKH";
            cbkh.ValueMember = "MaKH";
            cbkh.DataSource = HelpForm.Gettable(kh);
            string nv = "select * from TaiKhoanNV";
            cbnv.DisplayMember = "TenNV";
            cbnv.ValueMember = "MaNV";
            cbnv.DataSource = HelpForm.Gettable(nv);
            string se = "select * from PhieuXuat";
            dxh.DataSource = HelpForm.Gettable(se);
        }
    }
}
