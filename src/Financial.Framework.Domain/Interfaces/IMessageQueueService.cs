using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Financial.Framework.Domain.Interfaces
{
    public interface IMessageQueueService
    {
        Task<bool> PublishAsync<TValue>(TValue item, string routingKey, CancellationToken cancellationToken = default) where TValue : class;

        Task<bool> PublishAsync<TValue>(IEnumerable<TValue> items, string routingKey, CancellationToken cancellationToken = default) where TValue : class;
    }
}
