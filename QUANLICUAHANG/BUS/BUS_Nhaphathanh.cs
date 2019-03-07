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
    public class BUS_Nhaphathanh
    {
        DAL_Nhaphathanh nph = new DAL_Nhaphathanh();
        public DataTable getNhaphathanh()
        {
            return nph.getNhaphathanh();
        }
        public bool checkexitNph(string tennph)
        {
            return nph.checkexitNph(tennph);
        }
        public bool themNPH(DTO_NHAPHATHANH nhaph)
        {
            return nph.themNPH(nhaph);
        }
    }
}
