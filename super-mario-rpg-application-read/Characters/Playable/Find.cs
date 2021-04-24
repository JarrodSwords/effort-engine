using System.Data;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read.Characters.Playable
{
    public record Find(string Name) : IQuery<PlayableCharacter>
    {
        #region Nested Types

        internal class Handler : Handler<Find, PlayableCharacter>
        {
            #region Public Interface

            public override PlayableCharacter MakeRequest(IDbConnection connection, Find query)
            {
                return connection.QuerySingle<Record>(Record.Find, query);
            }

            #endregion
        }

        #endregion
    }
}
