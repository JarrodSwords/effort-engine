using Effort.Domain;

namespace SuperMarioRpg.Domain
{
    public class Player : AggregateRoot
    {
        #region Creation

        public Player(string emailAddress, string password, string userName) : base(null)
        {
            EmailAddress = emailAddress;
            Password = password;
            UserName = userName;
        }

        #endregion

        #region Public Interface

        public string EmailAddress { get; }
        public string Password { get; }
        public string UserName { get; }

        #endregion
    }

    public interface IPlayerRepository : IRepository<Player>
    {
        #region Public Interface

        void Create(Player player);

        #endregion
    }
}
