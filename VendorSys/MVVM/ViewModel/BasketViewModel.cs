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
    private Product _selectedProduct;
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
        //TEST
        ProductInBosket.Add(new Product(3, "Banana", 300, 1, 2, "image2.jpg", 25, new ProductType(), new List<ProductsSold>()));
        
       
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
