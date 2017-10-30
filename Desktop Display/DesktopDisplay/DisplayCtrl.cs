/**************************************************************************************************
DISPLAY CONTROL
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
using System.Xml.Serialization;
using  System.Windows.Media;        // reference to PresentationFramework

#endregion


namespace DesktopDisplay
{
    public partial class DisplayCtrl : UserControl
    {

        #region Data Members


        private int MonitorNo;

        public DisplayConfig Config;
        public Screen MonitorRef;                   // preserve screen pointer when config is reconfigured

        private Timer Clock;
        private int timerElapse;
        private int timerCumulative;

        private const int TIMER_INCR = 6000;        // 6 seconds

        // events to be sent to main form

        public delegate void ControlEvent();
        public event ControlEvent FormDirty;
        public event ControlEvent UpdateWallpaper;


        #endregion



        #region Constructors


        public DisplayCtrl()
        {
            InitializeComponent();
        }

        public DisplayCtrl(Screen p_screen, int p_monitorNo)
        {
            InitializeComponent();

            this.MonitorNo = p_monitorNo;
            this.MonitorRef = p_screen;

            // initialize monitor info

            f_isPrimary.Text = "Primary: " + (p_screen.Primary ? "Yes" : "No");

            string msg = string.Format("Width: {0}   Height: {1}   X: {2}   Y: {3}",
                p_screen.Bounds.Width, p_screen.Bounds.Height, p_screen.Bounds.X, p_screen.Bounds.Y);

            f_geometry.Text = msg;

            // initialize the config 

            this.Config = this.GetDataFromFile();

            if (Config != null)
            {
                this.SetDataToUI(this.Config);

                if (Config.ImageDir != null)
                    this.StartTimer();
            }
            else
            {
                this.Config = new DisplayConfig();
            }

            this.Config.ScreenRef = this.MonitorRef;
        }


        #endregion



        #region User Interface


        private void f_browse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Choose folder for image rotation.";

                if (this.Config != null && this.Config.ImageDir != null)
                    fbd.SelectedPath = Config.ImageDir;

                if (fbd.ShowDialog() != DialogResult.OK)
                    return;

                // save data to UI and notify the main form

                f_rootFolder.Text = fbd.SelectedPath;

                if (FormDirty != null)
                    FormDirty();
            }
        }

        private void f_timerInterval_ValueChanged(object sender, EventArgs e)
        {
            if (FormDirty != null)
                FormDirty();
        }

        private void f_marginLeft_ValueChanged(object sender, EventArgs e)
        {
            if (FormDirty != null)
                FormDirty();
        }

        private void f_marginTop_ValueChanged(object sender, EventArgs e)
        {
            if (FormDirty != null)
                FormDirty();
        }

        private void f_marginBottom_ValueChanged(object sender, EventArgs e)
        {
            if (FormDirty != null)
                FormDirty();
        }

        private void f_marginRight_ValueChanged(object sender, EventArgs e)
        {
            if (FormDirty != null)
                FormDirty();
        }


        #endregion



        #region Data Management


        private void SetDataToUI(DisplayConfig p_config)
        {
            f_rootFolder.Text = p_config.ImageDir;
            f_timerInterval.Value = p_config.ClockPeriod;
            f_marginTop.Value = p_config.Margin.Top;
            f_marginLeft.Value = p_config.Margin.Left;
            f_marginRight.Value = p_config.Margin.Right;
            f_marginBottom.Value = p_config.Margin.Bottom;
        }

        private DisplayConfig GetDataFromUI()
        {
            DisplayConfig createConfig = new DisplayConfig();

            createConfig.ScreenRef = this.MonitorRef;
            createConfig.ImageDir = f_rootFolder.Text;
            createConfig.ClockPeriod = (int)f_timerInterval.Value;
            createConfig.Margin = new Padding(
                (int)f_marginLeft.Value, (int)f_marginTop.Value, (int)f_marginRight.Value, (int)f_marginBottom.Value);

            return createConfig;
        }

        public void SaveDataToFile()
        {
            Config = this.GetDataFromUI();
            
            XmlSerializer cereal = new XmlSerializer(typeof(DisplayConfig));

            string filePath = this.GetConfigSerialPath(this.MonitorNo);
            TextWriter writer = File.CreateText(filePath);

            cereal.Serialize(writer, this.Config);
            writer.Dispose();
        }

        private DisplayConfig GetDataFromFile()
        {
            XmlSerializer cereal = new XmlSerializer(typeof(DisplayConfig));

            string configPath = this.GetConfigSerialPath(this.MonitorNo);

            if (File.Exists(configPath))
            {
                TextReader reader = File.OpenText(configPath);
                DisplayConfig createConfig = (DisplayConfig)cereal.Deserialize(reader);
                reader.Dispose();

                return createConfig;
            }

            return null;
        }

        private string GetConfigSerialPath(int p_configNo)
        {
            string msg = Utility.StringFormat.GetExecutableRootPath();
            string fileName = "config" + p_configNo + ".xml";

            msg = Path.Combine(msg, fileName);

            return msg;
        }


        #endregion



        #region Image Management


        public void StartTimer()
        {
            this.timerElapse = (Config.ClockPeriod > 0 ? Config.ClockPeriod * 60 : 12) *1000;
            this.timerCumulative = 0;
            f_countdown.Value = 0;

            if (this.Clock != null)
                Clock.Stop();

            Clock = new Timer();
            Clock.Interval = TIMER_INCR;
            Clock.Tick += new EventHandler(Clock_Tick);
            Clock.Start();

            this.Config.GoToNextImagePath();
            this.UpdateStatus();
        }

        private void Clock_Tick(object sender, EventArgs e)
        {
            timerCumulative += TIMER_INCR;

            int prog = (timerCumulative * 100) / timerElapse;
            f_countdown.Value = prog;
        
            if (timerCumulative >= timerElapse)
            {
                this.Config.GoToNextImagePath();
                this.UpdateStatus();

                timerCumulative = 0;
                f_countdown.Value = 0;

                // notify main form
                if (this.UpdateWallpaper != null)
                    this.UpdateWallpaper();
            }

        }

        private void UpdateStatus()
        {
            string folder, name;

            if (this.Config.FilePath != null)
            {
                folder = Utility.StringFormat.GetLastDirectoryOnly(this.Config.FilePath);
                name = Path.GetFileName(this.Config.FilePath);
                f_currImage.Text = Path.Combine(folder, name);
            }

            if (this.Config.PrevPath != null)
            {
                folder = Utility.StringFormat.GetLastDirectoryOnly(this.Config.PrevPath);
                name = Path.GetFileName(this.Config.PrevPath);
                f_previousImage.Text = Path.Combine(folder, name);
            }
        }


        #endregion


    }
}
