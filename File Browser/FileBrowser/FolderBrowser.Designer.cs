namespace FileBrowser
{
    partial class FolderBrowser
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
            System.Windows.Forms.Label f_recursionLabel;
            this.grpb_unmatchExt = new System.Windows.Forms.GroupBox();
            this.f_folderInfo = new System.Windows.Forms.ListView();
            this.h_folderPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.h_numberFiles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.h_folderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpb_status = new System.Windows.Forms.GroupBox();
            this.f_recursionDepth = new System.Windows.Forms.NumericUpDown();
            this.f_rootFolder = new System.Windows.Forms.Button();
            this.f_browseTime = new System.Windows.Forms.Label();
            this.f_rootFolderLabel = new System.Windows.Forms.Label();
            f_recursionLabel = new System.Windows.Forms.Label();
            this.grpb_unmatchExt.SuspendLayout();
            this.grpb_status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.f_recursionDepth)).BeginInit();
            this.SuspendLayout();
            // 
            // f_recursionLabel
            // 
            f_recursionLabel.AutoSize = true;
            f_recursionLabel.Location = new System.Drawing.Point(17, 55);
            f_recursionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            f_recursionLabel.Name = "f_recursionLabel";
            f_recursionLabel.Size = new System.Drawing.Size(106, 16);
            f_recursionLabel.TabIndex = 3;
            f_recursionLabel.Text = "Recursion Depth:";
            // 
            // grpb_unmatchExt
            // 
            this.grpb_unmatchExt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpb_unmatchExt.Controls.Add(this.f_folderInfo);
            this.grpb_unmatchExt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpb_unmatchExt.Location = new System.Drawing.Point(13, 110);
            this.grpb_unmatchExt.Margin = new System.Windows.Forms.Padding(2);
            this.grpb_unmatchExt.Name = "grpb_unmatchExt";
            this.grpb_unmatchExt.Padding = new System.Windows.Forms.Padding(2);
            this.grpb_unmatchExt.Size = new System.Drawing.Size(776, 526);
            this.grpb_unmatchExt.TabIndex = 7;
            this.grpb_unmatchExt.TabStop = false;
            this.grpb_unmatchExt.Text = "Folder Info";
            // 
            // f_folderInfo
            // 
            this.f_folderInfo.AllowColumnReorder = true;
            this.f_folderInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.f_folderInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.h_folderPath,
            this.h_numberFiles,
            this.h_folderSize});
            this.f_folderInfo.FullRowSelect = true;
            this.f_folderInfo.Location = new System.Drawing.Point(5, 21);
            this.f_folderInfo.Margin = new System.Windows.Forms.Padding(2);
            this.f_folderInfo.Name = "f_folderInfo";
            this.f_folderInfo.Size = new System.Drawing.Size(766, 499);
            this.f_folderInfo.TabIndex = 0;
            this.f_folderInfo.UseCompatibleStateImageBehavior = false;
            this.f_folderInfo.View = System.Windows.Forms.View.Details;
            this.f_folderInfo.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.f_folderInfo_ColumnClick);
            // 
            // h_folderPath
            // 
            this.h_folderPath.Text = "Folder Path";
            this.h_folderPath.Width = 400;
            // 
            // h_numberFiles
            // 
            this.h_numberFiles.Text = "Files";
            this.h_numberFiles.Width = 75;
            // 
            // h_folderSize
            // 
            this.h_folderSize.Text = "Size";
            this.h_folderSize.Width = 100;
            // 
            // grpb_status
            // 
            this.grpb_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpb_status.Controls.Add(this.f_recursionDepth);
            this.grpb_status.Controls.Add(this.f_rootFolder);
            this.grpb_status.Controls.Add(this.f_browseTime);
            this.grpb_status.Controls.Add(f_recursionLabel);
            this.grpb_status.Controls.Add(this.f_rootFolderLabel);
            this.grpb_status.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpb_status.Location = new System.Drawing.Point(13, 14);
            this.grpb_status.Margin = new System.Windows.Forms.Padding(2);
            this.grpb_status.Name = "grpb_status";
            this.grpb_status.Padding = new System.Windows.Forms.Padding(2);
            this.grpb_status.Size = new System.Drawing.Size(776, 84);
            this.grpb_status.TabIndex = 6;
            this.grpb_status.TabStop = false;
            this.grpb_status.Text = "Browse Properties";
            // 
            // f_recursionDepth
            // 
            this.f_recursionDepth.Location = new System.Drawing.Point(128, 50);
            this.f_recursionDepth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.f_recursionDepth.Name = "f_recursionDepth";
            this.f_recursionDepth.Size = new System.Drawing.Size(54, 23);
            this.f_recursionDepth.TabIndex = 7;
            this.f_recursionDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.f_recursionDepth.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // f_rootFolder
            // 
            this.f_rootFolder.Location = new System.Drawing.Point(18, 23);
            this.f_rootFolder.Name = "f_rootFolder";
            this.f_rootFolder.Size = new System.Drawing.Size(102, 23);
            this.f_rootFolder.TabIndex = 6;
            this.f_rootFolder.Text = "Root Folder";
            this.f_rootFolder.UseVisualStyleBackColor = true;
            this.f_rootFolder.Click += new System.EventHandler(this.f_rootFolder_Click);
            // 
            // f_browseTime
            // 
            this.f_browseTime.AutoSize = true;
            this.f_browseTime.Location = new System.Drawing.Point(440, 55);
            this.f_browseTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.f_browseTime.Name = "f_browseTime";
            this.f_browseTime.Size = new System.Drawing.Size(113, 16);
            this.f_browseTime.TabIndex = 5;
            this.f_browseTime.Text = "Browse Time: N/A";
            // 
            // f_rootFolderLabel
            // 
            this.f_rootFolderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.f_rootFolderLabel.AutoSize = true;
            this.f_rootFolderLabel.Location = new System.Drawing.Point(125, 26);
            this.f_rootFolderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.f_rootFolderLabel.Name = "f_rootFolderLabel";
            this.f_rootFolderLabel.Size = new System.Drawing.Size(88, 16);
            this.f_rootFolderLabel.TabIndex = 2;
            this.f_rootFolderLabel.Text = "File Root: N/A";
            // 
            // FolderBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 685);
            this.Controls.Add(this.grpb_unmatchExt);
            this.Controls.Add(this.grpb_status);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FolderBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Folder Browser";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FolderSize_FormClosed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FolderBrowser_KeyPress);
            this.grpb_unmatchExt.ResumeLayout(false);
            this.grpb_status.ResumeLayout(false);
            this.grpb_status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.f_recursionDepth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpb_unmatchExt;
        private System.Windows.Forms.ListView f_folderInfo;
        private System.Windows.Forms.ColumnHeader h_folderPath;
        private System.Windows.Forms.ColumnHeader h_numberFiles;
        private System.Windows.Forms.ColumnHeader h_folderSize;
        private System.Windows.Forms.GroupBox grpb_status;
        private System.Windows.Forms.Label f_browseTime;
        private System.Windows.Forms.Label f_rootFolderLabel;
        private System.Windows.Forms.NumericUpDown f_recursionDepth;
        private System.Windows.Forms.Button f_rootFolder;

    }
}