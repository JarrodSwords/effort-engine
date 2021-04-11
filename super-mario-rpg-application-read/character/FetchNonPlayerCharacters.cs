using System.Collections.Generic;
using System.Data;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read
{
    public record FetchNonPlayerCharacters : IQuery<IEnumerable<NonPlayerCharacter>>
    {
        #region Nested Types

        internal class Handler : Handler<FetchNonPlayerCharacters, IEnumerable<NonPlayerCharacter>>
        {
            private const string FetchNonPlayerCharacters = @"
select name
  from character
 where is_non_player_character = true
 order by name
";

            #region Public Interface

            public override IEnumerable<NonPlayerCharacter> MakeRequest(
                IDbConnection connection,
                FetchNonPlayerCharacters query
            )
            {
                return connection.Query<NonPlayerCharacter>(FetchNonPlayerCharacters);
            }

            #endregion
        }

        #endregion
    }
}
