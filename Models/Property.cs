using System;
using System.Collections.Generic;

namespace OpenDataExample.Models;

public partial class Property
{
    public int Id { get; set; }

    public virtual ICollection<ResultGeometry> ResultGeometries { get; set; } = new List<ResultGeometry>();
}
