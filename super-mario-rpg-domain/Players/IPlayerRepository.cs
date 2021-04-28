namespace SuperMarioRpg.Domain.Players
{
    public interface IPlayerRepository : IRepository<Player>
    {
        #region Public Interface

        void Create(Player player);

        #endregion
    }
}
