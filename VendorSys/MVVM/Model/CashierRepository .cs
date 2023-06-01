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
    public static class CashierRepository
    {
        private static ObservableCollection<Cashier>? cashiers;

        public static ObservableCollection<Cashier>? Cashiers
        {
            get
            {
                if (cashiers == null)
                    cashiers = ReadProductRepository();
                return cashiers;
            }
        }

        public static ObservableCollection<Cashier>? ReadProductRepository()
        {
            ObservableCollection<Cashier>? Cashiers = new ObservableCollection<Cashier>();

            // в колекцію "Cashiers" отримати касирів від сервера.
            Cashiers.Add(new Cashier(1, "John", "Wick", "john123@gmail.com", "0437231723", false, new List<Receipt>()));

            return Cashiers;
        }
    }
}
