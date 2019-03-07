using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.PhoneDetail
{
    public partial class Form_AddInformation : Form
    {
        public delegate void MyDelegateType(string data);
        public event MyDelegateType Handler;
      
        public Form_AddInformation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public string getDecription()
        {
            return rTxbDecription.Text;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            // getDecription();
           if(Handler!=null)
            {
                Handler(rTxbDecription.Text);
            }
            this.Dispose();

        }

        private void Form_AddInformation_Load(object sender, EventArgs e)
        {
            rTxbDecription.Text = "";
            this.ActiveControl = rTxbDecription;
        }
    }
}
