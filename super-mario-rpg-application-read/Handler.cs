using System.Data;
using Effort.Domain.Messages;
using Npgsql;

namespace SuperMarioRpg.Application.Read
{
    public abstract class Handler<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        private const string ConnectionString =
            "User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=SuperMarioRpg;Pooling=true;";

        private IDbConnection _connection;

        #region Public Interface

        public abstract TResult Execute(TQuery query);

        #endregion

        #region Protected Interface

        protected IDbConnection Connection => _connection ??= new NpgsqlConnection(ConnectionString);

        #endregion

        #region IQueryHandler<TQuery,TResult> Implementation

        public TResult Handle(TQuery query)
        {
            using var _ = Connection;
            return Execute(query);
        }

        #endregion
    }
}
