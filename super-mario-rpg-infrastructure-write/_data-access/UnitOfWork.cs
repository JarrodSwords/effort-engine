using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Infrastructure.Write
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private Domain.Character.IRepository _characters;
        private Enemy.IRepository _enemies;
        private NonPlayerCharacter.IRepository _nonPlayerCharacters;

        #region Creation

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        #endregion

        #region IUnitOfWork Implementation

        public Domain.Character.IRepository Characters => _characters ??= new CharacterRepository(_context);
        public Enemy.IRepository Enemies => _enemies ??= new EnemyRepository(_context);

        public NonPlayerCharacter.IRepository NonPlayerCharacters =>
            _nonPlayerCharacters ??= new NonPlayerCharacterRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
