using Effort.Domain;

namespace SuperMarioRpg.Domain
{
    public interface IRepository<T> where T : AggregateRoot
    {
    }
}
