using System;
using System.Collections.Generic;
using System.Linq;
using Effort.Domain;
using static SuperMarioRpg.Domain.Old.Combat.Stats;

namespace SuperMarioRpg.Domain.Old.Combat
{
    public class ManualPlayerCharacterBuilder : IPlayerCharacterBuilder
    {
        #region Creation

        public ManualPlayerCharacterBuilder()
        {
            Reset();
        }

        #endregion

        #region Public Interface

        public Equipment Accessory { get; private set; }
        public Equipment Armor { get; private set; }
        public CharacterTypes CharacterType { get; private set; }
        public Guid Id { get; private set; }
        public Name Name { get; }
        public Stats NaturalStats { get; private set; }
        public Equipment Weapon { get; private set; }
        public Xp Xp => new();

        public ManualPlayerCharacterBuilder Add(params Equipment[] equipment)
        {
            Equipment.AddRange(equipment);
            return this;
        }

        public PlayerCharacter Build()
        {
            var character = new PlayerCharacter(this);

            Reset();

            return character;
        }

        public ManualPlayerCharacterBuilder For(CharacterTypes characterType)
        {
            CharacterType = characterType;
            return this;
        }

        public ManualPlayerCharacterBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public ManualPlayerCharacterBuilder WithNaturalStats(
            short attack = default,
            short defense = default,
            short hp = default,
            short specialAttack = default,
            short specialDefense = default,
            short speed = default
        )
        {
            Attack = attack;
            Defense = defense;
            Hp = hp;
            SpecialAttack = specialAttack;
            SpecialDefense = specialDefense;
            Speed = speed;

            return this;
        }

        #endregion

        #region Private Interface

        private short Attack { get; set; }
        private short Defense { get; set; }
        private List<Equipment> Equipment { get; } = new();
        private short Hp { get; set; }
        private short SpecialAttack { get; set; }
        private short SpecialDefense { get; set; }
        private short Speed { get; set; }

        private void Reset()
        {
            Id = Guid.Empty;
            CharacterType = CharacterTypes.Mario;
            Equipment.Clear();
            NaturalStats = Default;
        }

        #endregion

        #region IPlayerCharacterBuilder Implementation

        public void CreateLoadout()
        {
            Accessory = Equipment.SingleOrDefault(x => x.EquipmentSlot == EquipmentSlot.Accessory);
            Armor = Equipment.SingleOrDefault(x => x.EquipmentSlot == EquipmentSlot.Armor);
            Weapon = Equipment.SingleOrDefault(x => x.EquipmentSlot == EquipmentSlot.Weapon);
        }

        public void CreateNaturalStats()
        {
            NaturalStats = CreateStats(Attack, Defense, Hp, SpecialAttack, SpecialDefense, Speed);
        }

        public CharacterTypes GetCharacterType() => CharacterType;
        public Id GetId() => new(Id);
        public Loadout GetLoadout() => new(Accessory, Armor, Weapon);
        public Name GetName() => Name;
        public Stats GetNaturalStats() => NaturalStats;
        public Xp GetXp() => Xp;

        #endregion
    }
}