using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read
{
    public record FetchEnemies : IQuery<IEnumerable<Enemy>>
    {
        #region Nested Types

        internal class Handler : Handler<FetchEnemies, IEnumerable<Enemy>>
        {
            #region Public Interface

            public override IEnumerable<Enemy> MakeRequest(IDbConnection connection, FetchEnemies query)
            {
                return connection
                    .Query<EnemyRecord>(EnemyRecord.Fetch)
                    .Select(EnemyRecord.AsEnemy);
            }

            #endregion
        }

        #endregion
    }
}
