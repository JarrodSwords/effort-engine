using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read.Characters.Playable
{
    public record Find(string Name) : IQuery<PlayableCharacter>
    {
        internal class Handler : Handler<Find, PlayableCharacter>
        {
            #region Public Interface

            public override PlayableCharacter Execute(Find query) =>
                null; //Connection.QuerySingle<Record>(Record.Find, query);

            #endregion
        }
    }
}
