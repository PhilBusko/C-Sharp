namespace FileBrowser
{
    partial class ReplaceFileNames
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label l_changeTextFrom;
            this.grpb_unmatchExt = new System.Windows.Forms.GroupBox();
            this.f_fileSystemList = new System.Windows.Forms.ListView();
            this.h_1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.h_2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpb_status = new System.Windows.Forms.GroupBox();
            this.f_rootPath = new System.Windows.Forms.TextBox();
            this.f_change = new System.Windows.Forms.Button();
            this.f_textChangeTo = new System.Windows.Forms.TextBox();
            this.f_textChangeFrom = new System.Windows.Forms.TextBox();
            this.f_setRoot = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            l_changeTextFrom = new System.Windows.Forms.Label();
            this.grpb_unmatchExt.SuspendLayout();
            this.grpb_status.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(23, 114);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(133, 21);
            label1.TabIndex = 8;
            label1.Text = "Change Text To:";
            // 
            // l_changeTextFrom
            // 
            l_changeTextFrom.AutoSize = true;
            l_changeTextFrom.Location = new System.Drawing.Point(23, 73);
            l_changeTextFrom.Name = "l_changeTextFrom";
            l_changeTextFrom.Size = new System.Drawing.Size(152, 21);
            l_changeTextFrom.TabIndex = 3;
            l_changeTextFrom.Text = "Change Text From:";
            // 
            // grpb_unmatchExt
            // 
            this.grpb_unmatchExt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpb_unmatchExt.Controls.Add(this.f_fileSystemList);
            this.grpb_unmatchExt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpb_unmatchExt.Location = new System.Drawing.Point(3, 165);
            this.grpb_unmatchExt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpb_unmatchExt.Name = "grpb_unmatchExt";
            this.grpb_unmatchExt.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpb_unmatchExt.Size = new System.Drawing.Size(1003, 224);
            this.grpb_unmatchExt.TabIndex = 9;
            this.grpb_unmatchExt.TabStop = false;
            this.grpb_unmatchExt.Text = "Results";
            // 
            // f_fileSystemList
            // 
            this.f_fileSystemList.AllowColumnReorder = true;
            this.f_fileSystemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.f_fileSystemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.h_1,
            this.h_2,
            this.columnHeader1});
            this.f_fileSystemList.FullRowSelect = true;
            this.f_fileSystemList.Location = new System.Drawing.Point(7, 25);
            this.f_fileSystemList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_fileSystemList.Name = "f_fileSystemList";
            this.f_fileSystemList.Size = new System.Drawing.Size(990, 183);
            this.f_fileSystemList.TabIndex = 0;
            this.f_fileSystemList.TabStop = false;
            this.f_fileSystemList.UseCompatibleStateImageBehavior = false;
            this.f_fileSystemList.View = System.Windows.Forms.View.Details;
            // 
            // h_1
            // 
            this.h_1.Text = "Folder";
            this.h_1.Width = 300;
            // 
            // h_2
            // 
            this.h_2.Text = "Original Name";
            this.h_2.Width = 300;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "New Name";
            this.columnHeader1.Width = 300;
            // 
            // grpb_status
            // 
            this.grpb_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpb_status.Controls.Add(this.f_rootPath);
            this.grpb_status.Controls.Add(this.f_change);
            this.grpb_status.Controls.Add(this.f_textChangeTo);
            this.grpb_status.Controls.Add(label1);
            this.grpb_status.Controls.Add(this.f_textChangeFrom);
            this.grpb_status.Controls.Add(this.f_setRoot);
            this.grpb_status.Controls.Add(l_changeTextFrom);
            this.grpb_status.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpb_status.Location = new System.Drawing.Point(3, 2);
            this.grpb_status.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpb_status.Name = "grpb_status";
            this.grpb_status.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpb_status.Size = new System.Drawing.Size(1003, 159);
            this.grpb_status.TabIndex = 8;
            this.grpb_status.TabStop = false;
            this.grpb_status.Text = "Configuration";
            // 
            // f_rootPath
            // 
            this.f_rootPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.f_rootPath.BackColor = System.Drawing.SystemColors.Window;
            this.f_rootPath.Location = new System.Drawing.Point(188, 29);
            this.f_rootPath.Margin = new System.Windows.Forms.Padding(4);
            this.f_rootPath.Name = "f_rootPath";
            this.f_rootPath.Size = new System.Drawing.Size(795, 27);
            this.f_rootPath.TabIndex = 0;
            this.f_rootPath.TabStop = false;
            this.f_rootPath.Click += new System.EventHandler(this.f_rootPath_Click);
            this.f_rootPath.TextChanged += new System.EventHandler(this.f_rootPath_TextChanged);
            // 
            // f_change
            // 
            this.f_change.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_change.Location = new System.Drawing.Point(476, 73);
            this.f_change.Margin = new System.Windows.Forms.Padding(4);
            this.f_change.Name = "f_change";
            this.f_change.Size = new System.Drawing.Size(209, 60);
            this.f_change.TabIndex = 2;
            this.f_change.Text = "Change OK";
            this.f_change.UseVisualStyleBackColor = true;
            this.f_change.Click += new System.EventHandler(this.f_change_Click);
            // 
            // f_textChangeTo
            // 
            this.f_textChangeTo.Location = new System.Drawing.Point(188, 110);
            this.f_textChangeTo.Margin = new System.Windows.Forms.Padding(4);
            this.f_textChangeTo.Name = "f_textChangeTo";
            this.f_textChangeTo.Size = new System.Drawing.Size(247, 27);
            this.f_textChangeTo.TabIndex = 1;
            this.f_textChangeTo.Click += new System.EventHandler(this.f_textChangeTo_Click);
            this.f_textChangeTo.Enter += new System.EventHandler(this.f_textChangeTo_Enter);
            // 
            // f_textChangeFrom
            // 
            this.f_textChangeFrom.Location = new System.Drawing.Point(188, 69);
            this.f_textChangeFrom.Margin = new System.Windows.Forms.Padding(4);
            this.f_textChangeFrom.Name = "f_textChangeFrom";
            this.f_textChangeFrom.Size = new System.Drawing.Size(247, 27);
            this.f_textChangeFrom.TabIndex = 0;
            this.f_textChangeFrom.Click += new System.EventHandler(this.f_textChangeFrom_Click);
            this.f_textChangeFrom.Enter += new System.EventHandler(this.f_textChangeFrom_Enter);
            // 
            // f_setRoot
            // 
            this.f_setRoot.Location = new System.Drawing.Point(27, 29);
            this.f_setRoot.Margin = new System.Windows.Forms.Padding(4);
            this.f_setRoot.Name = "f_setRoot";
            this.f_setRoot.Size = new System.Drawing.Size(148, 31);
            this.f_setRoot.TabIndex = 4;
            this.f_setRoot.TabStop = false;
            this.f_setRoot.Text = "Root Folder";
            this.f_setRoot.UseVisualStyleBackColor = true;
            this.f_setRoot.Click += new System.EventHandler(this.f_rootFolder_Click);
            // 
            // ReplaceFileNames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpb_unmatchExt);
            this.Controls.Add(this.grpb_status);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReplaceFileNames";
            this.Size = new System.Drawing.Size(1008, 391);
            this.grpb_unmatchExt.ResumeLayout(false);
            this.grpb_status.ResumeLayout(false);
            this.grpb_status.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpb_unmatchExt;
        private System.Windows.Forms.ListView f_fileSystemList;
        private System.Windows.Forms.ColumnHeader h_1;
        private System.Windows.Forms.ColumnHeader h_2;
        private System.Windows.Forms.GroupBox grpb_status;
        private System.Windows.Forms.Button f_change;
        private System.Windows.Forms.TextBox f_textChangeTo;
        private System.Windows.Forms.TextBox f_textChangeFrom;
        private System.Windows.Forms.Button f_setRoot;
        private System.Windows.Forms.TextBox f_rootPath;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}
