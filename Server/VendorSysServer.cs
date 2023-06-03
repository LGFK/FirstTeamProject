using Microsoft.Extensions.Configuration;
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
                    var reqStr = Encoding.UTF8.GetString(buffer).Split("<|>");

                    switch(reqStr[0])
                    {
                        case "Customers":
                            {
                                var _customers = await db.GetCustomers();
                                //List<CustomerToSend> _custToSend = new List<CustomerToSend>();
                                //foreach(var customer in _customers)
                                //{
                                //    _custToSend.Add(new CustomerToSend() { Email = customer.Email
                                //        , FirstName = customer.FirstName, SecondName = customer.SecondName, Id = customer.Id,PhoneN=customer.PhoneN });
                                //}    
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
                                //List<CashierToSend> cashiers = new List<CashierToSend>();
                                //foreach( var cashier in _cashiers)
                                //{
                                //    cashiers.Add(new CashierToSend() { Email = cashier.Email
                                //        , FirstName = cashier.FirstName, Id = cashier.Id, IsFired = cashier.IsFired, PhoneN = cashier.PhoneN, SecondName = cashier.SecondName });
                                //}
                                jsonToSend = JsonConvert.SerializeObject(_cashiers);
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

                                jsonToSend = JsonConvert.SerializeObject(_receipt);
                                responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
                                buffer = BitConverter.GetBytes(responseToSend.Length);
                                await networkStream.WriteAsync(buffer, 0, buffer.Length);
                                await networkStream.WriteAsync(responseToSend, 0, responseToSend.Length);
                                break;
                            }
                        case "Products":
                            {
                                var _products = await db.GetProductsList();
                                //var prodsToSend = new List<ProductToSend>();
                                //for(int i = 0; i<_products.Count;i++)
                                //{
                                //    prodsToSend.Add(new ProductToSend()
                                //    {
                                //        Pname = _products[i].Pname,
                                //        Id = _products[i].Id,
                                //        Amount = _products[i].Amount,
                                //        Discount = _products[i].Discount,
                                //        Image = _products[i].Image,
                                //        Price = _products[i].Price,
                                //        ProdType = _products[i].ProdType
                                //    });
                                //}
                                jsonToSend = JsonConvert.SerializeObject(_products);
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
                                buffer = new byte[4];
                                await networkStream.ReadAsync(buffer, 0, buffer.Length);
                                reqSize = BitConverter.ToInt32(buffer, 0);
                                buffer = new byte[reqSize];
                                await networkStream.ReadAsync(buffer, 0, buffer.Length);
                                reqStr[1] = Encoding.UTF8.GetString(buffer);
                                (Receipt, List<(Product, int amount)>) receiptToSave = JsonConvert.DeserializeObject<(Receipt, List<(Product, int amount)>)>(reqStr[1]);
                                db.AddReceipt(receiptToSave.Item1, receiptToSave.Item2);
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
