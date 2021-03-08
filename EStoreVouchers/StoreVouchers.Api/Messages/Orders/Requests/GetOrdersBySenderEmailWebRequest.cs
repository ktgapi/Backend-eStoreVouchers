namespace StoreVouchers.Api.Messages.Orders.Requests
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class GetOrdersBySenderEmailWebRequest : WebRequest
    {
        [JsonProperty("senderEmail")]
        [Required]
        public string SenderEmail { get; set; }
    }
}
