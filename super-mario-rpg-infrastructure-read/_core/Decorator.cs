using Effort.Domain.Messages;

namespace SuperMarioRpg.Infrastructure.Read
{
    public abstract class Decorator<TQuery, TResult> : Handler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        protected readonly IQueryHandler<TQuery, TResult> Handler;

        #region Creation

        protected Decorator(IQueryHandler<TQuery, TResult> handler)
        {
            Handler = handler;
        }

        #endregion
    }
}
