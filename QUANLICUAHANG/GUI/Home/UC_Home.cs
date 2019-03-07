using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Globalization;

using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using System.Data.SqlClient;

namespace GUI.Home
{
    public partial class UC_Home : UserControl
    {
        BUS_Donhang dhang = new BUS_Donhang();
        public UC_Home()
        {
            InitializeComponent();
        }
        public bool checkData(string tmp)
        {
            var isNumeric = int.TryParse(tmp, out int n);
            if (isNumeric == false) return false;
            else if (Int32.Parse(tmp) < 0) return false;
            else return true;
        }
        public void LoadData()
        {
            int value_payment = 0;
            int value_prepay = 0;
            int purc = 0;
            int sol = 0;
            lblSold.Text = dhang.getSoldProduct();
            lblPurchase.Text = dhang.getPurchaseProduct();
            lblTotal.Text = dhang.getTotalProduct();
            DataTable sold = new DataTable();
            DataTable pur = new DataTable();
            sold = dhang.getTotalDailySold(DateTime.Now.ToShortDateString());
            pur = dhang.getTotalDailyPurchase(DateTime.Now.ToShortDateString());
            if(sold.Rows.Count==0)
            {
                lblDailyAmSold.Text = "0";
                lblDailyQtySold.Text = "0";
            }
            else
            {
                float am = 0;
                float qty = 0;
                foreach(DataRow row in sold.Rows)
                {
                    if (row[0].ToString() == "" || row[1].ToString() == "")
                        break;
                   
                    else
                    {
                        qty +=  float.Parse(row[0].ToString(), CultureInfo.InvariantCulture.NumberFormat);
                        am += float.Parse(row[1].ToString(), CultureInfo.InvariantCulture.NumberFormat);
                    }
                }
                lblDailyAmSold.Text = am.ToString();
                lblDailyQtySold.Text = qty.ToString();
            }
            if (pur.Rows.Count == 0)
            {
                lblDailyAmPur.Text = "0";
                lblDailyQtyPur.Text = "0";
            }
            else
            {
                int am = 0;
                int qty = 0;
                foreach (DataRow row in pur.Rows)
                {
                    if (row[0].ToString() == "" || row[1].ToString() == "")
                        break;
                    else
                    {
                        qty += Int32.Parse(row[0].ToString());
                        am += Int32.Parse(row[1].ToString());
                    }
                }
                lblDailyAmPur.Text = am.ToString();
                lblDailyQtyPur.Text = qty.ToString();
            }
            
            DataTable payment = new DataTable();
            payment = dhang.getTotalDailyPayment(DateTime.Now.ToShortDateString());
            DataTable prepay = new DataTable();
            prepay = dhang.getTotalDailyPrePay(DateTime.Now.ToShortDateString());
            if (payment.Rows[0][0].ToString() == "")
                value_payment = 0;
            else
                value_payment = Int32.Parse(payment.Rows[0][0].ToString());
            if (prepay.Rows[0][0].ToString() == "")
                value_prepay = 0;
            else
                value_prepay = Int32.Parse(prepay.Rows[0][0].ToString());

            if (value_prepay==0)
            {
                cirPPayment.Value = 0;
            }
            else
            {
                cirPPayment.Value = (value_prepay * 100) / value_payment;

            }
            purc = Int32.Parse(lblDailyQtyPur.Text);
            sol = Int32.Parse(lblDailyQtySold.Text);
            int k = 0;
            if (sol + purc == 0)
                cirPSoldandPur.Value = 0;
            
            else
            {
                cirPSoldandPur.Value = (sol * 100) / (sol + purc);
               
            }


           // MessageBox.Show(k.ToString());
        }
        private void UC_Home_Load(object sender, EventArgs e)
        {

            LoadData();
        }

        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

       
    }
}
