using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class Race
{
    public int RaceId { get; set; }

    public int CustomerId { get; set; }

    public int TrackId { get; set; }

    public DateTime RaceDate { get; set; }

    public int Duration { get; set; }

    public decimal Cost { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Track Track { get; set; } = null!;
}
