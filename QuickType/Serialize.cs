using System.Text.Json;
using OpenDataExample.Models;

namespace OpenDataExample.QuickType
{
    public static class Serialize
    {
        public static string ToJson(this Fietsenstalling self) => JsonSerializer.Serialize(self, Converter.Settings);
    }
}
