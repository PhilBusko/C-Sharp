namespace ImageControls
{
    partial class SmartFlowLayout
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
            this.f_flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // f_flowLayout
            // 
            this.f_flowLayout.AutoScroll = true;
            this.f_flowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.f_flowLayout.Location = new System.Drawing.Point(0, 0);
            this.f_flowLayout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.f_flowLayout.Name = "f_flowLayout";
            this.f_flowLayout.Size = new System.Drawing.Size(1177, 242);
            this.f_flowLayout.TabIndex = 0;
            this.f_flowLayout.MouseClick += new System.Windows.Forms.MouseEventHandler(this.f_flowLayout_MouseClick);
            this.f_flowLayout.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.f_flowLayout_MouseDoubleClick);
            // 
            // SmartFlowLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.f_flowLayout);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SmartFlowLayout";
            this.Size = new System.Drawing.Size(1177, 242);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel f_flowLayout;
    }
}
