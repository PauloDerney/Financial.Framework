using System;

namespace Financial.Framework.Subscriber.Entities
{
    public class MessageBase
    {
        public string CorrelationId { get; set; }

        public DateTime ReceiveDate { get; set; }
    }
}