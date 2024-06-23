using Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
