﻿using System.Collections.Generic;
using System.Linq;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class CombatStats : Entity
    {
        #region Creation

        public CombatStats(Id id = default, Stats stats = default) : base(id)
        {
            Stats = stats;
        }

        #endregion

        #region Public Interface

        public Stats Stats { get; }

        #endregion
    }

    public class Stats : ValueObject
    {
        public static Stats Default = CreateStats();

        #region Creation

        private Stats(
            Stat attack,
            Stat defense,
            Stat hp,
            Stat specialAttack,
            Stat specialDefense,
            Stat speed,
            Stat evade,
            Stat magicEvade
        )
        {
            Attack = attack;
            Defense = defense;
            Hp = hp;
            SpecialAttack = specialAttack;
            SpecialDefense = specialDefense;
            Speed = speed;
            Evade = evade;
            MagicEvade = magicEvade;
        }

        private Stats(
            short attack,
            short defense,
            short hp,
            short specialAttack,
            short specialDefense,
            short speed,
            decimal evade,
            decimal magicEvade
        ) : this(
            new Stat(attack),
            new Stat(defense),
            new Stat(hp),
            new Stat(specialAttack),
            new Stat(specialDefense),
            new Stat(speed),
            new Stat((short) evade),
            new Stat((short) magicEvade)
        )
        {
        }

        #endregion

        #region Public Interface

        public Stat Attack { get; }
        public Stat Defense { get; }
        public Stat Evade { get; }
        public Stat Hp { get; }
        public Stat MagicEvade { get; }
        public Stat SpecialAttack { get; }
        public Stat SpecialDefense { get; }
        public Stat Speed { get; }

        public static Stats Aggregate(params Stats[] stats)
        {
            return stats.Aggregate((x, y) => x + y);
        }

        public static Stats CreateStats(
            short attack = default,
            short defense = default,
            short hp = default,
            short specialAttack = default,
            short specialDefense = default,
            short speed = default,
            decimal evade = default,
            decimal magicEvade = default
        )
        {
            return new(
                attack,
                defense,
                hp,
                specialAttack,
                specialDefense,
                speed,
                evade,
                magicEvade
            );
        }

        public static Stats CreateStats(
            Stat attack,
            Stat defense,
            Stat hp,
            Stat specialAttack,
            Stat specialDefense,
            Stat speed,
            Stat evade,
            Stat magicEvade
        )
        {
            return new(
                attack,
                defense,
                hp,
                specialAttack,
                specialDefense,
                speed,
                evade,
                magicEvade
            );
        }

        #endregion

        #region Equality, Operators

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Attack;
            yield return Defense;
            yield return Evade;
            yield return Hp;
            yield return MagicEvade;
            yield return SpecialAttack;
            yield return SpecialDefense;
            yield return Speed;
        }

        public static Stats operator +(Stats left, Stats right)
        {
            return CreateStats(
                left.Attack + right.Attack,
                left.Defense + right.Defense,
                left.Hp + right.Hp,
                left.SpecialAttack + right.SpecialAttack,
                left.SpecialDefense + right.SpecialDefense,
                left.Speed + right.Speed,
                left.Evade + right.Evade,
                left.MagicEvade + right.MagicEvade
            );
        }

        #endregion
    }
}
