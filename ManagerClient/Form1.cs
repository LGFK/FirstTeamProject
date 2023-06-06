using ManagerClient;
using System.Diagnostics;

namespace ManagerClient
{
    public partial class Form1 : Form
    {
        MyClient _cl;
        public Form1()
        {
            LoginForm lf = new LoginForm();
            
            if(lf.ShowDialog() == DialogResult.OK)
            {
                InitializeComponent();
            }
            else
            {
                InitializeComponent();
                Process.GetCurrentProcess().Kill();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _cl = new MyClient();
        }

        private void customersBttn_Click(object sender, EventArgs e)
        {
            CustomerForm frm = new CustomerForm(_cl);
            frm.ShowDialog();
        }

        private void productsBttn_Click(object sender, EventArgs e)
        {
            ProductsForm frm = new ProductsForm(_cl);
            frm.ShowDialog();
        }

        private void cashiersBttn_Click(object sender, EventArgs e)
        {
            CashiersForm frm = new CashiersForm(_cl);
            frm.ShowDialog();
        }

        private void bttnAddMngr_Click(object sender, EventArgs e)
        {
            var frm = new ManagerRegForm(_cl);
            frm.ShowDialog();
        }
    }
}