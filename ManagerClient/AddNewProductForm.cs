using ManagerClient.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerClient
{
    public partial class AddNewProductForm : Form
    {
        string path;
        MyClient _cl;
        public AddNewProductForm(MyClient cl)
        {
            InitializeComponent();
            _cl = cl;
            FillComboBoxTypes();
            if(comboBox1.Items.Count>0)
            {
                comboBox1.SelectedIndex = 0;
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "img |*.img|jpg|*.jpg|png|*.png";
            ofd.ShowDialog();
            path = ofd.FileName;
        }

        public void FillComboBoxTypes()
        {
            var prTList = _cl.GetProductsType();
            comboBox1.Items.Clear();
            for (int i = 0; i < prTList.Count; i++)
            {
                comboBox1.Items.Add($"{prTList[i].Id}:{prTList[i].TypeName}");
            }
        }
        private async void bttnAdd_Click(object sender, EventArgs e)
        {
            
            if(string.IsNullOrEmpty(tbAmount.Text)!=true&& string.IsNullOrEmpty(tbName.Text) != true&& string.IsNullOrEmpty(tbPrice.Text) != true&&string.IsNullOrEmpty(path)!=true)
            {
                try
                {
                    var prodTypeId = Int32.Parse(comboBox1.SelectedItem.ToString().Split(':')[0]);
                    Image img = Image.FromFile(path);
                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, ImageFormat.Png);
                    var reqBytes = ms.ToArray();
                    
                    var prToAdd = new Product()
                    {
                        Pname = tbName.Text,
                        Amount = Int32.Parse(tbAmount.Text),
                        Price = Int32.Parse(tbPrice.Text),
                        ProdType = prodTypeId,
                        
                    };
                    
                    _cl.AddProduct(prToAdd,img, ".png");
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var frm = new AddNewTypeForm(_cl);
            frm.ShowDialog();
            FillComboBoxTypes();
        }
    }
}
