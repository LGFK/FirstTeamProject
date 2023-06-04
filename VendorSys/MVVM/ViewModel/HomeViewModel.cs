using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using VendorSys.Core;
using VendorSys.MVVM.Model;

namespace VendorSys.MVVM.ViewModel;

internal class HomeViewModel : BaseViewModel
{
   
    protected override void LoadDataAsync()
    {
        // Логіка отримання даних товарів на знижку з бази даних
        //ProductRepository.ReadProductRepository();
        //Data = ProductRepository.Products.ToList();

        VendorSysClient vendorSysClient = new VendorSysClient();
        //Thread.Sleep(6000);
        vendorSysClient.GetProductsAsync();
        //vendorSysClient.GetReceiptsAsync(1);
        Data = vendorSysClient.Products;
        
    }
    // Додатковий код специфічний для HomeViewModel

}











/// <summary>
/// Читання списку продуктів з репозиторію (ProductRepository) за допомогою методу ReadProductRepository().
///Ініціалізація списку продуктів(_data) з продуктами, що мають знижку(Discount > 0).
///Фільтрація списку продуктів залежно від значення властивості FilterText.Якщо FilterText не є порожнім або null, 
///відбувається фільтрація продуктів за назвою, і результат зберігається у властивості FilteredData.
///Оновлення відображення списку продуктів за допомогою методу OnPropertyChanged().
/// </summary>
//internal class HomeViewModel : ObservableObject
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
//                OnPropertyChanged(nameof(SelectedProduct));
//            }
//        }
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

//    public List<Product> FilteredData
//    {
//        get { return _filteredData; }
//        set
//        {
//            _filteredData = value;
//            OnPropertyChanged(nameof(FilteredData));
//        }
//    }
//    public HomeViewModel()
//    {
//        ProductRepository.ReadProductRepository();
//        _data = ProductRepository.Products.Where(item => item.Discount > 0).ToList();
//        FilterData();

//        AddCommand = new RelayCommand(o =>
//        {
//            if (_selectedProduct != null)
//            {
//                OnProductSelected(_selectedProduct);
//            }
//        });
//    }

//    private void OnProductSelected(Product selectedProduct)
//    {
//        ProductSelected?.Invoke(this, new ProductSelectedEventArgs(selectedProduct));
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
