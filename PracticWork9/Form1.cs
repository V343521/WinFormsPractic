using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace PracticWork9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += (s, e) => DrawGraph();
        }
        private void DrawGraph()
        {
            if (!double.TryParse(txtXmin.Text, out double xmin) ||
                !double.TryParse(txtXmax.Text, out double xmax) ||
                !double.TryParse(txtStep.Text, out double step))
            {
                MessageBox.Show("Enter valid numbers in the Xmin, Xmax and Step fields!",
                                "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (xmax <= xmin)
            {
                MessageBox.Show("Xmax must be greater than Xmin!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (step <= 0)
            {
                MessageBox.Show("Step must be a positive number!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;
            if (w <= 0 || h <= 0) return;
            var bmp = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.White);
                int left = 40, right = w - 20, top = 20, bottom = h - 30;
                int plotW = right - left;
                int plotH = bottom - top;
                double ymin = -1.2, ymax = 1.2;
                Func<double, float> XtoPx = x =>
                    (float)(left + (x - xmin) / (xmax - xmin) * plotW);
                Func<double, float> YtoPx = y =>
                    (float)(bottom - (y - ymin) / (ymax - ymin) * plotH);
                DrawGrid(g, left, right, top, bottom, xmin, xmax, ymin, ymax, XtoPx, YtoPx);
                using (var axisPen = new Pen(Color.Black, 1.2f))
                {
                    float y0 = YtoPx(0);
                    float x0 = XtoPx(0);
                    g.DrawLine(axisPen, left, y0, right, y0);
                    g.DrawLine(axisPen, x0, top, x0, bottom);
                    g.DrawLine(axisPen, right, y0, right - 8, y0 - 4);
                    g.DrawLine(axisPen, right, y0, right - 8, y0 + 4);
                    g.DrawLine(axisPen, x0, top, x0 - 4, top + 8);
                    g.DrawLine(axisPen, x0, top, x0 + 4, top + 8);
                }
                DrawAxisLabels(g, left, right, top, bottom, xmin, xmax, ymin, ymax, XtoPx, YtoPx);
                using (var penSin = new Pen(Color.RoyalBlue, 2f))
                using (var penCos = new Pen(Color.Orange, 2f))
                {
                    DrawFunction(g, Math.Sin, xmin, xmax, step, XtoPx, YtoPx, penSin);
                    DrawFunction(g, Math.Cos, xmin, xmax, step, XtoPx, YtoPx, penCos);
                }
                DrawLegend(g, right, top);
            }
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = bmp;
        }
        private void DrawGrid(Graphics g, int left, int right, int top, int bottom,
                              double xmin, double xmax, double ymin, double ymax,
                              Func<double, float> XtoPx, Func<double, float> YtoPx)
        {
            using (var minorPen = new Pen(Color.FromArgb(230, 230, 230), 1f))
            using (var majorPen = new Pen(Color.FromArgb(180, 180, 180), 1f))
            {
                for (double x = Math.Ceiling(xmin * 2) / 2; x <= xmax; x += 0.5)
                {
                    float px = XtoPx(x);
                    bool isMajor = Math.Abs(x - Math.Round(x)) < 1e-9;
                    g.DrawLine(isMajor ? majorPen : minorPen, px, top, px, bottom);
                }
                for (double y = Math.Ceiling(ymin * 2) / 2; y <= ymax; y += 0.5)
                {
                    float py = YtoPx(y);
                    bool isMajor = Math.Abs(y - Math.Round(y)) < 1e-9;
                    g.DrawLine(isMajor ? majorPen : minorPen, left, py, right, py);
                }
            }
        }
        private void DrawAxisLabels(Graphics g, int left, int right, int top, int bottom,
                                    double xmin, double xmax, double ymin, double ymax,
                                    Func<double, float> XtoPx, Func<double, float> YtoPx)
        {
            using (var font = new Font("Segoe UI", 7.5f))
            using (var brush = new SolidBrush(Color.Black))
            {
                for (double x = Math.Ceiling(xmin * 2) / 2; x <= xmax; x += 0.5)
                {
                    float px = XtoPx(x);
                    string label = x.ToString("0.#");
                    var size = g.MeasureString(label, font);
                    g.DrawString(label, font, brush, px - size.Width / 2, bottom + 2);
                }

                for (double y = Math.Ceiling(ymin * 2) / 2; y <= ymax; y += 0.5)
                {
                    if (Math.Abs(y) < 1e-9) continue;
                    float py = YtoPx(y);
                    string label = y.ToString("0.#");
                    var size = g.MeasureString(label, font);
                    g.DrawString(label, font, brush, left - size.Width - 3, py - size.Height / 2);
                }
            }
        }
        private void DrawFunction(Graphics g, Func<double, double> f,
                                  double xmin, double xmax, double step,
                                  Func<double, float> XtoPx, Func<double, float> YtoPx,
                                  Pen pen)
        {
            PointF? prev = null;
            for (double x = xmin; x <= xmax + 1e-9; x += step)
            {
                double y = f(x);
                var pt = new PointF(XtoPx(x), YtoPx(y));
                if (prev.HasValue)
                    g.DrawLine(pen, prev.Value, pt);
                prev = pt;
            }
        }
        private void DrawLegend(Graphics g, int right, int top)
        {
            int lx = right - 90;
            int ly = top + 10;
            using (var font = new Font("Segoe UI", 9f))
            using (var brush = new SolidBrush(Color.Black))
            using (var penSin = new Pen(Color.RoyalBlue, 2.5f))
            using (var penCos = new Pen(Color.Orange, 2.5f))
            {
                g.DrawLine(penSin, lx, ly + 6, lx + 25, ly + 6);
                g.DrawString("sin(x)", font, brush, lx + 30, ly);
                g.DrawLine(penCos, lx, ly + 26, lx + 25, ly + 26);
                g.DrawString("cos(x)", font, brush, lx + 30, ly + 20);
            }
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            DrawGraph();
        }
    }
}