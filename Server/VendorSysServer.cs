using Castle.DynamicProxy.Generators;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
using Server.DB;
using Server.DB.ConfigFiles;
using System.Diagnostics.Eventing.Reader;
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
            //var config = new ConfigurationBuilder().SetBasePath(di.FullName).AddJsonFile("appsettings1.json").Build();
            //db = new VendorSysDb(config.GetConnectionString("MainConnectionString"));
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

        public async Task<string> HandleConnectionAsync(TcpClient _client)
        {
            DirectoryInfo di = new DirectoryInfo(@"..\..\..\DB\ConfigFiles");
            var config = new ConfigurationBuilder().SetBasePath(di.FullName).AddJsonFile("appsettings1.json").Build();
            db = new VendorSysDb(config.GetConnectionString("MainConnectionString"));
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
                    string logs = $"{_client.Client.RemoteEndPoint} has joined and requested {reqStr[0]}";
                    switch (reqStr[0])
                    {
                        case "Customers":
                            {
                                var _customers = await db.GetCustomers();
                                jsonToSend = JsonConvert.SerializeObject(_customers, Formatting.Indented);
                                responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
                                buffer = BitConverter.GetBytes(responseToSend.Length);
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
                        case "AllReceipts":
                            {
                                List<Receipt> receipts = await db.GetAllReceipts();
                                jsonToSend = JsonConvert.SerializeObject(receipts, Formatting.Indented);
                                responseToSend= Encoding.UTF8.GetBytes(jsonToSend);
                                buffer= BitConverter.GetBytes(responseToSend.Length);
                                await networkStream.WriteAsync(buffer , 0, buffer.Length);
                                await networkStream.WriteAsync(responseToSend,0,responseToSend.Length);
                                break;
                            }
                        case "Receipts":
                            {
                                var id = Int32.Parse(reqStr[1]);
                                var _receipt = await db.GetConcreeteReceiptById(id);
                                MessageBox.Show(_receipt._receipt.TotalPrice.ToString());
                                jsonToSend = JsonConvert.SerializeObject(_receipt._receipt);
                                MessageBox.Show(jsonToSend);
                                responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
                                buffer = BitConverter.GetBytes(responseToSend.Length);
                                await networkStream.WriteAsync(buffer, 0, buffer.Length);
                                await networkStream.WriteAsync(responseToSend, 0, responseToSend.Length);
                                jsonToSend = JsonConvert.SerializeObject(_receipt._prodsInReceipt);
                                responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
                                buffer = BitConverter.GetBytes(responseToSend.Length);
                                await networkStream.WriteAsync(buffer,0, buffer.Length);
                                await networkStream.WriteAsync(responseToSend,0, responseToSend.Length);
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
                        case "AddCashier":
                            {
                                Cashier cashierToAdd = JsonConvert.DeserializeObject<Cashier>(reqStr[1]);
                                db?.AddCashier(cashierToAdd);
                                break;
                            }
                        case "AddCustomer":
                            {
                                Customer custToSave = JsonConvert.DeserializeObject<Customer>(reqStr[1]);
                                db?.AddCustomer(custToSave);
                                break;
                            }
                        case "AddReceipt":
                            {
                                
                                var receipt = JsonConvert.DeserializeObject<Receipt>(reqStr[1]);
                                var prodsInReceipt = JsonConvert.DeserializeObject<List<Product>>(reqStr[2]);
                                var amountList = JsonConvert.DeserializeObject<List<int>>(reqStr[3]);
                                List<(Product, int)> listToAdd = new List<(Product, int)>();
                                for(int i = 0; i < prodsInReceipt.Count; i++)
                                {
                                    listToAdd.Add((prodsInReceipt[i], amountList[i]));
                                }
                                db.AddReceipt(receipt, listToAdd);
                                break;
                            }
                        case "AddProductType":
                            {
                                ProductType pT = new ProductType() { TypeName = reqStr[1] };
                                db.AddNewProductType(pT);
                                break;
                            }
                        case "GetProductTypes":
                            {
                                var _products = await db.GetAllTypes();
                                jsonToSend = JsonConvert.SerializeObject(_products, Formatting.Indented);
                                responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
                                buffer = BitConverter.GetBytes(responseToSend.Length);
                                await networkStream.WriteAsync(buffer, 0, buffer.Length);
                                await networkStream.WriteAsync(responseToSend, 0, responseToSend.Length);
                                break;
                                
                            }
                            
                        case "DeleteCust":
                            {
                                int id = Int32.Parse(reqStr[1]);
                                db?.DelCustomer(id);
                                break;
                            }
                        case "FireCashier":
                            {
                                await db.FireCashierById(Int32.Parse(reqStr[1]));
                                break;
                            }
                        case "AddProduct":
                            {
                                Product prodToAdd = JsonConvert.DeserializeObject<Product>(reqStr[1]);
                                buffer = new byte[4];
                                await networkStream.ReadAsync(buffer, 0, buffer.Length);
                                reqSize = BitConverter.ToInt32(buffer, 0);
                                buffer = new byte[reqSize];
                                await networkStream.ReadAsync(buffer, 0, buffer.Length);
                                Image imgToAdd = Image.FromStream(new MemoryStream(buffer));
                                string path = @"..\..\..\DB\Images\" + prodToAdd.Pname + ".png";
                                imgToAdd.Save(path);
                                prodToAdd.Image = path;
                                db?.AddProduct(prodToAdd);
                                break;
                            }
                    }
                    
                    return logs;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "Server");
                }
                
            }
            throw new Exception("Somethig Went Wrong On The Server Side");
            

        }


    }
}
