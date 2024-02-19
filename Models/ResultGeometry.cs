using System.Text.Json.Serialization;

namespace OpenDataExample.Models
{
    public partial class ResultGeometry
    {
        public int Id { get; set; }

        [JsonPropertyName("type")]
        public virtual string Type { get; set; }

        [JsonPropertyName("geometry")]
        public virtual GeometryGeometry Geometry { get; set; }

        [JsonPropertyName("properties")]
        public virtual Properties Properties { get; set; }
    }
}
