using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/**********************************************************************************************************************
BASE FORM
 * Use this as the base for all the program's forms. Doesn't quite fit in Common library becuase other programs require
 * a reference to their main form so that secondary form can be closed properly.
 * Use the mode functions to setup different form styles.
**********************************************************************************************************************/

namespace PictureShow
{
    public partial class BaseForm : Form
    {
        // DATA MEMBERS

        private Control m_customCtrl;   // control must also implement IBaseCtrl
        
        // METHODS

        // constructor
        public BaseForm(Control customCtrl)
        {
            InitializeComponent();

            m_customCtrl = customCtrl;

            // add custom control to form

            this.SuspendLayout();

            this.Width = customCtrl.Width;
            this.Height = customCtrl.Height +20;

            customCtrl.Location = new Point(0, 0);
            customCtrl.Dock = DockStyle.Fill;

            this.Controls.Add(customCtrl);

            (customCtrl as IBaseCtrl).InitializeForm();

            this.ResumeLayout();
        }

        // key press
        private void BaseForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Escape Key
            if (e.KeyChar == 27)
            {
                this.Close();
            }

            else
            {
                (m_customCtrl as IBaseCtrl).KeyPress(sender, e);
            }
        }

        // form closed
        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // show main form

            //if (this != Program.MainForm)
            //    Program.MainForm.Show();
        }

        public void SetDialogMode()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.SizeGripStyle = SizeGripStyle.Hide;

            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ShowIcon = false;
        }

        public void SetFullScreenMode()
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
    BASE CONTROL
    **********************************************************************************************/

    public interface IBaseCtrl
    {       
        /// <summary>
        /// Call this method after the control has a parent form.
        /// </summary>
        void InitializeForm();

        /// <summary>
        /// Send key input to the form to sub control.
        /// </summary>
        void KeyPress(object sender, KeyPressEventArgs ev);

    }
}
