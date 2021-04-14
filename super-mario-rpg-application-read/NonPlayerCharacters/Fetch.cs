using System.Collections.Generic;
using System.Data;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read.NonPlayerCharacters
{
    public record Fetch : IQuery<IEnumerable<NonPlayerCharacter>>
    {
        #region Nested Types

        internal class Handler : Handler<Fetch, IEnumerable<NonPlayerCharacter>>
        {
            private const string FetchNonPlayerCharacters = @"
select name
  from character
 where is_playable = false
 order by name";

            #region Public Interface

            public override IEnumerable<NonPlayerCharacter> MakeRequest(IDbConnection connection, Fetch query)
            {
                return connection.Query<NonPlayerCharacter>(FetchNonPlayerCharacters);
            }

            #endregion
        }

        #endregion
    }
}
