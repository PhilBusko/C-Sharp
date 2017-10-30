namespace ImageControls
{
    partial class ImageWorkspace
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
            this.f_editRotate = new System.Windows.Forms.Button();
            this.f_editCrop = new System.Windows.Forms.Button();
            this.f_dimensions = new System.Windows.Forms.Label();
            this.f_name = new System.Windows.Forms.Label();
            this.f_editUndo = new System.Windows.Forms.Button();
            this.f_zoomIn = new System.Windows.Forms.Button();
            this.f_zoomOut = new System.Windows.Forms.Button();
            this.f_zoomFit = new System.Windows.Forms.Button();
            this.f_zoom100 = new System.Windows.Forms.Button();
            this.f_imagePanel = new System.Windows.Forms.Panel();
            this.f_imageBox = new System.Windows.Forms.PictureBox();
            this.f_blur = new System.Windows.Forms.Button();
            this.f_cropTop = new System.Windows.Forms.Button();
            this.f_cropBottom = new System.Windows.Forms.Button();
            this.f_cropLeft = new System.Windows.Forms.Button();
            this.f_cropR = new System.Windows.Forms.Button();
            this.f_imagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.f_imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // f_editRotate
            // 
            this.f_editRotate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.f_editRotate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.f_editRotate.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_editRotate.Location = new System.Drawing.Point(39, 408);
            this.f_editRotate.Name = "f_editRotate";
            this.f_editRotate.Size = new System.Drawing.Size(30, 30);
            this.f_editRotate.TabIndex = 16;
            this.f_editRotate.Text = "R";
            this.f_editRotate.UseVisualStyleBackColor = true;
            this.f_editRotate.Click += new System.EventHandler(this.f_editRotate_Click);
            // 
            // f_editCrop
            // 
            this.f_editCrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.f_editCrop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.f_editCrop.Font = new System.Drawing.Font("Elephant", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_editCrop.Location = new System.Drawing.Point(168, 408);
            this.f_editCrop.Name = "f_editCrop";
            this.f_editCrop.Size = new System.Drawing.Size(87, 30);
            this.f_editCrop.TabIndex = 15;
            this.f_editCrop.Text = "CROP";
            this.f_editCrop.UseVisualStyleBackColor = true;
            this.f_editCrop.Click += new System.EventHandler(this.f_editCrop_Click);
            // 
            // f_dimensions
            // 
            this.f_dimensions.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.f_dimensions.AutoSize = true;
            this.f_dimensions.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_dimensions.Location = new System.Drawing.Point(285, 9);
            this.f_dimensions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.f_dimensions.Name = "f_dimensions";
            this.f_dimensions.Size = new System.Drawing.Size(112, 23);
            this.f_dimensions.TabIndex = 14;
            this.f_dimensions.Text = "Dimensions:";
            // 
            // f_name
            // 
            this.f_name.AutoSize = true;
            this.f_name.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_name.Location = new System.Drawing.Point(10, 9);
            this.f_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.f_name.Name = "f_name";
            this.f_name.Size = new System.Drawing.Size(66, 23);
            this.f_name.TabIndex = 13;
            this.f_name.Text = "Name:";
            // 
            // f_editUndo
            // 
            this.f_editUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.f_editUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.f_editUndo.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_editUndo.Location = new System.Drawing.Point(3, 408);
            this.f_editUndo.Name = "f_editUndo";
            this.f_editUndo.Size = new System.Drawing.Size(30, 30);
            this.f_editUndo.TabIndex = 17;
            this.f_editUndo.Text = "U";
            this.f_editUndo.UseVisualStyleBackColor = true;
            this.f_editUndo.Click += new System.EventHandler(this.f_editUndo_Click);
            // 
            // f_zoomIn
            // 
            this.f_zoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.f_zoomIn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_zoomIn.Location = new System.Drawing.Point(603, 407);
            this.f_zoomIn.Name = "f_zoomIn";
            this.f_zoomIn.Size = new System.Drawing.Size(40, 30);
            this.f_zoomIn.TabIndex = 18;
            this.f_zoomIn.Text = "Z+";
            this.f_zoomIn.UseVisualStyleBackColor = true;
            this.f_zoomIn.Click += new System.EventHandler(this.f_zoomIn_Click);
            // 
            // f_zoomOut
            // 
            this.f_zoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.f_zoomOut.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_zoomOut.Location = new System.Drawing.Point(649, 407);
            this.f_zoomOut.Name = "f_zoomOut";
            this.f_zoomOut.Size = new System.Drawing.Size(40, 30);
            this.f_zoomOut.TabIndex = 19;
            this.f_zoomOut.Text = "Z-";
            this.f_zoomOut.UseVisualStyleBackColor = true;
            this.f_zoomOut.Click += new System.EventHandler(this.f_zoomOut_Click);
            // 
            // f_zoomFit
            // 
            this.f_zoomFit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.f_zoomFit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_zoomFit.Location = new System.Drawing.Point(540, 407);
            this.f_zoomFit.Name = "f_zoomFit";
            this.f_zoomFit.Size = new System.Drawing.Size(57, 30);
            this.f_zoomFit.TabIndex = 22;
            this.f_zoomFit.Text = "Fit";
            this.f_zoomFit.UseVisualStyleBackColor = true;
            this.f_zoomFit.Click += new System.EventHandler(this.f_zoomShrink_Click);
            // 
            // f_zoom100
            // 
            this.f_zoom100.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.f_zoom100.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_zoom100.Location = new System.Drawing.Point(472, 407);
            this.f_zoom100.Name = "f_zoom100";
            this.f_zoom100.Size = new System.Drawing.Size(62, 30);
            this.f_zoom100.TabIndex = 21;
            this.f_zoom100.Text = "100%";
            this.f_zoom100.UseVisualStyleBackColor = true;
            this.f_zoom100.Click += new System.EventHandler(this.f_zoomActual_Click);
            // 
            // f_imagePanel
            // 
            this.f_imagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.f_imagePanel.AutoScroll = true;
            this.f_imagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.f_imagePanel.Controls.Add(this.f_imageBox);
            this.f_imagePanel.Location = new System.Drawing.Point(3, 38);
            this.f_imagePanel.Name = "f_imagePanel";
            this.f_imagePanel.Size = new System.Drawing.Size(686, 364);
            this.f_imagePanel.TabIndex = 23;
            this.f_imagePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.f_imagePanel_Paint);
            this.f_imagePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.f_imagePanel_MouseDown);
            this.f_imagePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.f_imagePanel_MouseMove);
            this.f_imagePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.f_imagePanel_MouseUp);
            // 
            // f_imageBox
            // 
            this.f_imageBox.BackColor = System.Drawing.Color.LightPink;
            this.f_imageBox.Location = new System.Drawing.Point(180, 54);
            this.f_imageBox.Name = "f_imageBox";
            this.f_imageBox.Size = new System.Drawing.Size(316, 240);
            this.f_imageBox.TabIndex = 0;
            this.f_imageBox.TabStop = false;
            this.f_imageBox.Visible = false;
            this.f_imageBox.Paint += new System.Windows.Forms.PaintEventHandler(this.f_imageBox_Paint);
            // 
            // f_blur
            // 
            this.f_blur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.f_blur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.f_blur.Font = new System.Drawing.Font("Elephant", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_blur.Location = new System.Drawing.Point(75, 408);
            this.f_blur.Name = "f_blur";
            this.f_blur.Size = new System.Drawing.Size(87, 30);
            this.f_blur.TabIndex = 24;
            this.f_blur.Text = "BLUR";
            this.f_blur.UseVisualStyleBackColor = true;
            this.f_blur.Click += new System.EventHandler(this.f_blur_Click);
            // 
            // f_cropTop
            // 
            this.f_cropTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.f_cropTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.f_cropTop.Font = new System.Drawing.Font("Elephant", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_cropTop.Location = new System.Drawing.Point(292, 408);
            this.f_cropTop.Name = "f_cropTop";
            this.f_cropTop.Size = new System.Drawing.Size(24, 20);
            this.f_cropTop.TabIndex = 25;
            this.f_cropTop.Text = "T";
            this.f_cropTop.UseVisualStyleBackColor = true;
            this.f_cropTop.Click += new System.EventHandler(this.f_cropTop_Click);
            // 
            // f_cropBottom
            // 
            this.f_cropBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.f_cropBottom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.f_cropBottom.Font = new System.Drawing.Font("Elephant", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_cropBottom.Location = new System.Drawing.Point(321, 419);
            this.f_cropBottom.Name = "f_cropBottom";
            this.f_cropBottom.Size = new System.Drawing.Size(24, 20);
            this.f_cropBottom.TabIndex = 26;
            this.f_cropBottom.Text = "B";
            this.f_cropBottom.UseVisualStyleBackColor = true;
            this.f_cropBottom.Click += new System.EventHandler(this.f_cropBottom_Click);
            // 
            // f_cropLeft
            // 
            this.f_cropLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.f_cropLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.f_cropLeft.Font = new System.Drawing.Font("Elephant", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_cropLeft.Location = new System.Drawing.Point(262, 414);
            this.f_cropLeft.Name = "f_cropLeft";
            this.f_cropLeft.Size = new System.Drawing.Size(24, 20);
            this.f_cropLeft.TabIndex = 27;
            this.f_cropLeft.Text = "L";
            this.f_cropLeft.UseVisualStyleBackColor = true;
            this.f_cropLeft.Click += new System.EventHandler(this.f_cropLeft_Click);
            // 
            // f_cropR
            // 
            this.f_cropR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.f_cropR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.f_cropR.Font = new System.Drawing.Font("Elephant", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_cropR.Location = new System.Drawing.Point(351, 414);
            this.f_cropR.Name = "f_cropR";
            this.f_cropR.Size = new System.Drawing.Size(24, 20);
            this.f_cropR.TabIndex = 28;
            this.f_cropR.Text = "R";
            this.f_cropR.UseVisualStyleBackColor = true;
            this.f_cropR.Click += new System.EventHandler(this.f_cropR_Click);
            // 
            // ImageWorkspace
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.f_cropR);
            this.Controls.Add(this.f_cropLeft);
            this.Controls.Add(this.f_cropBottom);
            this.Controls.Add(this.f_cropTop);
            this.Controls.Add(this.f_blur);
            this.Controls.Add(this.f_dimensions);
            this.Controls.Add(this.f_name);
            this.Controls.Add(this.f_zoomIn);
            this.Controls.Add(this.f_imagePanel);
            this.Controls.Add(this.f_zoomOut);
            this.Controls.Add(this.f_zoomFit);
            this.Controls.Add(this.f_zoom100);
            this.Controls.Add(this.f_editUndo);
            this.Controls.Add(this.f_editRotate);
            this.Controls.Add(this.f_editCrop);
            this.Name = "ImageWorkspace";
            this.Size = new System.Drawing.Size(692, 445);
            this.f_imagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.f_imageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button f_editRotate;
        private System.Windows.Forms.Button f_editCrop;
        private System.Windows.Forms.Label f_dimensions;
        private System.Windows.Forms.Label f_name;
        private System.Windows.Forms.Button f_editUndo;
        private System.Windows.Forms.Button f_zoomIn;
        private System.Windows.Forms.Button f_zoomOut;
        private System.Windows.Forms.Button f_zoomFit;
        private System.Windows.Forms.Button f_zoom100;
        private System.Windows.Forms.Panel f_imagePanel;
        private System.Windows.Forms.PictureBox f_imageBox;
        private System.Windows.Forms.Button f_blur;
        private System.Windows.Forms.Button f_cropTop;
        private System.Windows.Forms.Button f_cropBottom;
        private System.Windows.Forms.Button f_cropLeft;
        private System.Windows.Forms.Button f_cropR;
    }
}
