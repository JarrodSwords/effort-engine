using System;
using Effort.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain.Test
{
    public class FluentBuilder : Character.IBuilder
    {
        #region Public Interface

        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public NonPlayableCharacter BuildNonPlayerCharacter()
        {
            return new(this);
        }

        public FluentBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public FluentBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        #endregion

        #region IBuilder Implementation

        public CharacterTypes GetCharacterTypes()
        {
            return 0;
        }

        public Enemy.CombatStats GetEnemyCombatStats()
        {
            throw new NotImplementedException();
        }

        public Guid GetId()
        {
            return Id;
        }

        public Name GetName()
        {
            return Name;
        }

        public PlayableCharacter.CombatStats GetPlayableCharacterCombatStats()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
