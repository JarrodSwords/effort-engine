using System;
using Effort.Domain;
using SuperMarioRpg.Domain.Characters;
using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Domain.Stats;
using CombatStats = SuperMarioRpg.Domain.Stats.CombatStats;

namespace SuperMarioRpg.Domain.Test.Configuration
{
    public class FluentCharacterBuilder : ICharacterBuilder
    {
        #region Public Interface

        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public NonPlayableCharacter BuildNonPlayerCharacter()
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

        public CharacterTypes GetCharacterTypes()
        {
            return 0;
        }

        public CombatStats GetCombatStats()
        {
            throw new NotImplementedException();
        }

        public EnemyCombatStats GetEnemyCombatStats()
        {
            throw new NotImplementedException();
        }

        public Id GetId()
        {
            return Id;
        }

        public Name GetName()
        {
            return Name;
        }

        #endregion
    }
}
