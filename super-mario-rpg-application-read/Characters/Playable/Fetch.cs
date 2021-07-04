using System.Collections.Generic;
using System.Linq;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read.Characters.Playable
{
    public record Fetch : IQuery<IEnumerable<Fetch.PlayableCharacter>>
    {
        internal class Handler : Handler<Fetch, IEnumerable<PlayableCharacter>>
        {
            #region Public Interface

            public override IEnumerable<PlayableCharacter> Execute(Fetch query) =>
                Connection
                    .Query<Record>(Record.Fetch)
                    .Select(Record.AsPlayableCharacter);

            #endregion
        }

        public record PlayableCharacter(
            string Name,
            PlayableCharacterCombatStats BaseStats
        );
    }
}
