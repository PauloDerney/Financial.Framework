using Financial.Framework.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Financial.Framework.Domain.Handlers
{
    public class EventHandler<T>
    {
        protected readonly IPublisherService MessageQueueService;
        protected readonly ILogger<T> Logger;

        public EventHandler(IPublisherService messageQueueService, ILogger<T> logger)
        {
            MessageQueueService = messageQueueService;
            Logger = logger;
        }
    }
}
