using System.Text.Json.Serialization;

namespace Financial.Framework.Integration.Entities
{
    public class Chat
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
