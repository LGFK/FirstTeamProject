using Accessibility;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Server.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server
{
    internal class VendorSysServer
    {
        TcpListener tcpListener;
        VendorSysDb db;
        public VendorSysServer()
        {
            tcpListener = new TcpListener(IPAddress.Any,1488);
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
            if(_client.Connected)
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
                    string reqStr = Encoding.UTF8.GetString(buffer);
                    switch(reqStr)
                    {
                        case "Customers":
                            {
                                var _customers = await db.GetCustomers();
                                jsonToSend = JsonConvert.SerializeObject(_customers);
                                responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
                                buffer = BitConverter.GetBytes(responseToSend.Length);
                                await networkStream.WriteAsync(buffer, 0, buffer.Length);
                                await networkStream.WriteAsync(responseToSend, 0, responseToSend.Length);
                                break;
                            }
                        case "Cashiers":
                            {
                                var _cashiers = await db.GetCashiers();
                                jsonToSend = JsonConvert.SerializeObject(_cashiers);
                                responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
                                buffer = BitConverter.GetBytes(responseToSend.Length);
                                await networkStream.WriteAsync(buffer, 0, buffer.Length);
                                await networkStream.WriteAsync(responseToSend, 0, responseToSend.Length);
                                break;
                            }
                        case "Receipts":
                            {
                                byte[] receiptId = new byte[4];
                                await networkStream.ReadAsync(receiptId, 0, 4);
                                var id = BitConverter.ToInt32(receiptId,0);
                                var _receipt = await db.GetConcreeteReceiptById(id);
                                jsonToSend = JsonConvert.SerializeObject(_receipt);
                                responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
                                buffer = BitConverter.GetBytes(responseToSend.Length);
                                await networkStream.WriteAsync(buffer, 0, buffer.Length);
                                await networkStream.WriteAsync(responseToSend, 0, responseToSend.Length);
                                break;
                            }
                        case "Products":
                            {
                                var _product = await db.GetProductsList();
                                jsonToSend = JsonConvert.SerializeObject(_product);
                                responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
                                buffer = BitConverter.GetBytes(responseToSend.Length);
                                await networkStream.WriteAsync(buffer, 0, buffer.Length);
                                await networkStream.WriteAsync(responseToSend, 0, responseToSend.Length);
                                break;
                            }
                        case "ProductTypes":
                            {
                                break;
                            }
                        case "AddCustomer":
                            {
                                buffer= new byte[4];
                                await networkStream.ReadAsync(buffer, 0, buffer.Length);
                                reqSize = BitConverter.ToInt32(buffer,0);
                                buffer = new byte[reqSize];
                                await networkStream.ReadAsync(buffer,0, buffer.Length);
                                reqStr = Encoding.UTF8.GetString(buffer);
                                Customer custToSave = JsonConvert.DeserializeObject<Customer>(reqStr);
                                db.AddCustomer(custToSave);
                                break;
                            }
                        case "AddReceipt":
                            {
                                buffer = new byte[4];
                                await networkStream.ReadAsync(buffer, 0, buffer.Length);
                                reqSize = BitConverter.ToInt32(buffer, 0);
                                buffer = new byte[reqSize];
                                await networkStream.ReadAsync(buffer, 0, buffer.Length);
                                reqStr = Encoding.UTF8.GetString(buffer);
                                (Receipt,List<(Product,int amount)>) receiptToSave = JsonConvert.DeserializeObject<(Receipt, List<(Product, int amount)>)>(reqStr);
                                db.AddReceipt(receiptToSave.Item1,receiptToSave.Item2);
                                break;
                            }
                            
                            
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            

        }

        
    }
}
