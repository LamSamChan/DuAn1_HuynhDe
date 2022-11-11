using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace DuAn1_HuynhDe
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            //resize window
            //this.SetStyle(ControlStyles.ResizeRedraw,true);
        }
        //resize window
        /*private const int cGrip = 16;
        private const int cCaption = 32;*/

        /*protected override void WndProc(ref Message m)
        {
            if (m.Msg ==0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);

                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m); 
        }*/

        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form ChildFormCurrent;
        private void Form1_Load(object sender, EventArgs e)
        {
            // Load logo;
            Image image = Image.FromFile(@"D:\Fpoly\Img_logoHuynhde\Logo.png");
            bt_Home.Image = image;
            //Load form maxsize
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            PanelMainLogo.Controls.Add(leftBorderBtn);
        }
        //Methods
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(237,171,236);
            //public static Color color2 = Color.FromArgb(39, 80, 104);
            //public static Color color3 = Color.FromArgb(39, 80, 104);
            //public static Color color4 = Color.FromArgb(39, 80, 104);
        }

        private void ActionButton(object btnsender, Color color)
        {

            DisableBtn();
            if (btnsender != null)
            {
                currentBtn = (IconButton)btnsender;
                currentBtn.BackColor = Color.FromArgb(254, 244, 245);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                // left border btn

                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                //Icon HomeForm
                 IconHomeMain.IconChar = currentBtn.IconChar;
                 IconHomeMain.IconColor = color;
                

            }
        }

        private void DisableBtn()
        {
            if (currentBtn != null)
            {

                currentBtn.BackColor = Color.FromArgb(138, 98, 236);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;

            }
        }

        //oppem Child form
        private void OppenChildForm(Form childForm)
        {
            if (ChildFormCurrent != null)
            {
                // chỉ mở form con khi  icon home có hiện icon form con
                ChildFormCurrent.Close();
            }
            ChildFormCurrent = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDeskTop.Controls.Add(childForm);
            panelDeskTop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            label1.Text = childForm.Text;
        }


        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            ActionButton(sender, RGBColors.color1);
            OppenChildForm(new FormQuanTri());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActionButton(sender, RGBColors.color1);
            OppenChildForm(new FormNhanVien());

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActionButton(sender, RGBColors.color1);

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ActionButton(sender, RGBColors.color1);

        }

        private void btnExits_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaxSize_Click(object sender, EventArgs e)
        {
            if (btnMaxSize.Text.ToString() == "❐")
            {
                this.WindowState = FormWindowState.Normal;
                this.CenterToScreen();
                btnMaxSize.Text = "☐";
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                btnMaxSize.Text = "❐";
            }
        }

        private void BtnMinSize_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;
        }

        private void bt_Home_Click(object sender, EventArgs e)
        {
            ChildFormCurrent.Close();
            label1.Text = "Home";
            ResetForm();
        }
        // resert click tren form
        private void ResetForm()
        {
            DisableBtn();
            leftBorderBtn.Visible = false;
            IconHomeMain.IconChar = IconChar.HomeUser;
            IconHomeMain.IconColor = Color.PowderBlue;
        }

        //move window
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);

                if (this.WindowState == FormWindowState.Normal)
                {
                    btnMaxSize.Text = "☐";
                }
            }
        }

       
    }
}
