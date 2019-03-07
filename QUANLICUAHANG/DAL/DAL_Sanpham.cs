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
    public class DAL_Sanpham:DAL_DBConnect
    {
       
        public DataTable getSanphamEdit(string id)
        {
            string query = string.Format("SELECT SP.Masanpham,HANG.Tenhang, HIEU.Tenhieu,SP.Tensanpham,SP.Thongso,SP.Soluong,SP.Gia,SP.Giamgia,SP.Nhaphathanh,SP.Hinhanh FROM SANPHAM AS SP, HANG,HIEU WHERE SP.Mahang=HANG.Mahang AND SP.Mahieu=HIEU.Mahieu AND SP.Masanpham='{0}' AND SP.Trangthai=1",id);
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public DataTable getSanpham()
        {
            string query = string.Format("SELECT DISTINCT SP.Masanpham,SP.Tensanpham, HIEU.Tenhieu,HANG.Tenhang,LS.Ngaynhap,SP.Soluong,SP.Gia FROM SANPHAM AS SP, HANG,HIEU,LICHSUNHAPHANG AS LS WHERE SP.Trangthai=1 AND SP.Mahang=HANG.Mahang AND SP.Mahieu=HIEU.Mahieu AND SP.Masanpham=LS.Masanpham AND LS.Ngaynhap=(SELECT MAX(LICHSUNHAPHANG.Ngaynhap) FROM LICHSUNHAPHANG WHERE LS.Masanpham=LICHSUNHAPHANG.Masanpham)");
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public DataTable getSanphamtoSale(string id)
        {
            string query = string.Format("SELECT Mahang,Mahieu,Masanpham FROM SANPHAM WHERE Masanpham='{0}' AND Trangthai=1", id);
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        //---------------------------------------------
        public DataTable getLSOrderByMasp()
        {
            string query = string.Format("SELECT * FROM LICHSUNHAPHANG ORDER BY Masanpham");
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public DataTable getLSOrderBySoluong()
        {
            string query = string.Format("SELECT * FROM LICHSUNHAPHANG ORDER BY Soluongnhap");
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public DataTable getLSOrderByGiathanh()
        {
            string query = string.Format("SELECT * FROM LICHSUNHAPHANG ORDER BY Giathanh");
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public DataTable getLSOrderByNgaynhap()
        {
            string query = string.Format("SELECT * FROM LICHSUNHAPHANG ORDER BY Ngaynhap");
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public DataTable getLSOrderByLoainhap()
        {
            string query = string.Format("SELECT * FROM LICHSUNHAPHANG ORDER BY Loaihinhnhap");
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public DataTable getDetailProduct(string id)
        {
            string query = string.Format("SELECT Thongso,Giamgia,Nhaphathanh,Hinhanh FROM SANPHAM WHERE Masanpham='{0}' AND Trangthai=1", id);
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public string getSoluong(string id)
        {
            string query = string.Format("SELECT Soluong FROM SANPHAM WHERE Masanpham='{0}' AND Trangthai=1", id);
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result.Rows[0][0].ToString();
        }
        public DataTable searchManuf(string tenhang)
        {
            string query = string.Format("SELECT DISTINCT SP.Masanpham,SP.Tensanpham, HIEU.Tenhieu,HANG.Tenhang,LS.Ngaynhap,SP.Soluong,SP.Gia FROM SANPHAM AS SP, HANG,HIEU,LICHSUNHAPHANG AS LS WHERE SP.Trangthai=1 AND SP.Mahang=HANG.Mahang AND HANG.Tenhang LIKE '{0}%' AND SP.Mahieu=HIEU.Mahieu AND SP.Masanpham=LS.Masanpham AND LS.Ngaynhap=(SELECT MAX(LICHSUNHAPHANG.Ngaynhap) FROM LICHSUNHAPHANG WHERE LS.Masanpham=LICHSUNHAPHANG.Masanpham)",tenhang);
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public DataTable searchBrand(string tenhieu)
        {
            string query = string.Format("SELECT DISTINCT SP.Masanpham,SP.Tensanpham, HIEU.Tenhieu,HANG.Tenhang,LS.Ngaynhap,SP.Soluong,SP.Gia FROM SANPHAM AS SP, HANG,HIEU,LICHSUNHAPHANG AS LS WHERE SP.Trangthai=1 AND SP.Mahang=HANG.Mahang  AND SP.Mahieu=HIEU.Mahieu AND HIEU.Tenhieu LIKE '{0}%' AND SP.Masanpham=LS.Masanpham AND LS.Ngaynhap=(SELECT MAX(LICHSUNHAPHANG.Ngaynhap) FROM LICHSUNHAPHANG WHERE LS.Masanpham=LICHSUNHAPHANG.Masanpham)", tenhieu);
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public DataTable searchQuantity(int soluong)
        {
            string query = string.Format("SELECT DISTINCT SP.Masanpham,SP.Tensanpham, HIEU.Tenhieu,HANG.Tenhang,LS.Ngaynhap,SP.Soluong,SP.Gia FROM SANPHAM AS SP, HANG,HIEU,LICHSUNHAPHANG AS LS WHERE SP.Trangthai=1 AND SP.Soluong LIKE '{0}%' AND SP.Mahang=HANG.Mahang  AND SP.Mahieu=HIEU.Mahieu AND SP.Masanpham=LS.Masanpham AND LS.Ngaynhap=(SELECT MAX(LICHSUNHAPHANG.Ngaynhap) FROM LICHSUNHAPHANG WHERE LS.Masanpham=LICHSUNHAPHANG.Masanpham)", soluong);
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public DataTable searchPurchaseDate(string date)
        {
            string query = string.Format("SELECT DISTINCT SP.Masanpham,SP.Tensanpham, HIEU.Tenhieu,HANG.Tenhang,LS.Ngaynhap,SP.Soluong,SP.Gia FROM SANPHAM AS SP, HANG,HIEU,LICHSUNHAPHANG AS LS WHERE SP.Trangthai=1 AND SP.Mahang=HANG.Mahang AND SP.Mahieu=HIEU.Mahieu AND SP.Masanpham=LS.Masanpham AND LS.Ngaynhap=(SELECT MAX(LICHSUNHAPHANG.Ngaynhap) FROM LICHSUNHAPHANG WHERE LS.Masanpham=LICHSUNHAPHANG.Masanpham) AND CONVERT(DATE,LS.Ngaynhap) LIKE '{0}%'", date);
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public DataTable searchPrice(int gia)
        {
            string query = string.Format("SELECT DISTINCT SP.Masanpham,SP.Tensanpham, HIEU.Tenhieu,HANG.Tenhang,LS.Ngaynhap,SP.Soluong,SP.Gia FROM SANPHAM AS SP, HANG,HIEU,LICHSUNHAPHANG AS LS WHERE SP.Trangthai=1 AND SP.Gia LIKE '{0}%' AND SP.Mahang=HANG.Mahang  AND SP.Mahieu=HIEU.Mahieu AND SP.Masanpham=LS.Masanpham AND LS.Ngaynhap=(SELECT MAX(LICHSUNHAPHANG.Ngaynhap) FROM LICHSUNHAPHANG WHERE LS.Masanpham=LICHSUNHAPHANG.Masanpham)", gia);
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public bool UpdateQtySale(string id, int soluong)
        {
            try
            {
                // Ket noi
                _conn.Open();

                string query = string.Format("UPDATE SANPHAM SET Soluong='{0}' WHERE Masanpham='{1}'", soluong, id);

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
        public bool muathemsanpham(string id,int soluong,int gia)
        {
            try
            {
                // Ket noi
                _conn.Open();

                string query = string.Format("UPDATE SANPHAM SET Soluong='{0}',Gia='{1}' WHERE Masanpham='{2}'",soluong,gia, id);

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
      
        public bool xoaSanpham(string id)
        {
            try
            {
                // Ket noi
                _conn.Open();

                string query = string.Format("UPDATE SANPHAM SET Trangthai=0 WHERE Masanpham='{0}'", id);

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
        public bool themSanpham(DTO_SANPHAM sp)
        {
            try
            {
                // Ket noi
                _conn.Open();


                //string SQL = string.Format("INSERT INTO SANPHAM (Mahang,Mahieu,Tensanpham,Thongso,Soluong,Gia,Giamgia,Nhaphathanh,Trangthai," +
                //    "Hinhanh) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", sp.MAHANG, sp.MAHIEU,sp.TENSANPHAM,sp.THONGSO,sp.SOLUONG,sp.GIA,sp.GIAMGIA,sp.NHAPHATHANH,sp.TRANGTHAI,@sp.HINHANH);
                //// Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                string SQL = string.Format("INSERT INTO SANPHAM (Mahang,Mahieu,Tensanpham,Thongso,Soluong,Gia,Giamgia,Nhaphathanh,Trangthai," +
                "Hinhanh) VALUES(@Mahang,@Mahieu,@Tensanpham,@Thongso,@Soluong,@Gia,@Giamgia,@Nhaphathanh,@Trangthai,@Hinhanh)");

                SqlCommand cmd = new SqlCommand(SQL, _conn);
                cmd.Parameters.Add("@Mahang", SqlDbType.Int);
                cmd.Parameters.Add("@Mahieu", SqlDbType.Int);
                cmd.Parameters.Add("@Tensanpham", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Thongso", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Soluong", SqlDbType.Int);
                cmd.Parameters.Add("@Gia", SqlDbType.Int);
                cmd.Parameters.Add("@Giamgia", SqlDbType.Int);
                cmd.Parameters.Add("@Nhaphathanh", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Trangthai", SqlDbType.Int);
                cmd.Parameters.Add("@Hinhanh", SqlDbType.Image);


                cmd.Parameters["@Mahang"].Value = sp.MAHANG;
                cmd.Parameters["@Mahieu"].Value = sp.MAHIEU;
                cmd.Parameters["@Tensanpham"].Value = sp.TENSANPHAM;
                cmd.Parameters["@Thongso"].Value = sp.THONGSO;
                cmd.Parameters["@Soluong"].Value = sp.SOLUONG;
                cmd.Parameters["@Gia"].Value = sp.GIA;
                cmd.Parameters["@Giamgia"].Value = sp.GIAMGIA;
                cmd.Parameters["@Nhaphathanh"].Value = sp.NHAPHATHANH;
                cmd.Parameters["@Trangthai"].Value = sp.TRANGTHAI;
                cmd.Parameters["@Hinhanh"].Value = sp.HINHANH;

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
        public bool updateSanpham(string id,DTO_SANPHAM sp)
        {
            try
            {
                // Ket noi
                _conn.Open();


                //string SQL = string.Format("INSERT INTO SANPHAM (Mahang,Mahieu,Tensanpham,Thongso,Soluong,Gia,Giamgia,Nhaphathanh,Trangthai," +
                //    "Hinhanh) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", sp.MAHANG, sp.MAHIEU,sp.TENSANPHAM,sp.THONGSO,sp.SOLUONG,sp.GIA,sp.GIAMGIA,sp.NHAPHATHANH,sp.TRANGTHAI,@sp.HINHANH);
                //// Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                string SQL = string.Format("UPDATE  SANPHAM SET Mahang=@Mahang,Mahieu=@Mahieu,Tensanpham=@Tensanpham,Thongso=@Thongso,Soluong=@Soluong,Gia=@Gia,Giamgia=@Giamgia,Nhaphathanh=@Nhaphathanh, Hinhanh=@Hinhanh WHERE Masanpham=@id");

                SqlCommand cmd = new SqlCommand(SQL, _conn);
                cmd.Parameters.Add("@Mahang", SqlDbType.Int);
                cmd.Parameters.Add("@Mahieu", SqlDbType.Int);
                cmd.Parameters.Add("@Tensanpham", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Thongso", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Soluong", SqlDbType.Int);
                cmd.Parameters.Add("@Gia", SqlDbType.Int);
                cmd.Parameters.Add("@Giamgia", SqlDbType.Int);
                cmd.Parameters.Add("@Nhaphathanh", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Hinhanh", SqlDbType.Image);
                cmd.Parameters.Add("@id", SqlDbType.Int);


                cmd.Parameters["@Mahang"].Value = sp.MAHANG;
                cmd.Parameters["@Mahieu"].Value = sp.MAHIEU;
                cmd.Parameters["@Tensanpham"].Value = sp.TENSANPHAM;
                cmd.Parameters["@Thongso"].Value = sp.THONGSO;
                cmd.Parameters["@Soluong"].Value = sp.SOLUONG;
                cmd.Parameters["@Gia"].Value = sp.GIA;
                cmd.Parameters["@Giamgia"].Value = sp.GIAMGIA;
                cmd.Parameters["@Hinhanh"].Value = sp.HINHANH;
                cmd.Parameters["@Nhaphathanh"].Value = sp.NHAPHATHANH;
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
        public string getMaxid()
        {
            string query = string.Format("SElECT MAX(Masanpham) FROM SANPHAM ");
            SqlDataAdapter sanp = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanp.Fill(result);
            if (result.Rows.Count == 0)
                return "0";
            return result.Rows[0][0].ToString();
        }
        public bool checkexitProduct(string tensanpham, string tenhang, string tenhieu)
        {
            string query = string.Format("SElECT SP.Masanpham FROM SANPHAM AS SP, HANG, HIEU WHERE SP.Tensanpham=N'{0}' AND SP.Mahang=HANG.Mahang AND HANG.Tenhang=N'{1}' AND SP.Mahieu=HIEU.Mahieu AND HIEU.Tenhieu=N'{2}'",tensanpham,tenhang,tenhieu);
            SqlDataAdapter sanp = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanp.Fill(result);
            if (result.Rows.Count != 0)
                return true;
            return false;
        }

    }
}
