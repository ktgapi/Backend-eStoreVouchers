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
    [Route("api/create_order")]
    public class CreateOrderController : ControllerBase
    {
        private readonly IOrderService service;

        //// Inject controller dependencies. Usually services
        public CreateOrderController(IOrderService service)
        {
            Debug.Assert(service != null, "Null dependencies");
            this.service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        [ServiceFilter(typeof(ValidateModelStateAttribute))]
        [ServiceFilter(typeof(LogExceptionAttribute))]
        //// Controller code should only contain two lines i.e. invocation of service
        public async Task<IActionResult> AddOrderAsync([FromBody] AddOrderWebRequest request)
        {
            //// Decouple models/request-response from Api and Service layer
            //// Create Extension `.AsRequest` to convert models.
            var result = await this.service.CreateOrderAsync(request.AsRequest());
            return this.CreateResponse(result.AsWebResponse());
        }
    }
}
