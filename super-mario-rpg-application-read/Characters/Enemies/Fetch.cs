using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read.Characters.Enemies
{
    public record Fetch : IQuery<IEnumerable<Enemy>>
    {
        #region Nested Types

        internal class Handler : Handler<Fetch, IEnumerable<Enemy>>
        {
            #region Public Interface

            public override IEnumerable<Enemy> MakeRequest(IDbConnection connection, Fetch query)
            {
                return connection
                    .Query<Record>(Record.Fetch)
                    .Select(Record.AsEnemy);
            }

            #endregion
        }

        #endregion
    }
}
