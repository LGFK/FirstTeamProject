using System.Windows;
using VendorSys.Core;
using VendorSys.MVVM.View;

namespace VendorSys.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand CatalogViewCommand { get; set; }
        public RelayCommand ButtonMinimizeClickCommand { get; set; }
        public RelayCommand WindowsSateButtonClickCommand { get; set; }
        public RelayCommand CoseButtonClickCommand { get; set; }
        //~~~~~~~~~~//
        public HomeViewModel HomeVM { get; set; }
        public CatalogView CatalogVM { get; set; }


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
            HomeVM = new HomeViewModel();
            CatalogVM = new CatalogView();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            CatalogViewCommand = new RelayCommand(o =>
            {
                CurrentView = CatalogVM;
            });

            ButtonMinimizeClickCommand = new RelayCommand(o =>
            {
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
            });

            WindowsSateButtonClickCommand = new RelayCommand(o =>
            {
                if(Application.Current.MainWindow.WindowState != WindowState.Maximized)
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
                else
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
            });

            CoseButtonClickCommand = new RelayCommand(o =>
            {
                Application.Current.Shutdown();
            });



            /*            Page = new RelayCommand(o =>
                        {
                            CurrentView = PageVM;
                        });*/

        }
    }
}
