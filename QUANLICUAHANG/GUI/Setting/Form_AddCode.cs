using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using DTO;
using BUS;

namespace GUI.Setting
{
    public partial class Form_AddCode : Form
    {
        BUS_Khuyenmai km = new BUS_Khuyenmai();
        public Form_AddCode()
        {
            InitializeComponent();
        }
        public void Xoadulieu()
        {
            lblNotice.Text = "";
            cTxbCode.Text = "";
            cTxbDiscount.Text = "";
            this.ActiveControl = cTxbCode;
        }
        /// <summary>
        /// click button Clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Xoadulieu();
            
        }
        public bool checkData(string tmp)
        {
            var isNumeric = int.TryParse(tmp, out int n);
            if (isNumeric == false) return false;
            else if (Int32.Parse(tmp) < 0) return false;
            else return true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void addData()
        {
            DialogResult result;
            if (cTxbCode.Text == "")
            {
                lblNotice.Text = "Please enter discount code";
                this.ActiveControl = cTxbCode;
            }
            else if (cTxbDiscount.Text == "")
            {
                lblNotice.Text = "Please enter discount";
                this.ActiveControl = cTxbDiscount;
            }

            else if (checkData(cTxbDiscount.Text.ToString()) == false)
            {
                lblNotice.Text = "Please enter correctly data";
                cTxbDiscount.Text = "";
                this.ActiveControl = cTxbDiscount;
            }
            else if(km.checkexitCode(cTxbCode.Text.ToString())==false)
            {
                lblNotice.Text = "Code already exits";
                cTxbCode.Text = "";
                this.ActiveControl = cTxbCode;
            }
            else
            {
                DTO_KHUYENMAI khuyenmai = new DTO_KHUYENMAI(0,cTxbCode.Text.ToString(), DateTime.Parse(dtpkdate.Value.ToShortDateString()), Int32.Parse(cTxbDiscount.Text.ToString()), 1);
                if (km.themMakhuyenmai(khuyenmai) == true)
                {
                    result = MessageBox.Show("Adding the discount code succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    result = MessageBox.Show("Adding the discount code failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                if (result == DialogResult.OK)
                {
                    Xoadulieu();
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            addData();
        }

        private void Form_AddCode_Load(object sender, EventArgs e)
        {
            Xoadulieu();
        }

        private void cTxbCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                addData();
            }
        }

       

        private void cTxbDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addData();
            }
        }

        private void dtpkdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addData();
            }
        }
        private void cTxbDiscount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
