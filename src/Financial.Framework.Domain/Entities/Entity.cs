using System.Collections.Generic;
using System.Linq;

namespace Financial.Framework.Domain.Entities
{
    public abstract class Entity<T>
    {
        private readonly IList<Notification> _notifications = new List<Notification>();

        public T Id { get; set; }

        public bool Excluded { get; private set; }

        public void Exclude() => Excluded = true;

        protected void AddNotification(string key) => _notifications.Add(new Notification(key));

        protected bool HasNotifications() => _notifications.Any();

        public IEnumerable<Notification> GetNotifications() => _notifications;

        public abstract bool IsValid();
    }
}