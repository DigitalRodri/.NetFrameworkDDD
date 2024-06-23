using System.Linq;

namespace Application.Repository
{
    public class AccountRepository
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
