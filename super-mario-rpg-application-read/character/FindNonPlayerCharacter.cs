using System.Data;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read
{
    public record FindNonPlayerCharacter(string Name) : IQuery<NonPlayerCharacter>
    {
        #region Nested Types

        internal class Handler : Handler<FindNonPlayerCharacter, NonPlayerCharacter>
        {
            private const string FindNonPlayerCharacter = @"
select name
  from character
 where name = @Name
   and is_non_player_character = true
";

            #region Public Interface

            public override NonPlayerCharacter MakeRequest(IDbConnection connection, FindNonPlayerCharacter query)
            {
                return connection.QuerySingle<NonPlayerCharacter>(FindNonPlayerCharacter, query);
            }

            #endregion
        }

        #endregion
    }
}
