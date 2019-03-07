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
    public partial class Form_EditEmployee : Form
    {
        BUS_Nhanvien nhanvien = new BUS_Nhanvien();
        private string idnhanvien = "";
        private string imgLoc="";
        private byte[] image = null;
        private string sex = "";
        public Form_EditEmployee()
        {
            InitializeComponent();
        }
        public Form_EditEmployee(string tmp)
        {
            InitializeComponent();
            idnhanvien = tmp;
        }
        public bool checkData(string tmp)
        {
            var isNumeric = int.TryParse(tmp, out int n);
            if (isNumeric == false) return false;
            else if (Int32.Parse(tmp) < 0) return false;
            else return true;
        }
        private void Form_EditEmployee_Load(object sender, EventArgs e)
        {
            lblNotice.Text = "";
            DataTable edit = new DataTable();
            edit = nhanvien.getNhanvientoEdit(idnhanvien);
            lblID.Text = edit.Rows[0][0].ToString();
            cTxbName.Text= edit.Rows[0][1].ToString();
            cTxbCMND.Text = edit.Rows[0][2].ToString();
            if (edit.Rows[0][3].ToString() == "Nam")
                chkMale.Checked = true;
            else
                chkFemale.Checked = true;
            cTxbAddr.Text= edit.Rows[0][4].ToString();
            dtpkDOB.Value = (DateTime)edit.Rows[0][5];
            cTxbPhone.Text = edit.Rows[0][6].ToString();
            image = (byte[])(edit.Rows[0][7]);
            if (image == null)
            {
                picAvt.Image = null;
            }
            else
            {
                String sProfile = Convert.ToBase64String(image);

                var stream = new MemoryStream(Convert.FromBase64String(sProfile));
                picAvt.Image = Image.FromStream(stream);
            }
            this.ActiveControl = cTxbName;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblNotice.Text = "";
            cTxbName.Text = "";
            cTxbAddr.Text = "";
            cTxbCMND.Text = "";
            cTxbPhone.Text = "";
            chkMale.Checked = false;
            chkFemale.Checked = false;
            picAvt.Image = null;
            imgLoc = "";
            sex = "";
            image = null;
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
            else if (nhanvien.checkCMNDtoEdit(cTxbCMND.Text.ToString(),idnhanvien) == false)
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
            else if (picAvt.Image == null)
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
                //MessageBox.Show(cmbManuf.Text);
                if (imgLoc == "")
                {
                    img = image;
                }
                else
                {

                    FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);
                }
                DTO_NHANVIEN nv = new DTO_NHANVIEN(0, cTxbName.Text.ToString(), cTxbCMND.Text.ToString(), sex, cTxbAddr.Text.ToString(), DateTime.Parse(dtpkDOB.Value.ToShortDateString()), cTxbPhone.Text.ToString(), 1, img);
                if (nhanvien.updateNhanvien(idnhanvien,nv) == true)
                {
                    result = MessageBox.Show("Editing the employee succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        this.Dispose();


                    }
                }
                else
                {
                    result = MessageBox.Show("Editing the employee  failed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void chkMale_CheckedChanged(object sender, EventArgs e)
        {
            chkFemale.Checked = false;
        }

        private void chkFemale_CheckedChanged(object sender, EventArgs e)
        {
            chkMale.Checked = false;
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
