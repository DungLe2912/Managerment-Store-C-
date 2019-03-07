using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Windows.Forms.DataVisualization.Charting;
using DTO;
using BUS;
using System.Globalization;
using System.Collections;

namespace GUI.Report
{
    public partial class UC_Revenue : UserControl
    {
        BUS_Donhang dhang = new BUS_Donhang();
        private string year = "";
        private string month = "";
        private string begin = "";
        private string end = "";
        int type = 0;//0.Year| 1.Month| 2.Week|3.Option
        DataTable datarp = new DataTable();

        public IEnumerable[] GetOrdinal { get; private set; }

        public UC_Revenue()
        {
            InitializeComponent();
        }
        public UC_Revenue(string tmp, int tp, string mth, string b, string e)
        {
            InitializeComponent();
            year = tmp;
            type = tp;
            month = mth;
            begin = b;
            end = e;
        }
        bool checkexitAmount_Week(int tmp)
        {
            List<double> x = (from p in datarp.AsEnumerable()
                              where p.Field<int>("WK") == tmp
                              orderby p.Field<double>("TT") ascending
                              select p.Field<double>("TT")).ToList();
            if (x.Count == 0)
                return false;
            return true;
        }
        bool checkexitAmount_Month(int tmp)
        {
            List<double> x = (from p in datarp.AsEnumerable()
                           where p.Field<int>("THANG") == tmp
                           orderby p.Field<double>("TT") ascending
                           select p.Field<double>("TT")).ToList();
            if (x.Count == 0)
                return false;
            return true;
        }
        public void DataLoad_Week()
        {


            datarp = dhang.getDataReportRevenue_Week(year,month);
            if (datarp.Rows.Count == 0)
            {
                MessageBox.Show("No data to statistical", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CultureInfo ciCurr = CultureInfo.CurrentCulture;

            int days = DateTime.DaysInMonth(Int32.Parse(year), Int32.Parse(month));
            string daybegin = year + "-" + month + "-" + "1";
            string dayend = year + "-" + month + "-" + days.ToString();
            int weekNum_Begin = ciCurr.Calendar.GetWeekOfYear(DateTime.Parse(daybegin), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            int weekNum_End = ciCurr.Calendar.GetWeekOfYear(DateTime.Parse(dayend), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);



            for (int th = weekNum_Begin; th <= weekNum_End; th++)
            {
                if (checkexitAmount_Week(th) == false)
                {
                    DataRow r = datarp.NewRow();

                    r["TT"] = 0;
                    r["WK"] = th;
                    datarp.Rows.Add(r);
                }
            }
            //Remove the Default Series.
            if (chartSale.Series.Count() == 1)
            {
                chartSale.Series.Remove(chartSale.Series[0]);
            }

            int[] x = (from p in datarp.AsEnumerable()

                       orderby p.Field<int>("WK") ascending
                       select p.Field<int>("WK")).ToArray();

            //Get the quantity of Orders for each manufacturer.
            double[] y = (from p in datarp.AsEnumerable()

                       orderby p.Field<int>("WK") ascending
                       select p.Field<double>("TT")).ToArray();

            //Add Series to the Chart.
            chartSale.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series("Paid amount"));
            chartSale.Series["Paid amount"].IsValueShownAsLabel = true;
            chartSale.Series["Paid amount"].BorderWidth = 3;
            chartSale.Series["Paid amount"].ChartType = SeriesChartType.Line;
            chartSale.Series["Paid amount"].Points.DataBindXY(x, y);


            chartSale.Titles[0].Text = "Week";
            chartSale.Legends[0].Enabled = true;

        }
        public void DataLoad_Month()
        {


            datarp = dhang.getDataReportRevenue_Month(year);
            if (datarp.Rows.Count == 0)
            {
                MessageBox.Show("No data to statistical", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            for (int th = 1; th <= 12; th++)
            {
                if(checkexitAmount_Month(th)==false)
                {
                    DataRow r = datarp.NewRow();
                   
                    r["TT"] = 0;
                    r["THANG"] = th;
                    datarp.Rows.Add(r);
                }
            }
            //Remove the Default Series.
            if (chartSale.Series.Count() == 1)
            {
                chartSale.Series.Remove(chartSale.Series[0]);
            }

            int[] x = (from p in datarp.AsEnumerable()
                       
                       orderby p.Field<int>("THANG") ascending
                       select p.Field<int>("THANG")).ToArray();

            //Get the quantity of Orders for each manufacturer.
            double[] y = (from p in datarp.AsEnumerable()
                      
                       orderby p.Field<int>("THANG") ascending
                       select p.Field<double>("TT")).ToArray();

            //Add Series to the Chart.
            chartSale.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series("Paid amount"));
            chartSale.Series["Paid amount"].IsValueShownAsLabel = true;
            chartSale.Series["Paid amount"].BorderWidth = 3;
            chartSale.Series["Paid amount"].ChartType = SeriesChartType.Line;
            chartSale.Series["Paid amount"].Points.DataBindXY(x, y);


            chartSale.Titles[0].Text = "Month";
            chartSale.Legends[0].Enabled = true;

        }
        public void DataLoad_Year()
        {
            datarp = dhang.getDataReportRevenue_Year();
            if (datarp.Rows.Count == 0)
            {
                MessageBox.Show("No data to statistical", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Remove the Default Series.
            //if (chartSale.Series.Count() == 1)
            //{
            //    chartSale.Series.Remove(chartSale.Series[0]);
            //}
            chartSale.DataSource = datarp;
            chartSale.Series["Revenue"].XValueMember = "YR";
            chartSale.Series["Revenue"].XValueType = ChartValueType.Int32;
            chartSale.Series["Revenue"].YValueMembers = "TT";
            chartSale.Series["Revenue"].YValueType = ChartValueType.Double;

            chartSale.Titles[0].Text = "Year";


            chartSale.Legends[0].Enabled = true;
        }
        public void DataLoad_Option()
        {


            datarp = dhang.getDataReportRevenue_Option(begin, end);
            if (datarp.Rows.Count == 0)
            {
                MessageBox.Show("No data to statistical", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (datarp.Rows.Count == 0)
            {
                MessageBox.Show("No data to statistical", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            chartSale.DataSource = datarp;
            chartSale.Series["Revenue"].XValueMember = "DAY";
            chartSale.Series["Revenue"].XValueType = ChartValueType.DateTime;
            chartSale.Series["Revenue"].YValueMembers = "TT";
            chartSale.Series["Revenue"].YValueType = ChartValueType.Double;


            chartSale.Titles[0].Text = "Day";
            chartSale.Legends[0].Enabled = true;

        }
        private void UC_Revenue_Load(object sender, EventArgs e)
        {
            if (type == 0)
                DataLoad_Year();
            if (type == 1)
                DataLoad_Month();
            if (type == 2)
                DataLoad_Week();
            if (type == 3)
                DataLoad_Option();
        }
    }
}
