using System;
using static SuperMarioRpg.Domain.Combat.StatFactory;

namespace SuperMarioRpg.Domain.Combat
{
    public abstract class CharacterBuilder
    {
        #region Core

        protected CharacterBuilder()
        {
            Reset();
        }

        #endregion

        #region Public Interface

        public Characters CharacterType { get; protected set; }
        public Guid Id { get; protected set; }
        public Loadout Loadout { get; protected set; }
        public Stats NaturalStats { get; protected set; }

        public Character Build()
        {
            var character = new Character(this);

            Reset();

            return character;
        }

        public void CreateNaturalStats()
        {
            NaturalStats = CreateStats(CharacterType);
        }

        #endregion

        #region Protected Interface

        protected abstract void ResetExplicit();

        #endregion

        #region Private Interface

        private void Reset()
        {
            Id = Guid.Empty;
            CharacterType = Characters.Mario;
            Loadout = new Loadout();
            NaturalStats = new Stats();
            ResetExplicit();
        }

        #endregion
    }
}
