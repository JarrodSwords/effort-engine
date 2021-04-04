namespace SuperMarioRpg.Domain
{
    public interface IUnitOfWork
    {
        #region Public Interface

        ICharacterRepository CharacterRepository { get; }
        void Commit();

        #endregion
    }
}
