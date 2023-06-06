namespace ManagerClient
{
    partial class ManagerRegForm
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
            this.bttnReg = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bttnReg
            // 
            this.bttnReg.Location = new System.Drawing.Point(137, 97);
            this.bttnReg.Name = "bttnReg";
            this.bttnReg.Size = new System.Drawing.Size(75, 36);
            this.bttnReg.TabIndex = 9;
            this.bttnReg.Text = "Reg";
            this.bttnReg.UseVisualStyleBackColor = true;
            this.bttnReg.Click += new System.EventHandler(this.bttnReg_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(58, 62);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(60, 15);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Password:";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(78, 33);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(40, 15);
            this.lblLogin.TabIndex = 7;
            this.lblLogin.Text = "Login:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(122, 54);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(129, 23);
            this.tbPassword.TabIndex = 6;
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(122, 25);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(129, 23);
            this.tbLogin.TabIndex = 5;
            // 
            // ManagerRegForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 159);
            this.Controls.Add(this.bttnReg);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbLogin);
            this.MaximumSize = new System.Drawing.Size(325, 198);
            this.MinimumSize = new System.Drawing.Size(325, 198);
            this.Name = "ManagerRegForm";
            this.Text = "ManagerRegForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button bttnReg;
        private Label lblPassword;
        private Label lblLogin;
        private TextBox tbPassword;
        private TextBox tbLogin;
    }
}