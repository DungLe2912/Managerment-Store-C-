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
    public class DAL_Nhaphathanh:DAL_DBConnect
    {
        public DataTable getNhaphathanh()
        {
            string query = string.Format("SELECT Tennhaphathanh FROM NHAPHATHANH");
            SqlDataAdapter nph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            nph.Fill(result);
            return result;
        }
        public bool checkexitNph(string nph)
        {
            string query = string.Format("SELECT * FROM NHAPHATHANH WHERE Tennhaphathanh=N'{0}'", nph);
            SqlDataAdapter ph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            ph.Fill(result);
            if (result.Rows.Count != 0)
                return false;
            return true;
        }
        public bool themNPH(DTO_NHAPHATHANH nph)
        {
            try
            {
                // Ket noi
                _conn.Open();


                string SQL = string.Format("INSERT INTO NHAPHATHANH(Tennhaphathanh) VALUES('{0}')", nph.TENNHAPHATHANH);
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
