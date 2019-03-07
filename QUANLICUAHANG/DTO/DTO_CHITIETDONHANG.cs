using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CHITIETDONHANG
    {
        private int Machitiet;
        private int Madonhang;
        private int Mahang;
        private int Mahieu;

        private int Masanpham;
        private int Soluong;
        private float Dongia;
        public float DONGIA
        {
            get
            {
                return Dongia;
            }
            set
            {
                Dongia = value;
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
        public int MACHITIET
        {
            get
            {
                return Machitiet;
            }
            set
            {
                Machitiet = value;
            }
        }
        public int MADONHANG
        {
            get
            {
                return Madonhang;
            }
            set
            {
                Madonhang = value;
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
        public DTO_CHITIETDONHANG()
        {

        }
        public DTO_CHITIETDONHANG(int mact,int madonhang,int mahang,int mahieu,int masp, int soluong,float dongia)
        {
            this.MACHITIET = mact;
            this.MADONHANG = madonhang;
            this.MAHANG = mahang;
            this.MAHIEU = mahieu;
            this.MASANPHAM = masp;
            this.SOLUONG = soluong;
            this.DONGIA = dongia;
        }
    }
}
