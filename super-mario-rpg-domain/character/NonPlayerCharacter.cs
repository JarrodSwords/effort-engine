using System;

namespace SuperMarioRpg.Domain
{
    public class NonPlayerCharacter : Character
    {
        #region Creation

        public NonPlayerCharacter(string name, Guid id = default) : base(id, name)
        {
        }

        public NonPlayerCharacter(ICharacterBuilder builder) : base(builder)
        {
        }

        #endregion
    }
}
