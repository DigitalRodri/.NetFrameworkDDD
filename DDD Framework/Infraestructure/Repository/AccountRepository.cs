using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Repository.Models;
using System.Linq;

namespace Infraestructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public Account GetAccount(string email)
        {
            using (var db = new DDDContext())
            {
                return db.Accounts.Where(row => row.Email == email).FirstOrDefault();
            }
        }

    }
}
