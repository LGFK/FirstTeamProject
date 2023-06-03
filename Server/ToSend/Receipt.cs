using System;
using System.Collections.Generic;
using Server.DB.ConfigFiles;

namespace Server.ToSend;
public partial class ReceiptToSend
{
    public int Id { get; set; }

    public decimal TotalPrice { get; set; }

    public int? CustomerId { get; set; }

    public int? CashierId { get; set; }

    public DateTime Date { get; set; }

    

    
}
