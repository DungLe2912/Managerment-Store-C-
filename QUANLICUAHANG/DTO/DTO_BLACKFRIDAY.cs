using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_BLACKFRIDAY
    {
        private int Mangay;
        private DateTime NgayBF;
        private string sukien;
        private int giam;
        private int trangthai;
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
        public int GIAM
        {
            get
            {
                return giam;
            }
            set
            {
                giam = value;
            }
        }
        public int MANGAY
        {
            get
            {
                return Mangay;
            }
            set
            {
                Mangay = value;
            }
        }
        public DateTime NGAYBF
        {
            get
            {
                return NgayBF;
            }
            set
            {
                NgayBF = value;
            }
        }
        public string SUKIEN
        {
            get
            {
                return sukien;
            }
            set
            {
                sukien = value;
            }
        }
        public DTO_BLACKFRIDAY()
        {

        }   
        public DTO_BLACKFRIDAY(int id,DateTime ngay,string sk,int gg,int trangthai)
        {
            this.MANGAY = id;
            this.NGAYBF = ngay;
            this.SUKIEN = sk;
            this.GIAM = gg;
            this.TRANGTHAI = trangthai;
        }

    }
}
