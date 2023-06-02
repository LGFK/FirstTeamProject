using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorSys.MVVM.Model;
public class ProductSelectedEventArgs : EventArgs
{
    public Product SelectedProduct { get; }
    public ProductSelectedEventArgs(Product selectedProduct)
    {
        SelectedProduct = selectedProduct;
    }
}
