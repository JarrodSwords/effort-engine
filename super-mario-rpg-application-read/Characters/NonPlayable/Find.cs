using System.Data;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read.Characters.NonPlayable
{
    public record Find(string Name) : IQuery<NonPlayableCharacter>
    {
        #region Nested Types

        internal class Handler : Handler<Find, NonPlayableCharacter>
        {
            private const string FindNonPlayerCharacter = @"
select name
  from character
 where is_playable = false
   and name = @Name";

            #region Public Interface

            public override NonPlayableCharacter MakeRequest(IDbConnection connection, Find query)
            {
                return connection.QuerySingle<NonPlayableCharacter>(FindNonPlayerCharacter, query);
            }

            #endregion
        }

        #endregion
    }
}
