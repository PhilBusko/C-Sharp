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
using System.Collections.ObjectModel;
using Utility;
using System.Text.RegularExpressions;

#endregion


namespace FileBrowser
{
    public partial class SetFilesProperty : UserControl, IFileBrowserCtrl
    {

        #region Data Members

        private string m_rootPath;
        private int m_filesChecked;

        private ThreadMessage myThread;

        private const string TYPE_IMAGE = "Images";
        private const string TYPE_MUSIC = "Music";

        #endregion



        #region Control Basics

        /// <summary>
        /// Constructor.
        /// </summary>
        public SetFilesProperty()
        {
            InitializeComponent();

            // setup file type combo box

            object[] items = new object[2];
            items[0] = TYPE_IMAGE;
            items[1] = TYPE_MUSIC;
            f_fileType.Items.AddRange(items);
            f_fileType.SelectedIndex = 0;
            f_fileType.DropDownStyle = ComboBoxStyle.DropDownList;      // prevent user editing

            // setup config

            MusicProcessor.CreateBA(Properties.Settings.Default.MusicCoverPath);

        }


        // implement IFileBrowserCtrl
        
        public void Initialize()
        {
            (this.Parent as BaseForm).Text = "Set Files' Property";
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



        #region Control Interface

        /// <summary>
        /// "Choose Root" button: set the root folder to begin traversal.
        /// </summary>
        private void f_setRootFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Choose Root Folder For Setting Files' Property";
                fbd.SelectedPath = MainSelector.GetLastFolder();

                if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;

                f_rootFolder.Text = fbd.SelectedPath;
            }
        }

        /// <summary>
        /// "Root Folder" text box: on-click highlight text.
        /// </summary>
        private void f_rootFolder_Click(object sender, EventArgs e)
        {
            f_rootFolder.SelectAll();
        }

        /// <summary>
        /// "Ok Go" button: validate form input and launch appropriate thread.
        /// </summary>
        private void f_run_Click(object sender, EventArgs e)
        {
            // prepare members for computation
            
            m_filesChecked = 0;
            f_filesResults.Items.Clear();
            
            // validate data from form

            m_rootPath = f_rootFolder.Text;

            if (Directory.Exists(m_rootPath) == false)
            {
                f_rootFolder.Text = "ERROR";
                return;
            }

            MainSelector.SetLastFolder(m_rootPath);


            // create thread based on file type and function type

            if (f_fileType.Text == TYPE_IMAGE)
            {
                myThread = new ThreadMessage(RunImagePropChange);
                ImageProcessor.Progress += new ImageProcessor.ComputationEvent(FileBrowser_ProgressUpdate);
            }

            else if (f_fileType.Text == TYPE_MUSIC)
            {
                myThread = new ThreadMessage(RunMusicPropChange);
                MusicProcessor.MusicCoverPath = Properties.Settings.Default.MusicCoverPath;
                MusicProcessor.Progress += new MusicProcessor.ComputationEvent(FileBrowser_ProgressUpdate);
            }

            else
                return;


            // subscribe to the thread to get cancelations

            myThread.ThreadUpdate += new ThreadMessage.ThreadEventHandler(FileBrowser_ProgressUpdate);


            // launch the computation thread

            myThread.LaunchThread();
        }

        /// <summary>
        /// ListView context menu "Copy File Name"
        /// </summary>
        private void f_menuCopyName_Click(object sender, EventArgs e)
        {
            if (f_filesResults.SelectedItems.Count == 0)
                return;

            ListViewItem item = f_filesResults.SelectedItems[0];        // multiselect = false

            string fileName = item.SubItems[1].Text;

            string copy = "ERROR";

            // this code is reproduced in MusicProcessor

            string tArtist = null, tAlbum = null, tTrack = null, tSong = null;

            if (MusicProcessor.RX_TRACK_FULLNAME.IsMatch(fileName))
            {
                Match m = MusicProcessor.RX_TRACK_FULLNAME.Match(fileName);

                tArtist = m.Groups[MusicProcessor.MATCH_ARTIST].Value;
                tAlbum = m.Groups[MusicProcessor.MATCH_ALBUM].Value;
                tTrack = m.Groups[MusicProcessor.MATCH_TRACK].Value;
                tSong = m.Groups[MusicProcessor.MATCH_SONG].Value;

                copy = tArtist.ToLower() + " - " + tAlbum.ToLower();
            }

            Clipboard.SetText(copy);
        }

        /// <summary>
        /// ListView column click will sort based on the column clicked.
        /// </summary>
        private void f_filesResults_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            f_filesResults.ListViewItemSorter = new Utility.ListViewItemComparer(e.Column);
            f_filesResults.Sort();

            if (f_filesResults.Sorting == SortOrder.Ascending)
                f_filesResults.Sorting = SortOrder.Descending;
            else
                f_filesResults.Sorting = SortOrder.Ascending;
        }

        #endregion



        #region Thread Work


        /// <summary>
        /// Helper method to be called by thread.
        /// Everything in this function is executed by the thread.
        /// </summary>
        public void RunImagePropChange()
        {
            FileSystem.ProcessParams p = new FileSystem.ProcessParams();
            p.RootFolder = m_rootPath;

            FileSystem.RunRecursive(p, ImageProcessor.SetImageKeyword);
        }

        /// <summary>
        /// Helper method to be called by thread.
        /// </summary>
        public void RunMusicPropChange()
        {
            FileSystem.ProcessParams p = new FileSystem.ProcessParams();
            p.RootFolder = m_rootPath;

            FileSystem.RunRecursive(p, MusicProcessor.SetAlbumCover);
        }


        // delegate declaration
        protected delegate void FileBrowser_ThreadPointer(object updateData);

        // implement thread-safe messaging with delegate
        protected void FileBrowser_ProgressUpdate(object updateData)
        {
            if (this.InvokeRequired)
            {
                FileBrowser_ThreadPointer tp = new FileBrowser_ThreadPointer(FileBrowser_ProgressUpdate);
                this.Invoke(tp, new object[] { updateData });
            }
            else
            {
                ThreadMessageStruct tms = (ThreadMessageStruct)updateData;
                ListViewItem item;

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

                // strange issue where if the sorting is run subsequent times, this method calls itself
                (updateData as ThreadMessageStruct).Type = TMSType.Unknown;

            }
        }

        /// <summary>
        /// Helper for thread form update.
        /// </summary>
        private void UpdateForm(ThreadMessageStruct p_tms)
        {
            string fullPath = p_tms.Data1.ToString();
            string folder = Path.GetDirectoryName(fullPath).Substring(Utility.StringFormat.GoUpDirectory(m_rootPath).Length); 
            string name = Path.GetFileNameWithoutExtension(fullPath);
            string status = p_tms.Data2.ToString();

            ListViewItem item = new ListViewItem(folder);
            item.SubItems.Add(name);
            item.SubItems.Add(status);

            if (status.Contains("Attach"))
                item.ForeColor = Color.Red;

            f_filesResults.Items.Insert(0, item);

            m_filesChecked++;
            f_filesChecked.Text = "Files Checked: " + m_filesChecked;

            f_threadStatus.Text = "Thread: " + myThread.GetThread.IsAlive.ToString();
        }

        #endregion



    }

}
