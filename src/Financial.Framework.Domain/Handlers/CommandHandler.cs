using Financial.Framework.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Financial.Framework.Domain.Handlers
{
    public abstract class CommandHandler<T>
    {
        protected readonly INotificationService NotificationService;
        protected readonly ILogger<T> Logger;

        protected CommandHandler(INotificationService notificationService, ILogger<T> logger)
        {
            NotificationService = notificationService;
            Logger = logger;
        }
    }
}
