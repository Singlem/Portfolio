using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace Auto_Compiler
{
    public enum GitTypes
    {
        Core,
        Scriptdev2,
        Database
    }

    public enum PlatformTypes
    {
        win32,
        x64
    }

    public enum ConfigTypes
    {
        Release,
        Debug
    }

    public class GitHandler
    {
        private static ISynchronizeInvoke MainForm;
        private static RichTextBox MainRich;
        private static Button MainButton;

        public static void InitializeGit(ISynchronizeInvoke _isi, RichTextBox _rtMain, Button _btnCompile)
        {
            MainForm    = _isi;
            MainRich    = _rtMain;
            MainButton  = _btnCompile;

            MainButton.Enabled = false;

            if (!Directory.Exists("Source"))
                Directory.CreateDirectory("Source");

            if (ConfigSettings.ReadGitCoreSetting(GitTypes.Core) == string.Empty)
            {
                MainRich.AppendText("Core will not compile\nReason: No Core git settings");
                MainButton.Enabled = true;
                return;
            }

            if (!Directory.Exists("apps"))
            {
                MessageBox.Show("Could not find apps Directory, make sure in the folder", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists("Source\\Core"))
                CloneGit(GitTypes.Core);
            else
                PullGit(GitTypes.Core);

            /*if (!Directory.Exists("Database"))
                CloneGit(GitTypes.Database);
            else
                PullGit(GitTypes.Database);*/
        }

        private static void PullGit(GitTypes type)
        {
            ProcessCaller GitPull = new ProcessCaller(MainForm);
            GitPull.FileName = "apps\\git\\bin\\git.exe";

            switch ((GitTypes)type)
            {
                case GitTypes.Core:
                    GitPull.WorkingDirectory = "Source\\Core";
                    MainRich.AppendText("Pulling Core Updates\n");
                    frmMain.SetStatus("Pulling Core");

                    if (ConfigSettings.ReadGitCoreSetting(GitTypes.Scriptdev2) != string.Empty)
                        GitPull.Completed += new EventHandler(CanCloneSD2);
                    else
                        GitPull.Completed += new EventHandler(GitCompleted);
                        break;
                case GitTypes.Database:
                    GitPull.WorkingDirectory = "Source\\Database";
                    MainRich.AppendText("Pulling Databse Updates\n");
                    break;
                case GitTypes.Scriptdev2:
                    GitPull.WorkingDirectory = "Source\\Core\\src\\bindings\\ScriptDev2";
                    MainRich.AppendText("Pulling ScriptDev Updates\n");
                    frmMain.SetStatus("Pulling ScriptDev");
                    GitPull.Completed += new EventHandler(GitCompleted);
                    break;
            }

            GitPull.Arguments = "pull";
            GitPull.StdErrReceived += new DataReceivedHandler(writeStreamInfoNormal);
            GitPull.StdOutReceived += new DataReceivedHandler(writeStreamInfoNormal);
            GitPull.Start();
        }

        private static void CloneGit(GitTypes type)
        {
            ProcessCaller Git = new ProcessCaller(MainForm);
            Git.FileName = "apps\\git\\bin\\git.exe";
            Git.WorkingDirectory = "Source";

            string GitRepo = "";
            string RepoName = "";

            switch ((GitTypes)type)
            {
                case GitTypes.Core:
                    GitRepo = ConfigSettings.ReadGitCoreSetting(GitTypes.Core);
                    RepoName = "Core";

                    if (ConfigSettings.ReadGitCoreSetting(GitTypes.Scriptdev2) != string.Empty)
                        Git.Completed += new EventHandler(CanCloneSD2);
                    else
                        Git.Completed += new EventHandler(GitCompleted);

                    MainRich.AppendText("Cloning Core\n");
                    frmMain.SetStatus("Cloning Core");
                    break;
                case GitTypes.Database:
                    GitRepo = ConfigSettings.ReadGitCoreSetting(GitTypes.Database);
                    RepoName = "Database";
                    MainRich.AppendText("Cloning database\n");
                    break;
                case GitTypes.Scriptdev2:
                    GitRepo = ConfigSettings.ReadGitCoreSetting(GitTypes.Scriptdev2);
                    RepoName = "ScriptDev2";
                    Git.WorkingDirectory = "Source\\Core\\src\\bindings";
                    Git.Completed += new EventHandler(GitCompleted);
                    MainRich.AppendText("Cloning ScriptDev\n");
                    frmMain.SetStatus("Cloning ScriptDev");
                    break;
            }

            if (GitRepo != "")
            {

                Git.Arguments = "clone -b master " + GitRepo + " " + RepoName;
                Git.StdErrReceived += new DataReceivedHandler(writeStreamInfoNormal);
                Git.StdOutReceived += new DataReceivedHandler(writeStreamInfoNormal);
                Git.Start();
            }
            else
                MainRich.AppendText("Cloning failed on " + type.ToString() + "\n");
        }

        private static void CanCloneSD2(object sender, EventArgs e)
        {
            if (!Directory.Exists("Source\\Core\\src\\bindings"))
            {
                MessageBox.Show("Something went wrong with core git cloning/pulling", "ERROR" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                MainButton.Enabled = true;
                return;
            }

            if (!Directory.Exists("Source\\Core\\src\\bindings\\ScriptDev2"))
                CloneGit(GitTypes.Scriptdev2);
            else
                PullGit(GitTypes.Scriptdev2);
        }

        private static void GitCompleted(object sender, EventArgs e)
        {
            CompileHandler.InitializeCompile(MainForm, MainRich, MainButton);
        }

        private static void writeStreamInfoNormal(object sender, DataReceivedEventArgs e)
        {
            MainRich.AppendText(e.Text + "\n");
        }
    }

    public class CompileHandler
    {
        private static ISynchronizeInvoke MainForm;
        private static RichTextBox MainRich;
        private static Button MainButton;
        private static StringBuilder LogError;
        private static StringBuilder LogWarning;

        public static void InitializeCompile(ISynchronizeInvoke _isi, RichTextBox _rtMain, Button _btnCompile)
        {
            MainForm    = _isi;
            MainRich    = _rtMain;
            MainButton  = _btnCompile;

            CompileCore();
            frmMain.SetStatus("Compiling");
        }

        private static void CompileCore()
        {
            ProcessCaller CoreCompile = new ProcessCaller(MainForm);
            MainRich.Clear();
            MainRich.AppendText("Core Compile started\n");
            CoreCompile.FileName = "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\MSBuild.exe";
            CoreCompile.Arguments = CompileArguments(GitTypes.Core, false);
            CoreCompile.StdOutReceived += new DataReceivedHandler(writeStreamInfoNormal);
            CoreCompile.StdErrReceived += new DataReceivedHandler(writeStreamInfoNormal);
            CoreCompile.Completed += new EventHandler(CompileSD2);
            CoreCompile.Start();
        }

        private static void CompileSD2(object sender, EventArgs e)
        {
            ProcessCaller SD2Compile = new ProcessCaller(MainForm);
            MainRich.Clear();
            MainRich.AppendText("Scriptdev Compile started\n");
            SD2Compile.FileName = "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\MSBuild.exe";
            SD2Compile.Arguments = CompileArguments(GitTypes.Scriptdev2, false);
            SD2Compile.StdOutReceived += new DataReceivedHandler(writeStreamInfoNormal);
            SD2Compile.StdErrReceived += new DataReceivedHandler(writeStreamInfoNormal);
            SD2Compile.Completed += new EventHandler(finalizeCompile);
            SD2Compile.Start();
        }

        private static void BuildCmake()
        {
            ProcessCaller BuildCmake = new ProcessCaller(MainForm);
            MainRich.Clear();
            MainRich.AppendText("Building cmake\n");
            BuildCmake.FileName = "apps\\cmake\\bin\\cmake.exe";
            BuildCmake.Arguments = "cmake.exe -G\"Visual Studio 10\" -HSource\\Core -BSource\\cmake_core";
            BuildCmake.StdOutReceived += new DataReceivedHandler(writeStreamInfoNormal);
            BuildCmake.StdErrReceived += new DataReceivedHandler(writeStreamInfoNormal);
            BuildCmake.Completed += new EventHandler(CompileCmake);
            BuildCmake.Start();
        }

        private static void CompileCmake(object sender, EventArgs e)
        {
            ProcessCaller cmakeCompile = new ProcessCaller(MainForm);
            MainRich.Clear();
            MainRich.AppendText("Scriptdev Compile started\n");
            cmakeCompile.FileName = "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\MSBuild.exe";
            cmakeCompile.Arguments = CompileArguments(GitTypes.Core, true);
            cmakeCompile.StdOutReceived += new DataReceivedHandler(writeStreamInfoNormal);
            cmakeCompile.StdErrReceived += new DataReceivedHandler(writeStreamInfoNormal);
            cmakeCompile.Completed += new EventHandler(finalizeCompile);
            cmakeCompile.Start();
        }

        private static string CompileArguments(GitTypes GitType, bool cmake)
        {
            string slnFile;
            string buildtype;

            string Config = ConfigSettings.ReadConfigSetting();
            string Platform = ConfigSettings.ReadPlatformSetting();

            if (GitType == GitTypes.Core)
            {
                if (!cmake)
                {
                    if (File.Exists("Source\\Core\\win\\vc100\\ace__Win32_" + Config + "\\ACE.obj"))
                        buildtype = "build";
                    else
                        buildtype = "rebuild";

                    slnFile = "Source\\Core\\win\\mangosdVC100.sln";
                }
                else
                {
                    buildtype = "rebuild";
                    slnFile = "Source\\cmake_core\\MaNGOS.sln";
                }
            }
            else
            {
                if (File.Exists("Source\\Core\\src\\bindings\\ScriptDev2\\VC100\\ScriptDev2__Win32_" + Config + "\\trial_of_the_champion.obj"))
                    buildtype = "build";
                else
                    buildtype = "rebuild";

                slnFile = "Source\\Core\\src\\bindings\\ScriptDev2\\scriptVC100.sln";

            }

            LogError = new StringBuilder();
            LogWarning = new StringBuilder();

            LogError.AppendFormat("CompileErrors_{0}_{1}_{2}.log", Config, GitType.ToString(), Platform);
            LogWarning.AppendFormat("CompileWarnings_{0}_{1}_{2}.log", Config, GitType.ToString(), Platform);
            StringBuilder arg = new StringBuilder();
            arg.Append(slnFile);
            arg.AppendFormat(" /t:{0}", buildtype);
            arg.AppendFormat(" /p:Configuration={0};", Config);
            arg.AppendFormat("Platform={0}", Platform);
            arg.Append(" /flp1:logfile=" + LogError.ToString() + ";errorsonly");
            arg.Append(" /flp2:logfile=" + LogWarning.ToString() + ";warningsonly");

            return arg.ToString();
        }

        private static void finalizeCompile(object sender, EventArgs e)
        {
            if (!Directory.Exists("Logs"))
                Directory.CreateDirectory("Logs");
            else
            {
                Directory.Delete("Logs", true);
                Directory.CreateDirectory("Logs");
            }

            DirectoryInfo di = new DirectoryInfo(Application.StartupPath);

            FileInfo[] logFiles = di.GetFiles("*.log");
            foreach (FileInfo fi in logFiles)
            {
                fi.MoveTo("Logs\\" + fi.Name);
            }

            MoveCoreFiles();
            MainButton.Enabled = true;
            
            if (frmMain.TimerRunning)
                TimerHandler.StartTimer();
        }

        private static void MoveCoreFiles()
        {
            //TODO better file for server
            //maybe to server dir
            string Platform = ConfigSettings.ReadPlatformSetting();
            string Config = ConfigSettings.ReadConfigSetting();

            if (!Directory.Exists("BuiltCore"))
                Directory.CreateDirectory("BuiltCore");

            DirectoryInfo di = new DirectoryInfo(Application.StartupPath + @"\Source\Core\bin\" + Platform + "_" + Config);

            FileInfo[] DLLFiles = di.GetFiles("*.dll");
            foreach (FileInfo fi in DLLFiles)
            {
                fi.CopyTo("BuiltCore\\" + fi.Name, true);
            }

            FileInfo[] EXEFiles = di.GetFiles("*.exe");
            foreach (FileInfo fi in EXEFiles)
            {
                fi.CopyTo("BuiltCore\\" + fi.Name, true);
            }

            System.Diagnostics.Process.Start(Application.StartupPath + "\\BuiltCore\\");
        }

        private static void writeStreamInfoNormal(object sender, DataReceivedEventArgs e)
        {
            MainRich.AppendText(e.Text + "\n");
        }
    }
}