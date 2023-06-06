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
    public partial class ManagerRegForm : Form
    {
        MyClient _cl;
        public ManagerRegForm(MyClient cl)
        {
            InitializeComponent();
            _cl = cl;
        }

        

        private async void bttnReg_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
            var respose = await _cl.RegisterNewManager(tbLogin.Text, tbPassword.Text);
            MessageBox.Show(respose);
            switch (respose)
            {
                case "Manager Added":
                    {
                        MessageBox.Show("Manager Added");
                        this.Close();
                        break;
                    }
                default:
                    {
                        MessageBox.Show(respose);
                        break;
                    }
            }
        }
    }
}
