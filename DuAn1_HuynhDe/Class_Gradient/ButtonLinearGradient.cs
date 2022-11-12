using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DuAn1_HuynhDe.Class_Gradient
{
    [DefaultEvent("Click")]
    public partial class ButtonLinearGradient : UserControl
    {
        int wh = 2;
        public Color Color1 { get; set; }
        public Color Color2 { get; set; }
        public float Angle { get; set; }
        string txt = "";
        Timer t = new Timer();
        public ButtonLinearGradient()
        {
            DoubleBuffered = true;
            t.Interval = 90;
            t.Start();
            t.Tick += (s, e) => { Angle = Angle % 360 + 1; };
            ForeColor = Color.White;
        }

        public int BorderRadius
        {
            get { return wh; }
            set { wh = value; }
        }
        public string Text
        {
            get { return txt; }
            set { txt = value; }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            GraphicsPath Gp = new GraphicsPath();
            Gp.AddArc(new Rectangle(0, 0, wh, wh), 180, 90);
            Gp.AddArc(new Rectangle(Width - wh, 0, wh, wh), -90, 90);
            Gp.AddArc(new Rectangle(Width - wh, Height - wh, wh, wh), 0, 90);
            Gp.AddArc(new Rectangle(0, Height - wh, wh, wh), 90, 90);

            e.Graphics.FillPath(new LinearGradientBrush(ClientRectangle, Color1, Color2, 90), Gp);
           e.Graphics.DrawString(txt, Font, new SolidBrush(ForeColor), ClientRectangle, new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });

            base.OnPaint(e);
        }
    }
}
