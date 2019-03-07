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
    public partial class Form_AddDate : Form
    {
        BUS_BF bf = new BUS_BF();
        public Form_AddDate()
        {
            InitializeComponent();
        }
        public void Xoadulieu()
        {
            lblNotice.Text = "";
            cTxbEvent.Text = "";
            ctxbDiscount.Text = "";
            this.ActiveControl = dtpkdate;
        }
        private void Form_AddDate_Load(object sender, EventArgs e)
        {
            Xoadulieu();
        }

        private void btnClear_Click(object sender, EventArgs e)
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
        public void addData()
        {
            DialogResult result;
            if (cTxbEvent.Text == "")
            {
                lblNotice.Text = "Please enter event";
                this.ActiveControl = cTxbEvent;
            }
            else if (ctxbDiscount.Text == "")
            {
                lblNotice.Text = "Please enter discount";
                this.ActiveControl = ctxbDiscount;
            }

            else if (checkData(ctxbDiscount.Text.ToString()) == false)
            {
                lblNotice.Text = "Please enter correctly data";
                ctxbDiscount.Text = "";
                this.ActiveControl = ctxbDiscount;
            }
            else if (bf.checkexitDate(dtpkdate.Value.ToShortDateString()) == false)
            {
                lblNotice.Text = "Date already exits";
                this.ActiveControl = dtpkdate;
            }
            else
            {
                DTO_BLACKFRIDAY black = new DTO_BLACKFRIDAY(0, DateTime.Parse(dtpkdate.Value.ToShortDateString()), cTxbEvent.Text.ToString(), Int32.Parse(ctxbDiscount.Text.ToString()), 1);
                if (bf.themNgay(black) == true)
                {
                    result = MessageBox.Show("Adding the discount date succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    result = MessageBox.Show("Adding the discount date failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dtpkdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addData();
            }
        }

        private void cTxbEvent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addData();
            }
        }

        private void ctxbDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addData();
            }
        }
    }
}
