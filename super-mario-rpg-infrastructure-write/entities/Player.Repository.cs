using SuperMarioRpg.Domain.Players;

namespace SuperMarioRpg.Infrastructure.Write
{
    public partial class Player
    {
        internal class Repository : Repository<Player>, IPlayerRepository
        {
            #region Creation

            public Repository(Context context) : base(context)
            {
            }

            #endregion

            #region IPlayerRepository Implementation

            public void Create(Domain.Players.Player player)
            {
                base.Create(player);
            }

            #endregion
        }
    }
}
