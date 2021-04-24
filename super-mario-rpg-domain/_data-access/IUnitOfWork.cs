namespace SuperMarioRpg.Domain
{
    public interface IUnitOfWork
    {
        #region Public Interface

        IEnemyRepository Enemies { get; }
        NonPlayableCharacter.IRepository NonPlayerCharacters { get; }
        PlayableCharacter.IRepository PlayableCharacters { get; }

        void Commit();

        #endregion
    }
}
