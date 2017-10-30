namespace FileBrowser
{
    partial class FileStandardizorCtrl
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
            this.f_rootPath = new System.Windows.Forms.TextBox();
            this.f_setFileSort = new System.Windows.Forms.Button();
            this.f_openFolder = new System.Windows.Forms.Button();
            this.f_filesResults = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.f_filesChecked = new System.Windows.Forms.Label();
            this.f_close = new System.Windows.Forms.Button();
            this.f_deleteAll = new System.Windows.Forms.CheckBox();
            this.f_deleteImages = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(10, 66);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(111, 23);
            label1.TabIndex = 0;
            label1.Text = "Root Folder:";
            // 
            // f_rootPath
            // 
            this.f_rootPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.f_rootPath.Location = new System.Drawing.Point(135, 63);
            this.f_rootPath.Name = "f_rootPath";
            this.f_rootPath.Size = new System.Drawing.Size(819, 30);
            this.f_rootPath.TabIndex = 1;
            // 
            // f_setFileSort
            // 
            this.f_setFileSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.f_setFileSort.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_setFileSort.Location = new System.Drawing.Point(979, 46);
            this.f_setFileSort.Name = "f_setFileSort";
            this.f_setFileSort.Size = new System.Drawing.Size(129, 43);
            this.f_setFileSort.TabIndex = 2;
            this.f_setFileSort.Text = "Run Run";
            this.f_setFileSort.UseVisualStyleBackColor = true;
            this.f_setFileSort.Click += new System.EventHandler(this.f_run_Click);
            // 
            // f_openFolder
            // 
            this.f_openFolder.Location = new System.Drawing.Point(13, 13);
            this.f_openFolder.Name = "f_openFolder";
            this.f_openFolder.Size = new System.Drawing.Size(150, 30);
            this.f_openFolder.TabIndex = 11;
            this.f_openFolder.Text = "Choose Folder";
            this.f_openFolder.UseVisualStyleBackColor = true;
            this.f_openFolder.Click += new System.EventHandler(this.f_openFolder_Click);
            // 
            // f_filesResults
            // 
            this.f_filesResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.f_filesResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.f_filesResults.FullRowSelect = true;
            this.f_filesResults.Location = new System.Drawing.Point(13, 116);
            this.f_filesResults.Name = "f_filesResults";
            this.f_filesResults.Size = new System.Drawing.Size(1095, 117);
            this.f_filesResults.TabIndex = 12;
            this.f_filesResults.UseCompatibleStateImageBehavior = false;
            this.f_filesResults.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File";
            this.columnHeader1.Width = 550;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            this.columnHeader2.Width = 300;
            // 
            // f_filesChecked
            // 
            this.f_filesChecked.AutoSize = true;
            this.f_filesChecked.Location = new System.Drawing.Point(662, 20);
            this.f_filesChecked.Name = "f_filesChecked";
            this.f_filesChecked.Size = new System.Drawing.Size(122, 23);
            this.f_filesChecked.TabIndex = 13;
            this.f_filesChecked.Text = "Files Checked:";
            // 
            // f_close
            // 
            this.f_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.f_close.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_close.Location = new System.Drawing.Point(1018, 249);
            this.f_close.Name = "f_close";
            this.f_close.Size = new System.Drawing.Size(90, 25);
            this.f_close.TabIndex = 14;
            this.f_close.Text = "Close";
            this.f_close.UseVisualStyleBackColor = true;
            // 
            // f_deleteAll
            // 
            this.f_deleteAll.AutoSize = true;
            this.f_deleteAll.Location = new System.Drawing.Point(197, 16);
            this.f_deleteAll.Name = "f_deleteAll";
            this.f_deleteAll.Size = new System.Drawing.Size(148, 27);
            this.f_deleteAll.TabIndex = 15;
            this.f_deleteAll.Text = "Delete All Files";
            this.f_deleteAll.UseVisualStyleBackColor = true;
            // 
            // f_deleteImages
            // 
            this.f_deleteImages.AutoSize = true;
            this.f_deleteImages.Location = new System.Drawing.Point(365, 16);
            this.f_deleteImages.Name = "f_deleteImages";
            this.f_deleteImages.Size = new System.Drawing.Size(171, 27);
            this.f_deleteImages.TabIndex = 16;
            this.f_deleteImages.Text = "Delete All Images";
            this.f_deleteImages.UseVisualStyleBackColor = true;
            // 
            // FileStandardizorCtrl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.f_deleteImages);
            this.Controls.Add(this.f_deleteAll);
            this.Controls.Add(this.f_close);
            this.Controls.Add(this.f_filesChecked);
            this.Controls.Add(this.f_filesResults);
            this.Controls.Add(this.f_openFolder);
            this.Controls.Add(this.f_setFileSort);
            this.Controls.Add(this.f_rootPath);
            this.Controls.Add(label1);
            this.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FileStandardizorCtrl";
            this.Size = new System.Drawing.Size(1121, 286);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox f_rootPath;
        private System.Windows.Forms.Button f_setFileSort;
        private System.Windows.Forms.Button f_openFolder;
        private System.Windows.Forms.ListView f_filesResults;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label f_filesChecked;
        private System.Windows.Forms.Button f_close;
        private System.Windows.Forms.CheckBox f_deleteAll;
        private System.Windows.Forms.CheckBox f_deleteImages;
    }
}
