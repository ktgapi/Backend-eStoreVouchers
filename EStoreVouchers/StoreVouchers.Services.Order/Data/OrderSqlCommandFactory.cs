namespace StoreVouchers.Services.Order.Data
{
    using System.Data;
    using System.Data.SqlClient;
    using StoreVouchers.Services.Order.Data.Entities;

    public class OrderSqlCommandFactory : IOrderSqlCommandFactory
    {
        public SqlCommand CreateGetOrdersBySenderEmailCommand(string senderEmail)
        {
            var result = new SqlCommand("[dbo].[sp_GetOrdersBySenderEmail]")
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 60
            };

            result.Parameters.AddWithValue("@senderEmail", senderEmail);

            return result;
        }

        public SqlCommand CreateInsertOrderCommand(OrderEntity order)
        {
            var result = new SqlCommand("[dbo].[sp_InsertOrder]")
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 60
            };

            result.Parameters.AddWithValue("@recipientName", order.RecipientName);
            result.Parameters.AddWithValue("@recipientEmail", order.RecipientEmail);
            result.Parameters.AddWithValue("@senderName", order.SenderName);
            result.Parameters.AddWithValue("@senderEmail", order.SenderEmail);
            result.Parameters.AddWithValue("@dedication", order.Dedication);
            result.Parameters.AddWithValue("@voucher", order.Voucher);
            result.Parameters.AddWithValue("@orderDate", order.OrderDate);
            //// Add all fields as parameters

            return result;
        }
    }
}
