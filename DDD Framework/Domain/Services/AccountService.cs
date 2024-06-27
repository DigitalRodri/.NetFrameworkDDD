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

        public AccountDto GetAccount(Guid UUID)
        {
            if (UUID == null) throw new ArgumentNullException("UUID");

            Account account = _accountRepository.GetAccount(UUID);

            return _autoMapper.Map<AccountDto>(account);
        }

        public AccountDto CreateAccount(SimpleAccountDto simpleAccountDto)
        {
            ValidateSimpleAccountDto(simpleAccountDto);
            //HashPassword(simpleAccountDto);

            Account account = _accountRepository
                .CreateAccount(simpleAccountDto.Email, simpleAccountDto.Password, simpleAccountDto.Name, simpleAccountDto.Surname, simpleAccountDto.Title);

            return _autoMapper.Map<AccountDto>(account);
        }

        public AccountDto UpdateAccount(Guid UUID, SimpleAccountDto simpleAccountDto)
        {
            if (UUID == null) throw new ArgumentNullException("UUID");
            ValidateSimpleAccountDto(simpleAccountDto);
            //HashPassword(simpleAccountDto);

            Account modifiedAccount = _accountRepository
                .UpdateAccount(UUID, simpleAccountDto.Email, simpleAccountDto.Password, simpleAccountDto.Name, simpleAccountDto.Surname, simpleAccountDto.Title);

            return _autoMapper.Map<AccountDto>(modifiedAccount);
        }

        public void DeleteAccount(Guid UUID)
        {
            if (UUID == null) throw new ArgumentNullException("UUID");

            _accountRepository.DeleteAccount(UUID);

            return;
        }

        #region Private methods

        private void ValidateSimpleAccountDto(SimpleAccountDto simpleAccountDto)
        {
            if (string.IsNullOrEmpty(simpleAccountDto.Email)) throw new ArgumentNullException("simpleAccountDto.Email");
            if (string.IsNullOrEmpty(simpleAccountDto.Name)) throw new ArgumentNullException("simpleAccountDto.Name");
            if (string.IsNullOrEmpty(simpleAccountDto.Surname)) throw new ArgumentNullException("simpleAccountDto.Surname");
            if (string.IsNullOrEmpty(simpleAccountDto.Password)) throw new ArgumentNullException("simpleAccountDto.Password");
            if (!string.IsNullOrEmpty(simpleAccountDto.Title) && simpleAccountDto.Title.Length > 5)
                throw new ArgumentException("simpleAccountDto.Title - Title can't be longer than 5 characters");
        }
        private void HashPassword(SimpleAccountDto simpleAccountDto)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
