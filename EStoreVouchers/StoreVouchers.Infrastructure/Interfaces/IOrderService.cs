namespace StoreVouchers.Infrastructure.Interfaces
{
    using System.Threading.Tasks;
    using StoreVouchers.Infrastructure.Messages.Orders.Requests;
    using StoreVouchers.Infrastructure.Messages.Orders.Responses;

    public interface IOrderService
    {
        Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest request);

        Task<GetOrdersBySenderEmailResponse> GetOrdersBySenderEmailAsync(GetOrdersBySenderEmailRequest request);
    }
}
