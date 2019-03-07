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
    public class DAL_Hang:DAL_DBConnect
    {
      
        public DataTable getHang()
        {
            string query = string.Format("SELECT Tenhang FROM HANG");
            SqlDataAdapter hang = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            hang.Fill(result);
            return result;
        }
        public bool checkexitHang(string hang)
        {
            string query = string.Format("SELECT * FROM HANG WHERE Tenhang=N'{0}'",hang);
            SqlDataAdapter tenhang = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            tenhang.Fill(result);
            if (result.Rows.Count != 0)
                return false;
            return true;
        }
        public bool themHang(DTO_HANG hang)
        {
            try
            {
                // Ket noi
                _conn.Open();


                string SQL = string.Format("INSERT INTO HANG(Tenhang) VALUES('{0}')",hang.TENHANG);
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
