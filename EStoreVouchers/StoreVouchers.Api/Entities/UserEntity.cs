namespace StoreVouchers.Api.Entities
{
    public class UserEntity : SaaSVP.Authentication.Entities.User
    {
        public UserEntity(string email, string firstName, string lastName) : base(email, firstName, lastName)
        {
        }
    }
}
