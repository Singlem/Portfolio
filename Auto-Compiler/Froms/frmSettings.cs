using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Auto_Compiler
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        bool canClose   = false;
        bool enable     = false;
        int _hours      = 0;
        int _min        = 0;
        int _sec        = 0;

        private void LoadSettings()
        {
            edtCoreGit.Text = ConfigSettings.ReadGitCoreSetting(GitTypes.Core);
            //edtDatabaseGit.Text = ConfigSettings.ReadGitCoreSetting(GitTypes.Database);
            edtSD2Git.Text = ConfigSettings.ReadGitCoreSetting(GitTypes.Scriptdev2);
            cmbPlaform.Text = ConfigSettings.ReadPlatformSetting();
            cmbConfig.Text = ConfigSettings.ReadConfigSetting();
            chTimer.Checked = ConfigSettings.ReadTimerSetting();
            
            if (edtCoreGit.Text.Length < 1)
                ConfigSettings.SetDefault(edtCoreGit, edtSD2Git, cmbPlaform, cmbConfig);
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string CompileTime = _hours.ToString() + "," + _min.ToString() + "," + _sec.ToString();

            this.DialogResult = DialogResult.Cancel;
            ConfigSettings.SaveSettings(edtCoreGit.Text, edtSD2Git.Text, "", cmbPlaform.Text, cmbConfig.Text, chTimer.Checked, CompileTime);

            if (edtCoreGit.Text.Length < 1)
                DisplayMessage("No Core github url as been given, will not clone. Continue?", MessageBoxIcon.Error);
            //else if (edtDatabaseGit.Text.Length < 1)
                //DisplayMessage("No Database github url as been given, will not clone. Continue?", MessageBoxIcon.Question);
            else if (edtSD2Git.Text.Length < 1)
                DisplayMessage("No SD2 github url as been given, will not clone. Continue?", MessageBoxIcon.Question);
            else if (cmbPlaform.Text.Length < 1)
                DisplayMessage("No platform has been given", MessageBoxIcon.Error);
            else if (cmbConfig.Text.Length < 1)
                DisplayMessage("No config has been given", MessageBoxIcon.Error);
            else
            {
                MessageBox.Show("Settings Saved", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }

            canClose = true;

        }

        private void DisplayMessage(string mgsMessage, MessageBoxIcon mgsIcon)
        {
            DialogResult result;
            result = MessageBox.Show(mgsMessage, "Settings", MessageBoxButtons.YesNo, mgsIcon);
            
            if (result == DialogResult.No)
                this.DialogResult = DialogResult.No;
        }

        private void frmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;

            if (!canClose)
            {
                result = MessageBox.Show("Want to close Appliaction?", "Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    canClose = true;
                    Application.Exit();
                }
                else
                    e.Cancel = true;
            }

        }

        private void frmSettings_Shown(object sender, EventArgs e)
        {
            LoadSettings();
            enable = true;
        }

        private void chTimer_CheckedChanged(object sender, EventArgs e)
        {
            DialogResult result;

            if (enable)
            {
                if (chTimer.Checked == true)
                {
                    result = MessageBox.Show("This will enable you to set interval for auto-compile\n  Continue?", "Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        frmTimer timerForm = new frmTimer();
                        timerForm.ShowDialog();

                        _hours = Convert.ToInt16(timerForm.edtHours.Text);
                        _min = Convert.ToInt16(timerForm.edtMin.Text);
                        _sec = Convert.ToInt16(timerForm.edtSec.Text);

                        enable = true;
                        chTimer.Checked = true;
                    }
                    else
                    {
                        enable = false;
                        chTimer.Checked = false;
                    }
                }
                else
                {
                    result = MessageBox.Show("This will disable you to set interval for auto-compile\n  Continue?", "Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        enable = true;
                        chTimer.Checked = false;
                    }
                    else
                    {
                        enable = false;
                        chTimer.Checked = true;
                    }
                }
            }
            else
                enable = true;
        }
    }
}
