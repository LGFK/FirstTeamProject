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
    public partial class LoginForm : Form
    {
        MyClient _cl;
        public LoginForm()
        {
            _cl = new MyClient();
            InitializeComponent();
            
        }

        private async void bttnLogin_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbLogin.Text)!=true&&string.IsNullOrEmpty(tbPassword.Text)!=true)
            {
                var res = await _cl.TryLogin(tbLogin.Text, tbPassword.Text);
                if(res == true)
                {
                    this.DialogResult=DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong Password Or Login");
                }
            }
        }

        
    }
}
