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

namespace GUI.Employee
{
    public partial class Form_EditAccount : Form
    {
        BUS_ACCOUNT acc = new BUS_ACCOUNT();
        private string idnhanvien = "";
        public Form_EditAccount()
        {
            InitializeComponent();
        }
        public Form_EditAccount(string id)
        {
            InitializeComponent();
            idnhanvien = id;
        }
        private void Form_AccountControl_Load(object sender, EventArgs e)
        {
            DataTable edit = new DataTable();
            edit = acc.getAccToEdit(idnhanvien);
            cTxbUsername.Text = edit.Rows[0][0].ToString();
            cTxbPass.Text = edit.Rows[0][1].ToString();
            if (edit.Rows[0][2].ToString() == "1")
                chkEmPloy.Checked = true;
            if (edit.Rows[0][2].ToString() == "0")
                chkAdmin.Checked = true;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cTxbUsername.Text = "";
            cTxbPass.Text = "";
            chkEmPloy.Checked = false;
            chkAdmin.Checked = false;
        }

        private void chkEmPloy_CheckedChanged(object sender, EventArgs e)
        {
            chkAdmin.Checked = false;
        }

        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {

            chkEmPloy.Checked = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cTxbUsername.Text == "")
            {
                this.ActiveControl = cTxbUsername;
                lblNotice.Text = "Please enter username";
            }
            else if (acc.checkExitAccountToEdit(cTxbUsername.Text.ToString(),idnhanvien) == true)
            {
                cTxbUsername.Text = "";
                this.ActiveControl = cTxbUsername;
                lblNotice.Text = "Username already exits";
            }

            else if (cTxbPass.Text == "")
            {
                this.ActiveControl = cTxbPass;
                lblNotice.Text = "Please enter password";
            }
            else if (chkAdmin.Checked == false && chkEmPloy.Checked == false)
            {
                this.ActiveControl = chkEmPloy;
                lblNotice.Text = "Please choose role of employee";
            }
            else
            {
                int role = 0;
                if (chkEmPloy.Checked == true)
                    role = 1;
                if (chkAdmin.Checked == true)
                    role = 0;
                DTO_ACCOUNT tk = new DTO_ACCOUNT(0, cTxbUsername.Text.ToString(), cTxbPass.Text.ToString(), 1, Int32.Parse(idnhanvien), role);
                DialogResult result;
                if (acc.updateAcc(idnhanvien,tk) == true)
                {
                    result = MessageBox.Show("Editing the account succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        this.Dispose();
                    }
                }
                else
                {
                    result = MessageBox.Show("Editing the account  failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
