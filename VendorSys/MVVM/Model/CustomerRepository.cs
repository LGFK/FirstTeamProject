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
    public static class CustomerRepository
    {
        private static ObservableCollection<Customer>? customers;

        public static ObservableCollection<Customer>? Customers
        {
            get
            {
                if (customers == null)
                    customers = ReadProductRepository();
                return customers;
            }
        }

        public static ObservableCollection<Customer>? ReadProductRepository()
        {
            ObservableCollection<Customer>? Customers = new ObservableCollection<Customer>();

            // в колекцію "Customers" отримати клієнтів від сервера.
            Customers.Add(new Customer(1, "John", "Wick", "john123@gmail.com", "0437231723", new List<Receipt>()));

            return Customers;
        }
    }
}
