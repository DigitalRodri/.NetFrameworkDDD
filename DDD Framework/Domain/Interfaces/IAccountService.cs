using Domain.DTOs;

namespace Domain.Interfaces
{
    public interface IAccountService
    {
        AccountDto GetAccount(string email);
    }
}