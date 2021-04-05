using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Infrastructure.Write
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private ICharacterRepository _characterRepository;
        private INonPlayerCharacterRepository _nonPlayerCharacterRepository;

        #region Creation

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        #endregion

        #region IUnitOfWork Implementation

        public ICharacterRepository CharacterRepository => _characterRepository ??= new CharacterRepository(_context);

        public INonPlayerCharacterRepository NonPlayerCharacterRepository =>
            _nonPlayerCharacterRepository ??= new NonPlayerCharacterRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
