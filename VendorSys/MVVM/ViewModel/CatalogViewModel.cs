using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VendorSys.Core;
using VendorSys.MVVM.Model;

namespace VendorSys.MVVM.ViewModel;
internal class CatalogViewModel : BaseViewModel
{
    protected override void LoadDataAsync()
    {

        // Отримання товарів з бази даних
        VendorSysClient vendorSysClient = new VendorSysClient();
        //Receipt r = new Receipt();
        
        //r.TotalPrice = 315500;
        //r.CustomerId =1;
        //r.CashierId = 1;
        //r.Date = DateTime.Now;
        //int i = 1;
        //var p = Task.Run(() => vendorSysClient.GetProductsAsync()).Result;
        //List<int> a = new List<int>();
        //foreach (var item in p)
        //{
        //    a.Add(i);
        //    i++;
        //}
        //vendorSysClient.SendNewReceiptAsync(r, p,a).Wait();
        //vendorSysClient.GetProductsAsync();
        //var products = Task.Run(() => vendorSysClient.GetProductsAsync()).Result;
        Data = Task.Run(() => vendorSysClient.GetProductsAsync()).Result;
    }
    // Додатковий код специфічний для CatalogViewModel
}







/// <summary>
/// Властивість FilterText, яка відповідає за текст фільтрації продуктів у каталозі.
///Властивість FilteredData, яка представляє відфільтровану колекцію продуктів у каталозі.
///Властивість SelectedProduct, яка представляє обраний продукт у каталозі.
///Подія ProductSelected, яка виникає при виборі продукту і має підписників, які можуть реагувати на цю подію.
///Метод OnProductSelected, який викликає подію ProductSelected і передає обраний продукт у вигляді аргументу події.
///Метод FilterData, який виконує фільтрацію продуктів згідно з введеним текстом фільтра.
/// </summary>
//internal class CatalogViewModel : ObservableObject
//{
//    private string _filterText;
//    private List<Product> _data;
//    private List<Product> _filteredData;
//    private Product _selectedProduct;
//    public event EventHandler<ProductSelectedEventArgs> ProductSelected;
//    public RelayCommand AddCommand { get; set; }
//    public Product? SelectedProduct
//    {
//        get { return _selectedProduct; }
//        set
//        {
//            if (_selectedProduct != value)
//            {
//                _selectedProduct = value;
//                OnPropertyChanged();
//            }
//        }
//    }

//    public List<Product> FilteredData
//    {
//        get { return _filteredData; }
//        set
//        {
//            _filteredData = value;
//            OnPropertyChanged(nameof(FilteredData));
//        }
//    }
//    public CatalogViewModel()
//    {
//        ProductRepository.ReadProductRepository();
//        _data = ProductRepository.Products.ToList();
//        FilterData();

//        AddCommand = new RelayCommand(o =>
//        {
//            if(_selectedProduct != null)
//            {
//                OnProductSelected(_selectedProduct);
//            }            
//        });
//    }

//    /// <summary>
//    /// Цей метод OnProductSelected викликає подію ProductSelected, якщо є підписники (subscribers), і передає обраний продукт у вигляді аргументу події.
//    /// </summary>
//    /// <param name="selectedProduct"></param>
//    private void OnProductSelected(Product selectedProduct)
//    {
//        ProductSelected?.Invoke(this, new ProductSelectedEventArgs(selectedProduct));
//    }
//    public string FilterText
//    {
//        get { return _filterText; }
//        set
//        {
//            if (_filterText != value)
//            {
//                _filterText = value;
//                FilterData();
//                OnPropertyChanged(nameof(FilterText));
//            }
//        }
//    }
//    private void FilterData()
//    {
//        if (_filterText != "" && _filterText != null)
//        {
//            _filteredData = _data.Where(item => item.ToLower().Contains(_filterText.ToLower())).ToList();
//        }
//        else
//        {
//            _filteredData = _data;
//        }
//        OnPropertyChanged(nameof(FilteredData));
//    }
//}
