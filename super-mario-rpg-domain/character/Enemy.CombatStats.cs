﻿namespace SuperMarioRpg.Domain
{
    public partial class Enemy
    {
        #region Nested Types

        public record CombatStats(
            ushort HitPoints,
            byte FlowerPoints,
            short Speed,
            short Attack,
            short MagicAttack,
            short Defense,
            short MagicDefense,
            decimal Evade,
            decimal MagicEvade
        );

        #endregion
    }
}