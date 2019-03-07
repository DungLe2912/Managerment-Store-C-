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
    public partial class Form_EditDate : Form
    {
        BUS_BF bf = new BUS_BF();
        private string date = "";
        public Form_EditDate()
        {
            InitializeComponent();
        }
        public Form_EditDate(string tmp)
        {
            InitializeComponent();
            date = tmp;
        }
        public void Xoadulieu()
        {
            lblNotice.Text = "";
            cTxbEvent.Text = "";
            ctxbDiscount.Text = "";
            this.ActiveControl = dtpkdate;
        }
        private void Form_EditDate_Load(object sender, EventArgs e)
        {
            DataTable edit = new DataTable();
            edit = bf.getDatetoEdit(date);
            dtpkdate.Value = (DateTime)edit.Rows[0][0];
            cTxbEvent.Text = edit.Rows[0][1].ToString();

            ctxbDiscount.Text = edit.Rows[0][2].ToString();
            this.ActiveControl = dtpkdate;
            lblNotice.Text = "";
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
            else if (bf.checkexitDatetoEdit(dtpkdate.Value.ToShortDateString(),Int32.Parse(bf.getIDFromDate(date))) == false)
            {
                lblNotice.Text = "Date already exits";
                this.ActiveControl = dtpkdate;
            }
            else
            {
                DTO_BLACKFRIDAY black = new DTO_BLACKFRIDAY(0, DateTime.Parse(dtpkdate.Value.ToShortDateString()), cTxbEvent.Text.ToString(), Int32.Parse(ctxbDiscount.Text.ToString()), 1);
                if (bf.updateDate(Int32.Parse(bf.getIDFromDate(date)),black) == true)
                {
                    result = MessageBox.Show("Editing the discount date succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    result = MessageBox.Show("Editing the discount date failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                if (result == DialogResult.OK)
                {
                    Xoadulieu();
                    this.Dispose();
                }
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Xoadulieu();
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
