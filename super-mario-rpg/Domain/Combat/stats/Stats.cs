using System.Linq;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class Stats : ValueObject<Stats>
    {
        #region Core

        public static Stats Default = Create();

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
            Stat.Create(attack),
            Stat.Create(defense),
            Stat.Create(hp),
            Stat.Create(specialAttack),
            Stat.Create(specialDefense),
            Stat.Create(speed)
        )
        {
        }

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

        public static Stats Create(
            short attack = default,
            short defense = default,
            short hp = default,
            short specialAttack = default,
            short specialDefense = default,
            short speed = default
        ) =>
            new Stats(attack, defense, hp, specialAttack, specialDefense, speed);

        public static Stats Create(
            Stat attack,
            Stat defense,
            Stat hp,
            Stat specialAttack,
            Stat specialDefense,
            Stat speed
        ) =>
            new Stats(attack, defense, hp, specialAttack, specialDefense, speed);

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
            Create(
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
