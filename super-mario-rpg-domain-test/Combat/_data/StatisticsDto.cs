using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public class StatisticsDto : IStatisticsBuilder
    {
        #region Creation

        public StatisticsDto(
            Attack attack,
            Defense defense,
            HitPoints hitPoints,
            MagicAttack magicAttack,
            MagicDefense magicDefense,
            Speed speed
        )
        {
            Attack = attack;
            Defense = defense;
            HitPoints = hitPoints;
            MagicAttack = magicAttack;
            MagicDefense = magicDefense;
            Speed = speed;
        }

        #endregion

        #region Public Interface

        public Attack Attack { get; }
        public Defense Defense { get; }
        public HitPoints HitPoints { get; }
        public MagicAttack MagicAttack { get; }
        public MagicDefense MagicDefense { get; }
        public Speed Speed { get; }

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

        public static implicit operator Statistics(StatisticsDto dto) => new(dto);

        #endregion
    }
}
