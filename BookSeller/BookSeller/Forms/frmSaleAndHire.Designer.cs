namespace BookSeller
{
    partial class frmSaleAndHire
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
            this.listBoxBooks = new System.Windows.Forms.ListBox();
            this.listboxClients = new System.Windows.Forms.ListBox();
            this.groupBoxClients = new System.Windows.Forms.GroupBox();
            this.clientFilterComboBox = new System.Windows.Forms.ComboBox();
            this.edtClientFilter = new System.Windows.Forms.TextBox();
            this.btnClientFilter = new System.Windows.Forms.Button();
            this.groupBoxBooks = new System.Windows.Forms.GroupBox();
            this.bookFilterComboBox = new System.Windows.Forms.ComboBox();
            this.edtBookFilter = new System.Windows.Forms.TextBox();
            this.btnBookFilter = new System.Windows.Forms.Button();
            this.btnSale = new System.Windows.Forms.Button();
            this.btnHire = new System.Windows.Forms.Button();
            this.btnHoldHire = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.groupBoxClients.SuspendLayout();
            this.groupBoxBooks.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxBooks
            // 
            this.listBoxBooks.FormattingEnabled = true;
            this.listBoxBooks.HorizontalScrollbar = true;
            this.listBoxBooks.Location = new System.Drawing.Point(6, 16);
            this.listBoxBooks.Name = "listBoxBooks";
            this.listBoxBooks.Size = new System.Drawing.Size(256, 225);
            this.listBoxBooks.TabIndex = 15;
            // 
            // listboxClients
            // 
            this.listboxClients.FormattingEnabled = true;
            this.listboxClients.Location = new System.Drawing.Point(8, 16);
            this.listboxClients.Name = "listboxClients";
            this.listboxClients.Size = new System.Drawing.Size(256, 225);
            this.listboxClients.TabIndex = 16;
            // 
            // groupBoxClients
            // 
            this.groupBoxClients.Controls.Add(this.clientFilterComboBox);
            this.groupBoxClients.Controls.Add(this.edtClientFilter);
            this.groupBoxClients.Controls.Add(this.btnClientFilter);
            this.groupBoxClients.Controls.Add(this.listboxClients);
            this.groupBoxClients.Location = new System.Drawing.Point(288, 12);
            this.groupBoxClients.Name = "groupBoxClients";
            this.groupBoxClients.Size = new System.Drawing.Size(270, 318);
            this.groupBoxClients.TabIndex = 17;
            this.groupBoxClients.TabStop = false;
            this.groupBoxClients.Text = "Clients";
            // 
            // clientFilterComboBox
            // 
            this.clientFilterComboBox.FormattingEnabled = true;
            this.clientFilterComboBox.Items.AddRange(new object[] {
            "FirstName",
            "LastName",
            "Street",
            "City",
            "Province",
            "Zip",
            "E_Mail",
            "Books_purchased",
            "Books_hired"});
            this.clientFilterComboBox.Location = new System.Drawing.Point(8, 285);
            this.clientFilterComboBox.Name = "clientFilterComboBox";
            this.clientFilterComboBox.Size = new System.Drawing.Size(129, 21);
            this.clientFilterComboBox.TabIndex = 20;
            // 
            // edtClientFilter
            // 
            this.edtClientFilter.Location = new System.Drawing.Point(8, 247);
            this.edtClientFilter.Name = "edtClientFilter";
            this.edtClientFilter.Size = new System.Drawing.Size(129, 20);
            this.edtClientFilter.TabIndex = 19;
            // 
            // btnClientFilter
            // 
            this.btnClientFilter.Location = new System.Drawing.Point(159, 260);
            this.btnClientFilter.Name = "btnClientFilter";
            this.btnClientFilter.Size = new System.Drawing.Size(87, 32);
            this.btnClientFilter.TabIndex = 18;
            this.btnClientFilter.Text = "Filter";
            this.btnClientFilter.UseVisualStyleBackColor = true;
            this.btnClientFilter.Click += new System.EventHandler(this.btnClientFilter_Click);
            // 
            // groupBoxBooks
            // 
            this.groupBoxBooks.Controls.Add(this.bookFilterComboBox);
            this.groupBoxBooks.Controls.Add(this.edtBookFilter);
            this.groupBoxBooks.Controls.Add(this.btnBookFilter);
            this.groupBoxBooks.Controls.Add(this.listBoxBooks);
            this.groupBoxBooks.Location = new System.Drawing.Point(12, 12);
            this.groupBoxBooks.Name = "groupBoxBooks";
            this.groupBoxBooks.Size = new System.Drawing.Size(270, 318);
            this.groupBoxBooks.TabIndex = 18;
            this.groupBoxBooks.TabStop = false;
            this.groupBoxBooks.Text = "Books";
            // 
            // bookFilterComboBox
            // 
            this.bookFilterComboBox.FormattingEnabled = true;
            this.bookFilterComboBox.Items.AddRange(new object[] {
            "Title",
            "Author",
            "ISBN",
            "Pages",
            "Year",
            "Price",
            "In Stock",
            "Hired Out"});
            this.bookFilterComboBox.Location = new System.Drawing.Point(6, 285);
            this.bookFilterComboBox.Name = "bookFilterComboBox";
            this.bookFilterComboBox.Size = new System.Drawing.Size(129, 21);
            this.bookFilterComboBox.TabIndex = 18;
            // 
            // edtBookFilter
            // 
            this.edtBookFilter.Location = new System.Drawing.Point(6, 247);
            this.edtBookFilter.Name = "edtBookFilter";
            this.edtBookFilter.Size = new System.Drawing.Size(129, 20);
            this.edtBookFilter.TabIndex = 17;
            // 
            // btnBookFilter
            // 
            this.btnBookFilter.Location = new System.Drawing.Point(158, 260);
            this.btnBookFilter.Name = "btnBookFilter";
            this.btnBookFilter.Size = new System.Drawing.Size(87, 32);
            this.btnBookFilter.TabIndex = 16;
            this.btnBookFilter.Text = "Filter";
            this.btnBookFilter.UseVisualStyleBackColor = true;
            this.btnBookFilter.Click += new System.EventHandler(this.btnBookFilter_Click);
            // 
            // btnSale
            // 
            this.btnSale.Location = new System.Drawing.Point(12, 336);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(87, 32);
            this.btnSale.TabIndex = 19;
            this.btnSale.Text = "Sale";
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // btnHire
            // 
            this.btnHire.Location = new System.Drawing.Point(105, 336);
            this.btnHire.Name = "btnHire";
            this.btnHire.Size = new System.Drawing.Size(87, 32);
            this.btnHire.TabIndex = 20;
            this.btnHire.Text = "Hire";
            this.btnHire.UseVisualStyleBackColor = true;
            this.btnHire.Click += new System.EventHandler(this.btnHire_Click);
            // 
            // btnHoldHire
            // 
            this.btnHoldHire.Location = new System.Drawing.Point(291, 336);
            this.btnHoldHire.Name = "btnHoldHire";
            this.btnHoldHire.Size = new System.Drawing.Size(87, 32);
            this.btnHoldHire.TabIndex = 22;
            this.btnHoldHire.Text = "Hold Hired";
            this.btnHoldHire.UseVisualStyleBackColor = true;
            this.btnHoldHire.Click += new System.EventHandler(this.btnHoldHire_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(198, 336);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(87, 32);
            this.btnOrder.TabIndex = 21;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // frmSaleAndHire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 376);
            this.Controls.Add(this.btnHoldHire);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.btnHire);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.groupBoxBooks);
            this.Controls.Add(this.groupBoxClients);
            this.Name = "frmSaleAndHire";
            this.Text = "frmSaleAndHire";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSaleAndHire_FormClosing);
            this.Load += new System.EventHandler(this.frmSaleAndHire_Load);
            this.groupBoxClients.ResumeLayout(false);
            this.groupBoxClients.PerformLayout();
            this.groupBoxBooks.ResumeLayout(false);
            this.groupBoxBooks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxBooks;
        private System.Windows.Forms.ListBox listboxClients;
        private System.Windows.Forms.GroupBox groupBoxClients;
        private System.Windows.Forms.GroupBox groupBoxBooks;
        private System.Windows.Forms.ComboBox bookFilterComboBox;
        private System.Windows.Forms.TextBox edtBookFilter;
        private System.Windows.Forms.Button btnBookFilter;
        private System.Windows.Forms.TextBox edtClientFilter;
        private System.Windows.Forms.Button btnClientFilter;
        private System.Windows.Forms.ComboBox clientFilterComboBox;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Button btnHire;
        private System.Windows.Forms.Button btnHoldHire;
        private System.Windows.Forms.Button btnOrder;
    }
}