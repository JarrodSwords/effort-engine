using System;
using SuperMarioRpg.Api;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain
{
    public class NonPlayerCharacterBuilder : ICharacterBuilder
    {
        private CharacterDto _character;

        #region Public Interface

        public NonPlayerCharacter Build()
        {
            return new(this);
        }

        public NonPlayerCharacterBuilder From(CharacterDto character)
        {
            _character = character;
            return this;
        }

        #endregion

        #region ICharacterBuilder Implementation

        public Stats GetCombatStats()
        {
            var (attack, defense, hitPoints, magicAttack, magicDefense, speed) = _character.CombatStats;

            return Stats.CreateStats(attack, defense, (short) hitPoints, magicAttack, magicDefense, speed);
        }

        public Guid GetId()
        {
            return _character.Id;
        }

        public string GetName()
        {
            return _character.Name;
        }

        #endregion
    }
}
