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
    public partial class OperationSelector : Form
    {
        public enum Functions
        {
            reset = 0,
            adaptiveSmoothing,
            sobelFilter,
            differenceEdge,
            simpleEdge,
            homogenityEdge,
            hough,
            gradient,
            ownEdgeDetector,
            quadFilter,
            differentialFilter
        };

        public Functions SelectedFunction;

        public int Levels
        {
            get
            {
                return LevelsTrackBar.Value;
            }
        }

        public OperationSelector()
        {
            InitializeComponent();
            SelectedFunction = Functions.reset;
            LevelsLabel.Text = "Levels: " + LevelsTrackBar.Value.ToString();
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.Close();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            this.SelectedFunction = Functions.reset;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void AdaptiveSmoothingButton_Click(object sender, EventArgs e)
        {
            this.SelectedFunction = Functions.adaptiveSmoothing;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void SobelFilterButton_Click(object sender, EventArgs e)
        {
            this.SelectedFunction = Functions.sobelFilter;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void DifferenceEdgeDetctorButton_Click(object sender, EventArgs e)
        {
            this.SelectedFunction = Functions.differenceEdge;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void SimpleEdgeDetectorButton_Click(object sender, EventArgs e)
        {
            this.SelectedFunction = Functions.simpleEdge;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void HomogenityEdgeDetection_Click(object sender, EventArgs e)
        {
            this.SelectedFunction = Functions.homogenityEdge;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.SelectedFunction = Functions.gradient;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            LevelsLabel.Text = "Levels: " + LevelsTrackBar.Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.SelectedFunction = Functions.ownEdgeDetector;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void differentialFilterButton_Click(object sender, EventArgs e)
        {
            this.SelectedFunction = Functions.differentialFilter;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void QuadratureFilterButton_Click(object sender, EventArgs e)
        {
            this.SelectedFunction = Functions.quadFilter;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
