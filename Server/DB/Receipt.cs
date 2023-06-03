﻿using System;
using System.Collections.Generic;
using Server.DB.ConfigFiles;

namespace Server.DB;

public partial class Receipt
{
    public int Id { get; set; }

    public decimal TotalPrice { get; set; }

    public int? CustomerId { get; set; }

    public int? CashierId { get; set; }

    public DateTime Date { get; set; }

    public virtual Cashier? Cashier { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<ProductsSold> ProductsSolds { get; set; } = new List<ProductsSold>();
}
