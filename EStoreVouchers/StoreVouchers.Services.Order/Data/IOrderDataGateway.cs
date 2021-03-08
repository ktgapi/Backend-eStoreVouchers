namespace StoreVouchers.Services.Order.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using StoreVouchers.Services.Order.Data.Entities;

    public interface IOrderDataGateway
    {
        Task InsertOrderAsync(OrderEntity order);

        Task<IEnumerable<OrderEntity>> GetOrdersBySenderEmailAsync(string senderEmail);
    }
}
