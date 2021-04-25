using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read.Players
{
    internal record Record(
        string email_address,
        string user_name
    )
    {
        #region Static Interface

        public static implicit operator Player(Record record)
        {
            var (emailAddress, userName) = record;

            return new Player(emailAddress, userName);
        }

        #endregion
    }
}
