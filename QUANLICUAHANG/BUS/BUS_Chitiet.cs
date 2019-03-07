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
    public class BUS_Chitiet
    {
        DAL_Chitiet chitiet = new DAL_Chitiet();
        public bool themChitiet(DTO_CHITIETDONHANG ct)
        {
            return chitiet.themChitiet(ct);
        }
        public DataTable getDetail(string id)
        {
            return chitiet.getDetail(id);
        }
    }
}
