using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace VendorSys.MVVM.Model;

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

    public Cashier(int id, string firstName, string secondName, string email, string phoneN, bool isFired, ICollection<Receipt> receipts)
    {
        Id = id;
        FirstName = firstName;
        SecondName = secondName;
        Email = email;
        PhoneN = phoneN;
        IsFired = isFired;
        Receipts = receipts;
    }
}
