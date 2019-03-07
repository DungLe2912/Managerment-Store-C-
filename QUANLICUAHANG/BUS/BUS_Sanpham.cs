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
    public class BUS_Sanpham
    {
       
        DAL_Sanpham sp = new DAL_Sanpham();
        public DataTable getLSOrderByMasp()
        {
            return sp.getLSOrderByMasp();
        }
        public DataTable getLSOrderBySoluong()
        {
            return sp.getLSOrderBySoluong();
        }
        public DataTable getLSOrderByGiathanh()
        {
            return sp.getLSOrderByGiathanh();
        }
        public DataTable getLSOrderByNgaynhap()
        {
            return sp.getLSOrderByNgaynhap();
        }
        public DataTable getLSOrderByLoainhap()
        {
            return sp.getLSOrderByLoainhap();
        }
        public bool UpdateQtySale(string id, int soluong)
        {
            return sp.UpdateQtySale(id, soluong);
        }
        public DataTable getSanphamtoSale(string id)
        {
            return sp.getSanphamtoSale(id);
        }
        public bool updateSanpham(string id, DTO_SANPHAM spham)
        {
            return sp.updateSanpham(id, spham);
        }
        public DataTable getSanphamEdit(string id)
        {
            return sp.getSanphamEdit(id);
        }
        public bool themSanpham(DTO_SANPHAM spham)
        {
            return sp.themSanpham(spham);
        }
        public bool checkexitProduct(string tensanpham, string tenhang, string tenhieu)
        {
            return sp.checkexitProduct(tensanpham, tenhang, tenhieu);
        }
        public bool xoaSanpham(string id)
        {
            return sp.xoaSanpham(id);
        }
        public string getSoluong(string id)
        {
            return sp.getSoluong(id);
        }
        public DataTable getDetailProduct(string id)
        {
            return sp.getDetailProduct(id);
        }
        public DataTable getSanpham()
        {
            return sp.getSanpham();
        }
        public string getMaxid()
        {
            return sp.getMaxid();
        }
        public bool muathemsanpham(string id, int soluong, int gia)
        {
            return sp.muathemsanpham(id, soluong, gia);
        }
        public DataTable searchPrice(int gia)
        {
            return sp.searchPrice(gia);
        }
        public DataTable searchPurchaseDate(string date)
        {
            return sp.searchPurchaseDate(date);
        }
        public DataTable searchQuantity(int soluong)
        {
            return sp.searchQuantity(soluong);
        }
        public DataTable searchBrand(string tenhieu)
        {
            return sp.searchBrand(tenhieu);
        }
        public DataTable searchManuf(string tenhang)
        {
            return sp.searchManuf(tenhang);
        }


    }
}
