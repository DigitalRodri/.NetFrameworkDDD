using System.Data.Entity;

namespace Application
{
    public partial class DDDContext : DbContext
    {
        public DDDContext()
            : base("name=DDD")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Title)
                .IsUnicode(false);
        }
    }
}
