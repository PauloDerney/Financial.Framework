using Financial.Framework.Subscriber.AppModels;
using Financial.Framework.Subscriber.Entities;
using MediatR;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Text.Json;

namespace Financial.Framework.Subscriber.Services
{
    public class SubscriberService<TCommand> where TCommand : MessageBase
    {
        private readonly QueueSettings _settings;
        private readonly IMediator _mediator;
        private IModel _channel; 

        public SubscriberService(IOptions<QueueSettings> settings, IMediator mediator)
        {
            _settings = settings.Value;
            _mediator = mediator;
        }

        public void Subscribe(string queue, string routingKey)
        {
            using var connection = GetConnectionFactory().CreateConnection();
            _channel = connection.CreateModel();

            _channel.ExchangeDeclare(_settings.Exchange, ExchangeType.Topic, true);
            _channel.QueueDeclare(queue, true, true, false);
            _channel.QueueBind(queue, _settings.Exchange, routingKey);
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += ReceivedMessage;

            _channel.BasicConsume(queue, false, consumer);

            Console.WriteLine("Consumer started");
            Console.ReadLine();
        }

        public virtual void ReceivedMessage(object sender, BasicDeliverEventArgs e)
        {
            try
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var command = JsonSerializer.Deserialize<TCommand>(message);

                Console.WriteLine($"Message with correlation id {command.CorrelationId} received.");

                PublishCommand(command);

                _channel.BasicAck(e.DeliveryTag, true);
            }
            catch(Exception ex)
            {
                //Todo: log
                Console.WriteLine($"[Subscriber.ReceivedMessage] Error in message {ex.Message}.");
            }
        }

        public virtual void PublishCommand(TCommand command)
        {
            _mediator.Publish(command);
        }

        private ConnectionFactory GetConnectionFactory()
        {
            return new ConnectionFactory
            {
                HostName = _settings.HostName,
                UserName = _settings.UserName,
                Password = _settings.Password,
                Port = _settings.Port,
                RequestedConnectionTimeout = TimeSpan.FromSeconds(_settings.Timeout)
            };
        }
    }
}