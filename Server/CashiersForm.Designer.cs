namespace Server
{
    partial class CashiersForm
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
            this.lV1 = new System.Windows.Forms.ListView();
            this.createNewBttn = new System.Windows.Forms.Button();
            this.fireBttn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lV1
            // 
            this.lV1.FullRowSelect = true;
            this.lV1.Location = new System.Drawing.Point(27, 18);
            this.lV1.Name = "lV1";
            this.lV1.Size = new System.Drawing.Size(477, 343);
            this.lV1.TabIndex = 0;
            this.lV1.UseCompatibleStateImageBehavior = false;
            this.lV1.View = System.Windows.Forms.View.Details;
            // 
            // createNewBttn
            // 
            this.createNewBttn.Location = new System.Drawing.Point(389, 367);
            this.createNewBttn.Name = "createNewBttn";
            this.createNewBttn.Size = new System.Drawing.Size(115, 23);
            this.createNewBttn.TabIndex = 7;
            this.createNewBttn.Text = "Hire";
            this.createNewBttn.UseVisualStyleBackColor = true;
            // 
            // fireBttn
            // 
            this.fireBttn.Location = new System.Drawing.Point(27, 367);
            this.fireBttn.Name = "fireBttn";
            this.fireBttn.Size = new System.Drawing.Size(115, 23);
            this.fireBttn.TabIndex = 6;
            this.fireBttn.Text = "Fire";
            this.fireBttn.UseVisualStyleBackColor = true;
            // 
            // CashiersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 450);
            this.Controls.Add(this.createNewBttn);
            this.Controls.Add(this.fireBttn);
            this.Controls.Add(this.lV1);
            this.Name = "CashiersForm";
            this.Text = "CashiersForm";
            this.Load += new System.EventHandler(this.CashiersForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView lV1;
        private Button createNewBttn;
        private Button fireBttn;
    }
}