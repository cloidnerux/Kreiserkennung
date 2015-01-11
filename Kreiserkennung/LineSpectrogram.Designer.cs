namespace Kreiserkennung
{
    partial class LineSpectrogram
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
            this.LineSelector = new Kreiserkennung.ImageLineSelector();
            this.LineSpectogram = new Kreiserkennung.LineSpectrogramView();
            this.SuspendLayout();
            // 
            // LineSelector
            // 
            this.LineSelector.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LineSelector.CircleSize = 6;
            this.LineSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LineSelector.Location = new System.Drawing.Point(0, 0);
            this.LineSelector.Name = "LineSelector";
            this.LineSelector.P1 = new System.Drawing.Point(0, 137);
            this.LineSelector.P2 = new System.Drawing.Point(0, 137);
            this.LineSelector.Size = new System.Drawing.Size(988, 465);
            this.LineSelector.TabIndex = 1;
            // 
            // LineSpectogram
            // 
            this.LineSpectogram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LineSpectogram.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LineSpectogram.Image = null;
            this.LineSpectogram.Location = new System.Drawing.Point(0, 465);
            this.LineSpectogram.Name = "LineSpectogram";
            this.LineSpectogram.P1 = new System.Drawing.Point(0, 0);
            this.LineSpectogram.P2 = new System.Drawing.Point(0, 0);
            this.LineSpectogram.Size = new System.Drawing.Size(988, 152);
            this.LineSpectogram.TabIndex = 0;
            // 
            // LineSpectrogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 617);
            this.Controls.Add(this.LineSelector);
            this.Controls.Add(this.LineSpectogram);
            this.Name = "LineSpectrogram";
            this.Text = "LineSpectrogram";
            this.ResumeLayout(false);

        }

        #endregion

        private LineSpectrogramView LineSpectogram;
        private ImageLineSelector LineSelector;
    }
}