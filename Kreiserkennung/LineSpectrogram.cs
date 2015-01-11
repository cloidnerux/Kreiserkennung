using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kreiserkennung
{
    public partial class LineSpectrogram : Form
    {
        public Bitmap Image
        {
            get
            {
                return new Bitmap(LineSelector.BackgroundImage);
            }
            set
            {
                LineSelector.BackgroundImage = (Image)value;
                LineSelector.Invalidate();
                LineSpectogram.Image = value;
            }
        }

        public LineSpectrogram()
        {
            InitializeComponent();
            LineSelector.OnPointChangedEvent += LineSelector_OnPointChangedEvent;
        }

        void LineSelector_OnPointChangedEvent()
        {
            LineSpectogram.P1 = LineSelector.P1;
            LineSpectogram.P2 = LineSelector.P2;
        }

        private void imageLineSelector1_Load(object sender, EventArgs e)
        {

        }
    }
}
