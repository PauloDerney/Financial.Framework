using Financial.Framework.Infra.Data.AppModels;
using Financial.Framework.Infra.Data.Interfaces;
using Financial.Framework.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Framework.Infra.Data.DependencyInjection
{
    public static class Bootstrapper
    {
        public static void InjectBaseRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(options => configuration.GetSection("DatabaseSettings").Bind(options));
            services.AddSingleton(typeof(IBaseRepository<>), typeof(MongoDbBaseRepository<>));
        }
    }
}