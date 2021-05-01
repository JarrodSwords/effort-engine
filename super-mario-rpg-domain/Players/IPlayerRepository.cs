namespace SuperMarioRpg.Domain.Players
{
    public interface IPlayerRepository : IRepository<Player>
    {
        void Create(Player player);
    }
}
