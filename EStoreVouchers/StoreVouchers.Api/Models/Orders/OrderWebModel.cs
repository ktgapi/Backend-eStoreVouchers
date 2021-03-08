namespace StoreVouchers.Api.Models.Orders
{
    using System;
    using Newtonsoft.Json;

    public class OrderWebModel
    {
        [JsonProperty("orderId")]
        public int OrderId { get; set; }

        [JsonProperty("recipientName")]
        public string RecipientName { get; set; }

        [JsonProperty("recipientEmail")]
        public string RecipientEmail { get; set; }

        [JsonProperty("senderName")]
        public string SenderName { get; set; }

        [JsonProperty("senderEmail")]
        public string SenderEmail { get; set; }

        [JsonProperty("dedication")]
        public string Dedication { get; set; }

        [JsonProperty("voucher")]
        public string Voucher { get; set; }

        [JsonProperty("orderDate")]
        public DateTime OrderDate { get; set; }
    }
}
