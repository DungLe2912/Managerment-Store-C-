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
    public partial class Form_Detail : Form
    {
        BUS_Sanpham sanpham = new BUS_Sanpham();
        private string idSanpham;
        public Form_Detail()
        {
            InitializeComponent();
        }

        public Form_Detail(string tmp)
        {
            InitializeComponent();
            this.idSanpham = tmp;
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {

            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            Image img = (Image)converter.ConvertFrom(byteArrayIn);

            return img;
        }
        private void Form_Detail_Load(object sender, EventArgs e)
        {
            DataTable tmp = new DataTable();
            tmp = sanpham.getDetailProduct(idSanpham);
            rTxbDecription.Text = tmp.Rows[0][0].ToString();
            txbDiscount.Text = tmp.Rows[0][1].ToString()+" %";
            txbPub.Text = tmp.Rows[0][2].ToString();
            var img = (byte[])(tmp.Rows[0][3]);
            if (img == null)
            {
                picPhone.Image = null;
            }
            else
            {
                String sProfile = Convert.ToBase64String(img);

                var stream = new MemoryStream(Convert.FromBase64String(sProfile));
                picPhone.Image = Image.FromStream(stream);
            }

        }
        public void LoadData()
        {
           
            DataTable tmp = new DataTable();
            tmp = sanpham.getDetailProduct(idSanpham);
            rTxbDecription.Text = tmp.Rows[0][0].ToString();
            txbDiscount.Text = tmp.Rows[0][1].ToString() + " %";
            txbPub.Text = tmp.Rows[0][2].ToString();
            var img = (byte[])(tmp.Rows[0][3]);
            if (img == null)
            {
                picPhone.Image = null;
            }
            else
            {
                String sProfile = Convert.ToBase64String(img);

                var stream = new MemoryStream(Convert.FromBase64String(sProfile));
                picPhone.Image = Image.FromStream(stream);
            }

        }
        /// <summary>
        /// click button Edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (PhoneDetail.Form_EditProduct edit=new PhoneDetail.Form_EditProduct(idSanpham))
            {
                edit.ShowDialog();
                if (edit.IsDisposed)
                {
                    LoadData();
                    this.Show();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            DialogResult res;
            res = MessageBox.Show("Do you wanna delete this product?", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                
                if (sanpham.xoaSanpham(idSanpham) == true)
                {
                    res = MessageBox.Show("Delete the product succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (res == DialogResult.OK)
                    {

                        this.Dispose();

                    }
                }
                else
                {
                    res = MessageBox.Show("Delete the product failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }
    }
}
