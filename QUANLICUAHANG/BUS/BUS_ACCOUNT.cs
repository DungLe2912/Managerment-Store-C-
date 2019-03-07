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
    public class BUS_ACCOUNT
    {
        DAL_Account acc = new DAL_Account();
        public DataTable getUP(string id)
        {
            return acc.getUP(id);
        }
        public bool themAcc(DTO_ACCOUNT account)
        {
            return acc.themAcc(account);
        }
        public bool updateAcc(string id, DTO_ACCOUNT account)
        {
            return acc.updateAcc(id, account);
        }
        public bool delAcc(string id)
        {
            return acc.delAcc(id);
        }
        public bool CheckAccount(string username, string password)
        {
            return acc.CheckAccount(username, password);
        }
        public string getManhanvien(string username, string password)
        {
            return acc.getManhanvien(username, password);
        }
        public string getTennhanvien(string manhanvien)
        {
            return acc.getTennhanvien(manhanvien);
        }
        public string getLoainhanvien(string username, string password)
        {
            return acc.getLoainhanvien(username, password);
        }
        public bool checkExitAccount(string username)
        {
            return acc.checkExitAccount(username);
        }
        public DataTable getAccToEdit(string id)
        {
            return acc.getAccToEdit(id);
        }
        public bool checkExitAccountToEdit(string username, string id)
        {
            return acc.checkExitAccountToEdit(username, id);
        }

    }
}
