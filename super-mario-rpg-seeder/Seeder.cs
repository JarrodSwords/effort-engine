using Effort.Domain.Messages;
using SuperMarioRpg.Application.Write.Characters.Enemies;
using SuperMarioRpg.Infrastructure.Write;

namespace SuperMarioRpg.Seeder
{
    public class Seeder
    {
        private readonly Context _context;
        private readonly ICommandHandler<Seed> _seedEnemiesHandler;

        private readonly ICommandHandler<Application.Write.Characters.NonPlayable.Seed>
            _seedNonPlayableCharactersHandler;

        private readonly ICommandHandler<Application.Write.Characters.Playable.Seed> _seedPlayableCharactersHandler;

        #region Creation

        public Seeder(
            Context context,
            ICommandHandler<Application.Write.Characters.NonPlayable.Seed> seedNonPlayableCharactersHandler,
            ICommandHandler<Application.Write.Characters.Playable.Seed> seedPlayableCharactersHandler,
            ICommandHandler<Seed> seedEnemiesHandler
        )
        {
            _context = context;
            _seedNonPlayableCharactersHandler = seedNonPlayableCharactersHandler;
            _seedPlayableCharactersHandler = seedPlayableCharactersHandler;
            _seedEnemiesHandler = seedEnemiesHandler;
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
            _seedNonPlayableCharactersHandler.Handle(new Application.Write.Characters.NonPlayable.Seed());
            _seedEnemiesHandler.Handle(new Seed());
            _seedPlayableCharactersHandler.Handle(new Application.Write.Characters.Playable.Seed());
            return this;
        }

        #endregion
    }
}
