namespace SuperMarioRpg.Domain
{
    public interface IUnitOfWork
    {
        #region Public Interface

        ICharacterRepository CharacterRepository { get; }
        Enemy.IRepository EnemyRepository { get; }
        INonPlayerCharacterRepository NonPlayerCharacterRepository { get; }

        void Commit();

        #endregion
    }
}
