using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DuAn1_HuynhDe
{
    class PanelLinearGradient : Panel
    {
        public Color ColorTop { get; set; }
        public Color ColorBottom { get; set; }
        public Color Colorleft { get; set; }
        public Color ColorRight { get; set; }
        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush lgb = new LinearGradientBrush(this.ClientRectangle,this.ColorTop,this.ColorBottom, 90F);
            LinearGradientBrush lgb1 = new LinearGradientBrush(this.ClientRectangle,this.ColorRight, this.Colorleft, 180F);
            Graphics g = e.Graphics;
            g.FillRectangle(lgb,this.ClientRectangle);
            g.FillRectangle(lgb1,this.ClientRectangle);
            base.OnPaint(e);
        }
    }
}
