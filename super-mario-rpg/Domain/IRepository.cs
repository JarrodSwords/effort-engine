using System;
using System.Linq.Expressions;
using Effort.Domain;

namespace SuperMarioRpg.Domain
{
    public interface IRepository<T> where T : AggregateRoot
    {
        #region Public Interface

        void Commit();
        string Create(T aggregateRoot);
        T Find(Id id);
        T Find(Expression<Func<T, bool>> predicate);
        void Update(T aggregateRoot);

        #endregion
    }
}
