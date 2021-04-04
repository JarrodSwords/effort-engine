using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain
{
    public interface IUnitOfWork
    {
        #region Public Interface

        IPlayerCharacterRepository PlayerCharacterRepository { get; }
        void Commit();

        #endregion
    }
}
