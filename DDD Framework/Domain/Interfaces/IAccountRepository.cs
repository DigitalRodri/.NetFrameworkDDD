﻿using Domain.Entities;
using System;

namespace Domain.Interfaces
{
    public interface IAccountRepository
    {
        Account GetAccount(Guid UUID);
        Account CreateAccount(string email, string password, string name, string surname, string title);
        Account UpdateAccount(Guid UUID, string email, string password, string name, string surname, string title);
        void DeleteAccount(Guid UUID);
    }
}