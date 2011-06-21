using System;
using System.Configuration;
using System.Windows.Forms;

namespace Auto_Compiler
{
    public class ConfigSettings
    {
        public static string ReadGitCoreSetting(GitTypes type)
        {
            switch ((GitTypes)type)
            {
                case GitTypes.Core:
                    return ConfigurationManager.AppSettings["CoreGit"];
                case GitTypes.Scriptdev2:
                    return ConfigurationManager.AppSettings["SD2Git"];
                case GitTypes.Database:
                    return ConfigurationManager.AppSettings["DatabaseGit"];
                default: return string.Empty;
            }
        }

        public static bool ReadTimerSetting()
        {
            return Convert.ToBoolean(ConfigurationManager.AppSettings["TimerEnable"]);
        }

        public static string ReadTimer()
        {
            return ConfigurationManager.AppSettings["CompileTime"];
        }

        public static string ReadPlatformSetting()
        {
            return ConfigurationManager.AppSettings["ACplatform"];
        }

        public static string ReadConfigSetting()
        {
            return ConfigurationManager.AppSettings["ACconfig"];
        }

        public static void SaveSettings(string _coreGit, string _sd2Git, string _dbGit, string _platform, string _config, bool compile, string _compiletime)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings.Clear();
            config.AppSettings.Settings.Add("CoreGit", _coreGit);
            config.AppSettings.Settings.Add("SD2Git", _sd2Git);
            config.AppSettings.Settings.Add("DatabaseGit", _dbGit);
            config.AppSettings.Settings.Add("ACplatform", _platform);
            config.AppSettings.Settings.Add("ACconfig", _config);
            config.AppSettings.Settings.Add("TimerEnable", compile.ToString());
            config.AppSettings.Settings.Add("CompileTime", _compiletime);
            config.Save(ConfigurationSaveMode.Modified);
        }

        public static void SetDefault(TextBox _core, TextBox _sd, ComboBox _platform, ComboBox _config)
        {
            _core.Text = "http://github.com/mangos/mangos.git";
            _sd.Text = "http://github.com/scriptdev2/scriptdev2.git";
            _platform.Text = "win32";
            _config.Text = "Release";
        }
    }
}