using System.Collections.Generic;
using System.Linq;
using VendorSys.Core;
using VendorSys.MVVM.Model;

namespace VendorSys.MVVM.ViewModel;
internal class CatalogViewModel : ObservableObject
{
    private string _filterText;
    private List<Model.Product> _data;
    private List<Model.Product> _filteredData;

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

    public List<Model.Product> FilteredData
    {
        get { return _filteredData; }
        set
        {
            _filteredData = value;
            OnPropertyChanged(nameof(FilteredData));
        }
    }
    public CatalogViewModel()
    {
        ProductRepository.ReadProductRepository();
        _data = ProductRepository.Products.ToList();
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
