using System;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace One_Click
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
            wc.DownloadFile("http://h1.ripway.com/Singlem/OneClick/version.txt", "version.txt");

            StreamReader sr = new StreamReader("version.txt");
            version = sr.ReadLine();

            if (Application.ProductVersion != version)
            {
                MessageBox.Show("Updating please wait");
                try
                {
                    File.Move(Application.StartupPath + "\\One_Click.exe", Application.StartupPath + "\\" + "prog.old");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update\n" + ex.ToString());
                }
                wc.DownloadFile("http://h1.ripway.com/Singlem/OneClick/One_Click.exe", "One_Click.exe");
                Application.Exit();
                Process.Start("One_Click.exe");
            }
#endif
        }
    }
}