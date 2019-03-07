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
    public class DAL_Lichsunhap:DAL_DBConnect
    {
       
        public bool themLichsu(DTO_LICHSUNHAPHANG ls)
        {
            try
            {
                // Ket noi
                _conn.Open();


                string SQL = string.Format("INSERT INTO LICHSUNHAPHANG (Masanpham,Soluongnhap,Giathanh,Ngaynhap,Loaihinhnhap) VALUES('{0}','{1}','{2}','{3}','{4}')", ls.MASANPHAM,ls.SOLUONGNHAP,ls.GIATHANH,ls.NGAYNHAP,ls.LOAIHINHNHAP);
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
    }
}
