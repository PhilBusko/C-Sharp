namespace ImageControls
{
    partial class SmartThumbnail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.f_imageBox = new System.Windows.Forms.PictureBox();
            this.f_fileName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.f_imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // f_imageBox
            // 
            this.f_imageBox.Location = new System.Drawing.Point(4, 4);
            this.f_imageBox.Margin = new System.Windows.Forms.Padding(4);
            this.f_imageBox.Name = "f_imageBox";
            this.f_imageBox.Size = new System.Drawing.Size(204, 214);
            this.f_imageBox.TabIndex = 0;
            this.f_imageBox.TabStop = false;
            // 
            // f_fileName
            // 
            this.f_fileName.AutoSize = true;
            this.f_fileName.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_fileName.Location = new System.Drawing.Point(45, 226);
            this.f_fileName.Name = "f_fileName";
            this.f_fileName.Size = new System.Drawing.Size(91, 18);
            this.f_fileName.TabIndex = 1;
            this.f_fileName.Text = "<filename>";
            // 
            // SmartThumbnail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.f_fileName);
            this.Controls.Add(this.f_imageBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SmartThumbnail";
            this.Size = new System.Drawing.Size(212, 251);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SmartThumbnail_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.f_imageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox f_imageBox;
        private System.Windows.Forms.Label f_fileName;

    }
}
