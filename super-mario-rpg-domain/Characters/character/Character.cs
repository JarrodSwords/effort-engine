using Effort.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain.Characters
{
    public abstract partial class Character : AggregateRoot
    {
        #region Creation

        protected Character(ICharacterBuilder characterBuilder) : base(characterBuilder.GetId())
        {
            CharacterTypes = characterBuilder.GetCharacterTypes();
            Name = characterBuilder.GetName();
        }

        #endregion

        #region Public Interface

        public CharacterTypes CharacterTypes { get; }
        public Name Name { get; }

        #endregion
    }
}
