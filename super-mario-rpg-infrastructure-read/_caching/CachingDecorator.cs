using Effort.Domain.Messages;
using Microsoft.Extensions.Caching.Memory;

namespace SuperMarioRpg.Infrastructure.Read
{
    public class CachingDecorator<TQuery, TResult> : Decorator<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        private readonly IMemoryCache _cache;

        #region Creation

        public CachingDecorator(
            IQueryHandler<TQuery, TResult> handler,
            IMemoryCache cache
        ) : base(handler)
        {
            _cache = cache;
        }

        #endregion

        #region Public Interface

        public override TResult Execute(TQuery query)
        {
            var key = query.GetType().Name;

            if (_cache.TryGetValue(key, out TResult value))
                return value;

            value = Handler.Handle(query);
            _cache.Set(key, value);
            return value;
        }

        #endregion
    }
}
