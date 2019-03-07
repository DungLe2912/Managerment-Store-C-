using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainForm : Form
    {
        int PanelWidth;
        bool isCollapsed;
        private int m_nLoaiNhanVien = 0;
        private string m_strUsername;
        private int m_MaNhanVien = 1;
        public MainForm()
        {
            InitializeComponent();
            timerTime.Start();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
        }
        public MainForm(int LoaiNhanVien, string strUsername, int Manhanvien)
        {
            InitializeComponent();

            // ẩn thanh slide


            // quy định:
            // 0 : admin
            // 1 : nhân viên
            this.m_nLoaiNhanVien = LoaiNhanVien;
            this.m_strUsername = strUsername;
            this.m_MaNhanVien = Manhanvien;



        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(isCollapsed)
            {
                panelLeft.Width = panelLeft.Width + 10;
                if(panelLeft.Width>=PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 10;
                if(panelLeft.Width<=79)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void moveSlidePanel(Control btn)
        {
            slidePanel.Top = btn.Top;
            slidePanel.Height = btn.Height;
        }
        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            moveSlidePanel(btnHome);
            Home.UC_Home uch = new Home.UC_Home();
            AddControlsToPanel(uch);
        }

        private void btnNhanvien_Click(object sender, EventArgs e)
        {
            moveSlidePanel(btnNhanvien);
            Employee.UC_Employee employ = new Employee.UC_Employee();
            AddControlsToPanel(employ);
        }

        private void btnKhachhang_Click(object sender, EventArgs e)
        {
            moveSlidePanel(btnHistory);
            Customer.UC_Customer history = new Customer.UC_Customer();
            AddControlsToPanel(history);
        }

        private void btnSanpham_Click(object sender, EventArgs e)
        {
            moveSlidePanel(btnSanpham);
            PhoneDetail.UC_PhoneDetail upd = new PhoneDetail.UC_PhoneDetail();
            AddControlsToPanel(upd);
        }

        private void btnMuaban_Click(object sender, EventArgs e)
        {
            moveSlidePanel(btnMuaban);
            SalePhone.UC_Sale ucs = new SalePhone.UC_Sale();
            AddControlsToPanel(ucs);
        }

        private void btnBaocao_Click(object sender, EventArgs e)
        {
            moveSlidePanel(btnBaocao);
            Report.UC_Report rp = new Report.UC_Report();
            AddControlsToPanel(rp);
        }

        private void btnThietlap_Click(object sender, EventArgs e)
        {
            moveSlidePanel(btnThietlap);
            Setting.UC_Setting set = new Setting.UC_Setting();
            AddControlsToPanel(set);
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            lbTime.Text = dt.ToString("HH:MM:ss");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timerTime.Start();
            moveSlidePanel(btnHome);
            Home.UC_Home uch = new Home.UC_Home();
            AddControlsToPanel(uch);
            if (m_nLoaiNhanVien == 0)
            {
                lbRole.Text = "Admin";
            }
            else
            {
                lbRole.Text = "Employee";
            }

            // load avatar, load tên, load chức vụ
            lbName.Text = this.m_strUsername;
            if(m_nLoaiNhanVien==1)
            {
                btnBaocao.Enabled = false;
                btnNhanvien.Enabled = false;

            }
            

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Do you wanna logout ?", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(result==DialogResult.OK)
            {
                this.Hide();
                var window = new Login();
                window.ShowDialog();
                this.Close();
            }
        }
    }
}
