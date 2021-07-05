using System.Collections.Generic;
using SuperMarioRpg.Application.Read;

namespace SuperMarioRpg.Infrastructure.Read
{
    public class FetchPlayableCharactersHandler : Handler<FetchPlayableCharacters, IEnumerable<PlayableCharacter>>
    {
        #region Public Interface

        public override IEnumerable<PlayableCharacter> Execute(FetchPlayableCharacters query) => null;

        #endregion

        //Connection
        //    .Query<PlayableCharacterRecord>(PlayableCharacterRecord.Fetch)
        //    .Select(PlayableCharacterRecord.AsPlayableCharacter);
    }
}
