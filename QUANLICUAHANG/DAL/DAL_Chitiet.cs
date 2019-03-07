using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_Chitiet:DAL_DBConnect
    {
        public bool themChitiet(DTO_CHITIETDONHANG ct)
        {
            try
            {
                // Ket noi
                _conn.Open();


                string SQL = string.Format("INSERT INTO CHITIETDONHANG(Madonhang, Mahang,Mahieu, Masanpham, Soluong,Dongia  ) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", ct.MADONHANG,ct.MAHANG,ct.MAHIEU,ct.MASANPHAM,ct.SOLUONG,ct.DONGIA);
                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(SQL, _conn);

                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception e)
            {

            }
            finally
            {
                // Dong ket noi
                _conn.Close();
            }

            return false;
        }
        public DataTable getDetail(string id)
        {
            string query = string.Format("SELECT CT.Machitiet,CT.Madonhang, HANG.Tenhang, HIEU.Tenhieu, SP.Tensanpham, CT.Soluong, CT.Dongia FROM CHITIETDONHANG as CT, HANG, HIEU, SANPHAM as SP WHERE CT.Madonhang='{0}' AND CT.Mahang=HANG.Mahang AND CT.Mahieu=HIEU.Mahieu AND CT.Masanpham=SP.Masanpham", id);
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
    }
}
