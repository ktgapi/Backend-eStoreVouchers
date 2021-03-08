namespace StoreVouchers.Infrastructure.Messages.Orders.Responses
{
    using System.Collections.Generic;
    using System.Net;
    using System.Runtime.Serialization;
    using StoreVouchers.Infrastructure.Messages;

    [DataContract]
    public class CreateOrderResponse : Response
    {
        public override Dictionary<string, int> StatusCodeMap => new Dictionary<string, int>
        {
            { string.Empty, (int)HttpStatusCode.Created },
            { "customer/create-validation-error", (int)HttpStatusCode.UnprocessableEntity }
        };
    }
}
