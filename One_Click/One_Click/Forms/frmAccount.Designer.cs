namespace One_Click
{
    partial class frmAccount
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
            this._bCreateAccount = new System.Windows.Forms.Button();
            this._tbUser = new System.Windows.Forms.TextBox();
            this._tbPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._cbAddon = new System.Windows.Forms.ComboBox();
            this._cbGM = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // _bCreateAccount
            // 
            this._bCreateAccount.Location = new System.Drawing.Point(64, 118);
            this._bCreateAccount.Name = "_bCreateAccount";
            this._bCreateAccount.Size = new System.Drawing.Size(101, 38);
            this._bCreateAccount.TabIndex = 4;
            this._bCreateAccount.Text = "Create";
            this._bCreateAccount.UseVisualStyleBackColor = true;
            this._bCreateAccount.Click += new System.EventHandler(this._bCreateAccount_Click);
            // 
            // _tbUser
            // 
            this._tbUser.Location = new System.Drawing.Point(75, 12);
            this._tbUser.Name = "_tbUser";
            this._tbUser.Size = new System.Drawing.Size(130, 20);
            this._tbUser.TabIndex = 0;
            // 
            // _tbPass
            // 
            this._tbPass.Location = new System.Drawing.Point(75, 38);
            this._tbPass.Name = "_tbPass";
            this._tbPass.Size = new System.Drawing.Size(130, 20);
            this._tbPass.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "UserName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Addon";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "GM Level";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Lime;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password";
            // 
            // _cbAddon
            // 
            this._cbAddon.FormattingEnabled = true;
            this._cbAddon.Items.AddRange(new object[] {
            "Classic",
            "Burning Crusade",
            "Wrath of the Lich King"});
            this._cbAddon.Location = new System.Drawing.Point(75, 64);
            this._cbAddon.Name = "_cbAddon";
            this._cbAddon.Size = new System.Drawing.Size(130, 21);
            this._cbAddon.TabIndex = 2;
            // 
            // _cbGM
            // 
            this._cbGM.FormattingEnabled = true;
            this._cbGM.Items.AddRange(new object[] {
            "Player",
            "Moderaor",
            "Gamemaster",
            "Admin",
            "Super Admin"});
            this._cbGM.Location = new System.Drawing.Point(75, 91);
            this._cbGM.Name = "_cbGM";
            this._cbGM.Size = new System.Drawing.Size(130, 21);
            this._cbGM.TabIndex = 3;
            // 
            // frmAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::One_Click.Properties.Resources.nerbian_entrance;
            this.ClientSize = new System.Drawing.Size(233, 175);
            this.Controls.Add(this._cbGM);
            this.Controls.Add(this._cbAddon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._tbPass);
            this.Controls.Add(this._tbUser);
            this.Controls.Add(this._bCreateAccount);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Account Creation";
            this.Load += new System.EventHandler(this.frmAccount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _bCreateAccount;
        private System.Windows.Forms.TextBox _tbUser;
        private System.Windows.Forms.TextBox _tbPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox _cbAddon;
        private System.Windows.Forms.ComboBox _cbGM;
    }
}