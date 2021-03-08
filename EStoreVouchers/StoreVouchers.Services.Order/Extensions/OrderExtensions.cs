namespace StoreVouchers.Services.Order.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using StoreVouchers.Infrastructure.Messages.Orders.Requests;
    using StoreVouchers.Infrastructure.Models.Orders;
    using StoreVouchers.Services.Order.Data.Entities;

    public static class OrderExtensions
    {
        public static OrderEntity AsEntity(this CreateOrderRequest request)
        {
            var result = new OrderEntity
            {
                RecipientName = request.RecipientName,
                RecipientEmail = request.RecipientEmail,
                SenderName = request.SenderName,
                SenderEmail = request.SenderEmail,
                Dedication = request.Dedication,
                Voucher = request.Voucher,
                OrderDate = request.OrderDate
                //// Assign all necessary fields e.g. when new fields are introduced
            };

            return result;
        }

        public static IEnumerable<Order> AsModel(this IEnumerable<OrderEntity> entities)
        {
            var result = entities.Select(entity => entity.AsModel());
            return result;
        }

        public static Order AsModel(this OrderEntity entity)
        {
            var result = new Order
            {
                OrderId = entity.OrderId,
                RecipientName = entity.RecipientName,
                RecipientEmail = entity.RecipientEmail,
                SenderName = entity.SenderName,
                SenderEmail = entity.SenderEmail,
                Dedication = entity.Dedication,
                Voucher = entity.Voucher,
                OrderDate = entity.OrderDate
                //// Assign all necessary fields e.g. when new fields are introduced
            };

            return result;
        }
    }
}
