namespace StoreVouchers.Api.Messages.Orders.Requests
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class AddOrderWebRequest : WebRequest
    {
        [JsonProperty("recipientName")]
        [Required]
        public string RecipientName { get; set; }

        [JsonProperty("recipientEmail")]
        [Required]
        public string RecipientEmail { get; set; }

        [JsonProperty("senderName")]
        [Required]
        public string SenderName { get; set; }

        [JsonProperty("senderEmail")]
        [Required]
        public string SenderEmail { get; set; }

        [JsonProperty("dedication")]
        public string Dedication { get; set; }

        [JsonProperty("voucher")]
        public string Voucher { get; set; }

        [JsonProperty("orderDate")]
        public DateTime OrderDate { get; set; }
    }
}
