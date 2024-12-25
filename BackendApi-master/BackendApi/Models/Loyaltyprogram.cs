using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class Loyaltyprogram
{
    public int LoyaltyId { get; set; }

    public int CustomerId { get; set; }

    public decimal TotalSpending { get; set; }

    public int BonusPoints { get; set; }

    public string Tier { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
