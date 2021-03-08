namespace StoreVouchers.Services.Order.Data
{
    using System.Data.SqlClient;
    using StoreVouchers.Services.Order.Data.Entities;

    public interface IOrderSqlCommandFactory
    {
        SqlCommand CreateInsertOrderCommand(OrderEntity order);

        SqlCommand CreateGetOrdersBySenderEmailCommand(string senderEmail);
    }
}
