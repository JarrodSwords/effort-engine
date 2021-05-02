using Effort.Domain.Messages;
using SuperMarioRpg.Application.Write.Administration;
using SuperMarioRpg.Infrastructure.Write;

namespace SuperMarioRpg.Seeder
{
    public class Seeder
    {
        private readonly Context _context;
        private readonly ICommandHandler<SeedEnemies> _seedEnemiesHandler;

        private readonly ICommandHandler<SeedNonPlayableCharacters>
            _seedNonPlayableCharactersHandler;

        private readonly ICommandHandler<SeedPlayableCharacters> _seedPlayableCharactersHandler;

        #region Creation

        public Seeder(
            Context context,
            ICommandHandler<SeedEnemies> seedEnemiesHandler,
            ICommandHandler<SeedNonPlayableCharacters> seedNonPlayableCharactersHandler,
            ICommandHandler<SeedPlayableCharacters> seedPlayableCharactersHandler
        )
        {
            _context = context;
            _seedEnemiesHandler = seedEnemiesHandler;
            _seedNonPlayableCharactersHandler = seedNonPlayableCharactersHandler;
            _seedPlayableCharactersHandler = seedPlayableCharactersHandler;
        }

        #endregion

        #region Public Interface

        public Seeder ConfigureDevDatabase()
        {
            _context.ApplyMigrations();
            return this;
        }

        public Seeder Seed()
        {
            _seedNonPlayableCharactersHandler.Handle(new SeedNonPlayableCharacters());
            _seedEnemiesHandler.Handle(new SeedEnemies());
            _seedPlayableCharactersHandler.Handle(new SeedPlayableCharacters());
            return this;
        }

        #endregion
    }
}
