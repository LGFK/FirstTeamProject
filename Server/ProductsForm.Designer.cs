namespace Server
{
    partial class ProductsForm
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
            this.addPrdctBttn = new System.Windows.Forms.Button();
            this.lV1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // addPrdctBttn
            // 
            this.addPrdctBttn.Location = new System.Drawing.Point(200, 401);
            this.addPrdctBttn.Name = "addPrdctBttn";
            this.addPrdctBttn.Size = new System.Drawing.Size(115, 23);
            this.addPrdctBttn.TabIndex = 9;
            this.addPrdctBttn.Text = "AddNew";
            this.addPrdctBttn.UseVisualStyleBackColor = true;
            // 
            // lV1
            // 
            this.lV1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lV1.FullRowSelect = true;
            this.lV1.Location = new System.Drawing.Point(24, 39);
            this.lV1.Name = "lV1";
            this.lV1.Size = new System.Drawing.Size(477, 343);
            this.lV1.TabIndex = 8;
            this.lV1.UseCompatibleStateImageBehavior = false;
            this.lV1.View = System.Windows.Forms.View.Details;
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 450);
            this.Controls.Add(this.addPrdctBttn);
            this.Controls.Add(this.lV1);
            this.Name = "ProductsForm";
            this.Text = "ProductsForm";
            this.Load += new System.EventHandler(this.ProductsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button addPrdctBttn;
        private ListView lV1;
    }
}