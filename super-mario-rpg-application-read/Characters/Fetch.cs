using System.Collections.Generic;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read.Characters
{
    public record Fetch : IQuery<IEnumerable<Character>>
    {
        internal class Handler : Handler<Fetch, IEnumerable<Character>>
        {
            private const string Fetch = @"
select name
  from character
 order by name
";

            #region Public Interface

            public override IEnumerable<Character> Execute(Fetch query) => Connection.Query<Character>(Fetch, query);

            #endregion
        }
    }
}
