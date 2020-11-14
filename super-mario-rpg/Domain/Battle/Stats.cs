using System;
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
            if (attack > Max)
                throw new ArgumentOutOfRangeException(
                    nameof(attack),
                    attack,
                    $"\"{nameof(Attack)}\" cannot exceed {Max}."
                );

            if (defense > Max)
                throw new ArgumentOutOfRangeException(
                    nameof(attack),
                    attack,
                    $"\"{nameof(Defense)}\" cannot exceed {Max}."
                );

            if (hitPoints > Max)
                throw new ArgumentOutOfRangeException(
                    nameof(attack),
                    attack,
                    $"\"{nameof(HitPoints)}\" cannot exceed {Max}."
                );

            if (specialAttack > Max)
                throw new ArgumentOutOfRangeException(
                    nameof(attack),
                    attack,
                    $"\"{nameof(SpecialAttack)}\" cannot exceed {Max}."
                );

            if (specialDefense > Max)
                throw new ArgumentOutOfRangeException(
                    nameof(attack),
                    attack,
                    $"\"{nameof(SpecialDefense)}\" cannot exceed {Max}."
                );

            if (speed > Max)
                throw new ArgumentOutOfRangeException(
                    nameof(attack),
                    attack,
                    $"\"{nameof(Speed)}\" cannot exceed {Max}."
                );

            Attack = attack;
            Defense = defense;
            HitPoints = hitPoints;
            SpecialAttack = specialAttack;
            SpecialDefense = specialDefense;
            Speed = speed;
        }

        #endregion

        #region Public Interface

        public short Attack { get; }
        public short Defense { get; }
        public short HitPoints { get; }
        public short SpecialAttack { get; }
        public short SpecialDefense { get; }
        public short Speed { get; }

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
                (short) (addend1.Attack + addend2.Attack),
                (short) (addend1.Defense + addend2.Defense),
                (short) (addend1.HitPoints + addend2.HitPoints),
                (short) (addend1.SpecialAttack + addend2.SpecialAttack),
                (short) (addend1.SpecialDefense + addend2.SpecialDefense),
                (short) (addend1.Speed + addend2.Speed)
            );

        #endregion
    }
}
