using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

/********************************************************************************************
FOLDER BROWSER FORM
Author: Felipe Busko
********************************************************************************************/

namespace FileBrowser
{
    public partial class FolderBrowser : Form
    {

        #region Data Members

        private FolderData m_rootData;

        public class FolderData
        {
            public string Path;
            public int NumberFiles;
            public long FolderSize;

            public List<FolderData> SubFolderData;

            /// <summary>
            /// Clones the scalar data members.
            /// </summary>
            public FolderData Clone()
            {
                FolderData clone = new FolderData();

                clone.Path = this.Path;
                clone.NumberFiles = this.NumberFiles;
                clone.FolderSize = this.FolderSize;

                clone.SubFolderData = new List<FolderData>();

                return clone;
            }
        }

        #endregion


        #region Form Functions

        public FolderBrowser()
        {
            InitializeComponent();
        }

        private void FolderSize_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.MainForm.Show();

            //Program.MainForm.Close();
        }

        // press the Esc key to close the form
        // the form property KeyPreview must be set to true
        private void FolderBrowser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                this.Close();
        }

        #endregion


        #region User Input

        // Root Folder button
        private void f_rootFolder_Click(object sender, EventArgs e)
        {
            // get the root folder to browse

            string rootFolder;

            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Choose the root folder to browse from.";
                fbd.SelectedPath = @"C:\Documents and Settings\HP_Administrator\My Documents\My Programs\slideshow";

                if (fbd.ShowDialog() != DialogResult.OK)
                    return;

                rootFolder = fbd.SelectedPath;
            }

            // update the form

            f_rootFolderLabel.Text = "Root Folder: " + rootFolder;
            f_folderInfo.Items.Clear();

            // browse recursively

            DateTime dtStart = DateTime.Now;

            m_rootData = new FolderData();

            BrowseRecursion(rootFolder, m_rootData);

            DateTime dtEnd = DateTime.Now;
            long createTicks = dtEnd.Ticks - dtStart.Ticks;
            double createSeconds = (double)createTicks / 10000000.0;  // tick = 10^7 s

            f_browseTime.Text = "Browse Time: " + createSeconds + "s";

            DisplayResults(m_rootData);
        }

        // subroutine for Root Folder button
        // recursive function that returns information of subdirectories
        private void BrowseRecursion(string dirPath, FolderData folderData)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);

            // compute base data of this folder           

            folderData.Path = dirPath;
            folderData.NumberFiles = dirInfo.GetFiles().Length;
            folderData.FolderSize = 0;

            for (int f = 0; f < folderData.NumberFiles; f++)
                folderData.FolderSize += dirInfo.GetFiles()[f].Length;

            // compute data of subdirectories

            folderData.SubFolderData = new List<FolderData>();

            DirectoryInfo[] subDirInfo = dirInfo.GetDirectories();

            for (int d = 0; d < subDirInfo.Length; d++)
            {
                FolderData subFolderData = new FolderData();

                folderData.SubFolderData.Add(subFolderData);
                
                BrowseRecursion(subDirInfo[d].FullName, folderData.SubFolderData[d]);

                folderData.NumberFiles += folderData.SubFolderData[d].NumberFiles;
                folderData.FolderSize += folderData.SubFolderData[d].FolderSize;
            }
        }

        /// <summary>
        /// Entry point for recursion to display data on ListView.
        /// </summary>
        private void DisplayResults(FolderData rootData)
        {
            f_folderInfo.Items.Clear();

            DisplayResultsRecursion(rootData, 0);
            
            f_folderInfo.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void DisplayResultsRecursion(FolderData displayData, int recurseDepth)
        {
            if (recurseDepth >= f_recursionDepth.Value)
                return;
            
            string msg = "";

            for (int m = 0; m < recurseDepth; m++)
                msg += "      ";
            msg += Utility.StringFormat.GetLastDirectoryOnly(displayData.Path + @"\");  // cheat for creating folder name

            ListViewItem topItem = new ListViewItem(msg);
            topItem.SubItems.Add(displayData.NumberFiles.ToString());
            topItem.SubItems.Add(displayData.FolderSize.ToString());

            f_folderInfo.Items.Add(topItem);

            // a dvelopment mistake was made
            if (displayData == null || displayData.SubFolderData == null)
                return;

            foreach (FolderData currData in displayData.SubFolderData)
                DisplayResultsRecursion(currData, recurseDepth + 1);
        }

        private void f_folderInfo_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 1)
            {
                FolderData sortedData = new FolderData();

                GetSortedData(sortedData, m_rootData);

                DisplayResults(sortedData);
            }
        }

        private void GetSortedData(FolderData sortedData, FolderData origData)
        {
            sortedData.Path = origData.Path;
            sortedData.NumberFiles = origData.NumberFiles;
            sortedData.FolderSize = origData.FolderSize;

            sortedData.SubFolderData = new List<FolderData>();

            for (int s = 0; s < origData.SubFolderData.Count; s++)
            {
                // copy just the scalar data members
                FolderData subSortedData = origData.SubFolderData[s].Clone();

                // copy the sub-folder list sorted
                GetSortedData(subSortedData, origData.SubFolderData[s]);

                // add the current sub-folder in the sorted order

                if (s == 0)
                {
                    sortedData.SubFolderData.Add(subSortedData);
                }

                else
                {
                    bool inserted = false;

                    for (int c = 0; c < sortedData.SubFolderData.Count; c++)
                    {
                        if (sortedData.SubFolderData[c].NumberFiles < subSortedData.NumberFiles)
                        {
                            sortedData.SubFolderData.Insert(c, subSortedData);
                            inserted = true;
                            break;
                        }
                    }

                    if (inserted == false)
                        sortedData.SubFolderData.Add(subSortedData);
                }
            }
        }

        #endregion

    }
}
