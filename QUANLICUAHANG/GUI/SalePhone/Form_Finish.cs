using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using DTO;
using BUS;

namespace GUI.SalePhone
{
    public partial class Form_Finish : Form
    {
        private string total = "";
        private ListView lsdetail = new ListView();
        BUS_BF bf = new BUS_BF();
        BUS_Khuyenmai khuyenmai = new BUS_Khuyenmai();
        BUS_Donhang dhang = new BUS_Donhang();
        BUS_Chitiet ctiet = new BUS_Chitiet();
        BUS_Sanpham spham = new BUS_Sanpham();
        BUS_Khuyenmai kmai = new BUS_Khuyenmai();
        public Form_Finish()
        {
            InitializeComponent();
        }
        public Form_Finish(string tmp,ListView lsvtmp)
        {
            InitializeComponent();
            total = tmp;
            lsdetail.Items.AddRange((from ListViewItem item in lsvtmp.Items select (ListViewItem)item.Clone()).ToArray());
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public bool checkData(string tmp)
        {
            var isNumeric = int.TryParse(tmp, out int n);
            if (isNumeric == false) return false;
            else if (Int32.Parse(tmp) < 0) return false;
            else return true;
        }
        private void Form_Finish_Load(object sender, EventArgs e)
        {
            this.ActiveControl = cTxbNameCus;
            cTxbPhone.Text = "";
            cTxbNameCus.Text = "";
            cTxbAddr.Text = "";
            cTxbCode.Text = "";
            checkPre.Checked = false;
            checkDel.Checked = false;
            txbTotal.Text = total;
            txbPaid.Text = "";

            cTxbPhone.Enabled = false;
            cTxbAddr.Enabled = false; ;
            cTxbCode.Enabled = false ;
            checkPre.Enabled = false;
            checkDel.Enabled = false;
            dtpkDilivery.Enabled = false;
            lblNotice.Text = "";
        }

        private void txbAddr_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(cTxbNameCus.Text=="")
            {
               
                this.ActiveControl = cTxbNameCus;
                lblNotice.Text = "Please enter name of customer";
            }
            else if(cTxbPhone.Text=="")
            {
                
                this.ActiveControl = cTxbPhone;
                lblNotice.Text = "Please enter num-phone of customer";
            }
            else if(checkData(cTxbPhone.Text)==false)
            {
                cTxbPhone.Text = "";
                this.ActiveControl = cTxbPhone;
                lblNotice.Text = "Incorrect data";

            }
            else if(cTxbAddr.Text=="")
            {
               
                this.ActiveControl = cTxbAddr;
                lblNotice.Text = "Please enter delivery address";
            }
            else if(checkDel.Checked==false && checkPre.Checked==false)
            {
                this.ActiveControl = checkPre;
                lblNotice.Text = "Please choose payments";
            }
            else if((khuyenmai.checkexitCode(cTxbCode.Text.ToString())) == true&&cTxbCode.Text!="")
            {
                this.ActiveControl = cTxbCode;
                lblNotice.Text = "Code is incorrect";
            }
            else if ((khuyenmai.checkexitCodetoSale(cTxbCode.Text.ToString(),DateTime.Now.ToShortDateString())) == true && cTxbCode.Text != "")
            {
                this.ActiveControl = cTxbCode;
                lblNotice.Text = "Code is expired";
            }
            else
            {
                int payments=0;
                float ttamount = float.Parse(total, CultureInfo.InvariantCulture.NumberFormat)*2;
                float paid = ttamount;
                float discount = 0;
               
                if (checkDel.Checked == true)
                    payments = 1;
                if (checkPre.Checked == true)
                    payments = 0;
                if(cTxbCode.Text!="")
                {
                   discount+= float.Parse(khuyenmai.getDiscount(cTxbCode.Text.ToString()), CultureInfo.InvariantCulture.NumberFormat);
                   if(kmai.delCode(Int32.Parse(kmai.getIDFromCode(cTxbCode.Text.ToString())))==false)
                    {
                        MessageBox.Show("Updating code discount failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if(bf.checkexitDate(DateTime.Now.ToShortDateString())==false)
                {
                    discount += float.Parse(bf.getDiscountFromDate(DateTime.Now.ToShortDateString()), CultureInfo.InvariantCulture.NumberFormat);
                   
                }
                paid = paid * (float)(1 - (discount / 100));
                txbPaid.Text = paid.ToString();
                DTO_DONHANG donhang = new DTO_DONHANG(0, cTxbNameCus.Text.ToString(), cTxbPhone.Text.ToString(), cTxbAddr.Text.ToString(), DateTime.Parse(DateTime.Now.ToShortDateString()), DateTime.Parse(dtpkDilivery.Value.ToShortDateString()), ttamount, paid, payments, cTxbCode.Text.ToString());
                DialogResult result;
                if (dhang.themDonhang(donhang)==true)
                {
                    result = MessageBox.Show("Adding orders succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if(result==DialogResult.OK)
                    {
                        int madonhang = Int32.Parse(dhang.getMaxid());
                        foreach (ListViewItem item in lsdetail.Items)
                        {
                            int soluong = Int32.Parse(item.SubItems[1].Text);
                            float dongia = float.Parse(item.SubItems[2].Text, CultureInfo.InvariantCulture.NumberFormat);
                            DataTable spSale = new DataTable();
                            spSale = spham.getSanphamtoSale(item.SubItems[3].Text);
                            int mahang = Int32.Parse(spSale.Rows[0][0].ToString());
                            int mahieu = Int32.Parse(spSale.Rows[0][1].ToString());
                            int masanpham = Int32.Parse(spSale.Rows[0][2].ToString());
                            DTO_CHITIETDONHANG chitietdonhang = new DTO_CHITIETDONHANG(0,madonhang,mahang,mahieu,masanpham,soluong,dongia);
                            if(ctiet.themChitiet(chitietdonhang)==false)
                            {
                                result = MessageBox.Show("Adding detail orders failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            int soluongconlai = Int32.Parse(spham.getSoluong(item.SubItems[3].Text))-soluong;
                            if(spham.UpdateQtySale(item.SubItems[3].Text,soluongconlai)==false)
                            {
                                result = MessageBox.Show("Updating quantiy product failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                        this.Dispose();
                    }
                }
            }
        }

        private void checkPre_CheckedChanged(object sender, EventArgs e)
        {
            checkDel.Checked = false;
            cTxbCode.Enabled = true;
        }

        private void checkDel_CheckedChanged(object sender, EventArgs e)
        {
            checkPre.Checked = false;
            cTxbCode.Enabled = true;
        }

        private void cTxbNameCus_TextChanged(object sender, EventArgs e)
        {
            cTxbPhone.Enabled = true;
        }

        private void cTxbPhone_TextChanged(object sender, EventArgs e)
        {
            cTxbAddr.Enabled = true;
        }

        private void cTxbAddr_TextChanged(object sender, EventArgs e)
        {
            dtpkDilivery.Enabled = true;
            checkDel.Enabled = true;
            checkPre.Enabled = true;
        }

        private void cTxbCode_TextChanged(object sender, EventArgs e)
        {
            txbTotal.Text = total;
        }
    }
}
