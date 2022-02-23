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

namespace QLXuatNhapKho
{ 
    public partial class doimatkhau : Form
    {
        string tnv = "", tdn = "", mk = "", CV = "", mnv;
        public doimatkhau(string mnv, string tnv, string tdn, string cV)
        {
            InitializeComponent();
            this.mnv = mnv;
            this.tnv = tnv;
            this.tdn = tdn;
            this.CV = cV;

        }

        private void doimatkhau_Load(object sender, EventArgs e)
        {
            string se = "select Tendangnhap,MatKhau from TaiKhoanNV where MaNV='" + mnv + "'";
            SqlDataAdapter da = new SqlDataAdapter(se, HelpForm.Open());
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            txttdn.Text = dt.Rows[0]["Tendangnhap"].ToString();
            txtmk.Text = dt.Rows[0]["MatKhau"].ToString();
            txttdn.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                string i = "update  TaiKhoanNV set Tendangnhap='" + txttdn.Text + "', Matkhau='" + txtmk.Text + "' where MaNV ='" + mnv + "'";
                SqlCommand si = new SqlCommand(i, HelpForm.Open());
                si.ExecuteNonQuery();
                MessageBox.Show("Đã cập nhật tài khoản thành công!!");
                 txttdn.Focus();
                 txttdn.Clear();
                 txtmk.Clear();
                
             

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TaiKhoanNV ftknv = new TaiKhoanNV(mnv, tnv, tdn, CV);
            ftknv.Show();
            this.Hide();

        }
    }
}
