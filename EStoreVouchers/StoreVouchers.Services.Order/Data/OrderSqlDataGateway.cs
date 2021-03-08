namespace StoreVouchers.Services.Order.Data
{
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Linq;
    using System.Threading.Tasks;
    using StoreVouchers.Infrastructure.Helpers;
    using StoreVouchers.Infrastructure.Logging;
    using StoreVouchers.Services.Order.Data.Entities;
    using StoreVouchers.Services.Order.Exceptions;

    //// Data access class
    public class OrderSqlDataGateway : IOrderDataGateway
    {
        private readonly ISqlHelper sql;
        private readonly ILogger logger;
        private readonly IOrderSqlCommandFactory factory;

        //// Inject necessary data access adapter like `ISqlHelper` and `ILogger`
        //// Inject command factory; Separates the creation of commands with parameters to be executed
        public OrderSqlDataGateway(
            ISqlHelper helper, 
            ILogger logger,
            IOrderSqlCommandFactory factory)
        {
            this.sql = helper;
            this.logger = logger;
            this.factory = factory;
        }

        public async Task<IEnumerable<OrderEntity>> GetOrdersBySenderEmailAsync(string senderEmail)
        {
            var result = Enumerable.Empty<OrderEntity>();

            try
            {
                var command = this.factory.CreateGetOrdersBySenderEmailCommand(senderEmail);
                result = await this.sql.ReadAsListAsync<OrderEntity>(command);
            }
            catch (DbException ex)
            {
                //// Log, Wrap and Rethrow data-related exceptions
                this.logger.WriteException(ex);
                throw new OrderDataException(ex);
            }

            return result;
        }

        public async Task InsertOrderAsync(OrderEntity order)
        {
            try
            {
                var command = this.factory.CreateInsertOrderCommand(order);
                await this.sql.ExecuteAsync(command);
            }
            catch (DbException ex)
            {
                //// Log, Wrap and Rethrow data-related exceptions
                this.logger.WriteException(ex);
                throw new OrderDataException(ex);
            }
        }
    }
}
