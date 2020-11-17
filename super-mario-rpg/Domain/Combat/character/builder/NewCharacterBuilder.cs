using System;
using System.Collections.Generic;

namespace SuperMarioRpg.Domain.Combat
{
    public class NewCharacterBuilder : ICharacterBuilder
    {
        #region Core

        private static readonly IReadOnlyDictionary<CharacterTypes, ushort> BaseExp =
            new Dictionary<CharacterTypes, ushort>
            {
                {CharacterTypes.Bowser, 470},
                {CharacterTypes.Geno, 234},
                {CharacterTypes.Mallow, 30},
                {CharacterTypes.Mario, 0},
                {CharacterTypes.Toadstool, 600}
            };

        private static readonly IReadOnlyDictionary<CharacterTypes, byte> BaseLevel =
            new Dictionary<CharacterTypes, byte>
            {
                {CharacterTypes.Bowser, 8},
                {CharacterTypes.Geno, 6},
                {CharacterTypes.Mallow, 2},
                {CharacterTypes.Mario, 1},
                {CharacterTypes.Toadstool, 9}
            };

        public NewCharacterBuilder()
        {
            Reset();
        }

        #endregion

        #region Public Interface

        public Character Build()
        {
            var character = new Character(this);

            Reset();

            return character;
        }

        public NewCharacterBuilder For(CharacterTypes characterType)
        {
            CharacterType = characterType;
            return this;
        }

        #endregion

        #region Private Interface

        private void Reset()
        {
            CharacterType = CharacterTypes.Mario;
        }

        #endregion

        #region ICharacterBuilder

        public CharacterTypes CharacterType { get; private set; }
        public Guid Id { get; } = Guid.Empty;
        public Loadout Loadout { get; private set; }
        public Stats NaturalStats { get; private set; }
        public ProgressionSystem ProgressionSystem { get; set; }

        public void CreateLoadout()
        {
            Loadout = new Loadout();
        }

        public void CreateNaturalStats()
        {
            NaturalStats = StatFactory.CreateStats(CharacterType);
        }

        public void CreateProgressionSystem()
        {
            ProgressionSystem = new ProgressionSystem(
                new Level(BaseLevel[CharacterType]),
                new ExperiencePoints(BaseExp[CharacterType]),
                NaturalStats
            );
        }

        #endregion
    }
}
