using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLXuatNhapKho
{
    public partial class Flogin : Form
    {
       
        public Flogin()
        {
            InitializeComponent();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {   
            MessageBox.Show("Bạn có chắc muốn thoát không", "Warring!!!!", MessageBoxButtons.YesNo);
            Application.Exit();
        }

        private void hienmk_CheckedChanged(object sender, EventArgs e)
        {
            if (hienmk.Checked == true)
            {
                txtmk.UseSystemPasswordChar = false;
            }
            else
            {
                txtmk.UseSystemPasswordChar = true;
            }
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            try 
            {
                String sql = "select * from TaiKhoanNV where Tendangnhap='" + txttdn.Text + "' and MatKhau='" + txtmk.Text + "'";
                DataTable data = HelpForm.Gettable(sql);
                if (data.Rows.Count > 0)
                {
                    this.Hide();
                    Menuchucnang Fmm = new Menuchucnang(data.Rows[0][0].ToString(),data.Rows[0][1].ToString(), data.Rows[0][4].ToString(),data.Rows[0][5].ToString());
                    Fmm.Show();

                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
                    txttdn.Focus();
                }
            }
            catch(Exception ex) { MessageBox.Show("Đã xảy ra lỗi!!!"); }
        }

        private void Flogin_Load(object sender, EventArgs e)
        {
            txtmk.UseSystemPasswordChar = true;
        }

    }
}
