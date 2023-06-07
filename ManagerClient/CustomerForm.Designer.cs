namespace ManagerClient
{
    partial class CustomerForm
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
            this.deleteFromDbBttn = new System.Windows.Forms.Button();
            this.addNewBttn = new System.Windows.Forms.Button();
            this.lV1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // deleteFromDbBttn
            // 
            this.deleteFromDbBttn.Location = new System.Drawing.Point(386, 374);
            this.deleteFromDbBttn.MaximumSize = new System.Drawing.Size(115, 27);
            this.deleteFromDbBttn.MinimumSize = new System.Drawing.Size(115, 27);
            this.deleteFromDbBttn.Name = "deleteFromDbBttn";
            this.deleteFromDbBttn.Size = new System.Drawing.Size(115, 27);
            this.deleteFromDbBttn.TabIndex = 10;
            this.deleteFromDbBttn.Text = "Delete From Model";
            this.deleteFromDbBttn.UseVisualStyleBackColor = true;
            this.deleteFromDbBttn.Click += new System.EventHandler(this.deleteFromDbBttn_Click);
            // 
            // addNewBttn
            // 
            this.addNewBttn.Location = new System.Drawing.Point(24, 374);
            this.addNewBttn.Name = "addNewBttn";
            this.addNewBttn.Size = new System.Drawing.Size(115, 23);
            this.addNewBttn.TabIndex = 9;
            this.addNewBttn.Text = "Add New";
            this.addNewBttn.UseVisualStyleBackColor = true;
            this.addNewBttn.Click += new System.EventHandler(this.addNewBttn_Click);
            // 
            // lV1
            // 
            this.lV1.FullRowSelect = true;
            this.lV1.Location = new System.Drawing.Point(24, 25);
            this.lV1.MultiSelect = false;
            this.lV1.Name = "lV1";
            this.lV1.Size = new System.Drawing.Size(477, 343);
            this.lV1.TabIndex = 8;
            this.lV1.UseCompatibleStateImageBehavior = false;
            this.lV1.View = System.Windows.Forms.View.Details;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 450);
            this.Controls.Add(this.deleteFromDbBttn);
            this.Controls.Add(this.addNewBttn);
            this.Controls.Add(this.lV1);
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button deleteFromDbBttn;
        private Button addNewBttn;
        private ListView lV1;
    }
}