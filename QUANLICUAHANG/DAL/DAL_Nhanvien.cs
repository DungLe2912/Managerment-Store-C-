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
    public class DAL_Nhanvien:DAL_DBConnect
    {
        public DataTable getDetailNhanvien(string id)
        {
            string query = string.Format("SELECT Hinhanh FROM NHANVIEN WHERE Trangthai=1 AND Manhanvien={0}",id);
            SqlDataAdapter ph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            ph.Fill(result);
            return result;
        }
        public DataTable searchDOB(string date)
        {
            string query = string.Format("SELECT Manhanvien,Tennhanvien,CMND,Gioitinh,Diachi,Ngaysinh,Sodienthoai FROM NHANVIEN WHERE Trangthai=1 AND CONVERT(DATE,Ngaysinh) LIKE '{0}%'", date);
            SqlDataAdapter ph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            ph.Fill(result);
            return result;
        }
        public DataTable searchAddr(string addr)
        {
            string query = string.Format("SELECT Manhanvien,Tennhanvien,CMND,Gioitinh,Diachi,Ngaysinh,Sodienthoai FROM NHANVIEN WHERE Trangthai=1 AND Diachi LIKE '{0}%'", addr);
            SqlDataAdapter ph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            ph.Fill(result);
            return result;
        }
        public DataTable searchSex(string sex)
        {
            string query = string.Format("SELECT Manhanvien,Tennhanvien,CMND,Gioitinh,Diachi,Ngaysinh,Sodienthoai FROM NHANVIEN WHERE Trangthai=1 AND Gioitinh LIKE '{0}%'", sex);
            SqlDataAdapter ph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            ph.Fill(result);
            return result;
        }
        public DataTable getNhanvientoEdit(string id)
        {
            string query = string.Format("SELECT Manhanvien,Tennhanvien,CMND,Gioitinh,Diachi,Ngaysinh,Sodienthoai, Hinhanh FROM NHANVIEN WHERE Trangthai=1 AND Manhanvien='{0}'",id);
            SqlDataAdapter ph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            ph.Fill(result);
            return result;
        }
        public DataTable getNhanvien()
        {
            string query = string.Format("SELECT Manhanvien,Tennhanvien,CMND,Gioitinh,Diachi,Ngaysinh,Sodienthoai FROM NHANVIEN WHERE Trangthai=1");
            SqlDataAdapter ph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            ph.Fill(result);
            return result;
        }
        public bool checkCMND(string cmnd)
        {
            string query = string.Format("SELECT * FROM NHANVIEN WHERE CMND = '{0}' AND Trangthai=1", cmnd);
            SqlDataAdapter ph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            ph.Fill(result);
            if (result.Rows.Count != 0)
                return false;
            return true;
        }
        public bool checkCMNDtoEdit(string cmnd,string id)
        {
            string query = string.Format("SELECT * FROM NHANVIEN WHERE CMND = '{0}' AND Trangthai=1 AND Manhanvien<>'{1}'", cmnd,id);
            SqlDataAdapter ph = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            ph.Fill(result);
            if (result.Rows.Count != 0)
                return false;
            return true;
        }
        public bool themNhanvien(DTO_NHANVIEN nv)
        {
            try
            {
                // Ket noi
                _conn.Open();


                //string SQL = string.Format("INSERT INTO SANPHAM (Mahang,Mahieu,Tensanpham,Thongso,Soluong,Gia,Giamgia,Nhaphathanh,Trangthai," +
                //    "Hinhanh) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", sp.MAHANG, sp.MAHIEU,sp.TENSANPHAM,sp.THONGSO,sp.SOLUONG,sp.GIA,sp.GIAMGIA,sp.NHAPHATHANH,sp.TRANGTHAI,@sp.HINHANH);
                //// Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                string SQL = string.Format("INSERT INTO NHANVIEN (Tennhanvien,CMND,Gioitinh,Diachi,Ngaysinh,Sodienthoai,Trangthai,Hinhanh" +
                ") VALUES(@Tennhanvien,@CMND,@Gioitinh,@Diachi,@Ngaysinh,@Sodienthoai,@Trangthai,@Hinhanh)");

                SqlCommand cmd = new SqlCommand(SQL, _conn);
                cmd.Parameters.Add("@Tennhanvien", SqlDbType.NVarChar);
                cmd.Parameters.Add("@CMND", SqlDbType.VarChar);
                cmd.Parameters.Add("@Gioitinh", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Diachi", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Ngaysinh", SqlDbType.DateTime);
                cmd.Parameters.Add("@Sodienthoai", SqlDbType.VarChar);
                cmd.Parameters.Add("@Trangthai", SqlDbType.Int);
                cmd.Parameters.Add("@Hinhanh", SqlDbType.Image);


                cmd.Parameters["@Tennhanvien"].Value = nv.TENNHANVIEN;
                cmd.Parameters["@CMND"].Value = nv.CMND;
                cmd.Parameters["@Gioitinh"].Value = nv.GIOITINH;
                cmd.Parameters["@Diachi"].Value = nv.DIACHI;
                cmd.Parameters["@Ngaysinh"].Value = nv.NGAYSINH;
                cmd.Parameters["@Sodienthoai"].Value = nv.SODIENTHOAI;
                cmd.Parameters["@Trangthai"].Value = nv.TRANGTHAI;
                cmd.Parameters["@Hinhanh"].Value = nv.HINHANH;

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
        public bool xoaNhanvien(string id)
        {
            try
            {
                // Ket noi
                _conn.Open();

                string query = string.Format("UPDATE NHANVIEN SET Trangthai=0 WHERE Manhanvien='{0}'", id);

                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(query, _conn);

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
        public bool updateNhanvien(string id,DTO_NHANVIEN nv)
        {
            try
            {
                // Ket noi
                _conn.Open();


                //string SQL = string.Format("INSERT INTO SANPHAM (Mahang,Mahieu,Tensanpham,Thongso,Soluong,Gia,Giamgia,Nhaphathanh,Trangthai," +
                //    "Hinhanh) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", sp.MAHANG, sp.MAHIEU,sp.TENSANPHAM,sp.THONGSO,sp.SOLUONG,sp.GIA,sp.GIAMGIA,sp.NHAPHATHANH,sp.TRANGTHAI,@sp.HINHANH);
                //// Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                string SQL = string.Format("UPDATE  NHANVIEN SET Tennhanvien=@Tennhanvien,CMND=@CMND,Gioitinh=@Gioitinh,Diachi=@Diachi,Ngaysinh=@Ngaysinh,Sodienthoai=@Sodienthoai,Trangthai=@Trangthai, Hinhanh=@Hinhanh WHERE Manhanvien=@id");


                SqlCommand cmd = new SqlCommand(SQL, _conn);
                cmd.Parameters.Add("@Tennhanvien", SqlDbType.NVarChar);
                cmd.Parameters.Add("@CMND", SqlDbType.VarChar);
                cmd.Parameters.Add("@Gioitinh", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Diachi", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Ngaysinh", SqlDbType.DateTime);
                cmd.Parameters.Add("@Sodienthoai", SqlDbType.VarChar);
                cmd.Parameters.Add("@Trangthai", SqlDbType.Int);
                cmd.Parameters.Add("@Hinhanh", SqlDbType.Image);
                cmd.Parameters.Add("@id", SqlDbType.Int);

                cmd.Parameters["@Tennhanvien"].Value = nv.TENNHANVIEN;
                cmd.Parameters["@CMND"].Value = nv.CMND;
                cmd.Parameters["@Gioitinh"].Value = nv.GIOITINH;
                cmd.Parameters["@Diachi"].Value = nv.DIACHI;
                cmd.Parameters["@Ngaysinh"].Value = nv.NGAYSINH;
                cmd.Parameters["@Sodienthoai"].Value = nv.SODIENTHOAI;
                cmd.Parameters["@Trangthai"].Value = nv.TRANGTHAI;
                cmd.Parameters["@Hinhanh"].Value = nv.HINHANH;
                cmd.Parameters["@id"].Value = Int32.Parse(id);

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
