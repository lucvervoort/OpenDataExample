using System;
using System.Collections.Generic;

namespace OpenDataExample.Models;

public partial class Result
{
    public int Id { get; set; }

    public string Straat { get; set; } = null!;

    public int GeometryId { get; set; }

    public long Huisnr { get; set; }

    public string Karakter { get; set; } = null!;

    public string Eigenaar { get; set; } = null!;

    public long Capaciteit { get; set; }

    public string Openbaar { get; set; } = null!;

    public string Ondergrond { get; set; } = null!;

    public string Bestemming { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string Urid { get; set; } = null!;

    public string Naam { get; set; } = null!;

    public string Naamid { get; set; } = null!;

    public string Bezettingsinfo { get; set; } = null!;

    public string Bronid { get; set; } = null!;

    public string Betrokkenadressen { get; set; } = null!;

    public DateTimeOffset Timestampbron { get; set; }

    public int GeoPoint2Did { get; set; }

    public int? WelcomeId { get; set; }

    public virtual GeoPoint2D GeoPoint2D { get; set; } = null!;

    public virtual ResultGeometry Geometry { get; set; } = null!;

    public virtual Welcome? Welcome { get; set; }
}
