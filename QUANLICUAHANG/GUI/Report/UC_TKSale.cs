using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Windows.Forms.DataVisualization.Charting;
using DTO;
using BUS;
using System.Globalization;

namespace GUI.Report
{
    public partial class UC_TKSale : UserControl
    {
        BUS_Donhang dhang = new BUS_Donhang();
        private string year = "";
        private string month = "";
        private string begin = "";
        private string end = "";
        int type = 0;//0.Year| 1.Month| 2.Week|3.Option
        DataTable datarp = new DataTable();
        public UC_TKSale()
        {
            InitializeComponent();
            
        }
        public UC_TKSale(string tmp,int tp,string mth, string b, string e)
        {
            InitializeComponent();
            year = tmp;
            type = tp;
            month = mth;
            begin = b;
            end = e;
        }
        
        List<string> countManuf_month(int tmp)
        {
            List<string> x = (from p in datarp.AsEnumerable()
                       where p.Field<int>("THANG") == tmp
                       orderby p.Field<string>("TH") ascending
                       select p.Field<string>("TH")).ToList();
            return x;
        }
        List<string> countManuf_week(int tmp)
        {
            List<string> x = (from p in datarp.AsEnumerable()
                              where p.Field<int>("WK") == tmp
                              orderby p.Field<string>("TH") ascending
                              select p.Field<string>("TH")).ToList();
            return x;
        }
        List<string> countManuf_year(int tmp)
        {
            List<string> x = (from p in datarp.AsEnumerable()
                              where p.Field<int>("YR") == tmp
                              orderby p.Field<string>("TH") ascending
                              select p.Field<string>("TH")).ToList();
            return x;
        }
        
        public void DataLoad_Month()
        {

            DataTable top = new DataTable();
            top = dhang.getTop3Product_Year(year);
            string top_product = "";
            if(top.Rows.Count!=0)
            {
                label1.Visible = true;
                lblManuf.Visible = true;
                foreach(DataRow row in top.Rows)
                {
                    top_product += row[1].ToString() + " : " + row[2].ToString() + "\n";
                }
                lblManuf.Text = top_product;
            }
            datarp = dhang.getDataReportSale_Month(year);
            if(datarp.Rows.Count==0)
            {
                MessageBox.Show("No data to statistical", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            List<string> manufs = (from p in datarp.AsEnumerable()
                                      select p.Field<string>("TH")).Distinct().ToList();

            for (int th = 1; th <= 12; th++)
            {
                List<string> x = countManuf_month(th);
                if (x.Count < manufs.Count)
                {
                    foreach (string manuf in manufs)
                    {
                        var match = x.FirstOrDefault(stringToCheck => stringToCheck.Contains(manuf));
                        if (match == null)
                        {
                            DataRow r = datarp.NewRow();
                            r["TH"] = manuf;
                            r["SL"] = 0;
                            r["THANG"] = th;
                            datarp.Rows.Add(r);
                        }
                    }
                }
            }
            //Remove the Default Series.
            if (chartSale.Series.Count() == 1)
            {
                chartSale.Series.Remove(chartSale.Series[0]);
            }

            foreach (string manuf in manufs)
            {

                //Get the Month for each manufacturer.
                int[] x = (from p in datarp.AsEnumerable()
                           where p.Field<string>("TH") == manuf
                           orderby p.Field<int>("THANG") ascending
                           select p.Field<int>("THANG")).ToArray();

                //Get the quantity of Orders for each manufacturer.
                int[] y = (from p in datarp.AsEnumerable()
                           where p.Field<string>("TH") == manuf
                           orderby p.Field<int>("THANG") ascending
                           select p.Field<int>("SL")).ToArray();

                //Add Series to the Chart.
                chartSale.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series(manuf));
                chartSale.Series[manuf].IsValueShownAsLabel = true;
                chartSale.Series[manuf].BorderWidth = 3;
                chartSale.Series[manuf].ChartType = SeriesChartType.Line;
                chartSale.Series[manuf].Points.DataBindXY(x, y);
            }
            chartSale.Titles[0].Text = "Month";
            chartSale.Legends[0].Enabled = true;

        }
        public void DataLoad_Week()
        {
            DataTable top = new DataTable();
            top = dhang.getTop3Product_Month(year,month);
            string top_product = "";
            if (top.Rows.Count != 0)
            {
                label1.Visible = true;
                lblManuf.Visible = true;
                foreach (DataRow row in top.Rows)
                {
                    top_product += row[1].ToString() + " : " + row[2].ToString() + "\n";
                }
                lblManuf.Text = top_product;
            }
            datarp = dhang.getDataReportSale_Week(year, month);
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


            
            List<string> manufs = (from p in datarp.AsEnumerable()
                                   select p.Field<string>("TH")).Distinct().ToList();
            for (int th = weekNum_Begin; th <= weekNum_End; th++)
            {
                List<string> x = countManuf_week(th);
                if (x.Count < manufs.Count)
                {
                    foreach (string manuf in manufs)
                    {
                        var match = x.FirstOrDefault(stringToCheck => stringToCheck.Contains(manuf));
                        if (match == null)
                        {
                            DataRow r = datarp.NewRow();
                            r["TH"] = manuf;
                            r["SL"] = 0;
                            r["WK"] = th;
                            datarp.Rows.Add(r);
                        }
                    }
                }
            }
            //Remove the Default Series.
            if (chartSale.Series.Count() == 1)
            {
                chartSale.Series.Remove(chartSale.Series[0]);
            }

            foreach (string manuf in manufs)
            {

                //Get the Month for each manufacturer.
                int[] x = (from p in datarp.AsEnumerable()
                           where p.Field<string>("TH") == manuf
                           orderby p.Field<int>("WK") ascending
                           select p.Field<int>("WK")).ToArray();

                //Get the quantity of Orders for each manufacturer.
                int[] y = (from p in datarp.AsEnumerable()
                           where p.Field<string>("TH") == manuf
                           orderby p.Field<int>("WK") ascending
                           select p.Field<int>("SL")).ToArray();

                //Add Series to the Chart.
                chartSale.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series(manuf));
                chartSale.Series[manuf].IsValueShownAsLabel = true;
                chartSale.Series[manuf].BorderWidth = 3;
                chartSale.Series[manuf].ChartType = SeriesChartType.Line;
                chartSale.Series[manuf].Points.DataBindXY(x, y);
            }
            chartSale.Titles[0].Text = "Week";
            chartSale.Legends[0].Enabled = true;

            //CultureInfo ciCurr = CultureInfo.CurrentCulture;
            //int weekNum = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);


        }
        public void DataLoad_Year()
        {
            datarp = dhang.getDataReportSale_Year();
            if (datarp.Rows.Count == 0)
            {
                MessageBox.Show("No data to statistical", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            List<string> manufs = (from p in datarp.AsEnumerable()
                                   select p.Field<string>("TH")).Distinct().ToList();

            for (int th = Int32.Parse(dhang.getMinYear()); th <= Int32.Parse(dhang.getMaxYear()); th++)
            {
                List<string> x = countManuf_year(th);
                if (x.Count < manufs.Count)
                {
                    foreach (string manuf in manufs)
                    {
                        var match = x.FirstOrDefault(stringToCheck => stringToCheck.Contains(manuf));
                        if (match == null)
                        {
                            DataRow r = datarp.NewRow();
                            r["TH"] = manuf;
                            r["SL"] = 0;
                            r["YR"] = th;
                            datarp.Rows.Add(r);
                        }
                    }
                }
            }
            //Remove the Default Series.
            if (chartSale.Series.Count() == 1)
            {
                chartSale.Series.Remove(chartSale.Series[0]);
            }
            chartSale.DataBindCrossTable(datarp.DefaultView, "TH", "YR", "SL", "Label=SL");
            chartSale.Titles[0].Text = "Year";

           
            chartSale.Legends[0].Enabled = true;
        }
        public void DataLoad_Option()
        {
            DataTable top = new DataTable();
            top = dhang.getTop3Product_Option(begin,end);
            string top_product = "";
            if (top.Rows.Count != 0)
            {
                label1.Visible = true;
                lblManuf.Visible = true;
                foreach (DataRow row in top.Rows)
                {
                    top_product += row[1].ToString() + " : " + row[2].ToString() + "\n";
                }
                lblManuf.Text = top_product;
            }

            datarp = dhang.getDataReportSale_Option(begin,end);
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
            if (chartSale.Series.Count() == 1)
            {
                chartSale.Series.Remove(chartSale.Series[0]);
            }
            chartSale.DataBindCrossTable(datarp.DefaultView, "TH", "DAY", "SL", "Label=SL");

            chartSale.Titles[0].Text = "Day";
            chartSale.Legends[0].Enabled = true;

        }
        private void UC_TKSale_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            lblManuf.Visible = false;
            if (type == 0)
                DataLoad_Year();
            if (type == 1)
                DataLoad_Month();
            if(type==2)
                DataLoad_Week();
            if (type == 3)
                DataLoad_Option();
        }
    }
}
