using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace VendorSys.MVVM.Model;

public partial class ProductType
{
    public int Id { get; set; }

    public string? TypeName { get; set; }
    [JsonIgnore]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
