using System;
using Financial.Framework.Domain.Interfaces;
using Financial.Framework.Infra.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Framework.Infra.Service.DependencyInjection
{
    public static class Bootstrapper
    {
        [Obsolete("Method depreciated, in next version deleted")]
        public static void InjectMessageQueue(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IRestFulApiService, RestFulApiService>();
        }
    }
}