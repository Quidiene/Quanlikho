using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLXuatNhapKho
{
    class HelpForm
    {
        static string conn = (@"Data Source = LMQ; Initial Catalog = QuanLiXuatNhapKho; Integrated Security = True");
        static SqlConnection connect;

        public static SqlConnection Open()
        {
            connect = new SqlConnection(conn); //khai báo một biến kết nối mới với giá trị truyền vào là Chuỗi connString
            try
            {
                connect.Open();  //mở kết nối
            }
            catch (Exception ex)
            {  //nếu không kết nối được
                MessageBox.Show(ex.Message.ToString());   //hiện thông báo lỗi ngoại lê
            }
            return connect; //trả về biến kết nối
        }
        public static DataTable Gettable(String sql)
        {
            DataTable result = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, Open());
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return result;
        }
    }
}
