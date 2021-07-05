using System.Collections.Generic;
using Dapper;
using SuperMarioRpg.Application.Read;

namespace SuperMarioRpg.Infrastructure.Read
{
    public class FetchCharactersHandler : Handler<FetchCharacters, IEnumerable<Character>>
    {
        private const string Fetch = @"
select name
  from character
 order by name";

        #region Public Interface

        public override IEnumerable<Character> Execute(FetchCharacters query) =>
            Connection.Query<Character>(Fetch, query);

        #endregion
    }
}
