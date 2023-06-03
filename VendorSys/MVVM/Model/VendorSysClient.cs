using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Windows.Documents;
using System.Threading;
using System.Windows;

namespace VendorSys.MVVM.Model
{
    internal class VendorSysClient
    {
        public VendorSysClient()
        {
            products = new List<Product>();
        }
        List<Product> products;
        public List<Product> Products { 
            get { return products; } 
            set { products = value; }
        }
        public async Task GetProductsAsync()
        {
            try
            {
                
                var endPoint = new IPEndPoint(IPAddress.Loopback, 1488);
                TcpClient client = new TcpClient();
                client.Connect(endPoint);

                string jsonToReceive;
                byte[] requestToReceive;
                var networkStream = client.GetStream();
                byte[] buffer = new byte[4];
                string message = "Products";
                var requestMessage = Encoding.UTF8.GetBytes(message);
                buffer = BitConverter.GetBytes(requestMessage.Length);
                await networkStream.WriteAsync(buffer, 0, buffer.Length);
                await networkStream.WriteAsync(requestMessage, 0, requestMessage.Length);

                await networkStream.ReadAsync(buffer, 0, buffer.Length);
                int respSize = BitConverter.ToInt32(buffer, 0);

                requestToReceive = new byte[respSize];
                await networkStream.ReadAsync(requestToReceive, 0, requestToReceive.Length);
                jsonToReceive = Encoding.UTF8.GetString(requestToReceive);
                List<Product>? products = new List<Product>();
                products = JsonConvert.DeserializeObject<List<Product>>(jsonToReceive);
                client.Close();
                foreach (var item in products)
                {
                    Products.Add(new Product(item.Id, item.Pname, item.Price,
                        item.Amount, item.ProdType, item.Image, item.Discount,
                        new ProductType(), new List<ProductsSold>()));
                }
                //Products = products;
                //ObservableCollection<Product> productCollection = new ObservableCollection<Product>();
                //foreach (var item in products)
                //{
                //    productCollection.Add(item);
                //}

                //return products;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
