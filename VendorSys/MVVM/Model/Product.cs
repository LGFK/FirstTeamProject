﻿using Newtonsoft.Json;
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

    public byte[] Image { get; set; } = null!;

    public int? Discount { get; set; }
    [JsonIgnore]
    public virtual ProductType? ProdTypeNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<ProductsSold> ProductsSolds { get; set; } = new List<ProductsSold>();
    public Product(int id, string pname, decimal price, int amount, int? prodType, int? discount, byte[] image, ProductType? prodTypeNavigation, ICollection<ProductsSold> productsSolds)
    {
        
        Id = id;
        Pname = pname;
        Price = price;
        Amount = amount;
        ProdType = prodType;
        Discount = discount;
        ProdTypeNavigation = prodTypeNavigation;
        ProductsSolds = productsSolds;
        
    }
    //public string ToLower()
    //{
    //    return Pname.ToLower();
    //}
}
