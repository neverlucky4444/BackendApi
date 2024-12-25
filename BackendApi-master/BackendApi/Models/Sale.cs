using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public int CustomerId { get; set; }

    public string Item { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal Amount { get; set; }

    public DateTime? SaleDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
