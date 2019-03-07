using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ACCOUNT
    {
        private int Mataikhoan;
        private string username;
        private string password;
        private int trangthai;
        private int Manhanvien;
        private int Loainhanvien;
        public int LOAINHANVIEN
        {
            get
            {
                return Loainhanvien;
            }
            set
            {
                Loainhanvien = value;
            }
        }
        
        public int MATAIKHOAN
        {
            get
            {
                return Mataikhoan;
            }
            set
            {
                Mataikhoan = value;
            }
        }
        public string USERNAME
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        public string PASSWORD
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        public int TRANGTHAI
        {
            get
            {
                return trangthai;
            }
            set
            {
                trangthai = value;
            }
        }
        public int MANHANVIEN
        {
            get
            {
                return Manhanvien;
            }
            set
            {
                Manhanvien = value;
            }
        }
        public DTO_ACCOUNT()
        {

        }
        public DTO_ACCOUNT(int id,string user, string pass, int trangthai,int manhanvien,int loainhanvien)
        {
            this.MATAIKHOAN = id;
            this.USERNAME = user;
            this.PASSWORD = pass;
            this.TRANGTHAI = trangthai;
            this.MANHANVIEN = manhanvien;
            this.LOAINHANVIEN = loainhanvien;
        }

    }
}
