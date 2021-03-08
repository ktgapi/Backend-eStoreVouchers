namespace StoreVouchers.Infrastructure.Messages.Orders.Requests
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class CreateOrderRequest
    {
        [DataMember]
        public string RecipientName { get; set; }

        [DataMember]
        public string RecipientEmail { get; set; }

        [DataMember]
        public string SenderName { get; set; }

        [DataMember]
        public string SenderEmail { get; set; }

        [DataMember]
        public string Dedication { get; set; }

        [DataMember]
        public string Voucher { get; set; }

        [DataMember]
        public DateTime OrderDate { get; set; }
    }
}
