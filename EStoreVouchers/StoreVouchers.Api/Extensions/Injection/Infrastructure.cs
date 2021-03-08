namespace StoreVouchers.Api.Extensions.Injection
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using StoreVouchers.Infrastructure.Helpers;
    using StoreVouchers.Infrastructure.Logging;

    public static class Infrastructure
    {
        public static void InjectInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(typeof(ILogger), instance => new InsightsLogger(configuration.GetSection("ApplicationInsights")["InstrumentationKey"]));
            services.AddSingleton(typeof(ISqlHelper), instance => new SqlHelper(configuration.GetSection("Database")["ConnectionString"]));
        }
    }
}
