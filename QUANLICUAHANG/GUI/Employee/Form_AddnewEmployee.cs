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
    public partial class Form_AddnewEmployee : Form
    {
        private string imgLoc = "";
        private string sex = "";
        BUS_Nhanvien nhanvien = new BUS_Nhanvien();
        public Form_AddnewEmployee()
        {
            InitializeComponent();
        }
        public bool checkData(string tmp)
        {
            var isNumeric = int.TryParse(tmp, out int n);
            if (isNumeric == false) return false;
            else if (Int32.Parse(tmp) < 0) return false;
            else return true;
        }
        public void Xoadulieu()
        {
            imgLoc = "";
            sex = "";
            cTxbName.Text = "";
            cTxbCMND.Text = "";
            cTxbAddr.Text = "";
            cTxbPhone.Text = "";
            chkFemale.Checked = false;
            chkMale.Checked = false;
            lblNotice.Text = "";
            cTxbCMND.Enabled = false;
            cTxbPhone.Enabled = false;
            cTxbAddr.Enabled = false;
            dtpkDOB.Enabled = false;
            btnAddPic.Enabled = false;
            chkFemale.Enabled = false;
            chkMale.Enabled = false;
            picAvt.Image = null;
            this.ActiveControl = cTxbName;
        }
        private void Form_AddnewEmployee_Load(object sender, EventArgs e)
        {
            Xoadulieu();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result;
            if (cTxbName.Text == "")
            {
                lblNotice.Text = "Please enter name of employee";
                this.ActiveControl = cTxbName;
            }
            else if (cTxbCMND.Text == "")
            {
                lblNotice.Text = "Please enter number citizenship of employee";
                this.ActiveControl = cTxbName;
            }
            else if (chkFemale.Checked == false && chkMale.Checked == false)
            {
                lblNotice.Text = "Please choose sex of employee";
                this.ActiveControl = chkMale;
            }
            else if (cTxbAddr.Text == "")
            {
                lblNotice.Text = "Please enter address of employee";
                this.ActiveControl = cTxbAddr;
            }
            else if (cTxbPhone.Text == "")
            {
                lblNotice.Text = "Please enter telephone number of employee";
                this.ActiveControl = cTxbPhone;
            }
            else if (nhanvien.checkCMND(cTxbCMND.Text.ToString()) == false)
            {
                lblNotice.Text = "Number of citizenship already exits";
                cTxbCMND.Text = "";
                this.ActiveControl = cTxbCMND;
            }
            else if (checkData(cTxbPhone.Text.ToString()) == false)
            {
                lblNotice.Text = "Invalid phone number";
                cTxbPhone.Text = "";
                this.ActiveControl = cTxbPhone;
            }
            else if (checkData(cTxbCMND.Text.ToString()) == false)
            {
                lblNotice.Text = "Invalid number of citizenship";
                cTxbCMND.Text = "";
                this.ActiveControl = cTxbCMND;
            }
            else if (imgLoc == "")
            {
                result = MessageBox.Show("Please choose image of employee", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    try
                    {
                        OpenFileDialog dlg = new OpenFileDialog();
                        dlg.Filter = "JPG File (*.jpg)|*.jpg|GIF File (*.gif)|*.gif|All File (*.*)|*.*";
                        dlg.Title = "Select Avata Image";
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            imgLoc = dlg.FileName.ToString();
                            picAvt.ImageLocation = imgLoc;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            else
            {

                if (chkFemale.Checked == true)
                    sex = "Nữ";
                if (chkMale.Checked == true)
                    sex = "Nam";
                byte[] img = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                DTO_NHANVIEN nv = new DTO_NHANVIEN(0, cTxbName.Text.ToString(), cTxbCMND.Text.ToString(), sex, cTxbAddr.Text.ToString(), DateTime.Parse(dtpkDOB.Value.ToShortDateString()), cTxbPhone.Text.ToString(), 1,img);
                if (nhanvien.themNhanvien(nv) == true)
                {
                    result = MessageBox.Show("Adding the employee succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        Xoadulieu();


                    }
                }
                else
                {
                    result = MessageBox.Show("Adding the employee  failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        } 

        private void btnClear_Click(object sender, EventArgs e)
        {
            Xoadulieu();
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cTxbName_TextChanged(object sender, EventArgs e)
        {
            cTxbCMND.Enabled = true;
        }

        private void cTxbCMND_TextChanged(object sender, EventArgs e)
        {
            chkMale.Enabled = true;
            chkFemale.Enabled = true;
        }

        private void chkMale_CheckedChanged(object sender, EventArgs e)
        {
            chkFemale.Checked = false;
            cTxbAddr.Enabled = true;
        }

        private void chkFemale_CheckedChanged(object sender, EventArgs e)
        {
            chkMale.Checked = false;
            cTxbAddr.Enabled = true;
        }

        private void cTxbAddr_TextChanged(object sender, EventArgs e)
        {
            dtpkDOB.Enabled = true;
            cTxbPhone.Enabled = true;
            btnAddPic.Enabled = true;
        }

        private void btnAddPic_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG File (*.jpg)|*.jpg|GIF File (*.gif)|*.gif|All File (*.*)|*.*";
                dlg.Title = "Select Avata Image";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    picAvt.ImageLocation = imgLoc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

    }
}
