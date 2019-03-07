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
    public partial class Form_AddPublisher : Form
    {
        BUS_Nhaphathanh nph = new BUS_Nhaphathanh();
        public Form_AddPublisher()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txbNewPublisher.Text = "";
            this.ActiveControl = txbNewPublisher;
        }

        private void Form_AddPublisher_Load(object sender, EventArgs e)
        {
            txbNewPublisher.Text = "";
            this.ActiveControl = txbNewPublisher;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            DTO_NHAPHATHANH iNhaphathanh = new DTO_NHAPHATHANH(0, txbNewPublisher.Text);
            DialogResult result;
            if (txbNewPublisher.Text == "")
            {
                result = MessageBox.Show("Please enter full information", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    txbNewPublisher.Text = "";
                    this.ActiveControl = txbNewPublisher;
                }
            }
            else if (nph.checkexitNph(txbNewPublisher.Text.ToString()) == false)
            {
                result = MessageBox.Show("Publisher name already exists", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    txbNewPublisher.Text = "";
                    this.ActiveControl = txbNewPublisher;
                }
            }
            else
            {
                if (nph.themNPH(iNhaphathanh) == true)
                {
                    result = MessageBox.Show("Adding the Publisher name succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        txbNewPublisher.Text = "";
                        this.ActiveControl = txbNewPublisher;
                    }
                }
                else
                {
                    result = MessageBox.Show("Adding the Publisher name failed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (result == DialogResult.OK)
                    {
                        txbNewPublisher.Text = "";
                        this.ActiveControl = txbNewPublisher;
                    }
                }
            }

        }

        private void txbNewPublisher_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                DTO_NHAPHATHANH iNhaphathanh = new DTO_NHAPHATHANH(0, txbNewPublisher.Text);
                DialogResult result;
                if (txbNewPublisher.Text == "")
                {
                    result = MessageBox.Show("Please enter full information", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        txbNewPublisher.Text = "";
                        this.ActiveControl = txbNewPublisher;
                    }
                }
                else if (nph.checkexitNph(txbNewPublisher.Text.ToString()) == false)
                {
                    result = MessageBox.Show("Publisher name already exists", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        txbNewPublisher.Text = "";
                        this.ActiveControl = txbNewPublisher;
                    }
                }
                else
                {
                    if (nph.themNPH(iNhaphathanh) == true)
                    {
                        result = MessageBox.Show("Adding the Publisher name succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            txbNewPublisher.Text = "";
                            this.ActiveControl = txbNewPublisher;
                        }
                    }
                    else
                    {
                        result = MessageBox.Show("Adding the Publisher name failed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (result == DialogResult.OK)
                        {
                            txbNewPublisher.Text = "";
                            this.ActiveControl = txbNewPublisher;
                        }
                    }
                }

            }
        }
    }
}
