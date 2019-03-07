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
    public class BUS_BF
    {
        DAL_BF bf = new DAL_BF();
        public DataTable getDate()
        {
            return bf.getDate();
        }
        public DataTable getDatetoEdit(string date)
        {
            return bf.getDatetoEdit(date);
        }
        public bool checkexitDate(string date)
        {
            return bf.checkexitDate(date);
        }
        public bool checkexitDatetoEdit(string date, int id)
        {
            return bf.checkexitDatetoEdit(date, id);
        }
        public string getIDFromDate(string date)
        {
            return bf.getIDFromDate(date);
        }
        public bool themNgay(DTO_BLACKFRIDAY bfr)

        {
            return bf.themNgay(bfr);
        }

        public bool updateDate(int id, DTO_BLACKFRIDAY bfr)
        {
            return bf.updateDate(id, bfr);
        }
        public bool delDate(int id)
        {
            return bf.delDate(id);
        }
        public string getDiscountFromDate(string date)
        {
            return bf.getDiscountFromDate(date);
        }
    }
}
