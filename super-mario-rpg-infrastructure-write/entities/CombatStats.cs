using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Infrastructure.Write
{
    public class CombatStats : Entity
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

        public static CombatStats From(Enemy.CombatStats combatStats)
        {
            var (hitPoints, flowerPoints, speed, attack, magicAttack, defense, magicDefense, evade, magicEvade) =
                combatStats;

            return new CombatStats(
                hitPoints,
                flowerPoints,
                speed,
                attack,
                magicAttack,
                defense,
                magicDefense,
                evade,
                magicEvade
            );
        }

        #endregion
    }
}
