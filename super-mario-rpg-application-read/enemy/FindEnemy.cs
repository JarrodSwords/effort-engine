using System.Data;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read
{
    public record FindEnemy(string Name) : IQuery<Enemy>
    {
        #region Nested Types

        internal class Handler : Handler<FindEnemy, Enemy>
        {
            #region Public Interface

            public override Enemy MakeRequest(IDbConnection connection, FindEnemy query)
            {
                return EnemyRecord.AsEnemy(
                    connection.QuerySingle<EnemyRecord>(EnemyRecord.Find, query)
                );
            }

            #endregion
        }

        #endregion
    }
}
