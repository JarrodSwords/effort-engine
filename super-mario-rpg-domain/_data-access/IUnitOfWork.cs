namespace SuperMarioRpg.Domain
{
    public interface IUnitOfWork
    {
        #region Public Interface

        Enemy.IRepository Enemies { get; }
        NonPlayerCharacter.IRepository NonPlayerCharacters { get; }
        PlayableCharacter.IRepository PlayableCharacters { get; }

        void Commit();

        #endregion
    }
}
