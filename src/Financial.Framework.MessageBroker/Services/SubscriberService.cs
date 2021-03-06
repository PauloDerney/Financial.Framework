﻿using Financial.Framework.Domain.Entities;
using Financial.Framework.Domain.Interfaces;
using Financial.Framework.MessageBroker.AppModels;
using Financial.Framework.MessageBroker.Entities;
using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Financial.Framework.MessageBroker.Services
{
    public class SubscriberService : BaseService, ISubscriberService
    {
        private readonly IMediator _mediator;
        private IModel _channel;

        public SubscriberService(QueueSettings settings, IMediator mediator) : base(settings)
        {
            _mediator = mediator;
        }

        public void Subscribe<TCommand, TResponse>(string queue, string routingKey) where TCommand : Command<TResponse>
        {
            using var connection = GetConnectionFactory().CreateConnection();
            _channel = connection.CreateModel();

            _channel.ExchangeDeclare(QueueSettings.Exchange, ExchangeType.Topic, true);
            _channel.QueueDeclare(queue, true, false, false);
            _channel.QueueBind(queue, QueueSettings.Exchange, routingKey);
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += ReceivedMessage<TCommand, TResponse>;

            _channel.BasicConsume(queue, false, consumer);

            Console.WriteLine($"{queue} binding in {routingKey} - started");
            Console.ReadLine();
        }

        private void ReceivedMessage<TCommand, TResponse>(object sender, BasicDeliverEventArgs e) where TCommand : Command<TResponse>
        {
            try
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                var messageObj = JsonConvert.DeserializeObject<Message<TCommand>>(message);

                Console.WriteLine($"[Subscriber.ReceivedMessage] received message: {message}");

                PublishCommand(messageObj.Payload);

                _channel.BasicAck(e.DeliveryTag, true);
            }
            catch (Exception ex)
            {
                _channel.BasicNack(e.DeliveryTag, true, true);
                Console.WriteLine($"[Subscriber.ReceivedMessage] Error in message {ex.Message}.");
            }
        }

        private void PublishCommand<TCommand>(TCommand command)
        {
            _mediator.Send(command);
        }
    }
}