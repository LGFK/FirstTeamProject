
using Azure.Core;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System.Security.Cryptography;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DB
{
    public class VendorSysDb
    {
        VendorSysDbContext _dbContext;


        public VendorSysDb(String _connectionString1)
        {
            var dbContextOptions = new DbContextOptionsBuilder<VendorSysDbContext>().UseLazyLoadingProxies().UseSqlServer(_connectionString1).Options;
            _dbContext = new VendorSysDbContext(dbContextOptions);

        }
        public List<Receipt> GetAllReceipts()
        {
            return _dbContext.Receipts.ToList();
        }
        public void AddNewProductType(ProductType productType)
        {

            _dbContext.ProductTypes.Add(productType);
            _dbContext.SaveChanges();
        }
        public void SetDiscounts(List<int> _ids, int discount)
        {
            for (int i = 0; i < _ids.Count; i++)
            {
                _dbContext.Products.FirstOrDefault(x => x.Id == _ids[i]).Discount = discount;

            }
            _dbContext.SaveChanges();
        }
        public  List<ProductType> GetAllTypes()
        {
            return _dbContext.ProductTypes.ToList();
        }
        public  List<Customer?> GetCustomers()
        {
            return _dbContext?.Customers.ToList();
        }
        public Customer? GetConcreeteCustomer(int id)
        {
            return _dbContext.Customers.Where(x => x.Id == id).FirstOrDefault();
        }
        public void AddCustomer(Customer _cust)
        {
            _dbContext?.Customers.Add(_cust);
            _dbContext.SaveChanges();
        }

        public void DelCustomer(int _id)
        {
            try
            {
                _dbContext.Remove(_dbContext.Customers.FirstOrDefault(x => x.Id == _id));
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public (Receipt? _receipt, List<Product?> _prodsInReceipt) GetConcreeteReceiptById(int id)
        {
            return (_dbContext.Receipts.Where(x => x.Id == id).FirstOrDefault(), _dbContext.ProductsSolds.Where(x => x.ReceiptId == id).Select(x => x.Product).ToList());
        }

        public  void AddReceipt(Receipt _receipt, List<(Product product, int amSold)> _productsFromReceipt)
        {

            try
            {
                _dbContext?.Receipts.Add(_receipt);
                _dbContext?.SaveChanges();
                int receiptId = _dbContext.Receipts.ToList()[_dbContext.Receipts.ToList().Count - 1].Id;
                for (int i = 0; i < _productsFromReceipt.Count; i++)
                {
                    _dbContext?.ProductsSolds.Add(new ProductsSold() { ProductId = _productsFromReceipt[i].product.Id, ReceiptId = receiptId, AmountSold = _productsFromReceipt[i].amSold });
                    var _prodWhereAmHasToBeChanged = _dbContext?.Products.Where(x => x == _productsFromReceipt[i].product).FirstOrDefault();
                    _prodWhereAmHasToBeChanged.Amount -= _productsFromReceipt[i].amSold;
                }
                var res = _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void DeleteReceiptById(int _id)
        {
            var _prodsSoldToRemove = _dbContext.ProductsSolds.Where(x => x.ReceiptId == _id).ToList();
            foreach (var _prodSold in _prodsSoldToRemove)
            {
                _dbContext.ProductsSolds.Entry(_prodSold).State = EntityState.Deleted;
            }
            _dbContext.Receipts.Entry(_dbContext.Receipts.Where(x => x.Id == _id).FirstOrDefault()).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }

        public  Product GetProductByName(string _name)
        {
            return _dbContext.Products.Where(x => x.Pname == _name).FirstOrDefault();
        }
        public  List<Product> GetProductsList()
        {
            return _dbContext.Products.ToList();
        }

        public  void  AddProduct(Product? _prod)
        {
            _dbContext.Products.Add(_prod);
            _dbContext.SaveChanges();
        }

        public List<Cashier?> GetCashiers()
        {
            return _dbContext?.Cashiers.ToList();
        }

        public void AddCashier(Cashier? _cashier)
        {
            _dbContext.Cashiers.Add(_cashier);
            _dbContext.SaveChanges();
        }

        public void FireCashierById(int _id)
        {
            _dbContext.Cashiers.Where(x => x.Id == _id).FirstOrDefault().IsFired = true;
            _dbContext.SaveChanges();
        }

        public Cashier? GetCashierById(int _id)
        {
            return _dbContext.Cashiers.Where(x => x.Id == _id).FirstOrDefault();
        }


        public string GetProductTypeById(int id)
        {
            var res = _dbContext.ProductTypes.Where(x => x.Id == id).Select(x => x.TypeName);
            foreach (var type in res)
            {
                return type;
            }
            throw new Exception("Unhandled Exception");


        }

        public bool loginMngr(string login, string password)
        {

            var mngr =  GetManagerByLogin(login);
            if (string.IsNullOrEmpty(mngr[0]) != true)
            {
                password = password + mngr[3];
                var encodedPass = SHA256.HashData(Encoding.UTF8.GetBytes(password));
                if (Encoding.UTF8.GetString(encodedPass) == mngr[2])
                {

                    return true;
                }
                else
                {

                    return false;
                }

            }
            else
            {
                return false;
            }
            throw new Exception("Unhandled Server Exception(loginMngr");
        }
        public string AddNewManager(string login, string passwordStr)
        {
            string reply = "";
            if (String.IsNullOrEmpty(GetManagerByLogin(login)[1]))
            {
                try
                {
                    DirectoryInfo di = new DirectoryInfo(@"..\..\..\DB\ConfigFiles");
                    var config = new ConfigurationBuilder().SetBasePath(di.FullName).AddJsonFile("appsettings1.json").Build();
                    var connection = new SqlConnection(config.GetConnectionString("ManagersConnectionString"));
                    connection.Open();
                    var arrWithLetters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
                    var rand = new Random();
                    StringBuilder saltStrSB = new StringBuilder();
                    int amountOfLetterInWord = rand.Next(20, 99);
                    for (int i = 0; i < amountOfLetterInWord; i++)
                    {
                        saltStrSB.Append(arrWithLetters[rand.Next(0, arrWithLetters.Length - 1)]);
                    }
                    var saltStr = saltStrSB.ToString();

                    string saltedPasswordStr = passwordStr + saltStr;
                    byte[] password = Encoding.UTF8.GetBytes(saltedPasswordStr); ;
                    var hashedSaltedPassword = SHA256.HashData(password);
                    var hashedPasswordToSave = Encoding.UTF8.GetString(hashedSaltedPassword);
                    string query = "insert Managers values (@login,@password,@salt) ";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.Add("@login", System.Data.SqlDbType.NVarChar).Value = login;
                    command.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = hashedPasswordToSave;
                    command.Parameters.Add("@salt", System.Data.SqlDbType.NVarChar).Value = saltStr;
                    command.ExecuteNonQuery();
                    reply = "Manager Added";
                    return reply;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return $"{ex.Message}";
                }
            }
            else
            {
                reply = "User Already Exists";
                return reply;
            }


        }

        public string[] GetManagerByLogin(string login)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(@"..\..\..\DB\ConfigFiles");
                var config = new ConfigurationBuilder().SetBasePath(di.FullName).AddJsonFile("appsettings1.json").Build();
                var connection = new SqlConnection(config.GetConnectionString("ManagersConnectionString"));
                connection.Open();
                string query = "Select * From Managers where login = @login";
                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@login", System.Data.SqlDbType.NVarChar).Value = login;
                using var reader = command.ExecuteReader();
                return ExecuteReader(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            throw new Exception("Unhandled Exception on Server Side (GetManagersByLogin)");


        }

        public String[] ExecuteReader(SqlDataReader? reader)
        {
            string[] data = new string[4];
            while (reader?.Read() ?? false)
            {
                for (int i = 0; i < reader?.FieldCount; i++)
                {
                    data[i] = reader[i].ToString();
                }
            }
            return data;
        }

    }
}
