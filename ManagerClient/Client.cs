using ManagerClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerClient.Model;
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Drawing.Imaging;

namespace ManagerClient
{
    public class MyClient
    {
        TcpClient tcpClient;
        IPEndPoint _iPEndP;

        public MyClient()
        {
            _iPEndP = new IPEndPoint(IPAddress.Loopback, 1488);
        }
        public async Task<List<Customer>> GetAllCustomers()
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(_iPEndP);
            string req = "Customers";
            if(tcpClient.Connected)
            {
                try
                {
                    var networkStream = tcpClient.GetStream();
                    byte[] data = Encoding.UTF8.GetBytes(req);
                    int size = data.Length;
                    await networkStream.WriteAsync(BitConverter.GetBytes(size), 0, 4);
                    await networkStream.WriteAsync(data, 0, data.Length);
                    var bufferSize = new byte[4];
                    await networkStream.ReadAsync(bufferSize, 0, 4);
                    size = BitConverter.ToInt32(bufferSize);
                    data = new byte[size];
                    await networkStream.ReadAsync(data, 0, size);
                    var dataStr = Encoding.UTF8.GetString(data);
                    List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(dataStr);
                    tcpClient.Close();
                    return customers;
                }
                catch(Newtonsoft.Json.JsonException e)
                {
                    MessageBox.Show("Unresolved Problem WIth Reading Json File"); 
                    return new List<Customer>();
                }

            }
            throw new Exception("Something went wrong with connection");
        }

        public async Task<List<Product>> GetAllProducts()
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(_iPEndP);
            string req = "Products";
            if(tcpClient.Connected)
            {
                try
                {
                    var networkStream = tcpClient.GetStream();
                    byte[] data = Encoding.UTF8.GetBytes(req);
                    int size = data.Length;
                    await networkStream.WriteAsync(BitConverter.GetBytes(size), 0, 4);
                    await networkStream.WriteAsync(data, 0, data.Length);
                    var bufferSize = new byte[4];
                    await networkStream.ReadAsync(bufferSize, 0, 4);
                    size = BitConverter.ToInt32(bufferSize);

                    //Thread.Sleep(500);
                    data = new byte[size];
                    await networkStream.ReadAsync(data, 0, size);
                    var dataStr = Encoding.UTF8.GetString(data);
                    List<Product> _prods = JsonConvert.DeserializeObject<List<Product>>(dataStr);
                    
                    return await Task.FromResult(_prods);
                }
                catch(Exception ex)
                {
                    
                    MessageBox.Show(ex.Message);
                    return new List<Product>();
                }
                finally
                {
                    tcpClient.Close();
                }
                
            }
            throw new Exception("Something went wrong with connection");
        }

        public async Task<List<Cashier>> GetAllCashiers()
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(_iPEndP);
            string req = "Cashiers";
            if (tcpClient.Connected)
            {
                try
                {
                    var networkStream = tcpClient.GetStream();
                    byte[] data = Encoding.UTF8.GetBytes(req);
                    int size = data.Length;
                    await networkStream.WriteAsync(BitConverter.GetBytes(size), 0, 4);
                    await networkStream.WriteAsync(data, 0, data.Length);
                    var bufferSize = new byte[4];
                    await networkStream.ReadAsync(bufferSize, 0, 4);
                    size = BitConverter.ToInt32(bufferSize);
                    data = new byte[size];
                    await networkStream.ReadAsync(data, 0, size);
                    var dataStr = Encoding.UTF8.GetString(data);
                    List<Cashier> _cashiers = JsonConvert.DeserializeObject<List<Cashier>>(dataStr);
                   
                    return _cashiers;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    tcpClient.Close();
                }
               

            }
            throw new Exception("Something went wrong with connection");
        }

        public async Task DeleteCustomer(int id)
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(_iPEndP);
            string req = $"DeleteCust<|>{id}";
            if(tcpClient.Connected)
            {
                try
                {
                    var networkStream = tcpClient.GetStream();
                    byte[] data = Encoding.UTF8.GetBytes(req);
                    int size = data.Length;
                    await networkStream.WriteAsync(BitConverter.GetBytes(size), 0, 4);
                    await networkStream.WriteAsync(data, 0, data.Length);
                    tcpClient.Close();
                    return;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                   
                    return;
                }
                finally
                {
                    tcpClient.Close();
                }
                
            }
            
            throw new Exception("Unhandled Exception On Clients Side");
        }

        public async Task<string> GetTypeById(int id)
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(_iPEndP);
            string req = $"ProductType<|>{id}";
            if (tcpClient.Connected)
            {
                try
                {
                    var networkStream = tcpClient.GetStream();
                    byte[] data = Encoding.UTF8.GetBytes(req);
                    int size = data.Length;
                    await networkStream.WriteAsync(BitConverter.GetBytes(size), 0, 4);
                    await networkStream.WriteAsync(data, 0, data.Length);

                    var bufferSize = new byte[4];
                    await networkStream.ReadAsync(bufferSize, 0, 4);
                    
                    size = BitConverter.ToInt32(bufferSize);

                    data = new byte[size];
                    await networkStream.ReadAsync(data, 0, size);
                    var dataStr = Encoding.UTF8.GetString(data);
                    
                    
                    return dataStr;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                    return null;
                }
                finally
                {
                    tcpClient.Close();
                }
                
            }
            throw new Exception("Unhandled Exception On Clients Side");
        }

        public async Task AddClientToDB(Customer _custToAdd)
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(_iPEndP);
            string json = JsonConvert.SerializeObject(_custToAdd, Formatting.Indented);
            string req = $"AddCustomer<|>{json}";
            if(tcpClient.Connected)
            {
                try
                {
                    var networkStream = tcpClient.GetStream();
                    var reqBytes = Encoding.UTF8.GetBytes(req);
                    byte[] sizeToSendBuff = BitConverter.GetBytes(reqBytes.Length);
                    await networkStream.WriteAsync(sizeToSendBuff, 0, 4);
                    await networkStream.WriteAsync(reqBytes, 0, reqBytes.Length);
                    
                    return;
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                    return;
                }
                finally
                {
                    tcpClient.Close();
                }
            }
            throw new Exception("Unhandled Exception On Clients Side");
        }

        public async Task AddCashierToDB(Cashier _cashierToAdd)
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(_iPEndP);
            string json = JsonConvert.SerializeObject(_cashierToAdd, Formatting.Indented);
            string req = $"AddCashier<|>{json}";
            if (tcpClient.Connected)
            {
                try
                {
                    var networkStream = tcpClient.GetStream();
                    var reqBytes = Encoding.UTF8.GetBytes(req);
                    byte[] sizeToSendBuff = BitConverter.GetBytes(reqBytes.Length);
                    await networkStream.WriteAsync(sizeToSendBuff, 0, 4);
                    await networkStream.WriteAsync(reqBytes, 0, reqBytes.Length);
                    
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                    return;
                }
                finally
                {
                    tcpClient.Close();
                }
            }
            throw new Exception("Unhandled Exception On Clients Side");
        }

        public async Task FireCashierById(int id)
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(_iPEndP);
            string req = $"FireCashier<|>{id}";
            if(tcpClient.Connected)
            {
                try
                {
                    var networkStream = tcpClient.GetStream();
                    var reqBytes = Encoding.UTF8.GetBytes(req);
                    byte[] sizeToSendBuff = BitConverter.GetBytes(reqBytes.Length);
                    await networkStream.WriteAsync(sizeToSendBuff, 0, 4);
                    await networkStream.WriteAsync(reqBytes, 0, reqBytes.Length);
                    
                    return;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                    return;
                }
                finally
                {
                    tcpClient.Close();
                }
            }
            throw new Exception("Unhandled Exception On Clients Side");
        }
        public async Task AddProductType(string _typeName)
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(_iPEndP);
            string req = $"AddProductType<|>{_typeName}";
            if (tcpClient.Connected)
            {
                try
                {
                    var networkStream = tcpClient.GetStream();
                    var reqBytes = Encoding.UTF8.GetBytes(req);
                    byte[] sizeToSendBuff = BitConverter.GetBytes(reqBytes.Length);
                    await networkStream.WriteAsync(sizeToSendBuff, 0, 4);
                    await networkStream.WriteAsync(reqBytes, 0, reqBytes.Length);
                    
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                finally
                {
                    tcpClient.Close();
                }
            }
            throw new Exception("Unhandled Exception On Clients Side");
        }

        public  List<ProductType> GetProductsType()
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(_iPEndP);
            string req = $"GetProductTypes";
            if(tcpClient.Connected)
            {
                try
                {
                    var networkStream =  tcpClient.GetStream();
                    var reqBytes = Encoding.UTF8.GetBytes(req);
                    var sizeToSendBuff = BitConverter.GetBytes(reqBytes.Length);
                     networkStream.Write(sizeToSendBuff, 0, 4);
                     networkStream.Write(reqBytes,0, reqBytes.Length);
                    var sizeToRecieveBytes = new byte[4];
                     networkStream.Read(sizeToRecieveBytes, 0, 4);
                    int sizeToRecieve = BitConverter.ToInt32(sizeToRecieveBytes, 0);
                    var dataToRecieve = new byte[sizeToRecieve];
                    networkStream.Read(dataToRecieve, 0, dataToRecieve.Length);
                    var jsonStr = Encoding.UTF8.GetString(dataToRecieve);
                    tcpClient.Close();
                    List<ProductType> productTypes = JsonConvert.DeserializeObject<List<ProductType>>(jsonStr);
                    return productTypes;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    tcpClient.Close();
                    return null;
                }
            }
            throw new Exception("Unhandled Exception On Clients Side");
        }
        public async Task AddProduct(Product _prodToAdd,Image imgOfProduct,string format)
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(_iPEndP);
            string jsonProduct = JsonConvert.SerializeObject(_prodToAdd);
            
            string req = $"AddProduct<|>{jsonProduct}";
            if (tcpClient.Connected)
            {
                try
                {
                    var networkStream = tcpClient.GetStream();
                    var reqBytes = Encoding.UTF8.GetBytes(req);
                    var sizeToSendBuff = BitConverter.GetBytes(reqBytes.Length);
                    networkStream.Write(sizeToSendBuff, 0, 4);
                    networkStream.Write(reqBytes, 0, reqBytes.Length);
                    MemoryStream memoryStream = new MemoryStream();
                    switch (format)
                    {
                        case ".png":
                            {
                                imgOfProduct.Save(memoryStream, ImageFormat.Png);
                                reqBytes = memoryStream.ToArray();
                                sizeToSendBuff = BitConverter.GetBytes(reqBytes.Length);
                                await networkStream.WriteAsync(sizeToSendBuff, 0, 4);
                                //Thread.Sleep(500);
                                await networkStream.WriteAsync(reqBytes, 0, reqBytes.Length);
                                break;
                            }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                    
                }
                finally
                {
                    tcpClient.Close();
                }
            }
            throw new Exception("Unhandled Exception On Clients Side");
        }

        public async Task SetDiscount(int dicount, List<int> ids)
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(_iPEndP);
            string jsonIds = JsonConvert.SerializeObject(ids);

            string req = $"Discounts<|>{dicount}<|>{jsonIds}";
            if (tcpClient.Connected)
            {
                try
                {
                    var networkStream = tcpClient.GetStream();
                    var reqBytes = Encoding.UTF8.GetBytes(req);
                    byte[] sizeToSendBuff = BitConverter.GetBytes(reqBytes.Length);
                    await networkStream.WriteAsync(sizeToSendBuff, 0, 4);
                    await networkStream.WriteAsync(reqBytes, 0, reqBytes.Length);
                    
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                finally
                {
                    tcpClient.Close();
                }
            }
            throw new Exception("Unhandled Exception On Clients Side");
        }

        public async Task<bool> TryLogin(string login,string password)
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(_iPEndP);
            string req = $"MLogin<|>{login}<|>{password}";
            if(tcpClient.Connected)
            {
                try
                {
                    var networkStream = tcpClient.GetStream();
                    var reqBytes = Encoding.UTF8.GetBytes(req);
                    byte[] sizeToSendBuff = BitConverter.GetBytes(reqBytes.Length);
                    await networkStream.WriteAsync(sizeToSendBuff, 0, 4);
                    await networkStream.WriteAsync(reqBytes, 0, reqBytes.Length);
                    var sizeToRecieveBuff = new byte[4];
                    await networkStream.ReadAsync(sizeToRecieveBuff, 0, 4);
                    byte[] resp = new byte[BitConverter.ToInt32(sizeToRecieveBuff)];
                    await networkStream.ReadAsync(resp, 0, resp.Length);
                    var respStr = Encoding.UTF8.GetString(resp);
                    
                    if(respStr=="true")
                    {
                        return true;
                    }

                    return false;
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
                finally
                {
                    tcpClient.Close();
                }
            }
            throw new Exception("Unhandled Exception On Clients Side");

        }

        public async Task<string> RegisterNewManager(string login, string password)
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(_iPEndP);
            string req = $"MReg<|>{login}<|>{password}";
            if(tcpClient.Connected)
            {
                try
                {
                    var networkStream = tcpClient.GetStream();
                    var reqBytes = Encoding.UTF8.GetBytes(req);
                    byte[] sizeToSendBuff = BitConverter.GetBytes(reqBytes.Length);
                    await networkStream.WriteAsync(sizeToSendBuff, 0, 4);
                    await networkStream.WriteAsync(reqBytes, 0, reqBytes.Length);
                    var sizeToRecieveBuff = new byte[4];
                    await networkStream.ReadAsync(sizeToRecieveBuff, 0, 4);
                    byte[] resp = new byte[BitConverter.ToInt32(sizeToRecieveBuff)];
                    await networkStream.ReadAsync(resp, 0, resp.Length);
                    var respStr = Encoding.UTF8.GetString(resp);
                    return respStr;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
            throw new Exception("Unhandled Exception On Clients Side");
        }
    }
}
