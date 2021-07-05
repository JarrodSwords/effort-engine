using System.Collections.Generic;
using System.Linq;
using Dapper;
using SuperMarioRpg.Application.Read;

namespace SuperMarioRpg.Infrastructure.Read
{
    [Cached]
    public class FetchEnemiesHandler : Handler<FetchEnemies, IEnumerable<Enemy>>
    {
        #region Public Interface

        public override IEnumerable<Enemy> Execute(FetchEnemies query) =>
            Connection
                .Query<EnemyRecord>(EnemyRecord.Fetch)
                .Select(EnemyRecord.AsEnemy);

        #endregion
    }
}
