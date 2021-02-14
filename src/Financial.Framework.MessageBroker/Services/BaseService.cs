using Financial.Framework.MessageBroker.AppModels;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;

namespace Financial.Framework.MessageBroker.Services
{
    public abstract class BaseService
    {
        protected readonly QueueSettings QueueSettings;

        protected BaseService(IOptions<QueueSettings> settings)
        {
            QueueSettings = settings.Value;
        }

        protected ConnectionFactory GetConnectionFactory()
        {
            return new ConnectionFactory
            {
                HostName = QueueSettings.HostName,
                UserName = QueueSettings.UserName,
                Password = QueueSettings.Password,
                Port = QueueSettings.Port,
                RequestedConnectionTimeout = TimeSpan.FromSeconds(QueueSettings.Timeout)
            };
        }
    }
}