using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_Donhang
    {
        DAL_Donhang donhang = new DAL_Donhang();
        public DataTable getTop3Product_Year(string year)
        {
            return donhang.getTop3Product_Year(year);
        }
        public DataTable getTop3Product_Month(string year,string month)
        {
            return donhang.getTop3Product_Month(year,month);
        }
        public DataTable getTop3Product_Option(string begin,string end)
        {
            return donhang.getTop3Product_Option(begin,end);
        }
        public DataTable getDataReportSale_Option(string begin, string end)
        {
            return donhang.getDataReportSale_Option(begin, end);
        }
        public DataTable getDataReportRevenue_Option(string begin, string end)
        {
            return donhang.getDataReportRevenue_Option(begin, end);
        }
        public DataTable getDataReportRevenue_Year()
        {
            return donhang.getDataReportRevenue_Year();
        }
        public DataTable getDataReportRevenue_Week(string year, string month)
        {
            return donhang.getDataReportRevenue_Week(year, month);
        }
        public DataTable getDataReportRevenue_Month(string year)
        {
            return donhang.getDataReportRevenue_Month(year);
        }
        public string getMaxYear()
        {
            return donhang.getMaxYear();
        }
        public string getMinYear()
        {
            return donhang.getMinYear();
        }

        public DataTable getTotalDailyPayment(string date)
        {
            return donhang.getTotalDailyPayment(date);
        }
        public DataTable getTotalDailyPrePay(string date)
        {
            return donhang.getTotalDailyPrePay(date);
        }
        public bool themDonhang(DTO_DONHANG dh)
        {
            return donhang.themDonhang(dh);
        }
        public string getMaxid()
        {
            return donhang.getMaxid();
        }
        public DataTable getDHOrderByNgay()
        {
            return donhang.getDHOrderByNgay();
        }
        public DataTable getDHDetail(string id)
        {
            return donhang.getDHDetail(id);
        }
        public DataTable getDataReportSale_Month(string year)
        {
            return donhang.getDataReportSale_Month(year);
        }
        public DataTable getDataReportSale_Week(string year,string month)
        {
            return donhang.getDataReportSale_Week(year,month);
        }
        public DataTable getDataReportSale_Year()
        {
            return donhang.getDataReportSale_Year();
        }
        public string getSoldProduct()
        {
            return donhang.getSoldProduct();
        }
        public string getPurchaseProduct()
        {
            return donhang.getPurchaseProduct();
        }
        public string getTotalProduct()
        {
            return donhang.getTotalProduct();
        }
        public DataTable getTotalDailySold(string date)
        {
            return donhang.getTotalDailySold(date);
        }
        public DataTable getTotalDailyPurchase(string date)
        {
            return donhang.getTotalDailyPurchase(date);
        }
    }
}
