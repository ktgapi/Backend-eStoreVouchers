namespace StoreVouchers.Infrastructure.Messages.Orders.Requests
{
    using System.Runtime.Serialization;

    [DataContract]
    public class GetOrdersBySenderEmailRequest
    {
        [DataMember]
        public string SenderEmail { get; set; }
    }
}
