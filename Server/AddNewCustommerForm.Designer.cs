namespace Server
{
    partial class AddNewCustommerForm
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbSName = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbPhoneN = new System.Windows.Forms.TextBox();
            this.nameLbl = new System.Windows.Forms.Label();
            this.pnLbl = new System.Windows.Forms.Label();
            this.mailLbl = new System.Windows.Forms.Label();
            this.secondNLbl = new System.Windows.Forms.Label();
            this.titleLbl = new System.Windows.Forms.Label();
            this.bttnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(147, 73);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(179, 23);
            this.tbName.TabIndex = 0;
            // 
            // tbSName
            // 
            this.tbSName.Location = new System.Drawing.Point(147, 102);
            this.tbSName.Name = "tbSName";
            this.tbSName.Size = new System.Drawing.Size(179, 23);
            this.tbSName.TabIndex = 1;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(147, 131);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.PlaceholderText = "Not Necessary";
            this.tbEmail.Size = new System.Drawing.Size(179, 23);
            this.tbEmail.TabIndex = 2;
            // 
            // tbPhoneN
            // 
            this.tbPhoneN.Location = new System.Drawing.Point(147, 160);
            this.tbPhoneN.Name = "tbPhoneN";
            this.tbPhoneN.PlaceholderText = "Not Necessary";
            this.tbPhoneN.Size = new System.Drawing.Size(179, 23);
            this.tbPhoneN.TabIndex = 3;
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(79, 76);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(67, 15);
            this.nameLbl.TabIndex = 4;
            this.nameLbl.Text = "First Name:";
            // 
            // pnLbl
            // 
            this.pnLbl.AutoSize = true;
            this.pnLbl.Location = new System.Drawing.Point(67, 163);
            this.pnLbl.Name = "pnLbl";
            this.pnLbl.Size = new System.Drawing.Size(74, 15);
            this.pnLbl.TabIndex = 5;
            this.pnLbl.Text = "Phone Num:";
            // 
            // mailLbl
            // 
            this.mailLbl.AutoSize = true;
            this.mailLbl.Location = new System.Drawing.Point(102, 134);
            this.mailLbl.Name = "mailLbl";
            this.mailLbl.Size = new System.Drawing.Size(39, 15);
            this.mailLbl.TabIndex = 6;
            this.mailLbl.Text = "Email:";
            // 
            // secondNLbl
            // 
            this.secondNLbl.AutoSize = true;
            this.secondNLbl.Location = new System.Drawing.Point(62, 105);
            this.secondNLbl.Name = "secondNLbl";
            this.secondNLbl.Size = new System.Drawing.Size(84, 15);
            this.secondNLbl.TabIndex = 7;
            this.secondNLbl.Text = "Second Name:";
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Location = new System.Drawing.Point(175, 43);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(99, 15);
            this.titleLbl.TabIndex = 8;
            this.titleLbl.Text = "NEW CUSTOMER:";
            // 
            // bttnAdd
            // 
            this.bttnAdd.Location = new System.Drawing.Point(176, 205);
            this.bttnAdd.Name = "bttnAdd";
            this.bttnAdd.Size = new System.Drawing.Size(98, 29);
            this.bttnAdd.TabIndex = 9;
            this.bttnAdd.Text = "Add";
            this.bttnAdd.UseVisualStyleBackColor = true;
            this.bttnAdd.Click += new System.EventHandler(this.bttnAdd_Click);
            // 
            // AddNewCustommerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 259);
            this.Controls.Add(this.bttnAdd);
            this.Controls.Add(this.titleLbl);
            this.Controls.Add(this.secondNLbl);
            this.Controls.Add(this.mailLbl);
            this.Controls.Add(this.pnLbl);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.tbPhoneN);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbSName);
            this.Controls.Add(this.tbName);
            this.Name = "AddNewCustommerForm";
            this.Text = "AddNewCustommerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbName;
        private TextBox tbSName;
        private TextBox tbEmail;
        private TextBox tbPhoneN;
        private Label nameLbl;
        private Label pnLbl;
        private Label mailLbl;
        private Label secondNLbl;
        private Label titleLbl;
        private Button bttnAdd;
    }
}