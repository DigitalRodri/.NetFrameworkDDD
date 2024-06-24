using Application.Repository;
using System;

namespace Application.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account GetAccount(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException("email");
            return _accountRepository.GetAccount(email);
        }
    }
}
