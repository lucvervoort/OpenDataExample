using System;
using System.Collections.Generic;

namespace OpenDataExample.Models;

public partial class ResultGeometry
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public int GeometryId { get; set; }

    public int PropertiesId { get; set; }

    public virtual GeometryGeometry Geometry { get; set; } = null!;

    public virtual Property Properties { get; set; } = null!;

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
