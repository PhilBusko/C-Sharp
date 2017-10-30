/**************************************************************************************************
SMART FLOW LAYOUT
 * This class inherits from UserControl and is a wrapper for a FlowLayoutPanel.
 * The functionality allows to add, remove, select and save its component thumbnails.
 * The FlowDirection should be set in the caller.
**************************************************************************************************/

#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Utility;

#endregion


namespace ImageControls
{
    public partial class SmartFlowLayout : UserControl
    {

        #region Data Members


        // the SmartThumbnail list is held in the Control list of this control
        public FlowLayoutPanel NativeLayout
        { get { return f_flowLayout; } }

        public int NumberColumns = 1;

        // a reference to the currently selected SmartThumbnail
        private SmartThumbnail m_selectThumbRef;

        // event used when a SmartThumbnail becomes selected
        public delegate void ThumbSelectedEvent(object eventData);

        /// <summary>
        /// Fired when a smart thumbnail becomes selected.
        /// </summary>
        public event ThumbSelectedEvent SFLEvent;


        #endregion



        #region Constructor / Destructor


        /// <summary>
        /// Constructor.
        /// </summary>
        public SmartFlowLayout()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Dispose of all the current thumbnails without saving.
        /// </summary>
        public void DisposeThumbs()
        {
            if (f_flowLayout.Controls.Count == 0)
                return;

            f_flowLayout.SuspendLayout();

            SmartThumbnail currThumb;

            for (int c = 0; c < f_flowLayout.Controls.Count; c++)
            {
                currThumb = (SmartThumbnail)f_flowLayout.Controls[c];
                currThumb.DisposeThumb();
            }

            f_flowLayout.Controls.Clear();

            f_flowLayout.ResumeLayout(false);
            f_flowLayout.PerformLayout();
        }


        #endregion



        #region Queries


        /// <summary>
        /// Get the currently selected thumbnail. Result is NULL if nothing is selected.
        /// </summary>
        public SmartThumbnail SelectedThumbnail
        { 
            get { return m_selectThumbRef; }
        }

        /// <summary>
        /// Used for moving a thumbnail within a SPC.
        /// </summary>
        public int GetSelectedThumbIndex()
        {
            int index = 0;

            foreach (Control currCtrl in f_flowLayout.Controls)
            {
                if (currCtrl != m_selectThumbRef)
                    index++;
                else
                    break;
            }

            return index;
        }

        /// <summary>
        /// Returns the SmartThumbnail at the index.
        /// </summary>
        public SmartThumbnail GetThumbAt(int index)
        {
            return (SmartThumbnail)f_flowLayout.Controls[index];
        }


        /// <summary>
        /// Returns the number of SmartThumbnails.
        /// </summary>
        public int ControlCount()
        {
            if (f_flowLayout == null || f_flowLayout.Controls == null || f_flowLayout.Controls.Count == 0)
                return 0;

            return f_flowLayout.Controls.Count;
        }


        #endregion



        #region Add & Remove Thumbnails


        /// <summary>
        /// Creates an image from each file path passed in and adds thumbnail of that image.
        /// </summary>
        public void CreateThumbList(List<string> p_filePathList)
        {
            if (p_filePathList.Count == 0)
                return;

            // sort the files as best as possible

            //        List<string> sortedFilePaths = GetSortedFiles(filePathList);

            // loop through and add each file's thumbnail to control

            Size thumbSize = this.GetThumbnailSize();

            f_flowLayout.SuspendLayout();

            foreach (string currFilePath in p_filePathList)
                this.CreateThumb(currFilePath);

            f_flowLayout.ResumeLayout(false);
            f_flowLayout.PerformLayout();
        }


        /// <summary>
        /// Creates a new thumbnail and adds it to the end of Controls.
        /// </summary>
        public void CreateThumb(string p_filePath)
        {
            SmartThumbnail createThumb = new SmartThumbnail(p_filePath, this.GetThumbnailSize());
        
            f_flowLayout.Controls.Add(createThumb);
        }

        /// <summary>
        /// Creates a new thumbnail and adds it to the end of Controls.
        /// </summary>
        public void CreateThumb(EditImageData p_data)
        {
            SmartThumbnail createThumb = new SmartThumbnail(p_data, this.GetThumbnailSize());

            f_flowLayout.Controls.Add(createThumb);
        }


        /// <summary>
        /// Returns the size of the thumbnail that fits the control's current dimensions.
        /// </summary>
        private Size GetThumbnailSize()
        {
            Size thumbSize = new Size();

            double factor = 28;

            if (this.f_flowLayout.FlowDirection == FlowDirection.LeftToRight) // default value; fill top to bottom
            {
                thumbSize.Width = (int)((double)f_flowLayout.Width - 60 - this.NumberColumns *5);
                thumbSize.Height = (int)((double)f_flowLayout.Width - 60 - this.NumberColumns * 5);
            }
            else
            {
                thumbSize.Width = (int)((double)f_flowLayout.Height - factor);
                thumbSize.Height = (int)((double)f_flowLayout.Height - factor);
            }

            thumbSize.Width /= this.NumberColumns;
            thumbSize.Height /= this.NumberColumns;

            return thumbSize;
        }

        /// <summary>
        /// Insert the thumbnail at the requested position.
        /// </summary>
        public void InsertData(EditImageData p_data, int p_index)
        {
            try
            {
                // deselect since the inserted thumb is selected

                this.DeselectThumb();

                // create new thumb, sized for this control

                SmartThumbnail createTN = new SmartThumbnail(p_data, this.GetThumbnailSize());

                // insert the "hard way" since there is no Control.Insert

                List<SmartThumbnail> thumbList = new List<SmartThumbnail>();

                foreach (SmartThumbnail currThumb in f_flowLayout.Controls)
                    thumbList.Add(currThumb);

                f_flowLayout.Controls.Clear();

                thumbList.Insert(p_index, createTN);

                foreach (SmartThumbnail currThumb in thumbList)
                    f_flowLayout.Controls.Add(currThumb);
            }
            catch (Exception ex)
            {
                string msg = ex.Message + Utility.StringFormat.TwoEoL();
                msg += string.Format("control count: {0}, insert index {1}", this.ControlCount(), p_index);

                MessageBox.Show(msg, "InsertThumb Error");
            }
        }


        /// <summary>
        /// Subroutine for AddAllThumbs(). Renames certain files, sorts them and returns their file paths.
        /// </summary>
        private List<string> GetSortedFiles(List<string> filePathList)
        {
            // test files for numerical prefix

            string currFileName;
            System.Text.RegularExpressions.Regex rx_NumberPrefix =
                new System.Text.RegularExpressions.Regex(@"^(?<number>[0-9]+)");
            System.Text.RegularExpressions.Match m;

            string nPrefix;
            int currNDigitCount;
            int nDigitCountMax = 0;

            foreach (string currFilePath in filePathList)
            {
                currFileName = Path.GetFileName(currFilePath);

                if (rx_NumberPrefix.IsMatch(currFileName))
                {
                    m = rx_NumberPrefix.Match(currFileName);
                    nPrefix = m.Groups["number"].Value;

                    currNDigitCount = nPrefix.Length;
                    if (currNDigitCount > nDigitCountMax)
                        nDigitCountMax = currNDigitCount;
                }
            }

            // prepend 0's to sort correctly

            List<string> prependedFilePaths = new List<string>();
            string dirPath = Path.GetDirectoryName(filePathList[0]);
            string targetFileName, targetFilePath;
            int zeroCount;

            foreach (string currFilePath in filePathList)
            {
                currFileName = Path.GetFileName(currFilePath);
                targetFileName = currFileName;

                // change target file name if it matches

                if (rx_NumberPrefix.IsMatch(currFileName))
                {
                    m = rx_NumberPrefix.Match(currFileName);
                    nPrefix = m.Groups["number"].Value;

                    zeroCount = nDigitCountMax - nPrefix.Length;

                    for (int z = 0; z < zeroCount; z++)
                        targetFileName = "0" + targetFileName;
                }

                targetFilePath = dirPath + @"\" + targetFileName;

                if (currFilePath != targetFilePath)
                {
                    Directory.Move(currFilePath, targetFilePath);
                }

                prependedFilePaths.Add(targetFilePath);
            }

            // sort and return

            prependedFilePaths.Sort();

            return prependedFilePaths;
        }


        /// <summary>
        /// Removes the currently selected thumbnail from the Control list and returns its data.
        /// </summary>
        public EditImageData GetDataAndRemoveThumb()
        {
            if (m_selectThumbRef == null || m_selectThumbRef.EditData == null)
                return null;

            SmartThumbnail temp = m_selectThumbRef;

            EditImageData getThis = m_selectThumbRef.EditData;

            this.DeselectThumb(); // deletes m_selectThumbRef

            f_flowLayout.Controls.Remove(temp);

            return getThis;
        }


        /// <summary>
        /// Removes the first thumbnail from the Control list and returns its data.
        /// </summary>
        public EditImageData GetFirstAndRemoveThumb()
        {
            if (f_flowLayout.Controls.Count < 1)
                return null;

            this.DeselectThumb();   // deletes m_selectThumbRef

            SmartThumbnail temp = (f_flowLayout.Controls[0] as SmartThumbnail);

            EditImageData getThis = temp.EditData;

            f_flowLayout.Controls.Remove(temp);

            return getThis;
        }


        #endregion



        #region Select & Deselect a SmartThumbnail


        /// <summary>
        /// Mouse Down is used to select a thumb from the GUI.
        /// </summary>
        private void f_flowLayout_MouseClick(object sender, MouseEventArgs e)
        {
            if (f_flowLayout == null || f_flowLayout.IsDisposed == true)
                return;

            SmartThumbnail selectedThumb = (SmartThumbnail)f_flowLayout.GetChildAtPoint(e.Location);

            SelectThumb(selectedThumb);
        }

        private void f_flowLayout_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            MessageBox.Show("SmartFlowLayout double-clicked!");

        }


        /// <summary>
        /// Selects the parameter thumbnail by highlighting it, triggering an event for any subscribers and
        /// scrolling to its position.
        /// </summary>
        public void SelectThumb(SmartThumbnail p_selectedThumb)
        {
            // skip new selection if it is the old selection

            if (m_selectThumbRef != null && m_selectThumbRef == p_selectedThumb)
                return;

            // select control

            this.DeselectThumb();

            if (p_selectedThumb == null)
                return;

            m_selectThumbRef = p_selectedThumb;
            m_selectThumbRef.SelectThis();

            // send event

            if (SFLEvent != null)
                SFLEvent(m_selectThumbRef);


            // scroll to position

            if (f_flowLayout.Controls.Count < 6)
                return;

            int ctrlPos = -1;

            for (int c = 0; c < f_flowLayout.Controls.Count; c++)
			{
                if (p_selectedThumb == f_flowLayout.Controls[c])
                {
                    ctrlPos = c;
                    break;
                }
			}

            if (f_flowLayout.FlowDirection == FlowDirection.TopDown)
            {
                int firstPos = f_flowLayout.Controls[0].Location.X;
                int secondPos = f_flowLayout.Controls[1].Location.X;
                int thumbLength = secondPos - firstPos;

                int scrollTo = (ctrlPos * thumbLength) - this.ClientRectangle.Width / 2;

                f_flowLayout.AutoScrollPosition = new Point(scrollTo, 0);
            }
        }

        /// <summary>
        /// Set a thumb to selected by searching for its file name.
        /// </summary>
        public void SelectThumbByPath(string filePath)
        {
            SmartThumbnail searchThumb;
            
            foreach (Control currCtrl in f_flowLayout.Controls)
            {
                searchThumb = (SmartThumbnail)currCtrl;

                if (searchThumb.EditData.FilePathOrig == filePath)
                {
                    SelectThumb(searchThumb);
                    return;
                }
            }
        }

        /// <summary>
        /// Deselect any currently selected thumb.
        /// </summary>
        public void DeselectThumb()
        {
            if (m_selectThumbRef != null)
            {
                m_selectThumbRef.DeselectThis();
                m_selectThumbRef = null;
            }
        }


        #endregion



        #region Save Files

        // current vs original
        // save all vs save edited only
        // save to current folder vs save to custom folder

        // current, all, current folder = series sorter file save (SaveFilesCurrent)
        // current, all, custom folder = N/A
        // current, edited only, current folder = picture show file save (SaveFilesCurrent)
        // current, edited only, custom folder = N/A
        // original, all, current folder = N/A
        // original, all, custom folder = backup (SaveFilesBackup)
        // original, edited only, current folder = N/A
        // original, edited only, custom folder = N/A

        /// <summary>
        /// Save the current files to current path.
        /// saveAll = true, saves every file; saveAll = false, save only edited files
        /// </summary>
        public void SaveFilesCurrent(bool p_saveAll)
        {
            for (int c = 0; c < f_flowLayout.Controls.Count; c++)
            {
                SmartThumbnail currThumb = (SmartThumbnail)f_flowLayout.Controls[c];

                if (p_saveAll == true || currThumb.EditData.IsEdited() == true)
                    currThumb.EditData.SaveFileCurrent();
            }
        }

        /// <summary>
        /// Saves original files to backup folder. 
        /// Folder path must be sent from caller code, and original parent directory is also added to backup file name.
        /// </summary>
        public void SaveFilesBackup(bool p_saveAll, string p_saveFolder)
        {
            for (int c = 0; c < f_flowLayout.Controls.Count; c++)
            {
                SmartThumbnail currThumb = (SmartThumbnail)f_flowLayout.Controls[c];

                if (p_saveAll == true || currThumb.EditData.IsEdited() == true)
                    currThumb.EditData.SaveFileOverrideFolder(p_saveFolder);
            }
        }


        /// <summary>
        /// Delete all the files in the current SmartFlowLayout without saving.
        /// </summary>
        public void DeleteFiles()
        {
            f_flowLayout.SuspendLayout();

            for (int c = 0; c < f_flowLayout.Controls.Count; c++)
            {
                SmartThumbnail currThumb = (SmartThumbnail)f_flowLayout.Controls[c];
                string deletePath = currThumb.EditData.FilePathOrig;

                currThumb.DisposeThumb();
                File.Delete(deletePath);
            }

            f_flowLayout.Controls.Clear();

            f_flowLayout.ResumeLayout();
        }


        #endregion


    }
}
