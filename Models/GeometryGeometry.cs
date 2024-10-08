﻿using System;
using System.Collections.Generic;

namespace OpenDataExample.Models;

public partial class GeometryGeometry
{
    public int Id { get; set; }

    public string Coordinates { get; set; } = null!;

    public string Type { get; set; } = null!;

    public virtual ICollection<ResultGeometry> ResultGeometries { get; set; } = new List<ResultGeometry>();
}
