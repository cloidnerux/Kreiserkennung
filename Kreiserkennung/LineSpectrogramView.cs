using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Kreiserkennung
{
    public partial class LineSpectrogramView : UserControl
    {
        private Bitmap image;
        bool changed;
        float l1 = 0.0f, l2 = 0.0f;   //Real boundarys for vector line
        Point[] points;

        ConsoleTraceListener cTL = new ConsoleTraceListener();

        public Bitmap Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                changed = true;
                this.Invalidate();
            }
        }


        Point p1;
        public Point P1
        {
            get{return p1;}
            set
            {
                p1 = value;
                changed = true;
                this.Invalidate();
            }
        }

        Point p2;
        public Point P2
        {
            get { return p2; }
            set
            {
                p2 = value;
                changed = true;
                this.Invalidate();
            }
        }

        public LineSpectrogramView()
        {
            InitializeComponent();
            changed = false;
            points = new Point[this.Width];
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Image == null || p1 == null || p2 == null)
                return;
            try
            {
                int x = p2.X - p1.X;
                int y = p2.Y - p1.Y;
                if (changed)
                {
                    changed = false;
                    if (x == 0 && y == 0)
                        return;
                    float r1 = 0.0f, r2 = 0.0f, s1 = 0.0f, s2 = 0.0f;   //Factor for p1+µ*P1P2 to cross X=0, Y=0, X=Width, Y=Width
                    if (x != 0)   //more horizontally
                    {
                        r1 = -(float)p1.X / (float)x;
                        r2 = (float)(Image.Width - p1.X) / (float)x;
                    }
                    if (y != 0)
                    {
                        s1 = -(float)p1.Y / (float)y;
                        s2 = (float)(Image.Height - p1.Y) / (float)y;
                    }
                    if (x == 0)
                    {
                        l1 = s1;
                        l2 = s2;
                    }
                    else if (y == 0)
                    {
                        l1 = r1;
                        l2 = r2;
                    }
                    if ((p1.Y + y * r1) >= 0 && (p1.Y + y * r1) <= Image.Height && r1 != float.NaN)
                    {
                        l1 = r1;
                        r1 = float.NaN;
                    }
                    else if ((p1.X + x * s1) >= 0 && (p1.X + x * s1) <= Image.Width && s1 != float.NaN)
                    {
                        l1 = s1;
                        s1 = float.NaN;
                    }
                    else if ((p1.X + x * s2) >= 0 && (p1.X + x * s2) <= Image.Width && s2 != float.NaN)
                    {
                        l1 = s2;
                        s2 = float.NaN;
                    }

                    if ((p1.Y + y * r1) >= 0 && (p1.Y + y * r1) <= Image.Height && r1 != float.NaN)
                    {
                        l2 = r1;
                    }
                    else if ((p1.X + x * s1) >= 0 && (p1.X + x * s1) <= Image.Width && s1 != float.NaN)
                    {
                        l2 = s1;
                    }
                    else if ((p1.X + x * s2) >= 0 && (p1.X + x * s2) <= Image.Width && s2 != float.NaN)
                    {
                        l2 = s2;
                    }
                    else if ((p1.Y + y * r2) >= 0 && (p1.Y + y * r2) <= Image.Height && r2 != float.NaN)
                    {
                        l2 = r2;
                    }
                    float f = l1;
                    if (points.Count() < this.Width)
                    {
                        points = new Point[this.Width];
                    }
                    int x1, y1;
                    Bitmap tmp = new Bitmap(Image);
                    for (int i = 0; i < this.Width; i++)
                    {
                        x1 = p1.X + (int)(f * x);
                        x1 = Math.Max(0, x1);
                        x1 = Math.Min(x1, image.Width-1);
                        y1 = p1.Y + (int)(f * y);
                        y1 = Math.Max(0, y1);
                        y1 = Math.Min(y1, image.Height-1);
                        points[i] = new Point(i, this.Height - (tmp.GetPixel(x1, y1).R * this.Height / 255));
                        f = l1 + (l2 - l1) * (float)i / (float)this.Width;
                    }
                }
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawLines(Pens.Blue, points);
            }
            catch (Exception ex)
            {
                cTL.WriteLine(ex.Message);
                cTL.WriteLine(ex.StackTrace);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            changed = true;
            points = new Point[this.Width];
            this.Invalidate();
        }
    }
}
