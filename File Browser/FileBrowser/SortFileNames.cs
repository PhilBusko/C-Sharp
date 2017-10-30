/**************************************************************************************************
SORT FILE NAME
 * Responsible for all
**************************************************************************************************/

#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Utility;

#endregion


namespace FileBrowser
{
    public partial class SortFileNames : UserControl, IFileBrowserCtrl
    {


        #region Control Basics

        // constructor
        public SortFileNames()
        {
            InitializeComponent();

            f_close.Enabled = false;
        }

        // implement IFileBrowserCtrl
        void IFileBrowserCtrl.Initialize()
        {
            (this.Parent as BaseForm).Text = "Create Sorted File Names";
            (this.Parent as BaseForm).SetMode_Dialog();

            f_close.Click += new EventHandler((this.Parent as BaseForm).ctrlCloseClick);
        }

        private ThreadMessage myThread;

        public bool StopCtrlThread()
        {
            if (myThread.GetThread.IsAlive == false)
                return false;

            try
            {
                myThread.GetThread.Abort();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Stop Thread");
                return false;
            }

            return true;
        }


        #endregion


        private void f_openFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Choose Folder To Sort Files In";
                fbd.SelectedPath = MainSelector.GetLastFolder();

                if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;

                f_folderPath.Text = fbd.SelectedPath;
                MainSelector.SetLastFolder(fbd.SelectedPath);
            }
        }

        private void f_okgo_Click(object sender, EventArgs e)
        {
            // error checking

            string folderPath = f_folderPath.Text;
            string keyword = f_keyword.Text;

            if (Directory.Exists(folderPath) == false)
                return;

            if (string.IsNullOrEmpty(keyword))
                return;

            // run file name editing over all files in folder

            Cursor.Current = Cursors.WaitCursor;

            FileSystem.RunCreateSortedFN(folderPath, keyword);

            Cursor.Current = Cursors.Default;

            f_close.Enabled = true;
        }

    }
}
