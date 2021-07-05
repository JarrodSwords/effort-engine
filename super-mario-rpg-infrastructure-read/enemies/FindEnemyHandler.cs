using Dapper;
using SuperMarioRpg.Application.Read;

namespace SuperMarioRpg.Infrastructure.Read
{
    public class FindEnemyHandler : Handler<FindEnemy, Enemy>
    {
        #region Public Interface

        public override Enemy Execute(FindEnemy query) => Connection.QuerySingle<EnemyRecord>(EnemyRecord.Find, query);

        #endregion
    }
}
