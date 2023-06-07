using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Server.DB;

public partial class Customer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string? Email { get; set; }

    public string? PhoneN { get; set; }
    [JsonIgnore]
    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();
}
