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
            /*customers = new List<Customer>();
            cashiers = new List<Cashier>();
            receipt = new Receipt();
            receiptProducts = new List<Product>();
            products = new List<Product>();*/

        }
        //List<Customer>customers;
        //List<Cashier> cashiers;
        //Receipt receipt;
        //List<Product> receiptProducts;
        //List<Product> products;
        //string productType;

        string jsonToReceive;
        byte[] requestToReceive;
        byte[] buffer;
        int respSize;

        //public List<Customer> Customers
        //{
        //    get { return customers; } 
        //    set { customers = value; }
        //}
        //public List<Cashier> Cashiers
        //{
        //    get { return cashiers; }
        //    set { cashiers = value; }
        //}
        //public Receipt Receipt
        //{
        //    get { return receipt; }
        //    set { receipt = value; }
        //}
        //public List<Product> ReceiptProducts
        //{
        //    get { return receiptProducts; }
        //    set { receiptProducts = value; }
        //}
        //public List<Product> Products 
        //{ 
        //    get { return products; } 
        //    set { products = value; }
        //}

        //public string ProductType
        //{
        //    get { return productType; }
        //    set { productType = value; }
        //}

        public async Task<List<Customer>> GetCustomersAsync()
        {
            try
            {
                var endPoint = new IPEndPoint(IPAddress.Loopback, 1488);
                TcpClient client = new TcpClient();
                client.Connect(endPoint);

                var networkStream = client.GetStream();
                buffer = new byte[4];
                string message = "Customers";
                var requestMessage = Encoding.UTF8.GetBytes(message);
                buffer = BitConverter.GetBytes(requestMessage.Length);
                await networkStream.WriteAsync(buffer, 0, buffer.Length);
                await networkStream.WriteAsync(requestMessage, 0, requestMessage.Length);

                await networkStream.ReadAsync(buffer, 0, buffer.Length);
                respSize = BitConverter.ToInt32(buffer, 0);

                requestToReceive = new byte[respSize];
                await networkStream.ReadAsync(requestToReceive, 0, requestToReceive.Length);
                jsonToReceive = Encoding.UTF8.GetString(requestToReceive);
                List<Customer>? customers = new List<Customer>();
                customers = JsonConvert.DeserializeObject<List<Customer>>(jsonToReceive);
                client.Close();
                /*foreach (var item in customers)
                {
                    Customers.Add(new Customer(item.Id, item.FirstName, item.SecondName, item.Email, item.PhoneN, item.Receipts));
                }*/
                return await Task.FromResult(customers ??new List<Customer>());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            throw new Exception();
        }
        public async Task<List<Cashier>> GetCashiersAsync()
        {
            try
            {
                var endPoint = new IPEndPoint(IPAddress.Loopback, 1488);
                TcpClient client = new TcpClient();
                client.Connect(endPoint);

                var networkStream = client.GetStream();
                buffer = new byte[4];
                string message = "Cashiers";
                var requestMessage = Encoding.UTF8.GetBytes(message);
                buffer = BitConverter.GetBytes(requestMessage.Length);
                await networkStream.WriteAsync(buffer, 0, buffer.Length);
                await networkStream.WriteAsync(requestMessage, 0, requestMessage.Length);

                await networkStream.ReadAsync(buffer, 0, buffer.Length);
                respSize = BitConverter.ToInt32(buffer, 0);

                requestToReceive = new byte[respSize];
                await networkStream.ReadAsync(requestToReceive, 0, requestToReceive.Length);
                jsonToReceive = Encoding.UTF8.GetString(requestToReceive);
                List<Cashier>? cashiers = new List<Cashier>();
                cashiers = JsonConvert.DeserializeObject<List<Cashier>>(jsonToReceive);
                client.Close();
                /*List<Cashier> _cashiers = new List<Cashier>();
                foreach (var item in cashiers)
                {
                    _cashiers.Add(new Cashier(item.Id, item.FirstName, item.SecondName,
                        item.Email, item.PhoneN, item.IsFired, item.Receipts));
                }*/
                return await Task.FromResult(cashiers??new List<Cashier>());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            throw new Exception();
        }
        public async Task<(Receipt,List<Product>)> GetReceiptsAsync(int id)
        {
            try
            {
                
                var endPoint = new IPEndPoint(IPAddress.Loopback, 1488);
                TcpClient client = new TcpClient();
                client.Connect(endPoint);

                var networkStream = client.GetStream();
                buffer = new byte[4];
                string message = $"Receipts<|>{id}";
                var requestMessage = Encoding.UTF8.GetBytes(message);
                buffer = BitConverter.GetBytes(requestMessage.Length);
                await networkStream.WriteAsync(buffer, 0, buffer.Length);
                await networkStream.WriteAsync(requestMessage, 0, requestMessage.Length);

                buffer = new byte[4];
                await networkStream.ReadAsync(buffer, 0, buffer.Length);
                respSize = BitConverter.ToInt32(buffer, 0);
                requestToReceive = new byte[respSize];
                await networkStream.ReadAsync(requestToReceive, 0, requestToReceive.Length);
                jsonToReceive = Encoding.UTF8.GetString(requestToReceive);
                var receipt = JsonConvert.DeserializeObject<Receipt>(jsonToReceive);

                buffer = new byte[4];
                await networkStream.ReadAsync(buffer, 0, buffer.Length);
                respSize = BitConverter.ToInt32(buffer, 0);
                requestToReceive = new byte[respSize];
                await networkStream.ReadAsync(requestToReceive, 0, requestToReceive.Length);
                jsonToReceive = Encoding.UTF8.GetString(requestToReceive);
                var receiptProducts = JsonConvert.DeserializeObject<List<Product>>(jsonToReceive);
                client.Close();

                /*Receipt = receipt;
                foreach (var item in receiptProducts)
                {
                    ReceiptProducts.Add(new Product(item.Id, item.Pname, item.Price,
                        item.Amount, item.ProdType, item.Image, item.Discount,
                        item.ProdTypeNavigation, item.ProductsSolds));
                }
                var _receiptProducts = (receipt, receiptProducts);*/
                return await Task.FromResult((receipt??new Receipt(),receiptProducts??new List<Product>()));
                /*foreach (var item in ReceiptProducts)
                {
                    MessageBox.Show($"Id{item.Id}" +
                        $"\nPname: {item.Pname}" +
                        $"\n{item.Price}" +
                        $"\n{item.Amount}" +
                        $"\n{item.ProdType}");
                }*/
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            throw new Exception();
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            try
            {
                var endPoint = new IPEndPoint(IPAddress.Loopback, 1488);
                TcpClient client = new TcpClient();
                client.Connect(endPoint);

               
                var networkStream = client.GetStream();
                buffer = new byte[4];
                string message = "Products";
                var requestMessage = Encoding.UTF8.GetBytes(message);
                buffer = BitConverter.GetBytes(requestMessage.Length);
                await networkStream.WriteAsync(buffer, 0, buffer.Length);
                await networkStream.WriteAsync(requestMessage, 0, requestMessage.Length);

                await networkStream.ReadAsync(buffer, 0, buffer.Length);
                respSize = BitConverter.ToInt32(buffer, 0);

                requestToReceive = new byte[respSize];
                await networkStream.ReadAsync(requestToReceive, 0, requestToReceive.Length);
                jsonToReceive = Encoding.UTF8.GetString(requestToReceive);
                List<Product>? products = new List<Product>();
                products = JsonConvert.DeserializeObject<List<Product>>(jsonToReceive)??new List<Product>();
                client.Close();
                /*var _products = new List<Product>();
                foreach (var item in products)
                {
                    _products.Add(new Product(item.Id, item.Pname, item.Price,
                        item.Amount, item.ProdType, item.Image, item.Discount,
                        item.ProdTypeNavigation, item.ProductsSolds));
                }

                Products = products;
                ObservableCollection<Product> productCollection = new ObservableCollection<Product>();
                foreach (var item in products)
                {
                    productCollection.Add(item);
                }*/

                return await Task.FromResult(products);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            throw new Exception();
        }
        public async Task<List<Product>> GetDiscountProductsAsync()
        {
            try
            {
                var endPoint = new IPEndPoint(IPAddress.Loopback, 1488);
                TcpClient client = new TcpClient();
                client.Connect(endPoint);


                var networkStream = client.GetStream();
                buffer = new byte[4];
                string message = "Products";
                var requestMessage = Encoding.UTF8.GetBytes(message);
                buffer = BitConverter.GetBytes(requestMessage.Length);
                await networkStream.WriteAsync(buffer, 0, buffer.Length);
                await networkStream.WriteAsync(requestMessage, 0, requestMessage.Length);

                await networkStream.ReadAsync(buffer, 0, buffer.Length);
                respSize = BitConverter.ToInt32(buffer, 0);

                requestToReceive = new byte[respSize];
                await networkStream.ReadAsync(requestToReceive, 0, requestToReceive.Length);
                jsonToReceive = Encoding.UTF8.GetString(requestToReceive);
                List<Product>? products = new List<Product>();
                products = JsonConvert.DeserializeObject<List<Product>>(jsonToReceive);
                client.Close();
                /*foreach (var item in products)
                {
                    if (item.Discount > 0)
                    {
                        Products.Add(new Product(item.Id, item.Pname, item.Price,
                        item.Amount, item.ProdType, item.Image, item.Discount,
                        item.ProdTypeNavigation, item.ProductsSolds));
                    }
                }*/
                var productsWithDiscount = new List<Product>();
                productsWithDiscount = products?.Where(item => item.Discount > 0).ToList() ?? new List<Product>();
                return await Task.FromResult(productsWithDiscount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            throw new Exception();
        }

        public async Task<string> GetProductTypeAsync(int id)
        {
            try
            {
                var endPoint = new IPEndPoint(IPAddress.Loopback, 1488);
                TcpClient client = new TcpClient();
                client.Connect(endPoint);


                var networkStream = client.GetStream();
                buffer = new byte[4];
                string message = $"ProductType<|>{id}";
                var requestMessage = Encoding.UTF8.GetBytes(message);
                buffer = BitConverter.GetBytes(requestMessage.Length);
                await networkStream.WriteAsync(buffer, 0, buffer.Length);
                await networkStream.WriteAsync(requestMessage, 0, requestMessage.Length);


                buffer = new byte[4];
                await networkStream.ReadAsync(buffer, 0, buffer.Length);
                respSize = BitConverter.ToInt32(buffer, 0);
                requestToReceive = new byte[respSize];
                await networkStream.ReadAsync(requestToReceive, 0, requestToReceive.Length);
                string productType = Encoding.UTF8.GetString(requestToReceive);
                client.Close();
                return await Task.FromResult(productType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            throw new Exception();
        }

        public async Task SendNewReceiptAsync(Receipt receipt,List<(Product,int amount)> productsAmount)
        {
            var endPoint = new IPEndPoint(IPAddress.Loopback, 1488);
            TcpClient client = new TcpClient();
            client.Connect(endPoint);

            var networkStream = client.GetStream();
            buffer = new byte[4];
            (Receipt, List<(Product, int)>) receiptProductsAmount = (receipt,productsAmount);
            string message = $"AddReceipt<|>{receiptProductsAmount}";
            var requestMessage = Encoding.UTF8.GetBytes(message);
            buffer = BitConverter.GetBytes(requestMessage.Length);
            await networkStream.WriteAsync(buffer, 0, buffer.Length);
            await networkStream.WriteAsync(requestMessage, 0, requestMessage.Length);
        }

    }
}
