using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorSys.Core;

namespace VendorSys.MVVM.ViewModel;
internal class AllOrderViewModel : BaseViewModel
{
    public AllOrderViewModel()
    { 

    }

    protected override void LoadDataAsync()
    {
        // організувати логіку отримання данних із бази (Чека)
        //Data = (Чек)
    }
}
