using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Characters;
using SuperMarioRpg.Domain.Players;

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

        private Character.Repository CharacterRepository => _characterRepository ??= new Character.Repository(_context);

        #endregion

        #region IUnitOfWork Implementation

        public IEnemyRepository EnemyRepository => CharacterRepository;
        public INonPlayableCharacterRepository NonPlayerCharacterRepository => CharacterRepository;
        public IPlayableCharacterRepository PlayableCharacterRepository => CharacterRepository;
        public IPlayerRepository PlayerRepository => _playerRepository ?? new Player.Repository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
