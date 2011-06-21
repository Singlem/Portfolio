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
    public partial class frmOrder : Form
    {
        public frmOrder()
        {
            InitializeComponent();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (edtName.Text == "")
            {
                MessageBox.Show("No Name has been given", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                edtName.Focus();
                return;
            }
            else if (edtISBN.Text == "")
            {
                MessageBox.Show("No ISBN has been given", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                edtISBN.Focus();
                return;
            }

            new SaleAndHireHandler(edtName.Text, edtISBN.Text);
            this.DialogResult = DialogResult.OK;
        }
    }
}
