using Microsoft.IdentityModel.Abstractions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        BuyCommand = new RelayCommand(o =>
        {
            // тут реалізувати логіку відправки чека на сервер (Гамлет)
            MessageBox.Show("TestBuy");
        });

        DellCommand = new RelayCommand(o =>
        {
            if(SelectedProduct != null)
            {
                _productInBosket.Remove(SelectedProduct);
            }
        });

        CounterPlusCommand = new RelayCommand(o =>
        {
            if (SelectedProduct != null)
            {
                var p = ProductInBosket.FirstOrDefault(p=> p.Id == SelectedProduct.Id);
                if (p != null)
                {
                    var updateProduce = new Product(p.Id,p.Pname, p.Price, p.Amount+1, p.ProdType,p.Image, p.Discount, p.ProdTypeNavigation, p.ProductsSolds);
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
                if (p != null && p.Amount >1)
                {
                    var updateProduce = new Product(p.Id, p.Pname, p.Price, p.Amount - 1, p.ProdType, p.Image, p.Discount, p.ProdTypeNavigation, p.ProductsSolds);
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

    public void AddProductToBasket(Product product)
    {
        if (ProductInBosket.Where(p => p.Id == product.Id).Any())
        {
            return;
        }
        
        if(ProductInBosket.Contains(product)) // логіка перевірки скільки на складі вже є
        {
            int index = ProductInBosket.IndexOf(product);
            ProductInBosket[index].Amount = ProductInBosket[index].Amount++;
        }
        product.Amount = 1;
        ProductInBosket.Add(product);
    }
}
