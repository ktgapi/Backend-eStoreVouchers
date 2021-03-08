namespace StoreVouchers.Services.Order.Exceptions
{
    using System;

    public class OrderServiceException : Exception
    {
        public OrderServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public OrderServiceException(Exception innerException)
            : base(string.Empty, innerException)
        {
        }
    }
}
