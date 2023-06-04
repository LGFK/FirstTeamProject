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
    protected override  void LoadDataAsync()
    {
        //Thread.Sleep(6000);
        // Отримання товарів зі знижкою з бази даних
        VendorSysClient vendorSysClient = new VendorSysClient();
        /*List<Cashier> cashiers = Task.Run(() => vendorSysClient.GetCashiersAsync()).Result;
        MessageBox.Show(cashiers[0].Email);*/
        /*Thread.Sleep(6000);
        (Receipt receipt, List<Product> products) receiptProducts = await vendorSysClient.GetReceiptsAsync(1);
        MessageBox.Show($"{receiptProducts.receipt.Date}");
        var r = receiptProducts.receipt;
        var rP = receiptProducts.products;
        List<(Product, int)> productsAndAmount = new List<(Product, int)>();
        int i = 1;
        foreach (var item in rP)
        {
            productsAndAmount.Add((item, i));
            i++;
        }
        await vendorSysClient.SendNewReceiptAsync(r, productsAndAmount);

        await vendorSysClient.GetDiscountProductsAsync();*/
        Data = Task.Run(() => vendorSysClient.GetDiscountProductsAsync()).Result;        
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
