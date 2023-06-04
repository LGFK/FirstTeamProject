using ManagerClient;

namespace ManagerClient
{
    public partial class Form1 : Form
    {
        MyClient _cl;
        public Form1()
        {
            InitializeComponent();
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
    }
}