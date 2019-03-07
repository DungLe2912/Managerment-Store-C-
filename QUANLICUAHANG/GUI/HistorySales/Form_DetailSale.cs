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

namespace GUI.HistorySales
{
    public partial class Form_DetailSale : Form
    {
        private string iddonhang = "";
        int PageCountSale;
        int maxRecSale;
        int pageSizeSale = 4;
        int currentPageSale;
        int recNoSale;
        BUS_Donhang dhang = new BUS_Donhang();
        BUS_Chitiet ctiet = new BUS_Chitiet();
        private DataTable order = new DataTable();
        private DataTable sale = new DataTable();
        public Form_DetailSale()
        {
            InitializeComponent();
        }
        public Form_DetailSale(string id)
        {
            InitializeComponent();
            iddonhang = id;
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
        public void Xoadulieu_dh()
        {


            if (dtgvOrder.DataSource != null)
            {
                dtgvOrder.DataSource = null;
            }
            else
            {
                dtgvOrder.Rows.Clear();
            }
            dtgvOrder.Refresh();

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

            dtgvSal.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgvSal.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvSal.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvSal.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgvSal.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvSal.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgvSal.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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

            dtgvSal.Columns[0].HeaderText = "ID Detail";
            dtgvSal.Columns[1].HeaderText = "ID Order";
            dtgvSal.Columns[2].HeaderText = "Manufacturer";
            dtgvSal.Columns[3].HeaderText = "Band";
            dtgvSal.Columns[4].HeaderText = "Product";
            dtgvSal.Columns[5].HeaderText = "Quantity";
            dtgvSal.Columns[6].HeaderText = "Price";

        }
        public void LoadDataOrder()
        {
            BindingSource SBind = new BindingSource();
            dtgvOrder.Columns.Clear();
            SBind.DataSource = order;
            dtgvOrder.DataSource = SBind;

            dtgvOrder.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgvOrder.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvOrder.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgvOrder.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgvOrder.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgvOrder.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
            //datagrid has calculated it's widths so we can store them
            for (int i = 0; i <= dtgvOrder.Columns.Count - 1; i++)
            {
                //store autosized widths
                int colw = dtgvOrder.Columns[i].Width;
                //remove autosizing
                dtgvOrder.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //set width to calculated by autosize
                dtgvOrder.Columns[i].Width = colw;
            }

            dtgvOrder.Columns[0].HeaderText = "ID Order";
            dtgvOrder.Columns[1].HeaderText = "Phone number";
            dtgvOrder.Columns[2].HeaderText = "Delivery address";
            dtgvOrder.Columns[3].HeaderText = "Total amount";
            dtgvOrder.Columns[4].HeaderText = "Paid amount";
            dtgvOrder.Columns[5].HeaderText = "Discount code";
            

        }
        private void Form_DetailSale_Load(object sender, EventArgs e)
        {
            Xoadulieu_sale();
            Xoadulieu_dh();
            sale = ctiet.getDetail(iddonhang);
            order = dhang.getDHDetail(iddonhang);
            InitSetting_Sale();
            Loaddata_Sale();
            LoadDataOrder();
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

       
    }
}
