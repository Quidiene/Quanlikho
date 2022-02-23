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
    public partial class Menuchucnang : Form
    {
        string tnv="", tdn = "", mk = "", CV = "",mnv;
        public Menuchucnang()
        {
            InitializeComponent();
        }
        public Menuchucnang(string mnv, string tnv, string tdn, string cV)
        {
            InitializeComponent();
            this.mnv = mnv;
            this.tnv = tnv;
            this.tdn = tdn;
            this.CV = cV;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Flogin fdn = new Flogin();
            fdn.Show();
            this.Close();
        }

        private void btnxuathang_Click(object sender, EventArgs e)
        {
            PhieuXuatHang fpxh = new PhieuXuatHang(mnv, tnv, tdn, CV);
            fpxh.Show();
            this.Hide();
        }

        private void btnnhanvien_Click(object sender, EventArgs e)
        {
            TaiKhoanNV ftknv = new TaiKhoanNV(mnv, tnv, tdn, CV);
            ftknv.Show();
            this.Hide(); ;
            
        }

        private void btnhanghoa_Click(object sender, EventArgs e)
        {
            FHangHoa fhh = new FHangHoa(mnv,tnv,tdn,CV);
            fhh.Show();
            this.Hide();

        }

        private void btnnhaphang_Click(object sender, EventArgs e)
        {
            PhieuNhapHang fpn = new PhieuNhapHang(mnv, tnv, tdn, CV);
            fpn.Show();
            this.Hide();
        }

        private void Menuchucnang_Load(object sender, EventArgs e)
        {
           
        }
         
    }
}
