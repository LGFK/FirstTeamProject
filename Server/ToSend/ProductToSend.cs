using System;
using System.Collections.Generic;

namespace Server.ToSend;

public class ProductToSend
{
    public int Id { get; set; }

    public string Pname { get; set; } = null!;

    public decimal Price { get; set; }

    public int Amount { get; set; }

    public int? ProdType { get; set; }

    public string Image { get; set; } = null!;

    public int? Discount { get; set; }

}
