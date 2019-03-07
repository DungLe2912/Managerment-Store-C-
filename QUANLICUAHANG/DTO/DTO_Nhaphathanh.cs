using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NHAPHATHANH
    {
        private int Manhaphathanh;
        private string Tennhaphathanh;
        public int MANHAPHATHANH
        {
            get
            {
                return Manhaphathanh;
            }
            set
            {
                Manhaphathanh = value;
            }
        }
        public string TENNHAPHATHANH
        {
            get
            {
                return Tennhaphathanh;
            }
            set
            {
                Tennhaphathanh = value;
            }
        }
        public DTO_NHAPHATHANH()
        {

        }
        public DTO_NHAPHATHANH(int id, string name)
        {
            this.MANHAPHATHANH = id;
            this.TENNHAPHATHANH = name;
        }

    }
}
