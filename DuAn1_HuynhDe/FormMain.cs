using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }

        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form ChildFormCurrent;
        private void Form1_Load(object sender, EventArgs e)
        {
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
            public static Color color1 = Color.FromArgb(205, 205, 193);
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
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
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

                currentBtn.BackColor = Color.FromArgb(1, 59, 70);
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
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
                this.WindowState = FormWindowState.Normal;
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

       
    }
}
