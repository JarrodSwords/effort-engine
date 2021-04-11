using Effort.Domain;

namespace SuperMarioRpg.Infrastructure.Write
{
    public partial class Character
    {
        #region Nested Types

        public class Repository : Repository<Character>, Domain.Character.IRepository
        {
            #region Creation

            public Repository(Context context) : base(context)
            {
            }

            #endregion

            #region IRepository Implementation

            public Domain.Character.IRepository Delete(Name name)
            {
                var character = Find(x => x.Name == name.Value);
                Delete(character);
                return this;
            }

            #endregion
        }

        #endregion
    }
}
