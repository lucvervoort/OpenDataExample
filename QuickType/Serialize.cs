using System.Text.Json;
using OpenDataExample.Models;

namespace OpenDataExample.QuickType
{
    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonSerializer.Serialize(self, Converter.Settings);
    }
}
