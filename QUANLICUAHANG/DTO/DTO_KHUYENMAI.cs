using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_KHUYENMAI
    {
        private int id;
        private string Macode;
        private DateTime Ngayhethan;
        private int Giam;
        private int Trangthai;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public int GIAM
        {
            get
            {
                return Giam;
            }
            set
            {
                Giam = value;
            }
        }
        public int TRANGTHAI
        {
            get
            {
                return Trangthai;
            }
            set
            {
                Trangthai = value;
            }
        }
        public string MACODE
        {
            get
            {
                return Macode;
            }
            set
            {
                Macode = value;
            }
        }
        public DateTime NGAYHETHAN
        {
            get
            {
                return Ngayhethan;
            }
            set
            {
                Ngayhethan = value;
            }
        }
        public DTO_KHUYENMAI()
        {

        }
        public DTO_KHUYENMAI(int idc,string code,DateTime hethan,int giamgia,int tt)
        {
            this.ID = idc;
            this.MACODE = code;
            this.NGAYHETHAN = hethan;
            this.GIAM = giamgia;
            this.TRANGTHAI = tt;
        }
    }
}
