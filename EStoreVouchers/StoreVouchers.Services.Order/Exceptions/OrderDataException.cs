namespace StoreVouchers.Services.Order.Exceptions
{
    using System;

    public class OrderDataException : Exception
    {
        public OrderDataException(Exception innerException)
            : base(string.Empty, innerException)
        {
        }
    }
}
