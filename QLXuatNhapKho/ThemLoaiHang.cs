using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace QLXuatNhapKho
{
    public partial class ThemLoaiHang : Form
    {
        string tnv = "", tdn = "", mk = "", CV = "", mnv;
        private string mphieunhap;
        public ThemLoaiHang()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 24;

            for (int i = 1; i < dlh.Columns.Count + 1; i++)
            {
                obj.Cells[1, i] = dlh.Columns[i - 1].HeaderText;

            }
            for (int t = 0; t < dlh.Rows.Count; t++)
            {
                for (int j = 0; j < dlh.Columns.Count; j++)
                {
                    if (dlh.Rows[t].Cells[j].Value != null)
                    {
                        obj.Cells[t + 2, j + 1] = dlh.Rows[t].Cells[j].Value.ToString();
                    }
                }
            }
            obj.Visible = true;

            // obj.ActiveWorkbook.SaveCopyAs(@"D:\CT239\QLXuatNhapKho\HangHoa" + ".xlsx");
            // obj.ActiveWorkbook.Saved = true;
            MessageBox.Show("Đã in thành công!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(txtmaloai.Text =="" && txttenloai.Text == "") { MessageBox.Show("Sửa không thành công!"); }
            else 
            { string s = " update LoaiHang set TenLoai ='" + txttenloai.Text + "' where MaLoai ='" + txtmaloai.Text + "'";
                SqlCommand ss = new SqlCommand(s, HelpForm.Open());
                ss.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công!");
                txtmaloai.Clear();
                txttenloai.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtmaloai.Text == "" && txttenloai.Text == "") { MessageBox.Show("Xóa không thành công!"); }
            else
            {
                string x = " Delete from LoaiHang where MaLoai ='" + txtmaloai.Text + "'";
                SqlCommand xx = new SqlCommand(x, HelpForm.Open());
                xx.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!");
                txtmaloai.Clear();
                txttenloai.Clear();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txttimkiem.Text =="Tên loại hàng hóa") { txttimkiem.Text = ""; txttimkiem.ForeColor = Color.Black; }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                txttimkiem.Text = "Tên loại hàng hóa";
                txttimkiem.ForeColor = Color.Gray;

            }
        }

        public ThemLoaiHang(string mp, string tnv, string tdn, string CV)
        {
            InitializeComponent();
            this.mphieunhap = mp;
            this.tnv = tnv;
            this.tdn = tdn;
            this.CV = CV;
        }
        private void btnluu_Click(object sender, EventArgs e)
        {
           try
            {   string check ="select * from LoaiHang where MaLoai='"+txtmaloai.Text+"'";
                System.Data.DataTable da = new System.Data.DataTable();
                SqlDataAdapter dt = new SqlDataAdapter(check,HelpForm.Open());
                dt.Fill(da);
                if (da.Rows.Count > 0)
                {   MessageBox.Show("Đã có loại hàng này trong kho", "Lỗi Nhẹ !!!", MessageBoxButtons.OK);
                    txtmaloai.Focus();
                }
                else
                {
                    string tloai = "insert into LoaiHang values ('" + txtmaloai.Text + "',N'" + txttenloai.Text + "')";
                    SqlCommand themloai = new SqlCommand(tloai, HelpForm.Open());
                    themloai.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm thành công !!");
                    string se = "select * from LoaiHang";
                    dlh.DataSource = HelpForm.Gettable(se);
                    txtmaloai.Clear();
                    txttenloai.Clear();
                    txtmaloai.Focus();
                }
            }
            catch (Exception ec) { MessageBox.Show("...."); }
        }

        private void btntrove_Click(object sender, EventArgs e)
        {
            ChiTietPN fpn = new ChiTietPN(mnv, mphieunhap,  tnv,  tdn,  CV);
            fpn.Show();
            this.Hide();
        }

        private void ThemLoaiHang_Load(object sender, EventArgs e)
        {
            string se = "select * from LoaiHang";
            dlh.DataSource = HelpForm.Gettable(se);

        }
    }
}
