namespace Server
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
            this.cashiersBttn = new System.Windows.Forms.Button();
            this.customersBttn = new System.Windows.Forms.Button();
            this.productsBttn = new System.Windows.Forms.Button();
            this.serverStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cashiersBttn
            // 
            this.cashiersBttn.Location = new System.Drawing.Point(197, 88);
            this.cashiersBttn.Name = "cashiersBttn";
            this.cashiersBttn.Size = new System.Drawing.Size(108, 53);
            this.cashiersBttn.TabIndex = 0;
            this.cashiersBttn.Text = "Cashiers";
            this.cashiersBttn.UseVisualStyleBackColor = true;
            this.cashiersBttn.Click += new System.EventHandler(this.button1_Click);
            // 
            // customersBttn
            // 
            this.customersBttn.Location = new System.Drawing.Point(197, 147);
            this.customersBttn.Name = "customersBttn";
            this.customersBttn.Size = new System.Drawing.Size(108, 53);
            this.customersBttn.TabIndex = 1;
            this.customersBttn.Text = "Customers";
            this.customersBttn.UseVisualStyleBackColor = true;
            this.customersBttn.Click += new System.EventHandler(this.customersBttn_Click);
            // 
            // productsBttn
            // 
            this.productsBttn.Location = new System.Drawing.Point(197, 206);
            this.productsBttn.Name = "productsBttn";
            this.productsBttn.Size = new System.Drawing.Size(108, 55);
            this.productsBttn.TabIndex = 2;
            this.productsBttn.Text = "Products";
            this.productsBttn.UseVisualStyleBackColor = true;
            this.productsBttn.Click += new System.EventHandler(this.productsBttn_Click);
            // 
            // serverStart
            // 
            this.serverStart.BackColor = System.Drawing.Color.IndianRed;
            this.serverStart.Location = new System.Drawing.Point(197, 267);
            this.serverStart.Name = "serverStart";
            this.serverStart.Size = new System.Drawing.Size(108, 55);
            this.serverStart.TabIndex = 3;
            this.serverStart.Text = "Start Server";
            this.serverStart.UseVisualStyleBackColor = false;
            this.serverStart.Click += new System.EventHandler(this.serverStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 450);
            this.Controls.Add(this.serverStart);
            this.Controls.Add(this.productsBttn);
            this.Controls.Add(this.customersBttn);
            this.Controls.Add(this.cashiersBttn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button cashiersBttn;
        private Button customersBttn;
        private Button productsBttn;
        private Button serverStart;
    }
}