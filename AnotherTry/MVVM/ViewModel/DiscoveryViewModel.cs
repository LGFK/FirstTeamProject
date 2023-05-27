using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnotherTry.Model;

namespace AnotherTry.MVVM.ViewModel;
internal class DiscoveryViewModel
{
    public ObservableCollection<Customer> Customers { get; set; }
    
    public DiscoveryViewModel()
    {
        Customers = new ObservableCollection<Customer>() { new Customer(14,"12313","Chester"),
         new Customer(14,"12313","Oleksiy"),new Customer(100,"111111","Zhenia")};
    }


}
