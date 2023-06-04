namespace ManagerClient
{
    partial class AddNewProductForm
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
            this.bttnAdd = new System.Windows.Forms.Button();
            this.titleLbl = new System.Windows.Forms.Label();
            this.priceLbl = new System.Windows.Forms.Label();
            this.amountlbl = new System.Windows.Forms.Label();
            this.pnLbl = new System.Windows.Forms.Label();
            this.nameLbl = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.addImBttn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bttnAddType = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bttnAdd
            // 
            this.bttnAdd.Location = new System.Drawing.Point(173, 218);
            this.bttnAdd.Name = "bttnAdd";
            this.bttnAdd.Size = new System.Drawing.Size(98, 29);
            this.bttnAdd.TabIndex = 19;
            this.bttnAdd.Text = "Add";
            this.bttnAdd.UseVisualStyleBackColor = true;
            this.bttnAdd.Click += new System.EventHandler(this.bttnAdd_Click);
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Location = new System.Drawing.Point(163, 30);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(92, 15);
            this.titleLbl.TabIndex = 18;
            this.titleLbl.Text = "NEW PRODUCT:";
            // 
            // priceLbl
            // 
            this.priceLbl.AutoSize = true;
            this.priceLbl.Location = new System.Drawing.Point(90, 92);
            this.priceLbl.Name = "priceLbl";
            this.priceLbl.Size = new System.Drawing.Size(36, 15);
            this.priceLbl.TabIndex = 17;
            this.priceLbl.Text = "Price:";
            // 
            // amountlbl
            // 
            this.amountlbl.AutoSize = true;
            this.amountlbl.Location = new System.Drawing.Point(80, 121);
            this.amountlbl.Name = "amountlbl";
            this.amountlbl.Size = new System.Drawing.Size(54, 15);
            this.amountlbl.TabIndex = 16;
            this.amountlbl.Text = "Amount:";
            // 
            // pnLbl
            // 
            this.pnLbl.AutoSize = true;
            this.pnLbl.Location = new System.Drawing.Point(55, 150);
            this.pnLbl.Name = "pnLbl";
            this.pnLbl.Size = new System.Drawing.Size(65, 15);
            this.pnLbl.TabIndex = 15;
            this.pnLbl.Text = "Prod. Type:";
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(47, 63);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(87, 15);
            this.nameLbl.TabIndex = 14;
            this.nameLbl.Text = "Product Name:";
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(135, 118);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(179, 23);
            this.tbAmount.TabIndex = 12;
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(135, 89);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(179, 23);
            this.tbPrice.TabIndex = 11;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(135, 60);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(179, 23);
            this.tbName.TabIndex = 10;
            // 
            // addImBttn
            // 
            this.addImBttn.Location = new System.Drawing.Point(137, 176);
            this.addImBttn.Name = "addImBttn";
            this.addImBttn.Size = new System.Drawing.Size(177, 27);
            this.addImBttn.TabIndex = 20;
            this.addImBttn.Text = "IMG";
            this.addImBttn.UseVisualStyleBackColor = true;
            this.addImBttn.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(135, 147);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(179, 23);
            this.comboBox1.TabIndex = 21;
            // 
            // bttnAddType
            // 
            this.bttnAddType.Location = new System.Drawing.Point(320, 147);
            this.bttnAddType.Name = "bttnAddType";
            this.bttnAddType.Size = new System.Drawing.Size(75, 23);
            this.bttnAddType.TabIndex = 22;
            this.bttnAddType.Text = "Add Type";
            this.bttnAddType.UseVisualStyleBackColor = true;
            this.bttnAddType.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // AddNewProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 259);
            this.Controls.Add(this.bttnAddType);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.addImBttn);
            this.Controls.Add(this.bttnAdd);
            this.Controls.Add(this.titleLbl);
            this.Controls.Add(this.priceLbl);
            this.Controls.Add(this.amountlbl);
            this.Controls.Add(this.pnLbl);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbName);
            this.MaximumSize = new System.Drawing.Size(456, 298);
            this.MinimumSize = new System.Drawing.Size(456, 298);
            this.Name = "AddNewProductForm";
            this.Text = "AddNewProductForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button bttnAdd;
        private Label titleLbl;
        private Label priceLbl;
        private Label amountlbl;
        private Label pnLbl;
        private Label nameLbl;
        private TextBox tbAmount;
        private TextBox tbPrice;
        private TextBox tbName;
        private Button addImBttn;
        private ComboBox comboBox1;
        private Button bttnAddType;
    }
}