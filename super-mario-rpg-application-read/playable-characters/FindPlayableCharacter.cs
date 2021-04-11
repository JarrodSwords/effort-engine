using System.Data;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read
{
    public record FindPlayableCharacter(string Name) : IQuery<PlayableCharacter>
    {
        #region Nested Types

        internal class Handler : Handler<FindPlayableCharacter, PlayableCharacter>
        {
            #region Public Interface

            public override PlayableCharacter MakeRequest(IDbConnection connection, FindPlayableCharacter query)
            {
                return PlayableCharacterRecord.AsPlayableCharacter(
                    connection.QuerySingle<PlayableCharacterRecord>(PlayableCharacterRecord.Find, query)
                );
            }

            #endregion
        }

        #endregion
    }
}
