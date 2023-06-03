using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Server.DB;

public partial class Product
{
    public int Id { get; set; }

    public string Pname { get; set; } = null!;

    public decimal Price { get; set; }

    public int Amount { get; set; }

    public int? ProdType { get; set; }

    public string Image { get; set; } = null!;

    public int? Discount { get; set; }
    [JsonIgnore]
    public virtual ProductType? ProdTypeNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<ProductsSold> ProductsSolds { get; set; } = new List<ProductsSold>();
    
}
