using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_SANPHAM
    {
        private int Masanpham;
        private int Mahang;
        private int Mahieu;
        private string Tensanpham;
        private string Thongso;
        private int Soluong;
        private int Gia;
        private int Giamgia;
        private string Nhaphathanh;
        private int Trangthai;
        private byte[] Hinhanh;
        public int GIAMGIA
        {
            get
            {
                return Giamgia;
            }
            set
            {
                Giamgia = value;
            }
        }
        public byte[] HINHANH
        {
            get
            {
                return Hinhanh;
            }
            set
            {
                Hinhanh = value;
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
        public string NHAPHATHANH
        {
            get
            {
                return Nhaphathanh;
            }
            set
            {
                Nhaphathanh = value;
            }
        }
        public int GIA
        {
            get
            {
                return Gia;
            }
            set
            {
                Gia = value;
            }
        }
        public string THONGSO
        {
            get
            {
                return Thongso;
            }
            set
            {
                Thongso = value;
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
        public int MAHANG
        {
            get
            {
                return Mahang;
            }
            set
            {
                Mahang = value;
            }
        }
        public int MAHIEU
        {
            get
            {
                return Mahieu;
            }
            set
            {
                Mahieu = value;
            }
        }
        public string TENSANPHAM
        {
            get
            {
                return Tensanpham;
            }
            set
            {
                Tensanpham = value;
            }
        }
        public int SOLUONG
        {
            get
            {
                return Soluong;
            }
            set
            {
                Soluong = value;
            }
        }
        public DTO_SANPHAM()
        {

        }
        public DTO_SANPHAM(int id, int idhang, int idhieu, string name, string thongso, int sl, int giaca, int giam, string nhaph, int tt, byte[] img)

        {
            this.MASANPHAM = id;
            this.MAHANG = idhang;
            this.MAHIEU = idhieu;
            this.TENSANPHAM = name;
            this.THONGSO = thongso;
            this.SOLUONG = sl;
            this.GIA = giaca;
            this.GIAMGIA = giam;
            this.NHAPHATHANH = nhaph;
            this.TRANGTHAI = tt;
            this.HINHANH = img;
        }
    }
}
