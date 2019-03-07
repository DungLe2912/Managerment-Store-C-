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
    public partial class Form_EditCode : Form
    {
        BUS_Khuyenmai km = new BUS_Khuyenmai();
        private string Macode = "";
        public Form_EditCode()
        {
            InitializeComponent();
        }
        public Form_EditCode(string tmp)
        {
            InitializeComponent();
            Macode = tmp;
        }
        public void Xoadulieu()
        {
            lblNotice.Text = "";
            cTxbCode.Text = "";
            cTxbDiscount.Text = "";
            this.ActiveControl = cTxbCode;
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
            else if (km.checkexitCodetoEdit(cTxbCode.Text.ToString(),Int32.Parse(km.getIDFromCode(Macode))) == false)
            {
                lblNotice.Text = "Code already exits";
                cTxbCode.Text = "";
                this.ActiveControl = cTxbCode;
            }
            else
            {
                DTO_KHUYENMAI khuyenmai = new DTO_KHUYENMAI(0,cTxbCode.Text.ToString(), DateTime.Parse(dtpkdate.Value.ToShortDateString()), Int32.Parse(cTxbDiscount.Text.ToString()), 1);
                if (km.updateCode(Int32.Parse(km.getIDFromCode(Macode)),khuyenmai) == true)
                {
                    result = MessageBox.Show("Edit the discount code succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    result = MessageBox.Show("Edit the discount code failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void cTxbCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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

        private void Form_EditCode_Load(object sender, EventArgs e)
        {
            DataTable edit = new DataTable();
            edit = km.getCodetoEdit(Macode);
            cTxbCode.Text=edit.Rows[0][0].ToString();
            dtpkdate.Value= (DateTime)edit.Rows[0][1];
            cTxbDiscount.Text= edit.Rows[0][2].ToString();
            this.ActiveControl = cTxbCode;
            lblNotice.Text = "";
        }
    }
}
