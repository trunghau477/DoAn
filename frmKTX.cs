using FontAwesome.Sharp;
using QLKTX.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKTX
{
    public partial class frmKTX : Form
    {
        KTXDBContext context = new KTXDBContext();
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        public frmKTX()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            pnMenu.Controls.Add(leftBorderBtn);
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            //this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                //leftBorderBtn.BackColor = color;
                //leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                //leftBorderBtn.Visible = true;
                //leftBorderBtn.BringToFront();
                //Current Child Form Icon
                iconCurrentHome.IconChar = currentBtn.IconChar;
                iconCurrentHome.IconColor = color;
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.WhiteSmoke;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.WhiteSmoke;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void hidePnMenu()
        {
            pnSystem.Visible = false;
            pnCategory.Visible = false;
            pnTransaction.Visible = false;
            pnThongKe.Visible = false;
        }
        //click danh muc -> show menu
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hidePnMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void btnHeThong_Click(object sender, EventArgs e)
        {
            showSubMenu(pnSystem);
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            showSubMenu(pnCategory);
        }

        private void btnGiaoDich_Click(object sender, EventArgs e)
        {
            showSubMenu(pnTransaction);
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            showSubMenu(pnThongKe);
        }
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnDesktop.Controls.Add(childForm);
            pnDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }

        private void btnQLTK_Click(object sender, EventArgs e)
        {
                ActivateButton(sender, RGBColors.color1);
                OpenChildForm(new frmQLAccount());
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new frmQLThongTinNV());
        }

        private void btnSV_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new frmQLThongTinSV());
        }

        private void btnToa_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new frmAddBuilding());
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new frmAddRoom());
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            
        }
        private void btnReportHoaDon_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
        //    OpenChildForm(new frmReportHoaDon());
        }
        private void btnThongKeNV_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new frmThongKeNV());
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentHome.IconChar = IconChar.Home;
            iconCurrentHome.IconColor = Color.OrangeRed;
            lblTitleChildForm.Text = "TRANG CHỦ";
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            Reset();
        }
        //Thời gian hiện hành
        private void timer1_Tick(object sender, EventArgs e)
        {
            NHANVIEN NV = context.NHANVIEN.FirstOrDefault();
            lbXinChao.Text = NV.HOTENNV.ToString();
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lblDate.Text = DateTime.Now.ToString("dddd, dd MMMM, yyyy");
        }
        private void FormLogin()
        {
            frmLogin FormLogin = new frmLogin();
            FormLogin.ShowDialog();
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(FormLogin)); //Tạo luồng mới
            thread.Start(); //Khởi chạy luồng
            this.Close();
        }
         private void frmKTX_Load(object sender, EventArgs e)
        {
            // ACCOUNT user = new ACCOUNT();
            frmLogin frmLogin = new frmLogin();
            string quyen = frmLogin.role;
            if (quyen != "")
            {
                if (quyen == "MANAGE")
                {
                    //btnQLTK.Enabled = true;
                    btnHeThong.Visible = false;
                    btnQLTK.Visible = false;
                    pnSystem.Visible = false;
                    btnNV.Visible = false;
                }
                else
                {
                    btnHeThong.Visible = true;
                    btnQLTK.Visible = true;
                    pnSystem.Visible = true;
                    btnNV.Visible = true;
                    //btnQLTK.Enabled = false;
                }
            }
            hidePnMenu();
            timer1_Tick(sender, e);
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
