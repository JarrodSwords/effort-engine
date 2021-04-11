using System.Data;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read
{
    public record FindCharacter(string Name) : IQuery<Character>
    {
        #region Nested Types

        internal class Handler : Handler<FindCharacter, Character>
        {
            private const string FindCharacter = @"
select name
  from character
 where name = @Name
";

            #region Public Interface

            public override Character MakeRequest(IDbConnection connection, FindCharacter query)
            {
                return connection.QuerySingle<Character>(FindCharacter, query);
            }

            #endregion
        }

        #endregion
    }
}
