using System.Collections.Generic;
using System.Data;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read
{
    public record FetchCharacters : IQuery<IEnumerable<CharacterDto>>
    {
        #region Nested Types

        internal class Handler : Handler<FetchCharacters, IEnumerable<CharacterDto>>
        {
            private const string FetchCharacters = @"
SELECT id
     , name
  FROM character
";

            #region Public Interface

            public override IEnumerable<CharacterDto> MakeRequest(IDbConnection connection, FetchCharacters args)
            {
                return connection.Query<CharacterDto>(FetchCharacters, args);
            }

            #endregion
        }

        #endregion
    }
}
