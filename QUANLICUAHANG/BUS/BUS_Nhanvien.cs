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
    public class BUS_Nhanvien
    {
        DAL_Nhanvien nhanvien = new DAL_Nhanvien();
        public DataTable searchDOB(string date)
        {
            return nhanvien.searchDOB(date);
        }
        public DataTable searchAddr(string addr)
        {
            return nhanvien.searchAddr(addr);
        }
        public DataTable searchSex(string sex)
        {
            return nhanvien.searchSex(sex);
        }
        public DataTable getNhanvien()
        {
            return nhanvien.getNhanvien();
        }
        public bool checkCMND(string cmnd)
        {
            return nhanvien.checkCMND(cmnd);
        }
        public bool themNhanvien(DTO_NHANVIEN nv)
        {
            return nhanvien.themNhanvien(nv);
        }
        public DataTable getDetailNhanvien(string id)
        {
            return nhanvien.getDetailNhanvien(id);
        }
        public bool xoaNhanvien(string id)
        {
            return nhanvien.xoaNhanvien(id);
        }
        public DataTable getNhanvientoEdit(string id)
        {
            return nhanvien.getNhanvientoEdit(id);
        }
        public bool checkCMNDtoEdit(string cmnd, string id)
        {
            return nhanvien.checkCMNDtoEdit(cmnd, id);
        }
        public bool updateNhanvien(string id, DTO_NHANVIEN nv)
        {
            return nhanvien.updateNhanvien(id, nv);
        }
    }
}
