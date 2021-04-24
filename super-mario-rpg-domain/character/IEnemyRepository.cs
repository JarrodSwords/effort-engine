namespace SuperMarioRpg.Domain
{
    public interface IEnemyRepository : IRepository<Enemy>
    {
        #region Public Interface

        string Create(Enemy enemy);
        void Create(params Enemy[] enemy);

        #endregion
    }
}
