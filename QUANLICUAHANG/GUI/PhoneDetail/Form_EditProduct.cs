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

namespace GUI.PhoneDetail
{
    public partial class Form_EditProduct : Form
    {
        BUS_Sanpham sanpham = new BUS_Sanpham();
        BUS_Hang hang = new BUS_Hang();
        BUS_Hieu hieu = new BUS_Hieu();
        BUS_Nhaphathanh nph = new BUS_Nhaphathanh();

        private string idProduct = "";
        private string imgLoc = "";
        private byte[] image = null;
        public Form_EditProduct()
        {
            InitializeComponent();
        }
        public Form_EditProduct(string tmp)
        {
            InitializeComponent();
            idProduct = tmp;
        }
        public void Xoadulieu()
        {
           
            cmbManuf.Text = "";
            cmbManuf.DataSource = null;
            cmbManuf.Items.Clear();
            cmbManuf.SelectedIndex = -1;

            cmbBrand.Text = "";
            cmbBrand.DataSource = null;
            cmbBrand.Items.Clear();
            cmbBrand.SelectedIndex = -1;

            cmbPub.Text = "";
            cmbPub.DataSource = null;
            cmbPub.Items.Clear();
            cmbPub.SelectedIndex = -1;

            txbDiscount.Text = "";
            txbName.Text = "";
            txbPrice.Text = "";
            txbQuantity.Text = "";

            

            imgLoc = "";
            rTxbDecription.Text = "";
            
            if (picPhone.Image != null)
            {
                picPhone.Image.Dispose();
                picPhone.Image = null;
            }
        }
        public bool checkData(string tmp)
        {
            var isNumeric = int.TryParse(tmp, out int n);
            if (isNumeric == false) return false;
            else if (Int32.Parse(tmp) < 0) return false;
            else return true;
        }
        private void Form_EditProduct_Load(object sender, EventArgs e)
        {
            DataTable editProduct = new DataTable();
            editProduct = sanpham.getSanphamEdit(idProduct);
            lbIDProduct.Text = editProduct.Rows[0][0].ToString();
            cmbManuf.Text = editProduct.Rows[0][1].ToString();
            
            txbName.Text = editProduct.Rows[0][3].ToString();
            rTxbDecription.Text = editProduct.Rows[0][4].ToString();
            txbQuantity.Text = editProduct.Rows[0][5].ToString();
            txbPrice.Text= editProduct.Rows[0][6].ToString();
            txbDiscount.Text= editProduct.Rows[0][7].ToString();
            cmbPub.Text= editProduct.Rows[0][8].ToString();

            foreach (DataRow dr in hang.getHang().Rows)
            {
                cmbManuf.Items.Add(dr["Tenhang"].ToString());
            }

            cmbBrand.Text = editProduct.Rows[0][2].ToString();
            foreach (DataRow dr in hieu.getHieu(cmbManuf.Text.ToString()).Rows)
            {
                cmbBrand.Items.Add(dr["Tenhieu"].ToString());
            }

            foreach (DataRow dr in nph.getNhaphathanh().Rows)
            {
                cmbPub.Items.Add(dr["Tennhaphathanh"].ToString());
            }

             image = (byte[])(editProduct.Rows[0][9]);
            if (image == null)
            {
                picPhone.Image = null;
            }
            else
            {
                String sProfile = Convert.ToBase64String(image);

                var stream = new MemoryStream(Convert.FromBase64String(sProfile));
                picPhone.Image = Image.FromStream(stream);
            }
            this.ActiveControl = txbName;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result;

            if (cmbManuf.Text== "")
            {
                result = MessageBox.Show("Please choose manufacturer", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    this.ActiveControl = cmbManuf;
            }
            else if (cmbBrand.Text == "")
            {
                result = MessageBox.Show("Please choose brand", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    this.ActiveControl = cmbBrand;
            }
            else if (txbName.Text == "")
            {
                result = MessageBox.Show("Please enter name of product", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    this.ActiveControl = txbName;
            }
            else if (rTxbDecription.Text == "")
            {
                result = MessageBox.Show("Please enter the full product description", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    this.ActiveControl = rTxbDecription;
                }
            }

            else if (txbDiscount.Text == "")
            {
                result = MessageBox.Show("Please enter discount of product", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    this.ActiveControl = txbDiscount;
            }
            else if (txbQuantity.Text == "")
            {
                result = MessageBox.Show("Please enter quantity of product", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    this.ActiveControl = txbQuantity;

            }
            else if (txbPrice.Text == "")
            {
                result = MessageBox.Show("Please enter price of product", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    this.ActiveControl = txbPrice;

            }
            else if (cmbPub.Text =="")
            {
                result = MessageBox.Show("Please choose publisher of product", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    this.ActiveControl = cmbPub;

            }
            else if (checkData(txbDiscount.Text) == false)
            {
                result = MessageBox.Show("Please enter the correct data", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    txbDiscount.Text = "";
                    this.ActiveControl = txbDiscount;
                }

            }
            else if (checkData(txbQuantity.Text) == false)
            {
                result = MessageBox.Show("Please enter the correct data", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    txbQuantity.Text = "";
                    this.ActiveControl = txbQuantity;
                }

            }
            else if (checkData(txbPrice.Text) == false)
            {
                result = MessageBox.Show("Please enter the correct data", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    txbPrice.Text = "";
                    this.ActiveControl = txbPrice;
                }

            }
            else if (picPhone.Image == null)
            {
                result = MessageBox.Show("Please choose image of product", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    try
                    {
                        OpenFileDialog dlg = new OpenFileDialog();
                        dlg.Filter = "JPG File (*.jpg)|*.jpg|GIF File (*.gif)|*.gif|All File (*.*)|*.*";
                        dlg.Title = "Select Phone Image";
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            imgLoc = dlg.FileName.ToString();
                            picPhone.ImageLocation = imgLoc;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                   
                }
            }
           
            else if(hang.checkexitHang(cmbManuf.Text.ToString())==true)
            {
                result = MessageBox.Show("Manafacturer does not exits", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    cmbManuf.Text = "";
                    
                }
            }
            else if(hieu.checkexitTenhieu(cmbManuf.Text.ToString(), cmbBrand.Text.ToString())==true)
            {
                result = MessageBox.Show("Brand does not exits", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    cmbManuf.Text = "";

                }
            }
            else
            {
                byte[] img = null;
                //MessageBox.Show(cmbManuf.Text);
                if (imgLoc=="")
                {
                    img = image;
                }
               else
                {
                   
                    FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);
                }
                DTO_SANPHAM sp = new DTO_SANPHAM(0, Int32.Parse(hieu.getMahang(cmbManuf.Text.ToString())), Int32.Parse(hieu.getMahieu(cmbManuf.Text.ToString(), cmbBrand.Text.ToString())), txbName.Text.ToString(), rTxbDecription.Text.ToString(), Int32.Parse(txbQuantity.Text.ToString()), Int32.Parse(txbPrice.Text.ToString()), Int32.Parse(txbDiscount.Text.ToString()), cmbPub.Text.ToString(), 1, img);
                if (sanpham.updateSanpham(idProduct,sp) == true)
                {
                    result = MessageBox.Show("Edit the product succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {

                        this.Dispose();

                    }
                }
                else
                {
                    result = MessageBox.Show("Edit the product failed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Xoadulieu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbManuf_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBrand.Text = "";
            cmbBrand.DataSource = null;
            cmbBrand.Items.Clear();
            cmbBrand.SelectedIndex = -1;


            foreach (DataRow dr in hieu.getHieu(cmbManuf.GetItemText(cmbManuf.SelectedItem).ToString()).Rows)
            {
                cmbBrand.Items.Add(dr["Tenhieu"].ToString());
            }
           // cmbBrand.Text = cmbBrand.Items[0].ToString();
        }

        private void btnAddPic_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG File (*.jpg)|*.jpg|GIF File (*.gif)|*.gif|All File (*.*)|*.*";
                dlg.Title = "Select Phone Image";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    picPhone.ImageLocation = imgLoc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
