using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Configuration;

namespace SuperMarioRpg.Infrastructure.Write
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private Character.Repository _characterRepository;
        private Player.Repository _playerRepository;

        #region Creation

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        #endregion

        #region Private Interface

        private Character.Repository CharacterNonRepository =>
            _characterRepository ??= new Character.Repository(_context);

        #endregion

        #region IUnitOfWork Implementation

        public IEnemyRepository Enemies => CharacterNonRepository;
        public INonPlayableCharacterRepository NonPlayerCharacters => CharacterNonRepository;
        public IPlayableCharacterRepository PlayableCharacters => CharacterNonRepository;
        public IPlayerRepository Players => _playerRepository ?? new Player.Repository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
