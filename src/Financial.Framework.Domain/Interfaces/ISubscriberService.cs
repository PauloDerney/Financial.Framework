using Financial.Framework.Domain.Entities;

namespace Financial.Framework.Domain.Interfaces
{
    public interface ISubscriberService
    {
        void Subscribe<TCommand, TResponse>(string queue, string routingKey) where TCommand : Command<TResponse>;
    }
}