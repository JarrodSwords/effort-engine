using Effort.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain.Configuration
{
    public abstract partial class Character : AggregateRoot
    {
        #region Creation

        protected Character(IBuilder builder) : base(builder.GetId())
        {
            CharacterTypes = builder.GetCharacterTypes();
            Name = builder.GetName();
        }

        #endregion

        #region Public Interface

        public CharacterTypes CharacterTypes { get; }
        public Name Name { get; }

        #endregion
    }
}
