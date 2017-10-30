/**************************************************************************************************
CHANGER FORM
**************************************************************************************************/

#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using Utility;

#endregion


namespace DesktopDisplay
{
    public partial class ChangerForm : Form
    {

        #region Basics


        private bool StartWithWindows = true;
        private bool ChangeOnStartup = true;


        //Utility.Hotkey hk;

        public ChangerForm()
        {
            InitializeComponent();

            // clear the designer; tabs are just created in designer for sizing 
            f_monitorTabs.TabPages.Clear();

            // add a tab page and initialize its data
            // based on monitors available and data files

            for (int m = 0; m < System.Windows.Forms.Screen.AllScreens.Length; m++)
			{
                Screen monitor = System.Windows.Forms.Screen.AllScreens[m];
                
                // create the custom control that goes on tab page

                DisplayCtrl configCtrl = new DisplayCtrl(monitor, m+1);
                configCtrl.Dock = DockStyle.Fill;
                configCtrl.FormDirty += new DisplayCtrl.ControlEvent(configCtrl_FormDirty);
                configCtrl.UpdateWallpaper += new DisplayCtrl.ControlEvent(configCtrl_ClockTick);

                // create page and add the custom control

                TabPage createPage = new TabPage();
                createPage.Text = "Monitor " + (m + 1);

                createPage.Controls.Add(configCtrl);
                f_monitorTabs.TabPages.Add(createPage);

                configCtrl.StartTimer();
            }

        }

        private void configCtrl_FormDirty()
        {
            f_saveRestartItem.BackColor = Color.Red;
        }

        private void configCtrl_ClockTick()
        {
            this.UpdateDesktop();
        }

/*   
        hk = new Utility.Hotkey();
        hk.KeyCode = Keys.F;
        hk.Shift = true;

        hk.Pressed += new HandledEventHandler(NextHotkey_Pressed);

        if (!hk.GetCanRegister(this))
            MessageBox.Show("attempts to register hotkey will fail");
        else
            hk.Register(this);

          
        private void NextHotkey_Pressed(object sender, HandledEventArgs e)
        {
            this.f_taskIcon.ShowBalloonTip(10000, "hotkey title", "htkey pressd", ToolTipIcon.Error);
            this.ChangeDesktop();
        }
*/


        #endregion



        #region Form Behavior


        private void ChangerForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            if (this.ChangeOnStartup == true)
            {
                foreach (TabPage page in f_monitorTabs.TabPages)
                {
                    DisplayCtrl configCtrl = (DisplayCtrl)page.Controls[0];

                    configCtrl.Config.GoToNextImagePath();
                }

                this.UpdateDesktop();
            }
        }

        private void ChangerForm_Resize(object sender, EventArgs e)
        {
            // note: NotifyIcon must have an icon image to work

            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
            }

            else if (this.WindowState == FormWindowState.Normal)
            {
                this.ShowInTaskbar = true;
            }
        }

        private void ChangerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // task icon tends to linger once app is closed
            // http://www.csharp411.com/notifyiconshowballoontip-issues/
            f_taskIcon.Visible = false;
        }


        #endregion



        #region User Input

        /// <summary>
        /// KeyPress event handler. Requires KeyPreview = true.
        /// </summary>
        private void ChangerForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Escape Key
            if (e.KeyChar == 27)
            {
                this.WindowState = FormWindowState.Minimized;      // calls _Resize()
            }
        }


        // main menu

        private void f_saveRestartItem_Click(object sender, EventArgs e)
        {
            for (int p = 0; p < f_monitorTabs.TabPages.Count; p++)
            {
                TabPage page = f_monitorTabs.TabPages[p];
                DisplayCtrl configCtrl = (DisplayCtrl)page.Controls[0];

                configCtrl.SaveDataToFile();
                configCtrl.StartTimer();
            }

            f_saveRestartItem.BackColor = SystemColors.Control;
            this.UpdateDesktop();
        }

        private void f_optionsItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented");
        }


        // system tray menu

        private void f_taskIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;      // calls _Resize()
        }

        private void openImage1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage page = f_monitorTabs.TabPages[0];
            DisplayCtrl configCtrl = (DisplayCtrl)page.Controls[0];

            OpenFileDefault(configCtrl.Config.FilePath);
        }

        private void openImage2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage page = f_monitorTabs.TabPages[1];
            DisplayCtrl configCtrl = (DisplayCtrl)page.Controls[0];

            OpenFileDefault(configCtrl.Config.FilePath);
        }

        private void previousImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int p = 0; p < f_monitorTabs.TabPages.Count; p++)
            {
                TabPage page = f_monitorTabs.TabPages[p];
                DisplayCtrl configCtrl = (DisplayCtrl)page.Controls[0];

                configCtrl.Config.GoToPreviousImagePath();
            }

            this.UpdateDesktop();
        }

        private void nextImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int p = 0; p < f_monitorTabs.TabPages.Count; p++)
            {
                TabPage page = f_monitorTabs.TabPages[p];
                DisplayCtrl configCtrl = (DisplayCtrl)page.Controls[0];

                configCtrl.Config.GoToNextImagePath();
            }

            this.UpdateDesktop();
        }


        #endregion



        #region Common Functions

        /// <summary>
        /// Updates the wallpapers and system tray balloon.
        /// Uses the current screen and image path associated with each monitor. 
        /// </summary>
        private void UpdateDesktop()
        {
            string msg = "";

            List<DisplayConfig> displays = new List<DisplayConfig>();

            for (int p = 0; p < f_monitorTabs.TabPages.Count; p++)
            {
                TabPage page = f_monitorTabs.TabPages[p];
                DisplayCtrl configCtrl = (DisplayCtrl)page.Controls[0];

                DisplayConfig config = configCtrl.Config;

                displays.Add(config);

                msg += string.Format("{0}] {1}\n", p + 1, Path.GetFileNameWithoutExtension(config.FilePath));
            }

            f_taskIcon.Text = (msg.Length > 63 ? msg.Substring(0, 63) : msg);

            try
            {
                SystemCommands.Set(displays);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ChangerForm: Error in Setting Wallpaper");
            }
        }

        private void OpenFileDefault(string path)
        {
            if (File.Exists(path))
                System.Diagnostics.Process.Start(path);
        }


        #endregion


    }

}
