using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using One_Click.Properties;

namespace One_Click
{
    public class ServerHandler
    {
        private static Unrar unrar;

        public static void ProcessCheck(Label _lWorld, Label _lRealm, Button _bStart, Button _bStop, Button _bRestart)
        {
            bool WorldRunning = ProcessHandler.IsRunning(Settings.Default.WordExe);
            bool RealmRunning = ProcessHandler.IsRunning(Settings.Default.RealmExe);

            if (WorldRunning)
            {
                _lWorld.Text = "ONLINE";
                _lWorld.ForeColor = Color.Lime;
            }
            else
            {
                _lWorld.Text = "OFFLINE";
                _lWorld.ForeColor = Color.Red;
            }

            if (RealmRunning)
            {
                _lRealm.Text = "ONLINE";
                _lRealm.ForeColor = Color.Lime;
            }
            else
            {
                _lRealm.Text = "OFFLINE";
                _lRealm.ForeColor = Color.Red;
            }

            if (!RealmRunning || !WorldRunning)
                StatusHandler.ButtonHandler(_bStart, _bStop, _bRestart, ButtonEvent.Offline);
        }
        
        public static string[] OnlineStatus()
        {
            string[] Result = new string[4];
            Result[0] = MySQLConnenct.StatusQuery("SELECT COUNT(*) FROM account;", Database.Realm).ToString();
            Result[1] = MySQLConnenct.StatusQuery("SELECT COUNT(*) FROM account WHERE active_realm_id=1;", Database.Realm).ToString();
            Result[2] = MySQLConnenct.StatusQuery("SELECT COUNT(*) FROM account WHERE active_realm_id=1 AND gmlevel > 2;", Database.Realm).ToString();
            Result[3] = MySQLConnenct.StatusQuery("SELECT COUNT(*) FROM characters;", Database.Characters).ToString();
            return Result;
        }

        public static void UnZip()
        {
            unrar = new Unrar();
            string pathTo = "";
            string pathfrom = "apps.rar";

            unrar.DestinationPath = pathTo;
            unrar.Open(pathfrom, Unrar.OpenMode.Extract);

            while (unrar.ReadHeader())
                unrar.Extract();

            if (unrar != null)
                unrar.Close();

            File.Delete("apps.rar");
        }
    }

    public class ProcessHandler
    {
        public static RichTextBox ErrorRich;
        public static RichTextBox NormalRich;

        public static void StartServer(ProcessCaller _MangosProcess, ProcessCaller _RealmProcess, string _worldExe, string _realmExe, RichTextBox _Normal, RichTextBox _Error)
        {
            _Error.Clear();
            _Normal.Clear();
            _Normal.Focus();
            ErrorRich = _Error;
            NormalRich = _Normal;

            //World
            _MangosProcess.FileName = Settings.Default.ServerPath + "\\" + _worldExe;
            _MangosProcess.WorkingDirectory = Settings.Default.ServerPath + "\\";
            _MangosProcess.StdErrReceived += new DataReceivedHandler(writeStreamInfoError);
            _MangosProcess.StdOutReceived += new DataReceivedHandler(writeStreamInfoNormal);

            if (IsRunning(_worldExe))
                KillProcess(_worldExe);

            _MangosProcess.Start();

            //Realm
            _RealmProcess.FileName = Settings.Default.ServerPath + "\\" + _realmExe;
            _RealmProcess.WorkingDirectory = Settings.Default.ServerPath + "\\";
            _RealmProcess.StdErrReceived += new DataReceivedHandler(writeStreamInfoError);
            _RealmProcess.StdOutReceived += new DataReceivedHandler(writeStreamInfoNormal);

            if (IsRunning(_realmExe))
                KillProcess(_realmExe);

            _RealmProcess.Start();
        }
        
        private static void writeStreamInfoError(object sender, DataReceivedEventArgs e)
        {
            if (e.Text.Contains("%") || e.Text.Length < 2 && e.Text != "")
                return;

            ErrorRich.AppendText(e.Text + "\n");
        }
        
        private static void writeStreamInfoNormal(object sender, DataReceivedEventArgs e)
        {
            if (e.Text.Contains("%") || e.Text.Length < 2 && e.Text != "")
                return;

            NormalRich.AppendText(e.Text + "\n");
        }

        private static bool KillProcess(string name)
        {
            name = name.Remove(name.IndexOf("."), 4);

            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.StartsWith(name))
                {
                    clsProcess.Kill();
                    return true;
                }
            }
            return false;
        }
        
        public static void StopServer(string _worldExe, string _realmExe)
        {
            KillProcess(_worldExe);
            KillProcess(_realmExe);
        }
        
        public static bool IsRunning(string name)
        {
            if (name == null)
                return false;

            name = name.Remove(name.IndexOf("."), 4);

            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                    return true;
            }
            return false;
        }
        
    }
}