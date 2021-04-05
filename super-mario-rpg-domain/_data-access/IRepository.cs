using Effort.Domain;

namespace SuperMarioRpg.Domain
{
    public interface IRepository<T> where T : AggregateRoot
    {
        #region Public Interface

        void Commit();
        string Create(T root);
        void Create(params T[] root);
        T Find(Id id);
        void Update(T root);

        #endregion
    }
}
