using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Financial.Framework.Domain.Interfaces;
using Financial.Framework.Infra.Service.AppModels;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Financial.Framework.Infra.Service.Services
{
    public class MessageQueueService : IMessageQueueService
    {
        private readonly QueueSettings _settings;

        public MessageQueueService(IOptions<QueueSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task<bool> PublishAsync<TValue>(TValue item, string routingKey, CancellationToken cancellationToken = default) where TValue : class
        {
            return await PublishAsync<TValue>(new List<TValue> { item }, routingKey, cancellationToken);
        }

        public async Task<bool> PublishAsync<TValue>(IEnumerable<TValue> items, string routingKey, CancellationToken cancellationToken = default) where TValue : class
        {
            return await Task.Run(() =>
            {
                try
                {
                    using var connection = GetConnectionFactory().CreateConnection();
                    using var channel = connection.CreateModel();

                    channel.ExchangeDeclare(_settings.Exchange, ExchangeType.Topic, true, false);

                    var batch = channel.CreateBasicPublishBatch();

                    foreach (var item in items)
                        batch.Add(_settings.Exchange, routingKey, false, null, Encoding.UTF8.GetBytes(JsonSerializer.Serialize(item)));

                    if (!cancellationToken.IsCancellationRequested)
                        batch.Publish();

                    return Task.FromResult(true);
                }
                catch (Exception ex)
                {
                    throw;
                    //Todo: Log
                }
            }, cancellationToken);
        }

        private ConnectionFactory GetConnectionFactory()
        {
            return new ConnectionFactory
            {
                HostName = _settings.HostName,
                UserName = _settings.UserName,
                Password = _settings.Password,
                Port = _settings.Port,
                RequestedConnectionTimeout = _settings.Timeout
            };
        }
    }
}