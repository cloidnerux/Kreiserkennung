namespace Kreiserkennung
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenImageButton = new System.Windows.Forms.Button();
            this.SobelFilterButton = new System.Windows.Forms.Button();
            this.CircleDetectionButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProcessedImageBox = new DDPanBox.DDPanBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BaseImageBox = new DDPanBox.DDPanBox();
            this.HoughTransformButton = new System.Windows.Forms.Button();
            this.OwnTransformButton = new System.Windows.Forms.Button();
            this.SearchCentersCheckBox = new System.Windows.Forms.CheckBox();
            this.LevelSearchCheckBox = new System.Windows.Forms.CheckBox();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.IntensityTrackBar = new Kreiserkennung.ValueTrackBar();
            this.DiameterTrackBar = new Kreiserkennung.ValueTrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.WeightCenterCheckBox = new System.Windows.Forms.CheckBox();
            this.levelTrackBar = new Kreiserkennung.ValueTrackBar();
            this.FilterDistanceTrackBar = new Kreiserkennung.ValueTrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AreaTrackBar = new Kreiserkennung.ValueTrackBar();
            this.FactorTrackBar = new Kreiserkennung.ValueTrackBar();
            this.LineSpectogramButton = new System.Windows.Forms.Button();
            this.FourierButton = new System.Windows.Forms.Button();
            this.RotateButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenImageButton
            // 
            this.OpenImageButton.Location = new System.Drawing.Point(12, 12);
            this.OpenImageButton.Name = "OpenImageButton";
            this.OpenImageButton.Size = new System.Drawing.Size(75, 23);
            this.OpenImageButton.TabIndex = 0;
            this.OpenImageButton.Text = "Open Image";
            this.OpenImageButton.UseVisualStyleBackColor = true;
            this.OpenImageButton.Click += new System.EventHandler(this.OpenImageButton_Click);
            // 
            // SobelFilterButton
            // 
            this.SobelFilterButton.Location = new System.Drawing.Point(93, 12);
            this.SobelFilterButton.Name = "SobelFilterButton";
            this.SobelFilterButton.Size = new System.Drawing.Size(75, 23);
            this.SobelFilterButton.TabIndex = 1;
            this.SobelFilterButton.Text = "Sobel Filter";
            this.SobelFilterButton.UseVisualStyleBackColor = true;
            this.SobelFilterButton.Click += new System.EventHandler(this.SobelFilterButton_Click);
            // 
            // CircleDetectionButton
            // 
            this.CircleDetectionButton.Location = new System.Drawing.Point(174, 12);
            this.CircleDetectionButton.Name = "CircleDetectionButton";
            this.CircleDetectionButton.Size = new System.Drawing.Size(75, 23);
            this.CircleDetectionButton.TabIndex = 2;
            this.CircleDetectionButton.Text = "Circle Detection";
            this.CircleDetectionButton.UseVisualStyleBackColor = true;
            this.CircleDetectionButton.Click += new System.EventHandler(this.CircleDetectionButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ProcessedImageBox);
            this.panel1.Location = new System.Drawing.Point(439, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 638);
            this.panel1.TabIndex = 5;
            // 
            // ProcessedImageBox
            // 
            this.ProcessedImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcessedImageBox.Image = null;
            this.ProcessedImageBox.Location = new System.Drawing.Point(0, 0);
            this.ProcessedImageBox.Name = "ProcessedImageBox";
            this.ProcessedImageBox.Size = new System.Drawing.Size(685, 636);
            this.ProcessedImageBox.TabIndex = 0;
            this.ProcessedImageBox.Text = "ddPanBox1";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.BaseImageBox);
            this.panel2.Location = new System.Drawing.Point(12, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(421, 638);
            this.panel2.TabIndex = 6;
            // 
            // BaseImageBox
            // 
            this.BaseImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseImageBox.Image = null;
            this.BaseImageBox.Location = new System.Drawing.Point(0, 0);
            this.BaseImageBox.Name = "BaseImageBox";
            this.BaseImageBox.Size = new System.Drawing.Size(419, 636);
            this.BaseImageBox.TabIndex = 0;
            this.BaseImageBox.Text = "ddPanBox1";
            // 
            // HoughTransformButton
            // 
            this.HoughTransformButton.Location = new System.Drawing.Point(256, 12);
            this.HoughTransformButton.Name = "HoughTransformButton";
            this.HoughTransformButton.Size = new System.Drawing.Size(75, 23);
            this.HoughTransformButton.TabIndex = 8;
            this.HoughTransformButton.Text = "Hough";
            this.HoughTransformButton.UseVisualStyleBackColor = true;
            this.HoughTransformButton.Click += new System.EventHandler(this.HoughTransformButton_Click);
            // 
            // OwnTransformButton
            // 
            this.OwnTransformButton.Location = new System.Drawing.Point(337, 12);
            this.OwnTransformButton.Name = "OwnTransformButton";
            this.OwnTransformButton.Size = new System.Drawing.Size(75, 23);
            this.OwnTransformButton.TabIndex = 9;
            this.OwnTransformButton.Text = "Own";
            this.OwnTransformButton.UseVisualStyleBackColor = true;
            this.OwnTransformButton.Click += new System.EventHandler(this.OwnTransformButton_Click);
            // 
            // SearchCentersCheckBox
            // 
            this.SearchCentersCheckBox.AutoSize = true;
            this.SearchCentersCheckBox.Location = new System.Drawing.Point(7, 143);
            this.SearchCentersCheckBox.Name = "SearchCentersCheckBox";
            this.SearchCentersCheckBox.Size = new System.Drawing.Size(98, 17);
            this.SearchCentersCheckBox.TabIndex = 10;
            this.SearchCentersCheckBox.Text = "Search centers";
            this.SearchCentersCheckBox.UseVisualStyleBackColor = true;
            // 
            // LevelSearchCheckBox
            // 
            this.LevelSearchCheckBox.AutoSize = true;
            this.LevelSearchCheckBox.Location = new System.Drawing.Point(7, 166);
            this.LevelSearchCheckBox.Name = "LevelSearchCheckBox";
            this.LevelSearchCheckBox.Size = new System.Drawing.Size(87, 17);
            this.LevelSearchCheckBox.TabIndex = 13;
            this.LevelSearchCheckBox.Text = "Level search";
            this.LevelSearchCheckBox.UseVisualStyleBackColor = true;
            // 
            // MenuPanel
            // 
            this.MenuPanel.AutoScroll = true;
            this.MenuPanel.BackColor = System.Drawing.SystemColors.Control;
            this.MenuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MenuPanel.Controls.Add(this.groupBox3);
            this.MenuPanel.Controls.Add(this.groupBox2);
            this.MenuPanel.Controls.Add(this.groupBox1);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.MenuPanel.Location = new System.Drawing.Point(1123, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(169, 679);
            this.MenuPanel.TabIndex = 16;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.IntensityTrackBar);
            this.groupBox3.Controls.Add(this.DiameterTrackBar);
            this.groupBox3.Location = new System.Drawing.Point(3, 410);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(161, 146);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hough Circle Detect";
            // 
            // IntensityTrackBar
            // 
            this.IntensityTrackBar.Location = new System.Drawing.Point(7, 83);
            this.IntensityTrackBar.Maximum = 1000;
            this.IntensityTrackBar.Minimum = 1;
            this.IntensityTrackBar.Name = "IntensityTrackBar";
            this.IntensityTrackBar.Size = new System.Drawing.Size(150, 56);
            this.IntensityTrackBar.TabIndex = 1;
            this.IntensityTrackBar.TickFreqeuncy = 50;
            this.IntensityTrackBar.Value = 1;
            this.IntensityTrackBar.ValueText = "Intensity inverse:";
            // 
            // DiameterTrackBar
            // 
            this.DiameterTrackBar.Location = new System.Drawing.Point(7, 20);
            this.DiameterTrackBar.Maximum = 1000;
            this.DiameterTrackBar.Minimum = 10;
            this.DiameterTrackBar.Name = "DiameterTrackBar";
            this.DiameterTrackBar.Size = new System.Drawing.Size(150, 56);
            this.DiameterTrackBar.TabIndex = 0;
            this.DiameterTrackBar.TickFreqeuncy = 50;
            this.DiameterTrackBar.Value = 10;
            this.DiameterTrackBar.ValueText = "Diameter:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.WeightCenterCheckBox);
            this.groupBox2.Controls.Add(this.levelTrackBar);
            this.groupBox2.Controls.Add(this.LevelSearchCheckBox);
            this.groupBox2.Controls.Add(this.FilterDistanceTrackBar);
            this.groupBox2.Controls.Add(this.SearchCentersCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(3, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(160, 230);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Own Circle Detect";
            // 
            // WeightCenterCheckBox
            // 
            this.WeightCenterCheckBox.AutoSize = true;
            this.WeightCenterCheckBox.Location = new System.Drawing.Point(7, 189);
            this.WeightCenterCheckBox.Name = "WeightCenterCheckBox";
            this.WeightCenterCheckBox.Size = new System.Drawing.Size(105, 17);
            this.WeightCenterCheckBox.TabIndex = 19;
            this.WeightCenterCheckBox.Text = "Schwerezentrum";
            this.WeightCenterCheckBox.UseVisualStyleBackColor = true;
            // 
            // levelTrackBar
            // 
            this.levelTrackBar.Location = new System.Drawing.Point(7, 81);
            this.levelTrackBar.Maximum = 255;
            this.levelTrackBar.Minimum = 1;
            this.levelTrackBar.Name = "levelTrackBar";
            this.levelTrackBar.Size = new System.Drawing.Size(143, 56);
            this.levelTrackBar.TabIndex = 18;
            this.levelTrackBar.TickFreqeuncy = 10;
            this.levelTrackBar.Value = 1;
            this.levelTrackBar.ValueText = "Decision Level:";
            // 
            // FilterDistanceTrackBar
            // 
            this.FilterDistanceTrackBar.Location = new System.Drawing.Point(6, 19);
            this.FilterDistanceTrackBar.Maximum = 50000;
            this.FilterDistanceTrackBar.Minimum = 1;
            this.FilterDistanceTrackBar.Name = "FilterDistanceTrackBar";
            this.FilterDistanceTrackBar.Size = new System.Drawing.Size(144, 56);
            this.FilterDistanceTrackBar.TabIndex = 17;
            this.FilterDistanceTrackBar.TickFreqeuncy = 2500;
            this.FilterDistanceTrackBar.Value = 1;
            this.FilterDistanceTrackBar.ValueText = "Distance Between Points:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AreaTrackBar);
            this.groupBox1.Controls.Add(this.FactorTrackBar);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 165);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Circle Detection";
            // 
            // AreaTrackBar
            // 
            this.AreaTrackBar.Location = new System.Drawing.Point(7, 80);
            this.AreaTrackBar.Maximum = 50;
            this.AreaTrackBar.Minimum = 1;
            this.AreaTrackBar.Name = "AreaTrackBar";
            this.AreaTrackBar.Size = new System.Drawing.Size(150, 56);
            this.AreaTrackBar.TabIndex = 9;
            this.AreaTrackBar.TickFreqeuncy = 1;
            this.AreaTrackBar.Value = 1;
            this.AreaTrackBar.ValueText = "Area:";
            // 
            // FactorTrackBar
            // 
            this.FactorTrackBar.Location = new System.Drawing.Point(4, 17);
            this.FactorTrackBar.Maximum = 50;
            this.FactorTrackBar.Minimum = 1;
            this.FactorTrackBar.Name = "FactorTrackBar";
            this.FactorTrackBar.Size = new System.Drawing.Size(150, 56);
            this.FactorTrackBar.TabIndex = 8;
            this.FactorTrackBar.TickFreqeuncy = 1;
            this.FactorTrackBar.Value = 1;
            this.FactorTrackBar.ValueText = "Factor:";
            // 
            // LineSpectogramButton
            // 
            this.LineSpectogramButton.Location = new System.Drawing.Point(419, 12);
            this.LineSpectogramButton.Name = "LineSpectogramButton";
            this.LineSpectogramButton.Size = new System.Drawing.Size(98, 23);
            this.LineSpectogramButton.TabIndex = 17;
            this.LineSpectogramButton.Text = "Line Spectrogram";
            this.LineSpectogramButton.UseVisualStyleBackColor = true;
            this.LineSpectogramButton.Click += new System.EventHandler(this.LineSpectogramButton_Click);
            // 
            // FourierButton
            // 
            this.FourierButton.Location = new System.Drawing.Point(524, 13);
            this.FourierButton.Name = "FourierButton";
            this.FourierButton.Size = new System.Drawing.Size(75, 23);
            this.FourierButton.TabIndex = 18;
            this.FourierButton.Text = "Fourier";
            this.FourierButton.UseVisualStyleBackColor = true;
            this.FourierButton.Click += new System.EventHandler(this.FourierButton_Click);
            // 
            // RotateButton
            // 
            this.RotateButton.Location = new System.Drawing.Point(606, 11);
            this.RotateButton.Name = "RotateButton";
            this.RotateButton.Size = new System.Drawing.Size(75, 23);
            this.RotateButton.TabIndex = 19;
            this.RotateButton.Text = "Rotate";
            this.RotateButton.UseVisualStyleBackColor = true;
            this.RotateButton.Click += new System.EventHandler(this.RotateButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 679);
            this.Controls.Add(this.RotateButton);
            this.Controls.Add(this.FourierButton);
            this.Controls.Add(this.LineSpectogramButton);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.OwnTransformButton);
            this.Controls.Add(this.HoughTransformButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CircleDetectionButton);
            this.Controls.Add(this.SobelFilterButton);
            this.Controls.Add(this.OpenImageButton);
            this.Name = "MainForm";
            this.Text = "Circle detection";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.MenuPanel.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OpenImageButton;
        private System.Windows.Forms.Button SobelFilterButton;
        private System.Windows.Forms.Button CircleDetectionButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DDPanBox.DDPanBox ProcessedImageBox;
        private DDPanBox.DDPanBox BaseImageBox;
        private System.Windows.Forms.Button HoughTransformButton;
        private System.Windows.Forms.Button OwnTransformButton;
        private System.Windows.Forms.CheckBox SearchCentersCheckBox;
        private System.Windows.Forms.CheckBox LevelSearchCheckBox;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private ValueTrackBar FactorTrackBar;
        private ValueTrackBar AreaTrackBar;
        private System.Windows.Forms.GroupBox groupBox2;
        private ValueTrackBar levelTrackBar;
        private ValueTrackBar FilterDistanceTrackBar;
        private System.Windows.Forms.GroupBox groupBox3;
        private ValueTrackBar IntensityTrackBar;
        private ValueTrackBar DiameterTrackBar;
        private System.Windows.Forms.Button LineSpectogramButton;
        private System.Windows.Forms.Button FourierButton;
        private System.Windows.Forms.CheckBox WeightCenterCheckBox;
        private System.Windows.Forms.Button RotateButton;
    }
}

