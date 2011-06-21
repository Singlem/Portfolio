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
    public partial class frmViewClients : Form
    {
        public enum SaveOrUpdateOrDelete
        {
            Save,
            Update,
            Delete
        };

        public frmViewClients()
        {
            InitializeComponent();
        }

        private void frmViewClients_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public void ListClientsOrFilter(bool filter)
        {
            listboxClients.Items.Clear();
            ClientInfo[] ListedClients;

            if (filter)
                new ClientHandler(out ListedClients, filterComboBox.Text, FilterTextBox.Text);
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

        private void listboxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientInfo Info = listboxClients.SelectedItem as ClientInfo;
            edtFirstName.Text = Info.FirstName;
            edtLastName.Text = Info.LastName;
            edtEMail.Text = Info.E_Mail;
            edtStreet.Text = Info.Street;
            edtCity.Text = Info.City;
            edtProvince.Text = Info.Province;
            edtZip.Text = Info.Zip;
            edtPurchased.Text = Info.Books_purchased.ToString();
            edtHired.Text = Info.Books_hired.ToString();
        }

        private bool SaveOrUpdateOrDeleteSQL(SaveOrUpdateOrDelete saveOrUpdateDelete)
        {
            bool success;

            ClientInfo Client = new ClientInfo
            {
                FirstName = edtFirstName.Text,
                LastName = edtLastName.Text,
                Street = edtStreet.Text,
                City = edtCity.Text,
                Province = edtProvince.Text,
                Zip = edtZip.Text,
                E_Mail = edtEMail.Text,
                Books_purchased = int.Parse(edtPurchased.Text),
                Books_hired = int.Parse(edtHired.Text),
            };

            new ClientHandler(Client, saveOrUpdateDelete, out success);
            return success;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Add Client")
            {
                edtFirstName.Clear();
                edtLastName.Clear();
                edtStreet.Clear();
                edtCity.Clear();
                edtProvince.Clear();
                edtZip.Clear();
                edtEMail.Clear();
                edtPurchased.Text = "0";
                edtHired.Text = "0";
                btnAdd.Text = "Save";
                btnDone.Text = "Cancel";
            }
            else
            {
                if (DataValidate())
                    if (SaveOrUpdateOrDeleteSQL(SaveOrUpdateOrDelete.Save))
                    {
                        MessageBox.Show(edtFirstName.Text + " has been saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListClientsOrFilter(false);
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;
                        EditOptionsGroupBox.Visible = false;
                        btnAdd.Text = "Add Client";
                    }
            }
        }

        private bool DataValidate()
        {
            if (edtFirstName.Text == "")
            {
                MessageBox.Show("No Firstname has been given");
                edtFirstName.Focus();
                return false;
            }
            else if (edtLastName.Text == "")
            {
                MessageBox.Show("No Lastname has been given");
                edtLastName.Focus();
                return false;
            }
            else if (edtEMail.Text == "")
            {
                MessageBox.Show("No E-Mail has been given");
                edtEMail.Focus();
                return false;
            }
            else if (edtStreet.Text == "")
            {
                MessageBox.Show("No Street has been given");
                edtStreet.Focus();
                return false;
            }
            else if (edtCity.Text == "")
            {
                MessageBox.Show("No City has been given");
                edtCity.Focus();
                return false;
            }
            else if (edtProvince.Text == "")
            {
                MessageBox.Show("No Province has been given");
                edtProvince.Focus();
                return false;
            }
            else if (edtZip.Text == "")
            {
                MessageBox.Show("No Zip has been given");
                edtZip.Focus();
                return false;
            }
            else if (edtPurchased.Text == "")
            {
                MessageBox.Show("No Purchased value has been given");
                edtPurchased.Focus();
                return false;
            }
            else if (edtHired.Text == "")
            {
                MessageBox.Show("No Hired value has been given");
                edtHired.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DataValidate())
                if (SaveOrUpdateOrDeleteSQL(SaveOrUpdateOrDelete.Update))
                {
                    MessageBox.Show(edtFirstName.Text + " has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListClientsOrFilter(false);
                }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditOptionsGroupBox.Visible = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnShowFilter_Click(object sender, EventArgs e)
        {
            FilterGroupBox.Visible = true;
            filterComboBox.SelectedIndex = 0;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ListClientsOrFilter(true);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ListClientsOrFilter(false);
            FilterGroupBox.Visible = false;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (btnDone.Text == "Cancel")
            {
                EditOptionsGroupBox.Visible = false;
                ListClientsOrFilter(false);
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnDone.Text = "Done";
                btnAdd.Text = "Add Client";
            }
            else
            {
                FilterGroupBox.Visible = false;
                EditOptionsGroupBox.Visible = false;
                btnRemove.PerformClick();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SaveOrUpdateOrDeleteSQL(SaveOrUpdateOrDelete.Delete))
            {
                MessageBox.Show(edtFirstName.Text + " has been Deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListClientsOrFilter(false);
            }
        }
    }
}
