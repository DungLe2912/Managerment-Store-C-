using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_DONHANG
    {
        private int Madonhang;
        private string Tenkhachhang;
        private string Sodienthoai;

        private string Diachigiaohang;
        private DateTime Ngaydathang;
        private DateTime Ngaygiaohang;
        private float Tongtien;
        private float Tienthanhtoan;
        private int Hinhthucthanhtoan;
        private string Magiamgia;
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
        public int HINHTHUCTHANHTOAN
        {
            get
            {
                return Hinhthucthanhtoan;
            }
            set
            {
                Hinhthucthanhtoan = value;
            }
        }
        public float TIENTHANHTOAN
        {
            get
            {
                return Tienthanhtoan;
            }
            set
            {
                Tienthanhtoan = value;
            }
        }
        public string SODIENTHOAI
        {
            get
            {
                return Sodienthoai;
            }
            set
            {
                Sodienthoai = value;
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
        public string TENKHACHHANG
        {
            get
            {
                return Tenkhachhang;
            }
            set
            {
                Tenkhachhang = value;
            }
        }
        public string DIACHIGIAOHANG
        {
            get
            {
                return Diachigiaohang;
            }
            set
            {
                Diachigiaohang = value;
            }
        }
        public DateTime NGAYDATHANG
        {
            get
            {
                return Ngaydathang;
            }
            set
            {
                Ngaydathang = value;
            }
        }
        public DateTime NGAYGIAOHANG
        {
            get
            {
                return Ngaygiaohang;
            }
            set
            {
                Ngaygiaohang = value;
            }
        }
        public float TONGTIEN
        {
            get
            {
                return Tongtien;
            }
            set
            {
                Tongtien = value;
            }
        }
        public DTO_DONHANG()
        {

        }
        public DTO_DONHANG(int madonhang,string name, string sdt, string diachi, DateTime ngaydat, DateTime ngaygiao, float tong, float thanhtoan, int hinhthuc, string code)
        {
            this.MADONHANG = madonhang;
            this.TENKHACHHANG = name;
            this.SODIENTHOAI = sdt;
            this.DIACHIGIAOHANG = diachi;
            this.NGAYDATHANG = ngaydat;
            this.NGAYGIAOHANG = ngaygiao;
            this.TONGTIEN = tong;
            this.TIENTHANHTOAN = thanhtoan;
            this.HINHTHUCTHANHTOAN = hinhthuc;
            this.MAGIAMGIA = code;
        }
        
    }
}
