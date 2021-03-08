namespace StoreVouchers.Services.Order.Specifications
{
    using System.Collections.Generic;
    using StoreVouchers.Infrastructure.Messages.Orders.Requests;
    using StoreVouchers.Infrastructure.Specifications;

    public class ValidCreateOrderRequestSpecification : Specification<CreateOrderRequest>
    {
        public override bool IsSatisfiedBy(CreateOrderRequest entity, ref ICollection<string> errors)
        {
            if (string.IsNullOrEmpty(entity.RecipientName) ||
                string.IsNullOrEmpty(entity.RecipientEmail) ||
                string.IsNullOrEmpty(entity.SenderName) ||
                string.IsNullOrEmpty(entity.SenderEmail) ||
                string.IsNullOrEmpty(entity.Voucher))
            {
                errors.Add("All fields are required except Dedication");
            }

            var result = errors.Count == 0;
            return result;
        }
    }
}
