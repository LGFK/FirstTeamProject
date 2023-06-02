using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VendorSys.Core;
using VendorSys.MVVM.Model;

namespace VendorSys.MVVM.ViewModel;
/// <summary>
/// Читання списку продуктів з репозиторію (ProductRepository) за допомогою методу ReadProductRepository().
///Ініціалізація списку продуктів(_data) з продуктами, що мають знижку(Discount).
///Фільтрація списку продуктів залежно від значення властивості FilterText.Якщо FilterText не є порожнім або null, 
///відбувається фільтрація продуктів за назвою, і результат зберігається у властивості FilteredData.
///Оновлення відображення списку продуктів за допомогою методу OnPropertyChanged().
/// </summary>
class HomeViewModel : ObservableObject
{
    private string _filterText;
    private List<Product> _data;
    private List<Product> _filteredData;

    public string FilterText
    {
        get { return _filterText; }
        set
        {
            if (_filterText != value)
            {
                _filterText = value;
                FilterData();
                OnPropertyChanged(nameof(FilterText));
            }
        }
    }

    public List<Product> FilteredData
    {
        get { return _filteredData; }
        set
        {
            _filteredData = value;
            OnPropertyChanged(nameof(FilteredData));
        }
    }
    public HomeViewModel()
    {
        ProductRepository.ReadProductRepository();
        _data = ProductRepository.Products.Where(item => item.Discount > 0).ToList();
        FilterData();
    }

    private void FilterData()
    {
        if (_filterText != "" && _filterText != null)
        {
            _filteredData = _data.Where(item => item.ToLower().Contains(_filterText.ToLower())).ToList();
        }
        else
        {
            _filteredData = _data;
        }
        OnPropertyChanged(nameof(FilteredData));
    }
}
