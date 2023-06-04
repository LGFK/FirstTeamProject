namespace ManagerClient
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
            this.discountBttn = new System.Windows.Forms.Button();
            this.tbDiscount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // addPrdctBttn
            // 
            this.addPrdctBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addPrdctBttn.Location = new System.Drawing.Point(386, 388);
            this.addPrdctBttn.MaximumSize = new System.Drawing.Size(115, 27);
            this.addPrdctBttn.MinimumSize = new System.Drawing.Size(115, 27);
            this.addPrdctBttn.Name = "addPrdctBttn";
            this.addPrdctBttn.Size = new System.Drawing.Size(115, 27);
            this.addPrdctBttn.TabIndex = 9;
            this.addPrdctBttn.Text = "AddNew";
            this.addPrdctBttn.UseVisualStyleBackColor = true;
            this.addPrdctBttn.Click += new System.EventHandler(this.addPrdctBttn_Click);
            // 
            // lV1
            // 
            this.lV1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lV1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lV1.FullRowSelect = true;
            this.lV1.Location = new System.Drawing.Point(24, 39);
            this.lV1.Name = "lV1";
            this.lV1.Size = new System.Drawing.Size(477, 343);
            this.lV1.TabIndex = 8;
            this.lV1.UseCompatibleStateImageBehavior = false;
            this.lV1.View = System.Windows.Forms.View.Details;
            // 
            // discountBttn
            // 
            this.discountBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.discountBttn.Location = new System.Drawing.Point(24, 388);
            this.discountBttn.Name = "discountBttn";
            this.discountBttn.Size = new System.Drawing.Size(115, 27);
            this.discountBttn.TabIndex = 10;
            this.discountBttn.Text = "Discount";
            this.discountBttn.UseVisualStyleBackColor = true;
            this.discountBttn.Click += new System.EventHandler(this.discountBttn_Click);
            // 
            // tbDiscount
            // 
            this.tbDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDiscount.Location = new System.Drawing.Point(145, 392);
            this.tbDiscount.Name = "tbDiscount";
            this.tbDiscount.Size = new System.Drawing.Size(100, 23);
            this.tbDiscount.TabIndex = 11;
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 450);
            this.Controls.Add(this.tbDiscount);
            this.Controls.Add(this.discountBttn);
            this.Controls.Add(this.addPrdctBttn);
            this.Controls.Add(this.lV1);
            this.MaximumSize = new System.Drawing.Size(541, 489);
            this.MinimumSize = new System.Drawing.Size(541, 489);
            this.Name = "ProductsForm";
            this.Text = "ProductsForm";
            this.Load += new System.EventHandler(this.ProductsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button addPrdctBttn;
        private ListView lV1;
        private Button discountBttn;
        private TextBox tbDiscount;
    }
}