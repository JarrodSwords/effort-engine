using System.Data;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read
{
    public record FindCharacter(string Name) : IQuery<CharacterDto>
    {
        #region Nested Types

        internal class Handler : Handler<FindCharacter, CharacterDto>
        {
            private const string FindCharacter = @"
SELECT id
     , name
  FROM character C
 WHERE Name = @Name
";

            #region Public Interface

            public override CharacterDto MakeRequest(IDbConnection connection, FindCharacter args)
            {
                return connection.QueryFirst<CharacterDto>(FindCharacter, args);
            }

            #endregion
        }

        #endregion
    }
}
