using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/**********************************************************************************************************************
BASE FORM
Author: Felipe Busko
 * Use this as the base for all the program's forms. Doesn't quite fit in Common library because other programs require
 * a reference to their main form so that secondary form can be closed properly.
 * Use the mode functions to setup different form styles.
**********************************************************************************************************************/

namespace FileBrowser
{
    
    public partial class BaseForm : Form
    {
        // DATA MEMBERS

        // control must implement IBaseCtrl
        private Control m_customCtrl;
        
        // METHODS

        // constructor
        public BaseForm(Control customCtrl)
        {
            InitializeComponent();

            // add custom control to form

            m_customCtrl = customCtrl;

            (m_customCtrl as UserControl).AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;

            this.SuspendLayout();

            this.Width = customCtrl.Width +6;
            this.Height = customCtrl.Height + 26;

            m_customCtrl.Location = new Point(0, 0);
            
            this.Controls.Add(customCtrl);

            (m_customCtrl as IFileBrowserCtrl).Initialize();      // call interface method

            m_customCtrl.Dock = DockStyle.Fill;                   // necessary for proper form resizing

            this.ResumeLayout(true);
        }

        // an IFileBrowserCtrl can close the baseform by calling this method
        // control must have access to it, use friend class ?
        public void ctrlCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        // key press
        private void BaseForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Escape Key
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }

        // form closed
        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // show main form

            if (this != Program.MainForm)
                Program.MainForm.Show();

            (m_customCtrl as IFileBrowserCtrl).StopCtrlThread();      // call interface method
        }

        public void SetMode_Dialog()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.Sizable;         //FixedDialog;
            this.SizeGripStyle = SizeGripStyle.Auto;         //Hide;

          //  this.MinimizeBox = false;
          //  this.MaximizeBox = false;
            this.ShowIcon = false;
        }

        public void SetMode_FullScreen()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.SizeGripStyle = SizeGripStyle.Auto;

            this.MinimizeBox = true;
            this.MaximizeBox = true;
            this.ShowIcon = false;
        }

    }


    /**********************************************************************************************
    CUSTOM CONTROL INTERFACE
    **********************************************************************************************/

    public interface IFileBrowserCtrl
    {       
        /// <summary>
        /// Call this method after the control has a parent form.
        /// Use it to set the form title and mode.
        /// </summary>
        void Initialize();


        bool StopCtrlThread();

    }
}
