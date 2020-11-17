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

        public ManualCharacterBuilder WithProgressionStats(byte level, ushort experiencePoints)
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
            ProgressionSystem = new ProgressionSystem(new Level(0), new ExperiencePoints(), NaturalStats);
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
            ProgressionSystem = new ProgressionSystem(
                new Level(Level),
                new ExperiencePoints(ExperiencePoints),
                NaturalStats
            );
        }

        #endregion
    }
}
