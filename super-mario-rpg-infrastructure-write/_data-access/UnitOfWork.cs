using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Infrastructure.Write
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private Domain.Character.IRepository _characterRepository;
        private Enemy.IRepository _enemyRepository;
        private NonPlayerCharacter.IRepository _nonPlayerCharacterRepository;

        #region Creation

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        #endregion

        #region IUnitOfWork Implementation

        public Domain.Character.IRepository CharacterRepository =>
            _characterRepository ??= new CharacterRepository(_context);

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
