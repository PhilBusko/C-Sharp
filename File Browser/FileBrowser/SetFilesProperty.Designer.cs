namespace FileBrowser
{
    partial class SetFilesProperty
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.f_rootFolder = new System.Windows.Forms.TextBox();
            this.f_run = new System.Windows.Forms.Button();
            this.f_setRootFolder = new System.Windows.Forms.Button();
            this.f_filesResults = new System.Windows.Forms.ListView();
            this.c_folder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_file = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.f_fileResultsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.f_menuCopyName = new System.Windows.Forms.ToolStripMenuItem();
            this.f_filesChecked = new System.Windows.Forms.Label();
            this.f_close = new System.Windows.Forms.Button();
            this.f_fileType = new System.Windows.Forms.ComboBox();
            this.f_threadStatus = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.f_fileResultsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(10, 66);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(109, 24);
            label1.TabIndex = 0;
            label1.Text = "Root Folder:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(184, 23);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(87, 24);
            label2.TabIndex = 19;
            label2.Text = "File Type:";
            // 
            // f_rootFolder
            // 
            this.f_rootFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.f_rootFolder.Location = new System.Drawing.Point(135, 63);
            this.f_rootFolder.Name = "f_rootFolder";
            this.f_rootFolder.Size = new System.Drawing.Size(818, 29);
            this.f_rootFolder.TabIndex = 1;
            this.f_rootFolder.Click += new System.EventHandler(this.f_rootFolder_Click);
            // 
            // f_run
            // 
            this.f_run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.f_run.AutoSize = true;
            this.f_run.Font = new System.Drawing.Font("Elephant", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_run.Location = new System.Drawing.Point(975, 55);
            this.f_run.Name = "f_run";
            this.f_run.Size = new System.Drawing.Size(163, 43);
            this.f_run.TabIndex = 2;
            this.f_run.Text = "Ok Go";
            this.f_run.UseVisualStyleBackColor = true;
            this.f_run.Click += new System.EventHandler(this.f_run_Click);
            // 
            // f_setRootFolder
            // 
            this.f_setRootFolder.Location = new System.Drawing.Point(13, 13);
            this.f_setRootFolder.Name = "f_setRootFolder";
            this.f_setRootFolder.Size = new System.Drawing.Size(150, 40);
            this.f_setRootFolder.TabIndex = 11;
            this.f_setRootFolder.Text = "Choose Root";
            this.f_setRootFolder.UseVisualStyleBackColor = true;
            this.f_setRootFolder.Click += new System.EventHandler(this.f_setRootFolder_Click);
            // 
            // f_filesResults
            // 
            this.f_filesResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.f_filesResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.c_folder,
            this.c_file,
            this.c_status});
            this.f_filesResults.ContextMenuStrip = this.f_fileResultsMenu;
            this.f_filesResults.FullRowSelect = true;
            this.f_filesResults.Location = new System.Drawing.Point(13, 118);
            this.f_filesResults.MultiSelect = false;
            this.f_filesResults.Name = "f_filesResults";
            this.f_filesResults.Size = new System.Drawing.Size(1136, 116);
            this.f_filesResults.TabIndex = 12;
            this.f_filesResults.UseCompatibleStateImageBehavior = false;
            this.f_filesResults.View = System.Windows.Forms.View.Details;
            this.f_filesResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.f_filesResults_ColumnClick);
            // 
            // c_folder
            // 
            this.c_folder.Text = "Folder";
            this.c_folder.Width = 400;
            // 
            // c_file
            // 
            this.c_file.Text = "File";
            this.c_file.Width = 500;
            // 
            // c_status
            // 
            this.c_status.Text = "Status";
            this.c_status.Width = 200;
            // 
            // f_fileResultsMenu
            // 
            this.f_fileResultsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.f_menuCopyName});
            this.f_fileResultsMenu.Name = "contextMenuStrip1";
            this.f_fileResultsMenu.Size = new System.Drawing.Size(179, 26);
            // 
            // f_menuCopyName
            // 
            this.f_menuCopyName.Name = "f_menuCopyName";
            this.f_menuCopyName.Size = new System.Drawing.Size(178, 22);
            this.f_menuCopyName.Text = "Copy File Name";
            this.f_menuCopyName.Click += new System.EventHandler(this.f_menuCopyName_Click);
            // 
            // f_filesChecked
            // 
            this.f_filesChecked.AutoSize = true;
            this.f_filesChecked.Location = new System.Drawing.Point(588, 21);
            this.f_filesChecked.Name = "f_filesChecked";
            this.f_filesChecked.Size = new System.Drawing.Size(129, 24);
            this.f_filesChecked.TabIndex = 14;
            this.f_filesChecked.Text = "Files Checked:";
            // 
            // f_close
            // 
            this.f_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.f_close.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_close.Location = new System.Drawing.Point(1059, 246);
            this.f_close.Name = "f_close";
            this.f_close.Size = new System.Drawing.Size(90, 25);
            this.f_close.TabIndex = 15;
            this.f_close.Text = "Close";
            this.f_close.UseVisualStyleBackColor = true;
            // 
            // f_fileType
            // 
            this.f_fileType.FormattingEnabled = true;
            this.f_fileType.Location = new System.Drawing.Point(277, 18);
            this.f_fileType.Name = "f_fileType";
            this.f_fileType.Size = new System.Drawing.Size(139, 32);
            this.f_fileType.TabIndex = 17;
            // 
            // f_threadStatus
            // 
            this.f_threadStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.f_threadStatus.AutoSize = true;
            this.f_threadStatus.Location = new System.Drawing.Point(29, 247);
            this.f_threadStatus.Name = "f_threadStatus";
            this.f_threadStatus.Size = new System.Drawing.Size(70, 24);
            this.f_threadStatus.TabIndex = 21;
            this.f_threadStatus.Text = "Thread:";
            // 
            // SetFilesProperty
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.f_threadStatus);
            this.Controls.Add(label2);
            this.Controls.Add(this.f_fileType);
            this.Controls.Add(this.f_close);
            this.Controls.Add(this.f_filesChecked);
            this.Controls.Add(this.f_filesResults);
            this.Controls.Add(this.f_setRootFolder);
            this.Controls.Add(this.f_run);
            this.Controls.Add(this.f_rootFolder);
            this.Controls.Add(label1);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SetFilesProperty";
            this.Size = new System.Drawing.Size(1162, 283);
            this.f_fileResultsMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox f_rootFolder;
        private System.Windows.Forms.Button f_run;
        private System.Windows.Forms.Button f_setRootFolder;
        private System.Windows.Forms.ListView f_filesResults;
        private System.Windows.Forms.ColumnHeader c_folder;
        private System.Windows.Forms.ColumnHeader c_file;
        private System.Windows.Forms.Label f_filesChecked;
        private System.Windows.Forms.Button f_close;
        private System.Windows.Forms.ColumnHeader c_status;
        private System.Windows.Forms.ComboBox f_fileType;
        private System.Windows.Forms.Label f_threadStatus;
        private System.Windows.Forms.ContextMenuStrip f_fileResultsMenu;
        private System.Windows.Forms.ToolStripMenuItem f_menuCopyName;
    }
}
