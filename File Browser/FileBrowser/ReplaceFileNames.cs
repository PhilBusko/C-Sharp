using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Utility;


/**************************************************************************************************
This class is meant to go through a folder and change text characters in file names. The text is 
changed based on two different input strings.
**************************************************************************************************/

namespace FileBrowser
{
    public partial class ReplaceFileNames : UserControl, IFileBrowserCtrl
    {


        #region Control Basics


        // data members

        private string RootPath;
        private string ChangeFrom;
        private string ChangeTo;
        private ThreadMessage myThread;


        // constructor
        public ReplaceFileNames()
        {
            InitializeComponent();

            string currFolder = Properties.Settings.Default.LastInputFolder;

            if (Directory.Exists(currFolder) == true)
                this.SetFolder(currFolder);

            else if (Directory.Exists(Utility.StringFormat.GoUpDirectory(currFolder)) == true)
                this.SetFolder(Utility.StringFormat.GoUpDirectory(currFolder));

            else
                this.SetFolder(@"C:\Users\CFBComp"); // Properties.Settings.Default.FormatFolder);
        }

        // implement IFileBrowserCtrl
        public void Initialize()
        {
            (this.Parent as BaseForm).Text = "Replace File Names";
            (this.Parent as BaseForm).SetMode_Dialog();

            this.Dock = DockStyle.Fill;

         //   f_close.Click += new EventHandler((this.Parent as BaseForm).ctrlCloseClick);
        }

        public bool StopCtrlThread()
        {
            if (myThread == null || myThread.GetThread.IsAlive == false)
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




        #region User Interface 


        // Root Folder button
        private void f_rootFolder_Click(object sender, EventArgs e)
        {
            // get the root folder to browse

            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Choose Root Folder to Replace Names";
                fbd.SelectedPath = MainSelector.GetLastFolder();

                if (fbd.ShowDialog() != DialogResult.OK)
                    return;

                this.SetFolder(fbd.SelectedPath);
            }
        }

        private void f_rootPath_TextChanged(object sender, EventArgs e)
        {
            string target = f_rootPath.Text;

            if (Directory.Exists(target))
                this.SetFolder(target);


            //C:\Users\CFBComp\My Files\My Code\WAMP\root\phil_site\LegoCatalog
        }


        // subroutine for anytime the working folder is set
        private void SetFolder(string p_folderPath)
        {
            MainSelector.SetLastFolder(p_folderPath);

            f_rootPath.Text = p_folderPath;
            f_fileSystemList.Items.Clear();
        }


        private void f_rootPath_Click(object sender, EventArgs e)
        {
            f_rootPath.SelectAll();
        }

        private void f_textChangeFrom_Enter(object sender, EventArgs e)
        {
            f_textChangeFrom.SelectAll();
        }

        private void f_textChangeTo_Enter(object sender, EventArgs e)
        {
            //f_textChangeTo.SelectAll();
        }

        private void f_textChangeFrom_Click(object sender, EventArgs e)
        {
            f_textChangeFrom.SelectAll();
        }

        private void f_textChangeTo_Click(object sender, EventArgs e)
        {
            //f_textChangeTo.SelectAll();
        }


        #endregion




        #region Thread Work


        // Change OK button
        private void f_change_Click(object sender, EventArgs e)
        {
            // proceed if the input is valid

            this.RootPath = f_rootPath.Text;
            this.ChangeFrom = f_textChangeFrom.Text;
            this.ChangeTo = f_textChangeTo.Text;

            if (Directory.Exists(RootPath) == false || string.IsNullOrEmpty(ChangeFrom) == true)
            {
                MessageBox.Show("Invalid input fields.", "Change Text Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // change file names in thread

            myThread = new ThreadMessage(CallChangeText);

            FileSystem.Progress += new FileSystem.ComputationEvent(FileSystem_Progress);

            myThread.LaunchThread();
        }

        // delegate for thread call
        public void CallChangeText()
        {
            FileSystem.ProcessParams p = new FileSystem.ProcessParams();
            p.RootFolder = this.RootPath;
            p.Parameter1 = this.ChangeFrom;
            p.Parameter2 = this.ChangeTo;

            FileSystem.RunRecursive(p, FileSystem.ReplaceFileName);
        }

        // delegate declaration
        protected delegate void FileBrowser_ThreadPointer(object updateData);

        // implement computation thread notification
        private void FileSystem_Progress(object p_progressData)
        {
            if (this.InvokeRequired)
            {
                FileBrowser_ThreadPointer tp = new FileBrowser_ThreadPointer(FileSystem_Progress);
                this.Invoke(tp, new object[] { p_progressData });
            }
            else
            {
                ThreadMessageStruct tms = (ThreadMessageStruct)p_progressData;

                switch (tms.Type)
                {
                    case TMSType.Progress1:
                        this.UpdateForm(tms);
                        break;

                    case TMSType.Progress2: break;
                    case TMSType.Complete1: break;
                    case TMSType.Complete2: break;

                    case TMSType.Error:

                        Exception ex = (Exception)tms.Data1;

                        // thread.abort() throws an exception
                        if (ex.GetType() == typeof(System.Threading.ThreadAbortException))
                        {
                            MessageBox.Show("Thread aborted.", "Processing Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(ex.Message + Environment.NewLine + Environment.NewLine + ex.StackTrace,
                                "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //(Parent as Form).Close();
                        break;

                    default:
                        break;
                }

                // strange issue where if the sorting is run subsequent times, this method calls itself
                (p_progressData as ThreadMessageStruct).Type = TMSType.Unknown;
            }
        }


        /// <summary>
        /// Helper for thread form update.
        /// </summary>
        private void UpdateForm(ThreadMessageStruct p_tms)
        {
            string origPath = p_tms.Data1.ToString();
            string newPath = null;

            if (p_tms.Data2 != null)
                newPath = p_tms.Data2.ToString();

            string origName = Path.GetFileName(origPath);
            string newName = @"-";

            if (newPath != null)
                newName = Path.GetFileName(newPath);

            string dir = Path.GetDirectoryName(origPath);
            string lastDir = Utility.StringFormat.GetLastDirectoryOnly(f_rootPath.Text);

            string abrev = dir.Substring(f_rootPath.Text.Length - lastDir.Length -2);

            ListViewItem item = new ListViewItem(abrev);
            item.SubItems.Add(origName);
            item.SubItems.Add(newName);

            f_fileSystemList.Items.Insert(0, item);
        }


        #endregion


    }
}
