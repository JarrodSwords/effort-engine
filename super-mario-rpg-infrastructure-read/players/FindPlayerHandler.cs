using Dapper;
using SuperMarioRpg.Application.Read;

namespace SuperMarioRpg.Infrastructure.Read
{
    public class FindPlayerHandler : Handler<FindPlayer, Player>
    {
        private const string Find = @"
select email_address
     , user_name
  from player
 where user_name = @UserName";

        #region Public Interface

        public override Player Execute(FindPlayer query) => Connection.QuerySingle<PlayerRecord>(Find, query);

        #endregion
    }
}
