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
    public class DAL_Donhang:DAL_DBConnect
    {
        public bool themDonhang(DTO_DONHANG dh)
        {
            try
            {
                // Ket noi
                _conn.Open();


                string SQL = string.Format("INSERT INTO DONHANG(Tenkhachhang,Sodienthoai,Diachigiaohang,Ngaydathang,Ngaygiaohang, Tongtien, Tienthanhtoan,Hinhthucthanhtoan, Magiamgia) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", dh.TENKHACHHANG,dh.SODIENTHOAI,dh.DIACHIGIAOHANG,dh.NGAYDATHANG,dh.NGAYGIAOHANG,dh.TONGTIEN,dh.TIENTHANHTOAN,dh.HINHTHUCTHANHTOAN,dh.MAGIAMGIA);
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
        public string getMaxid()
        {
            string query = string.Format("SElECT MAX(Madonhang) FROM DONHANG ");
            SqlDataAdapter sanp = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanp.Fill(result);
            if (result.Rows.Count == 0)
                return "0";
            return result.Rows[0][0].ToString();
        }
        public string getSoldProduct()
        {
            string query = string.Format("SElECT SUM(Soluong) FROM CHITIETDONHANG ");
            SqlDataAdapter sanp = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanp.Fill(result);
            if (result.Rows.Count == 0)
                return "0";
            return result.Rows[0][0].ToString();
        }
        public string getPurchaseProduct()
        {
            string query = string.Format("SElECT SUM(Soluongnhap) FROM LICHSUNHAPHANG ");
            SqlDataAdapter sanp = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanp.Fill(result);
            if (result.Rows.Count == 0)
                return "0";
            return result.Rows[0][0].ToString();
        }
        public string getTotalProduct()
        {
            string query = string.Format("SElECT SUM(Soluong) FROM SANPHAM WHERE Trangthai=1");
            SqlDataAdapter sanp = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanp.Fill(result);
            if (result.Rows.Count == 0)
                return "0";
            return result.Rows[0][0].ToString();
        }
        public DataTable getTotalDailySold(string date)
        {
            string query = string.Format("SElECT SUM(CT.Soluong),SUM(CT.Dongia) FROM DONHANG as DH, CHITIETDONHANG as CT WHERE DH.Ngaydathang='{0}' AND DH.Madonhang=CT.Madonhang", date);
            SqlDataAdapter sanp = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanp.Fill(result);
            return result;
        }
        public DataTable getTotalDailyPurchase(string date)
        {
            string query = string.Format("SElECT SUM(Soluongnhap), SUM(Giathanh) FROM LICHSUNHAPHANG WHERE Ngaynhap='{0}'",date);
            SqlDataAdapter sanp = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanp.Fill(result);
            return result;
        }
        public DataTable getTotalDailyPayment(string date)
        {
            string query = string.Format("SElECT COUNT(Madonhang) FROM DONHANG WHERE Ngaydathang='{0}'", date);
            SqlDataAdapter sanp = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanp.Fill(result);
            return result;
        }
        public DataTable getTotalDailyPrePay(string date)
        {
            string query = string.Format("SElECT COUNT(Madonhang) FROM DONHANG WHERE Ngaydathang='{0}' AND Hinhthucthanhtoan = 0", date);
            SqlDataAdapter sanp = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanp.Fill(result);
            return result;
        }
        public DataTable getDHOrderByNgay()
        {
            string query = string.Format("SELECT Madonhang,Tenkhachhang,Ngaydathang,Ngaygiaohang, Hinhthucthanhtoan FROM DONHANG ORDER BY Ngaydathang");
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public DataTable getDHDetail(string id)
        {
            string query = string.Format("SELECT Madonhang,Sodienthoai,Diachigiaohang,Tongtien, Tienthanhtoan, Magiamgia FROM DONHANG WHERE Madonhang='{0}'",id);
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public DataTable getDataReportSale_Month(string year)
        {
            string query = string.Format("SELECT HANG.Tenhang as TH,SUM(CT.Soluong) as SL, MONTH(DH.Ngaydathang) as THANG " +
                "FROM CHITIETDONHANG as CT, DONHANG as DH,HANG WHERE YEAR(DH.Ngaydathang) = '{0}' AND DH.Madonhang=CT.Madonhang AND " +
                "CT.Mahang=HANG.Mahang GROUP BY HANG.Tenhang, MONTH(DH.Ngaydathang)  ORDER BY THANG",year);
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public DataTable getDataReportRevenue_Month(string year)
        {
            string query = string.Format("SELECT SUM(DH.Tienthanhtoan) as TT, MONTH(DH.Ngaydathang) as THANG " +
                "FROM  DONHANG as DH WHERE YEAR(DH.Ngaydathang) = '{0}'" +
                "GROUP BY DH.Tienthanhtoan, MONTH(DH.Ngaydathang)  ORDER BY THANG", year);
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public DataTable getDataReportSale_Week(string year,string month)
        {
            string query = string.Format("SELECT CT.Mahang,HANG.Tenhang as TH,SUM(CT.Soluong) as SL,DATEPART(wk,DH.Ngaydathang) as WK FROM CHITIETDONHANG as CT, DONHANG as DH,HANG WHERE YEAR(DH.Ngaydathang) = '{0}' AND MONTH(DH.Ngaydathang)='{1}' AND DH.Madonhang=CT.Madonhang AND CT.Mahang=HANG.Mahang GROUP BY CT.Mahang,HANG.Tenhang,DATEPART(wk,DH.Ngaydathang) ORDER BY WK", year,month);
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public DataTable getDataReportRevenue_Week(string year, string month)
        {
            string query = string.Format("SELECT SUM(DH.Tienthanhtoan) as TT, DATEPART(wk,DH.Ngaydathang) as WK FROM  DONHANG as DH WHERE YEAR(DH.Ngaydathang) = '{0}' AND MONTH(DH.Ngaydathang)='{1}' GROUP BY DH.Tienthanhtoan, DATEPART(wk,DH.Ngaydathang) ORDER BY WK", year, month);
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public DataTable getDataReportSale_Option(string begin, string end)
        {
            string query = string.Format("SELECT CT.Mahang,HANG.Tenhang as TH,SUM(CT.Soluong) as SL,DH.Ngaydathang as DAY FROM CHITIETDONHANG as CT, DONHANG as DH,HANG WHERE DH.Ngaydathang between '{0}' and '{1}' AND DH.Madonhang=CT.Madonhang AND CT.Mahang=HANG.Mahang GROUP BY CT.Mahang,HANG.Tenhang, DH.Ngaydathang ORDER BY DAY", begin, end);
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public DataTable getDataReportRevenue_Option(string begin, string end)
        {
            string query = string.Format("SELECT SUM(DH.Tienthanhtoan) as TT,DH.Ngaydathang as DAY FROM  DONHANG as DH WHERE DH.Ngaydathang between '{0}' and '{1}'  GROUP BY  DH.Ngaydathang ORDER BY DAY", begin, end);
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public DataTable getDataReportSale_Year()
        {
            string query = string.Format("SELECT CT.Mahang,HANG.Tenhang as TH,SUM(CT.Soluong) as SL,YEAR(DH.Ngaydathang) as YR FROM CHITIETDONHANG as CT, DONHANG as DH,HANG WHERE DH.Madonhang=CT.Madonhang AND CT.Mahang=HANG.Mahang GROUP BY CT.Mahang,HANG.Tenhang, YEAR(DH.Ngaydathang) ORDER BY YR");
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public DataTable getDataReportRevenue_Year()
        {
            string query = string.Format("SELECT SUM(DH.Tienthanhtoan) as TT,YEAR(DH.Ngaydathang) as YR FROM DONHANG as DH  GROUP BY  YEAR(DH.Ngaydathang) ORDER BY YR");
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public string getMaxYear()
        {
            string query = string.Format("select MAX(YEAR(Ngaydathang)) from DONHANG");
            SqlDataAdapter sanp = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanp.Fill(result);
            if (result.Rows.Count == 0)
                return "0";
            return result.Rows[0][0].ToString();
        }
        public string getMinYear()
        {
            string query = string.Format("select MIN(YEAR(Ngaydathang)) from DONHANG");
            SqlDataAdapter sanp = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanp.Fill(result);
            if (result.Rows.Count == 0)
                return "0";
            return result.Rows[0][0].ToString();
        }
        public DataTable getTop3Product_Year(string year)
        {
            string query = string.Format("SELECT TOP 3 CT.Mahang,HANG.Tenhang as MH,SUM(CT.Soluong) as SL FROM CHITIETDONHANG as CT, DONHANG as DH,HANG WHERE YEAR(DH.Ngaydathang) = '{0}' AND DH.Madonhang=CT.Madonhang AND CT.Mahang=HANG.Mahang GROUP BY CT.Mahang,HANG.Tenhang ORDER BY  SL DESC",year);
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public DataTable getTop3Product_Month(string year,string month)
        {
            string query = string.Format("SELECT TOP 3 CT.Mahang,HANG.Tenhang as MH,SUM(CT.Soluong) as SL FROM CHITIETDONHANG as CT, DONHANG as DH,HANG WHERE YEAR(DH.Ngaydathang) = '{0}' AND  MONTH(DH.Ngaydathang) = '{1}' AND DH.Madonhang=CT.Madonhang AND CT.Mahang=HANG.Mahang GROUP BY CT.Mahang,HANG.Tenhang ORDER BY  SL DESC", year,month);
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
        public DataTable getTop3Product_Option(string begin, string end)
        {
            string query = string.Format("SELECT TOP 3 CT.Mahang,HANG.Tenhang as MH,SUM(CT.Soluong) as SL FROM CHITIETDONHANG as CT, DONHANG as DH,HANG WHERE DH.Ngaydathang between '{0}' and '{1}' AND DH.Madonhang=CT.Madonhang AND CT.Mahang=HANG.Mahang GROUP BY CT.Mahang,HANG.Tenhang ORDER BY  SL DESC", begin, end);
            SqlDataAdapter sanpham = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            sanpham.Fill(result);
            return result;
        }
    }
}
