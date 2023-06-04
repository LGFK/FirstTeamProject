namespace ManagerClient
{
    partial class AddNewCashierForm
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
            this.titleLbl = new System.Windows.Forms.Label();
            this.secondNLbl = new System.Windows.Forms.Label();
            this.mailLbl = new System.Windows.Forms.Label();
            this.pnLbl = new System.Windows.Forms.Label();
            this.nameLbl = new System.Windows.Forms.Label();
            this.tbPhoneN = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbSName = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Location = new System.Drawing.Point(201, 34);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(99, 15);
            this.titleLbl.TabIndex = 18;
            this.titleLbl.Text = "NEW CUSTOMER:";
            // 
            // secondNLbl
            // 
            this.secondNLbl.AutoSize = true;
            this.secondNLbl.Location = new System.Drawing.Point(88, 96);
            this.secondNLbl.Name = "secondNLbl";
            this.secondNLbl.Size = new System.Drawing.Size(84, 15);
            this.secondNLbl.TabIndex = 17;
            this.secondNLbl.Text = "Second Name:";
            // 
            // mailLbl
            // 
            this.mailLbl.AutoSize = true;
            this.mailLbl.Location = new System.Drawing.Point(128, 125);
            this.mailLbl.Name = "mailLbl";
            this.mailLbl.Size = new System.Drawing.Size(39, 15);
            this.mailLbl.TabIndex = 16;
            this.mailLbl.Text = "Email:";
            // 
            // pnLbl
            // 
            this.pnLbl.AutoSize = true;
            this.pnLbl.Location = new System.Drawing.Point(93, 154);
            this.pnLbl.Name = "pnLbl";
            this.pnLbl.Size = new System.Drawing.Size(74, 15);
            this.pnLbl.TabIndex = 15;
            this.pnLbl.Text = "Phone Num:";
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(105, 67);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(67, 15);
            this.nameLbl.TabIndex = 14;
            this.nameLbl.Text = "First Name:";
            // 
            // tbPhoneN
            // 
            this.tbPhoneN.Location = new System.Drawing.Point(173, 151);
            this.tbPhoneN.Name = "tbPhoneN";
            this.tbPhoneN.Size = new System.Drawing.Size(179, 23);
            this.tbPhoneN.TabIndex = 13;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(173, 122);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(179, 23);
            this.tbEmail.TabIndex = 12;
            // 
            // tbSName
            // 
            this.tbSName.Location = new System.Drawing.Point(173, 93);
            this.tbSName.Name = "tbSName";
            this.tbSName.Size = new System.Drawing.Size(179, 23);
            this.tbSName.TabIndex = 11;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(173, 64);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(179, 23);
            this.tbName.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(201, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.bttnAdd_Click);
            // 
            // AddNewCashierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 259);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.titleLbl);
            this.Controls.Add(this.secondNLbl);
            this.Controls.Add(this.mailLbl);
            this.Controls.Add(this.pnLbl);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.tbPhoneN);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbSName);
            this.Controls.Add(this.tbName);
            this.MaximumSize = new System.Drawing.Size(456, 298);
            this.MinimumSize = new System.Drawing.Size(456, 298);
            this.Name = "AddNewCashierForm";
            this.Text = "AddNewCashierForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label titleLbl;
        private Label secondNLbl;
        private Label mailLbl;
        private Label pnLbl;
        private Label nameLbl;
        private TextBox tbPhoneN;
        private TextBox tbEmail;
        private TextBox tbSName;
        private TextBox tbName;
        private Button button1;
    }
}