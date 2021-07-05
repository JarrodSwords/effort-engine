using Dapper;
using SuperMarioRpg.Application.Read;

namespace SuperMarioRpg.Infrastructure.Read
{
    public class FindNonPlayableCharacterHandler : Handler<FindNonPlayableCharacter, NonPlayableCharacter>
    {
        private const string Find = @"
select name
  from character
 where is_playable = false
   and name = @Name";

        #region Public Interface

        public override NonPlayableCharacter Execute(FindNonPlayableCharacter query) =>
            Connection.QuerySingle<NonPlayableCharacter>(Find, query);

        #endregion
    }
}
