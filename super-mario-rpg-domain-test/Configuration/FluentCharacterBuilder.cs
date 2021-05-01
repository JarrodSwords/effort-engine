using System;
using Effort.Domain;
using SuperMarioRpg.Domain.Characters;
using SuperMarioRpg.Domain.Old.Combat;

namespace SuperMarioRpg.Domain.Test.Configuration
{
    public class FluentCharacterBuilder : ICharacterBuilder
    {
        #region Public Interface

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public NonPlayableCharacter BuildNonPlayerCharacter() => new(this);

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

        public CharacterTypes GetCharacterTypes() => 0;
        public Id GetId() => Id;
        public Name GetName() => Name;

        #endregion
    }
}
