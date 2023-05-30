using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;
using VendorSys.Core;

namespace VendorSys.MVVM.ViewModel
{
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
            CatalogVM = new CatalogViewModel();
            BasketVM = new BasketViewModel();

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
}
