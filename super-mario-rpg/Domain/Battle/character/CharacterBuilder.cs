using System;
using System.Collections.Generic;

namespace SuperMarioRpg.Domain.Battle
{
    public class CharacterBuilder : ICharacterBuilder
    {
        #region Core

        private readonly List<Equipment> _equipment;
        private Loadout _loadout;
        private Stats _stats;

        public CharacterBuilder(Characters character)
        {
            Character = character;
            _equipment = new List<Equipment>();
        }

        #endregion

        #region Public Interface

        public Characters Character { get; }
        public Stats EffectiveStats { get; private set; }
        public Guid Id { get; private set; }

        public Loadout Loadout
        {
            get => _loadout ??= new Loadout();
            private set => _loadout = value;
        }

        public Stats Stats
        {
            get => _stats ??= new Stats();
            private set => _stats = value;
        }

        public Character Build()
        {
            Validate();
            return new Character(this);
        }

        public void Validate()
        {
            if (!Loadout.CheckCompatibility(Character))
                throw new ArgumentException();
        }

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

        public void CalculateEffectiveStats()
        {
            EffectiveStats = Stats
                           + Loadout.Accessory.Stats
                           + Loadout.Armor.Stats
                           + Loadout.Weapon.Stats;
        }

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
