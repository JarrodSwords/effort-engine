namespace SuperMarioRpg.Domain.Characters
{
    public interface IEnemyRepository : IRepository<Enemy>
    {
        string Create(Enemy enemy);
        void Create(params Enemy[] enemy);
    }
}
