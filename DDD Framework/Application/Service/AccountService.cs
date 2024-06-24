using Application.Repository;
using System;

namespace Application.Service
{
    public class AccountService
    {
        public Account GetAccount(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException("email");
            AccountRepository accountRepository = new AccountRepository();
            return accountRepository.GetAccount(email);
        }
    }
}
