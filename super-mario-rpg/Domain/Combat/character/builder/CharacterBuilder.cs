using System;
using System.Collections.Generic;

namespace SuperMarioRpg.Domain.Combat
{
    public class CharacterBuilder : ICharacterBuilder
    {
        #region Core

        public CharacterBuilder()
        {
            Reset();
        }

        #endregion

        #region Public Interface

        public CharacterBuilder Add(params Equipment[] equipment)
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

        public CharacterBuilder For(CharacterTypes characterType)
        {
            CharacterType = characterType;
            return this;
        }

        public CharacterBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public CharacterBuilder WithNaturalStats(
            short attack = 0,
            short defense = 0,
            short hitPoints = 0,
            short specialAttack = 0,
            short specialDefense = 0,
            short speed = 0
        )
        {
            Attack = attack;
            Defense = defense;
            HitPoints = hitPoints;
            SpecialAttack = specialAttack;
            SpecialDefense = specialDefense;
            Speed = speed;

            return this;
        }

        public CharacterBuilder WithProgressionStats(byte level, ushort experiencePoints)
        {
            Level = level;
            ExperiencePoints = experiencePoints;
            return this;
        }

        #endregion

        #region Private Interface

        private short Attack { get; set; }
        private short Defense { get; set; }
        private List<Equipment> Equipment { get; } = new List<Equipment>();
        private ushort ExperiencePoints { get; set; }
        private short HitPoints { get; set; }
        private byte Level { get; set; }
        private short SpecialAttack { get; set; }
        private short SpecialDefense { get; set; }
        private short Speed { get; set; }

        private void Reset()
        {
            Id = Guid.Empty;
            CharacterType = CharacterTypes.Mario;
            Equipment.Clear();
            Loadout = new Loadout();
            NaturalStats = new Stats();
        }

        #endregion

        #region ICharacterBuilder

        public CharacterTypes CharacterType { get; protected set; }
        public Guid Id { get; protected set; }
        public Loadout Loadout { get; protected set; }
        public Stats NaturalStats { get; protected set; }
        public ProgressionSystem ProgressionSystem { get; protected set; }

        public void CreateLoadout()
        {
            Loadout = new Loadout(Equipment.ToArray());
        }

        public void CreateNaturalStats()
        {
            NaturalStats = new Stats(Attack, Defense, HitPoints, SpecialAttack, SpecialDefense, Speed);
        }

        public void CreateProgressionSystem()
        {
            ProgressionSystem = new ProgressionSystem(new Level(Level), new ExperiencePoints(ExperiencePoints));
        }

        #endregion
    }
}
