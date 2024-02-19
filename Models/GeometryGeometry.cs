using System.Text.Json.Serialization;

namespace OpenDataExample.Models
{
    public partial class GeometryGeometry
    {
        public int Id { get; set; }

        [JsonPropertyName("coordinates")]
        public virtual List<List<List<double>>> Coordinates { get; set; }

        [JsonPropertyName("type")]
        public virtual string Type { get; set; }
    }
}
