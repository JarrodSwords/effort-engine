namespace SuperMarioRpg.Domain
{
    public interface IPlayerRepository : IRepository<Player>
    {
        #region Public Interface

        void Create(Player player);

        #endregion
    }
}
