using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Infrastructure.Write
{
    public class Statistics : Entity, IEnemyStatisticsBuilder
    {
        #region Creation

        public Statistics()
        {
        }

        public Statistics(
            short hitPoints = default,
            byte? flowerPoints = default,
            short speed = default,
            short attack = default,
            short magicAttack = default,
            short defense = default,
            short magicDefense = default,
            decimal? evade = default,
            decimal? magicEvade = default
        )
        {
            HitPoints = hitPoints;
            FlowerPoints = flowerPoints;
            Speed = speed;
            Attack = attack;
            MagicAttack = magicAttack;
            Defense = defense;
            MagicDefense = magicDefense;
            Evade = evade;
            MagicEvade = magicEvade;
        }

        #endregion

        #region Public Interface

        public short Attack { get; set; }
        public short Defense { get; set; }
        public decimal? Evade { get; set; }
        public byte? FlowerPoints { get; set; }
        public short HitPoints { get; set; }
        public short MagicAttack { get; set; }
        public short MagicDefense { get; set; }
        public decimal? MagicEvade { get; set; }
        public short Speed { get; set; }

        public EnemyStatistics BuildEnemyCombatStats() => new(this);

        public Statistics Update(Statistics statistics)
        {
            Attack = statistics.Attack;
            Defense = statistics.Defense;
            HitPoints = statistics.HitPoints;
            MagicAttack = statistics.MagicAttack;
            MagicDefense = statistics.MagicDefense;
            Speed = statistics.Speed;

            return this;
        }

        #endregion

        #region IEnemyStatisticsBuilder Implementation

        public decimal GetEvade() => Evade ?? default;
        public byte GetFlowerPoints() => FlowerPoints ?? default;
        public decimal GetMagicEvade() => MagicEvade ?? default;

        #endregion

        #region IStatisticsBuilder Implementation

        public Attack GetAttack() => Attack;
        public Defense GetDefense() => Defense;
        public HitPoints GetHitPoints() => HitPoints;
        public MagicAttack GetMagicAttack() => MagicAttack;
        public MagicDefense GetMagicDefense() => MagicDefense;
        public Speed GetSpeed() => Speed;

        #endregion

        #region Static Interface

        public static implicit operator Domain.Combat.Statistics(Statistics statistics) => new(statistics);

        public static implicit operator EnemyStatistics(Statistics statistics) => statistics.BuildEnemyCombatStats();

        public static implicit operator Statistics(EnemyStatistics statistics) =>
            new(
                statistics.HitPoints,
                statistics.FlowerPoints,
                statistics.Speed,
                statistics.Attack,
                statistics.MagicAttack,
                statistics.Defense,
                statistics.MagicDefense,
                statistics.Evade,
                statistics.MagicEvade
            );

        public static implicit operator Statistics(Domain.Combat.Statistics statistics) =>
            new(
                statistics.HitPoints,
                speed: statistics.Speed,
                attack: statistics.Attack,
                magicAttack: statistics.MagicAttack,
                defense: statistics.Defense,
                magicDefense: statistics.MagicDefense
            );

        #endregion
    }
}
