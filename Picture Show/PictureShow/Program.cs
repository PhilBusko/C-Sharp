using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Win32;

/**************************************************************************************************
The PictureShow application needs to run only one instance so that double-clicking an associated
file on windows explorer always brings up the same instance. Double-clicking an associated file should
be the main behavior, as this program is an improvement over the windows picture viewer.
The one instance code is from:
http://sanity-free.org/143/csharp_dotnet_single_instance_application.html

Notes: I can't seem to get another command line string[] if the application is already running and a
an associated file is double-clicked on explorer. My work around will be to give the main form 
drag-and-drop capability.
**************************************************************************************************/

namespace PictureShow
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}");

        public static string[] CommandArgs;

        /// <summary>
        /// Use the Main(string[]) overload to get command line arguments.
        /// This works better than Environment.CommandLine because the arguments are already split.
        /// </summary>
        [STAThread]
        static void Main(string[] commandArgs)
        {           
            CommandArgs = commandArgs;
            
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Utility.LogRight.OpenLog("PictureShow Log.txt");
                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
                mutex.ReleaseMutex();
            }
            else
            {
                // send our Win32 message to make the currently running instance
                // jump on top of all the other windows
                NativeMethods.PostMessage(
                    (IntPtr)NativeMethods.HWND_BROADCAST,
                    NativeMethods.WM_FOCUSPICTURESHOW,
                    IntPtr.Zero,
                    IntPtr.Zero);
            }


        //    SetAssociation(".jpg", "JPG_Program", Application.ExecutablePath, "JPG Image File");

            Utility.LogRight.CloseLog();
        }


        public static void SetAssociation(string Extension, string KeyName, string OpenWith, string FileDescription)
        {
            
            Registry.ClassesRoot.CreateSubKey(".jpg").SetValue("", "JPG Image", Microsoft.Win32.RegistryValueKind.String);
            Registry.ClassesRoot.CreateSubKey(@"JPG Image\shell\open\command").SetValue("", Application.ExecutablePath, Microsoft.Win32.RegistryValueKind.String);           


            /*
            RegistryKey BaseKey;
            RegistryKey OpenMethod;
            RegistryKey Shell;
            RegistryKey CurrentUser;

            BaseKey = Registry.ClassesRoot.CreateSubKey(Extension);
            BaseKey.SetValue("", KeyName);

            OpenMethod = Registry.ClassesRoot.CreateSubKey(KeyName);
            OpenMethod.SetValue("", FileDescription);
            OpenMethod.CreateSubKey("DefaultIcon").SetValue("", "\"" + OpenWith + "\",0");
            Shell = OpenMethod.CreateSubKey("Shell");
            Shell.CreateSubKey("edit").CreateSubKey("command").SetValue("", "\"" + OpenWith + "\"" + " \"%1\"");
            Shell.CreateSubKey("open").CreateSubKey("command").SetValue("", "\"" + OpenWith + "\"" + " \"%1\"");
            BaseKey.Close();
            OpenMethod.Close();
            Shell.Close();

            CurrentUser = Registry.CurrentUser.CreateSubKey(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.jpg");

            if (CurrentUser != null)
            {
                CurrentUser = CurrentUser.OpenSubKey("UserChoice", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                CurrentUser.SetValue("Progid", KeyName, RegistryValueKind.String);
                CurrentUser.Close();
            }
            else
            {
                Utility.LogRight.WriteLog("JPG Registry Key not created.");
            }

            // The stuff that was above here is basically the same

            // Delete the key instead of trying to change it
            CurrentUser = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.jpg", true);
            CurrentUser.DeleteSubKey("UserChoice", false);
            CurrentUser.Close();

            // Tell explorer the file association has been changed
            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);

            */
        }


        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);


    }

    // this class just wraps some Win32 stuff that we're going to use
    internal class NativeMethods
    {
        public const int HWND_BROADCAST = 0xffff;

        public static readonly int WM_FOCUSPICTURESHOW = RegisterWindowMessage("WM_FOCUSPICTURESHOW");

        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }




}
