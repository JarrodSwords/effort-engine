using System;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain
{
    public class FluentCharacterBuilder : ICharacterBuilder
    {
        #region Public Interface

        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public NonPlayerCharacter BuildNonPlayerCharacter()
        {
            return new(this);
        }

        public FluentCharacterBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public FluentCharacterBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        #endregion

        #region ICharacterBuilder Implementation

        public Stats GetCombatStats()
        {
            throw new NotImplementedException();
        }

        public Guid GetId()
        {
            return Id;
        }

        public string GetName()
        {
            return Name;
        }

        #endregion
    }
}
