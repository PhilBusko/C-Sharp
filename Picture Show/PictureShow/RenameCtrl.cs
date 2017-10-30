using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PictureShow
{
    public partial class RenameCtrl : UserControl, IBaseCtrl
    {

        public RenameCtrl(List<string> fileNames)
        {
            InitializeComponent();

            f_renameBox.Items.AddRange(fileNames.ToArray());

            f_renameBox.SelectedIndex = 0;
        }


        // IBaseCtrl
        public void InitializeForm()
        {
            BaseForm parent = (this.Parent as BaseForm);

            parent.Text = "Rename Picture";
            parent.SetDialogMode();
        }

        // IBaseCtrl
        public void KeyPress(object sender, KeyPressEventArgs ev)
        {
            // Enter key closes form

            if (ev.KeyChar == (char)Keys.Return)
            {
                this.CloseParent();
            }
        }

        public string RenameText
        {
            get
            {
                if (string.IsNullOrEmpty(f_renameBox.Text) == true)
                    return null;

                else
                    return f_renameBox.Text;
            }
        }

        private void f_finish_Click(object sender, EventArgs e)
        {
            this.CloseParent();
        }

        private void CloseParent()
        {
            if (string.IsNullOrEmpty(RenameText) == false)
                (Parent as Form).DialogResult = DialogResult.OK;

            else
                (Parent as Form).Close();
        }

    }
}
