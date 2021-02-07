using System.Collections.Generic;
using System.Linq;

namespace Financial.Framework.Domain.Entities
{
    public abstract class Collection<TEntity, TIdentifier> where TEntity : Entity<TIdentifier>
    {
        private readonly IList<Notification> _notifications;

        public Collection()
        {
            _notifications = new List<Notification>();
        }

        public abstract bool IsValid();

        public IEnumerable<Notification> GetNotifications() => _notifications;

        protected bool HasNotifications() => _notifications.Any();

        protected void Push(IEnumerable<Notification> notifications)
        {
            foreach (var notification in notifications)
                _notifications.Add(notification);
        }
    }
}
