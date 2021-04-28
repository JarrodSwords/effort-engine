using System.Data;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read.Characters.Enemies
{
    public record Find(string Name) : IQuery<Enemy>
    {
        internal class Handler : Handler<Find, Enemy>
        {
            #region Public Interface

            public override Enemy MakeRequest(IDbConnection connection, Find query) =>
                connection.QuerySingle<Record>(Record.Find, query);

            #endregion
        }
    }
}
