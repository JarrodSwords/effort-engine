namespace SuperMarioRpg.Domain
{
    public interface IUnitOfWork
    {
        #region Public Interface

        ICharacterRepository CharacterRepository { get; }
        INonPlayerCharacterRepository NonPlayerCharacterRepository { get; }
        void Commit();

        #endregion
    }
}
