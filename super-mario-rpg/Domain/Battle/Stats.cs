using Effort.Domain;

namespace SuperMarioRpg.Domain.Battle
{
    public class Stats : ValueObject<Stats>
    {
        #region Core

        public const short Max = 255;

        public Stats(
            short attack,
            short defense,
            short hitPoints,
            short specialAttack,
            short specialDefense,
            short speed
        )
        {
            Attack = new Stat(attack);
            Defense = new Stat(defense);
            HitPoints = new Stat(hitPoints);
            SpecialAttack = new Stat(specialAttack);
            SpecialDefense = new Stat(specialDefense);
            Speed = new Stat(speed);
        }

        #endregion

        #region Public Interface

        public Stat Attack { get; }
        public Stat Defense { get; }
        public Stat HitPoints { get; }
        public Stat SpecialAttack { get; }
        public Stat SpecialDefense { get; }
        public Stat Speed { get; }

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
                (addend1.Attack + addend2.Attack).Value,
                (addend1.Defense + addend2.Defense).Value,
                (addend1.HitPoints + addend2.HitPoints).Value,
                (addend1.SpecialAttack + addend2.SpecialAttack).Value,
                (addend1.SpecialDefense + addend2.SpecialDefense).Value,
                (addend1.Speed + addend2.Speed).Value
            );

        #endregion
    }
}
