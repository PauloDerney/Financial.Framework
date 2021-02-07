using MediatR;
using System;

namespace Financial.Framework.Domain.Entities
{
    public class Event : INotification
    {
        public Event()
        {
            GenerationDate = DateTime.Now;
        }

        public DateTime GenerationDate { get; set; }

        public string CorrelationId { get; private set; }

        public void SetCorrelationId(string correlationId) => CorrelationId = correlationId;

        public void GenerateNewCorrelationId() => CorrelationId = Guid.NewGuid().ToString();
    }
}