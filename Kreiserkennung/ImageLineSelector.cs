using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kreiserkennung
{
    public partial class ImageLineSelector : UserControl
    {
        private Point p1;
        private Point p2;

        public delegate void OnPointChanged();
        public event OnPointChanged OnPointChangedEvent;

        private Size oldSize;

        bool moveP1;
        bool moveP2;

        public int CircleSize
        {
            get;
            set;
        }

        public Point P1
        {
            get
            {
                if (BackgroundImage == null)
                    return p1;
                return new Point(p1.X * BackgroundImage.Width / this.Width, p1.Y * BackgroundImage.Height / this.Height);
            }
            set
            {
                if (BackgroundImage != null)
                    p1 = new Point(value.X * this.Width / BackgroundImage.Width, value.Y * this.Height / BackgroundImage.Height);
                else
                    p1 = value;
            }
        }

        public Point P2
        {
            get
            {
                if (BackgroundImage == null)
                    return p1;
                return new Point(p2.X * BackgroundImage.Width / this.Width, p2.Y * BackgroundImage.Height / this.Height);
            }
            set
            {
                if (BackgroundImage != null)
                    p2 = new Point(value.X * this.Width / BackgroundImage.Width, value.Y * this.Height / BackgroundImage.Height);
                else
                    p2 = value;
            }
        }

        /// <summary>
        /// Base constructor
        /// </summary>
        public ImageLineSelector()
        {
            InitializeComponent();
            CircleSize = 6;
            moveP1 = false;
            moveP2 = false;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            p1 = new Point(10, this.Height / 2);
            p2 = new Point(this.Width - 10, this.Height / 2);
            oldSize = this.Size;
            this.Invalidate();
        }

        /// <summary>
        /// Overload of draw method, used to draw the lines and circles
        /// </summary>
        /// <param name="e">Event parameter</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (p1 == null || p2 == null || BackgroundImage == null)
                return;
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.FillEllipse(Brushes.Blue, p1.X - CircleSize, p1.Y - CircleSize, 2 * CircleSize, 2 * CircleSize);
            g.FillEllipse(Brushes.Blue, p2.X - CircleSize, p2.Y - CircleSize, 2 * CircleSize, 2 * CircleSize);
            float l1 = 0.0f, l2 = 0.0f;   //Real boundarys for vector line
            int x = p2.X - p1.X;
            int y = p2.Y - p1.Y;
            if (x == 0 && y == 0)
                    return;
            float r1 = 0.0f, r2 = 0.0f, s1 = 0.0f, s2 = 0.0f;   //Factor for p1+µ*P1P2 to cross X=0, Y=0, X=Width, Y=Width
            if (x != 0)   //more horizontally
            {
                r1 = -(float)p1.X / (float)x;
                r2 = (float)(this.Width - p1.X) / (float)x;
            }
            if (y != 0)
            {
                s1 = -(float)p1.Y / (float)y;
                s2 = (float)(this.Height - p1.Y) / (float)y;
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
            if ((p1.Y + y * r1) >= 0 && (p1.Y + y * r1) <= this.Height && r1 != float.NaN)
            {
                l1 = r1;
                r1 = float.NaN;
            }
            else if ((p1.X + x * s1) >= 0 && (p1.X + x * s1) <= this.Width && s1 != float.NaN)
            {
                l1 = s1;
                s1 = float.NaN;
            }
            else if ((p1.X + x * s2) >= 0 && (p1.X + x * s2) <= this.Width && s2 != float.NaN)
            {
                l1 = s2;
                s2 = float.NaN;
            }

            if ((p1.Y + y * r1) >= 0 && (p1.Y + y * r1) <= this.Height && r1 != float.NaN)
            {
                l2 = r1;
            }
            else if ((p1.X + x * s1) >= 0 && (p1.X + x * s1) <= this.Width && s1 != float.NaN)
            {
                l2 = s1;
            }
            else if ((p1.X + x * s2) >= 0 && (p1.X + x * s2) <= this.Width && s2 != float.NaN)
            {
                l2 = s2;
            }
            else if ((p1.Y + y * r2) >= 0 && (p1.Y + y * r2) <= this.Height && r2 != float.NaN)
            {
                l2 = r2;
            }
            
            g.DrawLine(Pens.Red, new Point((int)(p1.X + x * l1), (int)(p1.Y + y * l1)), new Point((int)(p1.X + x * l2), (int)(p1.Y + y * l2)));
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (p1 == null || p2 == null || BackgroundImage == null)
                return;
            int x = e.X - p1.X;
            int y = e.Y - p1.Y;
            if (Math.Sqrt(x * x + y * y) < 20)
            {
                moveP1 = true;
                return;
            }
            x = e.X - p2.X;
            y = e.Y - p2.Y;
            if (Math.Sqrt(x * x + y * y) < 20)
            {
                moveP2 = true;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;
            moveP1 = false;
            moveP2 = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if(moveP1)
            {
                p1 = new Point(e.X, e.Y);
                if (OnPointChangedEvent != null)
                {
                    OnPointChangedEvent();
                }
                this.Invalidate();
                return;
            }
            if(moveP2)
            {
                p2 = new Point(e.X, e.Y);
                if (OnPointChangedEvent != null)
                {
                    OnPointChangedEvent();
                }
                this.Invalidate();
                return;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (oldSize != Size.Empty && oldSize != this.Size)
            {
                p1.X = p1.X * Size.Width / oldSize.Width;
                p2.X = p2.X * Size.Width / oldSize.Width;

                p1.Y = p1.Y * Size.Height / oldSize.Height;
                p2.Y = p2.Y * Size.Height / oldSize.Height;
                this.Invalidate();
            }
            oldSize = this.Size;
        }
    }
}
