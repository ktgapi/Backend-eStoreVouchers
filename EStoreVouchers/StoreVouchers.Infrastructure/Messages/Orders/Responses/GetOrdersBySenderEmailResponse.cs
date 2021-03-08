namespace StoreVouchers.Infrastructure.Messages.Orders.Responses
{
    using System.Collections.Generic;
    using System.Net;
    using System.Runtime.Serialization;
    using StoreVouchers.Infrastructure.Messages;
    using StoreVouchers.Infrastructure.Models.Orders;

    public class GetOrdersBySenderEmailResponse : Response
    {
        [DataMember]
        public IEnumerable<Order> Data { get; set; }
    }
}
