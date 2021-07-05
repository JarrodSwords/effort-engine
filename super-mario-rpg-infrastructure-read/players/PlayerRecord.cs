using SuperMarioRpg.Application.Read;

namespace SuperMarioRpg.Infrastructure.Read
{
    internal record PlayerRecord(
        string email_address,
        string user_name
    )
    {
        #region Static Interface

        public static implicit operator Player(PlayerRecord playerRecord)
        {
            var (emailAddress, userName) = playerRecord;

            return new Player(emailAddress, userName);
        }

        #endregion
    }
}
