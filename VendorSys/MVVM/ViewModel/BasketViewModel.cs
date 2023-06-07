using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VendorSys.Core;
using VendorSys.MVVM.Model;

namespace VendorSys.MVVM.ViewModel;
/// <summary>
/// Властивість BuyCommand, яка представляє команду для виконання покупки.
///Властивість ProductInBasket, яка представляє колекцію продуктів в кошику.Вона ініціалізується як ObservableCollection<Product>, що дозволяє автоматично відслідковувати зміни у колекції та оновлювати відображення.
///Метод AddProductToBasket(), який додає переданий продукт до колекції продуктів в кошику.
/// </summary>
internal class BasketViewModel : ObservableObject
{
    public RelayCommand BuyCommand { get; set; }
    public RelayCommand PrintReceiptCommand { get; set; }
    public RelayCommand AddNewCustomerWindowOpenCommand { get; set; }
    public RelayCommand DellCommand { get; set; }
    public RelayCommand CounterMinusCommand { get; set; }
    public RelayCommand CounterPlusCommand { get; set; }
    private Product _selectedProduct;

    private ObservableCollection<Product> _productInBosket = new ObservableCollection<Product>();
    public ObservableCollection<Product> ProductInBosket
    {
        get { return _productInBosket; }
        set
        {
            _productInBosket = value;
            OnPropertyChanged(nameof(ProductInBosket));
        }
    }

    List<int> _amountOfProduct;

    Receipt _receipt;

    private Cashier _selectedCashier;

    private List<Cashier> _cashiers;
    public List<Cashier> Cashiers
    {
        get { return _cashiers; }
        set
        {
            if (_cashiers != value)
            {
                _cashiers = value;
                OnPropertyChanged(nameof(Cashiers));
            }
        }
    }
    public Cashier? SelectedCashier
    {
        get { return _selectedCashier; }
        set
        {
            if (_selectedCashier != value)
            {
                _selectedCashier = value;
                OnPropertyChanged(nameof(SelectedCashier));
            }
        }
    }

    private Customer _selectedCustomer;

    private List<Customer> _customers;
    public List<Customer> Customers
    {
        get { return _customers; }
        set
        {
            if (_customers != value)
            {
                _customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }
    }
    public Customer? SelectedCustomer
    {
        get { return _selectedCustomer; }
        set
        {
            if (_selectedCustomer != value)
            {
                _selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }
    }

    public Product? SelectedProduct
    {
        get { return _selectedProduct; }
        set
        {
            if (_selectedProduct != value)
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));

            }
        }
    }

    private Boolean _printAvailable;
    public Boolean PrintAvailable
    {
        get { return _printAvailable; }
        set
        {
            if (_printAvailable != value)
            {
                _printAvailable = value;
                OnPropertyChanged(nameof(PrintAvailable));
            }
        }
    }
    public BasketViewModel()
    {

        LoadDataAsync();
        BuyCommand = new RelayCommand(o =>
        {
            if (!ProductInBosket.IsNullOrEmpty())
            {
                if (SelectedCashier == null)
                {
                    MessageBox.Show("Choose cashier");
                }
                else if (SelectedCustomer == null)
                {
                    MessageBox.Show("Choose customer");
                }
                else
                {
                    _receipt = new Receipt();
                    _amountOfProduct = new List<int>();
                    foreach (var product in ProductInBosket)
                    {
                        _receipt.TotalPrice += product.Price;
                        _amountOfProduct.Add(product.Amount);
                    }
                    _receipt.CustomerId = SelectedCustomer.Id;
                    _receipt.CashierId = SelectedCashier.Id;
                    _receipt.Date = System.DateTime.Now;
                    _receipt.Cashier = SelectedCashier;
                    _receipt.Customer = SelectedCustomer;

                    // тут реалізувати логіку відправки чека на сервер (Гамлет)

                    VendorSysClient vendorSysClient = new VendorSysClient();

                    vendorSysClient.SendNewReceiptAsync(_receipt,ProductInBosket.ToList(),_amountOfProduct).Wait();
                    //_printAvailable = true;
                }
            }
            else
            {
                MessageBox.Show("Choose product");
            }

        });

        PrintReceiptCommand = new RelayCommand(o =>
        {
            if (_receipt != null)
            {
                var fileDialog = new SaveFileDialog();
                fileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
                fileDialog.FilterIndex = 1;
                if (fileDialog.ShowDialog() ?? false)
                {
                    using (var sw = new StreamWriter(fileDialog.FileName, false, Encoding.Default))
                    {
                        sw.WriteLine("\t---SHOP---");
                        sw.WriteLine(_receipt.Date);
                        sw.WriteLine("-------------------");
                        sw.WriteLine($"Cashier: {_receipt.Cashier.FirstName} {_receipt.Cashier.SecondName}");
                        sw.WriteLineAsync("Receipt:");
                        foreach (var product in ProductInBosket)
                        {
                            sw.WriteLineAsync($"{product.Pname}\t{product.Amount} x {product.Price}");
                        }
                        sw.WriteLineAsync($"Total price: {_receipt.TotalPrice}");
                        sw.WriteLineAsync($"Customer: {_receipt.Customer.FirstName} {_receipt.Customer.SecondName}");
                    }
                }
            }
            else
            {
                MessageBox.Show("You need to buy something");
            }
        });
        AddNewCustomerWindowOpenCommand = new RelayCommand(o =>
        {

        });

        DellCommand = new RelayCommand(o =>
        {
            if (SelectedProduct != null)
            {
                _productInBosket.Remove(SelectedProduct);
            }
        });

        CounterPlusCommand = new RelayCommand(o =>
        {
            if (SelectedProduct != null)
            {
                var p = ProductInBosket.FirstOrDefault(p => p.Id == SelectedProduct.Id);
                if (p != null)
                {
                    var updateProduce = new Product(p.Id, p.Pname, p.Price, p.Amount + 1, p.ProdType, p.Discount, p.Image, p.ProdTypeNavigation, p.ProductsSolds);
                    var index = ProductInBosket.IndexOf(p);
                    ProductInBosket[index] = updateProduce;
                }
            }
        });

        CounterMinusCommand = new RelayCommand(o =>
        {
            if (SelectedProduct != null)
            {
                var p = ProductInBosket.FirstOrDefault(p => p.Id == SelectedProduct.Id);
                if (p != null && p.Amount > 1)
                {
                    var updateProduce = new Product(p.Id, p.Pname, p.Price, p.Amount - 1, p.ProdType, p.Discount, p.Image, p.ProdTypeNavigation, p.ProductsSolds);
                    var index = ProductInBosket.IndexOf(p);
                    ProductInBosket[index] = updateProduce;
                }
                else
                {
                    _productInBosket.Remove(SelectedProduct);
                }
            }
        });
    }
    protected async void LoadDataAsync()
    {
        // Отримання товарів з бази даних
        VendorSysClient vendorSysClient = new VendorSysClient();
        _cashiers = Task.Run(() => vendorSysClient.GetCashiersAsync()).Result;

        _customers = Task.Run(() => vendorSysClient.GetCustomersAsync()).Result;
    }
    public void AddProductToBasket(Product product)
    {
        if (ProductInBosket.Where(p => p.Id == product.Id).Any())
        {
            return;
        }

        if (ProductInBosket.Contains(product))
        {
            int index = ProductInBosket.IndexOf(product);
            ProductInBosket[index].Amount = ProductInBosket[index].Amount++;
        }
        product.Amount = 1;
        ProductInBosket.Add(product);
    }
}
