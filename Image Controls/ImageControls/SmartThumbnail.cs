/**************************************************************************************************
SMART THUMBNAIL
 * This class inherits from UserControl and creates a custom thumbnail control.
**************************************************************************************************/

#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Utility;

#endregion


namespace ImageControls
{
    public partial class SmartThumbnail : UserControl
    {

    
        #region Data Members


        public EditImageData EditData;

        /// <summary>
        /// Whether this object is currently selected or not.
        /// </summary>
        public bool IsSelected
        { get { return m_isSelected; } }
        private bool m_isSelected;

        public static int THUMBNAIL_MARGIN = 3;
        public static int PIXEL_TEXTHEIGHT = 25;


        #endregion



        #region Constructor / Destructor


        // default constructor required for designer
        public SmartThumbnail() { }

        public SmartThumbnail(string p_fullPath, Size p_size)
        {                   
            this.EditData = new EditImageData(p_fullPath);

            this.Initialize(p_size);
        }

        public SmartThumbnail(EditImageData p_data, Size p_size)
        {
            this.EditData = p_data;

            this.Initialize(p_size);
        }


        private void Initialize(Size p_size)
        {
            // disable thumbnails so parent FlowLayout has access to mouse events
            this.Enabled = false;

            // format the SmartThumbnail to match it's parent's requested size

            InitializeComponent();

            this.Size = p_size;

            f_imageBox.Location = new System.Drawing.Point(THUMBNAIL_MARGIN -1, THUMBNAIL_MARGIN -1);
            f_imageBox.Height = this.Height - (THUMBNAIL_MARGIN * 2) - PIXEL_TEXTHEIGHT;
            f_imageBox.Width = this.Width - (THUMBNAIL_MARGIN * 2);
            f_imageBox.SizeMode = PictureBoxSizeMode.Zoom;
          //  f_imageBox.BackColor = Color.Aquamarine;

            f_fileName.Location = new System.Drawing.Point(THUMBNAIL_MARGIN, this.Height - PIXEL_TEXTHEIGHT);

            this.DisplayData();
        }

        public void DisposeThumb()
        {
            this.EditData.DisposeData();

            if (f_imageBox.Image != null)
                f_imageBox.Image.Dispose();

            f_imageBox.Dispose();
        }


        #endregion



        #region Thumbnail Display


        /// <summary>
        /// Display the current data in the thumbnail.
        /// </summary>
        private void DisplayData()
        {
            Image currImage = this.EditData.GetCurrentImage();

            if (currImage != null)
            {
                if (FileSystem.IsJPG(this.EditData.FilePathOrig) == false)
                    f_imageBox.BackColor = Color.Aqua;

                else if (currImage.Height < 400 || currImage.Width < 400)
                    f_imageBox.BackColor = Color.Red;

                else if (currImage.Height < 500 || currImage.Width < 500)
                    f_imageBox.BackColor = Color.Orange;

                else if (currImage.Height < 600 || currImage.Width < 600)
                    f_imageBox.BackColor = Color.Yellow;

                this.f_imageBox.Image = currImage;
            }

            string fileName = this.EditData.GetCurrentPath();

            f_fileName.Text = System.IO.Path.GetFileNameWithoutExtension(fileName);
        }

        public void SelectThis()
        {
            // if already selected, ignore
            if (m_isSelected == true)
                return;

            // select this thumbnail

            m_isSelected = true;
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        public void DeselectThis()
        {
            // if already deselected, ignore
            if (m_isSelected == false)
                return;

            m_isSelected = false;
            this.BorderStyle = BorderStyle.None;
        }


        #endregion



        #region Edit Image Data


        /// <summary>
        /// Set the edited file name. Uses the original file folder.
        /// Updates the UI with new data.
        /// </summary>
        public void SetEditedName(string p_fileName)
        {
            EditData.SetFileNameNew(p_fileName);

            this.DisplayData();
        }
        
        /// <summary>
        /// Set the entire edited file path. 
        /// </summary>
        public void SetEditedPath(string p_filePath)
        {
            EditData.SetFilePathNew(p_filePath);

            // this.DisplayData();
        }

        /// <summary>
        /// Set the thimbnails' data and refresh the display.
        /// </summary>
        public void SetEditedImage(Bitmap p_editedImage)
        {
            this.EditData.SetImageNew(p_editedImage);

            this.DisplayData();
        }


        #endregion




        private void SmartThumbnail_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("mouse cl STN");
        }



    }

}
