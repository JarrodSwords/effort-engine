using System;
using System.Linq;
using System.Linq.Expressions;
using Effort.Domain;

namespace SuperMarioRpg.Postgres
{
    public class RepositoryAdapter<TDom, TDb> : IRepository<TDb>
        where TDom : AggregateRoot
        where TDb : Entity<TDom>
    {
        private readonly Context _context;

        #region Creation

        protected RepositoryAdapter(Context context)
        {
            _context = context;
        }

        #endregion

        #region Public Interface

        public TDom Find(Expression<Func<TDb, bool>> predicate)
        {
            return _context
                .Set<TDb>()
                .AsQueryable()
                .Single(predicate)
                .To();
        }

        #endregion

        #region IRepository<TDb> Implementation

        public void Commit()
        {
            _context.SaveChanges();
        }

        public TDb Create(TDb entity)
        {
            return _context.Add(entity).Entity;
        }

        public TDb Find(Guid id)
        {
            return _context.Find<TDb>(id);
        }

        public void Update(TDb entity)
        {
            _context.Update(entity);
        }

        TDb IRepository<TDb>.Find(Expression<Func<TDb, bool>> predicate)
        {
            return _context
                .Set<TDb>()
                .AsQueryable()
                .Single(predicate);
        }

        #endregion
    }
}
