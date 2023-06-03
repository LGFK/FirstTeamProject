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
    public partial class AddNewCashierForm : Form
    {

        VendorSysDb _db;
        public AddNewCashierForm(VendorSysDb _db)
        {
            InitializeComponent();
            this._db = _db;
        }
    }
}
