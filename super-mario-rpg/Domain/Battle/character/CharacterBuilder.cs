using System;

namespace SuperMarioRpg.Domain.Battle
{
    public abstract class CharacterBuilder
    {
        #region Core

        private readonly Characters _character;
        private Loadout _loadout;
        private Stats _naturalStats;

        protected CharacterBuilder(Characters character)
        {
            _character = character;
        }

        #endregion

        #region Public Interface

        public Stats EffectiveStats { get; private set; }
        public Guid Id { get; protected set; }

        public Loadout Loadout
        {
            get => _loadout ??= new Loadout();
            protected set => _loadout = value;
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

        public void CalculateEffectiveStats()
        {
            EffectiveStats = NaturalStats
                           + Loadout.Accessory.Stats
                           + Loadout.Armor.Stats
                           + Loadout.Weapon.Stats;
        }

        public void CreateNaturalStats()
        {
            NaturalStats = StatFactory.Instance.Create(_character);
        }

        #endregion

        #region Private Interface

        private void Validate()
        {
            if (!Loadout.IsCompatible(_character))
                throw new ArgumentException();
        }

        #endregion
    }
}
