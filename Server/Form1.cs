
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.ApplicationServices;
using Server.DB;

namespace Server
{
    public partial class Form1 : Form
    {
        VendorSysServer _server;
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
            this.Icon = new Icon(@"..\..\..\Icon\serverIco.ico");
        }

        private async void serverStart_Click(object sender, EventArgs e)
        {
            _server = new VendorSysServer();
            _server.StartServer();
            AcceptClients();
            serverStart.Enabled = false;
            serverStart.BackColor= Color.Green;
        }

        private void AcceptClients()
        {
            _ = _server.GetConnection();
        }
    }
}