namespace Kreiserkennung
{
    using System.ComponentModel;
    using System.ComponentModel.Design;
    partial class ValueTrackBar
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.TrackBar1 = new System.Windows.Forms.TrackBar();
            this.ValueLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // TrackBar1
            // 
            this.TrackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrackBar1.Location = new System.Drawing.Point(0, 4);
            this.TrackBar1.Name = "TrackBar1";
            this.TrackBar1.Size = new System.Drawing.Size(150, 45);
            this.TrackBar1.TabIndex = 0;
            this.TrackBar1.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
            // 
            // ValueLabel
            // 
            this.ValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(3, 36);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(35, 13);
            this.ValueLabel.TabIndex = 1;
            this.ValueLabel.Text = "label1";
            // 
            // ValueTrackBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ValueLabel);
            this.Controls.Add(this.TrackBar1);
            this.Name = "ValueTrackBar";
            this.Size = new System.Drawing.Size(150, 56);
            ((System.ComponentModel.ISupportInitialize)(this.TrackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        private System.Windows.Forms.TrackBar TrackBar1;
        private System.Windows.Forms.Label ValueLabel;
    }
}
