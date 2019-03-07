using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagedList;
using System.Data.SqlClient;
using System.IO;
using DTO;
using BUS;
namespace GUI.PhoneDetail
{
    public partial class UC_PhoneDetail : UserControl
    {
        int PageCount;
        int maxRec;
        int pageSize = 15;
        int currentPage;
        int recNo;

        BUS_Sanpham sanpham = new BUS_Sanpham();
        private DataTable tblSP = new DataTable();
       
        public UC_PhoneDetail()
        {
            InitializeComponent();
        }

        private void btnAddPhone_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// click button previous
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (currentPage == 1)
                return;
            if (currentPage == PageCount)
            {
                recNo = pageSize * (currentPage - 2);
            }

            currentPage -= 1;
            //Check if you are already at the first page.
            if (currentPage < 1)
            {
               // MessageBox.Show("You are at the First Page!");
                currentPage = 1;
                return;
            }
            else
            {
                recNo = pageSize * (currentPage - 1);
            }
            Loaddata();
        }

        /// <summary>
        /// click button next
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (PageCount == 1)
                return;
            currentPage += 1;
            if (currentPage > PageCount)
            {
                currentPage = PageCount;
                return;
                //Check if you are already at the last page.

            }
            Loaddata();
        }

        private void btnAddPhone_Click_1(object sender, EventArgs e)
        {
            using (PhoneDetail.Form_AddnewPhone addphone = new PhoneDetail.Form_AddnewPhone())
            {
                addphone.ShowDialog();
                if(addphone.IsDisposed)
                {
                    Xoadulieu();
                    tblSP = sanpham.getSanpham();
                    InitSetting();
                    Loaddata();
                }
            }
        }

        public void Xoadulieu()
        {
            cmbSearch.Text = "";
            cmbSearch.DataSource = null;
            cmbSearch.Items.Clear();
            cmbSearch.SelectedIndex = -1;

            ctxbSearch.Text = "";

            if (dtgvDetailPhone.DataSource != null)
            {
                dtgvDetailPhone.DataSource = null;
            }
            else
            {
                dtgvDetailPhone.Rows.Clear();
            }
            dtgvDetailPhone.Refresh();
        }
        public void InitSetting()
        {
            maxRec = tblSP.Rows.Count;
            PageCount = maxRec / pageSize;
            if ((maxRec % pageSize) > 0)
            {
                PageCount += 1;
            }

            // Initial seeings
            currentPage = 1;
            recNo = 0;

        }
        public void Loaddata()
        {
            Xoadulieu();
            cmbSearch.Items.Add("Manufacturer");
            cmbSearch.Items.Add("Brand");
            cmbSearch.Items.Add("Purchase date");
            cmbSearch.Items.Add("Price");
            cmbSearch.Items.Add("Quantity");

           
            //DataSet tmp = new DataSet();
            //tmp=tblSP.
            
            
            int i;
            int startRec;
            int endRec;
            DataTable dtTemp;
            dtTemp = tblSP.Clone();
            if (tblSP.Rows.Count != 0)
            {
                //Clone the source table to create a temporary table.

                

                if (currentPage == PageCount)
                {
                    endRec = maxRec;
                }
                else
                {
                    endRec = pageSize * currentPage;
                }
                startRec = recNo;

                //Copy rows from the source table to fill the temporary table.
                for (i = startRec; i < endRec; i++)
                {
                    dtTemp.ImportRow(tblSP.Rows[i]);
                    recNo += 1;
                }


            }

            BindingSource SBind = new BindingSource();
            dtgvDetailPhone.Columns.Clear();
            SBind.DataSource = dtTemp;
            dtgvDetailPhone.DataSource = SBind;

            //set autosize mode
            dtgvDetailPhone.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDetailPhone.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDetailPhone.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //datagrid has calculated it's widths so we can store them
            for (i = 0; i <= dtgvDetailPhone.Columns.Count - 1; i++)
            {
                //store autosized widths
                int colw = dtgvDetailPhone.Columns[i].Width;
                //remove autosizing
                dtgvDetailPhone.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //set width to calculated by autosize
                dtgvDetailPhone.Columns[i].Width = colw;
            }


            dtgvDetailPhone.Columns[0].HeaderText = "IDPhone";
            dtgvDetailPhone.Columns[1].HeaderText = "Name";
            dtgvDetailPhone.Columns[2].HeaderText = "Brand";
            dtgvDetailPhone.Columns[3].HeaderText = "Manufacturer";
            dtgvDetailPhone.Columns[4].HeaderText = "Date of Purchase";
            dtgvDetailPhone.Columns[5].HeaderText = "Quantity";
            dtgvDetailPhone.Columns[6].HeaderText = "Price";





        }
        private void UC_PhoneDetail_Load(object sender, EventArgs e)
        {
            Xoadulieu();
            tblSP = sanpham.getSanpham();
           
            InitSetting();
            Loaddata();
            
            

        }

        private void dtgvDetailPhone_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //dtgvDetailPhone.Rows[0].Selected = false;
            //if (e.StateChanged != DataGridViewElementStates.Selected) return;
            //foreach (DataGridViewRow row in dtgvDetailPhone.SelectedRows)
            //{
            //    string id = row.Cells[0].Value.ToString();
            //    using (PhoneDetail.Form_Detail detail = new PhoneDetail.Form_Detail(id))
            //    {
            //        detail.ShowDialog();
            //    }
            //    //...
            //}
          //  dtgvDetailPhone.Rows[0].Selected = true;
        }

        private void dtgvDetailPhone_SelectionChanged(object sender, EventArgs e)
        {
           // dtgvDetailPhone.Rows[0].Selected = false;
            //foreach (DataGridViewRow row in dtgvDetailPhone.SelectedRows)
            //{
            //    string id = row.Cells[0].Value.ToString();
            //    using (PhoneDetail.Form_Detail detail = new PhoneDetail.Form_Detail(id))
            //    {
            //        detail.ShowDialog();
            //    }
            //    //...
            //}
        }

        private void dtgvDetailPhone_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dtgvDetailPhone.SelectedRows)
            {
                string id = row.Cells[0].Value.ToString();
                using (PhoneDetail.Form_Detail detail = new PhoneDetail.Form_Detail(id))
                {
                    detail.ShowDialog();
                    if (detail.IsDisposed)
                    {
                        tblSP = sanpham.getSanpham();

                        InitSetting();

                        Loaddata();
                    }
                }

                //...
            }
        }

        private void btnAddStoke_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dtgvDetailPhone.SelectedRows)
            {
                string id = row.Cells[0].Value.ToString();
                using (PhoneDetail.Form_AddStoke stoke = new PhoneDetail.Form_AddStoke(id))
                {
                    stoke.ShowDialog();
                    if (stoke.IsDisposed)
                    {
                        tblSP = sanpham.getSanpham();

                        InitSetting();

                        Loaddata();
                    }
                      
                }

                //...
            }
        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearch.Text == "Manufacturer")
            {
                //result = MessageBox.Show("Manufacturer", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctxbSearch.WaterMark = "String";
                this.ActiveControl = ctxbSearch;
            }
            else if (cmbSearch.Text == "Brand")
            {
                //result = MessageBox.Show("Brand", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctxbSearch.WaterMark = "String";
                this.ActiveControl = ctxbSearch;
            }
            else if (cmbSearch.Text == "Quantity")
            {
                // result = MessageBox.Show("Quantity", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctxbSearch.WaterMark = "Number";
                this.ActiveControl = ctxbSearch;
            }
            else if (cmbSearch.Text == "Purchase date")
            {
                //result = MessageBox.Show("Purchase date", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctxbSearch.WaterMark = "YYYY-MM-DD";
                this.ActiveControl = ctxbSearch;
            }
            else if (cmbSearch.Text == "Price")
            {
                //result = MessageBox.Show("Price", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctxbSearch.WaterMark = "Number";
                this.ActiveControl = ctxbSearch;
            }
        }

        private void ctxbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            DialogResult result;
            DataTable spSearch = new DataTable();
            if(e.KeyCode==Keys.Enter)
            {
                if (cmbSearch.Text == "")
                {
                    result = MessageBox.Show("Please choose data to search by", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        ctxbSearch.Text = "";
                        this.ActiveControl = cmbSearch;
                    }
                }
                else if (ctxbSearch.Text == "")
                {
                    result = MessageBox.Show("Please enter data to search", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        this.ActiveControl = ctxbSearch;
                    }
                }
                
                else if (cmbSearch.Text == "Manufacturer")
                {
                    //result = MessageBox.Show("Manufacturer", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    try
                    {
                        spSearch = sanpham.searchManuf(ctxbSearch.Text.ToString());
                        tblSP = spSearch;

                        InitSetting();

                        Loaddata();
                    }
                    catch
                    {
                        result = MessageBox.Show("Incorrect data", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (result == DialogResult.OK)
                        {
                            ctxbSearch.Text = "";
                            this.ActiveControl = ctxbSearch;
                        }
                    }

                }
                else if (cmbSearch.Text == "Brand")
                {
                    //result = MessageBox.Show("Brand", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    try
                    {
                        spSearch = sanpham.searchBrand(ctxbSearch.Text.ToString());
                        tblSP = spSearch;

                        InitSetting();

                        Loaddata();
                    }
                    catch
                    {
                        result = MessageBox.Show("Incorrect data", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (result == DialogResult.OK)
                        {
                            ctxbSearch.Text = "";
                            this.ActiveControl = ctxbSearch;
                        }
                    }
                }
                else if (cmbSearch.Text == "Quantity")
                {
                    // result = MessageBox.Show("Quantity", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    try
                    {
                        spSearch = sanpham.searchQuantity(Int32.Parse(ctxbSearch.Text.ToString()));
                        tblSP = spSearch;

                        InitSetting();

                        Loaddata();
                    }
                    catch
                    {
                        result = MessageBox.Show("Please enter number", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (result == DialogResult.OK)
                        {
                            ctxbSearch.Text = "";
                            this.ActiveControl = ctxbSearch;
                        }
                    }
                }
                else if (cmbSearch.Text == "Purchase date")
                {
                    //result = MessageBox.Show("Purchase date", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    try
                    {
                        spSearch = sanpham.searchPurchaseDate(ctxbSearch.Text.ToString());
                        tblSP = spSearch;

                        InitSetting();

                        Loaddata();
                    }
                    catch
                    {
                        result = MessageBox.Show("Please enter correctly format date", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (result == DialogResult.OK)
                        {
                            ctxbSearch.Text = "";
                            this.ActiveControl = ctxbSearch;
                        }
                    }
                }
                else if (cmbSearch.Text == "Price")
                {
                    //result = MessageBox.Show("Price", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    try
                    {
                        spSearch = sanpham.searchPrice(Int32.Parse(ctxbSearch.Text.ToString()));
                        tblSP = spSearch;

                        InitSetting();

                        Loaddata();
                    }
                    catch
                    {
                        result = MessageBox.Show("Please enter number", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (result == DialogResult.OK)
                        {
                            ctxbSearch.Text = "";
                            this.ActiveControl = ctxbSearch;
                        }
                    }
                }
                else
                {
                    result = MessageBox.Show("Incorrect data", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        this.cmbSearch.Text = "";
                    }
                }


            }
           
        }
        

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tblSP = sanpham.getSanpham();

            InitSetting();

            Loaddata();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dtgvDetailPhone_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ctxbSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
