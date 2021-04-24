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

        private Character.Repository CharacterNonPlayableCharacterRepository =>
            _characterRepository ??= new Character.Repository(_context);

        #endregion

        #region IUnitOfWork Implementation

        public IEnemyRepository Enemies => CharacterNonPlayableCharacterRepository;
        public INonPlayableCharacterRepository NonPlayerCharacters => CharacterNonPlayableCharacterRepository;
        public PlayableCharacter.IRepository PlayableCharacters => CharacterNonPlayableCharacterRepository;

        public void Commit()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
