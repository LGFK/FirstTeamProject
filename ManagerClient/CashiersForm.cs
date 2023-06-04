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
    
    public partial class CashiersForm : Form
    {
        MyClient _cl;
        public CashiersForm(MyClient cl)
        {
            InitializeComponent();
            _cl = cl;
        }

        public async void FillWithCashiers()
        {
            lV1.Clear();
            ColumnHeader ch1 = new ColumnHeader();
            ColumnHeader ch2 = new ColumnHeader();
            ColumnHeader ch3 = new ColumnHeader();
            ColumnHeader ch4 = new ColumnHeader();
            ColumnHeader ch5 = new ColumnHeader();
            ColumnHeader ch6 = new ColumnHeader();
            ch1.Name = "idColumn";
            ch1.Text = "ID";
            ch1.Width = 30;
            lV1.Columns.Add(ch1);
            ch2.Name = "nameColumn";
            ch2.Text = "First Name";
            ch2.Width = 100;
            lV1.Columns.Add(ch2);
            ch3.Name = "sNameColumn";
            ch3.Text = "Second Name";
            ch3.Width = 100;
            lV1.Columns.Add(ch3);
            ch4.Name = "EmailColumn";
            ch4.Text = "Email";
            ch4.Width = 100;
            lV1.Columns.Add(ch4);
            ch5.Name = "phoneNColumn";
            ch5.Text = "Phone";
            ch5.Width = 100;
            lV1.Columns.Add(ch5);
            ch6.Name = "firedColumn";
            ch6.Text = "Fired";
            ch6.Width = 50;
            lV1.Columns.Add(ch6);
            var cashiers = await _cl.GetAllCashiers();
            foreach (var cashier in cashiers)
            {
                ListViewItem lvItem = new ListViewItem(cashier.Id.ToString());
                lvItem.SubItems.Add(cashier.FirstName);
                lvItem.SubItems.Add(cashier.SecondName);
                lvItem.SubItems.Add(cashier.Email);
                lvItem.SubItems.Add(cashier.PhoneN);
                if (cashier.IsFired == true)
                {
                    lvItem.SubItems.Add("+");
                }
                else
                {
                    lvItem.SubItems.Add("-");
                }

                lV1.Items.Add(lvItem);
            }
        }

        private void CashiersForm_Load(object sender, EventArgs e)
        {
            
            FillWithCashiers();
        }

        private void createNewBttn_Click(object sender, EventArgs e)
        {
            AddNewCashierForm frm = new AddNewCashierForm(_cl);
            frm.ShowDialog();
            FillWithCashiers();
        }

        private void fireBttn_Click(object sender, EventArgs e)
        {
            _cl.FireCashierById(Int32.Parse(lV1.SelectedItems[0].Text));
            FillWithCashiers();
        }
    }
}
