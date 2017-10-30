/**************************************************************************************************
FILE STANDARDIZOR CTRL
**************************************************************************************************/

#region Using 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Utility;

#endregion


namespace FileBrowser
{

    public partial class FileStandardizorCtrl : UserControl, IFileBrowserCtrl
    {

        #region Data Members


        private ThreadMessage myThread;

        private int m_filesChecked;


        #endregion



        #region Control Basics

        public FileStandardizorCtrl()
        {
            InitializeComponent();
        }

        // implement IFileBrowserCtrl
        public void Initialize()
        {
            (this.Parent as BaseForm).Text = "File Standardizor";
            (this.Parent as BaseForm).SetMode_Dialog();

            f_close.Click += new EventHandler((this.Parent as BaseForm).ctrlCloseClick);
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



        #region Control Operations

        // Choose Folder
        private void f_openFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = MainSelector.GetLastFolder();

                fbd.Description = "Choose Root Folder For Standardizing Files";

                if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;

                f_rootPath.Text = fbd.SelectedPath;

                MainSelector.SetLastFolder(fbd.SelectedPath);
            }
        }

        // Ok Go
        private void f_run_Click(object sender, EventArgs e)
        {
            m_filesChecked = 0;
            f_filesResults.Items.Clear();

            FileSystem fs = new FileSystem();
            fs.RootPath = f_rootPath.Text;


            // create thread based on functionality

            if (f_deleteAll.Checked == false && f_deleteImages.Checked == false)
                myThread = new ThreadMessage(fs.RunStandardizor);

            else if (f_deleteAll.Checked == true && f_deleteImages.Checked == false)
                myThread = new ThreadMessage(fs.RunDeleteAll);

            else if (f_deleteAll.Checked == false && f_deleteImages.Checked == true)
                myThread = new ThreadMessage(fs.RunDeleteImages);

            else
            {
                MessageBox.Show("Choice of what to delete is ambiguous.", "Delete Error");
                return;
            }

            // sunscribe to file system for computation updates
            // subscribe to thread class for cancel events
            
            FileSystem.Progress += new FileSystem.ComputationEvent(FileBrowser_ProgressUpdate);
            myThread.ThreadUpdate += new ThreadMessage.ThreadEventHandler(FileBrowser_ProgressUpdate);

            myThread.LaunchThread();

            /*
                        // non-thread test

                        Cursor.Current = Cursors.WaitCursor;

                        FileSystem.ProcessParams p = new FileSystem.ProcessParams();
                        p.RootFolder = f_rootPath.Text;
                        FileSystem.RunRecursive(p, fs.Standardize);

                        Cursor.Current = Cursors.Default;
            */
        }

        #endregion



        #region Thread Work

        protected delegate void FileBrowser_ThreadPointer(object updateData);

        protected void FileBrowser_ProgressUpdate(object updateData)
        {
            if (this.InvokeRequired)
            {
                FileBrowser_ThreadPointer pc = new FileBrowser_ThreadPointer(FileBrowser_ProgressUpdate);
                this.Invoke(pc, new object[] { updateData });
            }
            else
            {
                ThreadMessageStruct tms = (ThreadMessageStruct)updateData;
                ListViewItem item;

                switch (tms.Type)
                {
                    case TMSType.Progress1:
                        string tname = tms.Data1.ToString().Substring(f_rootPath.Text.Length);
                        item = new ListViewItem(tname);
                        item.SubItems.Add("");
                        f_filesResults.Items.Insert(0, item);
                        m_filesChecked++;
                        f_filesChecked.Text = "Files Checked: " + m_filesChecked;
                        break;

                    case TMSType.Progress2:
                        if (f_filesResults.Items.Count > 0)  /// what ??
                        {
                            item = f_filesResults.Items[0];
                            string status = item.SubItems[1].Text;
                            if (string.IsNullOrEmpty(status) == false)
                                status += ", ";
                            status += tms.Data2.ToString();
                            item.SubItems[1] = new ListViewItem.ListViewSubItem(item, status);
                        }
                        break;

                    case TMSType.Complete1:
                        break;

                    case TMSType.Complete2:
                        break;

                    case TMSType.Error:
                        // computation has thrown an error
                        Exception ex = (Exception)tms.Data1;

                        // thread.abort() throws an exception
                        if (ex.GetType() == typeof(System.Threading.ThreadAbortException))
                        {
                            MessageBox.Show("Thread aborted.",
                                "Processing Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
        }

        #endregion

    }

}
