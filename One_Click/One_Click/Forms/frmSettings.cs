using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using One_Click.Properties;

namespace One_Click
{
    public partial class frmSettings : Form
    {
        bool canClose = false;

        public frmSettings()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            canClose = false;
        }

        private void _bTestConnect_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "Test")
            {
                //needed to test connection
                Settings.Default.User = _tbUser.Text;
                Settings.Default.Pass = _tbPass.Text;
                Settings.Default.Host = _tbHost.Text;
                Settings.Default.Port = _tbPort.Text;
                Settings.Default.DB_Mangos = _tbBase.Text;
                Settings.Default.DB_Char = _tbCharDB.Text;
                Settings.Default.DB_Realm = _tbRealmDB.Text;
                Settings.Default.DB_Scriptdev = _tbScriptdevDB.Text;
                Settings.Default.Save();

                if (MySQLConnenct.IsConnected)
                    MessageBox.Show("Connection is successfully!", "MySQL Connections!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No connection to database, please check settings", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void _bSaveAC_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void _bServerPath_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                _tbServerPath.Text = folderBrowser.SelectedPath;
            }
        }

        private void _bSaveServer_Click(object sender, EventArgs e)
        {
            if (!File.Exists(_tbServerPath.Text + @"\" + _tbWorldExe.Text))
                MessageBox.Show("Can't seem to find exe files. Please make sure name of exe is correct\n" +
                    "Need to have exe at the end!");
        }

        private void SaveSettings()
        {
            //Server
            Settings.Default.ServerPath = _tbServerPath.Text;
            Settings.Default.WordExe = _tbWorldExe.Text;
            Settings.Default.RealmExe = _tbRealmExe.Text;

            //Database
            Settings.Default.User = _tbUser.Text;
            Settings.Default.Pass = _tbPass.Text;
            Settings.Default.Host = _tbHost.Text;
            Settings.Default.Port = _tbPort.Text;
            Settings.Default.DB_Mangos = _tbBase.Text;
            Settings.Default.DB_Char = _tbCharDB.Text;
            Settings.Default.DB_Realm = _tbRealmDB.Text;
            Settings.Default.DB_Scriptdev = _tbScriptdevDB.Text;

            //Git
            Settings.Default.CoreGit = _tbCoreGit.Text;
            Settings.Default.DatabaseGit = _tbDatabaseGit.Text;
            Settings.Default.ScriptdevGit = _tbScriptdevGit.Text;

            //AC
            Settings.Default.ACConfig = _cbConfig.SelectedIndex;
            Settings.Default.ACPlatform = _cbPlatform.SelectedIndex;

            Settings.Default.Save();
            MessageBox.Show("Settings Saved");
            canClose = true;
            this.Close();
        }

        private void LoadSettings()
        {
            _tbHost.Text = Settings.Default.Host;
            _tbPort.Text = Settings.Default.Port;
            _tbUser.Text = Settings.Default.User;
            _tbPass.Text = Settings.Default.Pass;
            _tbBase.Text = Settings.Default.DB_Mangos;
            _tbCharDB.Text = Settings.Default.DB_Char;
            _tbRealmDB.Text = Settings.Default.DB_Realm;
            _tbScriptdevDB.Text = Settings.Default.DB_Scriptdev;
            _tbCoreGit.Text = Settings.Default.CoreGit;
            _tbDatabaseGit.Text = Settings.Default.DatabaseGit;
            _tbScriptdevGit.Text = Settings.Default.ScriptdevGit;
            _cbConfig.SelectedIndex = Settings.Default.ACConfig;
            _cbPlatform.SelectedIndex = Settings.Default.ACPlatform;
            _tbServerPath.Text = Settings.Default.ServerPath;
            _tbWorldExe.Text = Settings.Default.WordExe;
            _tbRealmExe.Text = Settings.Default.RealmExe;
        }

        private void frmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;

            if (!canClose)
            {
                result = MessageBox.Show("Seetings has not been saved.\nDo you want to save?", "Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    e.Cancel = true;
                else
                {
                    canClose = true;
                    Settings.Default.Save();
                    this.Close();
                }
            }
        }
    }
}
