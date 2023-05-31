
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.ApplicationServices;
using Server.DB;

namespace Server
{
    public partial class Form1 : Form
    {
        
        VendorSysDb _db;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(@"..\..\..\DB\ConfigFiles");
            var config = new ConfigurationBuilder().SetBasePath(di.FullName).AddJsonFile("appsettings1.json").Build();
            _db = new VendorSysDb(config.GetConnectionString("MainConnectionString"));
            cB1.Items.Add("Products");
            cB1.Items.Add("Cashiers");
            cB1.Items.Add("Customers");
            FillWithCashiers();
            cB1.SelectedIndex = 0;

        }

        public async void FillWithCustomers()
        {

        }
        public async void FillWithCashiers()
        {
            lV1.Clear();
            ColumnHeader ch1 = new ColumnHeader();
            ColumnHeader ch2 = new ColumnHeader();
            ColumnHeader ch3 = new ColumnHeader();
            ColumnHeader ch4 = new ColumnHeader();
            ch1.Name = "idColumn";
            ch1.Text = "ID";
            ch1.Width = 40;
            lV1.Columns.Add(ch1);
            ch2.Name = "nameColumn";
            ch2.Text = "First Name";
            ch2.Width = 300;
            lV1.Columns.Add(ch2);
            ch3.Name = "sNameColumn";
            ch3.Text = "Second Name";
            ch3.Width = 300;
            lV1.Columns.Add(ch3);
            ch4.Name = "firedColumn";
            ch4.Text = "Fired";
            ch4.Width = 40;
            lV1.Columns.Add(ch4);
            var cashiers = await _db.GetCashiers();
            foreach (var cashier in cashiers)
            {
                ListViewItem lvItem = new ListViewItem(cashier.Id.ToString());
                lvItem.SubItems.Add(cashier.FirstName);
                lvItem.SubItems.Add(cashier.SecondName);
                if(cashier.IsFired==true)
                {
                    lvItem.SubItems.Add("+");
                }
                else
                {
                    lvItem.SubItems.Add("-");
                }
                
                lV1.Items.Add(lvItem);
            }
        }

        
    }
}