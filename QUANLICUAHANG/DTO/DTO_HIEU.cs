using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HIEU
    {
        private int Mahieu;
        private int Mahang;
        private string Tenhieu;
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
        public string TENHIEU
        {
            get
            {
                return Tenhieu;
            }
            set
            {
                Tenhieu = value;
            }
        }
        public DTO_HIEU()
        {

        }
        public DTO_HIEU(int id,int idhang,string name)
        {
            this.MAHIEU = id;
            this.MAHANG = idhang;
            this.TENHIEU = name;
        }
    }
}
