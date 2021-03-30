using Microsoft.EntityFrameworkCore;

namespace SuperMarioRpg.Infrastructure.Write
{
    public class Context : DbContext
    {
        #region Public Interface

        public DbSet<Character> Characters { get; set; }

        #endregion

        #region Protected Interface

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(
                "User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=SuperMarioRpg;Pooling=true;"
            );
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.RemovePluralizingTableNameConvention();
            base.OnModelCreating(builder);
        }

        #endregion
    }
}
