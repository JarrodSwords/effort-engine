using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Infrastructure.Write
{
    public class CombatStats : Entity, IEnemyCombatStatsBuilder
    {
        #region Creation

        public CombatStats()
        {
        }

        public CombatStats(
            ushort hitPoints = default,
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
        public ushort HitPoints { get; set; }
        public short MagicAttack { get; set; }
        public short MagicDefense { get; set; }
        public decimal? MagicEvade { get; set; }
        public short Speed { get; set; }

        public Domain.Combat.CombatStats Build() => new(this);
        public EnemyCombatStats BuildEnemyCombatStats() => new(this);

        public CombatStats Update(CombatStats combatStats)
        {
            Attack = combatStats.Attack;
            Defense = combatStats.Defense;
            HitPoints = combatStats.HitPoints;
            MagicAttack = combatStats.MagicAttack;
            MagicDefense = combatStats.MagicDefense;
            Speed = combatStats.Speed;

            return this;
        }

        #endregion

        #region ICombatStatsBuilder Implementation

        public short GetAttack() => Attack;
        public short GetDefense() => Defense;
        public ushort GetHitPoints() => HitPoints;
        public short GetMagicAttack() => MagicAttack;
        public short GetMagicDefense() => MagicDefense;
        public short GetSpeed() => Speed;

        #endregion

        #region IEnemyCombatStatsBuilder Implementation

        public decimal GetEvade() => Evade ?? default;
        public byte GetFlowerPoints() => FlowerPoints ?? default;
        public decimal GetMagicEvade() => MagicEvade ?? default;

        #endregion

        #region Static Interface

        public static implicit operator Domain.Combat.CombatStats(CombatStats combatStats) => combatStats.Build();

        public static implicit operator EnemyCombatStats(CombatStats combatStats) =>
            combatStats.BuildEnemyCombatStats();

        public static implicit operator CombatStats(EnemyCombatStats combatStats) =>
            new(
                combatStats.HitPoints,
                combatStats.FlowerPoints,
                combatStats.Speed,
                combatStats.Attack,
                combatStats.MagicAttack,
                combatStats.Defense,
                combatStats.MagicDefense,
                combatStats.Evade,
                combatStats.MagicEvade
            );

        public static implicit operator CombatStats(Domain.Combat.CombatStats combatStats) =>
            new(
                combatStats.HitPoints,
                speed: combatStats.Speed,
                attack: combatStats.Attack,
                magicAttack: combatStats.MagicAttack,
                defense: combatStats.Defense,
                magicDefense: combatStats.MagicDefense
            );

        #endregion
    }
}
