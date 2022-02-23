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
    public partial class ThemKH : Form
    {
        string tnv = "", tdn = "", mk = "", CV = "", mnv;
        string nhan = "";
        private void button1_Click(object sender, EventArgs e)
        {   
            string pn = "select * from KhachHang";
            SqlCommand gpn = new SqlCommand(pn, HelpForm.Open());
            SqlDataAdapter spn = new SqlDataAdapter(gpn);
            System.Data.DataTable ds = new System.Data.DataTable();
            spn.Fill(ds);
            if (ds.Rows.Count <= 0)
            {
                txtmkh.Text = "KH" + "1";
                nhan = "Them";
                txttkh.Clear();
                txtdchi.Clear();
                txtsdt.Clear();
               
            }
            else
            {
                int mpn;
                mpn = Convert.ToInt32(ds.Rows.Count.ToString());
                mpn++;
                txtmkh.Text = "KH" + mpn;
                nhan = "Them";
               
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (nhan == "Them")
            {
                string t = "insert into KhachHang values('" + txtmkh.Text + "',N'" + txttkh.Text + "',N'" + txtdchi.Text + "','" + txtsdt.Text + "')";
                SqlCommand tt = new SqlCommand(t, HelpForm.Open());
                tt.ExecuteNonQuery();
                nhan = "";
                MessageBox.Show("Đã thêm thành công thông tin khách hàng");
                string se = "select * from KhachHang";
                dkh.DataSource = HelpForm.Gettable(se);
            }
            else 
            {
                if(nhan=="Sua")
                {
                    string s = "update KhachHang set TenKH ='" + txttkh.Text + "', Dchi='" + txtdchi.Text + "',Sdt='" + txtsdt.Text + "' where MaKH='" + txtmkh.Text + "'";
                    SqlCommand ss = new SqlCommand(s, HelpForm.Open());
                    MessageBox.Show("Đã chỉnh sửa thành công thông tin khách hàng!!!");
                    nhan = "";
                    string se = "select * from KhachHang";
                    dkh.DataSource = HelpForm.Gettable(se);
                } 
            }
        }

        private void dkh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dkh.Rows.Count; i++)
                if (e.RowIndex == i)
                {
                    DataGridViewRow row = this.dkh.Rows[e.RowIndex];
                    txtmkh.Text = row.Cells[0].Value.ToString();
                    txttkh.Text = row.Cells[1].Value.ToString();
                    txtdchi.Text = row.Cells[2].Value.ToString();
                    txtsdt.Text = row.Cells[3].Value.ToString();
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtmkh.Text =="" && txttkh.Text=="" && txtdchi.Text=="" && txtsdt.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn khách hàng cần sửa thông tin","Warring!");
            }
            else
            {
                nhan = "Sua";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtmkh.Clear();
            txtdchi.Clear();
            txtsdt.Clear();
            txttkh.Clear();
            string se = "select * from KhachHang";
            dkh.DataSource = HelpForm.Gettable(se);
            nhan = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sqll = "select * from KhachHang";
            SqlDataAdapter ada = new SqlDataAdapter(sqll, HelpForm.Open());
            System.Data.DataTable daa = new System.Data.DataTable();
            ada.Fill(daa);
            DataView dv = new DataView(daa);
            if (txtimkiem.Text == "")
            { MessageBox.Show("Bạn muốn tìm gì hãy ghi ra nào!!!"); txtimkiem.Focus(); }
            else
            {
                dv.RowFilter = " TenKH like \'%" + txtimkiem.Text + "%\'";
                dkh.DataSource = dv;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 24;

            for (int i = 1; i < dkh.Columns.Count + 1; i++)
            {
                obj.Cells[1, i] = dkh.Columns[i - 1].HeaderText;

            }
            for (int t = 0; t < dkh.Rows.Count; t++)
            {
                for (int j = 0; j < dkh.Columns.Count; j++)
                {
                    if (dkh.Rows[t].Cells[j].Value != null)
                    {
                        obj.Cells[t + 2, j + 1] = dkh.Rows[t].Cells[j].Value.ToString();
                    }
                }
            }
            obj.Visible = true;

            // obj.ActiveWorkbook.SaveCopyAs(@"D:\CT239\QLXuatNhapKho\HangHoa" + ".xlsx");
            // obj.ActiveWorkbook.Saved = true;
            MessageBox.Show("Đã in báo cáo thành công!!");
        }

        private void txtimkiem_Enter(object sender, EventArgs e)
        {
            if (txtimkiem.Text == "Tên khách hàng")
            {
                txtimkiem.Text = ""; txtimkiem.ForeColor = Color.Black;
            }
        }

        private void txtimkiem_Leave(object sender, EventArgs e)
        {
            if (txtimkiem.Text == "")
            {
                txtimkiem.Text = "Tên khách hàng";
                txtimkiem.ForeColor = Color.Gray;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PhieuXuatHang fpxh = new PhieuXuatHang(mnv, tnv, tdn, CV);
            fpxh.Show();
            this.Hide();
        }

        public ThemKH()
        {
            InitializeComponent();
        }
        public ThemKH(string mnv, string tnv, string tdn, string cV)
        {
            InitializeComponent();
            this.mnv = mnv;
            this.tnv = tnv;
            this.tdn = tdn;
            this.CV = cV;
        }
       
        private void ThemKH_Load(object sender, EventArgs e)
        {
            string se = "select * from KhachHang";
            dkh.DataSource = HelpForm.Gettable(se);
        }
    }
}
