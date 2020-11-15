using System;
using System.Collections.Generic;

namespace SuperMarioRpg.Domain.Battle
{
    public class CharacterBuilder : ICharacterBuilder
    {
        #region Core

        private readonly List<Equipment> _equipment;

        public CharacterBuilder(Characters character)
        {
            Character = character;
            _equipment = new List<Equipment>();
        }

        #endregion

        #region Public Interface

        public Characters Character { get; }
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
            Loadout = new Loadout(_equipment.ToArray());
        }

        public void CreateStats()
        {
            Stats = StatFactory.Instance.Create(Character);
        }

        #endregion
    }
}
