using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Financial.Framework.Integration.Entities
{
    public class Message
    {
        [JsonPropertyName("message_id")]
        public long MessageId { get; set; }

        [JsonPropertyName("from")]
        public From From { get; set; }

        [JsonPropertyName("chat")]
        public Chat Chat { get; set; }

        [JsonPropertyName("date")]
        public long Date { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("entities")]
        public List<Entity> Entities { get; set; }
    }
}
