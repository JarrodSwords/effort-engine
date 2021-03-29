using Effort.Domain;

namespace SuperMarioRpg.Domain
{
    public interface IRepository<T> where T : AggregateRoot
    {
        #region Public Interface

        void Commit();
        string Create(T character);
        T Find(Id id);
        void Update(T character);

        #endregion
    }
}
