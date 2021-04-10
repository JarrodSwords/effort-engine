namespace SuperMarioRpg.Domain
{
    public interface IUnitOfWork
    {
        #region Public Interface

        Enemy.IRepository EnemyRepository { get; }
        NonPlayerCharacter.IRepository NonPlayerCharacterRepository { get; }

        void Commit();

        #endregion
    }
}
