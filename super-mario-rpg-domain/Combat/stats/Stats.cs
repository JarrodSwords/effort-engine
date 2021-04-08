using System.Linq;

namespace SuperMarioRpg.Domain.Combat
{
    public record Stats
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
            new Stat(attack),
            new Stat(defense),
            new Stat(hp),
            new Stat(specialAttack),
            new Stat(specialDefense),
            new Stat(speed)
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

        public static Stats CreateStats(
            short attack = default,
            short defense = default,
            short hp = default,
            short specialAttack = default,
            short specialDefense = default,
            short speed = default
        )
        {
            return new(attack, defense, hp, specialAttack, specialDefense, speed);
        }

        public static Stats CreateStats(
            Stat attack,
            Stat defense,
            Stat hp,
            Stat specialAttack,
            Stat specialDefense,
            Stat speed
        )
        {
            return new(attack, defense, hp, specialAttack, specialDefense, speed);
        }

        #endregion

        #region Equality, Operators

        public static Stats operator +(Stats left, Stats right)
        {
            return CreateStats(
                left.Attack + right.Attack,
                left.Defense + right.Defense,
                left.Hp + right.Hp,
                left.SpecialAttack + right.SpecialAttack,
                left.SpecialDefense + right.SpecialDefense,
                left.Speed + right.Speed
            );
        }

        #endregion
    }
}
