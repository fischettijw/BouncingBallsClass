using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BouncingBallsClass
{
    public partial class FrmBouncingBalls : Form
    {
        Timer Draw;
        //Color BackgroundColor;
        Brush BackgroundBrush;

        int x, y, dx, dy;
        int ballSize = 50;
        public FrmBouncingBalls()
        {
            InitializeComponent();
        }

        private void FrmBouncingBalls_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            //BackgroundColor = Color.AntiqueWhite;
            BackgroundBrush = Brushes.AntiqueWhite;
            x = 0;
            y = 0;
            dx = 2;
            dy = 2;

            //this.BackColor = BackgroundColor;
            this.Paint += FrmBouncingBalls_Paint;

            Draw = new Timer();
            Draw.Interval = 10;
            Draw.Tick += Draw_Tick;
            Draw.Enabled = false;
        }

        private void FrmBouncingBalls_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //e.Graphics.FillRectangle(BackgroundBrush, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height);
            e.Graphics.FillEllipse(Brushes.Red, x, y, ballSize, ballSize);
            e.Graphics.DrawLine(new Pen(Color.Red, 5), 50, 200, 400, 210);
        }

        private void Draw_Tick(object sender, EventArgs e)
        {
            if (((x + ballSize) > this.ClientRectangle.Width) || x < 0) dx = -1 * dx;
            if (((y + ballSize) > this.ClientRectangle.Height) || y < 0) dy = -1 * dy;
            x += dx;
            y += dy;

            this.Refresh();
        }
    }
}
