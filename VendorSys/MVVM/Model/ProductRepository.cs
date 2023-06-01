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
    public static class ProductRepository
    {
        private static ObservableCollection<Product>? products;

        public static ObservableCollection<Product>? Products
        {
            get
            {
                if (products == null)
                    products = ReadProductRepository();
                return products;
            }
        }

        public static ObservableCollection<Product>? ReadProductRepository()
        {
            ObservableCollection<Product>? Products = new ObservableCollection<Product>();

            // в колекцію "Products" отримати продукти від сервера.
            Products.Add(new Product(1, "Apple", 200, 5, 1, "image1.jpg", 0, new ProductType(), new List<ProductsSold>()));
            Products.Add(new Product(2, "Banana", 300, 3, 2, "image2.jpg", 25, new ProductType(), new List<ProductsSold>()));

            return Products;
        }
    }
}
