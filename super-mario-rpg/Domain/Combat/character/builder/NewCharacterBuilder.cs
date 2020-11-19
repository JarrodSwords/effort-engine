using System;
using System.Collections.Generic;
using static SuperMarioRpg.Domain.Combat.Stats;
using static SuperMarioRpg.Domain.Combat.Xp;

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

        public Equipment Accessory { get; }
        public Equipment Armor { get; private set; }
        public CharacterTypes CharacterType { get; private set; }
        public Guid Id { get; }

        public ICollection<Level> Levels =>
            new List<Level>
            {
                new Level(1, 0, Default),
                new Level(2, 16, CreateStats(3, 2, 5, 2, 2)),
                new Level(3, 48, CreateStats(3, 2, 5, 2, 2)),
                new Level(4, 84, CreateStats(3, 2, 5, 2, 2))
            };

        public Stats NaturalStats { get; private set; }
        public Equipment Weapon { get; private set; }
        public Xp Xp => CreateXp(BaseExp[CharacterType]);

        public void CreateLoadout()
        {
            if (CharacterType != CharacterTypes.Toadstool)
                return;

            Weapon = EquipmentFactory.SlapGlove;
            Armor = EquipmentFactory.PolkaDress;
        }

        public void CreateNaturalStats()
        {
            NaturalStats = StatFactory.CreateStats(CharacterType);
        }

        #endregion
    }
}
