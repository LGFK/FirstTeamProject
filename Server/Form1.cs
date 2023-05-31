
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

        

        private void button1_Click(object sender, EventArgs e)
        {
            CashiersForm frm = new CashiersForm(_db);
            frm.ShowDialog();
        }

        private void customersBttn_Click(object sender, EventArgs e)
        {
            CustomerForm frm = new CustomerForm(_db);
            frm.ShowDialog();
        }

        private void productsBttn_Click(object sender, EventArgs e)
        {
            ProductsForm frm = new ProductsForm(_db);
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(@"..\..\..\DB\ConfigFiles");
            var config = new ConfigurationBuilder().SetBasePath(di.FullName).AddJsonFile("appsettings1.json").Build();
            _db = new VendorSysDb(config.GetConnectionString("MainConnectionString"));
        }
    }
}