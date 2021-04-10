using System;
using SuperMarioRpg.Api;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain
{
    public class NonPlayerCharacterBuilder : ICharacterBuilder
    {
        private CreateNonPlayerCharacterArgs _args;

        #region Public Interface

        public NonPlayerCharacter Build()
        {
            return new(this);
        }

        public NonPlayerCharacterBuilder From(CreateNonPlayerCharacterArgs args)
        {
            _args = args;
            return this;
        }

        #endregion

        #region ICharacterBuilder Implementation

        public Stats GetCombatStats()
        {
            throw new NotSupportedException();
        }

        public Guid GetId()
        {
            return Guid.Empty;
        }

        public string GetName()
        {
            return _args.Name;
        }

        #endregion
    }
}
