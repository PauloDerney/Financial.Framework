using Financial.Framework.Domain.Entities;
using System.Collections.Generic;

namespace Financial.Framework.Domain.Interfaces
{
    public interface INotificationService
    {
        public void Push(IEnumerable<Notification> notifications);

        public void Push(Notification notification);

        public void Clear();

        public IEnumerable<Notification> GetNotifications();

        public bool HasNotifications();
    }
}
