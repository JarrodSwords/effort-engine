namespace SuperMarioRpg.Domain
{
    public interface IUnitOfWork
    {
        #region Public Interface

        Character.IRepository CharacterRepository { get; }
        Enemy.IRepository EnemyRepository { get; }
        NonPlayerCharacter.IRepository NonPlayerCharacterRepository { get; }

        void Commit();

        #endregion
    }
}
