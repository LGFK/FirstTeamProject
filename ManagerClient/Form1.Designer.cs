namespace ManagerClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.productsBttn = new System.Windows.Forms.Button();
            this.customersBttn = new System.Windows.Forms.Button();
            this.cashiersBttn = new System.Windows.Forms.Button();
            this.bttnAddMngr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // productsBttn
            // 
            this.productsBttn.Location = new System.Drawing.Point(12, 130);
            this.productsBttn.Name = "productsBttn";
            this.productsBttn.Size = new System.Drawing.Size(343, 55);
            this.productsBttn.TabIndex = 6;
            this.productsBttn.Text = "Products";
            this.productsBttn.UseVisualStyleBackColor = true;
            this.productsBttn.Click += new System.EventHandler(this.productsBttn_Click);
            // 
            // customersBttn
            // 
            this.customersBttn.Location = new System.Drawing.Point(12, 12);
            this.customersBttn.Margin = new System.Windows.Forms.Padding(1);
            this.customersBttn.MaximumSize = new System.Drawing.Size(343, 53);
            this.customersBttn.MinimumSize = new System.Drawing.Size(343, 53);
            this.customersBttn.Name = "customersBttn";
            this.customersBttn.Size = new System.Drawing.Size(343, 53);
            this.customersBttn.TabIndex = 5;
            this.customersBttn.Text = "Customers";
            this.customersBttn.UseVisualStyleBackColor = true;
            this.customersBttn.Click += new System.EventHandler(this.customersBttn_Click);
            // 
            // cashiersBttn
            // 
            this.cashiersBttn.Location = new System.Drawing.Point(12, 71);
            this.cashiersBttn.Name = "cashiersBttn";
            this.cashiersBttn.Size = new System.Drawing.Size(343, 53);
            this.cashiersBttn.TabIndex = 4;
            this.cashiersBttn.Text = "Cashiers";
            this.cashiersBttn.UseVisualStyleBackColor = true;
            this.cashiersBttn.Click += new System.EventHandler(this.cashiersBttn_Click);
            // 
            // bttnAddMngr
            // 
            this.bttnAddMngr.Location = new System.Drawing.Point(12, 191);
            this.bttnAddMngr.Name = "bttnAddMngr";
            this.bttnAddMngr.Size = new System.Drawing.Size(343, 55);
            this.bttnAddMngr.TabIndex = 7;
            this.bttnAddMngr.Text = "Add Mngr";
            this.bttnAddMngr.UseVisualStyleBackColor = true;
            this.bttnAddMngr.Click += new System.EventHandler(this.bttnAddMngr_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(367, 252);
            this.Controls.Add(this.bttnAddMngr);
            this.Controls.Add(this.productsBttn);
            this.Controls.Add(this.customersBttn);
            this.Controls.Add(this.cashiersBttn);
            this.MinimumSize = new System.Drawing.Size(383, 233);
            this.Name = "Form1";
            this.Text = "ManagerClient";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button productsBttn;
        private Button customersBttn;
        private Button cashiersBttn;
        private Button bttnAddMngr;
    }
}