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
    public partial class AddNewCustommerForm : Form
    {
        VendorSysDb _db;
        public AddNewCustommerForm(VendorSysDb db)
        {
            InitializeComponent();
            _db = db;
        }

        private async void bttnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbEmail.Text) != true && string.IsNullOrEmpty(tbName.Text) != true)
                {
                    Customer cust = new Customer() { FirstName = tbName.Text, SecondName = tbEmail.Text };
                    if(string.IsNullOrEmpty(tbSName.Text)!=true)
                    {
                        cust.Email = tbSName.Text;
                    }
                    if(string.IsNullOrEmpty(tbPhoneN.Text)!=true)
                    {
                        cust.PhoneN = tbPhoneN.Text;
                    }
                    await _db.AddCustomer(cust);
                    
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please Fill The Fields");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
