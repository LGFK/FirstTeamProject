
using ManagerClient.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerClient
{
    public partial class AddNewCustommerForm : Form
    {
        MyClient _cl;
        public AddNewCustommerForm(MyClient cl)
        {
            InitializeComponent();
            _cl = cl;
            
        }

        private async void bttnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbEmail.Text) != true && string.IsNullOrEmpty(tbName.Text) != true)
                {
                    Customer cust = new Customer() { FirstName = tbName.Text, SecondName = tbSName.Text };
                    if (string.IsNullOrEmpty(tbSName.Text) != true)
                    {
                        cust.Email = tbEmail.Text;
                    }
                    if (string.IsNullOrEmpty(tbPhoneN.Text) != true)
                    {
                        cust.PhoneN = tbPhoneN.Text;
                    }
                    await _cl.AddClientToDB(cust);

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

        private void tbSName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbPhoneN_TextChanged(object sender, EventArgs e)
        {

        }

        private void nameLbl_Click(object sender, EventArgs e)
        {

        }

        private void pnLbl_Click(object sender, EventArgs e)
        {

        }

        private void mailLbl_Click(object sender, EventArgs e)
        {

        }

        private void secondNLbl_Click(object sender, EventArgs e)
        {

        }

        private void titleLbl_Click(object sender, EventArgs e)
        {

        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
