using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ManagerClient.Model;

public partial class Cashier
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneN { get; set; } = null!;

    public bool IsFired { get; set; }
    [JsonIgnore]
    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();
}
