﻿using System;
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
using System.Drawing;
using System.Windows.Markup;

namespace VendorSys.MVVM.Model
{
    internal class VendorSysClient
    {
        static List<Product> products;
        public VendorSysClient()
        { 

        }

        string jsonToReceive;
        byte[] requestToReceive;
        byte[] buffer;
        int respSize;


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

                return await Task.FromResult((receipt??new Receipt(),receiptProducts??new List<Product>()));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            throw new Exception();
        }

        public async Task<List<Receipt>> GetAllReceiptsAsync()
        {
            try
            {
                var endPoint = new IPEndPoint(IPAddress.Loopback, 1488);
                TcpClient client = new TcpClient();
                client.Connect(endPoint);

                var networkStream = client.GetStream();
                buffer = new byte[4];
                string message = $"AllReceipts";
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
                var receipts = JsonConvert.DeserializeObject<List<Receipt>>(jsonToReceive);

                client.Close();

                return await Task.FromResult(receipts ?? new List<Receipt>());
            }
            catch(Exception ex ) 
            {
                MessageBox.Show(ex.Message);
            }
            throw new Exception();
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            Thread.Sleep(1000);
            return products;
            //var endPoint = new IPEndPoint(IPAddress.Loopback, 1488);
            //TcpClient client = new TcpClient();
            //try
            //{
               
            //    client.Connect(endPoint);
            //    if(client.Connected)
            //    {
            //        var networkStream = client.GetStream();
            //        buffer = new byte[4];
            //        string message = "Products";
            //        var requestMessage = Encoding.UTF8.GetBytes(message);
            //        buffer = BitConverter.GetBytes(requestMessage.Length);
            //        networkStream.Write(buffer, 0, buffer.Length);
            //        networkStream.Write(requestMessage, 0, requestMessage.Length);

            //        networkStream.Read(buffer, 0, buffer.Length);
            //        respSize = BitConverter.ToInt32(buffer, 0);

            //        //Thread.Sleep(500);
            //        requestToReceive = new byte[respSize];
            //        networkStream.Read(requestToReceive, 0, requestToReceive.Length);
            //        jsonToReceive = Encoding.UTF8.GetString(requestToReceive);
            //        List<Product>? products = new List<Product>();
            //        products = JsonConvert.DeserializeObject<List<Product>>(jsonToReceive) ?? new List<Product>();
            //        foreach (var product in products)
            //        {
            //            var bufferSize = new byte[4];
            //            await networkStream.ReadAsync(bufferSize, 0, 4);
            //            var size = BitConverter.ToInt32(bufferSize);
            //            var data = new byte[size];
            //            await networkStream.ReadAsync(data, 0, size);
            //            product.Image = data;
            //        }
            //        Thread.Sleep(100);
            //        return products;
            //    }
                
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    return new List<Product>();
            //}
            //finally
            //{
            //    client.Close();
            //}
            //throw new Exception();
        }
        public async Task<List<Product>> GetDiscountProductsAsync()
        {
            var endPoint = new IPEndPoint(IPAddress.Loopback, 1488);
            TcpClient client = new TcpClient();
            try
            {
                
                client.Connect(endPoint);


                var networkStream = client.GetStream();
                buffer = new byte[4];
                string message = "Products";
                var requestMessage = Encoding.UTF8.GetBytes(message);
                buffer = BitConverter.GetBytes(requestMessage.Length);
                await networkStream.WriteAsync(buffer, 0, buffer.Length);
                
                await networkStream.WriteAsync(requestMessage, 0, requestMessage.Length);
                

                networkStream.Read(buffer, 0, buffer.Length);
                respSize = BitConverter.ToInt32(buffer, 0);

                //Thread.Sleep(500);
                requestToReceive = new byte[respSize];
                networkStream.Read(requestToReceive, 0, requestToReceive.Length);
                jsonToReceive = Encoding.UTF8.GetString(requestToReceive);
                List<Product>? _products = new List<Product>();
                _products = JsonConvert.DeserializeObject<List<Product>>(jsonToReceive);
                foreach (var product in _products)
                {
                    var bufferSize = new byte[4];
                    await networkStream.ReadAsync(bufferSize, 0, 4);
                    var size = BitConverter.ToInt32(bufferSize);
                    var data = new byte[size];
                    await networkStream.ReadAsync(data, 0, size);
                    product.Image = data;
                }
                Thread.Sleep(500);
                products = _products;
                var productsWithDiscount = new List<Product>();
                productsWithDiscount = _products?.Where(item => item.Discount > 0).ToList() ?? new List<Product>();
                
                return  productsWithDiscount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                client.Close();
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

        public async Task SendNewReceiptAsync(Receipt receipt,List<Product> products,List<int> amount)
        {
           
            var endPoint = new IPEndPoint(IPAddress.Loopback, 1488);
            TcpClient client = new TcpClient();
            client.Connect(endPoint);

            var networkStream = client.GetStream();
            buffer = new byte[4];
            string receiptToSend = JsonConvert.SerializeObject(receipt);
            string productsToSend = JsonConvert.SerializeObject(products);
            string amountToSend = JsonConvert.SerializeObject(amount);
            string message = $"AddReceipt<|>{receiptToSend}<|>{productsToSend}<|>{amountToSend}";
            var requestMessage = Encoding.UTF8.GetBytes(message);
            buffer = BitConverter.GetBytes(requestMessage.Length);
            await networkStream.WriteAsync(buffer, 0, buffer.Length);
            await networkStream.WriteAsync(requestMessage, 0, requestMessage.Length);
        }

        public async Task SendNewCustomerAsync(Customer customer)
        {

            var endPoint = new IPEndPoint(IPAddress.Loopback, 1488);
            TcpClient client = new TcpClient();
            client.Connect(endPoint);

            var networkStream = client.GetStream();
            buffer = new byte[4];
            string customerToSend = JsonConvert.SerializeObject(customer);
            string message = $"AddCustomer<|>{customerToSend}";
            var requestMessage = Encoding.UTF8.GetBytes(message);
            buffer = BitConverter.GetBytes(requestMessage.Length);
            await networkStream.WriteAsync(buffer, 0, buffer.Length);
            await networkStream.WriteAsync(requestMessage, 0, requestMessage.Length);
        }

    }
}
