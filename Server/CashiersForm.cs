using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Server.DB;

namespace Server
{
    public partial class CashiersForm : Form
    {
        VendorSysDb _db;
        public CashiersForm(VendorSysDb db)
        {
            InitializeComponent();
            _db = db; 
        }

        public async void FillWithCashiers()
        {
            lV1.Clear();
            ColumnHeader ch1 = new ColumnHeader();
            ColumnHeader ch2 = new ColumnHeader();
            ColumnHeader ch3 = new ColumnHeader();
            ColumnHeader ch4 = new ColumnHeader();
            ch1.Name = "idColumn";
            ch1.Text = "ID";
            ch1.Width = 100;
            lV1.Columns.Add(ch1);
            ch2.Name = "nameColumn";
            ch2.Text = "First Name";
            ch2.Width = 150;
            lV1.Columns.Add(ch2);
            ch3.Name = "sNameColumn";
            ch3.Text = "Second Name";
            ch3.Width = 150;
            lV1.Columns.Add(ch3);
            ch4.Name = "firedColumn";
            ch4.Text = "Fired";
            ch4.Width = 100;
            lV1.Columns.Add(ch4);
            var cashiers = await _db.GetCashiers();
            foreach (var cashier in cashiers)
            {
                ListViewItem lvItem = new ListViewItem(cashier.Id.ToString());
                lvItem.SubItems.Add(cashier.FirstName);
                lvItem.SubItems.Add(cashier.SecondName);
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
    }
}
