namespace DesktopDisplay
{
    partial class ChangerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangerForm));
            this.f_taskIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.f_taskMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openImage1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImage2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f_monitorTabs = new System.Windows.Forms.TabControl();
            this.f_monitorPage1 = new System.Windows.Forms.TabPage();
            this.f_monitorPage2 = new System.Windows.Forms.TabPage();
            this.f_mainMenu = new System.Windows.Forms.MenuStrip();
            this.f_saveRestartItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f_optionsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitorConfigCtrl1 = new DesktopDisplay.DisplayCtrl();
            this.monitorConfigCtrl2 = new DesktopDisplay.DisplayCtrl();
            this.f_taskMenu.SuspendLayout();
            this.f_monitorTabs.SuspendLayout();
            this.f_monitorPage1.SuspendLayout();
            this.f_monitorPage2.SuspendLayout();
            this.f_mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // f_taskIcon
            // 
            this.f_taskIcon.ContextMenuStrip = this.f_taskMenu;
            this.f_taskIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("f_taskIcon.Icon")));
            this.f_taskIcon.Text = "Computernator";
            this.f_taskIcon.Visible = true;
            this.f_taskIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.f_taskIcon_MouseDoubleClick);
            // 
            // f_taskMenu
            // 
            this.f_taskMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImage1ToolStripMenuItem,
            this.openImage2ToolStripMenuItem,
            this.previousImageToolStripMenuItem,
            this.nextImageToolStripMenuItem});
            this.f_taskMenu.Name = "f_taskMenu";
            this.f_taskMenu.Size = new System.Drawing.Size(179, 92);
            // 
            // openImage1ToolStripMenuItem
            // 
            this.openImage1ToolStripMenuItem.Name = "openImage1ToolStripMenuItem";
            this.openImage1ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.openImage1ToolStripMenuItem.Text = "Open Image1";
            this.openImage1ToolStripMenuItem.Click += new System.EventHandler(this.openImage1ToolStripMenuItem_Click);
            // 
            // openImage2ToolStripMenuItem
            // 
            this.openImage2ToolStripMenuItem.Name = "openImage2ToolStripMenuItem";
            this.openImage2ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.openImage2ToolStripMenuItem.Text = "Open Image2";
            this.openImage2ToolStripMenuItem.Click += new System.EventHandler(this.openImage2ToolStripMenuItem_Click);
            // 
            // previousImageToolStripMenuItem
            // 
            this.previousImageToolStripMenuItem.Name = "previousImageToolStripMenuItem";
            this.previousImageToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.previousImageToolStripMenuItem.Text = "Previous Image";
            this.previousImageToolStripMenuItem.Click += new System.EventHandler(this.previousImageToolStripMenuItem_Click);
            // 
            // nextImageToolStripMenuItem
            // 
            this.nextImageToolStripMenuItem.Name = "nextImageToolStripMenuItem";
            this.nextImageToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.nextImageToolStripMenuItem.Text = "Next Image";
            this.nextImageToolStripMenuItem.Click += new System.EventHandler(this.nextImageToolStripMenuItem_Click);
            // 
            // f_monitorTabs
            // 
            this.f_monitorTabs.Controls.Add(this.f_monitorPage1);
            this.f_monitorTabs.Controls.Add(this.f_monitorPage2);
            this.f_monitorTabs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.f_monitorTabs.Location = new System.Drawing.Point(0, 29);
            this.f_monitorTabs.Name = "f_monitorTabs";
            this.f_monitorTabs.SelectedIndex = 0;
            this.f_monitorTabs.Size = new System.Drawing.Size(693, 487);
            this.f_monitorTabs.TabIndex = 1;
            // 
            // f_monitorPage1
            // 
            this.f_monitorPage1.Controls.Add(this.monitorConfigCtrl1);
            this.f_monitorPage1.Location = new System.Drawing.Point(4, 29);
            this.f_monitorPage1.Name = "f_monitorPage1";
            this.f_monitorPage1.Padding = new System.Windows.Forms.Padding(3);
            this.f_monitorPage1.Size = new System.Drawing.Size(685, 454);
            this.f_monitorPage1.TabIndex = 0;
            this.f_monitorPage1.Text = "Monitor 1";
            this.f_monitorPage1.UseVisualStyleBackColor = true;
            // 
            // f_monitorPage2
            // 
            this.f_monitorPage2.Controls.Add(this.monitorConfigCtrl2);
            this.f_monitorPage2.Location = new System.Drawing.Point(4, 29);
            this.f_monitorPage2.Name = "f_monitorPage2";
            this.f_monitorPage2.Padding = new System.Windows.Forms.Padding(3);
            this.f_monitorPage2.Size = new System.Drawing.Size(685, 384);
            this.f_monitorPage2.TabIndex = 1;
            this.f_monitorPage2.Text = "Monitor 2";
            this.f_monitorPage2.UseVisualStyleBackColor = true;
            // 
            // f_mainMenu
            // 
            this.f_mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.f_saveRestartItem,
            this.f_optionsItem});
            this.f_mainMenu.Location = new System.Drawing.Point(0, 0);
            this.f_mainMenu.Name = "f_mainMenu";
            this.f_mainMenu.Size = new System.Drawing.Size(693, 26);
            this.f_mainMenu.TabIndex = 2;
            this.f_mainMenu.Text = "menuStrip1";
            // 
            // f_saveRestartItem
            // 
            this.f_saveRestartItem.Name = "f_saveRestartItem";
            this.f_saveRestartItem.Size = new System.Drawing.Size(119, 22);
            this.f_saveRestartItem.Text = "Save && Restart";
            this.f_saveRestartItem.Click += new System.EventHandler(this.f_saveRestartItem_Click);
            // 
            // f_optionsItem
            // 
            this.f_optionsItem.Name = "f_optionsItem";
            this.f_optionsItem.Size = new System.Drawing.Size(69, 22);
            this.f_optionsItem.Text = "Options";
            this.f_optionsItem.Click += new System.EventHandler(this.f_optionsItem_Click);
            // 
            // monitorConfigCtrl1
            // 
            this.monitorConfigCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monitorConfigCtrl1.Font = new System.Drawing.Font("Footlight MT Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monitorConfigCtrl1.Location = new System.Drawing.Point(3, 3);
            this.monitorConfigCtrl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.monitorConfigCtrl1.Name = "monitorConfigCtrl1";
            this.monitorConfigCtrl1.Size = new System.Drawing.Size(679, 448);
            this.monitorConfigCtrl1.TabIndex = 0;
            // 
            // monitorConfigCtrl2
            // 
            this.monitorConfigCtrl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monitorConfigCtrl2.Font = new System.Drawing.Font("Footlight MT Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monitorConfigCtrl2.Location = new System.Drawing.Point(3, 3);
            this.monitorConfigCtrl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.monitorConfigCtrl2.Name = "monitorConfigCtrl2";
            this.monitorConfigCtrl2.Size = new System.Drawing.Size(679, 382);
            this.monitorConfigCtrl2.TabIndex = 0;
            // 
            // ChangerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(693, 516);
            this.Controls.Add(this.f_mainMenu);
            this.Controls.Add(this.f_monitorTabs);
            this.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.f_mainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ChangerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smart Desktop Changer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChangerForm_FormClosed);
            this.Load += new System.EventHandler(this.ChangerForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ChangerForm_KeyPress);
            this.Resize += new System.EventHandler(this.ChangerForm_Resize);
            this.f_taskMenu.ResumeLayout(false);
            this.f_monitorTabs.ResumeLayout(false);
            this.f_monitorPage1.ResumeLayout(false);
            this.f_monitorPage2.ResumeLayout(false);
            this.f_mainMenu.ResumeLayout(false);
            this.f_mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon f_taskIcon;
        private System.Windows.Forms.ContextMenuStrip f_taskMenu;
        private System.Windows.Forms.ToolStripMenuItem openImage1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImage2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previousImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextImageToolStripMenuItem;
        private System.Windows.Forms.TabControl f_monitorTabs;
        private System.Windows.Forms.TabPage f_monitorPage1;
        private System.Windows.Forms.TabPage f_monitorPage2;
        private DisplayCtrl monitorConfigCtrl1;
        private DisplayCtrl monitorConfigCtrl2;
        private System.Windows.Forms.MenuStrip f_mainMenu;
        private System.Windows.Forms.ToolStripMenuItem f_saveRestartItem;
        private System.Windows.Forms.ToolStripMenuItem f_optionsItem;
    }
}