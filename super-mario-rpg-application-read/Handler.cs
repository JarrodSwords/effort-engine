using System.Data;
using Effort.Domain.Messages;
using Npgsql;

namespace SuperMarioRpg.Application.Read
{
    public abstract class Handler<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        private const string ConnectionString =
            "User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=SuperMarioRpg;Pooling=true;";

        #region Public Interface

        public abstract TResult MakeRequest(IDbConnection connection, TQuery query);

        #endregion

        #region IQueryHandler<TQuery,TResult> Implementation

        public TResult Handle(TQuery query)
        {
            using var connection = new NpgsqlConnection(ConnectionString);

            return MakeRequest(connection, query);
        }

        #endregion
    }
}
