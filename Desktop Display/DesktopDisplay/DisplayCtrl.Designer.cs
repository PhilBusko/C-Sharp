namespace DesktopDisplay
{
    partial class DisplayCtrl
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
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.GroupBox groupBox2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.GroupBox groupBox3;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            this.f_geometry = new System.Windows.Forms.Label();
            this.f_isPrimary = new System.Windows.Forms.Label();
            this.f_marginBottom = new System.Windows.Forms.NumericUpDown();
            this.f_marginRight = new System.Windows.Forms.NumericUpDown();
            this.f_marginLeft = new System.Windows.Forms.NumericUpDown();
            this.f_marginTop = new System.Windows.Forms.NumericUpDown();
            this.f_timerInterval = new System.Windows.Forms.NumericUpDown();
            this.f_browse = new System.Windows.Forms.Button();
            this.f_rootFolder = new System.Windows.Forms.TextBox();
            this.f_previousImage = new System.Windows.Forms.TextBox();
            this.f_currImage = new System.Windows.Forms.TextBox();
            this.f_countdown = new System.Windows.Forms.ProgressBar();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            groupBox3 = new System.Windows.Forms.GroupBox();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.f_marginBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f_marginRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f_marginLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f_marginTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f_timerInterval)).BeginInit();
            groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.f_geometry);
            groupBox1.Controls.Add(this.f_isPrimary);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox1.Location = new System.Drawing.Point(0, 0);
            groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Size = new System.Drawing.Size(576, 101);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Monitor Info";
            // 
            // f_geometry
            // 
            this.f_geometry.AutoSize = true;
            this.f_geometry.Location = new System.Drawing.Point(17, 65);
            this.f_geometry.Name = "f_geometry";
            this.f_geometry.Size = new System.Drawing.Size(184, 19);
            this.f_geometry.TabIndex = 1;
            this.f_geometry.Text = "Width:   Height:   X:   Y:   ";
            // 
            // f_isPrimary
            // 
            this.f_isPrimary.AutoSize = true;
            this.f_isPrimary.Location = new System.Drawing.Point(17, 30);
            this.f_isPrimary.Name = "f_isPrimary";
            this.f_isPrimary.Size = new System.Drawing.Size(70, 19);
            this.f_isPrimary.TabIndex = 0;
            this.f_isPrimary.Text = "Primary:";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            groupBox2.Controls.Add(this.f_marginBottom);
            groupBox2.Controls.Add(this.f_marginRight);
            groupBox2.Controls.Add(this.f_marginLeft);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(this.f_marginTop);
            groupBox2.Controls.Add(this.f_timerInterval);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(this.f_browse);
            groupBox2.Controls.Add(this.f_rootFolder);
            groupBox2.Controls.Add(label1);
            groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            groupBox2.Location = new System.Drawing.Point(1, 103);
            groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox2.Size = new System.Drawing.Size(576, 201);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Wallpaper Config";
            // 
            // f_marginBottom
            // 
            this.f_marginBottom.Location = new System.Drawing.Point(404, 158);
            this.f_marginBottom.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.f_marginBottom.Name = "f_marginBottom";
            this.f_marginBottom.Size = new System.Drawing.Size(61, 25);
            this.f_marginBottom.TabIndex = 10;
            this.f_marginBottom.ValueChanged += new System.EventHandler(this.f_marginBottom_ValueChanged);
            // 
            // f_marginRight
            // 
            this.f_marginRight.Location = new System.Drawing.Point(472, 132);
            this.f_marginRight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.f_marginRight.Name = "f_marginRight";
            this.f_marginRight.Size = new System.Drawing.Size(61, 25);
            this.f_marginRight.TabIndex = 9;
            this.f_marginRight.ValueChanged += new System.EventHandler(this.f_marginRight_ValueChanged);
            // 
            // f_marginLeft
            // 
            this.f_marginLeft.Location = new System.Drawing.Point(337, 132);
            this.f_marginLeft.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.f_marginLeft.Name = "f_marginLeft";
            this.f_marginLeft.Size = new System.Drawing.Size(61, 25);
            this.f_marginLeft.TabIndex = 8;
            this.f_marginLeft.ValueChanged += new System.EventHandler(this.f_marginLeft_ValueChanged);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(255, 107);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(68, 19);
            label3.TabIndex = 7;
            label3.Text = "Margins";
            // 
            // f_marginTop
            // 
            this.f_marginTop.Location = new System.Drawing.Point(404, 107);
            this.f_marginTop.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.f_marginTop.Name = "f_marginTop";
            this.f_marginTop.Size = new System.Drawing.Size(61, 25);
            this.f_marginTop.TabIndex = 6;
            this.f_marginTop.ValueChanged += new System.EventHandler(this.f_marginTop_ValueChanged);
            // 
            // f_timerInterval
            // 
            this.f_timerInterval.Location = new System.Drawing.Point(128, 107);
            this.f_timerInterval.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.f_timerInterval.Name = "f_timerInterval";
            this.f_timerInterval.Size = new System.Drawing.Size(61, 25);
            this.f_timerInterval.TabIndex = 5;
            this.f_timerInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.f_timerInterval.ValueChanged += new System.EventHandler(this.f_timerInterval_ValueChanged);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(17, 109);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(105, 19);
            label2.TabIndex = 4;
            label2.Text = "Timer (mins):";
            // 
            // f_browse
            // 
            this.f_browse.Location = new System.Drawing.Point(228, 28);
            this.f_browse.Name = "f_browse";
            this.f_browse.Size = new System.Drawing.Size(145, 30);
            this.f_browse.TabIndex = 3;
            this.f_browse.Text = "Browse";
            this.f_browse.UseVisualStyleBackColor = true;
            this.f_browse.Click += new System.EventHandler(this.f_browse_Click);
            // 
            // f_rootFolder
            // 
            this.f_rootFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.f_rootFolder.Location = new System.Drawing.Point(21, 66);
            this.f_rootFolder.Name = "f_rootFolder";
            this.f_rootFolder.ReadOnly = true;
            this.f_rootFolder.Size = new System.Drawing.Size(530, 25);
            this.f_rootFolder.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(17, 34);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(133, 19);
            label1.TabIndex = 1;
            label1.Text = "Image Root Folder";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(this.f_previousImage);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(this.f_currImage);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(this.f_countdown);
            groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            groupBox3.Location = new System.Drawing.Point(0, 308);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(576, 147);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Status";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(17, 107);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(93, 19);
            label6.TabIndex = 6;
            label6.Text = "Countdown:";
            // 
            // f_previousImage
            // 
            this.f_previousImage.Location = new System.Drawing.Point(141, 63);
            this.f_previousImage.Name = "f_previousImage";
            this.f_previousImage.ReadOnly = true;
            this.f_previousImage.Size = new System.Drawing.Size(410, 25);
            this.f_previousImage.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(17, 66);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(118, 19);
            label5.TabIndex = 4;
            label5.Text = "Previous Image:";
            // 
            // f_currImage
            // 
            this.f_currImage.Location = new System.Drawing.Point(141, 28);
            this.f_currImage.Name = "f_currImage";
            this.f_currImage.ReadOnly = true;
            this.f_currImage.Size = new System.Drawing.Size(411, 25);
            this.f_currImage.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(17, 31);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(114, 19);
            label4.TabIndex = 2;
            label4.Text = "Current Image:";
            // 
            // f_countdown
            // 
            this.f_countdown.Location = new System.Drawing.Point(116, 107);
            this.f_countdown.Name = "f_countdown";
            this.f_countdown.Size = new System.Drawing.Size(435, 23);
            this.f_countdown.TabIndex = 0;
            // 
            // MonitorConfigCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(groupBox3);
            this.Controls.Add(groupBox2);
            this.Controls.Add(groupBox1);
            this.Font = new System.Drawing.Font("Footlight MT Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MonitorConfigCtrl";
            this.Size = new System.Drawing.Size(576, 455);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.f_marginBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f_marginRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f_marginLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f_marginTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f_timerInterval)).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label f_geometry;
        private System.Windows.Forms.Label f_isPrimary;
        private System.Windows.Forms.NumericUpDown f_marginTop;
        private System.Windows.Forms.NumericUpDown f_timerInterval;
        private System.Windows.Forms.Button f_browse;
        private System.Windows.Forms.TextBox f_rootFolder;
        private System.Windows.Forms.NumericUpDown f_marginBottom;
        private System.Windows.Forms.NumericUpDown f_marginRight;
        private System.Windows.Forms.NumericUpDown f_marginLeft;
        private System.Windows.Forms.TextBox f_previousImage;
        private System.Windows.Forms.TextBox f_currImage;
        private System.Windows.Forms.ProgressBar f_countdown;
    }
}
