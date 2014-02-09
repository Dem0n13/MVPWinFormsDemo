namespace Dem0n13.MVP.DomainModel
{
    public class StupidLoginService : ILoginService
    {
        public bool Login(User user)
        {
            return !string.IsNullOrEmpty(user.Name);
        }
    }
}