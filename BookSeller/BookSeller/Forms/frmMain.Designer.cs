namespace BookSeller
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
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnSaleAndHire = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(197, 227);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 0;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(12, 12);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(95, 41);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "View Books";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClients
            // 
            this.btnClients.Location = new System.Drawing.Point(12, 59);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(95, 41);
            this.btnClients.TabIndex = 2;
            this.btnClients.Text = "View Clients";
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // btnSaleAndHire
            // 
            this.btnSaleAndHire.Location = new System.Drawing.Point(12, 106);
            this.btnSaleAndHire.Name = "btnSaleAndHire";
            this.btnSaleAndHire.Size = new System.Drawing.Size(95, 41);
            this.btnSaleAndHire.TabIndex = 3;
            this.btnSaleAndHire.Text = "Sale and Hire";
            this.btnSaleAndHire.UseVisualStyleBackColor = true;
            this.btnSaleAndHire.Click += new System.EventHandler(this.btnSaleAndHire_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnSaleAndHire);
            this.Controls.Add(this.btnClients);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnLogOut);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnSaleAndHire;
    }
}