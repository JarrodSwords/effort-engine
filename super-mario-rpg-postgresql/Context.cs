using Microsoft.EntityFrameworkCore;

namespace SuperMarioRpg.Postgresql
{
    public class Context : DbContext
    {
        private readonly string _connectionString;

        #region Creation

        public Context(string connectionString)
        {
            _connectionString = connectionString;
        }

        #endregion

        #region Public Interface

        public DbSet<Character> Characters { get; set; }

        #endregion

        #region Protected Interface

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(_connectionString);
        }

        #endregion
    }
}
