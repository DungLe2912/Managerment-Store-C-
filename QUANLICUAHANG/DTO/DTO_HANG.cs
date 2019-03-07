using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HANG
    {
        private int Maloai;
        private string Tenhang;
        public int MAHANG
        {
            get
            {
                return Maloai;
            }
            set
            {
                Maloai = value;
            }
        }
        public string TENHANG
        {
            get
            {
                return Tenhang;
            }
            set
            {
                Tenhang = value;
            }
        }
        public DTO_HANG()
        {

        }
        public DTO_HANG(int id,string name)
        {
            this.MAHANG = id;
            this.TENHANG = name;
        }

    }
}
