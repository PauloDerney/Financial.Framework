namespace Financial.Framework.Domain.Interfaces
{
    public interface ISubscriberService
    {
        void Subscribe<TCommand>(string queue, string routingKey) where TCommand : class;
    }
}