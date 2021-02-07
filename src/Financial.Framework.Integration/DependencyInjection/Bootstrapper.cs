using Financial.Framework.Integration.AppModels;
using Financial.Framework.Integration.Interfaces;
using Financial.Framework.Integration.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Framework.Integration.DependencyInjection
{
    public static class Bootstrapper
    {
        public static void InjectTelegramService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppMessageSettings>(configuration);
            services.AddSingleton<IAppMessageService, TelegramMessageService>();
        }
    }
}
