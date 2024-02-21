using System;
using System.Collections.Generic;

namespace OpenDataExample.Models;

public partial class GeoPoint2D
{
    public int Id { get; set; }

    public double Lon { get; set; }

    public double Lat { get; set; }

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
