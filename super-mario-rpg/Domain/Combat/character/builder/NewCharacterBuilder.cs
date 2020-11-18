using System;
using System.Collections.Generic;
using static SuperMarioRpg.Domain.Combat.Level;
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

        public Equipment Accessory { get; }
        public Equipment Armor { get; private set; }
        public CharacterTypes CharacterType { get; private set; }
        public Guid Id { get; }
        public Level Level => CreateLevel(BaseLevel[CharacterType]);
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
