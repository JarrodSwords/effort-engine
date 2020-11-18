using System;
using System.Collections.Generic;

namespace SuperMarioRpg.Domain.Combat
{
    public class ManualCharacterBuilder : ICharacterBuilder
    {
        #region Core

        public ManualCharacterBuilder()
        {
            Reset();
        }

        #endregion

        #region Public Interface

        public ManualCharacterBuilder Add(params Equipment[] equipment)
        {
            Equipment.AddRange(equipment);
            return this;
        }

        public Character Build()
        {
            var character = new Character(this);

            Reset();

            return character;
        }

        public ManualCharacterBuilder For(CharacterTypes characterType)
        {
            CharacterType = characterType;
            return this;
        }

        public ManualCharacterBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public ManualCharacterBuilder WithNaturalStats(
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
        private List<Equipment> Equipment { get; } = new List<Equipment>();
        private short Hp { get; set; }
        private short SpecialAttack { get; set; }
        private short SpecialDefense { get; set; }
        private short Speed { get; set; }

        private void Reset()
        {
            Id = Guid.Empty;
            CharacterType = CharacterTypes.Mario;
            Equipment.Clear();
            Loadout = Loadout.Default;
            NaturalStats = Stats.Default;
        }

        #endregion

        #region ICharacterBuilder

        public CharacterTypes CharacterType { get; protected set; }
        public Guid Id { get; protected set; }
        public Level Level { get; protected set; }
        public Loadout Loadout { get; protected set; }
        public Stats NaturalStats { get; protected set; }
        public Xp Xp { get; protected set; }

        public void CreateLoadout()
        {
            Loadout = new Loadout(Equipment.ToArray());
        }

        public void CreateNaturalStats()
        {
            NaturalStats = Stats.Create(Attack, Defense, Hp, SpecialAttack, SpecialDefense, Speed);
        }

        #endregion
    }
}
