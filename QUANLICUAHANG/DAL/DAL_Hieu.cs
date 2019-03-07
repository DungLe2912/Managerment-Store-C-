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
    public class DAL_Hieu:DAL_DBConnect
    {
        public DataTable getHieu(string tenhang)
        {
            string query = string.Format("SELECT HIEU.Tenhieu FROM HIEU, HANG WHERE HANG.Tenhang=N'{0}' AND HANG.Mahang=HIEU.Mahang",tenhang);
            SqlDataAdapter hieu = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            hieu.Fill(result);
            return result;
        }
        public bool checkexitTenhieu(string tenhang,string tenhieu)
        {
            string query = string.Format("SELECT HIEU.Mahieu FROM HIEU, HANG WHERE HANG.Tenhang=N'{0}' AND HANG.Mahang=HIEU.Mahang AND HIEU.Tenhieu=N'{1}'", tenhang,tenhieu);
            SqlDataAdapter hieu = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            hieu.Fill(result);
            if (result.Rows.Count != 0)
                return false;
            return true;
        }
        public string getMahang(string tenhang)
        {
            string query = string.Format("SELECT Mahang FROM HANG WHERE HANG.Tenhang=N'{0}'",tenhang);
            SqlDataAdapter mahang = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            mahang.Fill(result);
            return result.Rows[0][0].ToString();
        }
        public string getMahieu(string tenhang,string tenhieu)
        {
            string query = string.Format("SELECT HIEU.Mahieu FROM HIEU, HANG WHERE HANG.Tenhang=N'{0}' AND HANG.Mahang=HIEU.Mahang AND HIEU.Tenhieu=N'{1}'", tenhang, tenhieu);
            SqlDataAdapter hieu = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            hieu.Fill(result);
            return result.Rows[0][0].ToString();
        }
        public bool themHieu(DTO_HIEU hieu)
        {
            try
            {
                // Ket noi
                _conn.Open();


                string SQL = string.Format("INSERT INTO HIEU(Mahang,Tenhieu) VALUES('{0}','{1}')", hieu.MAHANG,hieu.TENHIEU);
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
