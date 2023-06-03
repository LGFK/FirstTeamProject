using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

            List<Product>? productsList = new List<Product>();
            VendorSysClient client = new VendorSysClient();
            //await client.GetProductsAsync();
            //productsList = ;




            // в колекцію "Products" отримати продукти від сервера.
            //_Products[0].ProdTypeNavigation = new ProductType();
            ObservableCollection<Product> productCollection = new ObservableCollection<Product>();
            foreach (var item in productsList)
            {
                productCollection.Add(new Product(item.Id, item.Pname, item.Price,
                    item.Amount, item.ProdType, item.Image, item.Discount, 
                    item.ProdTypeNavigation,item.ProductsSolds));
            }
            //Products.Add(new Product(1, "Apple", 200, 5, 1, "image1.jpg", 0, new ProductType(), new List<ProductsSold>()));
            //Products.Add(new Product(3, "Banana", 300, 3, 2, "image2.jpg", 25, new ProductType(), new List<ProductsSold>()));
            //Products.Add(new Product(4, "Banana1", 300, 3, 2, "image2.jpg", 25, new ProductType(), new List<ProductsSold>()));
            //Products.Add(new Product(5, "Banana2", 300, 3, 2, "image2.jpg", 25, new ProductType(), new List<ProductsSold>()));
            //Products.Add(new Product(6, "Banana3", 300, 3, 2, "image2.jpg", 25, new ProductType(), new List<ProductsSold>()));
            //Products.Add(new Product(7, "Banana4", 300, 3, 2, "image2.jpg", 25, new ProductType(), new List<ProductsSold>()));
            //Products.Add(new Product(8, "Banana5", 300, 3, 2, "image2.jpg", 25, new ProductType(), new List<ProductsSold>()));
            //Products.Add(new Product(9, "Banana6", 300, 3, 2, "image2.jpg", 25, new ProductType(), new List<ProductsSold>()));
            //Products.Add(new Product(10, "Banana7", 300, 3, 2, "image2.jpg", 25, new ProductType(), new List<ProductsSold>()));
            //Products.Add(new Product(11, "Banana8", 300, 3, 2, "image2.jpg", 25, new ProductType(), new List<ProductsSold>()));
            //Products.Add(new Product(12, "Banana9", 300, 3, 2, "image2.jpg", 25, new ProductType(), new List<ProductsSold>()));

            return productCollection;

        }
    }
}
