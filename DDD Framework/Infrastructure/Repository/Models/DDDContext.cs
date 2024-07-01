using Domain.Entities;
using System.Data.Entity;

namespace Infrastructure.Repository.Models
{
    public partial class DDDContext : DbContext
    {
        public DDDContext()
            : base("name=DDDConnectionString")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
    }
}
