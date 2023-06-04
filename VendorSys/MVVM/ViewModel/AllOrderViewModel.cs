using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorSys.Core;
using VendorSys.MVVM.Model;

namespace VendorSys.MVVM.ViewModel;
internal class AllOrderViewModel : ObservableObject
{
    public ObservableCollection<Receipt> ReceiptCollection { get; set; } = new ObservableCollection<Receipt>();
    private List<Receipt> _data;
    private Receipt _selectedReceipt;
    private string? _filterText;
    private List<Receipt> _filteredData;
    public AllOrderViewModel()
    { 
        Data = new List<Receipt>() { new Receipt() {Id =1, TotalPrice = 100, CashierId = 1, CustomerId = 1 , Date = DateTime.Now} };
    }

    public List<Receipt> Data
    {
        get { return _data; }
        set
        {
            if (_data != value)
            {
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }
    }

    public List<Receipt> FilteredData
    {
        get { return _filteredData; }
        set
        {
            if (_filteredData != value)
            {
                _filteredData = value;
                OnPropertyChanged(nameof(FilteredData));
            }
        }
    }

    public Receipt SelectedReceipt
    {
        get => _selectedReceipt;
        set
        {
            if (_selectedReceipt != value)
            {
                _selectedReceipt = value;
                OnPropertyChanged();
            }
        }
    }

    public string? FilterText
    {
        get => _filterText;
        set
        {
            if (_filterText != value)
            {
                _filterText = value;
                FilterData();
                OnPropertyChanged();
            }
        }
    }

    private void FilterData()
    {
        if(_filterText != "" &&  _filterText !=null)
        {
            _filteredData = _data.Where(item => item.Id.ToString().ToLower().Contains(_filterText.ToLower())).ToList();
        }
        else
        {
            _filteredData = _data;
        }
        OnPropertyChanged(nameof(FilteredData));

    }
}
