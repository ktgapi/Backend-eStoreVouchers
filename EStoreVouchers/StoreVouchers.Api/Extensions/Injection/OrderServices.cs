namespace StoreVouchers.Api.Extensions.Injection
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using StoreVouchers.Infrastructure.Interfaces;
    using StoreVouchers.Services.Order;
    using StoreVouchers.Services.Order.Data;

    public static class OrderServices
    {
        public static void InjectOrderService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IOrderSqlCommandFactory, OrderSqlCommandFactory>();
            services.AddSingleton<IOrderDataGateway, OrderSqlDataGateway>();
        }
    }
}
