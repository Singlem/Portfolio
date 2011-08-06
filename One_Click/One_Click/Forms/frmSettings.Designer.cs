namespace One_Click
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._tPanel = new System.Windows.Forms.TabControl();
            this._tpServer = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this._bServerPath = new System.Windows.Forms.Button();
            this._tbRealmExe = new System.Windows.Forms.TextBox();
            this._tbWorldExe = new System.Windows.Forms.TextBox();
            this._tbServerPath = new System.Windows.Forms.TextBox();
            this._tpDatabase = new System.Windows.Forms.TabPage();
            this._tbScriptdevDB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this._tbRealmDB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this._tbCharDB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this._tbBase = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._bTestConnect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._tbUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._tbHost = new System.Windows.Forms.TextBox();
            this._tbPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._tpGit = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this._tbCoreGit = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this._tbScriptdevGit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._tbDatabaseGit = new System.Windows.Forms.TextBox();
            this._tpAC = new System.Windows.Forms.TabPage();
            this._bSaveAC = new System.Windows.Forms.Button();
            this._cbPlatform = new System.Windows.Forms.ComboBox();
            this._cbConfig = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this._tbPass = new System.Windows.Forms.TextBox();
            this._tPanel.SuspendLayout();
            this._tpServer.SuspendLayout();
            this._tpDatabase.SuspendLayout();
            this._tpGit.SuspendLayout();
            this._tpAC.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tPanel
            // 
            this._tPanel.Controls.Add(this._tpServer);
            this._tPanel.Controls.Add(this._tpDatabase);
            this._tPanel.Controls.Add(this._tpGit);
            this._tPanel.Controls.Add(this._tpAC);
            this._tPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tPanel.Location = new System.Drawing.Point(0, 0);
            this._tPanel.Name = "_tPanel";
            this._tPanel.SelectedIndex = 0;
            this._tPanel.Size = new System.Drawing.Size(284, 271);
            this._tPanel.TabIndex = 0;
            // 
            // _tpServer
            // 
            this._tpServer.BackgroundImage = global::One_Click.Properties.Resources.blacktemple1600x_2;
            this._tpServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._tpServer.Controls.Add(this.label16);
            this._tpServer.Controls.Add(this.label15);
            this._tpServer.Controls.Add(this.label14);
            this._tpServer.Controls.Add(this._bServerPath);
            this._tpServer.Controls.Add(this._tbRealmExe);
            this._tpServer.Controls.Add(this._tbWorldExe);
            this._tpServer.Controls.Add(this._tbServerPath);
            this._tpServer.Location = new System.Drawing.Point(4, 22);
            this._tpServer.Name = "_tpServer";
            this._tpServer.Size = new System.Drawing.Size(276, 245);
            this._tpServer.TabIndex = 3;
            this._tpServer.Text = "Server";
            this._tpServer.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Lime;
            this.label16.Location = new System.Drawing.Point(3, 109);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "Realm exe";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Lime;
            this.label15.Location = new System.Drawing.Point(3, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "World exe";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Lime;
            this.label14.Location = new System.Drawing.Point(3, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "ServerPath";
            // 
            // _bServerPath
            // 
            this._bServerPath.Location = new System.Drawing.Point(244, 14);
            this._bServerPath.Name = "_bServerPath";
            this._bServerPath.Size = new System.Drawing.Size(28, 23);
            this._bServerPath.TabIndex = 3;
            this._bServerPath.Text = "...";
            this._bServerPath.UseVisualStyleBackColor = true;
            this._bServerPath.Click += new System.EventHandler(this._bServerPath_Click);
            // 
            // _tbRealmExe
            // 
            this._tbRealmExe.Location = new System.Drawing.Point(69, 106);
            this._tbRealmExe.Name = "_tbRealmExe";
            this._tbRealmExe.Size = new System.Drawing.Size(169, 20);
            this._tbRealmExe.TabIndex = 2;
            // 
            // _tbWorldExe
            // 
            this._tbWorldExe.Location = new System.Drawing.Point(69, 60);
            this._tbWorldExe.Name = "_tbWorldExe";
            this._tbWorldExe.Size = new System.Drawing.Size(169, 20);
            this._tbWorldExe.TabIndex = 1;
            // 
            // _tbServerPath
            // 
            this._tbServerPath.Location = new System.Drawing.Point(69, 16);
            this._tbServerPath.Name = "_tbServerPath";
            this._tbServerPath.Size = new System.Drawing.Size(169, 20);
            this._tbServerPath.TabIndex = 0;
            // 
            // _tpDatabase
            // 
            this._tpDatabase.BackgroundImage = global::One_Click.Properties.Resources.blacktemple1600x_2;
            this._tpDatabase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._tpDatabase.Controls.Add(this._tbPass);
            this._tpDatabase.Controls.Add(this._tbScriptdevDB);
            this._tpDatabase.Controls.Add(this.label10);
            this._tpDatabase.Controls.Add(this._tbRealmDB);
            this._tpDatabase.Controls.Add(this.label9);
            this._tpDatabase.Controls.Add(this._tbCharDB);
            this._tpDatabase.Controls.Add(this.label8);
            this._tpDatabase.Controls.Add(this._tbBase);
            this._tpDatabase.Controls.Add(this.label5);
            this._tpDatabase.Controls.Add(this._bTestConnect);
            this._tpDatabase.Controls.Add(this.label4);
            this._tpDatabase.Controls.Add(this.label3);
            this._tpDatabase.Controls.Add(this._tbUser);
            this._tpDatabase.Controls.Add(this.label1);
            this._tpDatabase.Controls.Add(this._tbHost);
            this._tpDatabase.Controls.Add(this._tbPort);
            this._tpDatabase.Controls.Add(this.label2);
            this._tpDatabase.Location = new System.Drawing.Point(4, 22);
            this._tpDatabase.Name = "_tpDatabase";
            this._tpDatabase.Size = new System.Drawing.Size(276, 245);
            this._tpDatabase.TabIndex = 0;
            this._tpDatabase.Text = "Database";
            this._tpDatabase.UseVisualStyleBackColor = true;
            // 
            // _tbScriptdevDB
            // 
            this._tbScriptdevDB.Location = new System.Drawing.Point(114, 159);
            this._tbScriptdevDB.Name = "_tbScriptdevDB";
            this._tbScriptdevDB.Size = new System.Drawing.Size(152, 20);
            this._tbScriptdevDB.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Lime;
            this.label10.Location = new System.Drawing.Point(41, 162);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "ScriptdevDB";
            // 
            // _tbRealmDB
            // 
            this._tbRealmDB.Location = new System.Drawing.Point(114, 133);
            this._tbRealmDB.Name = "_tbRealmDB";
            this._tbRealmDB.Size = new System.Drawing.Size(152, 20);
            this._tbRealmDB.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Lime;
            this.label9.Location = new System.Drawing.Point(41, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "RealmDB";
            // 
            // _tbCharDB
            // 
            this._tbCharDB.Location = new System.Drawing.Point(114, 107);
            this._tbCharDB.Name = "_tbCharDB";
            this._tbCharDB.Size = new System.Drawing.Size(152, 20);
            this._tbCharDB.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Lime;
            this.label8.Location = new System.Drawing.Point(41, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Char DB";
            // 
            // _tbBase
            // 
            this._tbBase.Location = new System.Drawing.Point(114, 81);
            this._tbBase.Name = "_tbBase";
            this._tbBase.Size = new System.Drawing.Size(152, 20);
            this._tbBase.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Lime;
            this.label5.Location = new System.Drawing.Point(41, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "world DB";
            // 
            // _bTestConnect
            // 
            this._bTestConnect.Location = new System.Drawing.Point(92, 211);
            this._bTestConnect.Name = "_bTestConnect";
            this._bTestConnect.Size = new System.Drawing.Size(95, 23);
            this._bTestConnect.TabIndex = 8;
            this._bTestConnect.Text = "Test";
            this._bTestConnect.UseVisualStyleBackColor = true;
            this._bTestConnect.Click += new System.EventHandler(this._bTestConnect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Lime;
            this.label4.Location = new System.Drawing.Point(41, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Pass";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(41, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "User";
            // 
            // _tbUser
            // 
            this._tbUser.Location = new System.Drawing.Point(114, 29);
            this._tbUser.Name = "_tbUser";
            this._tbUser.Size = new System.Drawing.Size(152, 20);
            this._tbUser.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(41, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host";
            // 
            // _tbHost
            // 
            this._tbHost.Location = new System.Drawing.Point(114, 3);
            this._tbHost.Name = "_tbHost";
            this._tbHost.Size = new System.Drawing.Size(152, 20);
            this._tbHost.TabIndex = 0;
            // 
            // _tbPort
            // 
            this._tbPort.Location = new System.Drawing.Point(114, 185);
            this._tbPort.Name = "_tbPort";
            this._tbPort.Size = new System.Drawing.Size(152, 20);
            this._tbPort.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(41, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Port";
            // 
            // _tpGit
            // 
            this._tpGit.BackgroundImage = global::One_Click.Properties.Resources.blacktemple1600x_2;
            this._tpGit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._tpGit.Controls.Add(this.label12);
            this._tpGit.Controls.Add(this._tbCoreGit);
            this._tpGit.Controls.Add(this.label11);
            this._tpGit.Controls.Add(this._tbScriptdevGit);
            this._tpGit.Controls.Add(this.label6);
            this._tpGit.Controls.Add(this._tbDatabaseGit);
            this._tpGit.Location = new System.Drawing.Point(4, 22);
            this._tpGit.Name = "_tpGit";
            this._tpGit.Size = new System.Drawing.Size(276, 245);
            this._tpGit.TabIndex = 1;
            this._tpGit.Text = "Git";
            this._tpGit.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Lime;
            this.label12.Location = new System.Drawing.Point(26, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Core";
            // 
            // _tbCoreGit
            // 
            this._tbCoreGit.Location = new System.Drawing.Point(99, 21);
            this._tbCoreGit.Name = "_tbCoreGit";
            this._tbCoreGit.Size = new System.Drawing.Size(152, 20);
            this._tbCoreGit.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Lime;
            this.label11.Location = new System.Drawing.Point(26, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Database";
            // 
            // _tbScriptdevGit
            // 
            this._tbScriptdevGit.Location = new System.Drawing.Point(99, 47);
            this._tbScriptdevGit.Name = "_tbScriptdevGit";
            this._tbScriptdevGit.Size = new System.Drawing.Size(152, 20);
            this._tbScriptdevGit.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Lime;
            this.label6.Location = new System.Drawing.Point(26, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Scriptdev";
            // 
            // _tbDatabaseGit
            // 
            this._tbDatabaseGit.Location = new System.Drawing.Point(99, 73);
            this._tbDatabaseGit.Name = "_tbDatabaseGit";
            this._tbDatabaseGit.Size = new System.Drawing.Size(152, 20);
            this._tbDatabaseGit.TabIndex = 2;
            // 
            // _tpAC
            // 
            this._tpAC.BackgroundImage = global::One_Click.Properties.Resources.blacktemple1600x_2;
            this._tpAC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._tpAC.Controls.Add(this._bSaveAC);
            this._tpAC.Controls.Add(this._cbPlatform);
            this._tpAC.Controls.Add(this._cbConfig);
            this._tpAC.Controls.Add(this.label13);
            this._tpAC.Controls.Add(this.label7);
            this._tpAC.Location = new System.Drawing.Point(4, 22);
            this._tpAC.Name = "_tpAC";
            this._tpAC.Size = new System.Drawing.Size(276, 245);
            this._tpAC.TabIndex = 2;
            this._tpAC.Text = "AC";
            this._tpAC.UseVisualStyleBackColor = true;
            // 
            // _bSaveAC
            // 
            this._bSaveAC.Location = new System.Drawing.Point(95, 148);
            this._bSaveAC.Name = "_bSaveAC";
            this._bSaveAC.Size = new System.Drawing.Size(75, 23);
            this._bSaveAC.TabIndex = 4;
            this._bSaveAC.Text = "Save";
            this._bSaveAC.UseVisualStyleBackColor = true;
            this._bSaveAC.Click += new System.EventHandler(this._bSaveAC_Click);
            // 
            // _cbPlatform
            // 
            this._cbPlatform.FormattingEnabled = true;
            this._cbPlatform.Items.AddRange(new object[] {
            "win32",
            "x64"});
            this._cbPlatform.Location = new System.Drawing.Point(84, 55);
            this._cbPlatform.Name = "_cbPlatform";
            this._cbPlatform.Size = new System.Drawing.Size(121, 21);
            this._cbPlatform.TabIndex = 3;
            // 
            // _cbConfig
            // 
            this._cbConfig.FormattingEnabled = true;
            this._cbConfig.Items.AddRange(new object[] {
            "Release",
            "Debug"});
            this._cbConfig.Location = new System.Drawing.Point(84, 94);
            this._cbConfig.Name = "_cbConfig";
            this._cbConfig.Size = new System.Drawing.Size(121, 21);
            this._cbConfig.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Lime;
            this.label13.Location = new System.Drawing.Point(33, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Config";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Lime;
            this.label7.Location = new System.Drawing.Point(33, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Platform";
            // 
            // _tbPass
            // 
            this._tbPass.Location = new System.Drawing.Point(114, 55);
            this._tbPass.Name = "_tbPass";
            this._tbPass.Size = new System.Drawing.Size(152, 20);
            this._tbPass.TabIndex = 15;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 271);
            this.Controls.Add(this._tPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSettings_FormClosing);
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this._tPanel.ResumeLayout(false);
            this._tpServer.ResumeLayout(false);
            this._tpServer.PerformLayout();
            this._tpDatabase.ResumeLayout(false);
            this._tpDatabase.PerformLayout();
            this._tpGit.ResumeLayout(false);
            this._tpGit.PerformLayout();
            this._tpAC.ResumeLayout(false);
            this._tpAC.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _tPanel;
        private System.Windows.Forms.TabPage _tpDatabase;
        private System.Windows.Forms.TabPage _tpGit;
        private System.Windows.Forms.TabPage _tpAC;
        private System.Windows.Forms.TextBox _tbBase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _tbUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _tbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _tbHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _bTestConnect;
        private System.Windows.Forms.TextBox _tbRealmDB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox _tbCharDB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _tbScriptdevDB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox _tbCoreGit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox _tbScriptdevGit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _tbDatabaseGit;
        private System.Windows.Forms.ComboBox _cbPlatform;
        private System.Windows.Forms.ComboBox _cbConfig;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button _bSaveAC;
        private System.Windows.Forms.TabPage _tpServer;
        private System.Windows.Forms.TextBox _tbRealmExe;
        private System.Windows.Forms.TextBox _tbWorldExe;
        private System.Windows.Forms.TextBox _tbServerPath;
        private System.Windows.Forms.Button _bServerPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox _tbPass;

    }
}