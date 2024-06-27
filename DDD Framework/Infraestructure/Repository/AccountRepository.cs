﻿using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Repository.Models;
using System;

namespace Infraestructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public Account GetAccount(Guid UUID)
        {
            using (var db = new DDDContext())
            {
                return db.Accounts.Find(UUID);
            }
        }

        public Account CreateAccount(string email, string password, string name, string surname, string title)
        {
            Account newAccount = new Account(email, password, name, surname, title);

            using (var db = new DDDContext())
            {
                Account result = db.Accounts.Add(newAccount);
                db.SaveChanges();
                return result;
            }
        }

        public Account UpdateAccount(Guid UUID, string email, string password, string name, string surname, string title)
        {
            using (var db = new DDDContext())
            {
                Account modifiedAccount = db.Accounts.Find(UUID);

                modifiedAccount.Email = email;
                modifiedAccount.Password = password;
                modifiedAccount.Name = name;
                modifiedAccount.Surname = surname;
                modifiedAccount.Title = title;

                db.SaveChanges();
                return modifiedAccount;
            }
        }

        public void DeleteAccount(Guid UUID)
        {
            using (var db = new DDDContext())
            {
                Account deletedAccount = db.Accounts.Find(UUID);
                db.Accounts.Remove(deletedAccount);
                db.SaveChanges();
            }
        }
    }
}