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
    public partial class Form_AddStoke : Form
    {
        BUS_Sanpham sanpham = new BUS_Sanpham();
        BUS_Lichsunhap lichsu = new BUS_Lichsunhap();
        private string idProduct;
        public Form_AddStoke()
        {
            InitializeComponent();
        }
        public Form_AddStoke(string tmp)
        {
            InitializeComponent();
            idProduct = tmp;
        }
        public void Xoadulieu()
        {
            txbPrice.Text = "";
            txbQuantity.Text = "";
           
        }
        private void Form_AddStoke_Load(object sender, EventArgs e)
        {
            Xoadulieu();
            picPhone.Image = null;
            lbIDProduct.Text = "";

            DataTable editProduct = new DataTable();
            editProduct = sanpham.getDetailProduct(idProduct);
            lbIDProduct.Text = idProduct;

            var image = (byte[])(editProduct.Rows[0][3]);
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

        }
        public bool checkData(string tmp)
        {
            var isNumeric = int.TryParse(tmp, out int n);
            if (isNumeric == false) return false;
            else if (Int32.Parse(tmp) < 0) return false;
            else return true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result;
            if(checkData(txbQuantity.Text.ToString())==false)
            {
                result = MessageBox.Show("Please enter number", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    txbQuantity.Text = "";
                    this.ActiveControl = txbQuantity;
                }
            }
            else if(checkData(txbPrice.Text.ToString())==false)
            {
                result = MessageBox.Show("Please enter number", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    txbPrice.Text = "";
                    this.ActiveControl = txbPrice;
                }
            }
            else
            {
                int quantity = Int32.Parse(sanpham.getSoluong(idProduct)) + Int32.Parse(txbQuantity.Text.ToString());

                if (sanpham.muathemsanpham(idProduct, quantity, Int32.Parse(txbPrice.Text.ToString())))
                {
                    result = MessageBox.Show("Adding quantity of product succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {

                        DTO_LICHSUNHAPHANG ls = new DTO_LICHSUNHAPHANG(0, Int32.Parse(idProduct), Int32.Parse(txbQuantity.Text.ToString()), Int32.Parse(txbPrice.Text.ToString()), DateTime.Parse(dtpkPurchase.Value.ToShortDateString()), 0);
                        if (lichsu.themLichsu(ls) == false)
                            MessageBox.Show("Failed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        Xoadulieu();


                    }

                }
                else
                    result = MessageBox.Show("Adding quantity of product failed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
