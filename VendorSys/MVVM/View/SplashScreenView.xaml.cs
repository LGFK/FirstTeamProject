using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace VendorSys.MVVM.View;
/// <summary>
/// Interaction logic for SplashScreenView.xaml
/// </summary>
public partial class SplashScreenView : Window
{
    readonly DispatcherTimer DispatcherTimer = new();
    public SplashScreenView()
    {
        InitializeComponent();

        DispatcherTimer.Tick += new EventHandler(MySplash);
        DispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        DispatcherTimer.Start();
    }

    private void MySplash(object? sender, EventArgs e)
    {
        MainWindow mainWindow = new ();
        mainWindow.Show();

        DispatcherTimer.Stop();
        Application.Current.MainWindow = mainWindow;
        this.Close();
    }
}
