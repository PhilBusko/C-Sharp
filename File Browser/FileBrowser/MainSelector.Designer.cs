namespace FileBrowser
{
    partial class MainSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainSelector));
            this.f_changeFilesText = new System.Windows.Forms.Button();
            this.f_fileSortProp = new System.Windows.Forms.Button();
            this.f_standardize = new System.Windows.Forms.Button();
            this.tt_main = new System.Windows.Forms.ToolTip(this.components);
            this.f_createSmallSeries = new System.Windows.Forms.Button();
            this.f_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // f_changeFilesText
            // 
            this.f_changeFilesText.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_changeFilesText.Location = new System.Drawing.Point(363, 17);
            this.f_changeFilesText.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.f_changeFilesText.Name = "f_changeFilesText";
            this.f_changeFilesText.Size = new System.Drawing.Size(308, 45);
            this.f_changeFilesText.TabIndex = 6;
            this.f_changeFilesText.Text = "Search/Replace File Name";
            this.tt_main.SetToolTip(this.f_changeFilesText, "Replaces text in the file name with a user input text.\r\nWorks for file extensions" +
                    " also.");
            this.f_changeFilesText.UseVisualStyleBackColor = true;
            this.f_changeFilesText.Click += new System.EventHandler(this.f_replaceFileNames_Click);
            // 
            // f_fileSortProp
            // 
            this.f_fileSortProp.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_fileSortProp.Location = new System.Drawing.Point(17, 17);
            this.f_fileSortProp.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.f_fileSortProp.Name = "f_fileSortProp";
            this.f_fileSortProp.Size = new System.Drawing.Size(308, 45);
            this.f_fileSortProp.TabIndex = 9;
            this.f_fileSortProp.Text = "Set Files\' Property";
            this.tt_main.SetToolTip(this.f_fileSortProp, "Sets an image\'s Tag property based on file name.\r\nSets a mp3\'s album tag based on" +
                    " file name and album cover repository.\r\nCan expand to other file types.");
            this.f_fileSortProp.UseVisualStyleBackColor = true;
            this.f_fileSortProp.Click += new System.EventHandler(this.f_setSortProp_Click);
            // 
            // f_standardize
            // 
            this.f_standardize.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_standardize.Location = new System.Drawing.Point(17, 80);
            this.f_standardize.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.f_standardize.Name = "f_standardize";
            this.f_standardize.Size = new System.Drawing.Size(308, 45);
            this.f_standardize.TabIndex = 10;
            this.f_standardize.Text = "File Standardizor";
            this.tt_main.SetToolTip(this.f_standardize, resources.GetString("f_standardize.ToolTip"));
            this.f_standardize.UseVisualStyleBackColor = true;
            this.f_standardize.Click += new System.EventHandler(this.f_standardize_Click);
            // 
            // tt_main
            // 
            this.tt_main.AutoPopDelay = 20000;
            this.tt_main.InitialDelay = 500;
            this.tt_main.IsBalloon = true;
            this.tt_main.ReshowDelay = 100;
            // 
            // f_createSmallSeries
            // 
            this.f_createSmallSeries.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_createSmallSeries.Location = new System.Drawing.Point(363, 80);
            this.f_createSmallSeries.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.f_createSmallSeries.Name = "f_createSmallSeries";
            this.f_createSmallSeries.Size = new System.Drawing.Size(308, 45);
            this.f_createSmallSeries.TabIndex = 13;
            this.f_createSmallSeries.Text = "Create Entry Sort Names";
            this.tt_main.SetToolTip(this.f_createSmallSeries, resources.GetString("f_createSmallSeries.ToolTip"));
            this.f_createSmallSeries.UseVisualStyleBackColor = true;
            this.f_createSmallSeries.Click += new System.EventHandler(this.f_createEntrySeries_Click);
            // 
            // f_close
            // 
            this.f_close.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_close.Location = new System.Drawing.Point(131, 148);
            this.f_close.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.f_close.Name = "f_close";
            this.f_close.Size = new System.Drawing.Size(430, 67);
            this.f_close.TabIndex = 12;
            this.f_close.Text = "CLOSE";
            this.f_close.UseVisualStyleBackColor = true;
            // 
            // MainSelector
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.f_createSmallSeries);
            this.Controls.Add(this.f_close);
            this.Controls.Add(this.f_standardize);
            this.Controls.Add(this.f_fileSortProp);
            this.Controls.Add(this.f_changeFilesText);
            this.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainSelector";
            this.Size = new System.Drawing.Size(693, 235);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button f_changeFilesText;
        private System.Windows.Forms.Button f_fileSortProp;
        private System.Windows.Forms.Button f_standardize;
        private System.Windows.Forms.ToolTip tt_main;
        private System.Windows.Forms.Button f_close;
        private System.Windows.Forms.Button f_createSmallSeries;
    }
}
