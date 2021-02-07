using System.Text.Json.Serialization;

namespace Financial.Framework.Integration.Entities
{
    public class MessageContext
    {
        [JsonPropertyName("update_id")]
        public long UpdateId { get; set; }

        [JsonPropertyName("message")]
        public Message Message { get; set; }
    }
}
