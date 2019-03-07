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
    public class DAL_BF:DAL_DBConnect
    {
        public DataTable getDate()
        {
            string query = string.Format("SELECT NgayBF , Sukien,Giam FROM BLACKFRIDAY WHERE Trangthai=1");
            SqlDataAdapter ph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            ph.Fill(result);
            return result;
        }
        public DataTable getDatetoEdit(string date)
        {
            string query = string.Format("SELECT NgayBF , Sukien,Giam FROM BLACKFRIDAY WHERE CONVERT(DATE,NgayBF)='{0}' AND Trangthai=1",date);
            SqlDataAdapter ph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            ph.Fill(result);
            return result;
        }
        public bool checkexitDate(string date)
        {
            string query = string.Format("SELECT * FROM BLACKFRIDAY WHERE CONVERT(DATE,NgayBF)='{0}' AND Trangthai=1", date);
            SqlDataAdapter ph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            ph.Fill(result);
            if (result.Rows.Count != 0)
                return false;
            return true;
        }

        public bool checkexitDatetoEdit(string date, int id)
        {
            string query = string.Format("SELECT * FROM BLACKFRIDAY WHERE NgayBF = '{0}' AND Mangay<>'{1}' AND Trangthai=1", date, id);
            SqlDataAdapter ph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            ph.Fill(result);
            if (result.Rows.Count != 0)
                return false;
            return true;
        }
        public string getIDFromDate(string date)
        {
            string query = string.Format("SELECT Mangay FROM BLACKFRIDAY WHERE NgayBF = '{0}' AND Trangthai=1", date);
            SqlDataAdapter ph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            ph.Fill(result);
            return result.Rows[0][0].ToString();
        }
        public string getDiscountFromDate(string date)
        {
            string query = string.Format("SELECT Giam FROM BLACKFRIDAY WHERE NgayBF = '{0}' AND Trangthai=1", date);
            SqlDataAdapter ph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            ph.Fill(result);
            return result.Rows[0][0].ToString();
        }
        public bool themNgay(DTO_BLACKFRIDAY bf)
        {
            try
            {
                // Ket noi
                _conn.Open();


                string SQL = string.Format("INSERT INTO BLACKFRIDAY (NgayBF,Sukien,Giam,Trangthai) VALUES('{0}','{1}','{2}','{3}')",bf.NGAYBF,bf.SUKIEN,bf.GIAM,bf.TRANGTHAI);
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
        public bool updateDate(int id, DTO_BLACKFRIDAY bf)
        {
            try
            {
                // Ket noi
                _conn.Open();


                string SQL = string.Format("UPDATE  BLACKFRIDAY SET NgayBF='{0}', Sukien='{1}',Giam='{2}' WHERE Mangay='{3}'", bf.NGAYBF,bf.SUKIEN,bf.GIAM,id);
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
        public bool delDate(int id)
        {
            try
            {
                // Ket noi
                _conn.Open();


                string SQL = string.Format("UPDATE  BLACKFRIDAY SET Trangthai=0 WHERE Mangay='{0}'", id);
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
