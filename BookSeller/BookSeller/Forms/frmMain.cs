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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmLogIn frm = new frmLogIn();
            if (frm.ShowDialog(this) == DialogResult.Abort)
            {
                this.Close();
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            frmBookViewer frm = new frmBookViewer();
            this.Hide();
            frm.ListBooksOrFilter(false);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            frmViewClients frm = new frmViewClients();
            this.Hide();
            frm.ListClientsOrFilter(false);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnSaleAndHire_Click(object sender, EventArgs e)
        {
            frmSaleAndHire frm = new frmSaleAndHire();
            this.Hide();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                this.Show();
            }
        }
    }
}
