using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra.Single;
using AForge.Imaging.Filters;
using AForge.Imaging;
using System.Diagnostics;

namespace Kreiserkennung
{
    public partial class MainForm : Form
    {
        private System.Drawing.Image baseFile;
        private Bitmap processed;

        private float minAcceptableDistortion = 0.5f;
        private float relativeDistortionLimit = 0.03f;

        ConsoleTraceListener cTL = new ConsoleTraceListener();

        LineSpectrogram lineSpectogram;

        class VectorF
        {
            /// <summary>
            /// Die Vectorangaben
            /// </summary>
            float x, y;
            /// <summary>
            /// Die X-Länge des Vectors
            /// </summary>
            public float X
            {
                get
                {
                    return x;
                }
                set
                {
                    x = value;
                }
            }
            /// <summary>
            /// Die Y-Länge des Vectors
            /// </summary>
            public float Y
            {
                get
                {
                    return y;
                }
                set
                {
                    y = value;
                }
            }

            /// <summary>
            /// Rechnet einen Winkel von Grad in Bogenmaß um
            /// </summary>
            /// <param name="angel">Der Winkel in Grad</param>
            /// <returns>Das Bogenmaß</returns>
            public static double GetRad(float angel)
            {
                return ((System.Math.PI / 180) * angel);
            }

            /// <summary>
            /// Rechnet einen Winkel von Grad in Bogenmaß um
            /// </summary>
            /// <param name="angel">Der Winkel in Grad</param>
            /// <returns>Das Bogenmaß</returns>
            public static double GetRad(double angel)
            {
                return ((System.Math.PI / 180) * angel);
            }

            /// <summary>
            /// Rechnet einen Winkel vom Bogenmaß in einen Winkel in Grad um
            /// </summary>
            /// <param name="rad">Der Winkel im Bogenmaß</param>
            /// <returns>Den Winkel in Grad</returns>
            public static double GetAngle(float rad)
            {
                return ((180 * rad) / System.Math.PI);
            }

            /// <summary>
            /// Rechnet einen Winkel vom Bogenmaß in einen Winkel in Grad um
            /// </summary>
            /// <param name="rad">Der Winkel im Bogenmaß</param>
            /// <returns>Den Winkel in Grad</returns>
            public static double GetAngle(double rad)
            {
                return ((180 * rad) / System.Math.PI);
            }

            /// <summary>
            /// Ermittelt die Distanz zweier Punkte
            /// </summary>
            /// <param name="p1">Der erste Punkt im OpenGL Koordinatensystem</param>
            /// <param name="p2">Der zweite Punkt im OpenGL Koordinatensystem</param>
            /// <returns>Die Distanz zwischen zwei Punkten</returns>
            public static double GetDistanceBetwenTwoPoints(PointF p1, PointF p2)
            {
                return System.Math.Sqrt(System.Math.Pow(p2.X - p1.X, 2) + System.Math.Pow(p2.Y - p1.Y, 2));
            }

            /// <summary>
            /// Gibt den Winkel der Linie mit den Endpunkten startPoint und endPoint zurück
            /// Die Angabe des Winkels erfolgt in Grad
            /// </summary>
            /// <param name="startPoint">Der Startpunkt der Linie</param>
            /// <param name="endPoint">Der Endpunkt der Linie</param>
            /// <returns>Den Winkel in Grad</returns>
            public static double GetAngle(PointF startPoint, PointF endPoint)
            {
                float rad = Convert.ToSingle(System.Math.Acos((endPoint.X - startPoint.X) /
                    GetDistanceBetwenTwoPoints(startPoint, endPoint)));
                if (startPoint.Y >= endPoint.Y)
                {
                    return GetAngle((2 * System.Math.PI) - rad);
                }
                else
                {
                    return GetAngle(rad);
                }
            }

            public VectorF()
            {
                X = 0;
                Y = 0;
            }

            public VectorF(float vX, float vY)
            {
                X = vX;
                Y = vY;
            }

            public VectorF(Point A, Point B)
            {
                X = B.X - A.X;
                Y = B.Y - A.Y;
            }

            public VectorF(PointF A, PointF B)
            {
                X = B.X - A.X;
                Y = B.Y - A.Y;
            }

            #region functions
            /// <summary>
            /// Gibt den Winkel des Vectors im Bogenmaß zurück
            /// </summary>
            /// <returns></returns>
            public double GetRad()
            {
                return GetRad(GetAngle(new PointF(0, 0), new PointF(X, Y)));
            }

            /// <summary>
            /// Gibt den Winkel des Vectors in Grad zurück
            /// </summary>
            /// <returns></returns>
            public double GetAngle()
            {
                return GetAngle(new PointF(0, 0), new PointF(X, Y));
            }

            /// <summary>
            /// Gibt die Länge des Vectors zurück
            /// </summary>
            /// <returns></returns>
            public double GetLength()
            {
                return System.Math.Sqrt((Y * Y) + (X * X));
            }

            /// <summary>
            /// Normalisiert einen Vektor(Bildet den Orthogonalen Vector)
            /// </summary>
            public void Normalize()
            {
                float oldY = Y;
                Y = X;
                X = oldY * -1;
            }

            /// <summary>
            /// Setzt die X und Y Werte so, das die Länge des Vectors 1 ist
            /// </summary>
            public void Nominalize()
            {
                float length = (float)this.GetLength();
                X = X / (float)length;
                Y = Y / (float)length;
            }

            /// <summary>
            /// Norminalisiert einen Vector als Statische Methode
            /// </summary>
            /// <param name="orginal">Orginalvector</param>
            /// <returns>Norminaliserter Vector</returns>
            public static VectorF Normalize(VectorF orginal)
            {
                VectorF v = orginal;
                v.Normalize();
                return v;
            }

            /// <summary>
            /// Nominalize a Vector to set it's lenth to 1
            /// </summary>
            /// <param name="orginal">original vector</param>
            /// <returns>Nominalized vector</returns>
            public static VectorF Nominalize(VectorF orginal)
            {
                VectorF v = orginal;
                v.Nominalize();
                return v;
            }

            public override string ToString()
            {
                return ("X: " + X.ToString() + " Y: " + Y.ToString());
            }
            #endregion
            #region Operatoren
            public static VectorF operator +(VectorF v1, VectorF v2)
            {
                return new VectorF(v1.X + v2.X, v1.Y + v2.Y);
            }

            public static PointF operator +(PointF p, VectorF v)
            {
                return new PointF(p.X + v.X, p.Y + v.Y);
            }

            public static VectorF operator -(VectorF v1, VectorF v2)
            {
                return new VectorF(v1.X - v2.X, v1.Y - v2.Y);
            }

            public static VectorF operator *(VectorF v1, float skalar)
            {
                return new VectorF(v1.X * skalar, v1.Y * skalar);
            }

            public static VectorF operator *(VectorF v1, double skalar)
            {
                return new VectorF(v1.X * (float)skalar, v1.Y * (float)skalar);
            }

            public static VectorF operator *(float skalar, VectorF v1)
            {
                return new VectorF(v1.X * skalar, v1.Y * skalar);
            }

            public static VectorF operator *(double skalar, VectorF v1)
            {
                return new VectorF(v1.X * (float)skalar, v1.Y * (float)skalar);
            }

            public static float operator *(VectorF v1, VectorF v2)
            {
                return ((v1.X * v2.X) + (v1.Y * v2.Y));
            }

            public static PointF operator /(PointF p, VectorF v)
            {
                return new PointF(p.X / v.X, p.Y / v.Y);
            }
            #endregion
        }

        public MainForm()
        {
            InitializeComponent();
            baseFile = null;
        }

        /// <summary>
        /// Load an image from file selected in the OFD
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void OpenImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PNG (*.png)|*.png|JPEG (*.jpeg)|*.jpeg|JPG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp|All files (*.*)|*.*";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                baseFile = Bitmap.FromFile(ofd.FileName, true);
                BaseImageBox.Image = baseFile;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load image!\n" + ex.Message);
                baseFile = null;
            }
            Grayscale gray = new Grayscale(1.0, 0.0, 0.0);
            processed = processed = gray.Apply(baseFile as Bitmap); ;
            ProcessedImageBox.Image = processed;
            if (lineSpectogram != null)
            {
                lineSpectogram.Image = processed;
            }
        }

        private void SobelFilterButton_Click(object sender, EventArgs e)
        {
            if (baseFile == null || !(baseFile is Bitmap))
                return;
            OperationSelector os = new OperationSelector();
            if (os.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            Grayscale gray = new Grayscale(1.0, 0.0, 0.0);
            BaseUsingCopyPartialFilter filter = null;
            switch (os.SelectedFunction)
            {
                case OperationSelector.Functions.reset:
                    processed = baseFile as Bitmap;
                    processed = gray.Apply(processed);
                    break;
                case OperationSelector.Functions.adaptiveSmoothing:
                    filter = new AdaptiveSmoothing();
                    break;
                case OperationSelector.Functions.differenceEdge:
                    filter = new DifferenceEdgeDetector();
                    break;
                case OperationSelector.Functions.homogenityEdge:
                    filter = new HomogenityEdgeDetector();
                    break;
                case OperationSelector.Functions.simpleEdge:
                    filter = new Edges();
                    break;
                case OperationSelector.Functions.sobelFilter:
                    filter = new SobelEdgeDetector();
                    break;
                case OperationSelector.Functions.gradient:
                    filter = new GradientFilter(os.Levels);
                    break;
                case OperationSelector.Functions.ownEdgeDetector:
                    filter = new OwnEdgeDetector();
                    break;
                case OperationSelector.Functions.quadFilter:
                    filter = new QuadrautreFilter();
                    break;
                case OperationSelector.Functions.differentialFilter:
                    filter = new DifferentialFilter();
                    break;
                default:
                    break;
                    
            }
            if (filter != null)
            {
                if (processed == null)
                {
                    processed = baseFile as Bitmap;
                    processed = gray.Apply(processed);
                }
                filter.ApplyInPlace(processed);
            }
            ProcessedImageBox.Image = processed;
            if(lineSpectogram != null)
                lineSpectogram.Image = processed;
        }

        private void CircleDetectionButton_Click(object sender, EventArgs e)
        {
            if (processed == null)
                return;
            // locate objects using blob counter
            AForge.Imaging.BlobCounter blobCounter = new AForge.Imaging.BlobCounter();
            blobCounter.ProcessImage(processed);
            AForge.Imaging.Blob[] blobs = blobCounter.GetObjectsInformation();
            Bitmap tmp = new Bitmap(processed);
            // create Graphics object to draw on the image and a pen
            Graphics g = Graphics.FromImage(tmp);
            Pen redPen = new Pen(Color.Red, 2);
            // check each object and draw circle around objects, which
            // are recognized as circles
            int AreaThreashold = AreaTrackBar.Value;
            AForge.Math.Geometry.SimpleShapeChecker shapeChecker = new AForge.Math.Geometry.SimpleShapeChecker();
            for (int i = 0, n = blobs.Length; i < n; i++)
            {
                List<AForge.IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobs[i]);
                if (blobs[i].Area <= AreaThreashold)
                    continue;

                AForge.Point center;
                Point c;
                float radius;

                if (shapeChecker.IsCircle(edgePoints, out center, out radius))
                {
                    c = new Point(Convert.ToInt32(center.X), Convert.ToInt32(center.Y));
                    g.DrawEllipse(redPen,
                        (int)(center.X - radius),
                        (int)(center.Y - radius),
                        (int)(radius * 2),
                        (int)(radius * 2));
                    g.DrawLine(Pens.Green, c + new Size(-10, 0), c + new Size(10, 0));
                    g.DrawLine(Pens.Green, c + new Size(0, -10), c + new Size(0, 10));
                }
            }

            redPen.Dispose();
            g.Dispose();
            ProcessedImageBox.Image = tmp;
        }

        private void HoughTransformButton_Click(object sender, EventArgs e)
        {
            Grayscale gray = new Grayscale(1.0, 0.0, 0.0);
            if (processed == null)
            {
                processed = baseFile as Bitmap;
                processed = gray.Apply(processed);
            }
            Bitmap tmp = new Bitmap(processed);
            // create Graphics object to draw on the image and a pen
            Graphics g = Graphics.FromImage(tmp);
            Pen redPen = new Pen(Color.Red, 2);
            HoughCircleTransformation circleTransform = new HoughCircleTransformation(DiameterTrackBar.Value);
            circleTransform.ProcessImage(processed);
            Bitmap houghCirlceImage = circleTransform.ToBitmap();
            // get circles using relative intensity
            HoughCircle[] circles = circleTransform.GetCirclesByRelativeIntensity(IntensityTrackBar.Value / 1000.0f);
            Point c;
            foreach (HoughCircle circle in circles)
            {
                c = new Point(Convert.ToInt32(circle.X), Convert.ToInt32(circle.Y));
                g.DrawEllipse(redPen,
                    (int)(circle.X - circle.Radius),
                    (int)(circle.Y - circle.Radius),
                    (int)(circle.Radius * 2),
                    (int)(circle.Radius * 2));
                g.DrawLine(Pens.Green, c + new Size(-10, 0), c + new Size(10, 0));
                g.DrawLine(Pens.Green, c + new Size(0, -10), c + new Size(0, 10));
            }
            redPen.Dispose();
            g.Dispose();
            ProcessedImageBox.Image = tmp;
        }

        public Point GetCircumcircle(Point A, Point B, Point C)
        {
            PointF centerA, centerB, circumcircleCenter;
            VectorF va;
            float k;
            centerA = new PointF(0.5f * (B.X + C.X),
                0.5f * (B.Y + C.Y));
            centerB = new PointF(0.5f * (A.X + C.X),
                0.5f * (A.Y + C.Y));
            VectorF vb;

            va = new VectorF(B, C);
            vb = new VectorF(A, C);
            va.Normalize();
            vb.Normalize();
            k = ((vb.X * (centerA.Y - centerB.Y)) - (vb.Y * (centerA.X - centerB.X))) / ((va.X * vb.Y) - (va.Y * vb.X));
            if (float.IsNaN(k) || float.IsInfinity(k))
            {
                circumcircleCenter = PointF.Empty;
                return new Point(Convert.ToInt32(circumcircleCenter.X), Convert.ToInt32(circumcircleCenter.Y));
            }
            circumcircleCenter = centerA + (va * k);
            return new Point(Convert.ToInt32(circumcircleCenter.X), Convert.ToInt32(circumcircleCenter.Y));
        }

        private byte limit(int n)
        {
            if (n < 0) return 0;
            else if (n > 255) return 255;
            return (byte)n;
        }

        private int GetDist(Point a, Point b)
        {
            return (a.X - b.X)*(a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y);
        }

        private void OwnTransformButton_Click(object sender, EventArgs e)
        {
            Grayscale gray = new Grayscale(1.0, 0.0, 0.0);
            if (processed == null)
            {
                processed = baseFile as Bitmap;
                processed = gray.Apply(processed);
            }
            Bitmap tmp = new Bitmap(processed);
            // create Graphics object to draw on the image and a pen
            Graphics g = Graphics.FromImage(tmp);
            Pen redPen = new Pen(Color.Red, 2);

            int[] linePos = new int[] { processed.Height / 3, processed.Height / 2, processed.Height * 2 / 3 };
            int[] filterParam = new int[] { -1, -3, -3, -5, -3, -3, -3, -3, 0, 3, 3, 3, 3, 5, 3, 3, 1 };

            int[,] gradients = new int[linePos.Count(), processed.Width];
            int[] max = new int[linePos.Count()];

            int level = levelTrackBar.Value;
            int shift = (filterParam.Count() - 1) / 2;
            List<Point> points = new List<Point>();

            cTL.WriteLine("Start circle detection");
            cTL.WriteLine("Search line count: " + linePos.Count().ToString());
            cTL.WriteLine("filter param count: " + filterParam.Count() + ", shift: " + shift.ToString());
            cTL.WriteLine("Level: " + level.ToString());

            //Edge filtering to smooth the result
            int i = 0;
            if (LevelSearchCheckBox.Checked)
            {
                foreach (int pos in linePos)
                {
                    for (int a = 0; a < processed.Width; a++)
                    {
                        if (processed.GetPixel(a, pos).R > level)
                        {
                            points.Add(new Point(a, linePos[i]));
                        }
                    }
                    i++;
                }
            }
            else
            {
                foreach (int pos in linePos)
                {
                    for (int a = 0; a < (processed.Width-shift); a++)
                    {
                        gradients[i, a] = 0;
                        for (int b = 0; b < filterParam.Count(); b++)
                        {
                            gradients[i, a] += limit(filterParam[b] * (((a - shift + b) < 0) ? (0) : (processed.GetPixel((a - shift)+b, pos).R)));
                        }
                        gradients[i, a] = Math.Abs(gradients[i, a]);
                        max[i] = Math.Max(max[i], gradients[i, a]);
                    }
                    i++;
                }
                for (i = 0; i < gradients.GetLength(0); i++)
                {
                    for (int a = 0; a < gradients.GetLength(1); a++)
                    {
                        gradients[i, a] = gradients[i, a] * 255 / max[i];
                    }
                }
                //Find edges by gradient detection
                for (i = 0; i < gradients.GetLength(0); i++)
                {
                    for (int a = 0; a < gradients.GetLength(1) - 1; a++)
                    {
                        if ((gradients[i, a] - gradients[i, a + 1]) > level)
                        {
                            points.Add(new Point(a, linePos[i]));
                        }
                    }
                }
            }
            cTL.WriteLine("Found " + points.Count.ToString() + " points!");
            Point _tmp;
            for (i = 0; i < points.Count -1; i++)
            {
                if (GetDist(points[i], points[i + 1]) < FilterDistanceTrackBar.Value)
                {
                    _tmp = new Point((points[i].X + points[i + 1].X)/2, (points[i].Y + points[i + 1].Y)/2);
                    points.RemoveAt(i);
                    points[i] = _tmp;
                    i--;
                }
            }
            cTL.WriteLine("Reduced points to " + points.Count.ToString() + "!");
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Draw the search lines and found points
            foreach (int a in linePos)
            {
                g.DrawLine(Pens.Red, new Point(0, a), new Point(processed.Width, a));
            }
            foreach (Point p in points)
            {
                g.DrawEllipse(Pens.Blue, p.X - 2, p.Y - 2, 4, 4);
            }
            if (WeightCenterCheckBox.Checked)
            {
                Point center = new Point(0, 0);
                int count = 0;
                if (points.Count() != 0)
                {
                    foreach (Point p in points)
                    {
                        center.X += p.X;
                        center.Y += p.Y;
                        count++;
                    }
                    center.X /= count;
                    center.Y /= count;
                    g.DrawLine(Pens.Orange, center - new Size(20, 0), center + new Size(20, 0));
                    g.DrawLine(Pens.Orange, center - new Size(0, 20), center + new Size(0, 20));
                }
            }
            if (SearchCentersCheckBox.Checked)
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////
                //Get every combination of 3 points, calculate the center point of the corresponding circle and save it
                List<Point> centers = new List<Point>();
                int counter = 0;
                for (i = 0; i < points.Count(); i++)
                {
                    for (int a = i + 1; a < points.Count(); a++)
                    {
                        for (int b = a + 1; b < points.Count(); b++)
                        {
                            if (points[a].Y == points[b].Y && points[a].Y == points[i].Y)   //Three points on the same line, skip
                            {
                                continue;
                            }
                            counter++;
                            centers.Add(GetCircumcircle(points[i], points[a], points[b]));      //Calculate all the centers
                        }
                    }
                }
                cTL.WriteLine("Checked " + counter.ToString() + " triangle circumcircle centers!");
                /////////////////////////////////////////////////////////////////////////////////////////////////////////
                //Draw all the centers
                foreach (Point p in centers)
                {
                    g.DrawLine(Pens.Green, p + new Size(-10, 0), p + new Size(10, 0));
                    g.DrawLine(Pens.Green, p + new Size(0, -10), p + new Size(0, 10));
                }
                /////////////////////////////////////////////////////////////////////////////////////////////////////////
                //Calculate the center 
            }
            redPen.Dispose();
            g.Dispose();
            ProcessedImageBox.Image = tmp;
        }

        private void LineSpectogramButton_Click(object sender, EventArgs e)
        {
            lineSpectogram = new LineSpectrogram();
            lineSpectogram.Image = processed;
            lineSpectogram.Show();
            lineSpectogram.FormClosed += lineSpectogram_FormClosed;
        }

        void lineSpectogram_FormClosed(object sender, FormClosedEventArgs e)
        {
            lineSpectogram = null;
        }

        public static Bitmap resizeImage(Bitmap imgToResize, Size size)
        {
            return (new Bitmap(imgToResize, size));
        }
        
        private void FourierButton_Click(object sender, EventArgs e)
        {
            if (processed == null)
            {
                processed = baseFile as Bitmap;
            }
            Grayscale gray = new Grayscale(1.0, 0.0, 0.0);
            int newWidth, newHeight, tmp = processed.Width;
            for (newWidth = 0; tmp > 0; newWidth++) tmp /= 2;
            tmp = processed.Height;
            for (newHeight = 0; tmp > 0; newHeight++) tmp /= 2;
            newWidth = 1 << (newWidth - 2);
            newHeight = 1 << (newHeight - 2);
            processed = resizeImage(processed, new Size(newWidth, newWidth));
            processed = gray.Apply(processed);
            ComplexImage complexImage = ComplexImage.FromBitmap(processed);
            // do forward Fourier transformation
            complexImage.ForwardFourierTransform();
            // get complex image as bitmat
            processed = complexImage.ToBitmap();
            ProcessedImageBox.Image = processed;
        }

        private void RotateButton_Click(object sender, EventArgs e)
        {
            if (processed == null)
                return;
            processed.RotateFlip(RotateFlipType.Rotate90FlipNone);
            if (lineSpectogram != null)
                lineSpectogram.Image = processed;
            ProcessedImageBox.Image = processed;
        }
    }
}