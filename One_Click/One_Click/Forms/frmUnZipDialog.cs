using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace One_Click
{
    public partial class frmUnZipDialog : Form
    {
        public frmUnZipDialog()
        {
            InitializeComponent();
        }

        private void frmUnZipDialog_Shown(object sender, EventArgs e)
        {
            this.Refresh();
            ServerHandler.UnZip();
            this.DialogResult = DialogResult.OK;
        }
    }
}
