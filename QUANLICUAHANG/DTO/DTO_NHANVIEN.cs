using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NHANVIEN
    {
        private int Manhanvien;
        private string Tennhanvien;
        private string cmnd;
        private string gioitinh;
        private string diachi;
        private DateTime ngaysinh;
        private string sodienthoai;
        private int trangthai;
        private byte[] hinhanh;
        public byte[] HINHANH
        {
            get
            {
                return hinhanh;
            }
            set
            {
                hinhanh = value;
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
        public string TENNHANVIEN
        {
            get
            {
                return Tennhanvien;
            }
            set
            {
                Tennhanvien = value;
            }
        }
        public string CMND
        {
            get
            {
                return cmnd;
            }
            set
            {
                cmnd = value;
            }
        }
        public string GIOITINH
        {
            get
            {
                return gioitinh;
            }
            set
            {
                gioitinh = value;
            }
        }
        public string DIACHI
        {
            get
            {
                return diachi;
            }
            set
            {
                diachi = value;
            }
        }
        public DateTime NGAYSINH
        {
            get
            {
                return ngaysinh;
            }
            set
            {
                ngaysinh = value;
            }
        }
        public string SODIENTHOAI
        {
            get
            {
                return sodienthoai;
            }
            set
            {
                sodienthoai = value;
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
        public DTO_NHANVIEN()
        {

        }
        public DTO_NHANVIEN(int id,string name,string cm,string sex,string addr,DateTime dob,string phone,int tt,byte[]img)
        {
            this.MANHANVIEN = id;
            this.TENNHANVIEN = name;
            this.CMND = cm;
            this.GIOITINH = sex;
            this.DIACHI = addr;
            this.NGAYSINH = dob;
            this.SODIENTHOAI = phone;
            this.TRANGTHAI = tt;
            this.HINHANH = img;
        }
    }
}
