using Microsoft.IdentityModel.Abstractions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Xml.Linq;
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
    public RelayCommand DellCommand { get; set; }
    private Product _selectedProduct;

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
    public ObservableCollection<Product> ProductInBosket { get; set; } = new ObservableCollection<Product>();
    public Product? SelectedProduct
    {
        get { return _selectedProduct; }
        set
        {
            if(_selectedProduct != value)
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }
    }
    public BasketViewModel()
    {
        LoadDataAsync();
        BuyCommand = new RelayCommand(o =>
        {
            // тут реалізувати логіку відправки чека на сервер (Гамлет)
            MessageBox.Show("TestBuy");
        });

        DellCommand = new RelayCommand(o =>
        {
            if(SelectedProduct != null)
            {
                ProductInBosket.Remove(SelectedProduct);
            }
        });
    }
    protected async void LoadDataAsync()
    {
        // Отримання товарів з бази даних
        VendorSysClient vendorSysClient = new VendorSysClient();
        //_cashiers = Task.Run(()=>;
    }
    public void AddProductToBasket(Product product)
    {
        // Додати продукт до кошика
        if(ProductInBosket.Contains(product)) // логіка перевірки скільки на складі вже є
        {
            int index = ProductInBosket.IndexOf(product);
            ProductInBosket[index].Amount = ProductInBosket[index].Amount++;
        }
        product.Amount = 1;
        ProductInBosket.Add(product);
    }
}
