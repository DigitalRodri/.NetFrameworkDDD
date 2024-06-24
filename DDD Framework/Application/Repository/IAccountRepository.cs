namespace Application.Repository
{
    public interface IAccountRepository
    {
        Account GetAccount(string email);
    }
}