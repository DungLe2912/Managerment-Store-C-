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
    public class BUS_Hieu
    {
        DAL_Hieu hieu = new DAL_Hieu();
        public DataTable getHieu(string tenhang)
        {
            return hieu.getHieu(tenhang);
        }
        public bool checkexitTenhieu(string tenhang, string tenhieu)
        {
            return hieu.checkexitTenhieu(tenhang, tenhieu);
        }
        public bool themHieu(DTO_HIEU Ihieu)
        {
            return hieu.themHieu(Ihieu);
        }
        public string getMahang(string tenhang)
        {
            return hieu.getMahang(tenhang);
        }
        public string getMahieu(string tenhang, string tenhieu)
        {
            return hieu.getMahieu(tenhang, tenhieu);
        }
    }

}
