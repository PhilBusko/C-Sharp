using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Utility;

/**************************************************************************************************
OBJECTIVES
This program will encapsulate the majority of my file browsing functionalities. 

ARCHITECTURE
The program will launch several forms from the MainForm. The way this is done currently is
using NewForm.Show() and MainForm.Hide(). This requires NewForm to overload the FormClosed() 
function and call MainForm.Show() in it.

**************************************************************************************************/

namespace FileBrowser
{
    static class Program
    {
        /// <summary>
        /// Get the main form.
        /// </summary>
        public static BaseForm MainForm
        { get { return m_mainForm; } }
        private static BaseForm m_mainForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Utility.LogRight.OpenLog("File Browser Log.txt");

            m_mainForm = new BaseForm(new MainSelector());
            Application.Run(m_mainForm);

            Utility.LogRight.CloseLog();
        }
    }
}
