using System;
using static SuperMarioRpg.Domain.Combat.StatFactory;

namespace SuperMarioRpg.Domain.Combat
{
    public abstract class CharacterBuilderBase
    {
        #region Core

        private Loadout _loadout;
        private Stats _naturalStats;

        protected CharacterBuilderBase(Characters characterType)
        {
            CharacterType = characterType;
        }

        #endregion

        #region Public Interface

        public Characters CharacterType { get; }
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

        public Character Build() => new Character(this);

        public void CreateNaturalStats()
        {
            NaturalStats = Create(CharacterType);
        }

        #endregion
    }
}
