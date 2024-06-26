using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using System;

namespace Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _autoMapper;

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _autoMapper = mapper;
        }

        public AccountDto GetAccount(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException("email");
            Account account = _accountRepository.GetAccount(email);
            return _autoMapper.Map<AccountDto>(account);
        }
    }
}
