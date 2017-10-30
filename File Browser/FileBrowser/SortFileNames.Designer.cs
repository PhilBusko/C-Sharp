namespace FileBrowser
{
    partial class SortFileNames
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
            System.Windows.Forms.Label label;
            this.f_keyword = new System.Windows.Forms.TextBox();
            this.f_okgo = new System.Windows.Forms.Button();
            this.f_openFolder = new System.Windows.Forms.Button();
            this.f_folderPath = new System.Windows.Forms.TextBox();
            this.f_close = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 113);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(96, 21);
            label1.TabIndex = 13;
            label1.Text = "All Keyword:";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(13, 70);
            label.Name = "label";
            label.Size = new System.Drawing.Size(58, 21);
            label.TabIndex = 12;
            label.Text = "Folder:";
            // 
            // f_keyword
            // 
            this.f_keyword.Location = new System.Drawing.Point(144, 110);
            this.f_keyword.Name = "f_keyword";
            this.f_keyword.Size = new System.Drawing.Size(158, 28);
            this.f_keyword.TabIndex = 14;
            // 
            // f_okgo
            // 
            this.f_okgo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.f_okgo.Location = new System.Drawing.Point(500, 147);
            this.f_okgo.Name = "f_okgo";
            this.f_okgo.Size = new System.Drawing.Size(248, 43);
            this.f_okgo.TabIndex = 11;
            this.f_okgo.Text = "Ok Go";
            this.f_okgo.UseVisualStyleBackColor = true;
            this.f_okgo.Click += new System.EventHandler(this.f_okgo_Click);
            // 
            // f_openFolder
            // 
            this.f_openFolder.Location = new System.Drawing.Point(14, 13);
            this.f_openFolder.Name = "f_openFolder";
            this.f_openFolder.Size = new System.Drawing.Size(237, 40);
            this.f_openFolder.TabIndex = 10;
            this.f_openFolder.Text = "Choose Folder";
            this.f_openFolder.UseVisualStyleBackColor = true;
            this.f_openFolder.Click += new System.EventHandler(this.f_openFolder_Click);
            // 
            // f_folderPath
            // 
            this.f_folderPath.Location = new System.Drawing.Point(144, 67);
            this.f_folderPath.Name = "f_folderPath";
            this.f_folderPath.Size = new System.Drawing.Size(800, 28);
            this.f_folderPath.TabIndex = 15;
            // 
            // f_close
            // 
            this.f_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.f_close.Location = new System.Drawing.Point(841, 151);
            this.f_close.Name = "f_close";
            this.f_close.Size = new System.Drawing.Size(75, 35);
            this.f_close.TabIndex = 16;
            this.f_close.Text = "Close";
            this.f_close.UseVisualStyleBackColor = true;
            // 
            // SortFileNames
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.f_close);
            this.Controls.Add(this.f_folderPath);
            this.Controls.Add(this.f_keyword);
            this.Controls.Add(label1);
            this.Controls.Add(label);
            this.Controls.Add(this.f_okgo);
            this.Controls.Add(this.f_openFolder);
            this.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SortFileNames";
            this.Size = new System.Drawing.Size(966, 219);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox f_keyword;
        private System.Windows.Forms.Button f_okgo;
        private System.Windows.Forms.Button f_openFolder;
        private System.Windows.Forms.TextBox f_folderPath;
        private System.Windows.Forms.Button f_close;
    }
}
