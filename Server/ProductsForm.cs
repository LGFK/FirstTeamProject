using Microsoft.Extensions.Configuration;
using Server.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class ProductsForm : Form
    {
        VendorSysDb _db;
        public ProductsForm(VendorSysDb db)
        {
            InitializeComponent();
            _db=db;
        }

        public async void FillProds()
        {
            lV1.Clear();
            ColumnHeader ch1 = new ColumnHeader();
            ColumnHeader ch2 = new ColumnHeader();
            ColumnHeader ch3 = new ColumnHeader();
            ColumnHeader ch4 = new ColumnHeader();
            ch1.Name = "idColumn";
            ch1.Text = "ID";
            ch1.Width = 100;
            lV1.Columns.Add(ch1);
            ch2.Name = "nameColumn";
            ch2.Text = "Name";
            ch2.Width = 150;
            lV1.Columns.Add(ch2);
            ch3.Name = "TypeColumn";
            ch3.Text = "Type";
            ch3.Width = 150;
            lV1.Columns.Add(ch3);
            ch4.Name = "AmountColumn";
            ch4.Text = "Amount";
            
            ch4.Width = 100;
            lV1.Columns.Add(ch4);
            var products = await _db.GetProductsList();
            foreach (var product in products)
            {
                ListViewItem lvItem = new ListViewItem(product.Id.ToString());
                lvItem.SubItems.Add(product.Pname);
                lvItem.SubItems.Add((await _db.GetProductTypeById((int)product.ProdType)).TypeName);
                lvItem.SubItems.Add(product.Amount.ToString());
                lV1.Items.Add(lvItem);
            }
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            FillProds();
        }
    }
}
