/**************************************************************************************************
WALLPAPER CONFIG
**************************************************************************************************/

#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Utility;
using System.IO;
using System.Runtime.InteropServices;   // DllImport
using System.Drawing;

#endregion


namespace DesktopDisplay
{
    
    public class DisplayConfig
    {

        #region Data Members


        public string ImageDir;
        public string FilePath;
        public string PrevPath;
        public Bitmap DisplayImage;

        [System.Xml.Serialization.XmlIgnore]
        public System.Windows.Forms.Screen ScreenRef;
        public int ClockPeriod;
        public System.Windows.Forms.Padding Margin;


        #endregion



        #region Constructor/Destructor


        public void DisposeData()
        {
            if (DisplayImage != null)
                DisplayImage.Dispose();
        }


        #endregion



        #region Set Image Paths


        public void GoToNextImagePath()
        {
            if (Directory.Exists(this.ImageDir) == false)
                return;

            if (this.FilePath != null)
                this.PrevPath = FilePath;

            // get list of all images in root

            List<string> allFiles = new List<string>();

            AddFilesRecursive(this.ImageDir, ref allFiles);

            // get a random file from the set

            int randIndex = Global.MyRandom.Next(allFiles.Count );

            this.FilePath = allFiles[randIndex];
        }

        private void AddFilesRecursive(string p_folder, ref List<string> p_files)
        {
            DirectoryInfo dir = new DirectoryInfo(p_folder);

            // get all images of current directory

            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo info in files)
            {
                string filePath = info.FullName;

                if (FileSystem.IsJPG(filePath))
                    p_files.Add(filePath);
            }

            // add images in subdirectories

            DirectoryInfo[] dirs = dir.GetDirectories();

            foreach (DirectoryInfo info in dirs)
            {
                string subPath = info.FullName;

                AddFilesRecursive(subPath, ref p_files);
            }
        }

        public void GoToPreviousImagePath()
        {
            if (this.PrevPath != null)
            {
                this.FilePath = this.PrevPath;
                this.PrevPath = null;
            }
        }


        #endregion




        public void CreateDisplayImage()
        {
            // get raw sizes of image

            System.Drawing.Bitmap origImage = new Bitmap(this.FilePath);

            int origW = origImage.Width;
            int origH = origImage.Height;


            // adjust for user-defined margins

            int screenW = this.ScreenRef.Bounds.Width;
            int screenH = this.ScreenRef.Bounds.Height;




            // find the appropriate scaled values

            double vertScale = (double)origH / (double)screenH;
            double horizScale = (double)origW / (double)screenW;

            double trueScale = (vertScale > horizScale ? vertScale : horizScale);

            int scaleW = (trueScale < 1 ? origW : (int)((double)origW / trueScale));
            int scaleH = (trueScale < 1 ? origH : (int)((double)origH / trueScale));

            int centerX = screenW / 2 - scaleW / 2;
            int centerY = screenH / 2 - scaleH / 2;


            // generate the display image

            Color medianColor = ImageProcessor.GetMedianColor(origImage);

            System.Drawing.Bitmap createImage = ImageProcessor.GetCanvas(screenW, screenH, medianColor);

            Graphics createGraphics = Graphics.FromImage((Image)createImage);
            createGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;


            // if scaled values are small enough, tile the image

            if (2.1 * scaleW > screenW)
            {
                createGraphics.DrawImage(origImage, centerX, centerY, scaleW, scaleH);
            }

            else
            {
                int xRange = screenW / 2 - scaleW;
                int yRange = screenH - scaleH;

                int x1Rand = Global.MyRandom.Next(0, xRange) +40;
                int y1Rand = Global.MyRandom.Next(0, yRange);
                int x2Rand = Global.MyRandom.Next(0, xRange) + screenW / 2 -40;
                int y2Rand = Global.MyRandom.Next(0, yRange);

                createGraphics.DrawImage(origImage, x1Rand, y1Rand, scaleW, scaleH);
                createGraphics.DrawImage(origImage, x2Rand, y2Rand, scaleW, scaleH);
            }

            createGraphics.Dispose();
            origImage.Dispose();

            this.DisplayImage = createImage;
        }



        public static Bitmap GetCombinedImage(List<DisplayConfig> p_displays)
        {
            // get combined image size

            int minX = int.MaxValue, maxX = int.MinValue;
            int minY = int.MaxValue, maxY = int.MinValue;

            System.Drawing.Bitmap createImage = null;
            
            for (int d = 0; d < p_displays.Count; d++)
            {
                if (minX > p_displays[d].ScreenRef.Bounds.X)
                    minX = p_displays[d].ScreenRef.Bounds.X;

                if (maxX < p_displays[d].ScreenRef.Bounds.X + p_displays[d].ScreenRef.Bounds.Width)
                    maxX = p_displays[d].ScreenRef.Bounds.X + p_displays[d].ScreenRef.Bounds.Width;

                if (minY > p_displays[d].ScreenRef.Bounds.Y)
                    minY = p_displays[d].ScreenRef.Bounds.Y;

                if (maxY < p_displays[d].ScreenRef.Bounds.Y + p_displays[d].ScreenRef.Bounds.Height)
                    maxY = p_displays[d].ScreenRef.Bounds.Y + p_displays[d].ScreenRef.Bounds.Height;
            }

            int totalW = maxX - minX;
            int totalH = maxY - minY;


            // create combined image

            createImage = ImageProcessor.GetCanvas(totalW, totalH, Color.Blue);

            Graphics createGraphics = Graphics.FromImage((Image)createImage);
            createGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            // must set to tile and not-center
            // primary monitor is always at 0,0
            // set this up just for one monitor away from primary
            // assume monitors are vertical side-by-side

            int vertBias = 0;

            for (int d = 0; d < p_displays.Count; d++)
            {
                if (p_displays[d].ScreenRef.Primary == true)
                {
                    createGraphics.DrawImage(p_displays[d].DisplayImage,
                        0,
                        0,
                        p_displays[d].ScreenRef.Bounds.Width,
                        p_displays[d].ScreenRef.Bounds.Height);

                    vertBias = p_displays[d].ScreenRef.Bounds.Width;
                }
            }

            for (int d = 0; d < p_displays.Count; d++)
            {
                if (p_displays[d].ScreenRef.Primary != true)
                {
                    createGraphics.DrawImage(p_displays[d].DisplayImage,
                        vertBias,
                        0,
                        p_displays[d].ScreenRef.Bounds.Width,
                        p_displays[d].ScreenRef.Bounds.Height);
                }
            }

            // release all resources 

            for (int d = 0; d < p_displays.Count; d++)
                p_displays[d].DisposeData();

            createGraphics.Dispose();
                        

            return createImage;
        }



    }


    public class SystemCommands
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, String pvParam, UInt32 fWinIni);

        private static UInt32 SPI_SETDESKWALLPAPER = 20;
        private static UInt32 SPIF_UPDATEINIFILE = 0x1;
        private static UInt32 SPIF_SENDWININICHANGE = 0x02;

        private static bool ConfigSet = false;

        private static void SetSystemConfig(int p_numDisplays)
        {
            if (SystemCommands.ConfigSet == true)
                return;

            SystemCommands.ConfigSet = true;

            if (p_numDisplays == 1)
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

                key.SetValue(@"WallpaperStyle", 1.ToString());  // center 1, stretch 2
                key.SetValue(@"TileWallpaper", 0.ToString());   // tile 1, don't tile 0
            }

            else if (p_numDisplays > 1)
            {
                // set the system display parameters for multi-desktop trick
                // must tile to get different images on each monitor

                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

                key.SetValue(@"WallpaperStyle", 0.ToString());  // center 1, stretch 2
                key.SetValue(@"TileWallpaper", 1.ToString());   // tile 1, don't tile 0
            }
        }


        public static void Set(List<DisplayConfig> p_displays)
        {
            SystemCommands.SetSystemConfig(p_displays.Count);

            // get appropriate image configuration

            System.Drawing.Bitmap imgFinal;                 

            if (p_displays.Count == 1)
            {
                try
                {
                    p_displays[0].CreateDisplayImage();
                }
                catch
                {
                    p_displays[0].GoToNextImagePath();
                    p_displays[0].CreateDisplayImage();
                }

                imgFinal = p_displays[0].DisplayImage;
            }

            else
            {
                try
                {
                    p_displays[0].CreateDisplayImage();
                }
                catch
                {
                    p_displays[0].GoToNextImagePath();
                    p_displays[0].CreateDisplayImage();
                }

                try
                {
                    p_displays[1].CreateDisplayImage();
                }
                catch
                {
                    p_displays[1].GoToNextImagePath();
                    p_displays[1].CreateDisplayImage();
                }

                imgFinal = DisplayConfig.GetCombinedImage(p_displays);
            }

            foreach (DisplayConfig data in p_displays)
                data.DisposeData();

            // save a bitmap copy of the final image to temp path

            string tempPath = Path.Combine(Path.GetTempPath(), "background.bmp");
            imgFinal.Save(tempPath, System.Drawing.Imaging.ImageFormat.Bmp);
            imgFinal.Dispose();

            SystemParametersInfo(SPI_SETDESKWALLPAPER,
                0,
                tempPath,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }
    
    }

}
