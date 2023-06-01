using System;
using System.Collections.Generic;

namespace VendorSys.MVVM.Model;

public partial class Product
{
    public int Id { get; set; }

    public string Pname { get; set; } = null!;

    public decimal Price { get; set; }

    public int Amount { get; set; }

    public int? ProdType { get; set; }

    public string Image { get; set; } = null!;

    public int? Discount { get; set; }

    public virtual ProductType? ProdTypeNavigation { get; set; }

    public virtual ICollection<ProductsSold> ProductsSolds { get; set; } = new List<ProductsSold>();
    public Product(int id, string pname, decimal price, int amount, int? prodType, string image, int? discount, ProductType? prodTypeNavigation, ICollection<ProductsSold> productsSolds)
    {
        Id = id;
        Pname = pname;
        Price = price;
        Amount = amount;
        ProdType = prodType;
        Image = image;
        Discount = discount;
        ProdTypeNavigation = prodTypeNavigation;
        ProductsSolds = productsSolds;
    }
    public string ToLower()
    {
        return Pname.ToLower();
    }
}
