using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Infrastructure.Write
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private Character.Repository _characterRepository;

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

        public Enemy.IRepository Enemies => CharacterRepository;
        public NonPlayableCharacter.IRepository NonPlayerCharacters => CharacterRepository;
        public PlayableCharacter.IRepository PlayableCharacters => CharacterRepository;

        public void Commit()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
