namespace GUI.Report
{
    partial class UC_Report
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnRev = new System.Windows.Forms.Button();
            this.btnSale = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelControl = new System.Windows.Forms.Panel();
            this.ctxbStatistics = new ChreneLib.Controls.TextBoxes.CTextBox();
            this.cmbStatistics = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cTxbMonth = new ChreneLib.Controls.TextBoxes.CTextBox();
            this.dtpk1 = new System.Windows.Forms.DateTimePicker();
            this.dtpk2 = new System.Windows.Forms.DateTimePicker();
            this.lb2 = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.panelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(10, 542);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1119, 10);
            this.panel6.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1129, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 542);
            this.panel2.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1129, 10);
            this.panel3.TabIndex = 20;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 552);
            this.panel4.TabIndex = 21;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.panel5.Controls.Add(this.cTxbMonth);
            this.panel5.Controls.Add(this.ctxbStatistics);
            this.panel5.Controls.Add(this.dtpk2);
            this.panel5.Controls.Add(this.cmbStatistics);
            this.panel5.Controls.Add(this.dtpk1);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.btnRev);
            this.panel5.Controls.Add(this.btnSale);
            this.panel5.Controls.Add(this.btnRefresh);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.panel5.Location = new System.Drawing.Point(10, 10);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1119, 54);
            this.panel5.TabIndex = 23;
            // 
            // btnRev
            // 
            this.btnRev.AutoSize = true;
            this.btnRev.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRev.FlatAppearance.BorderSize = 0;
            this.btnRev.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnRev.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnRev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRev.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRev.ForeColor = System.Drawing.Color.White;
            this.btnRev.Image = global::GUI.Properties.Resources.icons8_new_product_filled_50;
            this.btnRev.Location = new System.Drawing.Point(195, 0);
            this.btnRev.Name = "btnRev";
            this.btnRev.Size = new System.Drawing.Size(200, 54);
            this.btnRev.TabIndex = 14;
            this.btnRev.Text = "Revenue statistics";
            this.btnRev.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRev.UseVisualStyleBackColor = true;
            this.btnRev.Click += new System.EventHandler(this.btnRev_Click);
            // 
            // btnSale
            // 
            this.btnSale.AutoSize = true;
            this.btnSale.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSale.FlatAppearance.BorderSize = 0;
            this.btnSale.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnSale.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSale.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSale.ForeColor = System.Drawing.Color.White;
            this.btnSale.Image = global::GUI.Properties.Resources.icons8_new_50;
            this.btnSale.Location = new System.Drawing.Point(0, 0);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(195, 54);
            this.btnSale.TabIndex = 13;
            this.btnSale.Text = "Sale statistics";
            this.btnSale.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackgroundImage = global::GUI.Properties.Resources.icons8_refresh_30;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefresh.Location = new System.Drawing.Point(1058, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(55, 41);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.lb1);
            this.panelControl.Controls.Add(this.lb2);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(10, 64);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(1119, 478);
            this.panelControl.TabIndex = 24;
            // 
            // ctxbStatistics
            // 
            this.ctxbStatistics.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbStatistics.Location = new System.Drawing.Point(775, 16);
            this.ctxbStatistics.Name = "ctxbStatistics";
            this.ctxbStatistics.Size = new System.Drawing.Size(110, 27);
            this.ctxbStatistics.TabIndex = 17;
            this.ctxbStatistics.WaterMark = "Year";
            this.ctxbStatistics.WaterMarkActiveForeColor = System.Drawing.Color.Gray;
            this.ctxbStatistics.WaterMarkFont = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbStatistics.WaterMarkForeColor = System.Drawing.Color.LightGray;
            this.ctxbStatistics.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctxbStatistics_KeyDown);
            // 
            // cmbStatistics
            // 
            this.cmbStatistics.FormattingEnabled = true;
            this.cmbStatistics.Location = new System.Drawing.Point(546, 14);
            this.cmbStatistics.Name = "cmbStatistics";
            this.cmbStatistics.Size = new System.Drawing.Size(191, 29);
            this.cmbStatistics.TabIndex = 16;
            this.cmbStatistics.SelectedIndexChanged += new System.EventHandler(this.cmbStatistics_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(420, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "Statistics by:";
            // 
            // cTxbMonth
            // 
            this.cTxbMonth.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cTxbMonth.Location = new System.Drawing.Point(908, 16);
            this.cTxbMonth.Name = "cTxbMonth";
            this.cTxbMonth.Size = new System.Drawing.Size(110, 27);
            this.cTxbMonth.TabIndex = 18;
            this.cTxbMonth.WaterMark = "Month";
            this.cTxbMonth.WaterMarkActiveForeColor = System.Drawing.Color.Gray;
            this.cTxbMonth.WaterMarkFont = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cTxbMonth.WaterMarkForeColor = System.Drawing.Color.LightGray;
            this.cTxbMonth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cTxbMonth_KeyDown);
            // 
            // dtpk1
            // 
            this.dtpk1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpk1.Location = new System.Drawing.Point(775, 16);
            this.dtpk1.Name = "dtpk1";
            this.dtpk1.Size = new System.Drawing.Size(110, 27);
            this.dtpk1.TabIndex = 0;
            this.dtpk1.Value = new System.DateTime(2019, 1, 13, 20, 28, 41, 0);
            // 
            // dtpk2
            // 
            this.dtpk2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpk2.Location = new System.Drawing.Point(908, 16);
            this.dtpk2.Name = "dtpk2";
            this.dtpk2.Size = new System.Drawing.Size(110, 27);
            this.dtpk2.TabIndex = 1;
            this.dtpk2.Value = new System.DateTime(2019, 1, 13, 20, 29, 16, 0);
            // 
            // lb2
            // 
            this.lb2.AutoSize = true;
            this.lb2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(169)))));
            this.lb2.Location = new System.Drawing.Point(842, 71);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(34, 25);
            this.lb2.TabIndex = 11;
            this.lb2.Text = "To";
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(169)))));
            this.lb1.Location = new System.Drawing.Point(840, 17);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(62, 25);
            this.lb1.TabIndex = 12;
            this.lb1.Text = "From";
            // 
            // UC_Report
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.Name = "UC_Report";
            this.Size = new System.Drawing.Size(1139, 552);
            this.Load += new System.EventHandler(this.UC_Report_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnRev;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Panel panelControl;
        private ChreneLib.Controls.TextBoxes.CTextBox ctxbStatistics;
        private System.Windows.Forms.ComboBox cmbStatistics;
        private System.Windows.Forms.Label label1;
        private ChreneLib.Controls.TextBoxes.CTextBox cTxbMonth;
        private System.Windows.Forms.DateTimePicker dtpk2;
        private System.Windows.Forms.DateTimePicker dtpk1;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Label lb2;
    }
}
