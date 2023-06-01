using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VendorSys.MVVM.Model
{
    public static class ReceiptRepository
    {
        private static ObservableCollection<Receipt>? receipts;

        public static ObservableCollection<Receipt>? Receipts
        {
            get
            {
                if (receipts == null)
                    receipts = ReadProductRepository();
                return receipts;
            }
        }

        public static ObservableCollection<Receipt>? ReadProductRepository()
        {
            ObservableCollection<Receipt>? Receipts = new ObservableCollection<Receipt>();

            // в колекцію "Receipts" отримати чеки від сервера. 

            return Receipts;
        }
    }
}
