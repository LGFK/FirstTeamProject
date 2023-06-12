using Castle.DynamicProxy.Generators;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
using Server.DB;

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
        public void SendCustomers(NetworkStream _ns)
        {
            var _customers = db.GetCustomers();
            var jsonToSend = JsonConvert.SerializeObject(_customers, Formatting.Indented);
            var responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
            var buffer = BitConverter.GetBytes(responseToSend.Length);
            _ns.Write(buffer, 0, 4);
            _ns.Write(responseToSend, 0, responseToSend.Length);
        }
        public void SendCashiers(NetworkStream _ns)
        {
            var _cashiers = db.GetCashiers();
            var jsonToSend = JsonConvert.SerializeObject(_cashiers, Formatting.Indented);
            var responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
            var  buffer = BitConverter.GetBytes(responseToSend.Length);
            _ns.Write(buffer, 0, buffer.Length);
            _ns.Write(responseToSend, 0, responseToSend.Length);
        }
        public void SendReceipts(NetworkStream _ns)
        {
            List<Receipt> receipts = db.GetAllReceipts();
            var jsonToSend = JsonConvert.SerializeObject(receipts, Formatting.Indented);
            var responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
            var  buffer = BitConverter.GetBytes(responseToSend.Length);
            _ns.Write(buffer, 0, buffer.Length);
            _ns.Write(responseToSend, 0, responseToSend.Length);
        }
        public void SetDiscounts(List<int> _ids,int discountPercentage)
        {
            db.SetDiscounts(_ids, discountPercentage);
        }
        public void SendReceiptById(int id,NetworkStream _ns)
        {
            var _receipt = db.GetConcreeteReceiptById(id);
            var jsonToSend = JsonConvert.SerializeObject(_receipt._receipt);
            var responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
            var buffer = BitConverter.GetBytes(responseToSend.Length);
            _ns.Write(buffer, 0, buffer.Length);
            _ns.Write(responseToSend, 0, responseToSend.Length);
            jsonToSend = JsonConvert.SerializeObject(_receipt._prodsInReceipt);
            responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
            buffer = BitConverter.GetBytes(responseToSend.Length);
            _ns.Write(buffer, 0, buffer.Length);
            _ns.Write(responseToSend, 0, responseToSend.Length);
            
        }
        public void SendAllProds(NetworkStream _ns)
        {
            var _products = db.GetProductsList();
            var jsonToSend = JsonConvert.SerializeObject(_products, Formatting.Indented);
            var responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
            var buffer = BitConverter.GetBytes(responseToSend.Length);
            _ns.Write(buffer, 0, buffer.Length);
            _ns.Write(responseToSend, 0, responseToSend.Length);
            string tmp = null;
            foreach (var product in _products)
            {
                responseToSend = product.Image;
                buffer = BitConverter.GetBytes(responseToSend.Length);
                _ns.Write(buffer, 0, buffer.Length);
                _ns.Write(responseToSend, 0, responseToSend.Length);

            }
            
            Thread.Sleep(100);


        }
        public void SendProdType(NetworkStream _ns,int id)
        {
            var _pType = db.GetProductTypeById(id);
            var responseToSend = Encoding.UTF8.GetBytes(_pType);
            var buffer = BitConverter.GetBytes(responseToSend.Length);
            _ns.Write(buffer, 0, buffer.Length);
            _ns.Write(responseToSend, 0, responseToSend.Length);
        }
        public void AddCashier(Cashier cashierToAdd)
        {
            db?.AddCashier(cashierToAdd);
        }
        public void AddCustomer(Customer custToAdd)
        {
            db?.AddCustomer(custToAdd);
        }
        public void AddReceipt(Receipt receipt,List<Product>? prodsInReceipt,List<int> amountList)
        {
            List<(Product, int)> listToAdd = new List<(Product, int)>();
            for (int i = 0; i < prodsInReceipt.Count; i++)
            {
                listToAdd.Add((prodsInReceipt[i], amountList[i]));
            }
            db.AddReceipt(receipt, listToAdd);
            
        }
        public void AddProductType(ProductType pT)
        {
            db.AddNewProductType(pT);
        }
        public void SendProductTypes(NetworkStream _ns)
        {
            var _products = db.GetAllTypes();
            var  jsonToSend = JsonConvert.SerializeObject(_products, Formatting.Indented);
            var responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
            var  buffer = BitConverter.GetBytes(responseToSend.Length);
            _ns.Write(buffer, 0, buffer.Length);
            _ns.Write(responseToSend, 0, responseToSend.Length);
        }
        public void DeleteCustomer(int id)
        {
            db?.DelCustomer(id);
        }
        public void FireCashier(int id)
        {
            db.FireCashierById(id);
        }
        public void AddProduct(Product prodToAdd,NetworkStream _ns)
        {
            var buffer = new byte[4];
            _ns.Read(buffer, 0, buffer.Length);
            var reqSize = BitConverter.ToInt32(buffer, 0);
            buffer = new byte[reqSize];
            _ns.Read(buffer, 0, buffer.Length);
            prodToAdd.Image = buffer;
            db?.AddProduct(prodToAdd);
        }
        public void ManagerLogin(string login, string password, NetworkStream _ns)
        {
            byte[] responseToSend = null;
            if (db.loginMngr(login, password) == true)
            {
                 responseToSend = Encoding.UTF8.GetBytes("true");
            }
            else
            {
                 responseToSend = Encoding.UTF8.GetBytes("false");
            }
            var sizeToSend = responseToSend.Length;
            var buffer = BitConverter.GetBytes(sizeToSend);
            _ns.Write(buffer, 0, 4);
            _ns.Write(responseToSend, 0, responseToSend.Length);
        }
        public void ManagerRegister(string login,string password,NetworkStream _ns)
        {
            var res = db.AddNewManager(login, password);
            var responseToSend = Encoding.UTF8.GetBytes(res);
            var buffer = BitConverter.GetBytes(responseToSend.Length);
            _ns.Write(buffer, 0, buffer.Length);
            _ns.Write(responseToSend, 0, responseToSend.Length);
        }

        public async Task HandleConnectionAsync(TcpClient _client)
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
                                SendCustomers(networkStream);
                                break;
                            }
                        case "Cashiers":
                            {
                                SendCashiers(networkStream);
                                break;
                            }
                        case "AllReceipts":
                            {
                                SendReceipts(networkStream);
                                break;
                            }
                        case "Discounts":
                            {
                                //int discount = Int32.Parse(reqStr[1]);
                                //List<int> _ids = JsonConvert.DeserializeObject<List<int>>(reqStr[2]);
                                //db.SetDiscounts(_ids, discount);
                                SetDiscounts(JsonConvert.DeserializeObject<List<int>>(reqStr[2]), Int32.Parse(reqStr[1]));
                                break;
                            }
                        case "Receipts":
                            {
                                //var id = Int32.Parse(reqStr[1]);
                                //var _receipt = db.GetConcreeteReceiptById(id);
                                //jsonToSend = JsonConvert.SerializeObject(_receipt._receipt);
                                //responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
                                //buffer = BitConverter.GetBytes(responseToSend.Length);
                                //await networkStream.WriteAsync(buffer, 0, buffer.Length);
                                //await networkStream.WriteAsync(responseToSend, 0, responseToSend.Length);
                                //jsonToSend = JsonConvert.SerializeObject(_receipt._prodsInReceipt);
                                //responseToSend = Encoding.UTF8.GetBytes(jsonToSend);
                                //buffer = BitConverter.GetBytes(responseToSend.Length);
                                //await networkStream.WriteAsync(buffer, 0, buffer.Length);
                                //await networkStream.WriteAsync(responseToSend, 0, responseToSend.Length);
                                SendReceiptById(Int32.Parse(reqStr[1]), networkStream);
                                break;
                            }
                        case "Products":
                            {
                                SendAllProds(networkStream);
                                break;
                            }
                        case "ProductType":
                            {
                                
                                SendProdType(networkStream, Int32.Parse(reqStr[1]));
                                break;
                            }
                        case "AddCashier":
                            {
                                
                                AddCashier(JsonConvert.DeserializeObject<Cashier>(reqStr[1]));
                                
                                break;
                            }
                        case "AddCustomer":
                            {
                                AddCustomer(JsonConvert.DeserializeObject<Customer>(reqStr[1]));
                                
                                break;
                            }
                        case "AddReceipt":
                            {
                                var receipt = JsonConvert.DeserializeObject<Receipt>(reqStr[1]);
                                var prodsInReceipt = JsonConvert.DeserializeObject<List<Product>>(reqStr[2]);
                                var amountList = JsonConvert.DeserializeObject<List<int>>(reqStr[3]);
                                AddReceipt(receipt, prodsInReceipt, amountList);
                                break;
                            }
                        case "AddProductType":
                            {
                                
                                AddProductType(new ProductType() { TypeName = reqStr[1] });
                                break;
                            }
                        case "GetProductTypes":
                            {
                                SendProductTypes(networkStream);
                                break;

                            }

                        case "DeleteCust":
                            {
                                DeleteCustomer(Int32.Parse(reqStr[1]));
                                break;
                            }
                        case "FireCashier":
                            {
                                FireCashier(Int32.Parse(reqStr[1]));
                                break;
                            }
                        case "AddProduct":
                            {
                                AddProduct(JsonConvert.DeserializeObject<Product>(reqStr[1]), networkStream);
                                break;
                            }
                        case "MLogin":
                            {
                                ManagerLogin(reqStr[1], reqStr[2],networkStream);
                                break;
                            }
                        case "MReg":
                            {
                                ManagerRegister(reqStr[1], reqStr[2], networkStream);
                                break;
                            }
                    }

                    
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
