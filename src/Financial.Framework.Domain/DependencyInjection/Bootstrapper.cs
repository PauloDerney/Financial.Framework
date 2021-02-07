using Financial.Framework.Domain.Interfaces;
using Financial.Framework.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Framework.Domain.DependencyInjection
{
    public static class Bootstrapper
    {
        public static void InjectDomain(this IServiceCollection services)
        {
            services.AddScoped<INotificationService, NotificationService>();
        }
    }
}
