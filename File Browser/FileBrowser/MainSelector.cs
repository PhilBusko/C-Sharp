using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utility;

/**************************************************************************************************
MAIN SELECTOR CTRL
**************************************************************************************************/

namespace FileBrowser
{
    public partial class MainSelector : UserControl, IFileBrowserCtrl
    {

        #region Control Basics

        // constructor
        public MainSelector()
        {
            InitializeComponent();

        }

        // implement IFileBrowserCtrl
        public void Initialize()
        {
            (this.Parent as BaseForm).Text = "FileBrowser Main";
            (this.Parent as BaseForm).SetMode_Dialog();

            f_close.Click += new EventHandler((this.Parent as BaseForm).ctrlCloseClick);
        }

        public bool StopCtrlThread()
        {
            return false;
        }


        #endregion


        #region User Controls


        // Set Files' Property
        private void f_setSortProp_Click(object sender, EventArgs e)
        {
            // Program.MainForm.Hide();

            BaseForm nf = new BaseForm(new SetFilesProperty());
            nf.Show();
        }

        // Replace File Names
        private void f_replaceFileNames_Click(object sender, EventArgs e)
        {
            // Program.MainForm.Hide();

            BaseForm nf = new BaseForm(new ReplaceFileNames());
            nf.Show();
        }

        // File Standardizor
        private void f_standardize_Click(object sender, EventArgs e)
        {
            // Program.MainForm.Hide();

            BaseForm nf = new BaseForm(new FileStandardizorCtrl());
            nf.Show();
        }


        // Create Sorted File Names
        private void sortedFileNames_Click(object sender, EventArgs e)
        {
            // Program.MainForm.Hide();

            BaseForm bf = new BaseForm(new SortFileNames());
            bf.Show();
        }

        // Create Entry Sort Names 
        private void f_createEntrySeries_Click(object sender, EventArgs e)
        {
            // Program.MainForm.Hide();

            BaseForm nf = new BaseForm(new EntrySortCtrl());
            nf.Show();
        }


        // Folder Browser button
        private void f_folderBrowser_Click(object sender, EventArgs e)
        {
            // Program.MainForm.Hide();

            FolderBrowser fs = new FolderBrowser();
            fs.Show();
        }



        #endregion


        #region Common Form Config

        public static string GetLastFolder()
        {
            if (System.IO.Directory.Exists(Properties.Settings.Default.LastInputFolder) == true)
                return Properties.Settings.Default.LastInputFolder;

            else if (System.IO.Directory.Exists(
                Utility.StringFormat.GoUpDirectory(Properties.Settings.Default.LastInputFolder)) == true)
                return Utility.StringFormat.GoUpDirectory(Properties.Settings.Default.LastInputFolder);

            else
                return Properties.Settings.Default.DocFolder;
        }

        public static void SetLastFolder(string p_lastFolder)
        {
            Properties.Settings.Default.LastInputFolder = p_lastFolder;
            Properties.Settings.Default.Save();
        }

        #endregion

    }
}
