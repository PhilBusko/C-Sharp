namespace PictureShow
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.f_panelTop = new System.Windows.Forms.Panel();
            this.f_splitTop = new System.Windows.Forms.SplitContainer();
            this.n_deleteThumbsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.undeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f_filesView = new System.Windows.Forms.TreeView();
            this.f_saveFiles = new System.Windows.Forms.Button();
            this.f_panelBottom = new System.Windows.Forms.Panel();
            this.n_mainThumbsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.n_opsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.n_openPaintNet = new System.Windows.Forms.ToolStripMenuItem();
            this.n_opsRename = new System.Windows.Forms.ToolStripMenuItem();
            this.n_opsQuickName = new System.Windows.Forms.ToolStripMenuItem();
            this.f_splitter = new System.Windows.Forms.Splitter();
            this.n_sortGroup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.n_blurAll = new System.Windows.Forms.ToolStripMenuItem();
            this.n_deleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.f_deleteThumbs = new ImageControls.SmartFlowLayout();
            this.f_imageWorkspace = new ImageControls.ImageWorkspace();
            this.f_mainThumbs = new ImageControls.SmartFlowLayout();
            this.f_panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.f_splitTop)).BeginInit();
            this.f_splitTop.Panel1.SuspendLayout();
            this.f_splitTop.Panel2.SuspendLayout();
            this.f_splitTop.SuspendLayout();
            this.n_deleteThumbsMenu.SuspendLayout();
            this.f_panelBottom.SuspendLayout();
            this.n_mainThumbsMenu.SuspendLayout();
            this.n_sortGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // f_panelTop
            // 
            this.f_panelTop.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.f_panelTop.Controls.Add(this.f_splitTop);
            this.f_panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.f_panelTop.Location = new System.Drawing.Point(0, 0);
            this.f_panelTop.Margin = new System.Windows.Forms.Padding(4);
            this.f_panelTop.Name = "f_panelTop";
            this.f_panelTop.Size = new System.Drawing.Size(1219, 643);
            this.f_panelTop.TabIndex = 0;
            // 
            // f_splitTop
            // 
            this.f_splitTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.f_splitTop.Location = new System.Drawing.Point(0, 0);
            this.f_splitTop.Margin = new System.Windows.Forms.Padding(4);
            this.f_splitTop.Name = "f_splitTop";
            // 
            // f_splitTop.Panel1
            // 
            this.f_splitTop.Panel1.BackColor = System.Drawing.Color.Pink;
            this.f_splitTop.Panel1.Controls.Add(this.f_deleteThumbs);
            this.f_splitTop.Panel1.Controls.Add(this.f_filesView);
            this.f_splitTop.Panel1.Controls.Add(this.f_saveFiles);
            // 
            // f_splitTop.Panel2
            // 
            this.f_splitTop.Panel2.Controls.Add(this.f_imageWorkspace);
            this.f_splitTop.Size = new System.Drawing.Size(1219, 643);
            this.f_splitTop.SplitterDistance = 220;
            this.f_splitTop.SplitterWidth = 5;
            this.f_splitTop.TabIndex = 0;
            // 
            // n_deleteThumbsMenu
            // 
            this.n_deleteThumbsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undeleteToolStripMenuItem});
            this.n_deleteThumbsMenu.Name = "n_deleteThumbs";
            this.n_deleteThumbsMenu.Size = new System.Drawing.Size(134, 26);
            // 
            // undeleteToolStripMenuItem
            // 
            this.undeleteToolStripMenuItem.Name = "undeleteToolStripMenuItem";
            this.undeleteToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.undeleteToolStripMenuItem.Text = "Undelete";
            this.undeleteToolStripMenuItem.Click += new System.EventHandler(this.undeleteToolStripMenuItem_Click);
            // 
            // f_filesView
            // 
            this.f_filesView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.f_filesView.ContextMenuStrip = this.n_sortGroup;
            this.f_filesView.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_filesView.Location = new System.Drawing.Point(16, 64);
            this.f_filesView.Margin = new System.Windows.Forms.Padding(4);
            this.f_filesView.Name = "f_filesView";
            this.f_filesView.Size = new System.Drawing.Size(178, 296);
            this.f_filesView.TabIndex = 1;
            this.f_filesView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.f_filesView_BeforeSelect);
            this.f_filesView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.f_filesView_AfterSelect);
            this.f_filesView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.f_filesView_KeyPress);
            // 
            // f_saveFiles
            // 
            this.f_saveFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.f_saveFiles.BackColor = System.Drawing.Color.Gold;
            this.f_saveFiles.Location = new System.Drawing.Point(16, 15);
            this.f_saveFiles.Margin = new System.Windows.Forms.Padding(4);
            this.f_saveFiles.Name = "f_saveFiles";
            this.f_saveFiles.Size = new System.Drawing.Size(180, 31);
            this.f_saveFiles.TabIndex = 1;
            this.f_saveFiles.Text = "Save && Close";
            this.f_saveFiles.UseVisualStyleBackColor = false;
            this.f_saveFiles.Click += new System.EventHandler(this.f_saveFiles_Click);
            // 
            // f_panelBottom
            // 
            this.f_panelBottom.Controls.Add(this.f_mainThumbs);
            this.f_panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.f_panelBottom.Location = new System.Drawing.Point(0, 653);
            this.f_panelBottom.Margin = new System.Windows.Forms.Padding(4);
            this.f_panelBottom.Name = "f_panelBottom";
            this.f_panelBottom.Size = new System.Drawing.Size(1219, 181);
            this.f_panelBottom.TabIndex = 2;
            // 
            // n_mainThumbsMenu
            // 
            this.n_mainThumbsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.n_opsDelete,
            this.n_openPaintNet,
            this.n_opsRename,
            this.n_opsQuickName});
            this.n_mainThumbsMenu.Name = "n_thumbsOperations";
            this.n_mainThumbsMenu.Size = new System.Drawing.Size(189, 92);
            // 
            // n_opsDelete
            // 
            this.n_opsDelete.Name = "n_opsDelete";
            this.n_opsDelete.Size = new System.Drawing.Size(188, 22);
            this.n_opsDelete.Text = "Delete";
            this.n_opsDelete.Click += new System.EventHandler(this.n_opsDelete_Click);
            // 
            // n_openPaintNet
            // 
            this.n_openPaintNet.Name = "n_openPaintNet";
            this.n_openPaintNet.Size = new System.Drawing.Size(188, 22);
            this.n_openPaintNet.Text = "Open in Paint.net";
            this.n_openPaintNet.Click += new System.EventHandler(this.n_openPaintNet_Click);
            // 
            // n_opsRename
            // 
            this.n_opsRename.Name = "n_opsRename";
            this.n_opsRename.Size = new System.Drawing.Size(188, 22);
            this.n_opsRename.Text = "Rename";
            this.n_opsRename.Click += new System.EventHandler(this.n_opsRename_Click);
            // 
            // n_opsQuickName
            // 
            this.n_opsQuickName.Name = "n_opsQuickName";
            this.n_opsQuickName.Size = new System.Drawing.Size(188, 22);
            this.n_opsQuickName.Text = "Quick Name";
            // 
            // f_splitter
            // 
            this.f_splitter.BackColor = System.Drawing.SystemColors.Desktop;
            this.f_splitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.f_splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.f_splitter.Location = new System.Drawing.Point(0, 643);
            this.f_splitter.Margin = new System.Windows.Forms.Padding(4);
            this.f_splitter.Name = "f_splitter";
            this.f_splitter.Size = new System.Drawing.Size(1219, 10);
            this.f_splitter.TabIndex = 3;
            this.f_splitter.TabStop = false;
            // 
            // n_sortGroup
            // 
            this.n_sortGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.n_deleteAll,
            this.n_blurAll});
            this.n_sortGroup.Name = "n_sortGroup";
            this.n_sortGroup.Size = new System.Drawing.Size(153, 70);
            // 
            // n_blurAll
            // 
            this.n_blurAll.Name = "n_blurAll";
            this.n_blurAll.Size = new System.Drawing.Size(152, 22);
            this.n_blurAll.Text = "Blur All";
            this.n_blurAll.Click += new System.EventHandler(this.n_blurAll_Click);
            // 
            // n_deleteAll
            // 
            this.n_deleteAll.Name = "n_deleteAll";
            this.n_deleteAll.Size = new System.Drawing.Size(152, 22);
            this.n_deleteAll.Text = "Delete All";
            this.n_deleteAll.Click += new System.EventHandler(this.n_deleteAll_Click);
            // 
            // f_deleteThumbs
            // 
            this.f_deleteThumbs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.f_deleteThumbs.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.f_deleteThumbs.ContextMenuStrip = this.n_deleteThumbsMenu;
            this.f_deleteThumbs.Location = new System.Drawing.Point(16, 382);
            this.f_deleteThumbs.Margin = new System.Windows.Forms.Padding(5);
            this.f_deleteThumbs.Name = "f_deleteThumbs";
            this.f_deleteThumbs.Size = new System.Drawing.Size(180, 241);
            this.f_deleteThumbs.TabIndex = 1;
            // 
            // f_imageWorkspace
            // 
            this.f_imageWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.f_imageWorkspace.Location = new System.Drawing.Point(0, 0);
            this.f_imageWorkspace.Margin = new System.Windows.Forms.Padding(4);
            this.f_imageWorkspace.Name = "f_imageWorkspace";
            this.f_imageWorkspace.Size = new System.Drawing.Size(994, 643);
            this.f_imageWorkspace.TabIndex = 0;
            // 
            // f_mainThumbs
            // 
            this.f_mainThumbs.BackColor = System.Drawing.SystemColors.ControlLight;
            this.f_mainThumbs.ContextMenuStrip = this.n_mainThumbsMenu;
            this.f_mainThumbs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.f_mainThumbs.Location = new System.Drawing.Point(0, 0);
            this.f_mainThumbs.Margin = new System.Windows.Forms.Padding(5);
            this.f_mainThumbs.Name = "f_mainThumbs";
            this.f_mainThumbs.Size = new System.Drawing.Size(1219, 181);
            this.f_mainThumbs.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1219, 834);
            this.Controls.Add(this.f_panelTop);
            this.Controls.Add(this.f_splitter);
            this.Controls.Add(this.f_panelBottom);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Picture Show";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.DoubleClick += new System.EventHandler(this.MainForm_DoubleClick);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.f_panelTop.ResumeLayout(false);
            this.f_splitTop.Panel1.ResumeLayout(false);
            this.f_splitTop.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.f_splitTop)).EndInit();
            this.f_splitTop.ResumeLayout(false);
            this.n_deleteThumbsMenu.ResumeLayout(false);
            this.f_panelBottom.ResumeLayout(false);
            this.n_mainThumbsMenu.ResumeLayout(false);
            this.n_sortGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel f_panelTop;
        private System.Windows.Forms.Panel f_panelBottom;
        private ImageControls.SmartFlowLayout f_mainThumbs;
        private System.Windows.Forms.Splitter f_splitter;
        private ImageControls.ImageWorkspace f_imageWorkspace;
        private System.Windows.Forms.SplitContainer f_splitTop;
        private System.Windows.Forms.TreeView f_filesView;
        private System.Windows.Forms.Button f_saveFiles;
        private System.Windows.Forms.ContextMenuStrip n_mainThumbsMenu;
        private System.Windows.Forms.ToolStripMenuItem n_opsDelete;
        private System.Windows.Forms.ToolStripMenuItem n_opsRename;
        private ImageControls.SmartFlowLayout f_deleteThumbs;
        private System.Windows.Forms.ContextMenuStrip n_deleteThumbsMenu;
        private System.Windows.Forms.ToolStripMenuItem undeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem n_opsQuickName;
        private System.Windows.Forms.ToolStripMenuItem n_openPaintNet;
        private System.Windows.Forms.ContextMenuStrip n_sortGroup;
        private System.Windows.Forms.ToolStripMenuItem n_deleteAll;
        private System.Windows.Forms.ToolStripMenuItem n_blurAll;


    }
}

