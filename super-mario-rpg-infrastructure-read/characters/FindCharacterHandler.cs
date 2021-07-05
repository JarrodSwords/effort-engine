using Dapper;
using SuperMarioRpg.Application.Read;

namespace SuperMarioRpg.Infrastructure.Read
{
    public class FindCharacterHandler : Handler<FindCharacter, Character>
    {
        private const string Find = @"
select name
  from character
 where name = @Name";

        #region Public Interface

        public override Character Execute(FindCharacter query) => Connection.QuerySingle<Character>(Find, query);

        #endregion
    }
}
