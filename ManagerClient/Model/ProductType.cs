using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ManagerClient.Model;

public partial class ProductType
{
    public int Id { get; set; }

    public string? TypeName { get; set; }
    [JsonIgnore]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
