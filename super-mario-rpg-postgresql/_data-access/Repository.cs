using System;
using System.Linq;
using System.Linq.Expressions;

namespace SuperMarioRpg.Postgres
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly Context _context;

        #region Creation

        protected Repository(Context context)
        {
            _context = context;
        }

        #endregion

        #region IRepository<T> Implementation

        public void Commit()
        {
            _context.SaveChanges();
        }

        public T Create(T entity)
        {
            return _context.Add(entity).Entity;
        }

        public T Find(Guid id)
        {
            return _context.Find<T>(id);
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return _context
                .Set<T>()
                .AsQueryable()
                .Single(predicate);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        #endregion
    }
}
