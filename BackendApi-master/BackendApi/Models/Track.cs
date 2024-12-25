using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class Track
{
    public int TrackId { get; set; }

    public string TrackName { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int TrackLength { get; set; }

    public int MaxCapacity { get; set; }

    public virtual ICollection<Race> Races { get; set; } = new List<Race>();
}
