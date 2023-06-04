
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagerClient.Model;
using Newtonsoft.Json;

namespace ManagerClient
{
    public partial class CustomerForm : Form
    {

        MyClient _cl;
        public CustomerForm(MyClient cl)
        {
            InitializeComponent();
            
            _cl = cl;
            FillWithCustomers();

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
            List<Customer> _custs = await _cl.GetAllCustomers();
            foreach (Customer customer in _custs)
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
           
        }

        private async void deleteFromDbBttn_Click(object sender, EventArgs e)
        {
            _cl.DeleteCustomer(Int32.Parse(lV1.SelectedItems[0].Text));
            FillWithCustomers();
        }

        private void addNewBttn_Click(object sender, EventArgs e)
        {
            AddNewCustommerForm frm = new AddNewCustommerForm(_cl);
            frm.ShowDialog();
            FillWithCustomers();
        }

        
    }
}
