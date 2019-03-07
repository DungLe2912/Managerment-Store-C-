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
    public partial class Form_AddnewPhone : Form
    {
        private string imgLoc = "";
        private string decription = "";
        BUS_Hang hang = new BUS_Hang();
        BUS_Hieu hieu = new BUS_Hieu();
        BUS_Nhaphathanh nph = new BUS_Nhaphathanh();
        BUS_Sanpham sanpham = new BUS_Sanpham();
        BUS_Lichsunhap lichsu = new BUS_Lichsunhap();
        
        public Form_AddnewPhone()
        {
            InitializeComponent();
        }
        public void Xoadulieu()
        {
            decription = "";
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

            dtpkPurchase.Refresh();

            imgLoc = "";
            decription = "";
            checkInfor.Checked = false;
            if (picPhone.Image != null)
            {
                picPhone.Image.Dispose();
                picPhone.Image = null;
            }
        }
        private void Form_AddnewPhone_Load(object sender, EventArgs e)
        {
            Xoadulieu();
            cmbBrand.Enabled = false;
            txbName.Enabled = false;
            dtpkPurchase.Enabled = false;
            cmbPub.Enabled = false;
            txbDiscount.Enabled = false;
            txbPrice.Enabled = false;
            txbQuantity.Enabled = false;
            btnAddBr.Enabled = false;
            btnAddinfor.Enabled = false;
            btnAddPic.Enabled = false;
            btnAddPub.Enabled = false;
            foreach(DataRow dr in hang.getHang().Rows)
            {
                cmbManuf.Items.Add(dr["Tenhang"].ToString());
            }
            checkInfor.Checked = false;
            
        }
        public void LoadAgain()
        {
            Xoadulieu();
            cmbBrand.Enabled = false;
            txbName.Enabled = false;
            dtpkPurchase.Enabled = false;
            cmbPub.Enabled = false;
            txbDiscount.Enabled = false;
            txbPrice.Enabled = false;
            txbQuantity.Enabled = false;
            btnAddBr.Enabled = false;
            btnAddinfor.Enabled = false;
            btnAddPic.Enabled = false;
            btnAddPub.Enabled = false;
            
            foreach (DataRow dr in hang.getHang().Rows)
            {
                cmbManuf.Items.Add(dr["Tenhang"].ToString());
            }
            checkInfor.Checked = false;

        }
        public bool checkData(string tmp)
        {
            var isNumeric = int.TryParse(tmp, out int n);
            if (isNumeric == false) return false;
            else if (Int32.Parse(tmp) < 0) return false;
            else return true;
        }
        private void btnAddMa_Click(object sender, EventArgs e)
        {
            using (PhoneDetail.Form_AddManufacturer manu=new PhoneDetail.Form_AddManufacturer())
            {
                manu.ShowDialog();
                if(manu.IsDisposed)
                {
                    cmbManuf.DataSource = null;
                    cmbManuf.Items.Clear();
                    cmbManuf.SelectedIndex = -1;
                    foreach (DataRow dr in hang.getHang().Rows)
                    {
                        cmbManuf.Items.Add(dr["Tenhang"].ToString());
                    }
                }
            }
        }

        private void btnAddBr_Click(object sender, EventArgs e)
        {
            using (PhoneDetail.Form_AddBrand brand = new PhoneDetail.Form_AddBrand(cmbManuf.GetItemText(cmbManuf.SelectedItem).ToString()))
            {
                brand.ShowDialog();
                if (brand.IsDisposed)
                {
                    cmbBrand.DataSource = null;
                    cmbBrand.Items.Clear();
                    cmbBrand.SelectedIndex = -1;
                    foreach (DataRow dr in hieu.getHieu(cmbManuf.GetItemText(cmbManuf.SelectedItem).ToString()).Rows)
                    {
                        cmbBrand.Items.Add(dr["Tenhieu"].ToString());
                    }
                }
            }
        }

        /// <summary>
        /// click button cancel to close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// click button Clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Xoadulieu();
        }

        
        private void btnAddPub_Click(object sender, EventArgs e)
        {
            using (PhoneDetail.Form_AddPublisher pub = new PhoneDetail.Form_AddPublisher())
            {
                pub.ShowDialog();
                if (pub.IsDisposed)
                {
                    cmbPub.DataSource = null;
                    cmbPub.Items.Clear();
                    cmbPub.SelectedIndex = -1;
                    foreach (DataRow dr in nph.getNhaphathanh().Rows)
                    {
                        cmbPub.Items.Add(dr["Tennhaphathanh"].ToString());
                    }
                }
            }
            if (decription != "")
                checkInfor.Checked = true;
            else checkInfor.Checked = false;

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
            if (decription != "")
                checkInfor.Checked = true;
            else checkInfor.Checked = false;
        }

        private void btnAddinfor_Click(object sender, EventArgs e)
        {
            using (PhoneDetail.Form_AddInformation infor = new PhoneDetail.Form_AddInformation())
            {
                infor.Handler += data => decription = data;
                infor.ShowDialog();
                if(infor.IsDisposed)
                {
                    if (decription != "")
                        checkInfor.Checked = true;
                    else checkInfor.Checked = false;
                }
            }
            if (decription != "")
                checkInfor.Checked = true;
            else checkInfor.Checked = false;

        }

        private void cmbManuf_SelectedIndexChanged(object sender, EventArgs e)
        {
            decription = "";
            cmbBrand.Text = "";
            cmbBrand.DataSource = null;
            cmbBrand.Items.Clear();
            cmbBrand.SelectedIndex = -1;
            cmbBrand.Refresh();
            cmbBrand.Enabled = true;
            btnAddBr.Enabled = true;
            foreach (DataRow dr in hieu.getHieu(cmbManuf.GetItemText(cmbManuf.SelectedItem).ToString()).Rows)
            {
                cmbBrand.Items.Add(dr["Tenhieu"].ToString());
            }
            if (decription != "")
                checkInfor.Checked = true;
            else checkInfor.Checked = false;
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            decription = "";
            txbName.Text = "";
            txbName.Enabled = true;
            if (decription != "")
                checkInfor.Checked = true;
            else checkInfor.Checked = false;
        }

        private void txbName_TextChanged(object sender, EventArgs e)
        {
            cmbPub.Text = "";
            cmbPub.DataSource = null;
            cmbPub.Items.Clear();
            cmbPub.SelectedIndex = -1;
            cmbPub.Refresh();
            dtpkPurchase.Enabled = true;
            cmbPub.Enabled = true;
            btnAddPub.Enabled = true;
            btnAddinfor.Enabled = true;
            btnAddPic.Enabled = true;
            foreach (DataRow dr in nph.getNhaphathanh().Rows)
            {
                cmbPub.Items.Add(dr["Tennhaphathanh"].ToString());
            }
            if (decription != "")
                checkInfor.Checked = true;
        }

        private void cmbPub_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbDiscount.Enabled = true;
        }

        private void txbDiscount_TextChanged(object sender, EventArgs e)
        {
            txbQuantity.Enabled = true;
        }

        private void txbQuantity_TextChanged(object sender, EventArgs e)
        {
            txbPrice.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result;
            
            if(cmbManuf.GetItemText(cmbManuf.SelectedItem)=="")
            {
                result = MessageBox.Show("Please choose manufacturer", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    this.ActiveControl = cmbManuf;
            }
            else if(cmbBrand.GetItemText(cmbBrand.SelectedItem) == "")
            {
                result = MessageBox.Show("Please choose brand", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    this.ActiveControl = cmbBrand;
            }
            else if(txbName.Text=="")
            {
                result = MessageBox.Show("Please enter name of product", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    this.ActiveControl = txbName;
            }
            else if (decription == "")
            {
                result = MessageBox.Show("Please enter the full product description", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    using (PhoneDetail.Form_AddInformation infor = new PhoneDetail.Form_AddInformation())
                    {
                        infor.Handler += data => decription = data;
                        infor.ShowDialog();
                        if (infor.IsDisposed)
                        {
                            if (decription != "")
                                checkInfor.Checked = true;
                            else checkInfor.Checked = false;
                        }
                    }
                }
            }

            else if (txbDiscount.Text=="")
            {
                result = MessageBox.Show("Please enter discount of product", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    this.ActiveControl = txbDiscount;
            }
            else if(txbQuantity.Text=="")
            {
                result = MessageBox.Show("Please enter quantity of product", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    this.ActiveControl = txbQuantity;

            }
            else if(txbPrice.Text=="")
            {
                result = MessageBox.Show("Please enter price of product", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    this.ActiveControl = txbPrice;

            }
            else if(cmbPub.GetItemText(cmbPub.SelectedItem) == "")
            {
                result = MessageBox.Show("Please choose publisher of product", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    this.ActiveControl = cmbPub;

            }
            else if(checkData(txbDiscount.Text)==false)
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
            else if(imgLoc=="")
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
                    if (decription != "")
                        checkInfor.Checked = true;
                    else checkInfor.Checked = false;
                }
            }
            else if(sanpham.checkexitProduct(txbName.Text.ToString(),cmbManuf.GetItemText(cmbManuf.SelectedItem), cmbBrand.GetItemText(cmbBrand.SelectedItem)) ==true)
            {
                result = MessageBox.Show("Product already exits", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    txbName.Text = "";
                    this.ActiveControl = txbName;
                }
            }
            else if (hang.checkexitHang(cmbManuf.Text.ToString()) == true)
            {
                result = MessageBox.Show("Manafacturer does not exits", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    cmbManuf.Text = "";

                }
            }
            else if (hieu.checkexitTenhieu(cmbManuf.Text.ToString(), cmbBrand.Text.ToString()) == true)
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
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                DTO_SANPHAM sp = new DTO_SANPHAM(0,Int32.Parse(hieu.getMahang(cmbManuf.GetItemText(cmbManuf.SelectedItem))),Int32.Parse(hieu.getMahieu(cmbManuf.GetItemText(cmbManuf.SelectedItem), cmbBrand.GetItemText(cmbBrand.SelectedItem))),txbName.Text.ToString(),decription,Int32.Parse(txbQuantity.Text.ToString()), Int32.Parse(txbPrice.Text.ToString()), Int32.Parse(txbDiscount.Text.ToString()), cmbPub.GetItemText(cmbPub.SelectedItem).ToString(),1,img);
                if (sanpham.themSanpham(sp) == true)
                {
                    result = MessageBox.Show("Adding the product succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        DTO_LICHSUNHAPHANG ls = new DTO_LICHSUNHAPHANG(0, Int32.Parse(sanpham.getMaxid()), Int32.Parse(txbQuantity.Text.ToString()), Int32.Parse(txbPrice.Text.ToString()), DateTime.Parse(dtpkPurchase.Value.ToShortDateString()), 1);
                        if(lichsu.themLichsu(ls)==false)
                            result = MessageBox.Show("Failed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        LoadAgain();


                    }
                }
                else
                {
                    result = MessageBox.Show("Adding the product  failed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
        }
    }
}
