using System;
using System.Collections.Generic;

namespace OpenDataExample.Models;

public partial class Welcome
{
    public int Id { get; set; }

    public long TotalCount { get; set; }

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
