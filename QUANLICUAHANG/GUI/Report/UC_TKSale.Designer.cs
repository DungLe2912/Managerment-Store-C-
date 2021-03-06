﻿namespace GUI.Report
{
    partial class UC_TKSale
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartSale = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.lblManuf = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartSale)).BeginInit();
            this.SuspendLayout();
            // 
            // chartSale
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSale.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            legend1.Title = "Manufacturer";
            legend1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            legend1.TitleForeColor = System.Drawing.Color.Chocolate;
            this.chartSale.Legends.Add(legend1);
            this.chartSale.Location = new System.Drawing.Point(0, 15);
            this.chartSale.Name = "chartSale";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartSale.Series.Add(series1);
            this.chartSale.Size = new System.Drawing.Size(884, 519);
            this.chartSale.TabIndex = 0;
            this.chartSale.Text = "chart1";
            title1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Year";
            title2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title2";
            title2.Text = "Total";
            title3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            title3.Name = "Title3";
            title3.Text = "Total product sale by manufacturer";
            this.chartSale.Titles.Add(title1);
            this.chartSale.Titles.Add(title2);
            this.chartSale.Titles.Add(title3);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(828, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 19);
            this.label1.TabIndex = 35;
            this.label1.Text = "Best-selling mobile manufacturers";
            // 
            // lblManuf
            // 
            this.lblManuf.AutoSize = true;
            this.lblManuf.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManuf.Location = new System.Drawing.Point(919, 211);
            this.lblManuf.Name = "lblManuf";
            this.lblManuf.Size = new System.Drawing.Size(20, 19);
            this.lblManuf.TabIndex = 36;
            this.lblManuf.Text = "a";
            // 
            // UC_TKSale
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblManuf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartSale);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.Name = "UC_TKSale";
            this.Size = new System.Drawing.Size(1119, 478);
            this.Load += new System.EventHandler(this.UC_TKSale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartSale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblManuf;
    }
}
