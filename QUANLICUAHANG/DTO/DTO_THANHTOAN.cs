using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_THANHTOAN
    {
        private int Mahoadon;
        private int Madonhang;
        private int Loaihinhthanhtoan;
        private string Magiamgia;
        private DateTime Ngaythanhtoan;
        public int MAHOADON
        {
            get
            {
                return Mahoadon;
            }
            set
            {
                Mahoadon = value;
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
        public int LOAIHINHTHANHTOAN
        {
            get
            {
                return Loaihinhthanhtoan;
            }
            set
            {
                Loaihinhthanhtoan = value;
            }
        }
        public string MAGIAMGIA
        {
            get
            {
                return Magiamgia;
            }
            set
            {
                Magiamgia = value;
            }
        }
        public DateTime NGAYTHANHTOAN
        {
            get
            {
                return Ngaythanhtoan;
            }
            set
            {
                Ngaythanhtoan = value;
            }
        }
    }
}
