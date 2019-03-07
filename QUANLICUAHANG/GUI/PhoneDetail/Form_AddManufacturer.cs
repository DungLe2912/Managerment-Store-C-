using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
namespace GUI.PhoneDetail
{
    public partial class Form_AddManufacturer : Form
    {
        BUS_Hang hang = new BUS_Hang();
        public Form_AddManufacturer()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txbNewManufacturer.Text = "";
            this.ActiveControl = txbNewManufacturer;
        }

        private void Form_AddManufacturer_Load(object sender, EventArgs e)
        {
            txbNewManufacturer.Text = "";
            this.ActiveControl = txbNewManufacturer;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            DTO_HANG dh = new DTO_HANG(0,txbNewManufacturer.Text.ToString());
            DialogResult result;
            if (txbNewManufacturer.Text == "")
            {
                result = MessageBox.Show("Please enter full information", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    txbNewManufacturer.Text = "";
                    this.ActiveControl = txbNewManufacturer;
                }
            }
            else if(hang.checkexitHang(txbNewManufacturer.Text.ToString())==false)
            {
                result = MessageBox.Show("Manufacturer name already exists", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    txbNewManufacturer.Text = "";
                    this.ActiveControl = txbNewManufacturer;
                }
            }
           else
            {
                if (hang.themHang(dh) == true)
                {
                    result = MessageBox.Show("Adding the manufacturer name succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        txbNewManufacturer.Text = "";
                        this.ActiveControl = txbNewManufacturer;
                    }
                }
                else
                {
                    result = MessageBox.Show("Adding the manufacturer name failed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (result == DialogResult.OK)
                    {
                        txbNewManufacturer.Text = "";
                        this.ActiveControl = txbNewManufacturer;
                    }
                }
            }

        }

        private void txbNewManufacturer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DTO_HANG dh = new DTO_HANG(0, txbNewManufacturer.Text.ToString());
                DialogResult result;
                if (hang.checkexitHang(txbNewManufacturer.Text.ToString()) == false)
                {
                    result = MessageBox.Show("Manufacturer name already exists", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        txbNewManufacturer.Text = "";
                        this.ActiveControl = txbNewManufacturer;
                    }
                }
                else
                {
                    if (hang.themHang(dh) == true)
                    {
                        result = MessageBox.Show("Adding the manufacturer name succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            txbNewManufacturer.Text = "";
                            this.ActiveControl = txbNewManufacturer;
                        }
                    }
                    else
                    {
                        result = MessageBox.Show("Adding the manufacturer name failed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (result == DialogResult.OK)
                        {
                            txbNewManufacturer.Text = "";
                            this.ActiveControl = txbNewManufacturer;
                        }
                    }
                }

            }
        }
    }
}
