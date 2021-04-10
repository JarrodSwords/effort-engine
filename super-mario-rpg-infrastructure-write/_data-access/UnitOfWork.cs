using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Infrastructure.Write
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private Enemy.IRepository _enemyRepository;
        private NonPlayerCharacter.IRepository _nonPlayerCharacterRepository;

        #region Creation

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        #endregion

        #region IUnitOfWork Implementation

        public Enemy.IRepository EnemyRepository => _enemyRepository ??= new EnemyRepository(_context);

        public NonPlayerCharacter.IRepository NonPlayerCharacterRepository =>
            _nonPlayerCharacterRepository ??= new NonPlayerCharacterRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
