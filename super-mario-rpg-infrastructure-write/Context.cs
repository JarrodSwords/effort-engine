using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SuperMarioRpg.Infrastructure.Write
{
    public class Context : DbContext
    {
        #region Public Interface

        public DbSet<Character> Character { get; set; }

        public bool IsLatest => Database.GetAppliedMigrations().Last() == Database.GetMigrations().Last();

        public Context ApplyMigrations()
        {
            Database.EnsureDeleted();
            Database.Migrate();

            return this;
        }

        #endregion

        #region Protected Interface

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder
                .UseNpgsql(
                    "User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=SuperMarioRpg;Pooling=true;"
                )
                .UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        #endregion
    }
}
