using System;
using System.Windows.Forms;
using System.IO;
using One_Click.Properties;
using System.Text;
using System.ComponentModel;

namespace One_Click
{
    public enum GitTypes
    {
        Core,
        ScriptDev2,
        Database
    }

    public class CompileHandler
    {
        private static RichTextBox CompileRich;
        private static Button CompileButton;
        private static StringBuilder LogError;
        private static StringBuilder LogWarning;
        private static ISynchronizeInvoke MainForm;
        private static string Platform;
        private static string Config;

        public static void InitializeCompile(ISynchronizeInvoke _isi, RichTextBox _rtMain, Button _Compile)
        {
            CompileRich     = _rtMain;
            MainForm        = _isi;
            CompileButton   = _Compile;

            if (!Directory.Exists("Source"))
                Directory.CreateDirectory("Source");

            if (Settings.Default.CoreGit == "")
            {
                CompileRich.AppendText("Core will not compile\nReason: No Core git settings");
                CompileButton.Enabled = true;
                return;
            }

            if (!File.Exists("Source\\Core\\CMakeLists.txt"))
                CloneGit(GitTypes.Core);
            else
                PullGit(GitTypes.Core);

            if (!Directory.Exists("Database"))
                CloneGit(GitTypes.Database);
            else
                PullGit(GitTypes.Database);

        }

        private static void PullGit(GitTypes type)
        {
            ProcessCaller GitPull = new ProcessCaller(MainForm);
            GitPull.FileName = "apps\\git\\bin\\git.exe";

            switch ((GitTypes)type)
            {
                case GitTypes.Core:
                    GitPull.WorkingDirectory = "Source\\Core";
                    CompileRich.AppendText("Pulling Core Updates\n");
                    GitPull.Completed += new EventHandler(processCompleted);

                    if (Settings.Default.ScriptdevGit == "")
                        GitPull.Completed += new EventHandler(CompileCore);

                    break;
                case GitTypes.Database:
                    GitPull.WorkingDirectory = "Source\\Database";
                    CompileRich.AppendText("Pulling Databse Updates\n");
                    break;
                case GitTypes.ScriptDev2:
                    GitPull.WorkingDirectory = "Source\\Core\\src\\bindings\\ScriptDev2";
                    CompileRich.AppendText("Pulling scriptdev Updates\n");
                    GitPull.Completed += new EventHandler(CompileCore);
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
                    GitRepo = Settings.Default.CoreGit;
                    RepoName = "Core";
                    Git.Completed += new EventHandler(processCompleted);

                    if (Settings.Default.ScriptdevGit == "")
                        Git.Completed += new EventHandler(CompileCore);

                    CompileRich.AppendText("Cloning core\n");
                    break;
                case GitTypes.Database:
                    GitRepo = Settings.Default.DatabaseGit;
                    RepoName = "Database";
                    CompileRich.AppendText("Cloning database\n");
                    break;
                case GitTypes.ScriptDev2:
                    GitRepo = Settings.Default.ScriptdevGit;
                    RepoName = "ScriptDev2";
                    Git.WorkingDirectory = "Source\\Core\\src\\bindings";
                    Git.Completed += new EventHandler(CompileCore);
                    CompileRich.AppendText("Cloning Scriptdev\n");
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
                CompileRich.AppendText("Cloning failed on " + type.ToString() + "\n");
        }

        private static void processCompleted(object sender, EventArgs e)
        {
            if (!Directory.Exists("Source\\Core\\src\\bindings\\ScriptDev2"))
                CloneGit(GitTypes.ScriptDev2);
            else
                PullGit(GitTypes.ScriptDev2);
        }

        private static void CompileCore(object sender, EventArgs e)
        {
            ProcessCaller CoreCompile = new ProcessCaller(MainForm);
            CompileRich.Clear();
            CompileRich.AppendText("Core Compile started\n");
            CoreCompile.FileName = "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\MSBuild.exe";
            CoreCompile.Arguments = CompileArguments(GitTypes.Core);
            CoreCompile.StdOutReceived += new DataReceivedHandler(writeStreamInfoNormal);
            CoreCompile.StdErrReceived += new DataReceivedHandler(writeStreamInfoNormal);
            CoreCompile.Completed += new EventHandler(CompileSD2);
            CoreCompile.Start();
        }

        private static void CompileSD2(object sender, EventArgs e)
        {
            ProcessCaller SD2Compile = new ProcessCaller(MainForm);
            CompileRich.Clear();
            CompileRich.AppendText("Scriptdev Compile started\n");
            SD2Compile.FileName = "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\MSBuild.exe";
            SD2Compile.Arguments = CompileArguments(GitTypes.ScriptDev2);
            SD2Compile.StdOutReceived += new DataReceivedHandler(writeStreamInfoNormal);
            SD2Compile.StdErrReceived += new DataReceivedHandler(writeStreamInfoNormal);
            SD2Compile.Completed += new EventHandler(finalizeCompile);
            SD2Compile.Start();
        }

        private static void writeStreamInfoNormal(object sender, DataReceivedEventArgs e)
        {
            CompileRich.AppendText(e.Text + "\n");
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
            CompileButton.Enabled = true;
        }

        private static string CompileArguments(GitTypes GitType)
        {
            string slnFile;
            string buildtype;

            if (Settings.Default.ACPlatform == 0)
                Platform = "Win32";
            else
                Platform = "x64";

            if (Settings.Default.ACConfig == 0)
                Config = "Release";
            else
                Config = "Debug";

            if (GitType == GitTypes.Core)
            {
                if (File.Exists("Source\\Core\\win\\vc100\\ace__Win32_" + Config + "\\ACE.obj"))
                    buildtype = "build";
                else
                    buildtype = "rebuild";

                slnFile = "Source\\Core\\win\\mangosdVC100.sln";
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

        private static void MoveCoreFiles()
        {
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
        }
    }
}