using Effort.Domain;

namespace SuperMarioRpg.Domain
{
    public abstract partial class Character
    {
        #region Nested Types

        public interface IRepository : IRepository<Character>
        {
            #region Public Interface

            IRepository Delete(Name name);

            #endregion
        }

        #endregion
    }
}
