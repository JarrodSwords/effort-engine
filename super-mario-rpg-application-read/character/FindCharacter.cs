using Dapper;
using Effort.Domain.Messages;
using Npgsql;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read
{
    public record FindCharacter(string Name) : IQuery<CharacterDto>
    {
        #region Nested Types

        internal class Handler : IQueryHandler<FindCharacter, CharacterDto>
        {
            private const string Query = @"
SELECT id
     , name
  FROM character C
 WHERE Name = @Name
";

            #region IQueryHandler<FindCharacter,CharacterDto> Implementation

            public CharacterDto Handle(FindCharacter args)
            {
                using var connection = new NpgsqlConnection(
                    "User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=SuperMarioRpg;Pooling=true;"
                );

                var character = connection.QueryFirst<CharacterDto>(Query, args);

                return character;
            }

            #endregion
        }

        #endregion
    }
}
