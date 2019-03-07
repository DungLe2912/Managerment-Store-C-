namespace GUI.HistorySales
{
    partial class Form_DetailSale
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPreSale = new System.Windows.Forms.Button();
            this.btnNextSale = new System.Windows.Forms.Button();
            this.dtgvSal = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dtgvOrder = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dragControl1 = new DragControlDemo.DragControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvSal)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(776, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 253);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(776, 10);
            this.panel3.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 263);
            this.panel4.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnPreSale);
            this.panel1.Controls.Add(this.btnNextSale);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 263);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 126);
            this.panel1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.DarkOrange;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(662, 80);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 37);
            this.btnClose.TabIndex = 52;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(371, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 21);
            this.label2.TabIndex = 19;
            this.label2.Text = "Page";
            // 
            // btnPreSale
            // 
            this.btnPreSale.FlatAppearance.BorderSize = 0;
            this.btnPreSale.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnPreSale.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnPreSale.Location = new System.Drawing.Point(310, 60);
            this.btnPreSale.Name = "btnPreSale";
            this.btnPreSale.Size = new System.Drawing.Size(40, 25);
            this.btnPreSale.TabIndex = 20;
            this.btnPreSale.Text = "<";
            this.btnPreSale.UseVisualStyleBackColor = true;
            this.btnPreSale.Click += new System.EventHandler(this.btnPreSale_Click);
            // 
            // btnNextSale
            // 
            this.btnNextSale.FlatAppearance.BorderSize = 0;
            this.btnNextSale.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnNextSale.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnNextSale.Location = new System.Drawing.Point(443, 61);
            this.btnNextSale.Name = "btnNextSale";
            this.btnNextSale.Size = new System.Drawing.Size(40, 25);
            this.btnNextSale.TabIndex = 21;
            this.btnNextSale.Text = ">";
            this.btnNextSale.UseVisualStyleBackColor = true;
            this.btnNextSale.Click += new System.EventHandler(this.btnNextSale_Click);
            // 
            // dtgvSal
            // 
            this.dtgvSal.AllowUserToAddRows = false;
            this.dtgvSal.AllowUserToDeleteRows = false;
            this.dtgvSal.AllowUserToResizeColumns = false;
            this.dtgvSal.AllowUserToResizeRows = false;
            this.dtgvSal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvSal.Location = new System.Drawing.Point(10, 128);
            this.dtgvSal.Name = "dtgvSal";
            this.dtgvSal.RowHeadersVisible = false;
            this.dtgvSal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvSal.Size = new System.Drawing.Size(766, 135);
            this.dtgvSal.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Lime;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Location = new System.Drawing.Point(10, 81);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(766, 48);
            this.panel5.TabIndex = 5;
            // 
            // dtgvOrder
            // 
            this.dtgvOrder.AllowUserToAddRows = false;
            this.dtgvOrder.AllowUserToDeleteRows = false;
            this.dtgvOrder.AllowUserToResizeColumns = false;
            this.dtgvOrder.AllowUserToResizeRows = false;
            this.dtgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvOrder.Location = new System.Drawing.Point(10, 10);
            this.dtgvOrder.Name = "dtgvOrder";
            this.dtgvOrder.RowHeadersVisible = false;
            this.dtgvOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvOrder.Size = new System.Drawing.Size(766, 73);
            this.dtgvOrder.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(314, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 23);
            this.label1.TabIndex = 20;
            this.label1.Text = "Detail Order";
            // 
            // dragControl1
            // 
            this.dragControl1.SelectControl = this.panel1;
            // 
            // Form_DetailSale
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(786, 389);
            this.Controls.Add(this.dtgvOrder);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.dtgvSal);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_DetailSale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_DetailSale";
            this.Load += new System.EventHandler(this.Form_DetailSale_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvSal)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dtgvOrder;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dtgvSal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPreSale;
        private System.Windows.Forms.Button btnNextSale;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private DragControlDemo.DragControl dragControl1;
    }
}