using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using System.IO;
using DTO;
using BUS;

namespace GUI.SalePhone
{
    public partial class UC_Sale : UserControl
    {
        BUS_Sanpham sanpham = new BUS_Sanpham();
        public UC_Sale()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
       
        public void Xoadulieu_SP()
        {
            txbIDPhone.Text = "";
            txbQuantity.Text = "";
            picImagePhone.Image = null;
            txbManuf.Text = "";
            txbBrand.Text = "";
            txbName.Text = "";
            txbPub.Text = "";
            txbPrice.Text = "";
            txbDiscount.Text = "";
            rTxbDes.Text = "";
            lblNotice.Text = "";
            this.ActiveControl = txbIDPhone;
            txbQuantity.Enabled = false;
        }

        public void Xoadulieu_Detail()
        {
            lsvDetailSale.Items.Clear();
            lbTotal.Text = "0";
        }
        public void Total()
        {
            float total = 0;
            foreach (ListViewItem item in lsvDetailSale.Items)
            {
                total += float.Parse(item.SubItems[2].Text, CultureInfo.InvariantCulture.NumberFormat);
            }
            lbTotal.Text= total.ToString();
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            using (SalePhone.Form_Finish uf = new SalePhone.Form_Finish(lbTotal.Text.ToString(),lsvDetailSale))
            {
                uf.ShowDialog();
                if(uf.IsDisposed)
                {
                    Xoadulieu_Detail();
                    Xoadulieu_SP();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Xoadulieu_SP();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Xoadulieu_Detail();
        }

        private void UC_Sale_Load(object sender, EventArgs e)
        {
           
            Xoadulieu_SP();
            Xoadulieu_Detail();
           
        }
        public bool checkData(string tmp)
        {
            var isNumeric = int.TryParse(tmp, out int n);
            if (isNumeric == false) return false;
            else if (Int32.Parse(tmp) < 0) return false;
            else return true;
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            DataTable detailsp = new DataTable();
            if(checkData(txbIDPhone.Text.ToString())==false)
            {
                Xoadulieu_SP();
                lblNotice.Text = "Incorrect data. Please try again";
                return;
            }
            if (checkData(txbIDPhone.Text.ToString()) == false)
            {
                Xoadulieu_SP();
                lblNotice.Text = "Incorrect data. Please try again";
                return;
            }
            detailsp = sanpham.getSanphamEdit(txbIDPhone.Text.ToString());
            if(detailsp.Rows.Count==0)
            {
                Xoadulieu_SP();
                lblNotice.Text = "ID Phone not exits. Please try again";
                

            }
            else
            {
                txbManuf.Text = detailsp.Rows[0][1].ToString();
                txbBrand.Text = detailsp.Rows[0][2].ToString();
                txbName.Text = detailsp.Rows[0][3].ToString();
                txbPub.Text = detailsp.Rows[0][8].ToString();
                txbPrice.Text = detailsp.Rows[0][6].ToString();
                txbDiscount.Text = detailsp.Rows[0][7].ToString();
                rTxbDes.Text = detailsp.Rows[0][4].ToString();

                var image = (byte[])(detailsp.Rows[0][9]);
                if (image == null)
                {
                    picImagePhone.Image = null;
                }
                else
                {
                    String sProfile = Convert.ToBase64String(image);

                    var stream = new MemoryStream(Convert.FromBase64String(sProfile));
                    picImagePhone.Image = Image.FromStream(stream);
                }
                this.ActiveControl = txbQuantity;

            }
        }
        public bool checkSale(string id)
        {
            foreach(ListViewItem item in lsvDetailSale.Items)
            {
                if (item.SubItems[3].Text==id)
                    return false;

            }
            return true;
        }
        public bool addQuantity(string qty,string id,string cqty)
        {
            DataTable detailsp = new DataTable();
            detailsp = sanpham.getSanphamEdit(id);

            foreach (ListViewItem item in lsvDetailSale.Items)
            {
                if (item.SubItems[3].Text == id)
                {
                    int tmp = Int32.Parse(item.SubItems[1].Text) + Int32.Parse(qty);
                    if (tmp > Int32.Parse(cqty))
                        return false;
                    else
                    {
                        item.SubItems[1].Text = tmp.ToString();
                        float amount = (float)(Int32.Parse(detailsp.Rows[0][6].ToString()) * (float)(Int32.Parse(item.SubItems[1].Text.ToString())) * (float)(1 - (float)((float)(Int32.Parse(detailsp.Rows[0][7].ToString())) / 100)));
                        item.SubItems[2].Text = amount.ToString();
                        
                        return true;
                    }
                }

            }
            return true;
        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            DataTable detailsp = new DataTable();
            detailsp = sanpham.getSanphamEdit(txbIDPhone.Text.ToString());
            
            if (txbIDPhone.Text=="")
            {
                Xoadulieu_SP();
                lblNotice.Text = "Please enter id product";
            }
            else if (checkData(txbIDPhone.Text.ToString()) == false)
            {
                Xoadulieu_SP();
                lblNotice.Text = "Incorrect data. Please try again";
                
            }
            
            else if(detailsp.Rows.Count == 0)
            {
                Xoadulieu_SP();
                lblNotice.Text = "ID Phone not exits. Please try again";
            }
            else if (txbQuantity.Text=="")
            {
                this.ActiveControl = txbQuantity;
                lblNotice.Text = "Please enter quantity of product";
            }
            else if(checkData(txbQuantity.Text.ToString())==false)
            {
                txbQuantity.Text = "";
                this.ActiveControl = txbQuantity;
                lblNotice.Text = "Incorrect data";
            }
            else if(Int32.Parse(txbQuantity.Text.ToString())>Int32.Parse(sanpham.getSoluong(txbIDPhone.Text.ToString())))
            {
                txbQuantity.Text = "";
                this.ActiveControl = txbQuantity;
                lblNotice.Text = "Beyond quantity";
            }
            else
            {
                if (checkSale(txbIDPhone.Text.ToString()) == false)
                {
                    DialogResult result;

                    result = MessageBox.Show("This product is already in the shopping cart. Would you like to buy more?", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        if (addQuantity(txbQuantity.Text.ToString(), txbIDPhone.Text.ToString(), sanpham.getSoluong(txbIDPhone.Text.ToString()))==false)
                        {
                            txbQuantity.Text = "";
                            this.ActiveControl = txbQuantity;
                            lblNotice.Text = "Beyond quantity";
                        }
                        else
                        {
                            lsvDetailSale.Refresh();
                            Xoadulieu_SP();
                        }

                    }
                    

                }
                else
                {
                    float amount = (float)(Int32.Parse(detailsp.Rows[0][6].ToString()) * (float)(Int32.Parse(txbQuantity.Text.ToString())) * (float)(1 - (float)((float)(Int32.Parse(detailsp.Rows[0][7].ToString())) / 100)));
                    ListViewItem item = new ListViewItem(new[] { detailsp.Rows[0][3].ToString(), txbQuantity.Text.ToString(), amount.ToString(), txbIDPhone.Text.ToString() });
                    lsvDetailSale.Items.Add(item);
                    lsvDetailSale.Refresh();
                    Xoadulieu_SP();
                }

                Total();
            }
        }

        private void txbIDPhone_TextChanged(object sender, EventArgs e)
        {
            txbQuantity.Enabled = true;
        }

        private void btnAddQT_Click(object sender, EventArgs e)
        {
            DataTable detailsp = new DataTable();
           if(lsvDetailSale.SelectedItems.Count==0)
            {
                MessageBox.Show("Please select an order", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                detailsp = sanpham.getSanphamEdit(lsvDetailSale.SelectedItems[0].SubItems[3].Text);
                if (Int32.Parse(lsvDetailSale.SelectedItems[0].SubItems[1].Text) + 1 <= Int32.Parse(detailsp.Rows[0][5].ToString()))
                {
                    lsvDetailSale.SelectedItems[0].SubItems[1].Text = (Int32.Parse(lsvDetailSale.SelectedItems[0].SubItems[1].Text) + 1).ToString();
                    float amount = (float)(Int32.Parse(detailsp.Rows[0][6].ToString()) * (float)(Int32.Parse(lsvDetailSale.SelectedItems[0].SubItems[1].Text.ToString())) * (float)(1 - (float)((float)(Int32.Parse(detailsp.Rows[0][7].ToString())) / 100)));
                    lsvDetailSale.SelectedItems[0].SubItems[2].Text = amount.ToString();
                    Total();
                }
                else
                    MessageBox.Show("Beyond quantity", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnSubQT_Click(object sender, EventArgs e)
        {
            DataTable detailsp = new DataTable();
            if (lsvDetailSale.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an order", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                detailsp = sanpham.getSanphamEdit(lsvDetailSale.SelectedItems[0].SubItems[3].Text);
                if (Int32.Parse(lsvDetailSale.SelectedItems[0].SubItems[1].Text) - 1 >=0)
                {
                    lsvDetailSale.SelectedItems[0].SubItems[1].Text = (Int32.Parse(lsvDetailSale.SelectedItems[0].SubItems[1].Text) - 1).ToString();
                    float amount = (float)(Int32.Parse(detailsp.Rows[0][6].ToString()) * (float)(Int32.Parse(lsvDetailSale.SelectedItems[0].SubItems[1].Text.ToString())) * (float)(1 - (float)((float)(Int32.Parse(detailsp.Rows[0][7].ToString())) / 100)));
                    lsvDetailSale.SelectedItems[0].SubItems[2].Text = amount.ToString();
                    Total();
                }
                else
                    MessageBox.Show("Quantity cannot be less than 0", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Do you wanna delete this order?", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result==DialogResult.OK)
            {
                lsvDetailSale.SelectedItems[0].Remove();
                Total();
            }

        }

        private void btnEditDetail_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Function not available", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
