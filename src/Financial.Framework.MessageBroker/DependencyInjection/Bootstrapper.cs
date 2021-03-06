﻿using Financial.Framework.Domain.Interfaces;
using Financial.Framework.MessageBroker.AppModels;
using Financial.Framework.MessageBroker.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Financial.Framework.MessageBroker.DependencyInjection
{
    public static class Bootstrapper
    {
        public static void InjectSubscriber(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(provider => configuration.GetSection("QueueSettings").Get<QueueSettings>());
            services.AddSingleton<ISubscriberService, SubscriberService>();
        }

        public static void InjectPublisher(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(provider => configuration.GetSection("QueueSettings").Get<QueueSettings>());
            services.AddScoped<IPublisherService, PublisherService>();
        }

        public static IHostBuilder AddAppSettings(this IHostBuilder host)
        {
            host
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", false);
                });

            return host;
        }
    }
}