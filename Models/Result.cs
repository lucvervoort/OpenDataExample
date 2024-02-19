using System.Text.Json.Serialization;

namespace OpenDataExample.Models
{
    public partial class Result
    {
        public int Id { get; set; }

        [JsonPropertyName("straat")]
        public virtual string Straat { get; set; }

        [JsonPropertyName("geometry")]
        public virtual ResultGeometry Geometry { get; set; }

        [JsonPropertyName("huisnr")]
        [JsonConverter(typeof(QuickType.ParseStringConverter))]
        public virtual long Huisnr { get; set; }

        [JsonPropertyName("karakter")]
        public virtual string Karakter { get; set; }

        [JsonPropertyName("eigenaar")]
        public virtual string Eigenaar { get; set; }

        [JsonPropertyName("capaciteit")]
        public virtual long Capaciteit { get; set; }

        [JsonPropertyName("openbaar")]
        public virtual string Openbaar { get; set; }

        [JsonPropertyName("ondergrond")]
        public virtual string Ondergrond { get; set; }

        [JsonPropertyName("bestemming")]
        public virtual string Bestemming { get; set; }

        [JsonPropertyName("status")]
        public virtual string Status { get; set; }

        [JsonPropertyName("urid")]
        public virtual string Urid { get; set; }

        [JsonPropertyName("naam")]
        public virtual string Naam { get; set; }

        [JsonPropertyName("naamid")]
        public virtual string Naamid { get; set; }

        [JsonPropertyName("bezettingsinfo")]
        public virtual string Bezettingsinfo { get; set; }

        [JsonPropertyName("bronid")]
        public virtual string Bronid { get; set; }

        [JsonPropertyName("betrokkenadressen")]
        public virtual string Betrokkenadressen { get; set; }

        [JsonPropertyName("timestampbron")]
        public virtual DateTimeOffset Timestampbron { get; set; }

        [JsonPropertyName("geo_point_2d")]
        public virtual GeoPoint2D GeoPoint2D { get; set; }
    }
}
