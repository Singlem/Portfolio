namespace One_Click
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMain = new System.Windows.Forms.TabControl();
            this._tpHandler = new System.Windows.Forms.TabPage();
            this.lTotalAccounts = new System.Windows.Forms.Label();
            this.lTotalChar = new System.Windows.Forms.Label();
            this._pProcessNormal = new System.Windows.Forms.TabControl();
            this._tpNormal = new System.Windows.Forms.TabPage();
            this._rtProcessNormal = new System.Windows.Forms.RichTextBox();
            this._tpError = new System.Windows.Forms.TabPage();
            this._rtProcessError = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lGMOnline = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lCharOnline = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lRealm = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lWorld = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._pButtons = new System.Windows.Forms.Panel();
            this._bClose = new System.Windows.Forms.Button();
            this._bRestart = new System.Windows.Forms.Button();
            this._bAccount = new System.Windows.Forms.Button();
            this._bStop = new System.Windows.Forms.Button();
            this._bStart = new System.Windows.Forms.Button();
            this._tpAC = new System.Windows.Forms.TabPage();
            this._rtCompile = new System.Windows.Forms.RichTextBox();
            this._bCompile = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.pMain.SuspendLayout();
            this._tpHandler.SuspendLayout();
            this._pProcessNormal.SuspendLayout();
            this._tpNormal.SuspendLayout();
            this._tpError.SuspendLayout();
            this._pButtons.SuspendLayout();
            this._tpAC.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImage = global::One_Click.Properties.Resources.nerbian_entrance;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(614, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Lime;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.ForeColor = System.Drawing.Color.Lime;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this._bClose_Click);
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.optionToolStripMenuItem.ForeColor = System.Drawing.Color.Lime;
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionToolStripMenuItem.Text = "O&ption";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.Lime;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "S&ettings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // pMain
            // 
            this.pMain.Controls.Add(this._tpHandler);
            this.pMain.Controls.Add(this._tpAC);
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pMain.Location = new System.Drawing.Point(0, 24);
            this.pMain.Name = "pMain";
            this.pMain.SelectedIndex = 0;
            this.pMain.Size = new System.Drawing.Size(614, 388);
            this.pMain.TabIndex = 1;
            // 
            // _tpHandler
            // 
            this._tpHandler.BackgroundImage = global::One_Click.Properties.Resources.wow2_1113304c;
            this._tpHandler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._tpHandler.Controls.Add(this.lTotalAccounts);
            this._tpHandler.Controls.Add(this.lTotalChar);
            this._tpHandler.Controls.Add(this._pProcessNormal);
            this._tpHandler.Controls.Add(this.label5);
            this._tpHandler.Controls.Add(this.label8);
            this._tpHandler.Controls.Add(this.lGMOnline);
            this._tpHandler.Controls.Add(this.label4);
            this._tpHandler.Controls.Add(this.lCharOnline);
            this._tpHandler.Controls.Add(this.label6);
            this._tpHandler.Controls.Add(this.lRealm);
            this._tpHandler.Controls.Add(this.label3);
            this._tpHandler.Controls.Add(this.lWorld);
            this._tpHandler.Controls.Add(this.label1);
            this._tpHandler.Controls.Add(this._pButtons);
            this._tpHandler.Location = new System.Drawing.Point(4, 22);
            this._tpHandler.Name = "_tpHandler";
            this._tpHandler.Size = new System.Drawing.Size(606, 362);
            this._tpHandler.TabIndex = 0;
            this._tpHandler.Text = "Server";
            this._tpHandler.UseVisualStyleBackColor = true;
            // 
            // lTotalAccounts
            // 
            this.lTotalAccounts.AutoSize = true;
            this.lTotalAccounts.ForeColor = System.Drawing.Color.Lime;
            this.lTotalAccounts.Location = new System.Drawing.Point(358, 35);
            this.lTotalAccounts.Name = "lTotalAccounts";
            this.lTotalAccounts.Size = new System.Drawing.Size(13, 13);
            this.lTotalAccounts.TabIndex = 15;
            this.lTotalAccounts.Text = "0";
            // 
            // lTotalChar
            // 
            this.lTotalChar.AutoSize = true;
            this.lTotalChar.ForeColor = System.Drawing.Color.Lime;
            this.lTotalChar.Location = new System.Drawing.Point(358, 10);
            this.lTotalChar.Name = "lTotalChar";
            this.lTotalChar.Size = new System.Drawing.Size(13, 13);
            this.lTotalChar.TabIndex = 2;
            this.lTotalChar.Text = "0";
            // 
            // _pProcessNormal
            // 
            this._pProcessNormal.Controls.Add(this._tpNormal);
            this._pProcessNormal.Controls.Add(this._tpError);
            this._pProcessNormal.Location = new System.Drawing.Point(135, 56);
            this._pProcessNormal.Name = "_pProcessNormal";
            this._pProcessNormal.SelectedIndex = 0;
            this._pProcessNormal.ShowToolTips = true;
            this._pProcessNormal.Size = new System.Drawing.Size(463, 300);
            this._pProcessNormal.TabIndex = 14;
            // 
            // _tpNormal
            // 
            this._tpNormal.Controls.Add(this._rtProcessNormal);
            this._tpNormal.Location = new System.Drawing.Point(4, 22);
            this._tpNormal.Name = "_tpNormal";
            this._tpNormal.Size = new System.Drawing.Size(455, 274);
            this._tpNormal.TabIndex = 0;
            this._tpNormal.Text = "Normal";
            this._tpNormal.UseVisualStyleBackColor = true;
            // 
            // _rtProcessNormal
            // 
            this._rtProcessNormal.BackColor = System.Drawing.SystemColors.MenuText;
            this._rtProcessNormal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._rtProcessNormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rtProcessNormal.ForeColor = System.Drawing.Color.Lime;
            this._rtProcessNormal.Location = new System.Drawing.Point(0, 0);
            this._rtProcessNormal.Name = "_rtProcessNormal";
            this._rtProcessNormal.ReadOnly = true;
            this._rtProcessNormal.Size = new System.Drawing.Size(455, 274);
            this._rtProcessNormal.TabIndex = 1;
            this._rtProcessNormal.Text = "";
            // 
            // _tpError
            // 
            this._tpError.Controls.Add(this._rtProcessError);
            this._tpError.Location = new System.Drawing.Point(4, 22);
            this._tpError.Name = "_tpError";
            this._tpError.Size = new System.Drawing.Size(455, 274);
            this._tpError.TabIndex = 1;
            this._tpError.Text = "Error";
            this._tpError.UseVisualStyleBackColor = true;
            // 
            // _rtProcessError
            // 
            this._rtProcessError.BackColor = System.Drawing.SystemColors.MenuText;
            this._rtProcessError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._rtProcessError.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rtProcessError.ForeColor = System.Drawing.Color.Red;
            this._rtProcessError.Location = new System.Drawing.Point(0, 0);
            this._rtProcessError.Name = "_rtProcessError";
            this._rtProcessError.ReadOnly = true;
            this._rtProcessError.Size = new System.Drawing.Size(455, 274);
            this._rtProcessError.TabIndex = 0;
            this._rtProcessError.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(264, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Total Accounts  :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(264, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Total Characters:";
            // 
            // lGMOnline
            // 
            this.lGMOnline.AutoSize = true;
            this.lGMOnline.ForeColor = System.Drawing.Color.Lime;
            this.lGMOnline.Location = new System.Drawing.Point(227, 35);
            this.lGMOnline.Name = "lGMOnline";
            this.lGMOnline.Size = new System.Drawing.Size(13, 13);
            this.lGMOnline.TabIndex = 9;
            this.lGMOnline.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(132, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "GM\'s Online  :";
            // 
            // lCharOnline
            // 
            this.lCharOnline.AutoSize = true;
            this.lCharOnline.ForeColor = System.Drawing.Color.Lime;
            this.lCharOnline.Location = new System.Drawing.Point(227, 10);
            this.lCharOnline.Name = "lCharOnline";
            this.lCharOnline.Size = new System.Drawing.Size(13, 13);
            this.lCharOnline.TabIndex = 7;
            this.lCharOnline.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(132, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Characters Online:";
            // 
            // lRealm
            // 
            this.lRealm.AutoSize = true;
            this.lRealm.ForeColor = System.Drawing.Color.Red;
            this.lRealm.Location = new System.Drawing.Point(54, 35);
            this.lRealm.Name = "lRealm";
            this.lRealm.Size = new System.Drawing.Size(51, 13);
            this.lRealm.TabIndex = 5;
            this.lRealm.Text = "OFFLINE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Realm:";
            // 
            // lWorld
            // 
            this.lWorld.AutoSize = true;
            this.lWorld.ForeColor = System.Drawing.Color.Red;
            this.lWorld.Location = new System.Drawing.Point(54, 10);
            this.lWorld.Name = "lWorld";
            this.lWorld.Size = new System.Drawing.Size(51, 13);
            this.lWorld.TabIndex = 3;
            this.lWorld.Text = "OFFLINE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "World:";
            // 
            // _pButtons
            // 
            this._pButtons.BackColor = System.Drawing.Color.Transparent;
            this._pButtons.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_pButtons.BackgroundImage")));
            this._pButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._pButtons.Controls.Add(this._bClose);
            this._pButtons.Controls.Add(this._bRestart);
            this._pButtons.Controls.Add(this._bAccount);
            this._pButtons.Controls.Add(this._bStop);
            this._pButtons.Controls.Add(this._bStart);
            this._pButtons.Location = new System.Drawing.Point(8, 56);
            this._pButtons.Name = "_pButtons";
            this._pButtons.Size = new System.Drawing.Size(121, 300);
            this._pButtons.TabIndex = 0;
            // 
            // _bClose
            // 
            this._bClose.Location = new System.Drawing.Point(3, 175);
            this._bClose.Name = "_bClose";
            this._bClose.Size = new System.Drawing.Size(111, 37);
            this._bClose.TabIndex = 5;
            this._bClose.Text = "Close";
            this._bClose.UseVisualStyleBackColor = true;
            this._bClose.Click += new System.EventHandler(this._bClose_Click);
            // 
            // _bRestart
            // 
            this._bRestart.Location = new System.Drawing.Point(3, 89);
            this._bRestart.Name = "_bRestart";
            this._bRestart.Size = new System.Drawing.Size(111, 37);
            this._bRestart.TabIndex = 4;
            this._bRestart.Text = "Restart";
            this._bRestart.UseVisualStyleBackColor = true;
            this._bRestart.Click += new System.EventHandler(this._bRestart_Click);
            // 
            // _bAccount
            // 
            this._bAccount.Location = new System.Drawing.Point(3, 132);
            this._bAccount.Name = "_bAccount";
            this._bAccount.Size = new System.Drawing.Size(111, 37);
            this._bAccount.TabIndex = 3;
            this._bAccount.Text = "Create Account";
            this._bAccount.UseVisualStyleBackColor = true;
            this._bAccount.Click += new System.EventHandler(this._bAccount_Click);
            // 
            // _bStop
            // 
            this._bStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._bStop.Location = new System.Drawing.Point(3, 46);
            this._bStop.Name = "_bStop";
            this._bStop.Size = new System.Drawing.Size(111, 37);
            this._bStop.TabIndex = 2;
            this._bStop.Text = "Stop";
            this._bStop.UseVisualStyleBackColor = true;
            this._bStop.Click += new System.EventHandler(this._bStop_Click);
            // 
            // _bStart
            // 
            this._bStart.Location = new System.Drawing.Point(3, 3);
            this._bStart.Name = "_bStart";
            this._bStart.Size = new System.Drawing.Size(111, 37);
            this._bStart.TabIndex = 1;
            this._bStart.Text = "Start";
            this._bStart.UseVisualStyleBackColor = true;
            this._bStart.Click += new System.EventHandler(this._bStart_Click);
            // 
            // _tpAC
            // 
            this._tpAC.BackColor = System.Drawing.Color.Transparent;
            this._tpAC.BackgroundImage = global::One_Click.Properties.Resources.wow2_1113304c;
            this._tpAC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._tpAC.Controls.Add(this._rtCompile);
            this._tpAC.Controls.Add(this._bCompile);
            this._tpAC.Location = new System.Drawing.Point(4, 22);
            this._tpAC.Name = "_tpAC";
            this._tpAC.Size = new System.Drawing.Size(606, 362);
            this._tpAC.TabIndex = 1;
            this._tpAC.Text = "Auto_Compiler";
            // 
            // _rtCompile
            // 
            this._rtCompile.BackColor = System.Drawing.SystemColors.MenuText;
            this._rtCompile.ForeColor = System.Drawing.Color.Lime;
            this._rtCompile.Location = new System.Drawing.Point(121, 3);
            this._rtCompile.Name = "_rtCompile";
            this._rtCompile.Size = new System.Drawing.Size(482, 353);
            this._rtCompile.TabIndex = 1;
            this._rtCompile.Text = "";
            // 
            // _bCompile
            // 
            this._bCompile.Location = new System.Drawing.Point(17, 12);
            this._bCompile.Name = "_bCompile";
            this._bCompile.Size = new System.Drawing.Size(98, 38);
            this._bCompile.TabIndex = 0;
            this._bCompile.Text = "Compile sln";
            this._bCompile.UseVisualStyleBackColor = true;
            this._bCompile.Click += new System.EventHandler(this._bCompile_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "OneClick";
            this.notifyIcon1.BalloonTipClosed += new System.EventHandler(this.notifyIcon1_BalloonTipClosed);
            this.notifyIcon1.BalloonTipShown += new System.EventHandler(this.notifyIcon1_BalloonTipShown);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            this.notifyIcon1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.optionToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(112, 48);
            this.contextMenuStrip1.Text = "OneClick";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem1});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "File";
            // 
            // closeToolStripMenuItem1
            // 
            this.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
            this.closeToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem1.Text = "Close";
            this.closeToolStripMenuItem1.Click += new System.EventHandler(this._bClose_Click);
            // 
            // optionToolStripMenuItem1
            // 
            this.optionToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem1});
            this.optionToolStripMenuItem1.Name = "optionToolStripMenuItem1";
            this.optionToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.optionToolStripMenuItem1.Text = "Option";
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem1.Text = "Settings";
            this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::One_Click.Properties.Resources.nerbian_entrance;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(614, 412);
            this.Controls.Add(this.pMain);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "One-Click";
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pMain.ResumeLayout(false);
            this._tpHandler.ResumeLayout(false);
            this._tpHandler.PerformLayout();
            this._pProcessNormal.ResumeLayout(false);
            this._tpNormal.ResumeLayout(false);
            this._tpError.ResumeLayout(false);
            this._pButtons.ResumeLayout(false);
            this._tpAC.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.TabControl pMain;
        private System.Windows.Forms.TabPage _tpHandler;
        private System.Windows.Forms.Panel _pButtons;
        private System.Windows.Forms.Button _bStart;
        private System.Windows.Forms.Button _bStop;
        private System.Windows.Forms.Button _bRestart;
        private System.Windows.Forms.Button _bAccount;
        private System.Windows.Forms.Button _bClose;
        private System.Windows.Forms.RichTextBox _rtProcessNormal;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Label lWorld;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lRealm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lGMOnline;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lCharOnline;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabControl _pProcessNormal;
        private System.Windows.Forms.TabPage _tpNormal;
        private System.Windows.Forms.TabPage _tpError;
        private System.Windows.Forms.RichTextBox _rtProcessError;
        private System.Windows.Forms.TabPage _tpAC;
        private System.Windows.Forms.RichTextBox _rtCompile;
        private System.Windows.Forms.Button _bCompile;
        private System.Windows.Forms.Label lTotalChar;
        private System.Windows.Forms.Label lTotalAccounts;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
    }
}

