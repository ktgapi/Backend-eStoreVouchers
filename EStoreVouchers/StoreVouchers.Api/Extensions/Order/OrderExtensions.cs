namespace StoreVouchers.Api.Extensions.Order
{
    using System.Collections.Generic;
    using System.Linq;
    using StoreVouchers.Api.Messages;
    using StoreVouchers.Api.Messages.Orders.Requests;
    using StoreVouchers.Api.Models.Orders;
    using StoreVouchers.Infrastructure.Messages.Orders.Requests;
    using StoreVouchers.Infrastructure.Messages.Orders.Responses;
    using StoreVouchers.Infrastructure.Models.Orders;

    public static class OrderExtensions
    {
        public static CreateOrderRequest AsRequest(this AddOrderWebRequest request)
        {
            var result = new CreateOrderRequest
            {
                RecipientName = request.RecipientName,
                RecipientEmail = request.RecipientEmail,
                SenderName = request.SenderName,
                SenderEmail = request.SenderEmail,
                Dedication = request.Dedication,
                Voucher = request.Voucher,
                OrderDate = request.OrderDate
            };

            return result;
        }

        public static WebResponse AsWebResponse(this CreateOrderResponse response)
        {
            var result = new WebResponse
            {
                Message = response.Message,
                ErrorCode = response.ErrorCode,
                StatusCode = response.StatusCode
            };

            return result;
        }

        public static GetOrdersBySenderEmailRequest AsRequest(this GetOrdersBySenderEmailWebRequest request)
        {
            var result = new GetOrdersBySenderEmailRequest
            {
                SenderEmail = request.SenderEmail
            };

            return result;
        }

        public static WebResponse<IEnumerable<OrderWebModel>> AsWebResponse(this GetOrdersBySenderEmailResponse response)
        {
            var result = new WebResponse<IEnumerable<OrderWebModel>>(response.Data?.AsWebModel())
            {
                Message = response.Message,
                ErrorCode = response.ErrorCode,
                StatusCode = response.StatusCode
            };

            return result;
        }

        public static OrderWebModel AsWebModel(this Order model)
        {
            return new OrderWebModel
            {
                OrderId = model.OrderId,
                RecipientName = model.RecipientName,
                RecipientEmail = model.RecipientEmail,
                SenderName = model.SenderName,
                SenderEmail = model.SenderEmail,
                Dedication = model.Dedication,
                Voucher = model.Voucher,
                OrderDate = model.OrderDate
            };
        }

        public static IEnumerable<OrderWebModel> AsWebModel(this IEnumerable<Order> models)
        {
            return models.Select(entity => entity.AsWebModel());
        }
    }
}
