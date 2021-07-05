using System.Collections.Generic;
using Dapper;
using SuperMarioRpg.Application.Read;

namespace SuperMarioRpg.Infrastructure.Read
{
    public class FetchNonPlayableCharactersHandler : Handler<FetchNonPlayableCharacters,
        IEnumerable<NonPlayableCharacter>>
    {
        private const string Fetch = @"
select name
  from character
 where is_playable = false
 order by name";

        #region Public Interface

        public override IEnumerable<NonPlayableCharacter> Execute(FetchNonPlayableCharacters query) =>
            Connection.Query<NonPlayableCharacter>(Fetch);

        #endregion
    }
}
