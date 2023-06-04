﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Server.DB;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    internal class VendorSysServer
    {
        TcpListener tcpListener;
        VendorSysDb db;
        public VendorSysServer()
        {
            tcpListener = new TcpListener(IPAddress.Any, 1488);
            DirectoryInfo di = new DirectoryInfo(@"..\..\..\DB\ConfigFiles");
            var config = new ConfigurationBuilder().SetBasePath(di.FullName).AddJsonFile("appsettings1.json").Build();
            db = new VendorSysDb(config.GetConnectionString("MainConnectionString"));
        }

        public void StartServer()
        {
            tcpListener.Start();
        }
        public async Task GetConnection()
        {
            try
            {
                while (true)
                {
                    var _client = await tcpListener.AcceptTcpClientAsync();
                    _ = HandleConnectionAsync(_client);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task HandleConnectionAsync(TcpClient _client)
        {
            if (_client.Connected)
            {
                try
                {
                    string jsonToSend;
                    byte[] responseToSend;
                    var networkStream = _client.GetStream();
                    byte[] buffer = new byte[4];
                    await networkStream.ReadAsync(buffer, 0, buffer.Length);
                    int reqSize = BitConverter.ToInt32(buffer, 0);
                    buffer = new byte[reqSize];
                    await networkStream.ReadAsync(buffer, 0, reqSize);
                    var reqStr = Encoding.UTF8.GetString(buffer).Split("<|>");
                    switch (reqStr[0])
                    {
                        case "Customers":
                            {
                                var _customers = await db.GetCustomers();

                                jsonToSend = JsonConvert.SerializeObject(_customers, Formatting.Indented);
                                responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
                                buffer = BitConverter.GetBytes(responseToSend.Length);
                                MessageBox.Show(responseToSend.Length.ToString());
                                await networkStream.WriteAsync(buffer, 0, 4);
                                await networkStream.WriteAsync(responseToSend, 0, responseToSend.Length);
                                break;
                            }
                        case "Cashiers":
                            {
                                var _cashiers = await db.GetCashiers();

                                jsonToSend = JsonConvert.SerializeObject(_cashiers, Formatting.Indented);

                                responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
                                buffer = BitConverter.GetBytes(responseToSend.Length);
                                await networkStream.WriteAsync(buffer, 0, buffer.Length);
                                await networkStream.WriteAsync(responseToSend, 0, responseToSend.Length);
                                break;
                            }
                        case "Receipts":
                            {

                                var id = Int32.Parse(reqStr[1]);
                                var _receipt = await db.GetConcreeteReceiptById(id);
                                //MessageBox.Show(_receipt._receipt.TotalPrice.ToString());
                                jsonToSend = JsonConvert.SerializeObject(_receipt._receipt);
                                responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
                                buffer = BitConverter.GetBytes(responseToSend.Length);
                                await networkStream.WriteAsync(buffer, 0, buffer.Length);
                                await networkStream.WriteAsync(responseToSend, 0, responseToSend.Length);
                                jsonToSend = JsonConvert.SerializeObject(_receipt._prodsInReceipt);
                                responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
                                buffer = BitConverter.GetBytes(responseToSend.Length);
                                await networkStream.WriteAsync(buffer, 0, buffer.Length);
                                await networkStream.WriteAsync(responseToSend, 0, responseToSend.Length);
                                break;
                            }
                        case "Products":
                            {
                                var _products = await db.GetProductsList();

                                jsonToSend = JsonConvert.SerializeObject(_products, Formatting.Indented);
                                responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
                                buffer = BitConverter.GetBytes(responseToSend.Length);
                                await networkStream.WriteAsync(buffer, 0, buffer.Length);
                                await networkStream.WriteAsync(responseToSend, 0, responseToSend.Length);
                                break;
                            }
                        case "ProductType":
                            {
                                int id = Int32.Parse(reqStr[1]);
                                var _pType = await db.GetProductTypeById(id);

                                responseToSend = Encoding.UTF8.GetBytes(_pType);
                                buffer = BitConverter.GetBytes(responseToSend.Length);
                                await networkStream.WriteAsync(buffer, 0, buffer.Length);
                                await networkStream.WriteAsync(responseToSend, 0, responseToSend.Length);
                                break;
                            }
                        case "AddCustomer":
                            {
                                buffer = new byte[4];
                                await networkStream.ReadAsync(buffer, 0, buffer.Length);
                                reqSize = BitConverter.ToInt32(buffer, 0);
                                buffer = new byte[reqSize];
                                await networkStream.ReadAsync(buffer, 0, buffer.Length);
                                reqStr[1] = Encoding.UTF8.GetString(buffer);
                                Customer custToSave = JsonConvert.DeserializeObject<Customer>(reqStr[1]);
                                db.AddCustomer(custToSave);
                                break;
                            }
                        case "AddReceipt":
                            {
                                //buffer = new byte[4];
                                //await networkStream.ReadAsync(buffer, 0, buffer.Length);
                                //reqSize = BitConverter.ToInt32(buffer, 0);
                                //buffer = new byte[reqSize];
                                //await networkStream.ReadAsync(buffer, 0, buffer.Length);
                                //reqStr[1] = Encoding.UTF8.GetString(buffer);
                                (Receipt, List<(Product, int amount)>) receiptToSave = JsonConvert.DeserializeObject<(Receipt, List<(Product, int amount)>)>(reqStr[1]);
                                db?.AddReceipt(receiptToSave.Item1, receiptToSave.Item2);
                                MessageBox.Show($"{receiptToSave.Item1.Date}");
                                break;
                            }
                        case "DeleteCust":
                            {
                                int id = Int32.Parse(reqStr[1]);
                                db.DelCustomer(id);
                                break;
                            }


                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "Server");
                }

            }



        }


    }
}
