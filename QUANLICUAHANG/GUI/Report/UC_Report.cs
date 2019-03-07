using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Report
{
    public partial class UC_Report : UserControl
    {
        private int type = 0;
        private string year = "";
        private string month = "";
        private string begin = "";
        private string end = "";
        private int isClicked = 0;
        public UC_Report()
        {
            InitializeComponent();
        }
        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControl.Controls.Clear();
            panelControl.Controls.Add(c);
        }
        private void UC_Report_Load(object sender, EventArgs e)
        {
            Xoadulieu();
            cmbStatistics.Items.Add("Year");
            cmbStatistics.Items.Add("Month");
            cmbStatistics.Items.Add("Week");
            cmbStatistics.Items.Add("Option");
        }
        public void Xoadulieu()
        {
            ctxbStatistics.Visible = false;
            cTxbMonth.Visible = false;
            cTxbMonth.Enabled = false;
            dtpk1.Visible = false;
            dtpk2.Visible = false;
            lb1.Visible = false;
            lb2.Visible = false;
            cmbStatistics.Text = "";
            cmbStatistics.DataSource = null;
            cmbStatistics.Items.Clear();
            cmbStatistics.SelectedIndex = -1;

            Report.UC_TKSale sale = new Report.UC_TKSale(year,type,month,begin,end);
            AddControlsToPanel(sale);
        }
        private void btnSale_Click(object sender, EventArgs e)
        {
            Report.UC_TKSale sale = new Report.UC_TKSale(year,type,month,begin,end);
            AddControlsToPanel(sale);
            isClicked = 0;
        }

        private void btnRev_Click(object sender, EventArgs e)
        {
            Report.UC_Revenue rev = new Report.UC_Revenue();
            AddControlsToPanel(rev);
            isClicked = 1;
        }
        public bool checkData(string tmp)
        {
            var isNumeric = int.TryParse(tmp, out int n);
            if (isNumeric == false) return false;
            else if (Int32.Parse(tmp) < 0) return false;
            else return true;
        }
        private void cmbStatistics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbStatistics.Text=="Year")
            {
                ctxbStatistics.Visible = false;
                cTxbMonth.Visible = false;
                
                dtpk1.Visible = false;
                dtpk2.Visible = false;
                type = 0;

            }
            if(cmbStatistics.Text=="Month")
            {
                type = 1;
                ctxbStatistics.Visible = true;
                cTxbMonth.Visible = false;

                dtpk1.Visible = false;
                dtpk2.Visible = false;
                this.ActiveControl = ctxbStatistics;
            }
            if(cmbStatistics.Text=="Week")
            {
                type = 2;
                ctxbStatistics.Visible = true;
                cTxbMonth.Visible = true;
                dtpk1.Visible = false;
                dtpk2.Visible = false;
                cTxbMonth.Enabled = false;
                this.ActiveControl = ctxbStatistics;
            }
            if (cmbStatistics.Text == "Option")
            {
                type = 3;
                dtpk1.Visible = true;
                dtpk2.Visible = true;
                ctxbStatistics.Visible = false;
                cTxbMonth.Visible = false;

                lb1.Visible = true;
                lb2.Visible = true;
                this.ActiveControl = dtpk1;
            }
        }

        private void ctxbStatistics_KeyDown(object sender, KeyEventArgs e)
        {
            DialogResult result;
            if (e.KeyCode==Keys.Enter)
            {
                if(ctxbStatistics.Text=="")
                {
                    result = MessageBox.Show("Please enter year", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                        this.ActiveControl = ctxbStatistics;
                }
               else if(checkData(ctxbStatistics.Text)==false)
                {
                    
                    result = MessageBox.Show("Incorrect data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (result == DialogResult.OK)
                        this.ActiveControl = ctxbStatistics;
                }
                else
                {
                   if(type==1)
                    {
                        if(isClicked==0)
                        {
                            year = ctxbStatistics.Text;
                            Report.UC_TKSale sale = new Report.UC_TKSale(year, type, month,begin,end);
                            AddControlsToPanel(sale);
                            ctxbStatistics.Text = "";
                            cTxbMonth.Text = "";
                            ctxbStatistics.Visible = false;
                            cTxbMonth.Visible = false;
                            this.ActiveControl = cmbStatistics;
                        }
                        if (isClicked == 1)
                        {
                            year = ctxbStatistics.Text;
                            Report.UC_Revenue rev = new Report.UC_Revenue(year, type, month, begin, end);
                            AddControlsToPanel(rev);
                            ctxbStatistics.Text = "";
                            cTxbMonth.Text = "";
                            ctxbStatistics.Visible = false;
                            cTxbMonth.Visible = false;
                            this.ActiveControl = cmbStatistics;
                        }
                    }
                   if(type==2)
                    {
                        cTxbMonth.Enabled = true;
                        this.ActiveControl = cTxbMonth;
                    }
                    
                }
            }
           
        }

        private void cTxbMonth_KeyDown(object sender, KeyEventArgs e)
        {
            DialogResult result;
            if(e.KeyCode==Keys.Enter)
            {
                if (ctxbStatistics.Text == "")
                {
                    result = MessageBox.Show("Please enter year", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                        this.ActiveControl = ctxbStatistics;
                }
                else if (checkData(ctxbStatistics.Text) == false)
                {

                    result = MessageBox.Show("Incorrect data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (result == DialogResult.OK)
                        this.ActiveControl = ctxbStatistics;
                }
                else if(cTxbMonth.Text=="")
                {
                    result = MessageBox.Show("Please enter month", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                        this.ActiveControl = ctxbStatistics;
                }
                else if(checkData(cTxbMonth.Text)==false)
                {
                    result = MessageBox.Show("Incorrect data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (result == DialogResult.OK)
                        this.ActiveControl = ctxbStatistics;
                }
                else
                {
                    if(isClicked==0)
                    {
                        year = ctxbStatistics.Text;
                        month = cTxbMonth.Text;
                        Report.UC_TKSale sale = new Report.UC_TKSale(year, type, month,begin,end);
                        AddControlsToPanel(sale);
                        ctxbStatistics.Text = "";
                        cTxbMonth.Text = "";
                        ctxbStatistics.Visible = false;
                        cTxbMonth.Visible = false;
                        this.ActiveControl = cmbStatistics;
                    }
                    if (isClicked == 1)
                    {
                        year = ctxbStatistics.Text;
                        month = cTxbMonth.Text;
                        Report.UC_Revenue rev = new Report.UC_Revenue(year, type, month, begin, end);
                        AddControlsToPanel(rev);
                        ctxbStatistics.Text = "";
                        cTxbMonth.Text = "";
                        ctxbStatistics.Visible = false;
                        cTxbMonth.Visible = false;
                        this.ActiveControl = cmbStatistics;
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if(isClicked==0)
            {
                if(type==0)
                {
                    year = ctxbStatistics.Text;
                    Report.UC_TKSale sale = new Report.UC_TKSale(year, type, month,begin,end);
                    AddControlsToPanel(sale);
                    ctxbStatistics.Text = "";
                    cTxbMonth.Text = "";
                    ctxbStatistics.Visible = false;
                    cTxbMonth.Visible = false;
                    this.ActiveControl = cmbStatistics;
                }
                if(type==3)
                {
                    begin = dtpk1.Value.ToShortDateString();
                    end = dtpk2.Value.ToShortDateString();
                    Report.UC_TKSale sale = new Report.UC_TKSale(year, type, month, begin, end);
                    AddControlsToPanel(sale);
                    ctxbStatistics.Visible = false;
                    cTxbMonth.Visible = false;

                    dtpk1.Visible = false;
                    dtpk2.Visible = false;
                }
            }
            if (isClicked == 1)
            {
                if (type == 0)
                {
                    year = ctxbStatistics.Text;
                    Report.UC_Revenue rev = new Report.UC_Revenue(year, type, month, begin, end);
                    AddControlsToPanel(rev);
                    ctxbStatistics.Text = "";
                    cTxbMonth.Text = "";
                    ctxbStatistics.Visible = false;
                    cTxbMonth.Visible = false;
                    this.ActiveControl = cmbStatistics;
                }
                if (type == 3)
                {
                    begin = dtpk1.Value.ToShortDateString();
                    end = dtpk2.Value.ToShortDateString();
                    Report.UC_Revenue rev = new Report.UC_Revenue(year, type, month, begin, end);
                    AddControlsToPanel(rev);
                    ctxbStatistics.Visible = false;
                    cTxbMonth.Visible = false;

                    dtpk1.Visible = false;
                    dtpk2.Visible = false;
                }
            }
        }
    }
}
