using System.Collections.Generic;
using System.Linq;
using System.Windows;
using VendorSys.Core;

namespace VendorSys.MVVM.ViewModel;

class ProductTest // Приклад 
{
    public string? Name { get; set; }

    public string ToLower()
    {
        return Name.ToLower();
    }
}

class HomeViewModel : ObservableObject
{
    private string _filterText;
    private List<ProductTest> _data;
    private List<ProductTest> _filteredData;

    public RelayCommand AddCommand { get; set; }

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

    public List<ProductTest> FilteredData
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
        _data = new List<ProductTest>() { new ProductTest() {Name ="Test1" },
            new ProductTest() {Name ="Burger" }, 
            new ProductTest() { Name = "qweqwad" },
            new ProductTest() { Name = "123edqd" },
            new ProductTest() {Name ="asdaf" },new ProductTest() {Name ="213dqf" }, 
            new ProductTest() {Name ="asdf" },new ProductTest() {Name ="Burger" } };

        FilterData();

        // Тут описати логіку при натисканні на кнопку куди воно добавиться 
        AddCommand = new RelayCommand(o =>
        {
            MessageBox.Show("Click");
        });
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
