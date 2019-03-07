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
   public  class DAL_Khuyenmai:DAL_DBConnect
    {
        public DataTable getCode()
        {
            string query = string.Format("SELECT Macode , Ngayhethan, Giam FROM KHUYENMAI WHERE Trangthai = 1");
            SqlDataAdapter ph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            ph.Fill(result);
            return result;
        }
        public DataTable getCodetoEdit(string code)
        {
            string query = string.Format("SELECT Macode , Ngayhethan, Giam FROM KHUYENMAI WHERE Macode='{0}'  AND Trangthai=1",code);
            SqlDataAdapter ph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            ph.Fill(result);
            return result;
        }
        public bool checkexitCode(string code)
        {
            string query = string.Format("SELECT * FROM KHUYENMAI WHERE Macode = '{0}' AND Trangthai=1", code);
            SqlDataAdapter ph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            ph.Fill(result);
            if (result.Rows.Count != 0)
                return false;
            return true;
        }
        public string getDiscount(string code)
        {
            string query = string.Format("SELECT Giam FROM KHUYENMAI WHERE Macode = '{0}' AND Trangthai=1", code);
            SqlDataAdapter ph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            ph.Fill(result);
            return result.Rows[0][0].ToString();
        }
        public bool checkexitCodetoSale(string code,string date)
        {
            string query = string.Format("SELECT * FROM KHUYENMAI WHERE Macode = '{0}' AND Trangthai=1 AND Ngayhethan >='{1}'", code,date);
            SqlDataAdapter ph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            ph.Fill(result);
            if (result.Rows.Count != 0)
                return false;
            return true;
        }
        public bool checkexitCodetoEdit(string code,int id)
        {
            string query = string.Format("SELECT * FROM KHUYENMAI WHERE Macode = '{0}' AND ID<>'{1}'  AND Trangthai=1", code,id);
            SqlDataAdapter ph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            ph.Fill(result);
            if (result.Rows.Count != 0)
                return false;
            return true;
        }
        public string getIDFromCode(string code)
        {
            string query = string.Format("SELECT ID FROM KHUYENMAI WHERE Macode = '{0}' AND Trangthai=1", code);
            SqlDataAdapter ph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            ph.Fill(result);
            return result.Rows[0][0].ToString();
        }
        public bool themMakhuyenmai(DTO_KHUYENMAI km)
        {
            try
            {
                // Ket noi
                _conn.Open();


                string SQL = string.Format("INSERT INTO KHUYENMAI (Macode,Ngayhethan,Giam,Trangthai) VALUES('{0}','{1}','{2}','{3}')", km.MACODE,km.NGAYHETHAN,km.GIAM,km.TRANGTHAI);
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
        public bool updateCode(int code,DTO_KHUYENMAI km)
        {
            try
            {
                // Ket noi
                _conn.Open();


                string SQL = string.Format("UPDATE  KHUYENMAI SET Macode='{0}', Ngayhethan='{1}',Giam='{2}' WHERE ID='{3}'", km.MACODE, km.NGAYHETHAN, km.GIAM,code);
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
        public bool delCode(int code)
        {
            try
            {
                // Ket noi
                _conn.Open();


                string SQL = string.Format("UPDATE  KHUYENMAI SET Trangthai=0 WHERE ID='{0}'",code);
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
