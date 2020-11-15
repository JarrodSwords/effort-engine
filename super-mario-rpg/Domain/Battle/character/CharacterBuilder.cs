using System;
using System.Collections.Generic;

namespace SuperMarioRpg.Domain.Battle
{
    public class CharacterBuilder : ICharacterBuilder
    {
        #region Core

        private readonly CharacterType _characterType;
        private readonly List<Equipment> _equipment;

        public CharacterBuilder(CharacterType characterType)
        {
            _characterType = characterType;
            _equipment = new List<Equipment>();
        }

        #endregion

        #region Public Interface

        public Guid Id { get; private set; }
        public Loadout Loadout { get; private set; }
        public Stats Stats { get; private set; }

        public Character Build() => new Character(this);

        public CharacterBuilder WithEquipment(params Equipment[] equipment)
        {
            _equipment.AddRange(equipment);
            return this;
        }

        public CharacterBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        #endregion

        #region ICharacterBuilder

        public void CreateLoadout()
        {
            Loadout = new Loadout(_equipment);
        }

        public void CreateStats()
        {
            Stats = StatFactory.Instance.Create(_characterType);
        }

        #endregion
    }
}
