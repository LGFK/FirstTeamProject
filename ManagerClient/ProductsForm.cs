

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ManagerClient
{
    public partial class ProductsForm : Form
    {
        MyClient _cl;
        public ProductsForm(MyClient cl)
        {
            InitializeComponent();
           _cl = cl;
           
        }

        public async void FillProds()
        {
            lV1.Clear();
            ColumnHeader ch1 = new ColumnHeader();
            ColumnHeader ch2 = new ColumnHeader();
            ColumnHeader ch3 = new ColumnHeader();
            ColumnHeader ch4 = new ColumnHeader();
            ColumnHeader ch5 = new ColumnHeader();
            ch1.Name = "idColumn";
            ch1.Text = "ID";
            ch1.Width = 30;
            lV1.Columns.Add(ch1);
            ch2.Name = "nameColumn";
            ch2.Text = "Name";
            ch2.Width = 125;
            lV1.Columns.Add(ch2);
            ch3.Name = "TypeColumn";
            ch3.Text = "Type";
            ch3.Width = 125;
            lV1.Columns.Add(ch3);
            ch4.Name = "AmountColumn";
            ch4.Text = "Amount";
            ch4.Width = 100;
            lV1.Columns.Add(ch4);
            ch5.Name = "DiscountColumn";
            ch5.Text = "Discount";
            ch5.Width = 100;
            lV1.Columns.Add(ch5);

            var products = Task.Run(()=>_cl.GetAllProducts()).Result;
            foreach (var product in products)
            {
                ListViewItem lvItem = new ListViewItem(product.Id.ToString());
                lvItem.SubItems.Add(product.Pname);
                lvItem.SubItems.Add(await _cl.GetTypeById((int)product.ProdType));
                lvItem.SubItems.Add(product.Amount.ToString());
                if (String.IsNullOrEmpty(product.Discount.ToString())) 
                {
                    lvItem.SubItems.Add("0");
                }
                else
                {
                    lvItem.SubItems.Add(product.Discount.ToString());
                }
                
                lV1.Items.Add(lvItem);
            }

        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            FillProds();
        }

        private void addPrdctBttn_Click(object sender, EventArgs e)
        {
            AddNewProductForm frm = new AddNewProductForm(_cl);
            frm.ShowDialog();
            FillProds();
        }

        private async  void discountBttn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbDiscount.Text)!=true)
            {
                try
                {
                    int discount = Int32.Parse(tbDiscount.Text);
                    var items = lV1.SelectedItems;
                    List<int> ids = new List<int>();
                    for (int i = 0; i < items.Count; i++)
                    {
                        ids.Add(Int32.Parse(items[i].Text));

                    }
                    await _cl.SetDiscount(discount, ids);

                    FillProds();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
            
        }
    }
}
