using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace Kreiserkennung
{
    public partial class ValueTrackBar : UserControl
    {
        private string valueText;
        public string ValueText
        {
            get
            {
                return valueText;
            }
            set
            {
                valueText = value;
                ValueLabel.Text = valueText + " " + TrackBar1.Value.ToString();
            }
        }

        public int Minimum
        {
            get
            {
                return TrackBar1.Minimum;
            }
            set
            {
                TrackBar1.Minimum = value;
            }
        }

        public int Maximum
        {
            get{return TrackBar1.Maximum;}
            set { TrackBar1.Maximum = value; }
        }

        public int TickFreqeuncy
        {
            get{return TrackBar1.TickFrequency;}
            set{TrackBar1.TickFrequency = value;}
        }

        public int Value
        {
            get{return TrackBar1.Value;}
            set{TrackBar1.Value = value;}
        }

        public ValueTrackBar()
        {
            InitializeComponent();
            valueText = "";
            ValueLabel.Text = valueText + " " + TrackBar1.Value.ToString();
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            ValueLabel.Text = valueText + " " + TrackBar1.Value.ToString();
        }
    }
}
