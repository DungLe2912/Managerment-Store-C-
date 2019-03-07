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
    public partial class Form_DetailEmployee : Form
    {
        BUS_ACCOUNT acc = new BUS_ACCOUNT();
        BUS_Nhanvien nhanvien = new BUS_Nhanvien();
        private string idnhanvien = "";
        public Form_DetailEmployee()
        {
            InitializeComponent();
        }
        public Form_DetailEmployee(string tmp)
        {
            InitializeComponent();
            idnhanvien = tmp;
        }
        public void LoadData()
        {
            DataTable img = new DataTable();
            DataTable up = new DataTable();
            lblNotice.Text = "";
            txbPass.Visible = true;
            txbUsername.Visible = true;
            label1.Visible = true;
            label3.Visible = true;
            img = nhanvien.getDetailNhanvien(idnhanvien);
            up = acc.getUP(idnhanvien);
            
            if ((byte[])img.Rows[0][0] == null)
                picAvt.Image = null;
            else
            {
                var imgLoc = (byte[])img.Rows[0][0];
                String sProfile = Convert.ToBase64String(imgLoc);

                var stream = new MemoryStream(Convert.FromBase64String(sProfile));
                picAvt.Image = Image.FromStream(stream);
            }
            if(up.Rows.Count==0)
            {
                txbPass.Visible = false;
                txbUsername.Visible = false;
                label1.Visible = false;
                label3.Visible = false;
                lblNotice.Text = "Employee has not account";
            }
            else
            {
                txbPass.Text = up.Rows[0][1].ToString();
                txbUsername.Text = up.Rows[0][0].ToString();
            }
        }
        private void Form_DetailEmployee_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you wanna delete this employee?", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {

                if (nhanvien.xoaNhanvien(idnhanvien) == true)
                {
                    res = MessageBox.Show("Delete the employee succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (res == DialogResult.OK)
                    {

                        this.Dispose();

                    }
                }
                else
                {
                    res = MessageBox.Show("Delete the employee failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (Employee.Form_EditEmployee edit=new Employee.Form_EditEmployee(idnhanvien))
            {
                this.Hide();
                edit.ShowDialog();
                if(edit.IsDisposed)
                {
                    this.Show();
                    LoadData();
                }
            }
        }
    }
}
