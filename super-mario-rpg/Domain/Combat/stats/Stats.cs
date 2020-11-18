using System.Linq;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class Stats : ValueObject<Stats>
    {
        #region Core

        public static Stats Default = new Stats();

        public Stats(
            short attack = 0,
            short defense = 0,
            short hitPoints = 0,
            short specialAttack = 0,
            short specialDefense = 0,
            short speed = 0
        )
        {
            Attack = new Stat(attack);
            Defense = new Stat(defense);
            HitPoints = new Stat(hitPoints);
            SpecialAttack = new Stat(specialAttack);
            SpecialDefense = new Stat(specialDefense);
            Speed = new Stat(speed);
        }

        public Stats(
            Stat attack,
            Stat defense,
            Stat hitPoints,
            Stat specialAttack,
            Stat specialDefense,
            Stat speed
        ) : this(
            attack.Value,
            defense.Value,
            hitPoints.Value,
            specialAttack.Value,
            specialDefense.Value,
            speed.Value
        )
        {
        }

        #endregion

        #region Public Interface

        public Stat Attack { get; }
        public Stat Defense { get; }
        public Stat HitPoints { get; }
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
         && HitPoints == other.HitPoints
         && SpecialAttack == other.SpecialAttack
         && SpecialDefense == other.SpecialDefense
         && Speed == other.Speed;

        protected override int GetHashCodeExplicit() =>
            (Attack, Defense, HitPoints, SpecialAttack, SpecialDefense, Speed).GetHashCode();

        public static Stats operator +(Stats addend1, Stats addend2) =>
            new Stats(
                addend1.Attack + addend2.Attack,
                addend1.Defense + addend2.Defense,
                addend1.HitPoints + addend2.HitPoints,
                addend1.SpecialAttack + addend2.SpecialAttack,
                addend1.SpecialDefense + addend2.SpecialDefense,
                addend1.Speed + addend2.Speed
            );

        #endregion
    }
}
