using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorSys.Core;
using VendorSys.MVVM.Model;

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
        //VendorSysClient vendorSysClient = new VendorSysClient();
        //(Receipt receipt,List<Product> products) receiptProducts = Task.Run(() => vendorSysClient.GetReceiptsAsync(1)).Result;
        //Data = receiptProducts.products;
    }
}
