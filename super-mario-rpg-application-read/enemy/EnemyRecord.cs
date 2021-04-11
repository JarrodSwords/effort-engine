using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read
{
    internal record EnemyRecord(
        string name,
        int hit_points,
        short flower_points,
        short speed,
        short attack,
        short magic_attack,
        short defense,
        short magic_defense,
        decimal evade,
        decimal magic_evade
    )
    {
        #region Public Interface

        public static Enemy AsEnemy(EnemyRecord record)
        {
            var (name, hitPoints, flowerPoints, speed, attack, magicAttack, defense, magicDefense, evade,
                    magicEvade) =
                record;

            return new Enemy(
                name,
                new CombatStats(
                    (ushort) hitPoints,
                    (byte?) flowerPoints,
                    speed,
                    attack,
                    magicAttack,
                    defense,
                    magicDefense,
                    evade,
                    magicEvade
                )
            );
        }

        #endregion
    }
}
