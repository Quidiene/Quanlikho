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
    public partial class ThemNCC : Form
    {
        string tnv = "", tdn = "", mk = "", CV = "", mnv;
        private string mphieunhap;
        public ThemNCC()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(txtncc.Text =="" || txtdc.Text=="" || txtsdt.Text == "" || txttncc.Text == "")
            {
                MessageBox.Show("Sửa không thành công!!!");
            }
            else
            {
                string s = " update NhaCC set TenNCC ='" + txttncc.Text + "', Dchi='" + txtdc.Text + "',sdt='" + txtsdt.Text + "' where MaNCC='" + txtncc.Text + "'";
                SqlCommand ss = new SqlCommand(s, HelpForm.Open());
                ss.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công!!!");
                txtncc.Clear();
                txtdc.Clear();

                txttncc.Focus();
                txttncc.Clear();
                txtsdt.Clear();
                string se = "select * from NhaCC";
                dncc.DataSource = HelpForm.Gettable(se);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtncc.Text == "" || txtdc.Text == "" || txtsdt.Text == "" || txttncc.Text == "")
            {
                MessageBox.Show("Xóa không thành công!!!");
            }
            else
            {
                string x = " delete from NhaCC where MaNCC='" + txtncc.Text + "'";
                SqlCommand xx = new SqlCommand(x, HelpForm.Open());
                xx.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!!!");
                txtncc.Clear();
                txtdc.Clear();

                txttncc.Focus();
                txttncc.Clear();
                txtsdt.Clear();
                string se = "select * from NhaCC";
                dncc.DataSource = HelpForm.Gettable(se);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 24;

            for (int i = 1; i < dncc.Columns.Count + 1; i++)
            {
                obj.Cells[1, i] = dncc.Columns[i - 1].HeaderText;

            }
            for (int t = 0; t < dncc.Rows.Count; t++)
            {
                for (int j = 0; j < dncc.Columns.Count; j++)
                {
                    if (dncc.Rows[t].Cells[j].Value != null)
                    {
                        obj.Cells[t + 2, j + 1] = dncc.Rows[t].Cells[j].Value.ToString();
                    }
                }
            }
            obj.Visible = true;

            // obj.ActiveWorkbook.SaveCopyAs(@"D:\CT239\QLXuatNhapKho\HangHoa" + ".xlsx");
            // obj.ActiveWorkbook.Saved = true;
            MessageBox.Show("Đã in thành công!!");
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "Tên nhà cung cấp") { txttimkiem.Text = ""; txttimkiem.ForeColor = Color.Black; }

        }

        private void txttimkiem_Leave(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                txttimkiem.Text = "Tên nhà cung cấp";
                txttimkiem.ForeColor = Color.Gray;

            }
        }

        public ThemNCC(string mp, string tnv, string tdn, string CV)
        {
            InitializeComponent();
            this.mphieunhap = mp;
            this.tnv = tnv;
            this.tdn = tdn;
            this.CV = CV;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            { if (txtncc.Text == "" && txtdc.Text == "" && txttncc.Text == "" && txtsdt.Text == "") { MessageBox.Show("Bạn chưa điền đủ thông tin !!"); }
                else
                {
                    string check = "select * from NhaCC where MaNCC='" + txtncc.Text + "'";
                    System.Data.DataTable da = new System.Data.DataTable();
                    SqlDataAdapter dt = new SqlDataAdapter(check, HelpForm.Open());
                    dt.Fill(da);
                    if (da.Rows.Count > 0)
                    {
                        MessageBox.Show("Đã có dữ liệu nhà cung cấp này !! ");
                        txtncc.Focus();
                    }

                    else
                    {
                        string tncc = "insert into NhaCC values(N'" + txtncc.Text + "',N'" + txttncc.Text + "',N'" + txtdc.Text + "','" + txtsdt.Text + "')";
                        SqlCommand tnc = new SqlCommand(tncc, HelpForm.Open());
                        tnc.ExecuteNonQuery();
                        MessageBox.Show("Đã thêm thành công !!");
                        txtncc.Clear();
                        txtdc.Clear();
                       
                        txttncc.Focus();
                        txttncc.Clear();
                        txtsdt.Clear();
                        string se = "select * from NhaCC";
                        dncc.DataSource = HelpForm.Gettable(se);

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Chắc chưa nhập gì rồi bấm lưu nè !!");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChiTietPN fpn = new ChiTietPN(mnv, mphieunhap, tnv, tdn, CV);
            fpn.Show();
            this.Hide();
        }

        private void ThemNCC_Load(object sender, EventArgs e)
        {
            string se = "select * from NhaCC";
            dncc.DataSource = HelpForm.Gettable(se);
        }
    }
}
