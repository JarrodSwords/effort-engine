using Dapper;
using SuperMarioRpg.Application.Read;

namespace SuperMarioRpg.Infrastructure.Read
{
    public class FindPlayableCharacterHandler : Handler<FindPlayableCharacter, PlayableCharacter>
    {
        #region Public Interface

        public override PlayableCharacter Execute(FindPlayableCharacter query) =>
            Connection.QuerySingle<PlayableCharacterRecord>(PlayableCharacterRecord.Find, query);

        #endregion
    }
}
