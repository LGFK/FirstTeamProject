using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using VendorSys.Core;
using VendorSys.MVVM.Model;

namespace VendorSys.MVVM.ViewModel;
class AddCustomerViewModel : ObservableObject
{
    private string? _firstName;
    private string? _lastName;
    private string? _email;
    private string? _phone;
    public RelayCommand AddCommand { get; set; }
    public string FirstName
    {
        get => _firstName;
        set
        {
            if (_firstName != value)
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
    }
    public string? LastName { get => _lastName; set => _lastName = value; }
    public string? Email { get => _email; set => _email = value; }
    public string? Phone { get => _phone; set => _phone = value; }


    public AddCustomerViewModel() 
    {      
        AddCommand = new RelayCommand(o =>
        {
            //Реалізувати логіку відправки нового клієнта на сервер
            MessageBox.Show($"{FirstName}\n{LastName}\n{Email}\n{Phone}");
            VendorSysClient vendorSysClient = new VendorSysClient();
            Customer customer = new Customer();
            customer.FirstName = FirstName;
            customer.SecondName = LastName;
            customer.Email = Email;
            customer.PhoneN = Phone;
            vendorSysClient.SendNewCustomerAsync(customer).Wait();
        });
    }
}
