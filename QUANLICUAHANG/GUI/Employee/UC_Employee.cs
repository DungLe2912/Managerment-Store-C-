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

namespace GUI.Employee
{
    public partial class UC_Employee : UserControl
    {
        int PageCount;
        int maxRec;
        int pageSize = 15;
        int currentPage;
        int recNo;

        BUS_Nhanvien nhanvien = new BUS_Nhanvien();
        BUS_ACCOUNT acc = new BUS_ACCOUNT();
        private DataTable tblSP = new DataTable();
        public UC_Employee()
        {
            InitializeComponent();
        }
        public void Xoadulieu()
        {
            cmbSearch.Text = "";
            cmbSearch.DataSource = null;
            cmbSearch.Items.Clear();
            cmbSearch.SelectedIndex = -1;

            ctxbSearch.Text = "";

            if (dtgvEmployee.DataSource != null)
            {
                dtgvEmployee.DataSource = null;
            }
            else
            {
                dtgvEmployee.Rows.Clear();
            }
            dtgvEmployee.Refresh();
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
            cmbSearch.Items.Add("Day of Birth");
            cmbSearch.Items.Add("Address");
            cmbSearch.Items.Add("Sex");


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
            dtgvEmployee.Columns.Clear();
            SBind.DataSource = dtTemp;
            dtgvEmployee.DataSource = SBind;

            //set autosize mode
            dtgvEmployee.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvEmployee.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvEmployee.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //datagrid has calculated it's widths so we can store them
            for (i = 0; i <= dtgvEmployee.Columns.Count - 1; i++)
            {
                //store autosized widths
                int colw = dtgvEmployee.Columns[i].Width;
                //remove autosizing
                dtgvEmployee.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //set width to calculated by autosize
                dtgvEmployee.Columns[i].Width = colw;
            }

            dtgvEmployee.Columns[0].HeaderText = "ID";
            dtgvEmployee.Columns[1].HeaderText = "Name";
            dtgvEmployee.Columns[2].HeaderText = "Number Citizenship";
            dtgvEmployee.Columns[3].HeaderText = "Sex";
            dtgvEmployee.Columns[4].HeaderText = "Address";
            dtgvEmployee.Columns[5].HeaderText = "Day of Birth";
            dtgvEmployee.Columns[6].HeaderText = "Phone";





        }

        private void UC_Employee_Load(object sender, EventArgs e)
        {
            Xoadulieu();
            tblSP = nhanvien.getNhanvien();

            InitSetting();
            Loaddata();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            using (Employee.Form_AddnewEmployee emp = new Employee.Form_AddnewEmployee())
            {
                emp.ShowDialog();
                if (emp.IsDisposed)
                {
                    Xoadulieu();
                    tblSP = nhanvien.getNhanvien();

                    InitSetting();
                    Loaddata();
                }
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
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

        private void btnNext_Click(object sender, EventArgs e)
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

        private void dtgvEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dtgvEmployee.SelectedRows)
            {
                string id = row.Cells[0].Value.ToString();
                using (Employee.Form_DetailEmployee detail = new Employee.Form_DetailEmployee(id))
                {
                    detail.ShowDialog();
                    if (detail.IsDisposed)
                    {
                        Xoadulieu();
                        tblSP = nhanvien.getNhanvien();

                        InitSetting();
                        Loaddata();
                    }
                }

                //...
            }
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {

        }

        private void dtgvEmployee_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip my_menu = new ContextMenuStrip();
                int position_xy_mouse_row = dtgvEmployee.HitTest(e.X, e.Y).RowIndex;
                if (position_xy_mouse_row >= 0)
                {

                    string id = "";
                    foreach (DataGridViewRow row in dtgvEmployee.SelectedRows)
                    {
                        id = row.Cells[0].Value.ToString();

                    }
                    if (acc.getUP(id).Rows.Count == 0)
                    {
                        my_menu.Items.Add("Add account").Name = "Add";

                    }
                    else
                    {
                        my_menu.Items.Add("Delete account").Name = "Delete";
                        my_menu.Items.Add("Edit account").Name = "Edit";
                    }
                }
                my_menu.Show(dtgvEmployee, new Point(e.X, e.Y));
                my_menu.ItemClicked += new ToolStripItemClickedEventHandler(my_menu_ItemClicked);

            }

        }
        void my_menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToString())

            {
                case "Add":
                    string id = "";
                    foreach (DataGridViewRow row in dtgvEmployee.SelectedRows)
                    {
                        id = row.Cells[0].Value.ToString();
                        using (Employee.Form_Account add_acc = new Employee.Form_Account(id))
                        {
                            add_acc.ShowDialog();
                            if (add_acc.IsDisposed)
                            {
                                Xoadulieu();
                                tblSP = nhanvien.getNhanvien();

                                InitSetting();
                                Loaddata();
                            }
                        }
                    }
                    break;
                case "Delete":
                    //string id = "";
                    foreach (DataGridViewRow row in dtgvEmployee.SelectedRows)
                    {
                        id = row.Cells[0].Value.ToString();
                        DialogResult res;
                        res = MessageBox.Show("Do you wanna delete account of this employee?", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (res == DialogResult.OK)
                        {

                            if (acc.delAcc(id) == true)
                            {
                                res = MessageBox.Show("Delete account succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (res == DialogResult.OK)
                                {
                                    Xoadulieu();
                                    tblSP = nhanvien.getNhanvien();

                                    InitSetting();
                                    Loaddata();
                                }
                            }
                            else
                            {
                                res = MessageBox.Show("Delete account failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                    }
                    break;
                case "Edit":
                    break;
            }

        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearch.Text == "Day of Birth")
            {
                //result = MessageBox.Show("Manufacturer", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctxbSearch.WaterMark = "YYYY-MM-DD";
                this.ActiveControl = ctxbSearch;
            }
            else if (cmbSearch.Text == "Address")
            {
                //result = MessageBox.Show("Brand", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctxbSearch.WaterMark = "String";
                this.ActiveControl = ctxbSearch;
            }
            else if (cmbSearch.Text == "Sex")
            {
                // result = MessageBox.Show("Quantity", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctxbSearch.WaterMark = "String";
                this.ActiveControl = ctxbSearch;
            }

        }

        private void ctxbSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Xoadulieu();
            tblSP = nhanvien.getNhanvien();

            InitSetting();
            Loaddata();
        }

        private void ctxbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            DialogResult result;
            DataTable spSearch = new DataTable();
            if (e.KeyCode == Keys.Enter)
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
                else if (cmbSearch.Text == "Day of Birth")
                {
                    //result = MessageBox.Show("Manufacturer", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    try
                    {
                        spSearch = nhanvien.searchDOB(ctxbSearch.Text.ToString());
                        tblSP = spSearch;
                        Xoadulieu();
                        InitSetting();

                        Loaddata();
                        this.ActiveControl = cmbSearch;
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
                else if (cmbSearch.Text == "Address")
                {
                    //result = MessageBox.Show("Brand", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    try
                    {
                        spSearch = nhanvien.searchAddr(ctxbSearch.Text.ToString());
                        tblSP = spSearch;
                        Xoadulieu();
                        InitSetting();

                        Loaddata();
                        this.ActiveControl = cmbSearch;
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
                else if (cmbSearch.Text == "Sex")
                {
                    // result = MessageBox.Show("Quantity", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    try
                    {
                        spSearch = nhanvien.searchSex(ctxbSearch.Text.ToString());
                        tblSP = spSearch;
                        Xoadulieu();
                        InitSetting();

                        Loaddata();
                        this.ActiveControl = cmbSearch;
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
            }
        }

        
    }
}
