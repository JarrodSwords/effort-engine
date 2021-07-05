using SuperMarioRpg.Application.Read;

namespace SuperMarioRpg.Infrastructure.Read
{
    public class FindPlayableCharacterHandler : Handler<FindPlayableCharacter, PlayableCharacter>
    {
        #region Public Interface

        public override PlayableCharacter Execute(FindPlayableCharacter query) =>
            null; //Connection.QuerySingle<PlayableCharacterRecord>(PlayableCharacterRecord.FindEnemy, query);

        #endregion
    }
}
