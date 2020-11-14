using Effort.Domain;

namespace SuperMarioRpg.Domain.Battle
{
    public class Stats : ValueObject<Stats>
    {
        #region Core

        public Stats(
            byte attack,
            byte defense,
            byte hitPoints,
            byte specialAttack,
            byte specialDefense,
            byte speed
        )
        {
            Attack = attack;
            Defense = defense;
            HitPoints = hitPoints;
            SpecialAttack = specialAttack;
            SpecialDefense = specialDefense;
            Speed = speed;
        }

        #endregion

        #region Public Interface

        public byte Attack { get; }
        public byte Defense { get; }
        public byte HitPoints { get; }
        public byte SpecialAttack { get; }
        public byte SpecialDefense { get; }
        public byte Speed { get; }

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
                (byte) (addend1.Attack + addend2.Attack),
                (byte) (addend1.Defense + addend2.Defense),
                (byte) (addend1.HitPoints + addend2.HitPoints),
                (byte) (addend1.SpecialAttack + addend2.SpecialAttack),
                (byte) (addend1.SpecialDefense + addend2.SpecialDefense),
                (byte) (addend1.Speed + addend2.Speed)
            );

        #endregion
    }
}
