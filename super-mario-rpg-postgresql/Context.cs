using Microsoft.EntityFrameworkCore;

namespace SuperMarioRpg.Postgresql
{
    public class Context : DbContext
    {
        #region Public Interface

        public DbSet<Character> Characters { get; set; }

        #endregion

        #region Protected Interface

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql();
        }

        #endregion
    }
}
