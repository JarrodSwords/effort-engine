using System.Data;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read.Players
{
    public record Find(string UserName) : IQuery<Player>
    {
        internal class Handler : Handler<Find, Player>
        {
            private const string Find = @"
select email_address
     , user_name
  from player
 where user_name = @UserName";

            #region Public Interface

            public override Player MakeRequest(IDbConnection connection, Find query)
            {
                return connection.QuerySingle<Record>(Find, query);
            }

            #endregion
        }
    }
}
