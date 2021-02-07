using MediatR;

namespace Financial.Framework.Domain.Entities
{
    public class Command<T> : IRequest<T>
    {
        public string CorrelationId { get; set; }
    }
}