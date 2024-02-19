using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenDataExample.Models
{
    public class Welcome
    {
        public int Id { get; set; }

        [JsonPropertyName("total_count")]
        public virtual long TotalCount { get; set; }

        [JsonPropertyName("results")]
        public virtual List<Result>? Results { get; set; }
        public static Welcome FromJson(string json) => JsonSerializer.Deserialize<Welcome>(json, QuickType.Converter.Settings);
    }
}
