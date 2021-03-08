namespace StoreVouchers.Api.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using StoreVouchers.Api.Extensions;
    using StoreVouchers.Api.Extensions.Order;
    using StoreVouchers.Api.Filters;
    using StoreVouchers.Api.Messages.Orders.Requests;
    using StoreVouchers.Infrastructure.Interfaces;

    //// Use the Page Controllers or Experience Controllers convention wherein
    //// we create controllers per "pages/experience" and not in a RESTful manner
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService service;

        //// Inject controller dependencies. Usually services
        public OrdersController(IOrderService service)
        {
            Debug.Assert(service != null, "Null dependencies");
            this.service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        [ServiceFilter(typeof(ValidateModelStateAttribute))]
        [ServiceFilter(typeof(LogExceptionAttribute))]
        //// Controller code should only contain two lines i.e. invocation of service
        public async Task<IActionResult> GetOrdersBySenderEmailAsync([FromBody] GetOrdersBySenderEmailWebRequest request)
        {
            var result = await this.service.GetOrdersBySenderEmailAsync(request.AsRequest());
            return this.CreateResponse(result.AsWebResponse());
        }
    }
}
