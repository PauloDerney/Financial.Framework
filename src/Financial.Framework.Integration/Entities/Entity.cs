using System.Text.Json.Serialization;

namespace Financial.Framework.Integration.Entities
{
    public class Entity
    {
        [JsonPropertyName("offset")]
        public long OffSet { get; set; }

        [JsonPropertyName("length")]
        public long Length { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
