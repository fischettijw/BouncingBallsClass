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

namespace BouncingBallsClass
{
    public partial class FrmBouncingBalls : Form
    {
        Timer Draw;
        Color BackgroundColor;
        Brush BackgroundBrush;

        int x, y;
        public FrmBouncingBalls()
        {
            InitializeComponent();
        }

        private void FrmBouncingBalls_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            BackgroundColor = Color.AntiqueWhite;
            BackgroundBrush = Brushes.AntiqueWhite;
            x = 0;
            y = 0;

            this.BackColor = BackgroundColor;
            this.Paint += FrmBouncingBalls_Paint;

            Draw = new Timer();
            Draw.Interval = 10;
            Draw.Tick += Draw_Tick;
            Draw.Enabled = true;
        }

        private void FrmBouncingBalls_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.FillRectangle(BackgroundBrush, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height);
            e.Graphics.FillEllipse(Brushes.Red, x, y, 50, 50);
        }

        private void Draw_Tick(object sender, EventArgs e)
        {
            x += 1;
            y += 1;
            this.Refresh();
        }
    }
}
