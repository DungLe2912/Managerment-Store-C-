using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_LICHSUNHAPHANG
    {
        private int Malichsu;
        private int Masanpham;
        private int Soluongnhap;
        private int Giathanh;
        private DateTime Ngaynhap;
        private int Loaihinhnhap;
        public int MALICHSU
        {
            get
            {
                return Malichsu;
            }
            set
            {
                Malichsu = value;
            }
        }
        public int MASANPHAM
        {
            get
            {
                return Masanpham;
            }
            set
            {
                Masanpham = value;
            }
        }
        public int SOLUONGNHAP
        {
            get
            {
                return Soluongnhap;
            }
            set
            {
                Soluongnhap = value;
            }
        }
        public int GIATHANH
        {
            get
            {
                return Giathanh;
            }
            set
            {
                Giathanh = value;
            }
        }
        public DateTime NGAYNHAP
        {
            get
            {
                return Ngaynhap;
            }
            set
            {
                Ngaynhap = value;
            }
        }
        public int LOAIHINHNHAP
        {
            get
            {
                return Loaihinhnhap;
            }
            set
            {
                Loaihinhnhap = value;
            }
        }
        public DTO_LICHSUNHAPHANG()
        {

        }
        public DTO_LICHSUNHAPHANG(int id,int idsp,int sl,int giaca,DateTime ngaynhaphang, int lhn)
        {
            this.MALICHSU = id;
            this.MASANPHAM = idsp;
            this.SOLUONGNHAP = sl;
            this.GIATHANH = giaca;
            this.NGAYNHAP = ngaynhaphang;
            this.LOAIHINHNHAP = lhn;
        }
    }
}
