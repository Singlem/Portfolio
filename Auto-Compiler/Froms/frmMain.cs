using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace Auto_Compiler
{
    public partial class frmMain : Form
    {
        bool allowTip = true;
        public static bool TimerRunning = false;
        public static string status = "";
        

        public static void SetStatus(string _status)
        {
            status = _status;
        }

        public frmMain()
        {
            Updater.CheckUpdate();
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.Text = "Auto-Compiler v" + Application.ProductVersion;
        }

        private void DisplaySettings()
        {
            frmSettings frmSetting = new frmSettings();
            DialogResult result = DialogResult.No;
            this.Hide();

            while (result == DialogResult.No)
            {
                result = frmSetting.ShowDialog();

                if (result == DialogResult.Cancel)
                    MessageBox.Show("Settings does not seem to be correct please make sure of settings");
            }

            ConfigurationManager.RefreshSection("appSettings");

            if (frmSetting.chTimer.Checked)
            {
                TimerRunning = true;
                lblTimer.Text = "Timer Enabled";
                lblTimer.ForeColor = Color.Green;
                TimerHandler.RunTimer(BtnCompileSLN);
            }
            else
            {
                lblTimer.Text = "Timer disenabled";
                lblTimer.ForeColor = Color.Red;
            }

            this.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DisplaySettings();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            DisplaySettings();
        }

        private void BtnCompileSLN_Click(object sender, EventArgs e)
        {
            if (TimerRunning)
                TimerHandler.StopTimer();

            redMain.Clear();
            GitHandler.InitializeGit(this, redMain, BtnCompileSLN);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle = "Auto-Compiler";
            notifyIcon1.BalloonTipText = "Double click to show";

            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
                notifyIcon1.Visible = false;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_BalloonTipShown(object sender, EventArgs e)
        {
            allowTip = false;
        }

        private void notifyIcon1_BalloonTipClosed(object sender, EventArgs e)
        {
            allowTip = true;
        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
            if (allowTip)
            {
                if (BtnCompileSLN.Enabled == true)
                    status = "Idle";

                notifyIcon1.BalloonTipText = "Auto-Compiler";
                notifyIcon1.BalloonTipText = status;
                notifyIcon1.ShowBalloonTip(1);
            }
        }
    }
}
