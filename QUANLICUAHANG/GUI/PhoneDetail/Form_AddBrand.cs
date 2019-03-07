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
    public partial class Form_AddBrand : Form
    {
        BUS_Hieu hieu = new BUS_Hieu();
        private string tenhang = "";
        public Form_AddBrand()
        {
            InitializeComponent();
        }
        public Form_AddBrand(string tmp)
        {
            InitializeComponent();
            tenhang = tmp;
        }

        /// <summary>
        /// click button Cancle to Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txbNewBrand.Text = "";
            this.ActiveControl = txbNewBrand;
            
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            DTO_HIEU iHieu = new DTO_HIEU(0,Int32.Parse(hieu.getMahang(tenhang)), txbNewBrand.Text);
            DialogResult result;
            if(txbNewBrand.Text=="")
            {
                result = MessageBox.Show("Please enter full information", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    txbNewBrand.Text = "";
                    this.ActiveControl = txbNewBrand;
                }
            }
            else if (hieu.checkexitTenhieu(tenhang,txbNewBrand.Text.ToString()) == false)
            {
                result = MessageBox.Show("Brand name already exists", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    txbNewBrand.Text = "";
                    this.ActiveControl = txbNewBrand;
                }
            }
            else
            {
                if (hieu.themHieu(iHieu) == true)
                {
                    result = MessageBox.Show("Adding the brand name succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        txbNewBrand.Text = "";
                        this.ActiveControl = txbNewBrand;
                    }
                }
                else
                {
                    result = MessageBox.Show("Adding the brand name failed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (result == DialogResult.OK)
                    {
                        txbNewBrand.Text = "";
                        this.ActiveControl = txbNewBrand;
                    }
                }
            }

        }

        private void Form_AddBrand_Load(object sender, EventArgs e)
        {
            txbNewBrand.Text = "";
            this.ActiveControl = txbNewBrand;
        }

        private void txbNewBrand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DTO_HIEU iHieu = new DTO_HIEU(0, Int32.Parse(hieu.getMahang(tenhang)), txbNewBrand.Text);
                DialogResult result;
                if (txbNewBrand.Text == "")
                {
                    result = MessageBox.Show("Please enter full information", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        txbNewBrand.Text = "";
                        this.ActiveControl = txbNewBrand;
                    }
                }
                else if (hieu.checkexitTenhieu(tenhang, txbNewBrand.Text.ToString()) == false)
                {
                    result = MessageBox.Show("Brand name already exists", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        txbNewBrand.Text = "";
                        this.ActiveControl = txbNewBrand;
                    }
                }
                else
                {
                    if (hieu.themHieu(iHieu) == true)
                    {
                        result = MessageBox.Show("Adding the brand name succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            txbNewBrand.Text = "";
                            this.ActiveControl = txbNewBrand;
                        }
                    }
                    else
                    {
                        result = MessageBox.Show("Adding the brand name failed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (result == DialogResult.OK)
                        {
                            txbNewBrand.Text = "";
                            this.ActiveControl = txbNewBrand;
                        }
                    }
                }

            }
        }
    }
}
