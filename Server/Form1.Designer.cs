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
            this.cB1 = new System.Windows.Forms.ComboBox();
            this.fireBttn = new System.Windows.Forms.Button();
            this.createNewBttn = new System.Windows.Forms.Button();
            this.discountBttn = new System.Windows.Forms.Button();
            this.lV1 = new System.Windows.Forms.ListView();
            this.idF = new System.Windows.Forms.ColumnHeader();
            this.NameF = new System.Windows.Forms.ColumnHeader();
            this.secNameF = new System.Windows.Forms.ColumnHeader();
            this.isFired = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // cB1
            // 
            this.cB1.FormattingEnabled = true;
            this.cB1.Location = new System.Drawing.Point(12, 470);
            this.cB1.Name = "cB1";
            this.cB1.Size = new System.Drawing.Size(121, 23);
            this.cB1.TabIndex = 2;
            // 
            // fireBttn
            // 
            this.fireBttn.Location = new System.Drawing.Point(476, 470);
            this.fireBttn.Name = "fireBttn";
            this.fireBttn.Size = new System.Drawing.Size(109, 23);
            this.fireBttn.TabIndex = 3;
            this.fireBttn.Text = "Fire";
            this.fireBttn.UseVisualStyleBackColor = true;
            // 
            // createNewBttn
            // 
            this.createNewBttn.Location = new System.Drawing.Point(591, 470);
            this.createNewBttn.Name = "createNewBttn";
            this.createNewBttn.Size = new System.Drawing.Size(115, 23);
            this.createNewBttn.TabIndex = 4;
            this.createNewBttn.Text = "AddNewOne";
            this.createNewBttn.UseVisualStyleBackColor = true;
            // 
            // discountBttn
            // 
            this.discountBttn.Location = new System.Drawing.Point(476, 499);
            this.discountBttn.Name = "discountBttn";
            this.discountBttn.Size = new System.Drawing.Size(230, 23);
            this.discountBttn.TabIndex = 5;
            this.discountBttn.Text = "Fire";
            this.discountBttn.UseVisualStyleBackColor = true;
            // 
            // lV1
            // 
            this.lV1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idF,
            this.NameF,
            this.secNameF,
            this.isFired});
            this.lV1.Location = new System.Drawing.Point(12, 12);
            this.lV1.Name = "lV1";
            this.lV1.Size = new System.Drawing.Size(694, 437);
            this.lV1.TabIndex = 6;
            this.lV1.UseCompatibleStateImageBehavior = false;
            this.lV1.View = System.Windows.Forms.View.Details;
            // 
            // idF
            // 
            this.idF.Text = "id";
            this.idF.Width = 100;
            // 
            // NameF
            // 
            this.NameF.Text = "First Name";
            this.NameF.Width = 100;
            // 
            // secNameF
            // 
            this.secNameF.Text = "Second Name";
            this.secNameF.Width = 100;
            // 
            // isFired
            // 
            this.isFired.Text = "Fired";
            this.isFired.Width = 100;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 534);
            this.Controls.Add(this.lV1);
            this.Controls.Add(this.discountBttn);
            this.Controls.Add(this.createNewBttn);
            this.Controls.Add(this.fireBttn);
            this.Controls.Add(this.cB1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private ComboBox cB1;
        private Button fireBttn;
        private Button createNewBttn;
        private Button discountBttn;
        private ListView lV1;
        private ColumnHeader idF;
        private ColumnHeader NameF;
        private ColumnHeader secNameF;
        private ColumnHeader isFired;
    }
}