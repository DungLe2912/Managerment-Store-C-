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
    public class DAL_Account:DAL_DBConnect
    {
        public bool CheckAccount(string username, string password)
        {
            string query = string.Format("SElECT TK.Manhanvien FROM TAIKHOAN as TK, NHANVIEN as NV WHERE TK.Username=N'{0}'AND TK.Pass=N'{1}' AND TK.Manhanvien=NV.Manhanvien AND NV.Trangthai=1", username, password);
            SqlDataAdapter acc = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            acc.Fill(result);
            if (result.Rows.Count > 0) return true;
            return false;
        }
        public bool checkExitAccount(string username)
        {
            string query = string.Format("SElECT TK.Manhanvien FROM TAIKHOAN as TK, NHANVIEN as NV WHERE TK.Username= N'{0}' AND TK.Trangthai=1 AND TK.Manhanvien=NV.Manhanvien AND NV.Trangthai=1", username);
            SqlDataAdapter acc = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            acc.Fill(result);
            if (result.Rows.Count > 0) return true;
            return false;
        }
        public bool checkExitAccountToEdit(string username,string id)
        {
            string query = string.Format("SElECT TK.Manhanvien FROM TAIKHOAN as TK, NHANVIEN as NV WHERE TK.Username= N'{0}' AND TK.Trangthai=1 AND TK.Manhanvien <>'{1}' AND TK.Manhanvien=NV.Manhanvien AND NV.Trangthai=1", username,id);
            SqlDataAdapter acc = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            acc.Fill(result);
            if (result.Rows.Count > 0) return true;
            return false;
        }
        public string getManhanvien(string username, string password)
        {
            string query = string.Format("SElECT TK.Manhanvien FROM TAIKHOAN as TK , NHANVIEN as NV WHERE TK.Username=N'{0}'AND TK.Pass=N'{1}' AND TK.Manhanvien=NV.Manhanvien AND NV.Trangthai=1", username, password);
            SqlDataAdapter acc = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            acc.Fill(result);
            return result.Rows[0][0].ToString();
        }
        public string getTennhanvien(string manhanvien)
        {
            string query = string.Format("SElECT Tennhanvien FROM NHANVIEN WHERE Manhanvien='{0}'", manhanvien);
            SqlDataAdapter dichvu = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            dichvu.Fill(result);
            return result.Rows[0][0].ToString();
        }
        public string getLoainhanvien(string username, string password)
        {
            string query = string.Format("SElECT TK.Loainhanvien FROM TAIKHOAN as TK , NHANVIEN as NV WHERE TK.Username=N'{0}'AND TK.Pass=N'{1}' AND TK.Manhanvien=NV.Manhanvien AND NV.Trangthai=1", username, password);
            SqlDataAdapter acc = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            acc.Fill(result);
            return result.Rows[0][0].ToString();
        }
        public DataTable getUP(string id)
        {
            string query = string.Format("SElECT Username, Pass FROM TAIKHOAN WHERE Manhanvien='{0}' AND Trangthai=1", id);
            SqlDataAdapter acc = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            acc.Fill(result);
            return result;
        }
        public DataTable getAccToEdit(string id)
        {
            string query = string.Format("SElECT Username, Pass, Loainhanvien FROM TAIKHOAN WHERE Manhanvien='{0}'", id);
            SqlDataAdapter acc = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            acc.Fill(result);
            return result;
        }
        public bool themAcc(DTO_ACCOUNT acc)
        {
            try
            {
                // Ket noi
                _conn.Open();


                string SQL = string.Format("INSERT INTO TAIKHOAN (Username,Pass,Trangthai,Manhanvien,Loainhanvien) VALUES('{0}','{1}','{2}','{3}','{4}')", acc.USERNAME, acc.PASSWORD, acc.TRANGTHAI, acc.MANHANVIEN,acc.LOAINHANVIEN);
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
        public bool updateAcc(string id, DTO_ACCOUNT acc)
        {
            try
            {
                // Ket noi
                _conn.Open();


                string SQL = string.Format("UPDATE  TAIKHOAN SET Username='{0}', Pass='{1}',Loainhanvien='{2}' WHERE Manhanvien='{3}'", acc.USERNAME, acc.PASSWORD, acc.LOAINHANVIEN, id);
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
        public bool delAcc(string id)
        {
            try
            {
                // Ket noi
                _conn.Open();


                string SQL = string.Format("UPDATE  TAIKHOAN SET Trangthai=0 WHERE Manhanvien='{0}'", id);
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
