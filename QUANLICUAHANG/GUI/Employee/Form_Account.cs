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
    public partial class Form_Account : Form
    {
        BUS_ACCOUNT acc = new BUS_ACCOUNT();
        private string idnhanvien = "";
        public Form_Account()
        {
            InitializeComponent();
        }
        public Form_Account(string id)
        {
            InitializeComponent();
            idnhanvien = id;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form_Account_Load(object sender, EventArgs e)
        {
            lblNotice.Text = "";
            cTxbPass.Enabled = false;
            cTxbConfirm.Enabled = false;
            chkAdmin.Enabled = false;
            chkEmPloy.Enabled = false;
            this.ActiveControl = cTxbUsername;
            lblID.Text = idnhanvien;
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
            if(cTxbUsername.Text=="")
            {
                this.ActiveControl = cTxbUsername;
                lblNotice.Text = "Please enter username";
            }
            else if(acc.checkExitAccount(cTxbUsername.Text.ToString())==true)
            {
                cTxbUsername.Text = "";
                this.ActiveControl = cTxbUsername;
                lblNotice.Text = "Username already exits";
            }
            
            else if(cTxbPass.Text=="")
            {
                this.ActiveControl = cTxbPass;
                lblNotice.Text = "Please enter password";
            }
            
            else if(cTxbConfirm.Text=="")
            {
                this.ActiveControl = cTxbConfirm;
                lblNotice.Text = "Please enter confirm password";
            }
            else if(cTxbConfirm.Text.ToString()!=cTxbPass.Text.ToString())
            {
                this.ActiveControl = cTxbConfirm;
                lblNotice.Text = "Confirm password incorrect";
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
                if (acc.themAcc(tk)==true)
                {
                    result = MessageBox.Show("Adding the account succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        this.Dispose();
                    }
                }
                else
                {
                    result = MessageBox.Show("Adding the account  failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            
        }

        private void cTxbUsername_TextChanged(object sender, EventArgs e)
        {
            cTxbPass.Enabled = true;
        }

        private void cTxbPass_TextChanged(object sender, EventArgs e)
        {
            cTxbConfirm.Enabled = true;
        }

        private void cTxbConfirm_TextChanged(object sender, EventArgs e)
        {
            chkEmPloy.Enabled = true;
            chkAdmin.Enabled = true;
        }

    }
}
