using System.Linq;
using Effort.Domain;
using static SuperMarioRpg.Domain.Combat.Stat;

namespace SuperMarioRpg.Domain.Combat
{
    public class Stats : ValueObject<Stats>
    {
        public static Stats Default = CreateStats();

        #region Creation

        private Stats(
            Stat attack,
            Stat defense,
            Stat hp,
            Stat specialAttack,
            Stat specialDefense,
            Stat speed
        )
        {
            Attack = attack;
            Defense = defense;
            Hp = hp;
            SpecialAttack = specialAttack;
            SpecialDefense = specialDefense;
            Speed = speed;
        }

        private Stats(
            short attack,
            short defense,
            short hp,
            short specialAttack,
            short specialDefense,
            short speed
        ) : this(
            CreateStat(attack),
            CreateStat(defense),
            CreateStat(hp),
            CreateStat(specialAttack),
            CreateStat(specialDefense),
            CreateStat(speed)
        )
        {
        }

        public static Stats CreateStats(
            short attack = default,
            short defense = default,
            short hp = default,
            short specialAttack = default,
            short specialDefense = default,
            short speed = default
        ) =>
            new Stats(attack, defense, hp, specialAttack, specialDefense, speed);

        public static Stats CreateStats(
            Stat attack,
            Stat defense,
            Stat hp,
            Stat specialAttack,
            Stat specialDefense,
            Stat speed
        ) =>
            new Stats(attack, defense, hp, specialAttack, specialDefense, speed);

        #endregion

        #region Public Interface

        public Stat Attack { get; }
        public Stat Defense { get; }
        public Stat Hp { get; }
        public Stat SpecialAttack { get; }
        public Stat SpecialDefense { get; }
        public Stat Speed { get; }

        public static Stats Aggregate(params Stats[] stats)
        {
            return stats.Aggregate((x, y) => x + y);
        }

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(Stats other) =>
            Attack == other.Attack
         && Defense == other.Defense
         && Hp == other.Hp
         && SpecialAttack == other.SpecialAttack
         && SpecialDefense == other.SpecialDefense
         && Speed == other.Speed;

        protected override int GetHashCodeExplicit() =>
            (Attack, Defense, Hp, SpecialAttack, SpecialDefense, Speed).GetHashCode();

        public static Stats operator +(Stats left, Stats right) =>
            CreateStats(
                left.Attack + right.Attack,
                left.Defense + right.Defense,
                left.Hp + right.Hp,
                left.SpecialAttack + right.SpecialAttack,
                left.SpecialDefense + right.SpecialDefense,
                left.Speed + right.Speed
            );

        #endregion
    }
}
