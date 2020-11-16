using System;
using static SuperMarioRpg.Domain.Combat.StatFactory;

namespace SuperMarioRpg.Domain.Combat
{
    public abstract class CharacterBuilder : ICharacterBuilder
    {
        #region Core

        protected CharacterBuilder()
        {
            Reset();
        }

        #endregion

        #region Public Interface

        public CharacterTypes CharacterType { get; protected set; }
        public ExperiencePoints ExperiencePoints { get; protected set; }
        public Guid Id { get; protected set; }
        public Level Level { get; protected set; }
        public Loadout Loadout { get; protected set; }
        public Stats NaturalStats { get; protected set; }

        public Character Build()
        {
            var character = new Character(this);

            Reset();

            return character;
        }

        #endregion

        #region Protected Interface

        protected abstract void ResetExplicit();

        #endregion

        #region Private Interface

        private void Reset()
        {
            Id = Guid.Empty;
            CharacterType = CharacterTypes.Mario;
            Loadout = new Loadout();
            NaturalStats = new Stats();
            ExperiencePoints = new ExperiencePoints();
            ResetExplicit();
        }

        #endregion

        #region ICharacterBuilder

        public abstract void CreateLoadout();

        public void CreateNaturalStats()
        {
            NaturalStats = CreateStats(CharacterType);
        }

        public void InitializeGrowth()
        {
            var level = CharacterType switch
            {
                CharacterTypes.Bowser => 8,
                CharacterTypes.Geno => 6,
                CharacterTypes.Mallow => 2,
                CharacterTypes.Mario => 1,
                CharacterTypes.Toadstool => 9,
                _ => throw new ArgumentOutOfRangeException()
            };

            Level = new Level((byte) level);

            var experiencePoints = CharacterType switch
            {
                CharacterTypes.Bowser => 470,
                CharacterTypes.Geno => 234,
                CharacterTypes.Mallow => 30,
                CharacterTypes.Mario => 0,
                CharacterTypes.Toadstool => 600,
                _ => throw new ArgumentOutOfRangeException()
            };

            ExperiencePoints = new ExperiencePoints((ushort) experiencePoints);
        }

        #endregion
    }
}
