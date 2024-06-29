﻿using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Data;

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
            ValidateUUID(UUID);

            Account account = _accountRepository.GetAccount(UUID);

            return _autoMapper.Map<AccountDto>(account);
        }

        public AccountDto CreateAccount(SimpleAccountDto simpleAccountDto)
        {
            ValidateSimpleAccountDto(simpleAccountDto);
            //HashPassword(simpleAccountDto);

            Account existingAccount = _accountRepository.FindAccountByEmail(simpleAccountDto.Email);
            if (existingAccount != null) throw new DuplicateNameException(String.Format(Resources.Resources.AccountAlreadyExists, simpleAccountDto.Email));

            Account account = _accountRepository
                .CreateAccount(simpleAccountDto.Email, simpleAccountDto.Password, simpleAccountDto.Name, simpleAccountDto.Surname, simpleAccountDto.Title);

            return _autoMapper.Map<AccountDto>(account);
        }

        public AccountDto UpdateAccount(Guid UUID, SimpleAccountDto simpleAccountDto)
        {
            ValidateUUID(UUID);
            ValidateSimpleAccountDto(simpleAccountDto);
            //HashPassword(simpleAccountDto);

            Account modifiedAccount = _accountRepository
                .UpdateAccount(UUID, simpleAccountDto.Email, simpleAccountDto.Password, simpleAccountDto.Name, simpleAccountDto.Surname, simpleAccountDto.Title);

            return _autoMapper.Map<AccountDto>(modifiedAccount);
        }

        public void DeleteAccount(Guid UUID)
        {
            ValidateUUID(UUID);

            _accountRepository.DeleteAccount(UUID);

            return;
        }

        #region Private methods

        private void ValidateUUID(Guid UUID)
        {
            if (UUID == Guid.Empty) 
                throw new ArgumentException(String.Format(Resources.Resources.NullParameter, nameof(UUID)));
        }

        private void ValidateSimpleAccountDto(SimpleAccountDto simpleAccountDto)
        {
            if (string.IsNullOrEmpty(simpleAccountDto.Email)) 
                throw new ArgumentException(String.Format(Resources.Resources.NullOrEmptyParameter, nameof(simpleAccountDto.Email)));
            if (string.IsNullOrEmpty(simpleAccountDto.Name)) 
                throw new ArgumentException(String.Format(Resources.Resources.NullOrEmptyParameter, nameof(simpleAccountDto.Name)));
            if (string.IsNullOrEmpty(simpleAccountDto.Surname)) 
                throw new ArgumentException(String.Format(Resources.Resources.NullOrEmptyParameter, nameof(simpleAccountDto.Surname)));
            if (string.IsNullOrEmpty(simpleAccountDto.Password)) 
                throw new ArgumentException(String.Format(Resources.Resources.NullOrEmptyParameter, nameof(simpleAccountDto.Password)));
            if (!string.IsNullOrEmpty(simpleAccountDto.Title) && simpleAccountDto.Title.Length > 5)
                throw new ArgumentException(String.Format(Resources.Resources.TitleLengthError, simpleAccountDto.Title));
        }
        private void HashPassword(SimpleAccountDto simpleAccountDto)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
