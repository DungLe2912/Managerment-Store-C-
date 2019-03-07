using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using DTO;
using BUS;

namespace GUI
{
    public partial class Login : Form
    {
        BUS_ACCOUNT acc = new BUS_ACCOUNT();        
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = new Rectangle(400, 450, 400, 450);
            LinearGradientBrush brush = new LinearGradientBrush(r, Color.Gray, Color.LimeGreen, 180F);
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
            brush.Dispose();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = cTxbUserName.Text;
            string password = ctxbPassword.Text;
            DialogResult result;
            if (username == "")
            {
                MessageBox.Show("Username can not be blank!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = cTxbUserName;
            }
            else if (password == "")
            {
                MessageBox.Show("Password can not be blank!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = ctxbPassword;
            }
            else
            {
                if (acc.CheckAccount(username, password))
                {
                    this.Hide();
                    var window = new MainForm(Int32.Parse(acc.getLoainhanvien(cTxbUserName.Text, ctxbPassword.Text)), acc.getTennhanvien(getManhanvien()), Int32.Parse(getManhanvien()));

                    window.ShowDialog();
                    this.Close();
                }
                else
                {
                    result = MessageBox.Show("Username or password incorrect. Please try again", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (result == DialogResult.OK)
                    {
                        cTxbUserName.Text = "";
                        ctxbPassword.Text = "";
                        cTxbUserName.Focus();
                    }
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            cTxbUserName.Text = "";
            ctxbPassword.Text = "";
            this.ActiveControl = cTxbUserName;
        }

        private void btnExits_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Do you wanna exit?", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Hide();
                this.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Do you wanna exit?", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Hide();
                this.Close();
            }
        }

        private void cTxbUserName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                this.ActiveControl = ctxbPassword;
                e.IsInputKey = true;
            }
        }

        private void cTxbUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string username = cTxbUserName.Text;
                string password = ctxbPassword.Text;
                DialogResult result;
                if (username == "")
                {
                    MessageBox.Show("Username can not be blank!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.ActiveControl = cTxbUserName;
                }
                else if (password == "")
                {
                    MessageBox.Show("Password can not be blank!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.ActiveControl = ctxbPassword;
                }
                else
                {
                    if (acc.CheckAccount(username, password))
                    {
                        this.Hide();
                        var window = new MainForm(Int32.Parse(acc.getLoainhanvien(cTxbUserName.Text, ctxbPassword.Text)), acc.getTennhanvien(getManhanvien()), Int32.Parse(getManhanvien()));
                        window.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        result = MessageBox.Show("Username or password incorrect. Please try again", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (result == DialogResult.OK)
                        {
                            cTxbUserName.Text = "";
                            ctxbPassword.Text = "";
                            cTxbUserName.Focus();
                        }
                    }
                }

            }
        }

        private void ctxbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string username = cTxbUserName.Text;
                string password = ctxbPassword.Text;
                DialogResult result;
                if (username == "")
                {
                    MessageBox.Show("Username can not be blank!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.ActiveControl = cTxbUserName;
                }
                else if (password == "")
                {
                    MessageBox.Show("Password can not be blank!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.ActiveControl = ctxbPassword;
                }
                else
                {
                    if (acc.CheckAccount(username, password))
                    {
                        this.Hide();
                        var window = new MainForm(Int32.Parse(acc.getLoainhanvien(cTxbUserName.Text, ctxbPassword.Text)), acc.getTennhanvien(getManhanvien()), Int32.Parse(getManhanvien()));
                        window.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        result = MessageBox.Show("Username or password incorrect. Please try again", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (result == DialogResult.OK)
                        {
                            cTxbUserName.Text = "";
                            ctxbPassword.Text = "";
                            cTxbUserName.Focus();
                        }
                    }
                }

            }
        }
        public string getManhanvien()
        {
            return acc.getManhanvien(cTxbUserName.Text, ctxbPassword.Text);
        }
    }
}
