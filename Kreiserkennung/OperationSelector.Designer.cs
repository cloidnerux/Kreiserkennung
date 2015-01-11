namespace Kreiserkennung
{
    partial class OperationSelector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AbortButton = new System.Windows.Forms.Button();
            this.SobelFilterButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.DifferenceEdgeDetctorButton = new System.Windows.Forms.Button();
            this.SimpleEdgeDetectorButton = new System.Windows.Forms.Button();
            this.HomogenityEdgeDetection = new System.Windows.Forms.Button();
            this.AdaptiveSmoothingButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.LevelsTrackBar = new System.Windows.Forms.TrackBar();
            this.LevelsLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.differentialFilterButton = new System.Windows.Forms.Button();
            this.QuadratureFilterButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LevelsTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // AbortButton
            // 
            this.AbortButton.Location = new System.Drawing.Point(217, 177);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(154, 61);
            this.AbortButton.TabIndex = 0;
            this.AbortButton.Text = "Abbrechen";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            // 
            // SobelFilterButton
            // 
            this.SobelFilterButton.Location = new System.Drawing.Point(12, 71);
            this.SobelFilterButton.Name = "SobelFilterButton";
            this.SobelFilterButton.Size = new System.Drawing.Size(177, 23);
            this.SobelFilterButton.TabIndex = 1;
            this.SobelFilterButton.Text = "Sobel Filter";
            this.SobelFilterButton.UseVisualStyleBackColor = true;
            this.SobelFilterButton.Click += new System.EventHandler(this.SobelFilterButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(12, 13);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(177, 23);
            this.ResetButton.TabIndex = 2;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // DifferenceEdgeDetctorButton
            // 
            this.DifferenceEdgeDetctorButton.Location = new System.Drawing.Point(12, 100);
            this.DifferenceEdgeDetctorButton.Name = "DifferenceEdgeDetctorButton";
            this.DifferenceEdgeDetctorButton.Size = new System.Drawing.Size(177, 23);
            this.DifferenceEdgeDetctorButton.TabIndex = 3;
            this.DifferenceEdgeDetctorButton.Text = "Difference Edge Detector";
            this.DifferenceEdgeDetctorButton.UseVisualStyleBackColor = true;
            this.DifferenceEdgeDetctorButton.Click += new System.EventHandler(this.DifferenceEdgeDetctorButton_Click);
            // 
            // SimpleEdgeDetectorButton
            // 
            this.SimpleEdgeDetectorButton.Location = new System.Drawing.Point(12, 129);
            this.SimpleEdgeDetectorButton.Name = "SimpleEdgeDetectorButton";
            this.SimpleEdgeDetectorButton.Size = new System.Drawing.Size(177, 23);
            this.SimpleEdgeDetectorButton.TabIndex = 4;
            this.SimpleEdgeDetectorButton.Text = "Simple Edge Detection";
            this.SimpleEdgeDetectorButton.UseVisualStyleBackColor = true;
            this.SimpleEdgeDetectorButton.Click += new System.EventHandler(this.SimpleEdgeDetectorButton_Click);
            // 
            // HomogenityEdgeDetection
            // 
            this.HomogenityEdgeDetection.Location = new System.Drawing.Point(12, 158);
            this.HomogenityEdgeDetection.Name = "HomogenityEdgeDetection";
            this.HomogenityEdgeDetection.Size = new System.Drawing.Size(177, 23);
            this.HomogenityEdgeDetection.TabIndex = 5;
            this.HomogenityEdgeDetection.Text = "Homogenity Edge Detection";
            this.HomogenityEdgeDetection.UseVisualStyleBackColor = true;
            this.HomogenityEdgeDetection.Click += new System.EventHandler(this.HomogenityEdgeDetection_Click);
            // 
            // AdaptiveSmoothingButton
            // 
            this.AdaptiveSmoothingButton.Location = new System.Drawing.Point(12, 42);
            this.AdaptiveSmoothingButton.Name = "AdaptiveSmoothingButton";
            this.AdaptiveSmoothingButton.Size = new System.Drawing.Size(177, 23);
            this.AdaptiveSmoothingButton.TabIndex = 6;
            this.AdaptiveSmoothingButton.Text = "Adaptive Smoothing";
            this.AdaptiveSmoothingButton.UseVisualStyleBackColor = true;
            this.AdaptiveSmoothingButton.Click += new System.EventHandler(this.AdaptiveSmoothingButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Gradient Filter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LevelsTrackBar
            // 
            this.LevelsTrackBar.Location = new System.Drawing.Point(217, 13);
            this.LevelsTrackBar.Maximum = 20;
            this.LevelsTrackBar.Minimum = 1;
            this.LevelsTrackBar.Name = "LevelsTrackBar";
            this.LevelsTrackBar.Size = new System.Drawing.Size(104, 45);
            this.LevelsTrackBar.TabIndex = 8;
            this.LevelsTrackBar.Value = 1;
            this.LevelsTrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // LevelsLabel
            // 
            this.LevelsLabel.AutoSize = true;
            this.LevelsLabel.Location = new System.Drawing.Point(227, 42);
            this.LevelsLabel.Name = "LevelsLabel";
            this.LevelsLabel.Size = new System.Drawing.Size(44, 13);
            this.LevelsLabel.TabIndex = 9;
            this.LevelsLabel.Text = "Levels: ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 215);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "own Edge Detector";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // differentialFilterButton
            // 
            this.differentialFilterButton.Location = new System.Drawing.Point(12, 244);
            this.differentialFilterButton.Name = "differentialFilterButton";
            this.differentialFilterButton.Size = new System.Drawing.Size(177, 23);
            this.differentialFilterButton.TabIndex = 11;
            this.differentialFilterButton.Text = "differential Filter";
            this.differentialFilterButton.UseVisualStyleBackColor = true;
            this.differentialFilterButton.Click += new System.EventHandler(this.differentialFilterButton_Click);
            // 
            // QuadratureFilterButton
            // 
            this.QuadratureFilterButton.Location = new System.Drawing.Point(12, 273);
            this.QuadratureFilterButton.Name = "QuadratureFilterButton";
            this.QuadratureFilterButton.Size = new System.Drawing.Size(177, 23);
            this.QuadratureFilterButton.TabIndex = 12;
            this.QuadratureFilterButton.Text = "Quadrature filter";
            this.QuadratureFilterButton.UseVisualStyleBackColor = true;
            this.QuadratureFilterButton.Click += new System.EventHandler(this.QuadratureFilterButton_Click);
            // 
            // OperationSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 300);
            this.Controls.Add(this.QuadratureFilterButton);
            this.Controls.Add(this.differentialFilterButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.LevelsLabel);
            this.Controls.Add(this.LevelsTrackBar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AdaptiveSmoothingButton);
            this.Controls.Add(this.HomogenityEdgeDetection);
            this.Controls.Add(this.SimpleEdgeDetectorButton);
            this.Controls.Add(this.DifferenceEdgeDetctorButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.SobelFilterButton);
            this.Controls.Add(this.AbortButton);
            this.Name = "OperationSelector";
            this.Text = "OperationSelector";
            ((System.ComponentModel.ISupportInitialize)(this.LevelsTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.Button SobelFilterButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button DifferenceEdgeDetctorButton;
        private System.Windows.Forms.Button SimpleEdgeDetectorButton;
        private System.Windows.Forms.Button HomogenityEdgeDetection;
        private System.Windows.Forms.Button AdaptiveSmoothingButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar LevelsTrackBar;
        private System.Windows.Forms.Label LevelsLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button differentialFilterButton;
        private System.Windows.Forms.Button QuadratureFilterButton;
    }
}