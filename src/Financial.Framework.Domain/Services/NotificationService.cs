using Financial.Framework.Domain.Entities;
using Financial.Framework.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Financial.Framework.Domain.Services
{
    public class NotificationService : INotificationService
    {
        private List<Notification> Notifications = new List<Notification>();

        public void Push(IEnumerable<Notification> notifications) => Notifications.AddRange(notifications);

        public void Push(Notification notification) => Notifications.Add(notification);

        public void Clear() => Notifications = new List<Notification>();

        public IEnumerable<Notification> GetNotifications() => Notifications;

        public bool HasNotifications() => Notifications.Any();
    }
}
