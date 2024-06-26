using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAccountRepository
    {
        Account GetAccount(string email);
    }
}