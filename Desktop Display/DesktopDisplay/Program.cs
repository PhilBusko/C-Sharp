/**************************************************************************************************
PROGRAM
**************************************************************************************************/

#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Microsoft.Win32;      // registry modifications

#endregion


namespace DesktopDisplay
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Utility.LogRight.OpenLog("changer_log.txt");


            Program.InitializeSystem();

            ChangerForm mainWindow = new ChangerForm();

            Application.Run(mainWindow);


            Utility.LogRight.CloseLog();
        }

        private static void InitializeSystem()
        {
            // set the app to start with windows

            RegistryKey key = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            key.SetValue(@"DesktopDisplay", Application.ExecutablePath.ToString());
        }

    }


}
