using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VendorSys.Core;
using VendorSys.MVVM.Model;

namespace VendorSys.MVVM.ViewModel;
internal class AllOrderViewModel : BaseViewModel
{
    public ObservableCollection<AllOrderReceipt> ReceiptCollection { get; set; } = new ObservableCollection<AllOrderReceipt>();
    private List<AllOrderReceipt> _data;
    private AllOrderReceipt _selectedReceipt;
    private string? _filterText;
    private List<AllOrderReceipt> _filteredData;
    public AllOrderViewModel()
    {
        //LoadDataAsync();
        //VendorSysClient vendorSysClient = new VendorSysClient();
        ////Data = new List<Receipt>() { new Receipt() {Id =1, TotalPrice = 100, CashierId = 1, CustomerId = 1 , Date = DateTime.Now} };
        //try
        //{
        //    var receipts = Task.Run(() => vendorSysClient.GetAllReceiptsAsync()).Result;
        //    var cashiers = Task.Run(() => vendorSysClient.GetCashiersAsync()).Result;
        //    var customers = Task.Run(() => vendorSysClient.GetCustomersAsync()).Result;
        //    List<AllOrderReceipt> allOrderReceipts = new List<AllOrderReceipt>();
        //    string customerName;
        //    foreach (var receipt in receipts)
        //    {
        //        if (receipt.CustomerId == null)
        //            customerName = " ";
        //        else
        //            customerName = (from c in customers where c.Id == receipt.CustomerId select c.SecondName).First();

        //        allOrderReceipts.Add(new AllOrderReceipt(receipt.Id, receipt.TotalPrice, customerName,
        //            (from c in cashiers where c.Id == receipt.CashierId select c.SecondName ?? " ").First(),
        //            receipt.Date));
        //    }
        //    Data = allOrderReceipts;
        //}
        //catch (Exception ex)
        //{
        //    MessageBox.Show(ex.Message);
        //}
    }

    public List<AllOrderReceipt> Data
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

    public List<AllOrderReceipt> FilteredData
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

    public AllOrderReceipt SelectedReceipt
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

    protected override void LoadDataAsync()
    {
        VendorSysClient vendorSysClient = new VendorSysClient();
        //Data = new List<Receipt>() { new Receipt() {Id =1, TotalPrice = 100, CashierId = 1, CustomerId = 1 , Date = DateTime.Now} };
        try
        {
            var receipts = Task.Run(() => vendorSysClient.GetAllReceiptsAsync()).Result;
            var cashiers = Task.Run(() => vendorSysClient.GetCashiersAsync()).Result;
            var customers = Task.Run(() => vendorSysClient.GetCustomersAsync()).Result;
            List<AllOrderReceipt> allOrderReceipts = new List<AllOrderReceipt>();
            string customerName;
            foreach (var receipt in receipts)
            {
                if (receipt.CustomerId == null)
                    customerName = " ";
                else
                    customerName = (from c in customers where c.Id == receipt.CustomerId select c.SecondName).First();

                allOrderReceipts.Add(new AllOrderReceipt(receipt.Id, receipt.TotalPrice, customerName,
                    (from c in cashiers where c.Id == receipt.CashierId select c.SecondName ?? " ").First(),
                    receipt.Date));
            }
            Data = allOrderReceipts;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}
