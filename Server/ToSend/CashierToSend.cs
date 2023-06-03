using System;
using System.Collections.Generic;
using Server.DB;

namespace Server.ToSend;

public class CashierToSend
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneN { get; set; } = null!;

    public bool IsFired { get; set; }

    
}
