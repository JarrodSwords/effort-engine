namespace SuperMarioRpg.Domain
{
    public interface IUnitOfWork
    {
        #region Public Interface

        Character.IRepository Characters { get; }
        Enemy.IRepository Enemies { get; }
        NonPlayerCharacter.IRepository NonPlayerCharacters { get; }

        void Commit();

        #endregion
    }
}
