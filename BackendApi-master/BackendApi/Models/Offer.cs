using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class Offer
{
    public int OfferId { get; set; }

    public int CustomerId { get; set; }

    public string OfferType { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime ValidUntil { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
