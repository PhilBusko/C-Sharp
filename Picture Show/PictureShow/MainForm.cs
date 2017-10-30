/**************************************************************************************************
MAIN FORM
 * Houses the multiple controls that form the layout.
**************************************************************************************************/

#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ImageControls;
using System.IO;
using Utility;

#endregion


namespace PictureShow
{
    public partial class MainForm : Form
    {
        

        #region Data Members

        private string m_workingPath;

        private string m_backupFolder;

        #endregion



        #region Constructors


        public MainForm()
        {
            InitializeComponent();

            // make the main flow layout fill left-to-right, not sure why it's called TopDown
            f_mainThumbs.NativeLayout.FlowDirection = FlowDirection.TopDown;

            // capture the thumb-selected event from the main layout
            f_mainThumbs.SFLEvent += new SmartFlowLayout.ThumbSelectedEvent(f_smartSortThumbs_SFLEvent);

            f_deleteThumbs.NumberColumns = 2;
        }

        /// <summary>
        /// Put this code in Load() so other controls's contructors are called first.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Program.CommandArgs.Length >= 1)
            {
                string filePath = Program.CommandArgs[0];

                StartupFile(filePath);
            }
        }


        #endregion



        #region Form-Wide UI


        // Picture Drag & Drop
        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            string filePath = string.Empty;

            // get file name from drag & drop
            // http://www.codeproject.com/KB/cs/dandtutorial.aspx

            if ( (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileName") as Array;

                if (data != null)
                {
                    if ( (data.Length == 1 ) && (data.GetValue(0) is String) )
                    {
                        filePath = ((string[])data)[0];
                    }
                }
            }

            StartupFile(filePath);
        }

        // Form Key Press
        private void MainForm_KeyPress(object sender, KeyPressEventArgs p_args)
        {
            if (p_args.KeyChar == 27)        // Escape
            {
                this.Dispose();
                this.Close();
            }

            if (p_args.KeyChar == 99) //|| p_args.keyc == Keys.F5)           // c
            {
                f_imageWorkspace.CropImage();
            }

            else if (p_args.KeyChar == 120)     // X
            {
                EditImageData data = f_mainThumbs.GetDataAndRemoveThumb();

                if (data != null)
                    f_deleteThumbs.CreateThumb(data);
            }

            else return;
        }

        // Subroutine for opening, selecting and displaying a file.
        private void StartupFile(string filePath)
        {
            if (FileSystem.IsImage(filePath))
            {
                try
                {
                    m_workingPath = Path.GetDirectoryName(filePath);
                    this.Text = "Picture Show: " + m_workingPath;

                    PopulateFilesView();
                    SelectFile(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + Utility.StringFormat.TwoEoL() + ex.StackTrace);
                }
            }

            else
            {
                string fileName = Path.GetFileName(filePath);
                MessageBox.Show("Main Form: Drag & Drop file is not an image: " + fileName, "Open File Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
        }

        // UI: Save & Close button
        private void f_saveFiles_Click(object sender, EventArgs e)
        {
            f_imageWorkspace.ClearThumb();

            string backupFolder = FileSystem.CreateBackupFolder();

            f_mainThumbs.SaveFilesBackup(false, backupFolder);
            f_deleteThumbs.SaveFilesBackup(true, backupFolder);

            f_mainThumbs.SaveFilesCurrent(false);
            f_deleteThumbs.DeleteFiles();

            this.Close();
        }

        private void MainForm_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("main double-click clked");

        }


        #endregion



        #region Files Sort TreeView


        /// <summary>
        /// Populate the tree view with sort entries. 
        /// The sorted lists are held in the tree view nodes' tags.
        /// </summary>
        private void PopulateFilesView()
        {
            f_imageWorkspace.ClearThumb();
            
            // get files by sort order

            Dictionary<string, List<string>> sortEntries = FileSystem.GetKeywordSortedImages(m_workingPath);

            // add files to tree view

            f_filesView.Nodes.Clear();

            foreach (string groupName in sortEntries.Keys)
            {
                List<string> currList = new System.Collections.Generic.List<string>();
                sortEntries.TryGetValue(groupName, out currList);

                string nodeName = groupName + " (" + currList.Count.ToString() + ")";

                TreeNode createNode = new TreeNode(nodeName);
                createNode.Tag = currList;

                f_filesView.Nodes.Add(createNode);
            }


            // populate right-click menu

       //     string folder = Path.GetDirectoryName(fileNames[0]);
       //    List<string> groups = FileSystem.GetPotentialGroupNames(folder);

            ToolStripItem quickItem = n_mainThumbsMenu.Items.Find("n_opsQuickName", false)[0];
            ToolStripMenuItem quickMenuItem = (ToolStripMenuItem)quickItem;
            quickMenuItem.DropDownItems.Clear();

            foreach (string group in sortEntries.Keys)
            {
                if (group.Length > 1)
                {
                    ToolStripItem subItem = new ToolStripMenuItem();
                    subItem.Text = group + " 0";
                    subItem.Click += new EventHandler(item_Click);

                    quickMenuItem.DropDownItems.Add(subItem);
                }
            }
        }


        // UI: files' tree view selection
        private void f_filesView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = f_filesView.SelectedNode;

            PopulateMainLayout(selectedNode);
        }

        private void f_filesView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode selectedNode = f_filesView.SelectedNode;

            if (selectedNode == null)
                return;
        }

        /// <summary>
        /// Use the parameter TreeNode to populate the main layout.
        /// </summary>
        private void PopulateMainLayout(TreeNode populateNode)
        {
            // save any changes to a previously opened sort group

            if (f_mainThumbs.ControlCount() != 0)
            {
                string backupFolder = FileSystem.CreateBackupFolder();

                f_mainThumbs.SaveFilesBackup(false, backupFolder);
                f_deleteThumbs.SaveFilesBackup(true, backupFolder);

                f_mainThumbs.SaveFilesCurrent(false);
                f_deleteThumbs.DeleteFiles();
            }

            // reset the form and open new sort group

            f_imageWorkspace.ClearThumb();

            List<string> fileNames = new List<string>();

            if (populateNode != null)
            {
                fileNames = (List<string>)populateNode.Tag;
                f_mainThumbs.DisposeThumbs();
                f_mainThumbs.CreateThumbList(fileNames);
            }
        }

        /// <summary>
        /// Keep the stupid treeview from selecting nodes from the keyboard.
        /// </summary>
        private void f_filesView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        // Files View context menu

        private void n_deleteAll_Click(object sender, EventArgs e)
        {
            // get the currently selected node
            
            TreeNode thisNode = f_filesView.SelectedNode;

            if (thisNode == null)
                return;

            // move all files to the delete layout

            int ccnt = f_mainThumbs.NativeLayout.Controls.Count;

            for (int f = 0; f < ccnt; f++)
            {
                EditImageData data = f_mainThumbs.GetFirstAndRemoveThumb();

                if (data != null)
                    f_deleteThumbs.CreateThumb(data);
            }
        }

        private void n_blurAll_Click(object sender, EventArgs e)
        {
            // get the currently selected node

            TreeNode thisNode = f_filesView.SelectedNode;

            if (thisNode == null)
                return;

            // blur through the edit-data class

            Cursor.Current = Cursors.WaitCursor;

            int ccnt = f_mainThumbs.NativeLayout.Controls.Count;

            for (int f = 0; f < ccnt; f++)
            {
                SmartThumbnail smt = (f_mainThumbs.NativeLayout.Controls[f] as SmartThumbnail);
         
                Bitmap edit = smt.EditData.GetCurrentImage();
                if (edit == null)
                    return;

                Bitmap blur = ImageProcessor.Blur(edit);
                smt.SetEditedImage(blur);
            }

            Cursor.Current = Cursors.Default;
        }


        #endregion


 


        #region Smart Layout Functions


        /// <summary>
        /// Handle event sent from main layout when an thumbnail is selected.
        /// </summary>
        private void f_smartSortThumbs_SFLEvent(object eventData)
        {
            SmartThumbnail selectedThumb = (SmartThumbnail)eventData;

            f_imageWorkspace.SetCurrentThumb(selectedThumb);
        }


        /// <summary>
        /// To be called when a thumbnail in the main flow layout is selected by it's file path (not by clicking it).
        /// </summary>
        private void SelectFile(string p_filePath)
        {
            // find the tree node that has the parameter file name

            List<string> currList;
            TreeNode fileNode = null;

            p_filePath = Path.GetFullPath(p_filePath);

            foreach (TreeNode currNode in f_filesView.Nodes)
            {
                // the tag has the list of files associated with that node

                currList = (List<string>)currNode.Tag;

                foreach (string currPath in currList)
                {
                    if (currPath == p_filePath)
                    {
                        fileNode = currNode;
                        break;
                    }
                }
            }

            // select the node - this calls f_filesView_AfterSelect() !!
            f_filesView.SelectedNode = fileNode;

            // select the file in the node
            f_mainThumbs.SelectThumbByPath(p_filePath);
        }



        // main tumbs layout menu

        private void n_opsDelete_Click(object sender, EventArgs e)
        {
            EditImageData data = f_mainThumbs.GetDataAndRemoveThumb();

            if (data != null)
                f_deleteThumbs.CreateThumb(data);
        }

        private void n_opsRename_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = f_filesView.SelectedNode;

            if (selectedNode != null)
            {
                SmartThumbnail selectedThumb = f_mainThumbs.SelectedThumbnail;

                if (selectedThumb == null)
                    return;

                // get data for rename control's combo box

                string folder = Path.GetDirectoryName(selectedThumb.EditData.FilePathOrig);
                List<string> fileNames = new List<string>(); // FileSystem.GetPotentialGroupNames(folder);
                fileNames.Add(Path.GetFileNameWithoutExtension(selectedThumb.EditData.FilePathOrig));
                

                // open the file name entry dialog window

                RenameCtrl nameCtlr = new RenameCtrl(fileNames);

                using (BaseForm nameForm = new BaseForm(nameCtlr))
                {
                    if (nameForm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                        return;

                    selectedThumb.SetEditedName(nameCtlr.RenameText);
                }
            }

            else
            {
                MessageBox.Show("No tree view node selected");
            }
        }

        private void n_openPaintNet_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = f_filesView.SelectedNode;

            if (selectedNode != null)
            {
                SmartThumbnail selectedThumb = f_mainThumbs.SelectedThumbnail;

                if (selectedThumb == null)
                    return;

                string filePath = selectedThumb.EditData.FilePathOrig;

                // Process.Start does not take an executable as a parameter
                // instead create command line instructions to open file

                System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo("CMD.exe");

                info.WorkingDirectory = @"C:\Program Files\paint.net";
                info.Arguments = "/c PaintDotNet " + @""""+ filePath + @"""";
                info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = info;
                p.Start();
            }

            else
            {
                MessageBox.Show("No tree view node selected");
            }    
        }

        /// <summary>
        /// Quick Name event handler.
        /// </summary>
        private void item_Click(object sender, EventArgs p_eventArgs)
        {
            System.Windows.Forms.ToolStripDropDownItem item = (System.Windows.Forms.ToolStripDropDownItem)sender;

            string group = item.Text;

            SmartThumbnail selectedThumb = f_mainThumbs.SelectedThumbnail;

            selectedThumb.SetEditedName(group);
        }



        // delete thumbs layout menu

        private void undeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditImageData data = f_deleteThumbs.GetDataAndRemoveThumb();

            if (data == null)
                return;

            f_mainThumbs.CreateThumb(data);
        }



        #endregion



        #region Windows Messaging

        public static readonly int WM_LBUTTONDBLCLK = 0x0203;

        // WndProc() is called for every process that is running on computer
        protected override void WndProc(ref Message m)
        {
            // this conditional matches the WndProc that was sent for this window

            if (m.Msg == NativeMethods.WM_FOCUSPICTURESHOW)
            {
                ShowMe();

                // implement code based on another file being double-clicked

   //             string[] test = Environment.GetCommandLineArgs();
            }

            if (m.Msg == WM_LBUTTONDBLCLK)
            {


            }

            // let the other computer processes do their thing
            base.WndProc(ref m);
        }

        // subroutine for WndProc()
        private void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            // get our current "TopMost" value (ours will always be false though)
            bool top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;
        }

        #endregion



    }
}
