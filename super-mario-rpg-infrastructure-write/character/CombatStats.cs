namespace SuperMarioRpg.Infrastructure.Write
{
    public class CombatStats : Entity
    {
        #region Creation

        public CombatStats()
        {
        }

        public CombatStats(
            ushort hitPoints,
            short attack,
            short magicAttack,
            short defense,
            short magicDefense,
            decimal evade,
            decimal magicEvade,
            short speed
        )
        {
            HitPoints = hitPoints;
            Attack = attack;
            MagicAttack = magicAttack;
            Defense = defense;
            MagicDefense = magicDefense;
            Evade = evade;
            MagicEvade = magicEvade;
            Speed = speed;
        }

        #endregion

        #region Public Interface

        public short Attack { get; set; }
        public short Defense { get; set; }
        public decimal Evade { get; set; }
        public ushort HitPoints { get; set; }
        public short MagicAttack { get; set; }
        public short MagicDefense { get; set; }
        public decimal MagicEvade { get; set; }
        public short Speed { get; set; }

        #endregion
    }
}
