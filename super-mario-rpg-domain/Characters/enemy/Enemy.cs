﻿using SuperMarioRpg.Domain.Stats;

namespace SuperMarioRpg.Domain.Characters
{
    public class Enemy : Character
    {
        #region Creation

        public Enemy(IEnemyBuilder builder) : base(builder)
        {
            BaseStats = builder.GetCombatStats();
        }

        #endregion

        #region Public Interface

        public EnemyCombatStats BaseStats { get; }

        #endregion
    }
}