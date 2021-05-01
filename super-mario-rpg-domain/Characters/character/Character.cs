using Effort.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain.Characters
{
    public abstract class Character : AggregateRoot
    {
        #region Creation

        protected Character(ICharacterBuilder builder) : base(builder.GetId())
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
