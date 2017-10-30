/**************************************************************************************************
EDIT IMAGE DATA
 * Logic class for managing the editing and saving of an image.
 * Used by SmarThumbnail.
**************************************************************************************************/

#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Utility;
using System.Drawing;
using System.IO;

#endregion


namespace ImageControls
{
    public class EditImageData
    {

        #region Data Members


        public string FilePathOrig = null;

        public string FilePathNew
        {   get { return m_filePathNew; }   }
        private string m_filePathNew;

        public Bitmap ImageOrig = null;

        public Bitmap ImageNew 
        { get { return m_imageNew;}    }
        private Bitmap m_imageNew;


        #endregion



        #region Constructor / Destructor


        public EditImageData(string p_filePath)
        {
            FilePathOrig = p_filePath;

            ImageOrig = new Bitmap(p_filePath);

            /* // this doesn't release the stream with Dispose() ?
            Image imgPicture = Image.FromFile(p_fullPath);
            Image bmpPicture = new Bitmap(imgPicture);
            this.EditData.ImageOrig = bmpPicture;           */
        }

        /// <summary>
        /// Destructorz!!
        /// </summary>
        public void DisposeData()
        {
            if (ImageOrig != null)
            {
                ImageOrig.Dispose();
                ImageOrig = null;
            }

            if (m_imageNew != null)
            {
                m_imageNew.Dispose();
                m_imageNew = null;
            }
        }


        #endregion



        #region Query Methods

        /// <summary>
        /// Returns the edited file path if it exists, otherwise returns the original file path.
        /// </summary>
        public string GetCurrentPath()
        {
            if (FilePathNew != null)
                return FilePathNew;

            if (FilePathOrig != null)
                return FilePathOrig;

            return null;
        }

        /// <summary>
        /// Returns the edited image if it exists, otherwise returns the original image.
        /// </summary>
        public Bitmap GetCurrentImage()
        {
            if (ImageNew != null)
                return ImageNew;

            if (ImageOrig != null)
                return ImageOrig;
   
            return null;
        }

        /// <summary>
        /// Returns true if there is edited data.
        /// </summary>
        public bool IsEdited()
        {
            return (FilePathNew != null || ImageNew != null);
        }

        #endregion



        #region Set Data Members


        public void SetFileNameNew(string p_fileName)
        {
            string createPath = Path.GetDirectoryName(this.FilePathOrig);
            createPath = Path.Combine(createPath, p_fileName + ".jpg");

            createPath = FileSystem.GetUniquePath(createPath);

            m_filePathNew = createPath;
        }

        public void SetFilePathNew(string p_filePath)
        {
            string createPath = FileSystem.GetUniquePath(p_filePath);

            m_filePathNew = createPath;
        }

        public void SetImageNew(Bitmap p_image)
        {
            if (m_imageNew != null)
                m_imageNew.Dispose();

            m_imageNew = p_image;
        }



        #endregion



        #region Save Images


        public void SaveFileCurrent()
        {
            string savePath = null;

            this.ImageOrig.Dispose();

            // substitute old image with new one

            if (this.ImageNew != null)
            {
                File.Delete(this.FilePathOrig);

                // save to original name because name-change comes next

                savePath = this.FilePathOrig;
                savePath = Utility.StringFormat.ChangeFilePathExt(savePath, ".jpg");

                /* Save Test Results
                 * 
                 * the original file was 307kb
                 * with code 1, the saved file was 264kb
                 * with code 2, the saved file was 304kb; on a subsequent save, it remained at 304kb
                
                 // code 1            
                 this.ImageNew.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);      */


                // code 2

                ImageProcessor.SaveHighDef(this.ImageNew, savePath);
            }

            // change file name in place

            if (this.FilePathNew != null)
            {
                savePath = this.FilePathNew;
                savePath = FileSystem.GetUniquePath(savePath);

                File.Move(this.FilePathOrig, savePath);
            }


            // create new image keyword

            if (savePath != null)
            {
                FileSystem.ProcessParams p = new FileSystem.ProcessParams();
                p.FilePath = savePath;

                ImageProcessor.SetImageKeyword(p);
            }

        }

        public void SaveFileOverrideFolder(string p_saveFolder)
        {
            // create the backup file path

            string fileNameNew = Path.GetFileName(this.FilePathOrig);
            fileNameNew = Utility.StringFormat.ChangeFilePathExt(fileNameNew, ".jpg");

            string parentDir = Utility.StringFormat.GetLastDirectoryOnly(this.FilePathOrig);

            string fullPath = Path.Combine(p_saveFolder, parentDir + " - " + fileNameNew);
            fullPath = FileSystem.GetUniquePath(fullPath);

            // save backup image

            ImageProcessor.SaveHighDef(this.ImageOrig, fullPath);
        }


        #endregion


    }

}
