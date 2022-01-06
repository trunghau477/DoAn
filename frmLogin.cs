using QLKTX.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKTX
{
    public partial class frmLogin : Form
    {
        KTXDBContext context = new KTXDBContext();
        public static string role = "";
        public static string userlogin = "";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text != "" && txtPass.Text != "")
            {
                ACCOUNT user = context.ACCOUNT.FirstOrDefault(p => p.USER == txtUser.Text && p.PASS == txtPass.Text);
                if (user != null)
                {
                    if (user.QUYEN == "ADMIN"  )
                    {
                        frmKTX f = new frmKTX();
                        this.Hide();
                        role = "ADMIN";
                        userlogin = user.MANV;
                        f.ShowDialog();
                    }
                    else if(user.QUYEN == "MANAGE")
                    {
                        frmKTX f = new frmKTX();
                        this.Hide();
                        role = "MANAGE";
                        userlogin = user.MANV;
                        f.ShowDialog();
                    }    
                    else
                    {
                     //   frmSinhVien f = new frmSinhVien();
                       // this.Hide();
                     //   userlogin = user.CCCD;
                      //  f.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }

        private void cbRememberMe_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUser.Text != null && txtPass.Text != null)
                {
                    if (cbRememberMe.Checked == true)
                    {
                        string username = txtUser.Text;
                        string password = txtPass.Text;
                        Properties.Settings.Default.User = username;
                        Properties.Settings.Default.Pass = password;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.Reset();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPass_IconRightClick(object sender, EventArgs e)
        {
            if (txtPass.UseSystemPasswordChar)
            {
                txtPass.UseSystemPasswordChar = false;
                //txtPass.IconRight = Properties.Resources.Done_3;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
