namespace Financial.Framework.MessageBroker.Entities
{
    public class Message<T>
    {
        public T Payload { get; set; }
    }
}