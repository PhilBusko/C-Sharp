namespace FileBrowser
{
    partial class EntrySortCtrl
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
            this.f_close = new System.Windows.Forms.Button();
            this.f_fileList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.f_chooseFiles = new System.Windows.Forms.Button();
            this.f_keywords = new System.Windows.Forms.TextBox();
            this.f_okgo = new System.Windows.Forms.Button();
            this.f_openFolder = new System.Windows.Forms.Button();
            this.f_sortValue = new System.Windows.Forms.TextBox();
            this.f_useSort = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(16, 129);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(98, 22);
            label1.TabIndex = 16;
            label1.Text = "Keywords:";
            // 
            // f_close
            // 
            this.f_close.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.f_close.Location = new System.Drawing.Point(334, 416);
            this.f_close.Name = "f_close";
            this.f_close.Size = new System.Drawing.Size(75, 31);
            this.f_close.TabIndex = 12;
            this.f_close.TabStop = false;
            this.f_close.Text = "Close";
            this.f_close.UseVisualStyleBackColor = true;
            // 
            // f_fileList
            // 
            this.f_fileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.f_fileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.f_fileList.Location = new System.Drawing.Point(20, 228);
            this.f_fileList.Name = "f_fileList";
            this.f_fileList.Size = new System.Drawing.Size(390, 179);
            this.f_fileList.TabIndex = 10;
            this.f_fileList.TabStop = false;
            this.f_fileList.UseCompatibleStateImageBehavior = false;
            this.f_fileList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File Name";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            this.columnHeader2.Width = 78;
            // 
            // f_chooseFiles
            // 
            this.f_chooseFiles.Location = new System.Drawing.Point(21, 19);
            this.f_chooseFiles.Name = "f_chooseFiles";
            this.f_chooseFiles.Size = new System.Drawing.Size(187, 38);
            this.f_chooseFiles.TabIndex = 1;
            this.f_chooseFiles.TabStop = false;
            this.f_chooseFiles.Text = "Choose Files";
            this.f_chooseFiles.UseVisualStyleBackColor = true;
            this.f_chooseFiles.Click += new System.EventHandler(this.f_chooseFiles_Click);
            // 
            // f_keywords
            // 
            this.f_keywords.Location = new System.Drawing.Point(120, 126);
            this.f_keywords.Name = "f_keywords";
            this.f_keywords.Size = new System.Drawing.Size(214, 30);
            this.f_keywords.TabIndex = 3;
            // 
            // f_okgo
            // 
            this.f_okgo.Location = new System.Drawing.Point(121, 168);
            this.f_okgo.Name = "f_okgo";
            this.f_okgo.Size = new System.Drawing.Size(154, 35);
            this.f_okgo.TabIndex = 4;
            this.f_okgo.Text = "Ok Go";
            this.f_okgo.UseVisualStyleBackColor = true;
            this.f_okgo.Click += new System.EventHandler(this.f_okgo_Click);
            // 
            // f_openFolder
            // 
            this.f_openFolder.Location = new System.Drawing.Point(235, 19);
            this.f_openFolder.Name = "f_openFolder";
            this.f_openFolder.Size = new System.Drawing.Size(174, 38);
            this.f_openFolder.TabIndex = 2;
            this.f_openFolder.Text = "Choose Folder";
            this.f_openFolder.UseVisualStyleBackColor = true;
            this.f_openFolder.Click += new System.EventHandler(this.f_openFolder_Click);
            // 
            // f_sortValue
            // 
            this.f_sortValue.Enabled = false;
            this.f_sortValue.Location = new System.Drawing.Point(161, 76);
            this.f_sortValue.Name = "f_sortValue";
            this.f_sortValue.ReadOnly = true;
            this.f_sortValue.Size = new System.Drawing.Size(47, 30);
            this.f_sortValue.TabIndex = 17;
            // 
            // f_useSort
            // 
            this.f_useSort.AutoSize = true;
            this.f_useSort.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.f_useSort.Location = new System.Drawing.Point(14, 78);
            this.f_useSort.Name = "f_useSort";
            this.f_useSort.Size = new System.Drawing.Size(127, 26);
            this.f_useSort.TabIndex = 19;
            this.f_useSort.Text = "Letter Sort: ";
            this.f_useSort.UseVisualStyleBackColor = true;
            this.f_useSort.CheckedChanged += new System.EventHandler(this.f_useSort_CheckedChanged);
            // 
            // EntrySortCtrl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.f_useSort);
            this.Controls.Add(this.f_sortValue);
            this.Controls.Add(this.f_close);
            this.Controls.Add(this.f_fileList);
            this.Controls.Add(this.f_chooseFiles);
            this.Controls.Add(this.f_keywords);
            this.Controls.Add(label1);
            this.Controls.Add(this.f_okgo);
            this.Controls.Add(this.f_openFolder);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "EntrySortCtrl";
            this.Size = new System.Drawing.Size(432, 458);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button f_close;
        private System.Windows.Forms.ListView f_fileList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button f_chooseFiles;
        private System.Windows.Forms.TextBox f_keywords;
        private System.Windows.Forms.Button f_okgo;
        private System.Windows.Forms.Button f_openFolder;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox f_sortValue;
        private System.Windows.Forms.CheckBox f_useSort;
    }
}
