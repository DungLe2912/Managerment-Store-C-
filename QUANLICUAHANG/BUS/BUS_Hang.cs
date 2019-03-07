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
    public class BUS_Hang
    {
        DAL_Hang hang = new DAL_Hang();
        public DataTable getHang()
        {
            return hang.getHang();
        }
        public bool themHang(DTO_HANG h)
        {
            return hang.themHang(h);
        }
        public bool checkexitHang(string tenhang)
        {
            return hang.checkexitHang(tenhang);
        }
    }
}
