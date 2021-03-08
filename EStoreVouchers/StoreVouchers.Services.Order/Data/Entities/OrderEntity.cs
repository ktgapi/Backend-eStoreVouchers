namespace StoreVouchers.Services.Order.Data.Entities
{
    using System;

    public class OrderEntity
    {
        public int OrderId { get; set; }

        public string RecipientName { get; set; }

        public string RecipientEmail { get; set; }

        public string SenderName { get; set; }

        public string SenderEmail { get; set; }

        public string Dedication { get; set; }

        public string Voucher { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
