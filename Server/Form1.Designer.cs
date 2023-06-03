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
            this.serverStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serverStart
            // 
            this.serverStart.BackColor = System.Drawing.Color.IndianRed;
            this.serverStart.Location = new System.Drawing.Point(193, 192);
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
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Button serverStart;
    }
}