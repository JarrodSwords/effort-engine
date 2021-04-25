namespace SuperMarioRpg.Infrastructure.Write
{
    public partial class Player : Entity
    {
        #region Creation

        public Player(string emailAddress, string password, string userName)
        {
            EmailAddress = emailAddress;
            Password = password;
            UserName = userName;
        }

        #endregion

        #region Public Interface

        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        #endregion

        #region Static Interface

        public static implicit operator Player(Domain.Configuration.Player player)
        {
            return new(player.EmailAddress, player.Password, player.UserName);
        }

        #endregion
    }
}
