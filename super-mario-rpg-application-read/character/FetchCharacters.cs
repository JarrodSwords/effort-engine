using System.Collections.Generic;
using System.Data;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read
{
    public record FetchCharacters : IQuery<IEnumerable<Character>>
    {
        #region Nested Types

        internal class Handler : Handler<FetchCharacters, IEnumerable<Character>>
        {
            private const string FetchCharacters = @"
select name
  from character
 order by name
";

            #region Public Interface

            public override IEnumerable<Character> MakeRequest(IDbConnection connection, FetchCharacters query)
            {
                return connection.Query<Character>(FetchCharacters, query);
            }

            #endregion
        }

        #endregion
    }
}
