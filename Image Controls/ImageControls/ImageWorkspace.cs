/**********************************************************************************************************************
IMAGE WORKSPACE
 * This custom control is mainly a wrapper for a picture box. Also displays text information about image.
 * Capabilities: zoom image displayed, crop, rotate, undo.
**********************************************************************************************************************/

#region Using 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Utility;

#endregion


namespace ImageControls
{
    public partial class ImageWorkspace : UserControl
    {


        #region Data Members


        public SmartThumbnail GetCurrentThumb
        { get { return m_thumbRef; } }
        private SmartThumbnail m_thumbRef;

        private double m_zoomLevel;
        private const float ZOOM_INCREMENT = 0.10f;

        private ViewModeType m_viewMode = ViewModeType.Shrink;

        enum ViewModeType
        {
            Shrink,
            Actual,
            None
        }

        // these data members exist to retain in memory a more precise value of the image box's sizes
        // this is necessary to get the correct crop rectangle size (specially when the image is zoomed out)

        private double m_imageBoxH;
        private double m_imageBoxW;

        // IMAGE CHANGED EVENT

        public event ImageChangedEvent ImageChangedUpdate;
        public delegate void ImageChangedEvent();


        #endregion



        #region Image Display


        /// <summary>
        /// Constructor initializes variables.
        /// </summary>
        public ImageWorkspace()
        {
            InitializeComponent();

            f_imageBox.Enabled = false;
            f_imageBox.SendToBack();

            f_imageBox.Visible = true;
            f_imageBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        /// <summary>
        /// Set the current SmartThumbnail reference and display it.
        /// </summary>
        public void SetCurrentThumb(SmartThumbnail currThumb)
        {            
            m_thumbRef = currThumb;

            if (m_viewMode == ViewModeType.Shrink)
                m_zoomLevel = (GetZoomToShrink() < 1f ? GetZoomToShrink() : 1f);

            else if (m_viewMode == ViewModeType.Actual)
                m_zoomLevel = 1f;

            DisplayThumb();
        }

        /// <summary>
        /// Updates the form with the image and data from the current SmartThumbnail using the current zoom level.
        /// </summary>
        private void DisplayThumb()
        {
            if (m_thumbRef == null)
            {
                f_imageBox.Image = null;
                f_imageBox.Invalidate();

                f_name.Text = "Name:";
                f_dimensions.Text = "Dimensions:";

                return;
            }
            

            // reset the image panel, or image box locations are screwy

            f_imagePanel.AutoScrollPosition = new Point(0, 0);
            f_imagePanel.Invalidate();


            // scale the image based on the current zoom level
            
            Image displayImage = m_thumbRef.EditData.GetCurrentImage();

            m_imageBoxW = (double)displayImage.Width * m_zoomLevel;
            m_imageBoxH = (double)displayImage.Height * m_zoomLevel;


            // display the image
            // setting one of these fields forces the PictureBox to redraw

            Point locTopLeft = new Point();
            locTopLeft.X = (f_imagePanel.Width - (int)m_imageBoxW) /2; 
            locTopLeft.Y = (f_imagePanel.Height - (int)m_imageBoxH) /2;

            if (locTopLeft.X < 6)
                locTopLeft.X = 6;

            if (locTopLeft.Y < 6)
                locTopLeft.Y = 6;

            f_imageBox.Location = locTopLeft;
            f_imageBox.Size = new Size((int)m_imageBoxW, (int)m_imageBoxH);     // same as AutoSize = true

            f_imageBox.Image = displayImage;


            // scroll to center of image

            int scrollX = f_imageBox.Size.Width / 2 - f_imagePanel.ClientSize.Width / 2;
            int scrollY = f_imageBox.Size.Height /2 - f_imagePanel.ClientSize.Height / 2;

            f_imagePanel.AutoScrollPosition = new Point(scrollX, scrollY);


            // update text info

            string nameMsg = "Name: " + System.IO.Path.GetFileNameWithoutExtension(m_thumbRef.EditData.GetCurrentPath());
            nameMsg += string.Format(" ({0})", ImageProcessor.RawFormatToString(displayImage.RawFormat).Trim());
            f_name.Text = nameMsg;
            f_dimensions.Text = "Dimensions: " + displayImage.Width + " x " + displayImage.Height;
            f_dimensions.Text += " (" + (m_zoomLevel * 100).ToString("0.0") + "%)";

            m_selectRect = Rectangle.Empty;
        }

        public void ClearThumb()
        {
            m_thumbRef = null;

            DisplayThumb();
        }


        #endregion



        #region Image Zoom UI & Logic



        private void f_zoomShrink_Click(object sender, EventArgs e)
        {
            m_viewMode = ViewModeType.Shrink;
            m_zoomLevel = GetZoomToShrink();
            DisplayThumb();
        }

        private void f_zoomActual_Click(object sender, EventArgs e)
        {
            m_viewMode = ViewModeType.Actual;
            m_zoomLevel = 1f;
            DisplayThumb();
        }

        private void f_zoomIn_Click(object sender, EventArgs e)
        {
            m_zoomLevel += ZOOM_INCREMENT;
            DisplayThumb();
        }

        private void f_zoomOut_Click(object sender, EventArgs e)
        {
            m_zoomLevel -= ZOOM_INCREMENT;
            DisplayThumb();
        }


        /// <summary>
        /// Get the zoom value to shrink, if necessary, the image to the current ImagePanel dimensions.
        /// </summary>
        private double GetZoomToShrink()
        {
            if (m_thumbRef == null)
                return 0.0;

            Image currentImage = m_thumbRef.EditData.GetCurrentImage();

            if (currentImage == null)
                return 0.0;

            double zoomW = (double)(f_imagePanel.Width - 12) / (double)currentImage.Width;
            double zoomH = (double)(f_imagePanel.Height - 12) / (double)currentImage.Height;

            zoomW = Math.Round(zoomW, 3);
            zoomH = Math.Round(zoomH, 3);

            if (zoomW < zoomH)
                return zoomW;

            return zoomH;
        }


        #endregion



        #region Selection Rectangle

        /* 
         * I'd like to implement the selection rectangle with events in only one windows controls -
         * either the image panel or the image box. The image box goes inside the panel.
         * It has to be the image panel, so that the user
         * can start the selection rectangle outside of the image. Setting the image box to disabled
         * works well as the mouse events are then handled by the panel, even if the event happens in
         * the box's area. 
         * The only snag is that the PictureBox.CreateGraphics() is buggy, so the next
         * best way of getting the image box's graphics, to draw the selection rectangle, is off the paint
         * event handler's parameters.    
        */

        // DATA MEMBERS

        private bool m_mouseDown;
        private Point m_mouseStart;
        private Rectangle m_selectRect;

        private static Pen SELECTION_PEN = new Pen(Brushes.Red, 1.0f);

        // SELECTION RECTANGLE EVENTS
        
        private void f_imagePanel_MouseDown(object sender, MouseEventArgs e)
        {
            m_mouseDown = true;
            m_mouseStart.X = ((MouseEventArgs)e).X;
            m_mouseStart.Y = ((MouseEventArgs)e).Y;
        }

        private void f_imagePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_mouseDown == true)
            {
                m_selectRect = new Rectangle();

                int newX = ((MouseEventArgs)e).X;
                int newY = ((MouseEventArgs)e).Y;

                if (newX > m_mouseStart.X && newY > m_mouseStart.Y)
                {
                    m_selectRect.Location = m_mouseStart;
                    m_selectRect.Width = newX - m_mouseStart.X;
                    m_selectRect.Height = newY - m_mouseStart.Y;
                }

                else if (newX > m_mouseStart.X && newY < m_mouseStart.Y)
                {
                    m_selectRect.Location = new Point(m_mouseStart.X, newY);
                    m_selectRect.Width = newX - m_mouseStart.X;
                    m_selectRect.Height = m_mouseStart.Y - newY;
                }

                else if (newX < m_mouseStart.X && newY > m_mouseStart.Y)
                {
                    m_selectRect.Location = new Point(newX, m_mouseStart.Y);
                    m_selectRect.Width = m_mouseStart.X - newX;
                    m_selectRect.Height = newY - m_mouseStart.Y;
                }

                else if (newX < m_mouseStart.X && newY < m_mouseStart.Y)
                {
                    m_selectRect.Location = new Point(newX, newY);
                    m_selectRect.Width = m_mouseStart.X - newX;
                    m_selectRect.Height = m_mouseStart.Y - newY;
                }

                // this built-in method causes a paint event to be called
                
                f_imagePanel.Invalidate(true);

            }
        }

        private void f_imagePanel_MouseUp(object sender, MouseEventArgs e)
        {
            m_mouseDown = false;
        }

        /// <summary>
        /// Implement the image panel's Paint event.
        /// </summary>
        private void f_imagePanel_Paint(object sender, PaintEventArgs e)
        {
            if (m_mouseDown == true)
            {
                e.Graphics.DrawRectangle(SELECTION_PEN, m_selectRect);
            }
        }

        /// <summary>
        /// Implement the image box's Paint event.
        /// </summary>
        private void f_imageBox_Paint(object sender, PaintEventArgs e)
        {
            if (m_mouseDown == true)
            {
                e.Graphics.DrawRectangle(SELECTION_PEN, this.GetImageBoxRectangle());
            }
        }

        #endregion



        #region Image Editing UI


        private int ShortCutCrop = 2;

        private void f_editCrop_Click(object sender, EventArgs e)
        {
            CropImage();
        }

        private void f_cropLeft_Click(object sender, EventArgs e)
        {
            int w = f_imageBox.Image.Width;
            int h = f_imageBox.Image.Height;

            Rectangle cropR = new Rectangle(ShortCutCrop, 0, w - ShortCutCrop, h);

            this.CropImage(cropR);
        }

        private void f_cropTop_Click(object sender, EventArgs e)
        {
            int w = f_imageBox.Image.Width;
            int h = f_imageBox.Image.Height;

            Rectangle cropR = new Rectangle(0, ShortCutCrop, w, h - ShortCutCrop);

            this.CropImage(cropR);
        }

        private void f_cropBottom_Click(object sender, EventArgs e)
        {
            int w = f_imageBox.Image.Width;
            int h = f_imageBox.Image.Height;

            Rectangle cropR = new Rectangle(0, 0, w, h - ShortCutCrop);

            this.CropImage(cropR);
        }

        private void f_cropR_Click(object sender, EventArgs e)
        {
            int w = f_imageBox.Image.Width;
            int h = f_imageBox.Image.Height;

            Rectangle cropR = new Rectangle(0, 0, w - ShortCutCrop, h);

            this.CropImage(cropR);
        }


        private void f_blur_Click(object sender, EventArgs e)
        {                
            if (m_thumbRef == null)
                return;
            
            Bitmap edit = m_thumbRef.EditData.GetCurrentImage();

            if (edit == null)
                return;

            Cursor.Current = Cursors.WaitCursor;

            Bitmap blur = ImageProcessor.Blur(edit);

            m_thumbRef.SetEditedImage(blur);
            UpdateDisplay();

            Cursor.Current = Cursors.Default;
        }

        private void f_editRotate_Click(object sender, EventArgs e)
        {
            if (m_thumbRef == null)
                return;

            Bitmap rotateImage = ImageProcessor.CloneImage(m_thumbRef.EditData.GetCurrentImage(), Rectangle.Empty);

            // rotate image by 90
            rotateImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

            m_thumbRef.SetEditedImage(rotateImage);
            UpdateDisplay();
        }

        private void f_editUndo_Click(object sender, EventArgs e)
        {
            m_thumbRef.SetEditedImage(null);
            UpdateDisplay();
        }


        #endregion



        #region Image Editing Logic


        // subroutine for cropping an image
        public void CropImage()
        {
            // check for an image and a rectangle

            if (f_imageBox.Image == null || m_selectRect.IsEmpty == true)
            {
                UpdateDisplay();
                return;
            }

            // crop the image in the edit memory

            Rectangle cropRect = GetCropRectangle();

            this.CropImage(cropRect);
        }

        private void CropImage(Rectangle p_rect)
        {
            Bitmap cropImage = ImageProcessor.CloneImage(m_thumbRef.EditData.GetCurrentImage(), p_rect);

            m_thumbRef.SetEditedImage(cropImage);

            UpdateDisplay();
        }

        // subroutine to translate image panel coordinates rectangle to image box coordinates
        private Rectangle GetImageBoxRectangle()
        {
            if (m_selectRect == Rectangle.Empty)
                return Rectangle.Empty;

            Rectangle boxBias = new Rectangle(
                                new Point(m_selectRect.Location.X - f_imageBox.Location.X ,
                                          m_selectRect.Location.Y - f_imageBox.Location.Y ),
                                new Size(m_selectRect.Width, m_selectRect.Height));

            return boxBias;
        }

        private Rectangle GetCropRectangle()
        {
            // error checking
            
            if (m_selectRect == Rectangle.Empty)
                return Rectangle.Empty;


            // get sizes scaled to current display sizes

            double leftZ, rightZ, topZ, bottomZ;

            if (m_selectRect.Left <= f_imageBox.Location.X)
                leftZ = 0;
            else
                leftZ = m_selectRect.Left - f_imageBox.Location.X;

            if (m_selectRect.Right >= (f_imageBox.Location.X + f_imageBox.Width))
                rightZ = m_imageBoxW; // f_imageBox.Width;
            else
                rightZ = m_selectRect.Right - f_imageBox.Location.X;

            if (m_selectRect.Top <= f_imageBox.Location.Y)
                topZ = 0;
            else
                topZ = m_selectRect.Top - f_imageBox.Location.Y;

            if (m_selectRect.Bottom >= (f_imageBox.Location.Y + f_imageBox.Height))
                bottomZ = m_imageBoxH; // f_imageBox.Height;
            else
                bottomZ = m_selectRect.Bottom - f_imageBox.Location.Y;


            // get sizes scaled to actual image size

            int leftR = (int)(leftZ / m_zoomLevel +.5);
            int rightR = (int)(rightZ / m_zoomLevel + .5);
            int topR = (int)(topZ / m_zoomLevel + .5);
            int bottomR = (int)(bottomZ / m_zoomLevel + .5);


            Rectangle cropRect = new Rectangle(leftR, topR, rightR - leftR, bottomR - topR);

            return cropRect;
        }

        // subroutine for common editing update
        private void UpdateDisplay()
        {
            m_zoomLevel = (GetZoomToShrink() < 1f ? GetZoomToShrink() : 1f);
            DisplayThumb();

            m_selectRect = Rectangle.Empty;

            // send event for current image being changed

            if (ImageChangedUpdate != null)
                ImageChangedUpdate();
        }


        #endregion


    }
}
