using System;
using System.Collections.Generic;

namespace SuperMarioRpg.Domain.Battle
{
    public class CharacterBuilder : ICharacterBuilder
    {
        #region Core

        private readonly Characters _character;
        private readonly List<Equipment> _equipment;
        private Loadout _loadout;
        private Stats _naturalStats;

        public CharacterBuilder(Characters character)
        {
            _character = character;
            _equipment = new List<Equipment>();
        }

        #endregion

        #region Public Interface

        public Stats EffectiveStats { get; private set; }
        public Guid Id { get; private set; }

        public Loadout Loadout
        {
            get => _loadout ??= new Loadout();
            private set => _loadout = value;
        }

        public Stats NaturalStats
        {
            get => _naturalStats ??= new Stats();
            private set => _naturalStats = value;
        }

        public Character Build()
        {
            Validate();
            return new Character(this);
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

        #region Private Interface

        private void Validate()
        {
            if (!Loadout.IsCompatible(_character))
                throw new ArgumentException();
        }

        #endregion

        #region ICharacterBuilder

        public void CalculateEffectiveStats()
        {
            EffectiveStats = NaturalStats
                           + Loadout.Accessory.Stats
                           + Loadout.Armor.Stats
                           + Loadout.Weapon.Stats;
        }

        public void CreateLoadout()
        {
            Loadout = new Loadout(_equipment.ToArray());
        }

        public void CreateNaturalStats()
        {
            NaturalStats = StatFactory.Instance.Create(_character);
        }

        #endregion
    }
}
