
using ManagerClient.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerClient
{
    public partial class AddNewCashierForm : Form
    {

        MyClient _cl;
        public AddNewCashierForm(MyClient cl)
        {
            InitializeComponent();
            _cl = cl;
        }

        

        private async void bttnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbEmail.Text) != true && string.IsNullOrEmpty(tbName.Text) != true&& string.IsNullOrEmpty(tbEmail.Text)!=true&& string.IsNullOrEmpty(tbPhoneN.Text) != true)
                {
                    Cashier cashier = new Cashier() { FirstName = tbName.Text, SecondName = tbSName.Text, Email = tbEmail.Text, PhoneN = tbPhoneN.Text};
                    await _cl.AddCashierToDB(cashier);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please Fill The Fields");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
