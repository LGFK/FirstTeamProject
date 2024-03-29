﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorSys.Core;
using VendorSys.MVVM.Model;

namespace VendorSys.MVVM.ViewModel;

/// <summary>
/// риватні поля _filterText, _data, _filteredData та _selectedProduct, які зберігають стан і дані ViewModel.
///Подію ProductSelected, яка відбувається при виборі продукту.
///Властивості Data, SelectedProduct, FilteredData та FilterText, які надають доступ до внутрішніх даних ViewModel та забезпечують механізм зміни властивостей.
///Приватний метод FilterData(), який застосовує фільтрацію до даних залежно від значення _filterText.
///Конструктор BaseViewModel, який викликає методи LoadData() та FilterData() для ініціалізації та фільтрації даних. 
///Він також створює команду AddCommand, яка викликає метод OnProductSelected(_selectedProduct) при виконанні команди.
///Абстрактний метод LoadData(), який повинен бути реалізований у похідних класах для завантаження даних до _data.
/// </summary>
internal abstract class BaseViewModel : ObservableObject
{

    private string? _filterText;
    private List<Product> _data;
    private List<Product> _filteredData;
    private Product _selectedProduct;
    public event EventHandler<ProductSelectedEventArgs> ProductSelected;
    protected abstract void LoadDataAsync();
    public RelayCommand AddToCartCommand { get; private set; }
    public List<Product> Data
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
    public Product? SelectedProduct
    {
        get { return _selectedProduct; }
        set
        {
            if (_selectedProduct != value)
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }
    }

    public List<Product> FilteredData
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

    private void FilterData()
    {
        if (_filterText != "" && _filterText != null)
        {
            _filteredData = _data.Where(item => item.Pname.ToLower().Contains(_filterText.ToLower())).ToList();
        }
        else
        {
            _filteredData = _data;
        }
        OnPropertyChanged(nameof(FilteredData));
    }

    protected BaseViewModel()
    {
        Task.Run(()=>LoadDataAsync()).Wait();
        FilterData();

        AddToCartCommand = new RelayCommand(AddToCart);
    }

    private void AddToCart(object parameter)
    {
        if (ProductSelected != null)
        {
            var selectedProduct = parameter as Product;
            ProductSelected?.Invoke(this, new ProductSelectedEventArgs(selectedProduct));
        }
    }
}
