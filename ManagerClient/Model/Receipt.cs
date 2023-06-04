﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ManagerClient.Model;

public partial class Receipt
{
    public int Id { get; set; }

    public decimal TotalPrice { get; set; }

    public int? CustomerId { get; set; }

    public int? CashierId { get; set; }

    public DateTime Date { get; set; }
    [JsonIgnore]
    public virtual Cashier? Cashier { get; set; }
    [JsonIgnore]
    public virtual Customer? Customer { get; set; }
    [JsonIgnore]
    public virtual ICollection<ProductsSold> ProductsSolds { get; set; } = new List<ProductsSold>();
}