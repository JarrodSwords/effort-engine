using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read
{
    public record FetchPlayableCharacters : IQuery<IEnumerable<PlayableCharacter>>
    {
        #region Nested Types

        internal class Handler : Handler<FetchPlayableCharacters, IEnumerable<PlayableCharacter>>
        {
            #region Public Interface

            public override IEnumerable<PlayableCharacter> MakeRequest(
                IDbConnection connection,
                FetchPlayableCharacters query
            )
            {
                return connection
                    .Query<PlayableCharacterRecord>(PlayableCharacterRecord.Fetch)
                    .Select(PlayableCharacterRecord.AsPlayableCharacter);
            }

            #endregion
        }

        #endregion
    }
}
