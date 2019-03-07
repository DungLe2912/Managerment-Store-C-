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
    public class BUS_Lichsunhap
    {
        DAL_Lichsunhap ls = new DAL_Lichsunhap();
        public bool themLichsu(DTO_LICHSUNHAPHANG lsu)
        {
            return ls.themLichsu(lsu);
        }
    }
}
