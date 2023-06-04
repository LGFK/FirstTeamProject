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
    public partial class AddNewTypeForm : Form
    {
        MyClient _cl;
        public AddNewTypeForm( MyClient cl)
        {
            InitializeComponent();
            _cl = cl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbType.Text)!=true)
            {
                _cl.AddProductType(tbType.Text);
                this.Close();
                    
            }    
            
        }
    }
}
