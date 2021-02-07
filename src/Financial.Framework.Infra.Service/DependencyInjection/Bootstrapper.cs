using Financial.Framework.Domain.Interfaces;
using Financial.Framework.Infra.Service.AppModels;
using Financial.Framework.Infra.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Framework.Infra.Service.DependencyInjection
{
    public static class Bootstrapper
    {
        public static void InjectMessageQueue(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<QueueSettings>(configuration.GetSection("QueueSettings"));
            services.AddSingleton<IRestFulApiService, RestFulApiService>();
            services.AddScoped<IMessageQueueService, MessageQueueService>();
        }
    }
}