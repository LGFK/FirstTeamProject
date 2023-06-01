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
    public static class ProductsSoldRepository
    {
        private static ObservableCollection<ProductsSold>? productsSolds;

        public static ObservableCollection<ProductsSold>? ProductsSolds
        {
            get
            {
                if (productsSolds == null)
                    productsSolds = ReadProductRepository();
                return productsSolds;
            }
        }

        public static ObservableCollection<ProductsSold>? ReadProductRepository()
        {
            ObservableCollection<ProductsSold>? ProductsSolds = new ObservableCollection<ProductsSold>();

            // в колекцію "ProductsSolds" отримати ProductsSold від сервера. 

            return ProductsSolds;
        }
    }
}
