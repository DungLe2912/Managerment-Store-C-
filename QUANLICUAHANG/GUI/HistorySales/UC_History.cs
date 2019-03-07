using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using DTO;
using BUS;

namespace GUI.Customer
{
    public partial class UC_Customer : UserControl
    {
        BUS_Sanpham spham = new BUS_Sanpham();
        BUS_Donhang dhang = new BUS_Donhang();

        /*Danh cho sale*/
        int PageCountSale;
        int maxRecSale;
        int pageSizeSale = 18;
        int currentPageSale;
        int recNoSale;
        /*Danh cho lichsu*/
        int PageCountLS;
        int maxRecLS;
        int pageSizeLS = 18;
        int currentPageLS;
        int recNoLS;
        private DataTable sale = new DataTable();
        private DataTable ls = new DataTable();

        public UC_Customer()
        {
            InitializeComponent();
        }
        public void Xoadulieu_sale()
        {


            if (dtgvSal.DataSource != null)
            {
                dtgvSal.DataSource = null;
            }
            else
            {
                dtgvSal.Rows.Clear();
            }
            dtgvSal.Refresh();
            
        }
        public void Xoadulieu_ls()
        {


            if (dtgvPurchase.DataSource != null)
            {
                dtgvPurchase.DataSource = null;
            }
            else
            {
                dtgvPurchase.Rows.Clear();
            }
            dtgvPurchase.Refresh();

        }
        public void InitSetting_Sale()
        {
            maxRecSale = sale.Rows.Count;
            PageCountSale = maxRecSale / pageSizeSale;
            if ((maxRecSale % pageSizeSale) > 0)
            {
                PageCountSale += 1;
            }

            // Initial seeings
            currentPageSale = 1;
            recNoSale = 0;

        }
        public void InitSetting_ls()
        {
            maxRecLS = ls.Rows.Count;
            PageCountLS = maxRecLS / pageSizeLS;
            if ((maxRecLS % pageSizeLS) > 0)
            {
                PageCountLS += 1;
            }

            // Initial seeings
            currentPageLS = 1;
            recNoLS = 0;

        }
        public void Loaddata_Sale()
        {
            Xoadulieu_sale();
            //DataSet tmp = new DataSet();
            //tmp=tblSP.


            int i;
            int startRec;
            int endRec;
            DataTable dtTemp;

            //Clone the source table to create a temporary table.
            dtTemp = sale.Clone();
            if (sale.Rows.Count != 0)
            {
                if (currentPageSale == PageCountSale)
                {
                    endRec = maxRecSale;
                }
                else
                {
                    endRec = pageSizeSale * currentPageSale;
                }
                startRec = recNoSale;

                //Copy rows from the source table to fill the temporary table.
                for (i = startRec; i < endRec; i++)
                {
                    dtTemp.ImportRow(sale.Rows[i]);
                    recNoSale += 1;
                }

            }


            BindingSource SBind = new BindingSource();
            dtgvSal.Columns.Clear();
            SBind.DataSource = dtTemp;
            dtgvSal.DataSource = SBind;
            
            dtgvSal.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvSal.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgvSal.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgvSal.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgvSal.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //datagrid has calculated it's widths so we can store them
            for (i = 0; i <= dtgvSal.Columns.Count - 1; i++)
            {
                //store autosized widths
                int colw = dtgvSal.Columns[i].Width;
                //remove autosizing
                dtgvSal.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //set width to calculated by autosize
                dtgvSal.Columns[i].Width = colw;
            }

            dtgvSal.Columns[0].HeaderText = "ID Order";
            dtgvSal.Columns[1].HeaderText = "Customer";
            dtgvSal.Columns[2].HeaderText = "Order Day";
            dtgvSal.Columns[3].HeaderText = "Delivery Day";
            dtgvSal.Columns[4].HeaderText = "Payments";

        }
        public void Loaddata_LS()
        {
            Xoadulieu_ls();
            //DataSet tmp = new DataSet();
            //tmp=tblSP.


            int i;
            int startRec;
            int endRec;
            DataTable dtTemp;

            //Clone the source table to create a temporary table.
            dtTemp = ls.Clone();
            if (ls.Rows.Count != 0)
            {
                if (currentPageLS == PageCountLS)
                {
                    endRec = maxRecLS;
                }
                else
                {
                    endRec = pageSizeLS * currentPageLS;
                }
                startRec = recNoLS;

                //Copy rows from the source table to fill the temporary table.
                for (i = startRec; i < endRec; i++)
                {
                    dtTemp.ImportRow(ls.Rows[i]);
                    recNoLS += 1;
                }

            }


            BindingSource SBind = new BindingSource();
            dtgvPurchase.Columns.Clear();
            SBind.DataSource = dtTemp;
            dtgvPurchase.DataSource = SBind;
           
           dtgvPurchase.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvPurchase.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvPurchase.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgvPurchase.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgvPurchase.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgvPurchase.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //datagrid has calculated it's widths so we can store them
            for (i = 0; i <= dtgvPurchase.Columns.Count - 1; i++)
            {
                //store autosized widths
                int colw = dtgvPurchase.Columns[i].Width;
                //remove autosizing
                dtgvPurchase.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //set width to calculated by autosize
                dtgvPurchase.Columns[i].Width = colw;
            }

            dtgvPurchase.Columns[0].HeaderText = "ID Purchase";
            dtgvPurchase.Columns[1].HeaderText = "ID Product";
            dtgvPurchase.Columns[2].HeaderText = "Quantity";
            dtgvPurchase.Columns[3].HeaderText = "Price";
            dtgvPurchase.Columns[4].HeaderText = "Day Purchase";
            dtgvPurchase.Columns[5].HeaderText = "Type Purchase";

        }
        public void changeColor()
        {
            foreach(DataGridViewRow row in dtgvSal.Rows)
            {
                DateTime pay = DateTime.Parse(row.Cells[3].Value.ToString());
                if(Int32.Parse(row.Cells[4].Value.ToString()) == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.YellowGreen;
                }
                else
                {
                    if(pay<DateTime.Now)
                        row.DefaultCellStyle.BackColor = Color.YellowGreen;
                    else
                        row.DefaultCellStyle.BackColor = Color.DarkRed;
                }
            }
        }
        private void UC_Customer_Load(object sender, EventArgs e)
        {
            Xoadulieu_sale();
            Xoadulieu_ls();
            sale = dhang.getDHOrderByNgay();
            ls = spham.getLSOrderByNgaynhap();
            InitSetting_Sale();
            InitSetting_ls();
            Loaddata_LS();
            Loaddata_Sale();
           // changeColor();
        }


        
        private void dtgvPurchase_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dtgvSal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dtgvSal.SelectedRows)
            {
                string id = row.Cells[0].Value.ToString();
                using (HistorySales.Form_DetailSale detail = new HistorySales.Form_DetailSale(id))
                {
                    detail.ShowDialog();
                   
                }

                //...
            }
        }

        private void dtgvSal_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            changeColor();
        }

        private void btnPreSale_Click(object sender, EventArgs e)
        {
            if (currentPageSale == 1)
                return;
            if (currentPageSale == PageCountSale)
            {
                recNoSale = pageSizeSale * (currentPageSale - 2);
            }

            currentPageSale -= 1;
            //Check if you are already at the first page.
            if (currentPageSale < 1)
            {
                // MessageBox.Show("You are at the First Page!");
                currentPageSale = 1;
                return;
            }
            else
            {
                recNoSale = pageSizeSale * (currentPageSale - 1);
            }
            Loaddata_Sale();
        }

        private void btnNextSale_Click(object sender, EventArgs e)
        {
            if (PageCountSale == 1)
                return;
            currentPageSale += 1;
            if (currentPageSale > PageCountSale)
            {
                currentPageSale = PageCountSale;
                return;
                //Check if you are already at the last page.

            }
            Loaddata_Sale();
        }

        private void btnPrePur_Click(object sender, EventArgs e)
        {
            if (currentPageLS == 1)
                return;
            if (currentPageLS == PageCountLS)
            {
                recNoLS = pageSizeLS * (currentPageLS - 2);
            }

            currentPageLS -= 1;
            //Check if you are already at the first page.
            if (currentPageLS < 1)
            {
                // MessageBox.Show("You are at the First Page!");
                currentPageLS = 1;
                return;
            }
            else
            {
                recNoLS = pageSizeLS * (currentPageLS - 1);
            }
            Loaddata_LS();
        }

        private void btnNextPur_Click(object sender, EventArgs e)
        {
            if (PageCountLS == 1)
                return;
            currentPageLS += 1;
            if (currentPageLS > PageCountLS)
            {
                currentPageLS = PageCountLS;
                return;
                //Check if you are already at the last page.

            }
            Loaddata_LS();
        }
    }
}
