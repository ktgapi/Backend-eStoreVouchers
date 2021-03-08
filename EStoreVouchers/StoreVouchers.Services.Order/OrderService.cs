namespace StoreVouchers.Services.Order
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using StoreVouchers.Infrastructure.Interfaces;
    using StoreVouchers.Infrastructure.Logging;
    using StoreVouchers.Infrastructure.Messages.Orders.Requests;
    using StoreVouchers.Infrastructure.Messages.Orders.Responses;
    using StoreVouchers.Services.Order.Constants;
    using StoreVouchers.Services.Order.Data;
    using StoreVouchers.Services.Order.Exceptions;
    using StoreVouchers.Services.Order.Extensions;
    using StoreVouchers.Services.Order.Specifications;

    //// Service typically executes the operations needed e.g. CRUD.
    public class OrderService : IOrderService
    {
        private readonly IOrderDataGateway dataGateway;
        private readonly ILogger logger;

        //// Inject dependencies. Usually data access dependencies i.e. Data Gateways
        public OrderService(
            IOrderDataGateway dataGateway,
            ILogger logger)
        {
            this.dataGateway = dataGateway;
            this.logger = logger;
        }

        public async Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest request)
        {
            var result = new CreateOrderResponse();
            ICollection<string> errors = new Collection<string>();

            try
            {
                //// Validate using Specification classes. You can leverage factories to inject
                //// your specifications if it touches the database
                var spec = new ValidCreateOrderRequestSpecification();
                if (spec.IsSatisfiedBy(request, ref errors))
                {
                    //// Decouple Service Models from Shared models i.e. Create `AsEntity` extension to convert vice-versa
                    await this.dataGateway.InsertOrderAsync(request.AsEntity());
                }
                else
                {
                    //// Communicate Specification-added errors, and return appropriate error.
                    result.SetError(Errors.CreateValidationError, errors);
                }
            }
            catch (Exception ex)
            {
                //// Log and Wrap exception then rethrow
                this.logger.WriteException(ex);
                throw new OrderServiceException(ex);
            }

            return result;
        }

        public async Task<GetOrdersBySenderEmailResponse> GetOrdersBySenderEmailAsync(GetOrdersBySenderEmailRequest request)
        {
            var result = new GetOrdersBySenderEmailResponse();
            try
            {
                //// Convert Entity (Service) model to Shared (Infra) model using `AsModel` extension
                result.Data = (await this.dataGateway.GetOrdersBySenderEmailAsync(request.SenderEmail)).AsModel();
            }
            catch (Exception ex)
            {
                //// Wrap exception and rethrow
                this.logger.WriteException(ex);
                throw new OrderServiceException(ex);
            }

            return result;
        }
    }
}
