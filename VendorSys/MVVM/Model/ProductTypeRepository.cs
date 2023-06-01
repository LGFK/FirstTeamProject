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
    public static class ProductTypeRepository
    {
        private static ObservableCollection<ProductType>? productTypes;

        public static ObservableCollection<ProductType>? ProductTypes
        {
            get
            {
                if (productTypes == null)
                    productTypes = ReadProductRepository();
                return productTypes;
            }
        }

        public static ObservableCollection<ProductType>? ReadProductRepository()
        {
            ObservableCollection<ProductType>? ProductTypes = new ObservableCollection<ProductType>();

            // в колекцію "ProductType" отримати ProductType від сервера. 

            return ProductTypes;
        }
    }
}
