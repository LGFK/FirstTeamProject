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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serverStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serverStart
            // 
            this.serverStart.AutoSize = true;
            this.serverStart.BackColor = System.Drawing.Color.IndianRed;
            this.serverStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverStart.Location = new System.Drawing.Point(0, 0);
            this.serverStart.Name = "serverStart";
            this.serverStart.Size = new System.Drawing.Size(525, 55);
            this.serverStart.TabIndex = 3;
            this.serverStart.Text = "Start Server";
            this.serverStart.UseVisualStyleBackColor = false;
            this.serverStart.Click += new System.EventHandler(this.serverStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 55);
            this.Controls.Add(this.serverStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button serverStart;
    }
}