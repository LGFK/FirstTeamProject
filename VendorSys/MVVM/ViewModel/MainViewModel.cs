using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using VendorSys.Core;
using VendorSys.MVVM.Model;

namespace VendorSys.MVVM.ViewModel;
/// <summary>
/// Властивості RelayCommand для керування командами кнопок.
///Властивості HomeVM, CatalogVM і BasketVM для інстанціювання відповідних моделей представлення.
///Властивість CurrentView, яка представляє поточне відображення на основі обраної сторінки(Home, Catalog, Basket).
///Ініціалізація моделей представлення та налаштування команд переключення між сторінками.
///Підписка на подію ProductSelected в CatalogVM і виклик методу AddProductToBasket в BasketVM при виборі продукту з каталогу.
/// </summary>
class MainViewModel : ObservableObject
{
    public RelayCommand HomeViewCommand { get; set; }
    public RelayCommand CatalogViewCommand { get; set; }
    public RelayCommand BasketViewCommand { get; set; }
    public RelayCommand ButtonMinimizeClickCommand { get; set; }
    public RelayCommand WindowsSateButtonClickCommand { get; set; }
    public RelayCommand CoseButtonClickCommand { get; set; }

    //~~~~~~~~~~//
    public HomeViewModel HomeVM { get; set; }
    public CatalogViewModel CatalogVM { get; set; }
    public BasketViewModel BasketVM { get; set; }

    private object _currentView;
    public object CurrentView
    {
        get { return _currentView; }
        set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public MainViewModel()
    {
        SwitchBetweenPages();
        ButtonLogic();
    }

    private void ButtonLogic()
    {
        ButtonMinimizeClickCommand = new RelayCommand(o =>
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        });

        WindowsSateButtonClickCommand = new RelayCommand(o =>
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            else
                Application.Current.MainWindow.WindowState = WindowState.Normal;
        });

        CoseButtonClickCommand = new RelayCommand(o =>
        {
            Application.Current.Shutdown();
        });
    }

    private void SwitchBetweenPages()
    {
        HomeVM = new HomeViewModel();
        BasketVM = new BasketViewModel();
        CatalogVM = new CatalogViewModel();

        //Підписка на подію додавання із каталога в кошик товарів
        CatalogVM.ProductSelected += (sender, e) => BasketVM.AddProductToBasket(e.SelectedProduct);

        CurrentView = HomeVM;

        HomeViewCommand = new RelayCommand(o =>
        {
            CurrentView = HomeVM;
        });

        CatalogViewCommand = new RelayCommand(o =>
        {
            CurrentView = CatalogVM;
        });

        BasketViewCommand = new RelayCommand(o =>
        {
            CurrentView = BasketVM;
        });
    }
}
