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
using System.Threading;
using System.Timers;
using System.Diagnostics;

namespace One_Click
{
    public partial class frmMain : Form
    {
        private ProcessCaller MangosProcessCaller;
        private ProcessCaller RealmdProcessCaller;
        bool allowTip = true;
        public string ServerPath;
        public string WorldExe;
        public string RealmExe;
        public delegate void UpdateUIThread(string[] Status);

        System.Timers.Timer StatusTimer = new System.Timers.Timer(5000);

        private void CreateProcesses()
        {
            MangosProcessCaller = new ProcessCaller(this);
            RealmdProcessCaller = new ProcessCaller(this);
        }

        private void LoadSettings()
        {
            ServerPath = Settings.Default.ServerPath;

            if (ServerPath == string.Empty)
            {
                ServerPath = Application.StartupPath + @"\MaNGOS";
                Settings.Default.ServerPath = ServerPath;
                Settings.Default.Save();
            }

            WorldExe = Settings.Default.WordExe;
            RealmExe = Settings.Default.RealmExe;
        }

        public frmMain()
        {
            Updater.CheckUpdate();
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.Text = "One-Click v" + Application.ProductVersion;
            StatusHandler.ButtonHandler(_bStart, _bStop, _bRestart, ButtonEvent.Offline);

            StatusTimer.Elapsed += new ElapsedEventHandler(OnTimerEvent);
            LoadSettings();
            CreateProcesses();

            if (File.Exists("apps.rar"))
            {
                frmUnZipDialog frmUnZip = new frmUnZipDialog();
                frmUnZip.ShowDialog();
            }

            if (MySQLConnenct.IsConnected)
                StatusTimer.Start();
            else
            {
                Process.Start("mysql\\Start.bat");
                settingsToolStripMenuItem.PerformClick();
            }
        }

        public void OnTimerEvent(object source, ElapsedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(DoWork));
            t.Name = "StatusTimer";
            t.Start();
        }

        private void UpdateUI(string[] status)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateUIThread(UpdateUI), new object[] { status });
            }
            else
            {
                lTotalAccounts.Text = status[0];
                lCharOnline.Text    = status[1];
                lGMOnline.Text      = status[2];
                lTotalChar.Text     = status[3];
                ServerHandler.ProcessCheck(lWorld, lRealm, _bStart, _bStop, _bRestart);
            }
        }

        private void DoWork()
        {
            string[] StatusResult;
            StatusTimer.Stop();
            StatusResult = ServerHandler.OnlineStatus();
            UpdateUI(StatusResult);
            StatusTimer.Start();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings frmSettings = new frmSettings();
            frmSettings.ShowDialog(this);
        }

        private void _bAccount_Click(object sender, EventArgs e)
        {
            if (MySQLConnenct.IsConnected)
            {
                frmAccount frmAccount = new frmAccount();
                frmAccount.ShowDialog(this);
            }
            else
                MessageBox.Show("Not connected to database, please check settings");
        }

        private void _bStart_Click(object sender, EventArgs e)
        {
            LoadSettings();
            if (!File.Exists(ServerPath + "\\" + WorldExe) || !File.Exists(ServerPath + "\\" + RealmExe))
            {
                MessageBox.Show("Could not find the server exe files");
                return;
            }

            if (!MySQLConnenct.IsConnected)
                Process.Start("mysql\\Start.bat");

            if (!StatusTimer.Enabled && MySQLConnenct.IsConnected)
                StatusTimer.Start();

            ProcessHandler.StartServer(MangosProcessCaller, RealmdProcessCaller, WorldExe, RealmExe, _rtProcessNormal, _rtProcessError);
            StatusHandler.ButtonHandler(_bStart, _bStop, _bRestart, ButtonEvent.Online);
        }

        private void _bClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void _bStop_Click(object sender, EventArgs e)
        {
            ProcessHandler.StopServer(WorldExe, RealmExe);
            StatusHandler.ButtonHandler(_bStart, _bStop, _bRestart, ButtonEvent.Offline);
            CreateProcesses();
            _rtProcessNormal.Clear();
            _rtProcessError.Clear();
        }

        private void _bRestart_Click(object sender, EventArgs e)
        {
            ProcessHandler.StopServer(WorldExe, RealmExe);
            ProcessHandler.StartServer(MangosProcessCaller, RealmdProcessCaller, WorldExe, RealmExe, _rtProcessNormal, _rtProcessError);
            StatusHandler.ButtonHandler(_bStart, _bStop, _bRestart, ButtonEvent.Online);
        }

        private void _bCompile_Click(object sender, EventArgs e)
        {
            _bCompile.Enabled = false;
            CompileHandler.InitializeCompile(this, _rtCompile, _bCompile);
        }

        private void _compileCmake_Click(object sender, EventArgs e)
        {
            _bCompile.Enabled = false;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;

            if (ProcessHandler.IsRunning(WorldExe) || ProcessHandler.IsRunning(RealmExe))
            {
                result = MessageBox.Show("Server is still running.\nDo you want to close and stop server?","Close",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    e.Cancel = true;
            }

            if (StatusTimer.Enabled)
                StatusTimer.Enabled = false;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle = "OneClick";
            notifyIcon1.BalloonTipText = "Double click to show";

            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
            if (allowTip)
            {
                StringBuilder Status = new StringBuilder();
                Status.AppendLine("Char Online: " + lCharOnline.Text);
                Status.AppendLine("GM Online: " + lGMOnline.Text);
                Status.AppendLine("Total Char: " + lTotalChar.Text);
                Status.AppendLine("Total Account: " + lTotalAccounts.Text);

                notifyIcon1.BalloonTipTitle = "OneClick";
                notifyIcon1.BalloonTipText = Status.ToString();
                notifyIcon1.ShowBalloonTip(1);
            }
        }

        private void notifyIcon1_BalloonTipShown(object sender, EventArgs e)
        {
            allowTip = false;
        }

        private void notifyIcon1_BalloonTipClosed(object sender, EventArgs e)
        {
            allowTip = true;
        }
    }
}
