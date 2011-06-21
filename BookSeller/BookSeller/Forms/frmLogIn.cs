using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BookSeller
{
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            bool Success;

            if (edtUser.Text == "")
            {
                MessageBox.Show("Please input a Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                edtUser.Focus();
                return;
            }

            if (edtPassword.Text == "")
            {
                MessageBox.Show("Please input a Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                edtPassword.Focus();
                return;
            }

            new LogInHandler(out Success, edtUser.Text, edtPassword.Text);
            if (Success)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void frmLogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }
    }
}
