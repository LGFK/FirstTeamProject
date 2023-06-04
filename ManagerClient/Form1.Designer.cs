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
            this.label1 = new System.Windows.Forms.Label();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(367, 194);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productsBttn);
            this.Controls.Add(this.customersBttn);
            this.Controls.Add(this.cashiersBttn);
            this.MaximumSize = new System.Drawing.Size(383, 233);
            this.MinimumSize = new System.Drawing.Size(383, 233);
            this.Name = "Form1";
            this.Text = "ManagerClient";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button productsBttn;
        private Button customersBttn;
        private Button cashiersBttn;
        private Label label1;
    }
}