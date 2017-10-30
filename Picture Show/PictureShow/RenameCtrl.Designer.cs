namespace PictureShow
{
    partial class RenameCtrl
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
            this.f_renameBox = new System.Windows.Forms.ComboBox();
            this.f_finish = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // f_renameBox
            // 
            this.f_renameBox.FormattingEnabled = true;
            this.f_renameBox.Location = new System.Drawing.Point(12, 13);
            this.f_renameBox.Name = "f_renameBox";
            this.f_renameBox.Size = new System.Drawing.Size(280, 24);
            this.f_renameBox.TabIndex = 0;
            // 
            // f_finish
            // 
            this.f_finish.Location = new System.Drawing.Point(192, 43);
            this.f_finish.Name = "f_finish";
            this.f_finish.Size = new System.Drawing.Size(100, 28);
            this.f_finish.TabIndex = 1;
            this.f_finish.Text = "Ok Go";
            this.f_finish.UseVisualStyleBackColor = true;
            this.f_finish.Click += new System.EventHandler(this.f_finish_Click);
            // 
            // RenameCtrl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.f_finish);
            this.Controls.Add(this.f_renameBox);
            this.Name = "RenameCtrl";
            this.Size = new System.Drawing.Size(303, 94);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox f_renameBox;
        private System.Windows.Forms.Button f_finish;
    }
}
