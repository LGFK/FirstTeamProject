using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ManagerClient.Model;

public partial class ProductsSold
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int AmountSold { get; set; }

    public int? ReceiptId { get; set; }
    [JsonIgnore]
    public virtual Product? Product { get; set; }
    [JsonIgnore]
    public virtual Receipt? Receipt { get; set; }
    public ProductsSold(int id, int? productId, int amountSold, int? receiptId, Product? product, Receipt? receipt)
    {
        Id = id;
        ProductId = productId;
        AmountSold = amountSold;
        ReceiptId = receiptId;
        Product = product;
        Receipt = receipt;
    }
}
