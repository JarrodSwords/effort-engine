namespace SuperMarioRpg.Infrastructure.Write
{
    public class CombatStats : Entity
    {
        #region Creation

        public CombatStats()
        {
        }

        public CombatStats(
            short attack,
            short defense,
            decimal evade,
            ushort hitPoints,
            short magicAttack,
            short magicDefense,
            decimal magicEvade,
            short speed
        )
        {
            Attack = attack;
            Defense = defense;
            Evade = evade;
            HitPoints = hitPoints;
            MagicAttack = magicAttack;
            MagicDefense = magicDefense;
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
