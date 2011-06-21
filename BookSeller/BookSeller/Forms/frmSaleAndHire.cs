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
    public partial class frmSaleAndHire : Form
    {
        public enum SaleOrHire
        {
            Sale,
            Hire,
            Hold_Hire,
        }

        public frmSaleAndHire()
        {
            InitializeComponent();
        }

        private void frmSaleAndHire_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void frmSaleAndHire_Load(object sender, EventArgs e)
        {
            ListBooksOrFilter(false);
            ListClientsOrFilter(false);
        }

        private void btnBookFilter_Click(object sender, EventArgs e)
        {
            ListBooksOrFilter(true);
        }

        private void btnClientFilter_Click(object sender, EventArgs e)
        {
            ListClientsOrFilter(true);
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            Books book = listBoxBooks.SelectedItem as Books;
            ClientInfo Client = listboxClients.SelectedItem as ClientInfo;
            new SaleAndHireHandler(book.ISBN, Client.FirstName, Client.LastName, SaleOrHire.Sale);
        }

        private void btnHire_Click(object sender, EventArgs e)
        {
            Books book = listBoxBooks.SelectedItem as Books;
            ClientInfo Client = listboxClients.SelectedItem as ClientInfo;
            new SaleAndHireHandler(book.ISBN, Client.FirstName, Client.LastName, SaleOrHire.Hire);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();
            this.Hide();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void btnHoldHire_Click(object sender, EventArgs e)
        {
            //TODO
            Books book = listBoxBooks.SelectedItem as Books;
            ClientInfo Client = listboxClients.SelectedItem as ClientInfo;
            new SaleAndHireHandler(book.ISBN, Client.FirstName, Client.LastName, SaleOrHire.Hold_Hire);
        }

        public void ListBooksOrFilter(bool filter)
        {
            listBoxBooks.Items.Clear();
            Books[] ListedBooks;

            if (filter)
                new BookHandler(out ListedBooks, bookFilterComboBox.Text, edtBookFilter.Text);
            else
                new BookHandler(out ListedBooks);

            foreach (Books Book in ListedBooks)
            {
                if (Book == null)
                    break;
                listBoxBooks.Items.Add(Book);
            }

            listBoxBooks.SelectedIndex = 0;
        }

        public void ListClientsOrFilter(bool filter)
        {
            listboxClients.Items.Clear();
            ClientInfo[] ListedClients;

            if (filter)
                new ClientHandler(out ListedClients, clientFilterComboBox.Text, edtClientFilter.Text);
            else
                new ClientHandler(out ListedClients);

            foreach (ClientInfo Client in ListedClients)
            {
                if (Client == null)
                    break;
                listboxClients.Items.Add(Client);
            }

            listboxClients.SelectedIndex = 0;
        }
    }
}
