using System.Text.Json.Serialization;

namespace Financial.Framework.Integration.Entities
{
    public class From
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("is_bot")]
        public bool IsBot { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("language_code")]
        public string LanguageCode { get; set; }
    }
}
