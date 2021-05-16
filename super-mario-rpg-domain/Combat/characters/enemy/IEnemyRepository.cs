namespace SuperMarioRpg.Domain.Combat
{
    public interface IEnemyRepository : IRepository<Enemy>
    {
        string Create(Enemy enemy);
        void Create(params Enemy[] enemy);
    }
}
