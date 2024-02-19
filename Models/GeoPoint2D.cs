using System.Text.Json.Serialization;

namespace OpenDataExample.Models
{
    public partial class GeoPoint2D
    {
        public int Id { get; set; }

        [JsonPropertyName("lon")]
        public virtual double Lon { get; set; }

        [JsonPropertyName("lat")]
        public virtual double Lat { get; set; }
    }
}
