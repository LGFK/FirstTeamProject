
using Microsoft.EntityFrameworkCore;
using Server.DB.ConfigFiles;

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

        public VendorSysDb(String _connectionString)
        {
            var dbContextOptions = new DbContextOptionsBuilder<VendorSysDbContext>().UseLazyLoadingProxies().UseSqlServer(_connectionString).Options;
            _dbContext = new VendorSysDbContext(dbContextOptions);
        }

        public async Task<List<Customer?>> GetCustomers()
        {
            return _dbContext?.Customers.ToList();
        }
        public async Task<Customer?> GetConcreeteCustomer(int id)
        {
            return _dbContext.Customers.Where(x => x.Id == id).FirstOrDefault();
        }
        public async Task AddCustomer(Customer _cust)
        {
            _dbContext?.Customers.Add(_cust);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DelCustomer(int _id)
        {
            try
            {
                _dbContext.Remove(_dbContext.Customers.FirstOrDefault(x => x.Id == _id));
                _dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public async Task<(Receipt? _receipt, List<Product?> _prodsInReceipt)> GetConcreeteReceiptById(int id)
        {
            return (_dbContext.Receipts.Where(x => x.Id == id).FirstOrDefault(), _dbContext.ProductsSolds.Where(x => x.ReceiptId == id).Select(x => x.Product).ToList());
        }

        public async Task AddReceipt(Receipt _receipt, List<(Product product, int amSold)> _productsFromReceipt)
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

        public async Task<Product> GetProductByName(string _name)
        {
            return _dbContext.Products.Where(x => x.Pname == _name).FirstOrDefault();
        }
        public async Task<List<Product>> GetProductsList()
        {
            return _dbContext.Products.ToList();
        }

        public async Task AddProduct(Product? _prod)
        {
            _dbContext.Products.Add(_prod);
            _dbContext.SaveChanges();
        }

        public async Task<List<Cashier?>> GetCashiers()
        {
            return _dbContext?.Cashiers.ToList();
        }

        public async Task AddCashier(Cashier? _cashier)
        {
            _dbContext.Cashiers.Add(_cashier);
            _dbContext.SaveChanges();
        }

        public async Task FireCashierById(int _id)
        {
            _dbContext.Cashiers.Where(x => x.Id == _id).FirstOrDefault().IsFired = true;
            _dbContext.SaveChanges();
        }

        public async Task<Cashier?> GetCashierById(int _id)
        {
            return _dbContext.Cashiers.Where(x => x.Id == _id).FirstOrDefault();
        }


        public async Task<ProductType> GetProductTypeById(int id)
        {
            return _dbContext.ProductTypes.Where(x => x.Id == id).FirstOrDefault();
        }

    }
}
