using Financial.Framework.Domain.Interfaces;
using Financial.Framework.MessageBroker.AppModels;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Financial.Framework.MessageBroker.Services
{
    public class PublisherService : BaseService, IPublisherService
    {
        public PublisherService(QueueSettings settings) : base(settings) { }

        public async Task PublishAsync<TValue>(TValue item, string routingKey, CancellationToken cancellationToken = default) where TValue : class
        {
            await PublishAsync<TValue>(new List<TValue> { item }, routingKey, cancellationToken);
        }

        public async Task PublishAsync<TValue>(IEnumerable<TValue> items, string routingKey, CancellationToken cancellationToken = default) where TValue : class
        {
            await Task.Run(() =>
            {
                try
                {
                    using var connection = GetConnectionFactory().CreateConnection();
                    using var channel = connection.CreateModel();

                    channel.ExchangeDeclare(QueueSettings.Exchange, ExchangeType.Topic, true, false);

                    var batch = channel.CreateBasicPublishBatch();

                    Parallel.ForEach(items, item =>
                    {
                        batch.Add(QueueSettings.Exchange, routingKey, false, null,
                            new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(item))));
                    });

                    if (!cancellationToken.IsCancellationRequested)
                        batch.Publish();
                }
                catch (Exception ex)
                {
                    Console.Write($"[PublisherService.PublishAsync] Error sending message.{ex.Message}");
                }

            }, cancellationToken);
        }
    }
}