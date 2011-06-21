using System;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Auto_Compiler
{
    public static class Updater
    {
        public static void CheckUpdate()
        {
#if !DEBUG
            WebClient wc = new WebClient();
            if (File.Exists("prog.old"))
                File.Delete("prog.old");

            string version = null;
            wc.DownloadFile("http://h1.ripway.com/Singlem/Auto-Compiler/version.txt ", "version.txt");

            StreamReader sr = new StreamReader("version.txt");
            version = sr.ReadLine();

            if (Application.ProductVersion != version)
            {
                MessageBox.Show("Updating please wait");
                try
                {
                    File.Move(Application.StartupPath + "\\Auto-Compiler.exe", Application.StartupPath + "\\" + "prog.old");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update\n" + ex.ToString());
                }
                wc.DownloadFile("http://h1.ripway.com/Singlem/Auto-Compiler/Auto-Compiler.exe", "Auto-Compiler.exe");
                Application.Exit();
                Process.Start("Auto-Compiler.exe");
            }
#endif
        }
    }
}