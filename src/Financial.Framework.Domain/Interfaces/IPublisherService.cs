using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Financial.Framework.Domain.Interfaces
{
    public interface IPublisherService
    {
        Task PublishAsync<TValue>(TValue item, string routingKey, CancellationToken cancellationToken = default) where TValue : class;

        Task PublishAsync<TValue>(IEnumerable<TValue> items, string routingKey, CancellationToken cancellationToken = default) where TValue : class;
    }
}