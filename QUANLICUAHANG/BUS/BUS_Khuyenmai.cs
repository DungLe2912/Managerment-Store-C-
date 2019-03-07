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
    public class BUS_Khuyenmai
    {
        DAL_Khuyenmai khuyenmai = new DAL_Khuyenmai();
        public bool checkexitCodetoEdit(string code, int id)
        {
            return khuyenmai.checkexitCodetoEdit(code, id);
        }
        public bool checkexitCodetoSale(string code, string date)
        {
            return khuyenmai.checkexitCodetoSale(code, date);
        }
        public string getDiscount(string code)
        {
            return khuyenmai.getDiscount(code);
        }
        public string getIDFromCode(string code)
        {
            return khuyenmai.getIDFromCode(code);
        }
        public bool themMakhuyenmai(DTO_KHUYENMAI km)
        {
            return khuyenmai.themMakhuyenmai(km);
        }
        public bool checkexitCode(string code)
        {
            return khuyenmai.checkexitCode(code);
        }
        public DataTable getCode()
        {
            return khuyenmai.getCode();
        }
        public bool updateCode(int code, DTO_KHUYENMAI km)
        {
            return khuyenmai.updateCode(code, km);
        }
        public bool delCode(int code)
        {
            return khuyenmai.delCode(code);
        }
        public DataTable getCodetoEdit(string code)
        {
            return khuyenmai.getCodetoEdit(code);
        }
    }
}
