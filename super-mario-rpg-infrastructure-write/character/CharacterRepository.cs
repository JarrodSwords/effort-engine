using System;
using Effort.Domain;

namespace SuperMarioRpg.Infrastructure.Write
{
    public class CharacterRepository : Repository<Character>, Domain.Character.IRepository
    {
        #region Creation

        public CharacterRepository(Context context) : base(context)
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

        #region IRepository<Character> Implementation

        public string Create(Domain.Character root)
        {
            throw new NotSupportedException();
        }

        public void Create(params Domain.Character[] root)
        {
            throw new NotSupportedException();
        }

        public Domain.Character Find(Id id)
        {
            throw new NotSupportedException();
        }

        public void Update(Domain.Character root)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
