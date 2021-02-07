using Financial.Framework.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Financial.Framework.Domain.Handlers
{
    public class EventHandler<T>
    {
        protected readonly IMessageQueueService MessageQueueService;
        protected readonly ILogger<T> Logger;

        public EventHandler(IMessageQueueService messageQueueService, ILogger<T> logger)
        {
            MessageQueueService = messageQueueService;
            Logger = logger;
        }
    }
}
