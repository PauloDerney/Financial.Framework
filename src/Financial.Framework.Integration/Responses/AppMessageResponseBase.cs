using Financial.Framework.Domain.Responses;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Financial.Framework.Integration.Responses
{
    public class AppMessageResponseBase<T> : ResponseBase
    {
        public AppMessageResponseBase(bool success, string message) : base(success, message)
        {
        }

        public AppMessageResponseBase()
        {
        }

        [JsonPropertyName("ok")]
        public bool Ok { get; set; }

        [JsonPropertyName("result")]
        public IEnumerable<T> Result { get; set; }
    }
}
