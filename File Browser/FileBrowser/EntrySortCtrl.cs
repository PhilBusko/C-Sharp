/**************************************************************************************************
ENTRY SORT CTRL
 * Sort chosen files by "<sortID> <keywords>" or "<name> <keywords> <id000>".
**************************************************************************************************/

#region USING

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
    public partial class EntrySortCtrl : UserControl, IFileBrowserCtrl
    {

        #region Control Basics

        public EntrySortCtrl()
        {
            InitializeComponent();
        }

        // implement IFileBrowserCtrl
        public void Initialize()
        {
            (this.Parent as BaseForm).Text = "Create Entry Sort File Names";
            (this.Parent as BaseForm).SetMode_Dialog();

            f_close.Click += new EventHandler((this.Parent as BaseForm).ctrlCloseClick);
        }

        private ThreadMessage myThread;

        public bool StopCtrlThread()
        {
            if (myThread == null || myThread.GetThread == null)
                return false;
            
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


        #region Control Operations

        private void f_chooseFiles_Click(object sender, EventArgs e)
        {
            string[] filePaths;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {

                if (Directory.Exists(Properties.Settings.Default.LastInputFolder) == true)
                    ofd.InitialDirectory = Properties.Settings.Default.LastInputFolder;
                else
                    ofd.InitialDirectory = Utility.StringFormat.GoUpDirectory(Properties.Settings.Default.LastInputFolder);

                ofd.Title = "Choose Files To Entry Sort";
                ofd.Multiselect = true;

                if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;

                filePaths = ofd.FileNames;
            }

            Properties.Settings.Default.LastInputFolder = Path.GetDirectoryName(filePaths[0]);
            Properties.Settings.Default.Save();

            AddFilesToProcess(filePaths);
        }

        private void f_openFolder_Click(object sender, EventArgs e)
        {
            string chosenFolder;

            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Choose Folder To Entry Sort";

                if (Directory.Exists(Properties.Settings.Default.LastInputFolder) == true)
                    fbd.SelectedPath = Properties.Settings.Default.LastInputFolder;
                else
                    fbd.SelectedPath = Utility.StringFormat.GoUpDirectory(Properties.Settings.Default.LastInputFolder);


                if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;

                chosenFolder = fbd.SelectedPath;
            }

            Properties.Settings.Default.LastInputFolder = chosenFolder;
            Properties.Settings.Default.Save();

            List<string> filePaths = new List<string>(); ;

            DirectoryInfo dirInfo = new DirectoryInfo(chosenFolder);

            foreach (FileInfo info in dirInfo.GetFiles())
                filePaths.Add(info.FullName);

            AddFilesToProcess(filePaths.ToArray());

            f_keywords.Text = string.Empty;
        }

        private void AddFilesToProcess(string[] p_filePaths)
        {
            // auto-populate name field but splitting on white space

            string name = Path.GetFileNameWithoutExtension(p_filePaths[0]);

            string first = name.Split(new char[0])[0];    

            f_keywords.Text = first;

            // add files to listview
            
            f_fileList.Items.Clear();

            for (int f = 0; f < p_filePaths.Length; f++)
            {
                string fileName = Path.GetFileName(p_filePaths[f]);

                if (Utility.FileSystem.IsSystem(fileName) == false)
                {
                    ListViewItem item = new ListViewItem(fileName);
                    item.Tag = p_filePaths[f];

                    f_fileList.Items.Add(item);
                }
            }
        }


        private void f_useSort_CheckedChanged(object sender, EventArgs e)
        {
            if (f_useSort.Checked == true)
            {
                f_sortValue.Enabled = true;
                f_sortValue.ReadOnly = false;
            }
            else
            {
                f_sortValue.Enabled = false;
                f_sortValue.ReadOnly = true;
            }
        }

        
        private void f_okgo_Click(object sender, EventArgs e)
        {
            // get data from form

            string sort = f_sortValue.Text;
            string keywords = f_keywords.Text;

            if (string.IsNullOrEmpty(keywords) && string.IsNullOrEmpty(sort))
                return;

            if (f_useSort.Checked == false)
                sort = "";

            // change file names to new sorted format

            Cursor.Current = Cursors.WaitCursor;

            List<string> filePaths = new List<string>();

            foreach (ListViewItem currItem in f_fileList.Items)
            {
                string filePath = currItem.Tag.ToString();
                filePaths.Add(filePath);
            }

            FileSystem.RunCreateEntryFN(filePaths.ToArray(), keywords, sort);


            // mark files as done on form

            foreach (ListViewItem currItem in f_fileList.Items)
                currItem.SubItems.Add("Done");

            Cursor.Current = Cursors.Default;
        }


        #endregion



    }
}
