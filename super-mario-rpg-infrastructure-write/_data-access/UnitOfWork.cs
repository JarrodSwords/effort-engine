using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Infrastructure.Write
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private IPlayerCharacterRepository _playerCharacterRepository;

        #region Creation

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        #endregion

        #region IUnitOfWork Implementation

        public IPlayerCharacterRepository PlayerCharacterRepository =>
            _playerCharacterRepository ??= new PlayerCharacterRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
