using Domain.Entities;
using System.Data.Entity;

namespace Infraestructure.Repository.Models
{
    public partial class DDDContext : DbContext
    {
        public DDDContext()
            : base("name=DDD")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
    }
}
