using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Infrastructure.Write
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private ICharacterRepository _characterRepository;
        private Domain.Enemy.IRepository _enemyRepository;
        private INonPlayerCharacterRepository _nonPlayerCharacterRepository;

        #region Creation

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        #endregion

        #region IUnitOfWork Implementation

        public ICharacterRepository CharacterRepository => _characterRepository ??= new CharacterRepository(_context);
        public Domain.Enemy.IRepository EnemyRepository => _enemyRepository ??= new EnemyRepository(_context);

        public INonPlayerCharacterRepository NonPlayerCharacterRepository =>
            _nonPlayerCharacterRepository ??= new NonPlayerCharacterRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
