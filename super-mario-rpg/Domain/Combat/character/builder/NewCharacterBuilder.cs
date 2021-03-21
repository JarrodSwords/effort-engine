using System;
using System.Collections.Generic;
using Effort.Domain;
using static Effort.Domain.Id;
using static Effort.Domain.Name;
using static SuperMarioRpg.Domain.Combat.Xp;

namespace SuperMarioRpg.Domain.Combat
{
    public class NewCharacterBuilder : ICharacterBuilder
    {
        private static readonly IReadOnlyDictionary<CharacterTypes, ushort> BaseExp =
            new Dictionary<CharacterTypes, ushort>
            {
                { CharacterTypes.Bowser, 470 },
                { CharacterTypes.Geno, 234 },
                { CharacterTypes.Mallow, 30 },
                { CharacterTypes.Mario, 0 },
                { CharacterTypes.Toadstool, 600 }
            };

        #region Creation

        public NewCharacterBuilder()
        {
            Reset();
        }

        #endregion

        #region Public Interface

        public Equipment Accessory { get; }
        public Equipment Armor { get; private set; }
        public CharacterTypes CharacterType { get; private set; }
        public Guid Id { get; }
        public Name Name => CreateName(CharacterType.ToString());
        public Stats NaturalStats { get; private set; }
        public Equipment Weapon { get; private set; }
        public Xp Xp => CreateXp(BaseExp[CharacterType]);

        public Character Build()
        {
            var character = new Character(this);

            Reset();

            return character;
        }

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

        #region ICharacterBuilder Implementation

        public CharacterTypes GetCharacterType() => CharacterType;

        public Id GetId() => CreateId(Id);

        public Loadout GetLoadout() => new (Accessory, Armor, Weapon);

        public Name GetName() => Name;

        public Stats GetNaturalStats() => NaturalStats;

        public Xp GetXp() => Xp;

        #endregion
    }
}
