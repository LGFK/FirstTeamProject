using System;
using System.Collections.Generic;

namespace VendorSys.MVVM.Model;

public partial class Customer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string? Email { get; set; }

    public string? PhoneN { get; set; }

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();

    public Customer(int id, string firstName, string secondName, string? email, string? phoneN, ICollection<Receipt> receipts)
    {
        Id = id;
        FirstName = firstName;
        SecondName = secondName;
        Email = email;
        PhoneN = phoneN;
        Receipts = receipts;
    }
}
