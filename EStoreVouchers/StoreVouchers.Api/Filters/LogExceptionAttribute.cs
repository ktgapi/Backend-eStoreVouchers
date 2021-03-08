namespace StoreVouchers.Api.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using StoreVouchers.Infrastructure.Extensions;
    using StoreVouchers.Infrastructure.Logging;

    public class LogExceptionAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger logger;

        public LogExceptionAttribute(ILogger logger)
        {
            this.logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            var innermost = context.Exception.GetInnermostException();
            this.logger.WriteException(innermost);
            context.Result = new StatusCodeResult(500);
        }
    }
}
