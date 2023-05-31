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
    public partial class CustomerForm : Form
    {
        VendorSysDb _db;
        public CustomerForm(VendorSysDb db)
        {
            InitializeComponent();
            _db = db;   
        }

        public async void FillWithCustomers()
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
            ch2.Text = "First Name";
            ch2.Width = 150;
            lV1.Columns.Add(ch2);
            ch3.Name = "sNameColumn";
            ch3.Text = "Second Name";
            ch3.Width = 100;
            lV1.Columns.Add(ch3);
            ch4.Name = "emailColumn";
            ch4.Text = "E-mail";
            ch4.Width = 150;
            lV1.Columns.Add(ch4);
            var customers = await _db.GetCustomers();
            foreach (var customer in customers)
            {
                ListViewItem lvItem = new ListViewItem(customer.Id.ToString());
                lvItem.SubItems.Add(customer.FirstName);
                lvItem.SubItems.Add(customer.SecondName);
                lvItem.SubItems.Add(customer.Email);
                lV1.Items.Add(lvItem);
            }
        }
        private void CustomerForm_Load(object sender, EventArgs e)
        {
           
            FillWithCustomers();
            
        }
    }
}
