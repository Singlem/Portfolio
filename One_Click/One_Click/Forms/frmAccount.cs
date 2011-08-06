using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace One_Click
{
    public partial class frmAccount : Form
    {
        public frmAccount()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            _cbAddon.SelectedIndex = 2;
            _cbGM.SelectedIndex = 0;
        }

        private void _bCreateAccount_Click(object sender, EventArgs e)
        {
            string query;
            string HashedPass;

            if (_tbUser.Text == string.Empty)
            {
                MessageBox.Show("No username has been given");
                _tbUser.Focus();
                return;
            }
            else if (_tbPass.Text == string.Empty)
            {
                MessageBox.Show("No password has been given");
                _tbPass.Focus();
                return;
            }

            try
            {
                query = "SELECT SHA1(CONCAT(UPPER('" + _tbUser.Text + "'), ':', UPPER('" + _tbPass.Text + "')))";
                HashedPass = MySQLConnenct.PasswordQuery(query, Database.Realm);

                if (HashedPass == null)
                {
                    throw new NoNullAllowedException();
                }

                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO account (username, sha_pass_hash, gmlevel, locked, expansion) ");
                sb.AppendFormat("VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                    _tbUser.Text,
                    HashedPass,
                    _cbGM.SelectedIndex.ToString(),
                    "0",
                    _cbAddon.SelectedIndex.ToString());

                MySQLConnenct.Insert(sb.ToString(), Database.Realm);
                MessageBox.Show("Account: " + _tbUser.Text + " has been created");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong\n" + ex);
            }
            finally
            {
                this.Close();
            }
        }
    }
}
