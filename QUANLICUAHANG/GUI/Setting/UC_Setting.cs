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

namespace GUI.Setting
{
    public partial class UC_Setting : UserControl
    {
        BUS_Khuyenmai khuyenmai = new BUS_Khuyenmai();
        BUS_BF bf = new BUS_BF();
        /*Danh cho ma code*/
        int PageCount;
        int maxRec;
        int pageSize = 19;
        int currentPage;
        int recNo;
        /*Danh cho ngay*/
        int PageCountDate;
        int maxRecDate;
        int pageSizeDate = 19;
        int currentPageDate;
        int recNoDate;
        private DataTable code = new DataTable();
        private DataTable date = new DataTable();


        public UC_Setting()
        {
            InitializeComponent();
        }

        public void Xoadulieu()
        {
            

            if (dtgvCode.DataSource != null)
            {
                dtgvCode.DataSource = null;
            }
            else
            {
                dtgvCode.Rows.Clear();
            }
            dtgvCode.Refresh();

           

        }
        public void XoadulieuDate()
        {
            if (dtgvDate.DataSource != null)
            {
                dtgvDate.DataSource = null;
            }
            else
            {
                dtgvDate.Rows.Clear();
            }
            dtgvDate.Refresh();
        }
        public void InitSetting()
        {
            maxRec = code.Rows.Count;
            PageCount = maxRec / pageSize;
            if ((maxRec % pageSize) > 0)
            {
                PageCount += 1;
            }

            // Initial seeings
            currentPage = 1;
            recNo = 0;

        }
        public void InitSettingDate()
        {
            maxRecDate = date.Rows.Count;
            PageCountDate = maxRecDate / pageSizeDate;
            if ((maxRecDate % pageSizeDate) > 0)
            {
                PageCountDate += 1;
            }

            // Initial seeings
            currentPageDate = 1;
            recNoDate = 0;

        }
        public void Loaddata()
        {
            Xoadulieu();
            //DataSet tmp = new DataSet();
            //tmp=tblSP.

           
            int i;
            int startRec;
            int endRec;
            DataTable dtTemp;

            //Clone the source table to create a temporary table.
            dtTemp = code.Clone();
            if (code.Rows.Count != 0)
            {
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
                    dtTemp.ImportRow(code.Rows[i]);
                    recNo += 1;
                }

            }


            BindingSource SBind = new BindingSource();
            dtgvCode.Columns.Clear();
            SBind.DataSource = dtTemp;
            dtgvCode.DataSource = SBind;

            dtgvCode.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvCode.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvCode.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //datagrid has calculated it's widths so we can store them
            for (i = 0; i <= dtgvCode.Columns.Count - 1; i++)
            {
                //store autosized widths
                int colw = dtgvCode.Columns[i].Width;
                //remove autosizing
                dtgvCode.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //set width to calculated by autosize
                dtgvCode.Columns[i].Width = colw;
            }

            dtgvCode.Columns[0].HeaderText = "Code";
            dtgvCode.Columns[1].HeaderText = "Expiration date";
            dtgvCode.Columns[2].HeaderText = "Discount (%)";
            
        }
        public void LoaddataDate()
        {
            XoadulieuDate();
            //DataSet tmp = new DataSet();
            //tmp=tblSP.


            int i;
            int startRec;
            int endRec;
            DataTable dtTemp;

            //Clone the source table to create a temporary table.
            dtTemp = date.Clone();
            if (date.Rows.Count != 0)
            {
                if (currentPageDate == PageCountDate)
                {
                    endRec = maxRecDate;
                }
                else
                {
                    endRec = pageSizeDate * currentPageDate;
                }
                startRec = recNoDate;

                //Copy rows from the source table to fill the temporary table.
                for (i = startRec; i < endRec; i++)
                {
                    dtTemp.ImportRow(date.Rows[i]);
                    recNoDate += 1;
                }

            }


            BindingSource SBind = new BindingSource();
            dtgvDate.Columns.Clear();
            SBind.DataSource = dtTemp;
            dtgvDate.DataSource = SBind;

            dtgvDate.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDate.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDate.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //datagrid has calculated it's widths so we can store them
            for (i = 0; i <= dtgvDate.Columns.Count - 1; i++)
            {
                //store autosized widths
                int colw = dtgvDate.Columns[i].Width;
                //remove autosizing
                dtgvDate.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //set width to calculated by autosize
                dtgvDate.Columns[i].Width = colw;
            }

            dtgvDate.Columns[0].HeaderText = "Date discount";
            dtgvDate.Columns[1].HeaderText = "Event";
            dtgvDate.Columns[2].HeaderText = "Discount (%)";

        }
        private void UC_Setting_Load(object sender, EventArgs e)
        {
            Xoadulieu();
            XoadulieuDate();
            code = khuyenmai.getCode();
            date = bf.getDate();
            InitSetting();
            InitSettingDate();
            Loaddata();
            LoaddataDate();
            //dtgvCode.MouseClick+=new MouseEventHandler
        }

        private void btnAddCode_Click(object sender, EventArgs e)
        {
            using (Setting.Form_AddCode addcode=new Setting.Form_AddCode())
            {
                addcode.ShowDialog();
                if(addcode.IsDisposed)
                {
                    Xoadulieu();
                    code = khuyenmai.getCode();

                    InitSetting();
                    Loaddata();
                }
            }
        }

        private void btnPreCode_Click(object sender, EventArgs e)
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

        private void btnNextCode_Click(object sender, EventArgs e)
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

        private void dtgvCode_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
            {
                ContextMenuStrip my_menu = new ContextMenuStrip();
                int position_xy_mouse_row = dtgvCode.HitTest(e.X, e.Y).RowIndex;
                if(position_xy_mouse_row>=0)
                {
                    my_menu.Items.Add("Delete").Name = "Delete";
                    my_menu.Items.Add("Edit").Name = "Edit";
                    
                }
                my_menu.Show(dtgvCode, new Point(e.X, e.Y));
                my_menu.ItemClicked += new ToolStripItemClickedEventHandler(my_menu_ItemClicked);
            }
        }
        void my_menu_ItemClicked(object sender,ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToString())
            {
                case "Delete":
                    foreach (DataGridViewRow row in dtgvCode.SelectedRows)
                    {
                        string id = row.Cells[0].Value.ToString();
                        DialogResult res;
                        res = MessageBox.Show("Do you wanna delete this code?", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if(res==DialogResult.OK)
                        {
                            int idcode = Int32.Parse(khuyenmai.getIDFromCode(id));
                            if(khuyenmai.delCode(idcode)==true)
                            {
                                res = MessageBox.Show("Delete code succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if(res==DialogResult.OK)
                                {
                                    Xoadulieu();
                                    code = khuyenmai.getCode();

                                    InitSetting();
                                    Loaddata();
                                }
                            }
                            else
                            {
                                res = MessageBox.Show("Delete code failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                    }
                    break;
                case "Edit":
                    foreach (DataGridViewRow row in dtgvCode.SelectedRows)
                    {
                        string id = row.Cells[0].Value.ToString();
                        using (Setting.Form_EditCode edit = new Setting.Form_EditCode(id))
                        {
                            edit.ShowDialog();
                            if (edit.IsDisposed)
                            {
                                Xoadulieu();
                                code = khuyenmai.getCode();

                                InitSetting();
                                Loaddata();
                            }

                        }
                    }
                    break;
            }

        }

        private void btnAddDate_Click(object sender, EventArgs e)
        {
            using (Setting.Form_AddDate adddate = new Setting.Form_AddDate())
            {
                adddate.ShowDialog();
                if (adddate.IsDisposed)
                {
                    XoadulieuDate();
                    date = bf.getDate();

                    InitSettingDate();
                    LoaddataDate();
                }
            }
        }

        private void btnPreDate_Click(object sender, EventArgs e)
        {
            if (currentPageDate == 1)
                return;
            if (currentPageDate == PageCountDate)
            {
                recNoDate = pageSizeDate * (currentPageDate - 2);
            }

            currentPageDate -= 1;
            //Check if you are already at the first page.
            if (currentPageDate < 1)
            {
                // MessageBox.Show("You are at the First Page!");
                currentPageDate = 1;
                return;
            }
            else
            {
                recNoDate = pageSizeDate * (currentPageDate - 1);
            }
            LoaddataDate();
        }

        private void btnNextDate_Click(object sender, EventArgs e)
        {
            if (PageCountDate == 1)
                return;
            currentPageDate += 1;
            if (currentPageDate > PageCountDate)
            {
                currentPageDate = PageCountDate;
                return;
                //Check if you are already at the last page.

            }
            LoaddataDate();
        }

        private void dtgvDate_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip my_menu = new ContextMenuStrip();
                int position_xy_mouse_row = dtgvDate.HitTest(e.X, e.Y).RowIndex;
                if (position_xy_mouse_row >= 0)
                {
                    my_menu.Items.Add("Delete").Name = "Delete";
                    my_menu.Items.Add("Edit").Name = "Edit";

                }
                my_menu.Show(dtgvDate, new Point(e.X, e.Y));
                my_menu.ItemClicked += new ToolStripItemClickedEventHandler(my_menuDate_ItemClicked);
            }
        }
        void my_menuDate_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToString())
            {
                case "Delete":
                    foreach (DataGridViewRow row in dtgvDate.SelectedRows)
                    {
                        string id = row.Cells[0].Value.ToString();
                        
                        DialogResult res;
                        res = MessageBox.Show("Do you wanna delete this date?", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (res == DialogResult.OK)
                        {
                            int idcode = Int32.Parse(bf.getIDFromDate(id));
                            if (bf.delDate(idcode) == true)
                            {
                                res = MessageBox.Show("Delete date succeeded", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (res == DialogResult.OK)
                                {
                                    XoadulieuDate();
                                    date = bf.getDate();

                                    InitSettingDate();
                                    LoaddataDate();
                                }
                            }
                            else
                            {
                                res = MessageBox.Show("Delete date failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                    }
                    break;
                case "Edit":
                    foreach (DataGridViewRow row in dtgvDate.SelectedRows)
                    {
                        string id = row.Cells[0].Value.ToString();

                        using (Setting.Form_EditDate edit = new Setting.Form_EditDate(id))
                        {
                            edit.ShowDialog();
                            if (edit.IsDisposed)
                            {
                                XoadulieuDate();
                                date = bf.getDate();

                                InitSettingDate();
                                LoaddataDate();
                            }

                        }
                    }
                    break;
            }

        }
    }
}
